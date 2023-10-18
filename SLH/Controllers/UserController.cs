using SLH.Common;
using SLH.Entity;
using SLH.Entity.RequestEntity;
using SLH.Entity.ResponseEntity;
using SLH.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SLH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CORS")]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        /// <summary>
        /// Constructor of User Controller
        /// </summary>
        /// <param name="userService"></param>
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("UpdateProfile")]
        public IActionResult UpdateProfile(UpdateProfileEntity entity)
        {
            ICollection<string> errors = this.ValidatePost(entity);

            if (errors.Any())
                return this.GetErrorResult(System.Net.HttpStatusCode.BadRequest, errors);

            entity.Id = this.GetUserID();
            //ApiResult<UserDetailsResponse> result = _userService.UpdateUser(entity);
            ApiResult<AuthenticationToken> result = this.LoginUserObj(_userService.UpdateUser(entity));
            return this.GetResult(result);
        }

        [HttpPost]
        [Route("UpdateProfile")]
        public IActionResult GetUsersRoleWise(GetUsersRoleWiseEntity entity)
        {
            ICollection<string> errors = this.ValidatePost(entity);

            if (errors.Any())
                return this.GetErrorResult(System.Net.HttpStatusCode.BadRequest, errors);

            ApiResult<List<UserDetailsResponse>> result = _userService.RoleWiseUsers(entity);
            return this.GetResult(result);
        }

        //    [HttpPost]
        //    [Route("ChangeUserStatus")]
        //    public IActionResult ChangeUserStatus(ChangeUserStatusEntity entity)
        //    {
        //        ICollection<string> errors = this.ValidatePost(entity);

        //        if (errors.Any())
        //            return this.GetErrorResult(System.Net.HttpStatusCode.BadRequest, errors);

        //        entity.Id = this.GetUserID();
        //        ApiResult<AuthenticationToken> result = this.LoginUserObj(_userService.ChangeUserStatus(entity));
        //        //ApiResult<UserDetailsResponse> result = _userService.ChangeUserStatus(entity);
        //        return this.GetResult(result);
        //    }

        //    [HttpPost]
        //    [Route("ChangePassword")]
        //    public IActionResult ChangePassword(ChangePasswordEntity entity)
        //    {
        //        ICollection<string> errors = this.ValidatePost(entity);

        //        if (errors.Any())
        //            return this.GetErrorResult(System.Net.HttpStatusCode.BadRequest, errors);

        //        entity.Id = this.GetUserID();
        //        //ApiResult<UserDetailsResponse> result = _userService.ChangePassword(entity);
        //        ApiResult<AuthenticationToken> result = this.LoginUserObj(_userService.ChangePassword(entity));
        //        return this.GetResult(result);
        //    }

        //    [AllowAnonymous]
        //    [HttpPost]
        //    [Route("ForgotPassword")]
        //    public async Task<IActionResult> ForgotPassword(ForgotPasswordEntity entity)
        //    {
        //        ICollection<string> errors = this.ValidatePost(entity);

        //        if (errors.Any())
        //            return this.GetErrorResult(System.Net.HttpStatusCode.BadRequest, errors);
        //        ApiResult<UserDetailsResponse> result = await _userService.ForgotPassword(entity);
        //        return this.GetResult(result);
        //    }

        //[HttpPost]
        //[Route("GetUserById")]
        //public IActionResult GetUserById(UserDetailsByIdEntity entity)
        //{
        //    ICollection<string> errors = this.ValidatePost(entity);

        //    if (errors.Any())
        //        return this.GetErrorResult(System.Net.HttpStatusCode.BadRequest, errors);

        //    ApiResult<UserDetailsResponse> result = _userService.GetUserDetailsById(entity);
        //    return this.GetResult(result);
        //}
    }
}
