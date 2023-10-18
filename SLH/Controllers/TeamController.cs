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
    public class TeamController : BaseController
    {
        private readonly ITeamService _teamService;

        /// <summary>
        /// Constructor of Team Controller
        /// </summary>
        /// <param name="teamService"></param>
        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpPost]
        [Route("GetAllTeams")]
        public async Task<IActionResult> GetAllTeams(GetAllTeamsEntity entity)
        {
            ICollection<string> errors = this.ValidatePost(entity);

            if (errors.Any())
                return this.GetErrorResult(System.Net.HttpStatusCode.BadRequest, errors);

            entity.OwnerId = this.GetUserID();
            ApiResult<List<GetTeamResponse>> result = _teamService.GetAllTeams(entity);
            return this.GetResult(result);
        }

        [HttpPost]
        [Route("AddTeam")]
        public async Task<IActionResult> AddTeam(AddTeamEntity entity)
        {
            ICollection<string> errors = this.ValidatePost(entity);

            if (errors.Any())
                return this.GetErrorResult(System.Net.HttpStatusCode.BadRequest, errors);

            if (entity.OwnerId.ToString().Equals("0"))
                entity.OwnerId = this.GetUserID();

            ApiResult<GetTeamResponse> result = _teamService.TeamAdd(entity);
            return this.GetResult(result);
        }

        [HttpPost]
        [Route("UpdateTeam")]
        public async Task<IActionResult> UpdateTeam(UpdateTeamEntity entity)
        {
            ICollection<string> errors = this.ValidatePost(entity);

            if (errors.Any())
                return this.GetErrorResult(System.Net.HttpStatusCode.BadRequest, errors);

            if (entity.OwnerId.ToString().Equals("0"))
                entity.OwnerId = this.GetUserID();

            ApiResult<GetTeamResponse> result = _teamService.TeamUpdate(entity);
            return this.GetResult(result);
        }

        [HttpPost]
        [Route("DeleteTeam")]
        public async Task<IActionResult> DeleteTeam(DeleteTeamEntity entity)
        {
            ICollection<string> errors = this.ValidatePost(entity);

            if (errors.Any())
                return this.GetErrorResult(System.Net.HttpStatusCode.BadRequest, errors);

            entity.OwnerId = this.GetUserID();
            ApiResult<GetTeamResponse> result = _teamService.TeamDelete(entity);
            return this.GetResult(result);
        }
    }
}
