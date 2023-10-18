using Dapper;
using SLH.Common;
using SLH.Entity;
using SLH.Entity.RequestEntity;
using SLH.Service.Common;
using SLH.Service.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using SLH.Entity.ResponseEntity;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Linq;
using SLH.Entity.GeneralEntity;

namespace SLH.Service.Service
{
    public class UserService: IUserService
    {

        public ApiResult<UserDetailsResponse> ValidateToken(string token)
        {
            ApiResult<UserDetailsResponse> result = new ApiResult<UserDetailsResponse>();

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            JwtSecurityToken readToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

            long userid = Convert.ToInt64(readToken.Claims.Where(x => x.Type == "userid").FirstOrDefault().Value ?? "0");
            UserDetailsResponse user = GetUser(userid).Item;

            if (user == null || !tokenHandler.CanValidateToken)
            {
                result.SetCode((int)HttpStatusCode.Unauthorized);
            }
            else
            {
                result.SetCode((int)HttpStatusCode.OK);
                result.Item = user;
            }

            return result;
        }

        public async Task<ApiResult<AuthenticationToken>> SignUp(SignUpEntity entity)
        {
            ApiResult<AuthenticationToken> result = new ApiResult<AuthenticationToken>();

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@email", entity.Email, DbType.String, ParameterDirection.Input);
            parameters.Add("@password", entity.Password, DbType.String, ParameterDirection.Input);
            parameters.Add("@username", entity.UserName, DbType.String, ParameterDirection.Input);
            parameters.Add("@roleId", entity.UserRole, DbType.Int64, ParameterDirection.Input);

            Helper.GetData(ref result, ref parameters, SqlConstant.SignUp);

            if (result.Code == 201)
            {
                result.Message = "You have register yourself successfully!!!";
                SignInEntity loginentity = new SignInEntity();
                loginentity.Email = entity.Email;
                loginentity.Password = entity.Password;
                ApiResult<AuthenticationToken> userresult = this.GenerateToken(loginentity);
                return userresult;
            }
            result.Item = null;
            return result;
        }

        public ApiResult<AuthenticationToken> GenerateToken(SignInEntity entity)
        {
            ApiResult<AuthenticationToken> result = new ApiResult<AuthenticationToken>();
            UserDetailsResponse user = new UserDetailsResponse();
            if (string.IsNullOrEmpty(entity.Password))
            {
                result.Code = 404;
                result.Message = "Password is required";
                return result;
            }

            //entity.Password = Helper.Encrypt(entity.Password);
            user = CheckUserLogin(entity).Item;
            if (user != null && user.Id != 0)
            {
                TokenHelper tokenHelper = new TokenHelper();
                result.Item = new AuthenticationToken(user)
                {
                    Token = tokenHelper.GenerateToken(new Claim[] { new Claim("username", user.Email), new Claim("userid", user.Id.ToString()) })
                };
                result.Message = "User logged in successfully";
                result.Code = 200;
            }
            else
            {
                result.Message = "Username or password incorrect";
                result.Code = 400;
            }

            return result;
        }

        private ApiResult<UserDetailsResponse> CheckUserLogin(SignInEntity loginEntity)
        {
            ApiResult<UserDetailsResponse> result = new ApiResult<UserDetailsResponse>();
            result.Item = new UserDetailsResponse();
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@email", loginEntity.Email, DbType.String, ParameterDirection.Input);
            parameters.Add("@password", loginEntity.Password, DbType.String, ParameterDirection.Input);
            Helper.GetData(ref result, ref parameters, SqlConstant.SignIn);

            return result;
        }

        private ApiResult<UserDetailsResponse> GetUser(long userId)
        {
            ApiResult<UserDetailsResponse> result = new ApiResult<UserDetailsResponse>();
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@UserId", userId, DbType.Int64, ParameterDirection.Input);
            Helper.GetData(ref result, ref parameters, SqlConstant.GetUserByUserId);
            return result;
        }

        [Obsolete]
        public ApiResult<UserDetailsResponse> UpdateUser(UpdateProfileEntity userEntity)
        {
            ApiResult<UserDetailsResponse> result = new ApiResult<UserDetailsResponse>();
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@id", userEntity.Id, DbType.Int64, ParameterDirection.Input);
            parameters.Add("@userid", userEntity.UserId, DbType.Int64, ParameterDirection.Input);
            parameters.Add("@fname", userEntity.FirstName, DbType.String, ParameterDirection.Input);
            parameters.Add("@lname", userEntity.LastName, DbType.String, ParameterDirection.Input);
            parameters.Add("@country", userEntity.Country, DbType.String, ParameterDirection.Input);
            parameters.Add("@dOB", userEntity.DOB, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("@userBio", userEntity.UserBio, DbType.String, ParameterDirection.Input);
  
            Helper.GetData(ref result, ref parameters, SqlConstant.UpdateProfile);

            return result;
        }

        public ApiResult<List<GetRoleResponse>> GetRolesForRegister(RoleForRegisterEntity entity)
        {
            ApiResult<List<GetRoleResponse>> result = new ApiResult<List<GetRoleResponse>>();
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@type", entity.Type, DbType.Int32, ParameterDirection.Input);

            Helper.GetListData(ref result, ref parameters, SqlConstant.GetRolesForRegister);

            return result;
        }

        public ApiResult<List<UserDetailsResponse>> RoleWiseUsers(GetUsersRoleWiseEntity entity)
        {
            ApiResult<List<UserDetailsResponse>> result = new ApiResult<List<UserDetailsResponse>>();
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@roleId", entity.RoleId, DbType.Int32, ParameterDirection.Input);

            Helper.GetListData(ref result, ref parameters, SqlConstant.RoleWiseUsers);

            return result;
        }
    }
}
