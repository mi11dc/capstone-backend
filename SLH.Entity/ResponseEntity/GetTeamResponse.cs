using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLH.Entity.ResponseEntity
{
    public class GetTeamResponse
    {
        public long TotalCount { get; set; }
        public long Id { get; set; }
        public long OwnerId { get; set; }
        public string OwnerFName { get; set; }
        public string OwnerLName { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string SportName { get; set; }
        public long SportId { get; set; }

        public List<PlayerDetailsResponse> LstPlayers { get; set; }
    }
}
