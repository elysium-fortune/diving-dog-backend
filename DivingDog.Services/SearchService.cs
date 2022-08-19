using DivingDog.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivingDog.Services
{
    public class SearchService
    {
        private DiveShopService _diveShopService;
        private LocationService _locationService;

        public SearchService(DiveShopService diveShopService, LocationService locationService)
        {
            _diveShopService = diveShopService;
            _locationService = locationService;
        }

        public SearchResultModel Get(Guid locationId)
        {
            var model = new SearchResultModel();
            var location = _locationService.GetLocationById(locationId);

            //Setup Location info
            model.Location = location;

            //Setup Dive Shops
            var closedByDiveShops = _diveShopService.GetAllWithinLocation(location);

            var listings = closedByDiveShops.Select(l =>
            {
                return new ListingModel
                {
                    Title = l.Name,
                    Description = l.Description,
                    Image = l.LogoUrl
                };
            });

            model.MatchedListings.AddRange(listings);

            return model;
        }

    }
}
