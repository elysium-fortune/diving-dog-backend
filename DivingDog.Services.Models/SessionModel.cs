using DivingDog.Services.Models.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivingDog.Services.Models
{
    public class SessionModel
    {
        public SearchParameterModel LatestSearch => Searches.LastOrDefault();

        public string Id { get; set; }
        public List<SearchParameterModel> Searches { get; private set; }

        
        public SessionModel()
        {
            Searches = new List<SearchParameterModel>();
        }
    }
}
