using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLH.Entity.RequestEntity
{
    public class AddMatchEntity
    {
        public long UserId { get; set; }
        public long Team1Id { get; set; }
        public long Team2Id { get; set; }
        public long TournamentId { get; set; }
        public long TournamentVenueId { get; set; }
        public DateTime DateTime { get; set; }
        public string Result { get; set; }
    }
}
