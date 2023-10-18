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
    public class MatchService: IMatchService
    {
        public ApiResult<List<GetMatchResponse>> GetAllMatches(GetAllMatchesEntity entity)
        {
            ApiResult<List<GetMatchResponse>> result = new ApiResult<List<GetMatchResponse>>();
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@userId", entity.UserId, DbType.Int64, ParameterDirection.Input);
            parameters.Add("@id", entity.Id, DbType.Int64, ParameterDirection.Input);
            parameters.Add("@searchStr", entity.SearchStr, DbType.String, ParameterDirection.Input);
            Helper.GetListData(ref result, ref parameters, SqlConstant.GetAllMatches);
            return result;
        }

        public ApiResult<GetMatchResponse> MatchAdd(AddMatchEntity entity)
        {
            ApiResult<GetMatchResponse> result = new ApiResult<GetMatchResponse>();
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@userId", entity.UserId, DbType.Int64, ParameterDirection.Input);
            parameters.Add("@team1Id", entity.Team1Id, DbType.Int64, ParameterDirection.Input);
            parameters.Add("@team2Id", entity.Team2Id, DbType.Int64, ParameterDirection.Input);
            parameters.Add("@tournamentId", entity.TournamentId, DbType.Int64, ParameterDirection.Input);
            parameters.Add("@tournamentVenueId", entity.TournamentVenueId, DbType.Int64, ParameterDirection.Input);
            parameters.Add("@result", entity.Result, DbType.String, ParameterDirection.Input);
            parameters.Add("@dateTime", entity.DateTime, DbType.DateTime, ParameterDirection.Input);
            Helper.GetData(ref result, ref parameters, SqlConstant.MatchAdd);
            return result;
        }

        public ApiResult<GetMatchResponse> MatchUpdate(UpdateMatchEntity entity)
        {
            ApiResult<GetMatchResponse> result = new ApiResult<GetMatchResponse>();
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@userId", entity.UserId, DbType.Int64, ParameterDirection.Input);
            parameters.Add("@id", entity.Id, DbType.Int64, ParameterDirection.Input);
            parameters.Add("@team1Id", entity.Team1Id, DbType.Int64, ParameterDirection.Input);
            parameters.Add("@team2Id", entity.Team2Id, DbType.Int64, ParameterDirection.Input);
            parameters.Add("@tournamentId", entity.TournamentId, DbType.Int64, ParameterDirection.Input);
            parameters.Add("@tournamentVenueId", entity.TournamentVenueId, DbType.Int64, ParameterDirection.Input);
            parameters.Add("@result", entity.Result, DbType.String, ParameterDirection.Input);
            parameters.Add("@dateTime", entity.DateTime, DbType.DateTime, ParameterDirection.Input); 
            Helper.GetData(ref result, ref parameters, SqlConstant.MatchUpdate);
            return result;
        }

        public ApiResult<GetMatchResponse> MatchDelete(DeleteMatchEntity entity)
        {
            ApiResult<GetMatchResponse> result = new ApiResult<GetMatchResponse>();
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@userId", entity.UserId, DbType.Int64, ParameterDirection.Input);
            parameters.Add("@id", entity.Id, DbType.Int64, ParameterDirection.Input);
            Helper.GetData(ref result, ref parameters, SqlConstant.MatchDelete);
            return result;
        }
    }
}
