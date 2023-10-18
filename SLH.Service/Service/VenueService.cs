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
    public class VenueService: IVenueService
    {
        public ApiResult<List<GetVenueResponse>> GetAllVenues(GetAllVenuesEntity entity)
        {
            ApiResult<List<GetVenueResponse>> result = new ApiResult<List<GetVenueResponse>>();
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@userId", entity.UserId, DbType.Int64, ParameterDirection.Input);
            parameters.Add("@id", entity.Id, DbType.Int64, ParameterDirection.Input);
            parameters.Add("@searchStr", entity.SearchStr, DbType.String, ParameterDirection.Input);
            Helper.GetListData(ref result, ref parameters, SqlConstant.GetAllVenues);
            return result;
        }

        public ApiResult<GetVenueResponse> VenueAdd(AddVenueEntity entity)
        {
            ApiResult<GetVenueResponse> result = new ApiResult<GetVenueResponse>();
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@userId", entity.UserId, DbType.Int64, ParameterDirection.Input);
            parameters.Add("@name", entity.Name, DbType.String, ParameterDirection.Input);
            parameters.Add("@location", entity.Location, DbType.String, ParameterDirection.Input);
            parameters.Add("@country", entity.Country, DbType.String, ParameterDirection.Input);
            Helper.GetData(ref result, ref parameters, SqlConstant.VenueAdd);
            return result;
        }

        public ApiResult<GetVenueResponse> VenueUpdate(UpdateVenueEntity entity)
        {
            ApiResult<GetVenueResponse> result = new ApiResult<GetVenueResponse>();
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@userId", entity.UserId, DbType.Int64, ParameterDirection.Input);
            parameters.Add("@name", entity.Name, DbType.String, ParameterDirection.Input);
            parameters.Add("@id", entity.Id, DbType.Int64, ParameterDirection.Input);
            parameters.Add("@location", entity.Location, DbType.String, ParameterDirection.Input);
            parameters.Add("@country", entity.Country, DbType.String, ParameterDirection.Input);
            Helper.GetData(ref result, ref parameters, SqlConstant.VenueUpdate);
            return result;
        }

        public ApiResult<GetVenueResponse> VenueDelete(DeleteVenueEntity entity)
        {
            ApiResult<GetVenueResponse> result = new ApiResult<GetVenueResponse>();
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@userId", entity.UserId, DbType.Int64, ParameterDirection.Input);
            parameters.Add("@id", entity.Id, DbType.Int64, ParameterDirection.Input);
            Helper.GetData(ref result, ref parameters, SqlConstant.VenueDelete);
            return result;
        }
    }
}
