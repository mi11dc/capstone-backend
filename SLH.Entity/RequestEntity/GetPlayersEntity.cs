using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLH.Entity.RequestEntity
{
    public class GetPlayersEntity
    {
        public long TeamId { get; set; }
        public long UserId { get; set; }
        public long SportId { get; set; }
    }
}
