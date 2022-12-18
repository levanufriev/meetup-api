﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.RequestFeatures
{
    public class RequestParameters
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 2;

        public DateTime MinDate { get; set; } = DateTime.UtcNow;
    }
}
