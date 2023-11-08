using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLH.Entity.RequestEntity
{
    public class AddPlayerToTeamEntity
    {
        public long Id { get; set; }
        public long OwnerId { get; set; }
        public long TeamId { get; set; }
        public long PlayerId { get; set; }
    }
}
