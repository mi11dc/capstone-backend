﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLH.Entity.RequestEntity
{
    public class GetAllTeamsEntity
    {
        public long Id { get; set; }
        public long OwnerId { get; set; }
        public string SearchStr { get; set; }
        public bool IsDropdown { get; set; }
        public int PageNo { get; set; }
        public int PageSize { get; set; }
    }
}
