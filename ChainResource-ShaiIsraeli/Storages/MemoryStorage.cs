using ChainResource_ShaiIsraeli.Storages.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace ChainResource_ShaiIsraeli.Storages
{
    public class MemoryStorage<T> : AbstractReadWriteStorage<T>
    {
        private const string cacheKey = "cacheKey";

        public MemoryStorage(int _expirationInterval, PermissionsEnum _permission)
        {
            this.ExpirationInterval = _expirationInterval;
            this.Permissions = _permission;
        }

        public override Task<T> ReadData()
        {
            ObjectCache cache = MemoryCache.Default;
            var res = cache.Get(cacheKey);
            if (res != null)
            {
                return Task.FromResult((T)cache.Get(cacheKey));
            }
            return null;
        }

        public override bool WriteData(T stream)
        {
            try
            {
                ObjectCache cache = MemoryCache.Default;
                var cacheItemPolicy = new CacheItemPolicy
                {
                    AbsoluteExpiration = DateTimeOffset.Now.AddHours(this.ExpirationInterval),

                };
                cache.Add(cacheKey, stream, cacheItemPolicy);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to write data in memory. error: {0}", ex.Message);
                return false;
            }
        }
    }
}
