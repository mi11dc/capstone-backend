using Dapper;
using SLH.Common;
using SLH.Entity.RequestEntity;
using SLH.Entity.ResponseEntity;
using SLH.Service.Common;
using SLH.Service.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLH.Service.Service
{
    public class TeamService: ITeamService
    {
        public ApiResult<List<GetTeamResponse>> GetAllTeams(GetAllTeamsEntity entity)
        {
            ApiResult<List<GetTeamResponse>> result = new ApiResult<List<GetTeamResponse>>();
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ownerId", entity.OwnerId, DbType.Int64, ParameterDirection.Input);
            parameters.Add("@id", entity.Id, DbType.Int64, ParameterDirection.Input);
            parameters.Add("@searchStr", entity.SearchStr, DbType.String, ParameterDirection.Input);
            Helper.GetListData(ref result, ref parameters, SqlConstant.GetAllTeams);
            return result;
        }

        public ApiResult<GetTeamResponse> TeamAdd(AddTeamEntity entity)
        {
            ApiResult<GetTeamResponse> result = new ApiResult<GetTeamResponse>();
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ownerId", entity.OwnerId, DbType.Int64, ParameterDirection.Input);
            parameters.Add("@name", entity.Name, DbType.String, ParameterDirection.Input);
            parameters.Add("@country", entity.Country, DbType.String, ParameterDirection.Input);
            parameters.Add("@sportId", entity.SportId, DbType.Int64, ParameterDirection.Input);
            Helper.GetData(ref result, ref parameters, SqlConstant.TeamAdd);
            return result;
        }

        public ApiResult<GetTeamResponse> TeamUpdate(UpdateTeamEntity entity)
        {
            ApiResult<GetTeamResponse> result = new ApiResult<GetTeamResponse>();
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ownerId", entity.OwnerId, DbType.Int64, ParameterDirection.Input);
            parameters.Add("@id", entity.Id, DbType.Int64, ParameterDirection.Input);
            parameters.Add("@country", entity.Country, DbType.String, ParameterDirection.Input);
            parameters.Add("@name", entity.Name, DbType.String, ParameterDirection.Input);
            parameters.Add("@sportId", entity.SportId, DbType.Int64, ParameterDirection.Input);
            Helper.GetData(ref result, ref parameters, SqlConstant.TeamUpdate);
            return result;
        }

        public ApiResult<GetTeamResponse> TeamDelete(DeleteTeamEntity entity)
        {
            ApiResult<GetTeamResponse> result = new ApiResult<GetTeamResponse>();
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ownerId", entity.OwnerId, DbType.Int64, ParameterDirection.Input);
            parameters.Add("@id", entity.Id, DbType.Int64, ParameterDirection.Input);
            Helper.GetData(ref result, ref parameters, SqlConstant.TeamDelete);
            return result;
        }
    }
}
