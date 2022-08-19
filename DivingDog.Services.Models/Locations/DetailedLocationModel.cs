using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivingDog.Services.Models.Locations
{
    public class DetailedLocationModel : LocationModel
    {
        public string Description { get; set; }
        public string Image { get; set; }
        public Coordinates Coordinates { get; set; }
    }
}
