using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeDev.WebApi.Sqlite.Services
{
    public interface ILocationService
    {
        Task SetupTestDataAsync();
    }
}
