using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SLH.Common;
using SLH.Entity.RequestEntity;
using SLH.Entity.ResponseEntity;
using SLH.Service.Interface;
using SLH.Service.Service;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SLH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CORS")]
    public class TournamentController : BaseController
    {
        private readonly ITournamentService _tournamentService;

        /// <summary>
        /// Constructor of Tournament Controller
        /// </summary>
        /// <param name="tournamentService"></param>
        public TournamentController(ITournamentService tournamentService)
        {
            _tournamentService = tournamentService;
        }

        [HttpPost]
        [Route("GetAllTournaments")]
        public async Task<IActionResult> GetAllTournaments(GetAllTournamentsEntity entity)
        {
            ICollection<string> errors = this.ValidatePost(entity);

            if (errors.Any())
                return this.GetErrorResult(System.Net.HttpStatusCode.BadRequest, errors);

            entity.OrganizerId = this.GetUserID();
            ApiResult<List<GetTournamentResponse>> result = _tournamentService.GetAllTournaments(entity);
            return this.GetResult(result);
        }

        [HttpPost]
        [Route("AddTournament")]
        public async Task<IActionResult> AddTournament(AddTournamentEntity entity)
        {
            ICollection<string> errors = this.ValidatePost(entity);

            if (errors.Any())
                return this.GetErrorResult(System.Net.HttpStatusCode.BadRequest, errors);

            if (entity.OrganizerId.ToString().Equals("0"))
                entity.OrganizerId = this.GetUserID();

            ApiResult<GetTournamentResponse> result = _tournamentService.TournamentAdd(entity);
            return this.GetResult(result);
        }

        [HttpPost]
        [Route("UpdateTournament")]
        public async Task<IActionResult> UpdateTournament(UpdateTournamentEntity entity)
        {
            ICollection<string> errors = this.ValidatePost(entity);

            if (errors.Any())
                return this.GetErrorResult(System.Net.HttpStatusCode.BadRequest, errors);

            if (entity.OrganizerId.ToString().Equals("0"))
                entity.OrganizerId = this.GetUserID();

            ApiResult<GetTournamentResponse> result = _tournamentService.TournamentUpdate(entity);
            return this.GetResult(result);
        }

        [HttpPost]
        [Route("DeleteTournament")]
        public async Task<IActionResult> DeleteTournament(DeleteTournamentEntity entity)
        {
            ICollection<string> errors = this.ValidatePost(entity);

            if (errors.Any())
                return this.GetErrorResult(System.Net.HttpStatusCode.BadRequest, errors);

            entity.OrganizerId = this.GetUserID();
            ApiResult<GetTournamentResponse> result = _tournamentService.TournamentDelete(entity);
            return this.GetResult(result);
        }

        [HttpPost]
        [Route("AddTeamToTournament")]
        public async Task<IActionResult> AddTeamToTournament(AddTeamToTournamentEntity entity)
        {
            ICollection<string> errors = this.ValidatePost(entity);

            if (errors.Any())
                return this.GetErrorResult(System.Net.HttpStatusCode.BadRequest, errors);

            entity.OrganizerId = this.GetUserID();
            ApiResult<GetTournamentResponse> result = _tournamentService.AddTournamentTeam(entity);
            return this.GetResult(result);
        }

        [HttpPost]
        [Route("ReleaseTeamFromTournament")]
        public async Task<IActionResult> ReleaseTeamFromTournament(ReleaseTeamFromTournamentEntity entity)
        {
            ICollection<string> errors = this.ValidatePost(entity);

            if (errors.Any())
                return this.GetErrorResult(System.Net.HttpStatusCode.BadRequest, errors);

            entity.OrganizerId = this.GetUserID();
            ApiResult<GetTournamentResponse> result = _tournamentService.ReleaseTournamentTeam(entity);
            return this.GetResult(result);
        }
    }
}
