using SLH.Entity.ResponseEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SLH.Entity
{
    public class AuthenticationToken: UserDetailsResponse
    {
        public AuthenticationToken()
        {

        }

        public AuthenticationToken(UserDetailsResponse entity)
        {
            this.Id = entity.Id;
            this.Email = entity.Email;
            this.FirstName = entity.FirstName;
            this.LastName = entity.LastName;
            this.UserName = entity.UserName;
            this.UserRoleId = entity.UserRoleId;
            this.UserRoleName = entity.UserRoleName;
            this.DOB = entity.DOB;
            this.Country = entity.Country;
            this.UserBio = entity.UserBio;
            this.IsActive = entity.IsActive;
        }

        /// <summary>
        /// Gets or sets auth token.
        /// </summary>
        /// <value>
        /// The token.
        /// </value>
        public string Token { get; set; }
    }
}