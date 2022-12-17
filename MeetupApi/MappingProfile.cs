using AutoMapper;
using Entities.Dtos;
using Entities.Models;

namespace MeetupApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Event, EventDto>()
                .ForMember(e => e.DateAndPlace, 
                           o => o.MapFrom(x => string.Join(' ', x.Date, x.Place)));

            CreateMap<EventForCreationDto, Event>();

            CreateMap<EventForUpdateDto, Event>().ReverseMap();
        }
    }
}
