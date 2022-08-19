using DivingDog.Services;
using DivingDog.Services.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DivingDog.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListingController : ControllerBase
    {
        private DiveShopService _diveShopService;
        private LocationService _locationService;
        private SessionService _sessionService;

        public ListingController(DiveShopService diveShopService, LocationService locationService, SessionService sessionService)
        {
            _diveShopService = diveShopService;
            _locationService = locationService;
            _sessionService = sessionService;
        }

        [HttpGet("session/{sessionId}")]
        public IEnumerable<ListingModel> GetBySessionId(string sessionId)
        {
            var session = _sessionService.GetSessionById(sessionId);
            if (session.LatestSearch is not null)
            {
                var latestSearch = session.LatestSearch;

                if(latestSearch.LocationId is not null)
                {
                    var location = _locationService.GetLocationById(latestSearch.LocationId.GetValueOrDefault());
                    var diveShops = _diveShopService.GetAllWithinLocation(location).Select(c => new ListingModel(c));

                    return diveShops;
                }
            }

            return new List<ListingModel>();
        }
    }
}
