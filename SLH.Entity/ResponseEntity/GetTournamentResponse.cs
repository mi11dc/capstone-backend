using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLH.Entity.ResponseEntity
{
    public class GetTournamentResponse
    {
        public long TotalCount { get; set; }
        public long Id { get; set; }
        public string Name { get; set; }
        public long OrganizerId { get; set; }
        public string OrganizerFName { get; set; }
        public string OrganizerLName { get; set; }
        public long SportId { get; set; }
        public string SportName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public List<GetTeamResponse> ListOfTeams { get; set; }
        //public List<GetTeamResponse> ListOfTeamsReleased { get; set; }
    }
}
