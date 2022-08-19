using DivingDog.Services.Models;
using DivingDog.Services.Models.Locations;
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivingDog.Services
{
    public class DiveShopService
    {
        private List<DiveShopModel> _diveShops;

        public DiveShopService()
        {
            _diveShops = new List<DiveShopModel>
            {
                new DiveShopModel
                {
                    Id = Guid.NewGuid(),
                    Name = "CABO DIVERS",
                    Description = "Some description ...",
                    LogoUrl = "https://the-dive-shop.com/wp-content/uploads/2017/12/Dive-Shop-Logo-150x122.png",
                    Coordinates = new Coordinates(22.881791271538354, -109.9105780239999)
                },
                new DiveShopModel
                {
                    Id = Guid.NewGuid(),
                    Name = "Dive Cabo",
                    Description = "Some description ...",
                    LogoUrl = "https://the-dive-shop.com/wp-content/uploads/2017/12/Dive-Shop-Logo-150x122.png",
                    Coordinates = new Coordinates(22.88081973467939, -109.91159460593181)
                },
                new DiveShopModel
                {
                    Id = Guid.NewGuid(),
                    Name = "Cabo Excursions",
                    Description = "Some description ...",
                    LogoUrl = "https://the-dive-shop.com/wp-content/uploads/2017/12/Dive-Shop-Logo-150x122.png",
                    Coordinates = new Coordinates(22.879994971314126, -109.91098010491328)
                },
            };
        }

        public List<DiveShopModel> GetAllWithinLocation(DetailedLocationModel location)
        {
            var closeByDiveShops = new List<DiveShopModel>();
            
            //Get all within 5km
            foreach (var diveShop in _diveShops)
            {
                double distanceBetweenInMeters = 1000; //location.Coordinates.GetDistanceTo(diveShop.Coordinates);

                if (distanceBetweenInMeters <= 5000)
                    closeByDiveShops.Add(diveShop);

            }

            return closeByDiveShops;
        }
    }
}
