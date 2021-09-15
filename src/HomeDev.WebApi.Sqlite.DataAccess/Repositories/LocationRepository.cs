using HomeDev.WebApi.Sqlite.Entities;
using HomeDev.WebApi.Sqlite.DataAccess.Interfaces;
using HomeDev.WebApi.Sqlite.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeDev.WebApi.Sqlite.DataAccess.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly ApiSettings _apiSettings;

        public LocationRepository(IOptions<ApiSettings> apiOptions)
        {
            _apiSettings = apiOptions.Value;
        }

        public async Task AddLocationAsync(LocationDto location)
        {
            using (var dbContext = new SqliteContext(_apiSettings))
            {
                dbContext.Locations.Add(location);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<IList<LocationDto>> GetLocationsAsync()
        {
            using (var dbContext = new SqliteContext(_apiSettings))
            {
                var locations = await dbContext.Locations.ToListAsync();
                return locations;
            }
        }
    }
}
