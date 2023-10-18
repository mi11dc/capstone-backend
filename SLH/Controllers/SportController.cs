using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SLH.Common;
using SLH.Entity.RequestEntity;
using SLH.Entity.ResponseEntity;
using SLH.Service.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SLH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CORS")]
    public class SportController : BaseController
    {
        private readonly ISportService _sportService;

        /// <summary>
        /// Constructor of User Controller
        /// </summary>
        /// <param name="sportService"></param>
        public SportController(ISportService sportService)
        {
            _sportService = sportService;
        }

        [HttpPost]
        [Route("GetAllSports")]
        public async Task<IActionResult> GetAllSports(GetAllSportsEntity entity)
        {
            ICollection<string> errors = this.ValidatePost(entity);

            if (errors.Any())
                return this.GetErrorResult(System.Net.HttpStatusCode.BadRequest, errors);

            entity.UserId = this.GetUserID();
            ApiResult<List<GetSportResponse>> result = _sportService.GetAllSports(entity);
            return this.GetResult(result);
        }

        [HttpPost]
        [Route("AddSport")]
        public async Task<IActionResult> AddSport(AddSportEntity entity)
        {
            ICollection<string> errors = this.ValidatePost(entity);

            if (errors.Any())
                return this.GetErrorResult(System.Net.HttpStatusCode.BadRequest, errors);

            entity.UserId = this.GetUserID();
            ApiResult<GetSportResponse> result = _sportService.SportAdd(entity);
            return this.GetResult(result);
        }

        [HttpPost]
        [Route("UpdateSport")]
        public async Task<IActionResult> UpdateSport(UpdateSportEntity entity)
        {
            ICollection<string> errors = this.ValidatePost(entity);

            if (errors.Any())
                return this.GetErrorResult(System.Net.HttpStatusCode.BadRequest, errors);

            entity.UserId = this.GetUserID();
            ApiResult<GetSportResponse> result = _sportService.SportUpdate(entity);
            return this.GetResult(result);
        }

        [HttpPost]
        [Route("DeleteSport")]
        public async Task<IActionResult> DeleteSport(DeleteSportEntity entity)
        {
            ICollection<string> errors = this.ValidatePost(entity);

            if (errors.Any())
                return this.GetErrorResult(System.Net.HttpStatusCode.BadRequest, errors);

            entity.UserId = this.GetUserID();
            ApiResult<GetSportResponse> result = _sportService.SportDelete(entity);
            return this.GetResult(result);
        }
    }
}
