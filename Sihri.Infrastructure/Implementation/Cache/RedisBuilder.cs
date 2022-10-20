using System.Collections.Generic;
using Microsoft.Extensions.Options;
using StackExchange.Redis;

namespace Sihri.Infrastructure.Implementation.Cache
{
    public class RedisBuilder
    {
        private readonly RedisSettings _redisSettings;
        public IDatabase Database { get; set; }
        public List<IServer> Servers { get; set; } = new();
        public int ExpireTime { get; set; }

        public RedisBuilder(IOptionsMonitor<RedisSettings> redisSettings)
        {
            _redisSettings = redisSettings.CurrentValue;

            ExpireTime = _redisSettings.ExpireTime;
            ConfigurationOptions configurationOptions = new ConfigurationOptions()
            {
                User = _redisSettings.Username,
                Password = _redisSettings.Password,
                EndPoints = new(),
                AllowAdmin = _redisSettings.AllowAdmin,
                Ssl = _redisSettings.Ssl,
                SslHost = _redisSettings.SslHost

            };
            foreach (var endpoint in _redisSettings.Endpoints)
            {
                configurationOptions.EndPoints.Add(endpoint.Host, endpoint.Port);
            }
            // creating connection to redis 
            ConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect(configurationOptions);
            // now we can use redis features for caching , pub/sub
            Database = connectionMultiplexer.GetDatabase(_redisSettings.Database);
            var endPoints = connectionMultiplexer.GetEndPoints();


            foreach (var endPoint in endPoints)
            {
                Servers.Add(connectionMultiplexer.GetServer(endPoint));
            }

        }
    }

}
