﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLH.Entity.RequestEntity
{
    public class AddTeamEntity
    {
        public string Name { get; set; }
        public long OwnerId { get; set; }
        public string Country { get; set; }
        public long SportId { get; set; }
    }
}
