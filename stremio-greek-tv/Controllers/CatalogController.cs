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
    public class CatalogController : ControllerBase
    {
        private readonly IStreamRetriever _m3uRetriever;
        private readonly IMemoryCache _memoryCache;
        public CatalogController(IStreamRetriever m3uRetriever , IMemoryCache memoryCache)
        {
            _m3uRetriever = m3uRetriever;
            _memoryCache = memoryCache;
        }

        [HttpGet("{type}/{id}")]
        public async Task<CatalogResult> Get(string type, string id)
        {
            if(type == "tv")
            {
                return await _memoryCache.GetOrCreateAsync(
                                CacheConstants.CatalogCacheKey,
                                cacheEntry =>
                                {                                    
                                    cacheEntry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5);
                                    return ChannelsData.GetChannelsCatalogAsync(_m3uRetriever);
                                });
            }

            return new CatalogResult { Metas = Array.Empty<Meta>() };
        }  
    }
}
