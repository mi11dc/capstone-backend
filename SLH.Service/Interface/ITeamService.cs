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
    public interface ITeamService
    {
        ApiResult<List<GetTeamResponse>> GetAllTeams(GetAllTeamsEntity entity);
        ApiResult<GetTeamResponse> TeamAdd(AddTeamEntity entity);
        ApiResult<GetTeamResponse> TeamUpdate(UpdateTeamEntity entity);
        ApiResult<GetTeamResponse> TeamDelete(DeleteTeamEntity entity);
        ApiResult<GetTeamResponse> AddTeamPlayer(AddPlayerToTeamEntity entity);
        ApiResult<GetTeamResponse> ReleaseTeamPlayer(ReleasePlayerFromTeamEntity entity);
    }
}
