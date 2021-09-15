using HomeDev.WebApi.Sqlite.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeDev.WebApi.Sqlite.DataAccess.Interfaces
{
    public interface ILocationRepository
    {
        Task AddLocationAsync(LocationDto location);

        Task<IList<LocationDto>> GetLocationsAsync();
    }
}
