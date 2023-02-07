using System.Runtime.Serialization.Json;
using System;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace MangaReader.Client.ExtensionsHelper
{
    public static class DistributedCacheextensions
    {
        public static async Task SetRecordAsync<T>(this IDistributedCache cache, 
        string recordId,
        T data,
        TimeSpan? 
        absoluteExpireTime = null, 
        TimeSpan? unusedExpireTime = null)
        {
            var options = new DistributedCacheEntryOptions();

            options.AbsoluteExpirationRelativeToNow = absoluteExpireTime ?? TimeSpan.FromSeconds(60);
            options.SlidingExpiration = unusedExpireTime;

            var jsonData = JsonSerializer.Serialize(data);
            await cache.SetStringAsync(recordId,jsonData,options);
        }
        
        public static async Task <T> GetRecordAsync<T>(this IDistributedCache cache, string recoredId)
        {
            var jsonData = await cache.GetStringAsync(recoredId);

            if(jsonData is null)
            {
                return default(T);
            }
            return JsonSerializer.Deserialize<T>(jsonData);
        }
    }
    
}
