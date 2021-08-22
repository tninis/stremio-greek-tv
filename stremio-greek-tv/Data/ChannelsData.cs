using Microsoft.AspNetCore.Http;
using stremio_greek_tv.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stremio_greek_tv.Data
{
    public static class ChannelsData
    {       
        public static Meta[] GetChannelsCatalog(string baseUrl)
        {          
            //Image loads on stremio only on https 
            return new Meta[] {
                new Meta { Id =$"{Constants.IdPrefix}_ert1", Name="ERT 1", Type="tv" ,Poster = $"{baseUrl}/ert1.png"  },
                new Meta { Id =$"{Constants.IdPrefix}_ert2", Name="ERT 2", Type="tv" ,Poster = $"{baseUrl}/ert2.png"  },
                new Meta { Id =$"{Constants.IdPrefix}_ert3", Name="ERT 3", Type="tv" ,Poster = $"{baseUrl}/ert3.png"  },
                new Meta { Id =$"{Constants.IdPrefix}_vouli", Name="VOULI TV", Type="tv" ,Poster = $"{baseUrl}/vouli.png"  },
                new Meta { Id =$"{Constants.IdPrefix}_alpha", Name="ALPHA", Type="tv" ,Poster = $"{baseUrl}/alpha.png"  },
                new Meta { Id =$"{Constants.IdPrefix}_star", Name="STAR", Type="tv" ,Poster = $"{baseUrl}/star.png"  },
                new Meta { Id =$"{Constants.IdPrefix}_open", Name="OPEN", Type="tv" ,Poster = $"{baseUrl}/open.png"  },
                new Meta { Id =$"{Constants.IdPrefix}_mega", Name="MEGA", Type="tv" ,Poster = $"{baseUrl}/mega.png" },
                new Meta { Id =$"{Constants.IdPrefix}_skai", Name="SKAI", Type="tv" ,Poster = $"{baseUrl}/skai.png" },
                new Meta { Id =$"{Constants.IdPrefix}_one", Name="ONE", Type="tv" ,Poster = $"{baseUrl}/one.png"  },
                new Meta { Id =$"{Constants.IdPrefix}_groovy", Name="GROOVY", Type="tv" ,Poster = $"{baseUrl}/groovy.png"  },               
                new Meta { Id =$"{Constants.IdPrefix}_kontra", Name="KONTRA", Type="tv" ,Poster = $"{baseUrl}/kontra.png"  }               
                              
            };
        }

        public static Dictionary<string, Stream[]> GetChannelStreams()
        {
            return new Dictionary<string, Stream[]>()
            {
                { $"{Constants.IdPrefix}_ert1", new Stream[] { new Stream { Title = "ERT 1", Url = "https://ert-live-bcbs15228.siliconweb.com/media/ert_1/ert_1_3Mbps.m3u8" }} },
                { $"{Constants.IdPrefix}_ert2", new Stream[] { new Stream { Title = "ERT 2", Url = "https://ert-live-bcbs15228.siliconweb.com/media/ert_2/ert_2_3Mbps.m3u8" }} },
                { $"{Constants.IdPrefix}_ert3", new Stream[] { new Stream { Title = "ERT 3", Url = "https://ert-live-bcbs15228.siliconweb.com/media/ert_1/ert_3_2Mbps.m3u8" }} },
                { $"{Constants.IdPrefix}_alpha", new Stream[] { new Stream { Title = "ALPHA", Url = "https://alphalive-i.akamaihd.net/hls/live/682300/live/high/prog_index.m3u8" }} },
                { $"{Constants.IdPrefix}_star", new Stream[] { new Stream { Title = "STAR", Url = "https://livestar.siliconweb.com/media/star1/star1mediumhd.m3u8" }} },
                { $"{Constants.IdPrefix}_open", new Stream[] { new Stream { Title = "OPEN", Url = "https://liveopencloud.siliconweb.com/1/ZlRza2R6L2tFRnFJ/eWVLSlQx/hls/kcmblc8k/2728/chunklist.m3u8" }} },
                { $"{Constants.IdPrefix}_mega", new Stream[] 
                    { 
                        new Stream { Title = "MEGA", Url = "https://streamcdnb8-c98db5952cb54b358365984178fb898a.msvdn.net/live/S86713049/gonOwuUacAxM/chunklist_b2628000.m3u8" },
                        new Stream { Title = "MEGA 2", Url = "https://c98db5952cb54b358365984178fb898a.msvdn.net/live/S86713049/gonOwuUacAxM/playlist.m3u8" },
                    } 
                },
                { $"{Constants.IdPrefix}_skai", new Stream[] { new Stream { Title = "SKAI", Url = "https://skai-live-gr-bb.siliconweb.com/media/cambria4/index_bitrate2000K.m3u8" }} },
                { $"{Constants.IdPrefix}_one", new Stream[] { new Stream { Title = "ONE", Url = "https://streaming.onetv.gr/show/onetv_hd720/index.m3u8" }} },
                { $"{Constants.IdPrefix}_groovy", new Stream[] { new Stream { Title = "GROOVY", Url = "https://web.onair-radio.eu/groovytv/groovytv/chunklist_w1859804103.m3u8" }} },
                { $"{Constants.IdPrefix}_vouli", new Stream[] { new Stream { Title = "VOULI", Url = "https://streamer-cache.grnet.gr/parliament/hls/webtv_1280_960x540/index.m3u8" }} },
                { $"{Constants.IdPrefix}_kontra", new Stream[] { new Stream { Title = "KONTRA", Url = "https://kontralive.siliconweb.com/live/kontratv/chunklist.m3u8" }} }
                
            };
        }
    }
}
