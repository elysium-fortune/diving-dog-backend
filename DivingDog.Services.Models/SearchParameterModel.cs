using DivingDog.Services.Models.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivingDog.Services.Models
{
    public class SearchParameterModel
    {
        public Guid? LocationId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }

        public SearchParameterModel()
        {

        }

        public SearchParameterModel(Guid locationId)
        {
            LocationId = locationId;
        }

        public SearchParameterModel(Guid locationId, DateTime fromDate, DateTime toDate) : this(locationId)
        {
            FromDate = fromDate;
            ToDate = toDate;
        }
    }
}
