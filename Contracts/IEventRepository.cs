using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetAllEventsAsync(bool trackChanges);
        Task<Event> GetEventAsync(Guid id, bool trackChanges);
        void CreateEvent(Event _event);

        Task SaveAsync();
    }
}
