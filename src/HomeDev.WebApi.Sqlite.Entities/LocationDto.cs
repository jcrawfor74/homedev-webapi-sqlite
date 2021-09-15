using NetTopologySuite.Geometries;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeDev.WebApi.Sqlite.Entities
{
    public class LocationDto
    {
        [Key]
        public Guid LocationUuid { get; set; }
        public Guid? AddressUuid { get; set; }
        public Guid EntityUuid { get; set; }
        public string Name { get; set; }
        public string Prefix { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Postcode { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public Point Coordinates { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
