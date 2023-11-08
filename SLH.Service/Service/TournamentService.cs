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
    public class TournamentService: ITournamentService
    {
        public ApiResult<List<GetTournamentResponse>> GetAllTournaments(GetAllTournamentsEntity entity)
        {
            ApiResult<List<GetTournamentResponse>> result = new ApiResult<List<GetTournamentResponse>>();
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@organizerId", entity.OrganizerId, DbType.Int64, ParameterDirection.Input);
            parameters.Add("@id", entity.Id, DbType.Int64, ParameterDirection.Input);
            parameters.Add("@searchStr", entity.SearchStr, DbType.String, ParameterDirection.Input);
            parameters.Add("@isDropdown", entity.IsDropdown, DbType.Boolean, ParameterDirection.Input);
            BaseHelper.AddPageParams(new BaseSearchEntity()
            {
                PageNo = entity.PageNo,
                PageSize = entity.PageSize
            }, ref parameters);
            Helper.GetListData(ref result, ref parameters, SqlConstant.GetAllTournaments);
            return result;
        }

        public ApiResult<GetTournamentResponse> TournamentAdd(AddTournamentEntity entity)
        {
            ApiResult<GetTournamentResponse> result = new ApiResult<GetTournamentResponse>();
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@organizerId", entity.OrganizerId, DbType.Int64, ParameterDirection.Input);
            parameters.Add("@name", entity.Name, DbType.String, ParameterDirection.Input); 
            parameters.Add("@startDate", entity.StartDate, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("@endDate", entity.EndDate, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("@sportId", entity.SportId, DbType.Int64, ParameterDirection.Input);
            Helper.GetData(ref result, ref parameters, SqlConstant.TournamentAdd);
            return result;
        }

        public ApiResult<GetTournamentResponse> TournamentUpdate(UpdateTournamentEntity entity)
        {
            ApiResult<GetTournamentResponse> result = new ApiResult<GetTournamentResponse>();
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@organizerId", entity.OrganizerId, DbType.Int64, ParameterDirection.Input);
            parameters.Add("@id", entity.Id, DbType.Int64, ParameterDirection.Input);
            parameters.Add("@startDate", entity.StartDate, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("@endDate", entity.EndDate, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("@name", entity.Name, DbType.String, ParameterDirection.Input);
            parameters.Add("@sportId", entity.SportId, DbType.Int64, ParameterDirection.Input);
            Helper.GetData(ref result, ref parameters, SqlConstant.TournamentUpdate);
            return result;
        }

        public ApiResult<GetTournamentResponse> TournamentDelete(DeleteTournamentEntity entity)
        {
            ApiResult<GetTournamentResponse> result = new ApiResult<GetTournamentResponse>();
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@organizerId", entity.OrganizerId, DbType.Int64, ParameterDirection.Input);
            parameters.Add("@id", entity.Id, DbType.Int64, ParameterDirection.Input);
            Helper.GetData(ref result, ref parameters, SqlConstant.TournamentDelete);
            return result;
        }

        public ApiResult<GetTournamentResponse> AddTournamentTeam(AddTeamToTournamentEntity entity)
        {
            ApiResult<GetTournamentResponse> result = new ApiResult<GetTournamentResponse>();
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ownerId", entity.OrganizerId, DbType.Int64, ParameterDirection.Input);
            parameters.Add("@teamId", entity.TeamId, DbType.Int64, ParameterDirection.Input);
            parameters.Add("@tournamentId", entity.TournamentId, DbType.Int64, ParameterDirection.Input);
            Helper.GetData(ref result, ref parameters, SqlConstant.TournamentTeamAdd);
            return result;
        }

        public ApiResult<GetTournamentResponse> ReleaseTournamentTeam(ReleaseTeamFromTournamentEntity entity)
        {
            ApiResult<GetTournamentResponse> result = new ApiResult<GetTournamentResponse>();
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ownerId", entity.OrganizerId, DbType.Int64, ParameterDirection.Input);
            parameters.Add("@id", entity.Id, DbType.String, ParameterDirection.Input);
            Helper.GetData(ref result, ref parameters, SqlConstant.TournamentTeamRelease);
            return result;
        }
    }
}
