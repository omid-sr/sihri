using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Sihri.Infrastructure.Interfaces;
using StackExchange.Redis;

namespace Sihri.Infrastructure.Implementation.Cache
{
    public class RedisStackExchangeCacheService : ICacheService
    {
        private RedisBuilder _redisBuilder;

        public RedisStackExchangeCacheService(RedisBuilder redisBuilder)
        {
            _redisBuilder = redisBuilder;
        }

        public async Task<T> GetAsync<T>(string key)
        {
            RedisValue value = await _redisBuilder.Database.StringGetAsync(key);
            return JsonSerializer.Deserialize<T>(value);
        }

        public Task SetAsync<T>(string key, T data, int expire = 0)
        {
            if (expire is 0)
                expire = _redisBuilder.ExpireTime;
            return _redisBuilder.Database.StringSetAsync(key, data.Serialize(), TimeSpan.FromMinutes(expire));
        }

        public Task DeleteAsync(string key)
        {
            return _redisBuilder.Database.KeyDeleteAsync(key);
        }
        /// <summary>
        /// delete caches using wildecard formatting
        /// use *a to delete all cacehs ends with a  
        /// </summary>
        /// <param name="wildCardPattern"></param>
        /// <returns></returns>
        public async Task DeleteWildCardAsync(string wildCardPattern)
        {
            foreach (var server in _redisBuilder.Servers)
                foreach (var key in server.Keys(pattern: wildCardPattern))
                    await _redisBuilder.Database.KeyDeleteAsync(key);
        }
    }
}
