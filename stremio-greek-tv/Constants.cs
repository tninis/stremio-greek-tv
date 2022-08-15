using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stremio_greek_tv
{
    class Constants
    {
        public const string IdPrefix = "grtv";
        public const string ImagesBaseUrl = "https://raw.githubusercontent.com/tninis/greek-tv-resources/main/Images";
        public const string TVChannelsFileUrl = "https://raw.githubusercontent.com/tninis/greek-tv-resources/main/Playlists/GRTV.m3u";
        public const string TVChannelsFilePath = @"Resources\Playlists\GRTV.m3u";
    }

    class CacheConstants
    {       
        public const string CatalogCacheKey = "catalogs_tv";
    }
}
