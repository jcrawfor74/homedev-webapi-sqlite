using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeDev.WebApi.Sqlite.DataAccess.Interfaces;
using HomeDev.WebApi.Sqlite.Entities;
using HomeDev.WebApi.Sqlite.Extensions;
using HomeDev.WebApi.Sqlite.Services;
using Microsoft.AspNetCore.Mvc;

namespace homedev_webapi_auth.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        private readonly ILocationRepository _locationRepository;

        public ValuesController(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var locations = _locationRepository.GetLocationsAsync().Result;
            return locations.Select(_ => _.ToJson()).ToArray();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] string value)
        {
            var location = new LocationDto()
            {
                LocationUuid = Guid.NewGuid(),
                AddressUuid = Guid.NewGuid(),
                EntityUuid = Guid.NewGuid(),
                Coordinates = new NetTopologySuite.Geometries.Point(33.1, 151.1),
                City = id.ToString(),
                Postcode = value,
                CreatedAt = DateTime.Now
            };

            await _locationRepository.AddLocationAsync(location);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
