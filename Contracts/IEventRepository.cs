using Entities.Models;
using Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IEventRepository
    {
        Task<PagedList<Event>> GetAllEventsAsync(RequestParameters parameters, bool trackChanges);
        Task<Event> GetEventAsync(Guid id, bool trackChanges);
        void CreateEvent(Event _event);
        void DeleteEvent(Event _event);

        Task SaveAsync();
    }
}
