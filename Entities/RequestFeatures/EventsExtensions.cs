using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.RequestFeatures
{
    public static class EventsExtensions
    {
        public static IQueryable<Event> Filter(this IQueryable<Event> events, DateTime minDate)
        {
            return events.Where(e => (e.Date>=minDate));
        }

        public static IQueryable<Event> Search(this IQueryable<Event> events, string searchTheme)
        {
            if (string.IsNullOrEmpty(searchTheme))
            {
                return events;
            }

            var theme = searchTheme.Trim().ToLower();

            return events.Where(e => (e.Theme.ToLower().Contains(theme)));
        }
    }
}
