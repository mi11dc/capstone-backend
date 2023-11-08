using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLH.Entity.ResponseEntity
{
    public class GetVenueResponse
    {
        public long TotalCount { get; set; }
        public long Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Country { get; set; }
    }
}
