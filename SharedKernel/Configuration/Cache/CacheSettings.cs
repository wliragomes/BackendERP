namespace SharedKernel.Configuration.Cache
{
    public class CacheSettings : ICacheSettings
    {
        public string ConnectionString { get; }

        public CacheSettings(string connectionString)
        {
            ConnectionString = connectionString;
        }
    }
}
