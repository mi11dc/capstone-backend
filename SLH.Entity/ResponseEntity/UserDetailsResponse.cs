using System;
using System.Collections.Generic;
using System.Text;

namespace SLH.Entity.ResponseEntity
{
    public class UserDetailsResponse
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long UserRoleId { get; set; }
        public string UserRoleName { get; set; }
        public DateTime DOB { get; set; }
        public string Country { get; set; }
        public string UserBio { get; set; }
        public bool IsActive { get; set; }
    }
}
