using AutoMapper;
using Azure;
using Azure.Core;
using Contracts;
using Entities.Dtos;
using Entities.Models;
using Entities.RequestFeatures;
using MeetupApi.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Configuration;
using Xunit;

namespace MeetupApi.Tests
{
    public class EventsControllerTests
    {
        private readonly Mock<IEventRepository> repositoryMock = new Mock<IEventRepository>();
        private readonly Mock<ILogger<EventsController>> loggerMock = new Mock<ILogger<EventsController>>();
        private readonly Mock<IMapper> mapperMock = new Mock<IMapper>();

        [Fact]
        public async Task GetEvents_WithoutParameters_ReturnsFirstPage()
        {
            var events = new[] { CreateRandomEvent(), CreateRandomEvent(), CreateRandomEvent(), CreateRandomEvent(), CreateRandomEvent() };

            var dtos = new List<EventDto>();
            foreach (var _event in events)
            {
                dtos.Add(ConvertToDto(_event));
            }

            var parameters = new RequestParameters();

            PagedList<Event> pagedList = PagedList<Event>.ToPagedList(events, 1, 2);
            repositoryMock.Setup(repo => repo.GetAllEventsAsync(parameters, false))
                .ReturnsAsync(pagedList);

            mapperMock.Setup(m => m.Map<IEnumerable<EventDto>>(pagedList)).Returns(dtos);

            var controller = new EventsController(repositoryMock.Object, loggerMock.Object, mapperMock.Object);
            controller.ControllerContext = new ControllerContext();
            controller.ControllerContext.HttpContext = new DefaultHttpContext();


            var response = await controller.GetEvents(parameters);
            OkObjectResult result = Assert.IsType<OkObjectResult>(response);
            Assert.Equal(dtos, result.Value);
        }

        [Fact]
        public async Task GetEvents_WithFilterAndSearch_ReturnsFirstPage()
        {
            var events = new[] { CreateRandomEvent(), CreateRandomEvent(), CreateRandomEvent(), CreateRandomEvent(), CreateRandomEvent() };

            var parameters = new RequestParameters()
            {
                MinDate = DateTime.Now.AddDays(-1)
            };

            var expectedEvents = events.Where(e =>
                (e.Date >= parameters.MinDate
                && e.Theme.ToLower().Contains(parameters.SearchTheme.Trim().ToLower())));

            var dtos = new List<EventDto>();
            foreach (var _event in expectedEvents)
            {
                dtos.Add(ConvertToDto(_event));
            }

            PagedList<Event> pagedList = PagedList<Event>.ToPagedList(events, 1, 2);
            repositoryMock.Setup(repo => repo.GetAllEventsAsync(parameters, false))
                .ReturnsAsync(pagedList);

            mapperMock.Setup(m => m.Map<IEnumerable<EventDto>>(pagedList)).Returns(dtos);

            var controller = new EventsController(repositoryMock.Object, loggerMock.Object, mapperMock.Object);
            controller.ControllerContext = new ControllerContext();
            controller.ControllerContext.HttpContext = new DefaultHttpContext();


            var response = await controller.GetEvents(parameters);
            OkObjectResult result = Assert.IsType<OkObjectResult>(response);
            Assert.Equal(dtos, result.Value);
        }

        [Fact]
        public async Task GetEvent_WithUnexistingEvent_ReturnsNotFound()
        {
            repositoryMock.Setup(repo => repo.GetEventAsync(It.IsAny<Guid>(), false))
                .ReturnsAsync((Event)null);

            var controller = new EventsController(repositoryMock.Object, loggerMock.Object, mapperMock.Object);

            var result = await controller.GetEvent(Guid.NewGuid());

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task GetEvent_WithExistingEvent_ReturnsExpectedEvent()
        {
            var _event = CreateRandomEvent();
            var dto = ConvertToDto(_event);

            repositoryMock.Setup(repo => repo.GetEventAsync(It.IsAny<Guid>(), false))
                .ReturnsAsync(_event);

            mapperMock.Setup(m => m.Map<EventDto>(_event)).Returns(dto);

            var controller = new EventsController(repositoryMock.Object, loggerMock.Object, mapperMock.Object);

            var response = await controller.GetEvent(Guid.NewGuid());
            OkObjectResult result = Assert.IsType<OkObjectResult>(response);
            Assert.Equal(dto, result.Value);
        }

        [Fact]
        public async Task CreateEvent_WithEventToCreate_ReturnsCreatedEvent()
        {
            var eventToCreate = new EventForCreationDto()
            {
                Theme = Guid.NewGuid().ToString(),
                Description = Guid.NewGuid().ToString(),
                Speaker = Guid.NewGuid().ToString(),
                Place = Guid.NewGuid().ToString(),
                Date = DateTime.Now
            };

            var _event = ConvertToEvent(eventToCreate);
            var dto = ConvertToDto(_event);

            mapperMock.Setup(m => m.Map<Event>(eventToCreate)).Returns(_event);
            mapperMock.Setup(m => m.Map<EventDto>(_event)).Returns(dto);

            var controller = new EventsController(repositoryMock.Object, loggerMock.Object, mapperMock.Object);

            var response = await controller.CreateEvent(eventToCreate);
            CreatedAtRouteResult result = Assert.IsType<CreatedAtRouteResult>(response);
            Assert.Equal(dto, result.Value);
        }

        [Fact]
        public async Task UpdateEvent_WithExistingEvent_ReturnsNoContent()
        {
            Event eventToChange = CreateRandomEvent();
            repositoryMock.Setup(repo => repo.GetEventAsync(It.IsAny<Guid>(), true))
                .ReturnsAsync(eventToChange);

            var eventId = eventToChange.Id;
            var eventToUpdate = new EventForUpdateDto()
            {
                Theme = Guid.NewGuid().ToString(),
                Description = Guid.NewGuid().ToString(),
                Speaker = Guid.NewGuid().ToString(),
                Place = Guid.NewGuid().ToString(),
                Date = DateTime.Now
            };

            var controller = new EventsController(repositoryMock.Object, loggerMock.Object, mapperMock.Object);

            var result = await controller.UpdateEvent(eventId, eventToUpdate);

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task DeleteEvent_WithExistingEvent_ReturnsNoContent()
        {
            Event _event = CreateRandomEvent();
            repositoryMock.Setup(repo => repo.GetEventAsync(It.IsAny<Guid>(), false))
                .ReturnsAsync(_event);

            var controller = new EventsController(repositoryMock.Object, loggerMock.Object, mapperMock.Object);

            var result = await controller.DeleteEvent(_event.Id);

            Assert.IsType<NoContentResult>(result);
        }

        private Event CreateRandomEvent()
        {
            return new Event()
            {
                Id = Guid.NewGuid(),
                Theme = Guid.NewGuid().ToString(),
                Description = Guid.NewGuid().ToString(),
                Speaker = Guid.NewGuid().ToString(),
                Place = Guid.NewGuid().ToString(),
                Date = DateTime.Now,
            };
        }

        private EventDto ConvertToDto(Event _event)
        {
            return new EventDto()
            {
                Id = _event.Id,
                Theme = _event.Theme,
                Description = _event.Description,
                Speaker = _event.Speaker,
                DateAndPlace = string.Join(' ', _event.Date, _event.Place)
            };
        }

        private Event ConvertToEvent(EventForCreationDto dto)
        {
            return new Event()
            {
                Id = Guid.NewGuid(),
                Theme = dto.Theme,
                Description = dto.Description,
                Speaker = dto.Speaker,
                Date = dto.Date,
                Place = dto.Place
            };
        }
    }
}