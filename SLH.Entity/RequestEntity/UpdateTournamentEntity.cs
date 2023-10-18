using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLH.Entity.RequestEntity
{
    public class UpdateTournamentEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long OrganizerId { get; set; }
        public long SportId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
