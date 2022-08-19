using DivingDog.Services.Models.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivingDog.Services.Models
{
    public class SearchResultModel
    {
        public DetailedLocationModel Location { get; set; }
        public List<ListingModel> MatchedListings { get; set; }

        public SearchResultModel()
        {
            MatchedListings = new List<ListingModel>();
        }
    }
}
