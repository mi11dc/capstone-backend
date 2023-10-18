using Microsoft.AspNetCore.Authorization;
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
    public class VenueController : BaseController
    {
        private readonly IVenueService _venueService;

        /// <summary>
        /// Constructor of Venue Controller
        /// </summary>
        /// <param name="venueService"></param>
        public VenueController(IVenueService venueService)
        {
            _venueService = venueService;
        }

        [HttpPost]
        [Route("GetAllVenues")]
        public async Task<IActionResult> GetAllVenues(GetAllVenuesEntity entity)
        {
            ICollection<string> errors = this.ValidatePost(entity);

            if (errors.Any())
                return this.GetErrorResult(System.Net.HttpStatusCode.BadRequest, errors);

            entity.UserId = this.GetUserID();
            ApiResult<List<GetVenueResponse>> result = _venueService.GetAllVenues(entity);
            return this.GetResult(result);
        }

        [HttpPost]
        [Route("AddVenue")]
        public async Task<IActionResult> AddVenue(AddVenueEntity entity)
        {
            ICollection<string> errors = this.ValidatePost(entity);

            if (errors.Any())
                return this.GetErrorResult(System.Net.HttpStatusCode.BadRequest, errors);

            entity.UserId = this.GetUserID();
            ApiResult<GetVenueResponse> result = _venueService.VenueAdd(entity);
            return this.GetResult(result);
        }

        [HttpPost]
        [Route("UpdateVenue")]
        public async Task<IActionResult> UpdateVenue(UpdateVenueEntity entity)
        {
            ICollection<string> errors = this.ValidatePost(entity);

            if (errors.Any())
                return this.GetErrorResult(System.Net.HttpStatusCode.BadRequest, errors);

            entity.UserId = this.GetUserID();
            ApiResult<GetVenueResponse> result = _venueService.VenueUpdate(entity);
            return this.GetResult(result);
        }

        [HttpPost]
        [Route("DeleteVenue")]
        public async Task<IActionResult> DeleteVenue(DeleteVenueEntity entity)
        {
            ICollection<string> errors = this.ValidatePost(entity);

            if (errors.Any())
                return this.GetErrorResult(System.Net.HttpStatusCode.BadRequest, errors);

            entity.UserId = this.GetUserID();
            ApiResult<GetVenueResponse> result = _venueService.VenueDelete(entity);
            return this.GetResult(result);
        }
    }
}
