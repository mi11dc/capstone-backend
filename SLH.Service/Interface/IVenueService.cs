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
    public interface IVenueService
    {
        ApiResult<List<GetVenueResponse>> GetAllVenues(GetAllVenuesEntity entity);
        ApiResult<GetVenueResponse> VenueAdd(AddVenueEntity entity);
        ApiResult<GetVenueResponse> VenueUpdate(UpdateVenueEntity entity);
        ApiResult<GetVenueResponse> VenueDelete(DeleteVenueEntity entity);
    }
}
