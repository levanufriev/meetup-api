using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class EventDto
    {
        public Guid Id { get; set; }

        public string Theme { get; set; }

        public string Description { get; set; }

        public string Speaker { get; set; }

        public string DateAndPlace { get; set; }
    }
}
