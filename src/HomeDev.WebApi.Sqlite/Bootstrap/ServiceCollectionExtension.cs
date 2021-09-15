using HomeDev.WebApi.Sqlite.DataAccess;
using HomeDev.WebApi.Sqlite.DataAccess.Interfaces;
using HomeDev.WebApi.Sqlite.DataAccess.Repositories;
using HomeDev.WebApi.Sqlite.Models;
using HomeDev.WebApi.Sqlite.Services;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeDev.WebApi.Sqlite.Bootstrap
{
    public static class ServiceCollectionExtension
    {
        private static ApiSettings _apiSettings;
        private static SqliteConnection _keepAliveConnection;
        public static void AddWebApiConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            _apiSettings = configuration.GetSection(ApiSettings.Key).Get<ApiSettings>();

            services.Configure<ApiSettings>(configuration.GetSection(ApiSettings.Key));
        }

        public static void AddWebApiDependencies(this IServiceCollection services)
        {

            services.AddScoped<ILocationRepository, LocationRepository>();
            services.AddScoped<ILocationService, LocationService>();

            services.AddDbContext<SqliteContext>(options =>
            {
                options.UseSqlite(_apiSettings.SqliteDb, _ => _.UseNetTopologySuite());
            });

        }

        public static void AddWebApiSqlite(this IServiceCollection services)
        {
            // setup single to
            _keepAliveConnection = new SqliteConnection(_apiSettings.SqliteDb);
            _keepAliveConnection.Open();

            var command = _keepAliveConnection.CreateCommand();
            command.CommandText =
            @"
        CREATE TABLE Location (
            ""LocationUuid""         TEXT INTEGER UNIQUE,
            ""AddressUuid""          TEXT,
            ""EntityUuid""           TEXT,
            ""Name""                 TEXT,
            ""Prefix""               TEXT,
            ""Street""               TEXT,
            ""City""                 TEXT,
            ""State""                TEXT,
            ""Postcode""             TEXT,
            ""Country""              TEXT,
            ""Email""                TEXT,
            ""Phone""                TEXT,
            ""Coordinates""          BLOB,
            ""Latitude""             TEXT,
            ""Longitude""            TEXT,
            ""CreatedAt""       DATETIME,
            PRIMARY KEY(""LocationUuid"")
        );
    ";
            try
            {
                command.ExecuteNonQuery();
            }
            catch
            {
                // ignore
            }
        }
    }
}
