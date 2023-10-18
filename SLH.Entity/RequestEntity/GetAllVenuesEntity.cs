using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLH.Entity.RequestEntity
{
    public class GetAllVenuesEntity
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string SearchStr { get; set; }
    }
}
