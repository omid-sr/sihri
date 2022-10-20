namespace Sihri.Infrastructure.Interfaces;

public interface ICacheService
{
    public Task<T> GetAsync<T>(string key);
    public Task SetAsync<T>(string key, T data, int expire = 0);
    public Task DeleteAsync(string key);
    public Task DeleteWildCardAsync(string wildCard);
}