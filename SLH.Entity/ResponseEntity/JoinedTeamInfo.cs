using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLH.Entity.ResponseEntity
{
    public class JoinedTeamInfo
    {
        public long TeamPlayerId { get; set; }
        public long TeamId { get; set; }
        public long TeamName { get; set; }
        public long JoinedDate { get; set; }

        public List<PlayerJoinedHistory> JoinedHistory { get; set; }
    }
}
