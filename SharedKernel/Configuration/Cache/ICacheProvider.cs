namespace SharedKernel.Configuration.Cache
{
    public interface ICacheProvider
    {
        Task DeleteKeyAsync<T>(string key);

        Task<T?> GetAsync<T>(string key);

        Task SetAsync<T>(string key, T value);

        Task<bool> KeyExists<T>(string key);

        Task SetAsync<T>(string key, T value, TimeSpan expiry);
    }
}
