using DivingDog.Services.Models;
using DivingDog.Services.Models.Locations;
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivingDog.Services
{
    public class LocationService
    {
        private List<DetailedLocationModel> _locations;

        public LocationService()
        {
            _locations = new List<DetailedLocationModel>()
            {
                new DetailedLocationModel
                {
                    Id = new Guid("7b61b83a-cc6b-11ec-9d64-0242ac120002"),
                    Name = "Los Cabos",
                    Description = "A true highlight in Cabo San Lucas is diving with the local sea lions. These playful pups are regulars at many of the area’s dive sites and never fail to amuse and entertain with their mischievous antics.",
                    Image = "https://bajasharkexperience.com/wp-content/uploads/2018/06/DSCN4614-1024x768.jpg",
                    Coordinates = new Coordinates(22.8905, -109.9167)
                },
                new DetailedLocationModel
                {
                    Id = new Guid("8b03a596-cc6b-11ec-9d64-0242ac120002"),
                    Name = "Cabo Pulmo",
                    Description = @"Cabo Pulmo National Park is home to over 6,000 marine species. Principle among these are the area’s famous sea lions. In terms of other large species, the park also welcomes Humpback Whales, Mobulas and Whale Sharks.

                                    Enormous groupers, turtles and large schools of jacks are easily found. Tropical fish are bountiful and even the occasional reef shark can be found stalking its prey nearby. Underwater photographers will marvel at the diversity of macro life found on this rare reef.

                                    If you move a bit off the reef, you’ll be pleasantly surprised by garden eels, sticking their head out of the sand to stare at new visitors.",
                    Image = "https://d2p1cf6997m1ir.cloudfront.net/media/c83opt/75/9b/759b2f4f79643971d0b3ba65ce8a2741.jpg"
                },
                new DetailedLocationModel
                {
                    Id = new Guid("852d7c50-cc6b-11ec-9d64-0242ac120002"),
                    Name = "Dos Ojos (Quinatana Roo)",
                    Description = "Dos Ojos is part of a flooded cave system located north of Tulum, on the Caribbean coast of the Yucatán Peninsula, in the state of Quintana Roo, Mexico.",
                    Image = "https://voyageinstyle.net/wp-content/uploads/2019/07/Dive-DosOjos-Mexico4-1024x683.jpg"
                },
            };
        }

        public List<LocationModel> GetAllLocations()
        {
            return _locations.Select(l => l as LocationModel).ToList();
        }

        public List<DetailedLocationModel> GetAllLocationsWithDetails()
        {
            return _locations;
        }

        public DetailedLocationModel GetLocationById(Guid id)
        {
            return _locations.Where(c => c.Id == id).First();
        }
    }
}
