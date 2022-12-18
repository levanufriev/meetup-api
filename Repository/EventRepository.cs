using Contracts;
using Entities;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class EventRepository : RepositoryBase<Event>, IEventRepository
    {
        public EventRepository(RepositoryContext repositoryContext)
            :base(repositoryContext) { }

        public void CreateEvent(Event _event)
        {
            Create(_event);
        }

        public void DeleteEvent(Event _event)
        {
            Delete(_event);
        }

        public async Task<PagedList<Event>> GetAllEventsAsync(RequestParameters parameters, bool trackChanges)
        {
            var events = await FindByCondition(e => (e.Date>=parameters.MinDate), trackChanges)
                               .OrderBy(e => e.Theme)
                               .ToListAsync();
            
            return PagedList<Event>.ToPagedList(events, parameters.PageNumber, parameters.PageSize);
        }

        public async Task<Event> GetEventAsync(Guid id, bool trackChanges)
        {
            return await FindByCondition(e => e.Id.Equals(id), trackChanges).SingleOrDefaultAsync();
        }

        public async Task SaveAsync()
        {
            await repositoryContext.SaveChangesAsync();
        }
    }
}
