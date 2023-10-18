using SLH.Common;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using SLH.Entity;
using SLH.Service.Interface;
using SLH.Entity.ResponseEntity;

namespace SLH
{
    public class AuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IUserService _userService;

        public AuthenticationHandler(
           IOptionsMonitor<AuthenticationSchemeOptions> options,
           ILoggerFactory logger,
           UrlEncoder encoder,
           ISystemClock clock,
           IUserService userService
            )
           : base(options, logger, encoder, clock)
        {
            _userService = userService;
        }

        /// <summary>
        /// Handles the authenticate asynchronous.
        /// </summary>
        /// <returns>returns AuthenticationResult</returns>
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            HttpResponseMessage response = null;

            if (!this.Request.Headers.ContainsKey("Authorization"))
            {
                return AuthenticateResult.Fail("Missing Authorization Header");
            }

            string token = this.Request.Headers.ContainsKey("Authorization") ? this.Request.Headers["Authorization"].FirstOrDefault() : string.Empty;
            token = token.Replace("Bearer", string.Empty).Trim();
            ApiResult<UserDetailsResponse> result = _userService.ValidateToken(token);
            //var result = new ApiResult<object>();

            if (result.Code == HttpStatusCode.OK.GetHashCode())
            {
                var claims = new[]
                {
                    new Claim("userid", result.Item.Id.ToString())
                };

                var identity = new ClaimsIdentity(claims, this.Scheme.Name);
                var principal = new ClaimsPrincipal(identity);
                var ticket = new AuthenticationTicket(principal, this.Scheme.Name);

                return AuthenticateResult.Success(ticket);
            }
            else
            {
                return AuthenticateResult.Fail("Unauthenticated User");
            }
        }
    }
}
