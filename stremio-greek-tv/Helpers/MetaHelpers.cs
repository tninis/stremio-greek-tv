using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stremio_greek_tv.Helpers
{
    public static class MetaHelpers
    {
        public static string CreateMetaId(string tvgId)
        {
            return $"{ManifestHelpers.IdPrefix}_{tvgId.Replace(".","_")}";
        }

        public static string GePureTvgId(string id, string separator = "_")
        {
            var splitId = id.Split(separator);            
            return splitId.Length == 2 ? splitId[1].Replace(".","_") : "";
        }

        public static string GetTvId(string id)
        {
            return id.Split('.')[0];
        }      
    }
}
