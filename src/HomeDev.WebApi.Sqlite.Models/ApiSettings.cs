using System;

namespace HomeDev.WebApi.Sqlite.Models
{
    public class ApiSettings
    {
        public const string Key = "ApiSettings";
        public string SqliteDb { get; set; }
    }
}
