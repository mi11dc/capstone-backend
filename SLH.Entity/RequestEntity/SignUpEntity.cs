using System;
using System.Collections.Generic;
using System.Text;

namespace SLH.Entity.RequestEntity
{
    public class SignUpEntity
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public long UserRole { get; set; }
    }
}
