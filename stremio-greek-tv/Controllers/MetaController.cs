using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using stremio_greek_tv.Data;
using stremio_greek_tv.Interfaces;
using stremio_greek_tv.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stremio_greek_tv.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class MetaController : ControllerBase
    {
        private readonly IStreamRetriever _m3uRetriever;
        private readonly IMemoryCache _memoryCache;
        public MetaController(IStreamRetriever m3uRetriever, IMemoryCache memoryCache)
        {
            _m3uRetriever = m3uRetriever;
            _memoryCache = memoryCache;
    }

        [HttpGet("{type}/{id}")]
        public async Task<MetaResult> Get(string type, string id)
        {
            var dictId = id.Split('.')[0];
            //Meta meta =  ChannelsData.GetChannelsCatalog(_m3uRetriever).Result.Where(r=>r.Id == dictId).FirstOrDefault();

            return await _memoryCache.GetOrCreateAsync(
                        CacheConstants.MetaCacheKey,
                        cacheEntry =>
                        {
                            cacheEntry.SlidingExpiration = TimeSpan.FromMinutes(5);
                            return ChannelsData.GetChannelMetaAsync(_m3uRetriever, dictId);
                        });
        }       
    }
}
