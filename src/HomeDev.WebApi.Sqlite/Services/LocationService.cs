using HomeDev.WebApi.Sqlite.Entities;
using HomeDev.WebApi.Sqlite.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeDev.WebApi.Sqlite.Services
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepository;

        public LocationService(
            ILocationRepository locationRepository
        )
        {
            _locationRepository = locationRepository;
        }
        public async Task SetupTestDataAsync()
        {
            for (int i = 0; i < 2; i++)
            {
                var location = new LocationDto()
                {
                    LocationUuid = Guid.NewGuid(),
                    AddressUuid = Guid.NewGuid(),
                    EntityUuid = Guid.NewGuid(),
                    Coordinates = new NetTopologySuite.Geometries.Point(-33.824161758848476, 151.21060563916393),
                    CreatedAt = DateTime.Now
                };

                await _locationRepository.AddLocationAsync(location);
            }
        }
    }
}
