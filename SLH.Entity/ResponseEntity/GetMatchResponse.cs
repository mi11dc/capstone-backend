using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLH.Entity.ResponseEntity
{
    public class GetMatchResponse
    {
        public long Id { get; set; }
        public long Team1 { get; set; }
        public string Team1Name { get; set; }
        public long Team2 { get; set; }
        public string Team2Name { get; set; }
        public long TournamentId { get; set; }
        public string TournamentName { get; set; }
        public long TournamentVenueId { get; set; }
        public string TournamentVenueName { get; set; }
        public DateTime DateTime { get; set; }
        public string Result { get; set; }
    }
}
