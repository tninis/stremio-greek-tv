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
            return $"{Constants.IdPrefix}_{tvgId}";
        }

        public static string GePureTvgId(string id, string separator = "_")
        {
            var splitId = id.Split(separator);            
            return splitId.Length == 2 ? splitId[1] : "";
        }
    }
}
