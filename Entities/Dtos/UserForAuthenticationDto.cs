using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class UserForAuthenticationDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }

    }
}
