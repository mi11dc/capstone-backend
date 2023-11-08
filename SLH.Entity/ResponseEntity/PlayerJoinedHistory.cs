using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLH.Entity.ResponseEntity
{
    public class PlayerJoinedHistory
    {
        public long TeamPlayerId { get; set; }
        public long TeamId { get; set; }
        public string TeamName { get; set; }
        public string JoinedDate { get; set; }
        public string ReleasedDate { get; set; }
    }
}
