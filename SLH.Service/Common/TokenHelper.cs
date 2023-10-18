using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SLH.Service.Common
{
    public class TokenHelper
    {
        /// <summary>
        /// Generates the token.
        /// </summary>
        /// <param name="claims">The claims.</param>
        /// <returns>
        /// returns generated token
        /// </returns>
        public string GenerateToken(Claim[] claims)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityKey key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(AppSettings.Secret));

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = this.GetTokenExpireTime(),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature),
            };

            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
        }

        /// <summary>
        /// Gets the token expire time.
        /// </summary>
        /// <returns>returns token expire time</returns>
        private DateTime GetTokenExpireTime()
        {
            return DateTime.UtcNow.AddDays(AppSettings.Expires);
        }
    }
}
