using Microsoft.AspNetCore.Mvc;
using SLH.Common;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using SLH.Entity.ResponseEntity;
using SLH.Entity;

namespace SLH
{
    public class BaseController : ControllerBase
    {
        protected IActionResult GetResult<T>(ApiResult<T> result, bool errorBody = false)
            where T : class
        {
            if (result == null)
            {
                return this.StatusCode((int)HttpStatusCode.InternalServerError);
            }
            else if (!result.IsValid())
            {
                if (errorBody || !string.IsNullOrWhiteSpace(result.Message))
                {
                    return this.GetErrorResult(result.GetCode(), result.Message);
                }

                return this.StatusCode(result.GetCode());
            }

            return this.StatusCode(result.GetCode(), new SuccessResult<T>(result));
        }

        protected IActionResult GetErrorResult(int code, string message)
        {
            return this.GetErrorResult(code, new List<string> { message });
        }

        protected IActionResult GetErrorResult(int code, IEnumerable<string> messages)
        {
            return this.GetErrorResult((HttpStatusCode)code, messages);
        }

        protected IActionResult GetErrorResult(HttpStatusCode code, IEnumerable<string> messages)
        {
            ErrorResult result = new ErrorResult();
            result.Message.AddRange(messages);

            return this.StatusCode((int)code, result);
        }

        protected ICollection<string> ValidatePost<T>(T model)
            where T : class
        {
            ICollection<string> errors = this.Validate<T>(model);

            return errors;
        }

        protected ICollection<string> Validate<T>(T model)
        where T : class
        {
            List<string> errors = new List<string>();

            if (model == null || !this.ModelState.IsValid)
            {
                errors.AddRange(this.GetModelStateErrors());
            }

            return errors;
        }

        private IEnumerable<string> GetModelStateErrors()
        {
            return this.ModelState.Values.SelectMany(e => e.Errors.Select(m => m.ErrorMessage));
        }

        protected long GetUserID()
        {
            string token = this.Request.Headers.ContainsKey("Authorization") ? this.Request.Headers["Authorization"].FirstOrDefault() : string.Empty;
            if (!string.IsNullOrWhiteSpace(token))
            {
                token = token.Replace("Bearer", string.Empty).Trim();
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                JwtSecurityToken readToken = tokenHandler.ReadToken(token) as JwtSecurityToken;
                return Convert.ToInt64(readToken.Claims.Where(x => x.Type == "userid").FirstOrDefault().Value ?? "0");
            }
            return 0;
        }

        protected long GetUserFromToken(string token)
        {
            if (!string.IsNullOrWhiteSpace(token))
            {
                token = token.Replace("Bearer", string.Empty).Trim();
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                JwtSecurityToken readToken = tokenHandler.ReadToken(token) as JwtSecurityToken;
                return Convert.ToInt64(readToken.Claims.Where(x => x.Type == "userid").FirstOrDefault().Value ?? "0");
            }
            return 0;
        }

        protected ApiResult<AuthenticationToken> LoginUserObj(ApiResult<UserDetailsResponse> response)
        {
            string token = this.Request.Headers.ContainsKey("Authorization") ? this.Request.Headers["Authorization"].FirstOrDefault() : string.Empty;
            ApiResult<AuthenticationToken> result;
            result = new ApiResult<AuthenticationToken>()
            {
                Code = response.Code,
                Message = response.Message,
                Item = new AuthenticationToken(response.Item)
                {
                    Token = (!string.IsNullOrWhiteSpace(token)) ? token : String.Empty
                }
            };
            return result;
        }
    }
}
