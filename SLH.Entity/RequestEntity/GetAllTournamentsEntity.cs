using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLH.Entity.RequestEntity
{
    public class GetAllTournamentsEntity
    {
        public long Id { get; set; }
        public long OrganizerId { get; set; }
        public string SearchStr { get; set; }
    }
}
