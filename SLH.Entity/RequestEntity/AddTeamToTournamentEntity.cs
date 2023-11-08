using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLH.Entity.RequestEntity
{
    public class AddTeamToTournamentEntity
    {
        public long Id { get; set; }
        public long OrganizerId { get; set; }
        public long TournamentId { get; set; }
        public long TeamId { get; set; }
    }
}
