﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLH.Entity.RequestEntity
{
    public class AddVenueEntity
    {
        public long Id { get; set; }
        public long Name { get; set; }
        public long UserId { get; set; }
        public string Location { get; set; }
        public string Country { get; set; }
    }
}
