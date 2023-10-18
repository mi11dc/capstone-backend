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
    public interface IMatchService
    {
        ApiResult<List<GetMatchResponse>> GetAllMatches(GetAllMatchesEntity entity);
        ApiResult<GetMatchResponse> MatchAdd(AddMatchEntity entity);
        ApiResult<GetMatchResponse> MatchUpdate(UpdateMatchEntity entity);
        ApiResult<GetMatchResponse> MatchDelete(DeleteMatchEntity entity);
    }
}
