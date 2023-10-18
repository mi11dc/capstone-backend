using SLH.Common;
using SLH.Entity.RequestEntity;
using SLH.Entity.ResponseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLH.Service.Interface
{
    public interface ISportService
    {
        ApiResult<List<GetSportResponse>> GetAllSports(GetAllSportsEntity entity);
        ApiResult<GetSportResponse> SportAdd(AddSportEntity entity);
        ApiResult<GetSportResponse> SportUpdate(UpdateSportEntity entity);
        ApiResult<GetSportResponse> SportDelete(DeleteSportEntity entity);
    }
}
