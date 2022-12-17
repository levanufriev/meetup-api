using Contracts;
using Entities;
using Entities.Models;
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

        public async Task<IEnumerable<Event>> GetAllEventsAsync(bool trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(e => e.Theme).ToListAsync();
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
