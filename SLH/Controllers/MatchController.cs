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
    public class MatchController : BaseController
    {
        private readonly IMatchService _matchService;

        /// <summary>
        /// Constructor of Match Controller
        /// </summary>
        /// <param name="matchService"></param>
        public MatchController(IMatchService matchService)
        {
            _matchService = matchService;
        }

        [HttpPost]
        [Route("GetAllMatches")]
        public async Task<IActionResult> GetAllMatches(GetAllMatchesEntity entity)
        {
            ICollection<string> errors = this.ValidatePost(entity);

            if (errors.Any())
                return this.GetErrorResult(System.Net.HttpStatusCode.BadRequest, errors);

            entity.UserId = this.GetUserID();
            ApiResult<List<GetMatchResponse>> result = _matchService.GetAllMatches(entity);
            return this.GetResult(result);
        }

        [HttpPost]
        [Route("AddMatch")]
        public async Task<IActionResult> AddMatch(AddMatchEntity entity)
        {
            ICollection<string> errors = this.ValidatePost(entity);

            if (errors.Any())
                return this.GetErrorResult(System.Net.HttpStatusCode.BadRequest, errors);

            entity.UserId = this.GetUserID();
            ApiResult<GetMatchResponse> result = _matchService.MatchAdd(entity);
            return this.GetResult(result);
        }

        [HttpPost]
        [Route("UpdateMatch")]
        public async Task<IActionResult> UpdateMatch(UpdateMatchEntity entity)
        {
            ICollection<string> errors = this.ValidatePost(entity);

            if (errors.Any())
                return this.GetErrorResult(System.Net.HttpStatusCode.BadRequest, errors);

            entity.UserId = this.GetUserID();
            ApiResult<GetMatchResponse> result = _matchService.MatchUpdate(entity);
            return this.GetResult(result);
        }

        [HttpPost]
        [Route("DeleteMatch")]
        public async Task<IActionResult> DeleteMatch(DeleteMatchEntity entity)
        {
            ICollection<string> errors = this.ValidatePost(entity);

            if (errors.Any())
                return this.GetErrorResult(System.Net.HttpStatusCode.BadRequest, errors);

            entity.UserId = this.GetUserID();
            ApiResult<GetMatchResponse> result = _matchService.MatchDelete(entity);
            return this.GetResult(result);
        }
    }
}
