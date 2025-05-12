using SharedKernel.Configuration.Cache;
using System.Text;
using System.Security.Cryptography;

namespace SharedKernel.Configuration.Security.JWT
{
    public static class TokenBlacklist
    {
        public static async void AddTokenToBlacklist(string token, ICacheProvider _cacheProvider)
        {
            var tokenHash = GetSha256_hash(token);

            var key = $"BlacklistedTokens:{tokenHash}";
            await _cacheProvider.SetAsync(key, token, TimeSpan.FromDays(3));
        }

        public static async Task<bool> IsTokenBlacklisted(string token, ICacheProvider _cacheProvider)
        {
            var tokenHash = GetSha256_hash(token);

            var key = $"BlacklistedTokens:{tokenHash}";
            var result = await _cacheProvider.KeyExists<string?>(key);

            return result;
        }

        private static string GetSha256_hash(string value)
        {
            var Sb = new StringBuilder();

            using (var hash = SHA256.Create())
            {
                var enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(value));

                foreach (byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
        }
    }
}
