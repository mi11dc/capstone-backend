using SLH.Common;
using SLH.Entity;
using SLH.Entity.RequestEntity;
using SLH.Entity.ResponseEntity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SLH.Service.Interface
{
    public interface IUserService
    {
        ApiResult<UserDetailsResponse> ValidateToken(string token);
        Task<ApiResult<AuthenticationToken>> SignUp(SignUpEntity entity);
        ApiResult<AuthenticationToken> GenerateToken(SignInEntity loginEntity);
        ApiResult<UserDetailsResponse> UpdateUser(UpdateProfileEntity userEntity);
        ApiResult<List<GetRoleResponse>> GetRolesForRegister(RoleForRegisterEntity entity);
        ApiResult<List<UserDetailsResponse>> RoleWiseUsers(GetUsersRoleWiseEntity entity);
    }
}
