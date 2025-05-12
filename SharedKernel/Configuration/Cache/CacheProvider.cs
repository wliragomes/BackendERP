using Newtonsoft.Json;
using StackExchange.Redis;

namespace SharedKernel.Configuration.Cache
{
    public class CacheProvider : ICacheProvider
    {
        private ConnectionMultiplexer? _redisConnection;
        private readonly ICacheSettings _cacheSettings;
        private const int _defaultTimeout = 30000;
        private const int _minThreads = 50;
        private static readonly object GetConnectionLock = new object();

        public CacheProvider(ICacheSettings cacheSettings)
        {
            _cacheSettings = cacheSettings;
        }

        public async Task<T?> GetAsync<T>(string key)
        {
            var db = GetDb();
            var serializedValue = await db.StringGetAsync(key);

            if (serializedValue.IsNullOrEmpty)
                return default;

            return JsonConvert.DeserializeObject<T>(serializedValue!);
        }

        public async Task SetAsync<T>(string key, T value)
        {
            var db = GetDb();
            var serializedValue = JsonConvert.SerializeObject(value);
            await db.StringSetAsync(key, serializedValue);
        }

        public async Task SetAsync<T>(string key, T value, TimeSpan expiry)
        {
            var db = GetDb();
            var serializedValue = JsonConvert.SerializeObject(value);
            await db.StringSetAsync(key, serializedValue, expiry);
        }

        public async Task DeleteKeyAsync<T>(string key)
        {
            var db = GetDb();
            await db.KeyDeleteAsync(key);
        }

        public async Task<bool> KeyExists<T>(string key)
        {
            var db = GetDb();
            return await db.KeyExistsAsync(key);
        }

        private IDatabase GetDb()
        {
            if (_redisConnection != null)
                return _redisConnection.GetDatabase();

            return GetConnectionMultiplexer().GetDatabase();
        }

        private ConnectionMultiplexer GetConnectionMultiplexer()
        {
            if (_redisConnection != null && _redisConnection.IsConnected)
                return _redisConnection;

            lock (GetConnectionLock)
            {
                if (_redisConnection != null && _redisConnection.IsConnected)
                    return _redisConnection;

                if (_redisConnection != null && !_redisConnection.IsConnected)
                    _redisConnection.Dispose();

                ThreadPool.GetMinThreads(out var workerThreads, out var completionPortThreads);

                if (workerThreads != _minThreads || completionPortThreads != _minThreads)
                    ThreadPool.SetMinThreads(_minThreads, _minThreads);

                var options = ConfigurationOptions.Parse(_cacheSettings.ConnectionString);
                options.AsyncTimeout = _defaultTimeout;
                options.SyncTimeout = _defaultTimeout;
                options.ConnectTimeout = _defaultTimeout;

                _redisConnection = ConnectionMultiplexer.Connect(options);
            }

            return _redisConnection;

        }
    }
}
