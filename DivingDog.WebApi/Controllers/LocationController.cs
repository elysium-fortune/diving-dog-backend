using DivingDog.Services;
using DivingDog.Services.Models;
using DivingDog.Services.Models.Locations;
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
    public class LocationController : ControllerBase
    {
        private LocationService _locationService;

        public LocationController(LocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet("all")]
        public ActionResult<List<LocationModel>> GetAllLocations()
        {
            return _locationService.GetAllLocations();
        }

        [HttpGet("all/detailed")]
        public ActionResult<List<DetailedLocationModel>> GetAllLocationsWithDetails()
        {
            return _locationService.GetAllLocationsWithDetails();
        }
    }
}
