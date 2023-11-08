using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SLH.Service.Interface;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SLH.Common;
using SLH.Entity.RequestEntity;
using SLH.Entity;
using System.Net;
using SLH.Entity.ResponseEntity;

namespace SLH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CORS")]
    [AllowAnonymous]
    public class LoginController : BaseController
    {
        private readonly IUserService _userService;

        /// <summary>
        /// Constructor of Login Controller
        /// </summary>
        /// <param name="userService"></param>
        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("SignUp")]
        public async Task<IActionResult> SignUp(SignUpEntity entity)
        {
            ICollection<string> errors = this.ValidatePost(entity);

            if (errors.Any())
                return this.GetErrorResult(System.Net.HttpStatusCode.BadRequest, errors);
            
            ApiResult<AuthenticationToken> result = await _userService.SignUp(entity);
            return this.GetResult(result);
        }

        [HttpPost]
        [Route("SignIn")]
        public IActionResult SignIn(SignInEntity entity)
        {
            ICollection<string> errors = this.ValidatePost(entity);

            if (errors.Any())
                return this.GetErrorResult(System.Net.HttpStatusCode.BadRequest, errors);
            

            ApiResult<AuthenticationToken> result = _userService.GenerateToken(entity);
            return this.GetResult(result);
        }

        [HttpPost]
        [Route("GetRoleForRegister")]
        public IActionResult GetRoleForRegister()
        {
            RoleForRegisterEntity entity = new RoleForRegisterEntity()
            {
                Type = 1,
            };

            ApiResult<List<GetRoleResponse>> result = _userService.GetRolesForRegister(entity);
            return this.GetResult(result);
        }

        [HttpPost]
        [Route("GetSportsForRegister")]
        public IActionResult GetSportsForRegister()
        {
            GetSportsForRegisterEntity entity = new GetSportsForRegisterEntity()
            {
                IsDropdown = true,
            };
            ApiResult<List<GetSportResponse>> result = _userService.GetSportForRegister(entity);
            return this.GetResult(result);
        }

        //[HttpPost]
        //[Route("ForgotPassword")]
        //public async Task<IActionResult> ForgotPassword(ForgotPasswordEntity entity)
        //{
        //    ICollection<string> errors = this.ValidatePost(entity);

        //    if (errors.Any())
        //        return this.GetErrorResult(System.Net.HttpStatusCode.BadRequest, errors);

        //    ApiResult<UserDetailsResponse> result = await _userService.ForgotPassword(entity);
        //    return this.GetResult(result);
        //}

        //[HttpGet]
        //[Route("AdminForgotPassword")]
        //public async Task<IActionResult> AdminForgotPassword()
        //{
        //    //ICollection<string> errors = this.ValidatePost(entity);

        //    //if (errors.Any())
        //    //    return this.GetErrorResult(System.Net.HttpStatusCode.BadRequest, errors);

        //    ApiResult<UserDetailsResponse> result = await _userService.AdminForgotPassword();
        //    return this.GetResult(result);
        //}

        //[HttpGet]
        //[Route("CheckAPI")]
        //public IActionResult CheckAPI()
        //{

        //    ApiResult<List<UserDetailsResponse>> result = _userService.GetAllUsers();

        //    return this.GetErrorResult((int)HttpStatusCode.OK, "API working");
        //}
    }
}
