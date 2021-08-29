using m3uParser;
using Microsoft.AspNetCore.Http;
using stremio_greek_tv.Helpers;
using stremio_greek_tv.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stremio_greek_tv.Data
{
    public static class ChannelsData
    {       
        public async static Task<Meta[]> GetChannelsCatalog()
        {       
            var channels = new List<Meta>();
            try
            {
                var channelsPlaylist = await M3U.ParseFromUrlAsync(Constants.TVChannelsFileUrl);

                foreach (var media in channelsPlaylist.Medias)
                {
                    var channelInternalId = MetaHelpers.CreateMetaId(media.Attributes.TvgId);
                    channels.Add(new Meta 
                    {
                        Id = channelInternalId,
                        Name = media.Title.RawTitle,
                        Type = "tv",
                        Poster = media.Attributes.TvgLogo
                    });
                }
            }
            catch (Exception ex)
            {
                //TODO : Log Exception
                              
            }

            return channels.ToArray();
        }

        public async static Task<Dictionary<string, Stream[]>> GetChannelStreams()
        {
            var channelsStreams = new Dictionary<string, Stream[]>();
            try
            {
                var channelsPlaylist = await M3U.ParseFromUrlAsync(Constants.TVChannelsFileUrl);
                foreach (var media in channelsPlaylist.Medias)
                {
                    var channelInternalId = MetaHelpers.CreateMetaId(media.Attributes.TvgId);
                    channelsStreams.Add(channelInternalId, new Stream[] { new Stream { Title = media.Title.RawTitle, Url = media.MediaFile }});
                }
            }
            catch (Exception ex)
            {
                //TODO : Log Exception
                              
            }

            return channelsStreams;
        }
    }
}
