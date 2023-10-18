using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLH.Entity.ResponseEntity
{
    public class PlayerDetailsResponse
    {
        public long Id { get; set; }
        public long SportId { get; set; }
        public string SportName { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
    }
}
