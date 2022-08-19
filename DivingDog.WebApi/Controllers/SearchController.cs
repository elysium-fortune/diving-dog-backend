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
    public class SearchController : ControllerBase
    {
        private SearchService _searchService;
        private SessionService _sessionService;

        public SearchController(SearchService searchService, SessionService sessionService)
        {
            _searchService = searchService;
            _sessionService = sessionService;
        }


        [HttpGet]
        public ActionResult<SearchResultModel> Get()
        {
            var losCabosId = new Guid("7b61b83a-cc6b-11ec-9d64-0242ac120002");

            //Update session


            //Get result
            var result = _searchService.Get(losCabosId);
            return result;
        }

        [HttpGet("{locationId}")]
        public ActionResult<SearchResultModel> GetByLocationid(Guid locationId)
        {
            //Update Session with Search
            var sessionId = HttpContext.Session.Id.ToString();
            _sessionService.AddSearch(sessionId, locationId);

            //Return result
            var result = _searchService.Get(locationId);
            return result;
        }

        //[HttpGet("location")]
        //public ActionResult<SearchResultModel> GetLocation(string location)
        //{
        //    var result = _searchService.Get();
        //    return result;
        //}
    }
}
