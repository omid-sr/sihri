using Utf8Json;

namespace Sihri.Infrastructure
{
    public static class DataFormatter
    {
        //serializes object to json string using uft8
        public static string Serialize<T>(this T data)
        {
            return JsonSerializer.ToJsonString(data);
        }


        //deserializes string to object
        public static T Deserialize<T>(byte[] data)
        {
            if (data is null)
                return default;

            return JsonSerializer.Deserialize<T>(data);
        }
    }
}
