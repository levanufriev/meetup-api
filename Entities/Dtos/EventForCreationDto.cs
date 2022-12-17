using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class EventForCreationDto
    {
        public string Theme { get; set; }

        public string Description { get; set; }

        public string Speaker { get; set; }

        public DateTime Date { get; set; }

        public string Place { get; set; }
    }
}
