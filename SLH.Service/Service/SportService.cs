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
    public class SportService: ISportService
    {
        public ApiResult<List<GetSportResponse>> GetAllSports(GetAllSportsEntity entity)
        {
            ApiResult<List<GetSportResponse>> result = new ApiResult<List<GetSportResponse>>();
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@userId", entity.UserId, DbType.Int64, ParameterDirection.Input);
            parameters.Add("@id", entity.Id, DbType.Int64, ParameterDirection.Input);
            parameters.Add("@searchStr", entity.SearchStr, DbType.String, ParameterDirection.Input);
            //BaseHelper.AddPageParams(new BaseSearchEntity()
            //{
            //    PageNo = entity.PageNo,
            //    PageSize = entity.PageSize
            //}, ref parameters);
            Helper.GetListData(ref result, ref parameters, SqlConstant.GetAllSports);
            return result;
        }

        public ApiResult<GetSportResponse> SportAdd(AddSportEntity entity)
        {
            ApiResult<GetSportResponse> result = new ApiResult<GetSportResponse>();
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@userId", entity.UserId, DbType.Int64, ParameterDirection.Input);
            parameters.Add("@name", entity.Name, DbType.String, ParameterDirection.Input);
            Helper.GetData(ref result, ref parameters, SqlConstant.SportAdd);
            return result;
        }

        public ApiResult<GetSportResponse> SportUpdate(UpdateSportEntity entity)
        {
            ApiResult<GetSportResponse> result = new ApiResult<GetSportResponse>();
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@userId", entity.UserId, DbType.Int64, ParameterDirection.Input);
            parameters.Add("@name", entity.Name, DbType.String, ParameterDirection.Input);
            parameters.Add("@id", entity.Id, DbType.Int64, ParameterDirection.Input);
            Helper.GetData(ref result, ref parameters, SqlConstant.SportUpdate);
            return result;
        }

        public ApiResult<GetSportResponse> SportDelete(DeleteSportEntity entity)
        {
            ApiResult<GetSportResponse> result = new ApiResult<GetSportResponse>();
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@userId", entity.UserId, DbType.Int64, ParameterDirection.Input);
            parameters.Add("@id", entity.Id, DbType.Int64, ParameterDirection.Input);
            Helper.GetData(ref result, ref parameters, SqlConstant.SportDelete);
            return result;
        }
    }
}
