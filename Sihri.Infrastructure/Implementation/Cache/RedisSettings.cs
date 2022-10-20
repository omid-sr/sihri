using System.Collections.Generic;

namespace Sihri.Infrastructure.Implementation.Cache
{
    public class RedisSettings
    {
        public List<Endpoints> Endpoints { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Database { get; set; }
        public bool Ssl { get; set; }
        public string SslHost { get; set; }
        public int ExpireTime { get; set; }
        public bool AllowAdmin { get; set; }
    }

    public class Endpoints
    {
        public string Host { get; set; }
        public int Port { get; set; }
    }
}