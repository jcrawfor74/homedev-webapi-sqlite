using HomeDev.WebApi.Sqlite.Entities;
using HomeDev.WebApi.Sqlite.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;

namespace HomeDev.WebApi.Sqlite.DataAccess
{
    public class SqliteContext : DbContext
    {
        private readonly ApiSettings _apiSettings;

        public SqliteContext(ApiSettings apiSettings)
        {
            _apiSettings = apiSettings;
        }

        public SqliteContext(DbContextOptions<SqliteContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(_apiSettings.SqliteDb, _ => _.UseNetTopologySuite());

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LocationDto>()
                .ToTable("Location")
                .Property(_ => _.Coordinates)
                .HasSrid(4326)
                .HasColumnType("POINTZ");
        }

        public DbSet<LocationDto> Locations { get; set; }
    }
}
