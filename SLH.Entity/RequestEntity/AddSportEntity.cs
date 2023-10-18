using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLH.Entity.RequestEntity
{
    public class AddSportEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long UserId { get; set; }
    }
}
