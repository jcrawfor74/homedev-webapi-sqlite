using System.Text.Json;

namespace HomeDev.WebApi.Sqlite.Extensions
{
    public static class ObjectExtensions
    {
        public static string ToJson(this object value)
        {
            return JsonSerializer.Serialize(value);
        }
    }
}