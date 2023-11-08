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
    public interface ITournamentService
    {
        ApiResult<List<GetTournamentResponse>> GetAllTournaments(GetAllTournamentsEntity entity);
        ApiResult<GetTournamentResponse> TournamentAdd(AddTournamentEntity entity);
        ApiResult<GetTournamentResponse> TournamentUpdate(UpdateTournamentEntity entity);
        ApiResult<GetTournamentResponse> TournamentDelete(DeleteTournamentEntity entity);
        ApiResult<GetTournamentResponse> AddTournamentTeam(AddTeamToTournamentEntity entity);
        ApiResult<GetTournamentResponse> ReleaseTournamentTeam(ReleaseTeamFromTournamentEntity entity);
    }
}
