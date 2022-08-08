using m3uParser;
using Microsoft.AspNetCore.Http;
using stremio_greek_tv.Helpers;
using stremio_greek_tv.Interfaces;
using stremio_greek_tv.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stremio_greek_tv.Data
{
    public static class ChannelsData
    { 
        public async static Task<CatalogResult> GetChannelsCatalogAsync(IStreamRetriever m3uRetriever)
        {
            var channels = new List<Meta>();
          
            var channelsPlaylist = await m3uRetriever.GetStreams();

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

            return new CatalogResult { Metas = channels.ToArray() };
        }

        public async static Task<MetaResult> GetChannelMetaAsync(IStreamRetriever m3uRetriever,string channelId)
        {
            var channelMeta = new Meta();
            var channelsPlaylist = await m3uRetriever.GetStreams();
            var channel = channelsPlaylist?.Medias?.Where(r => MetaHelpers.CreateMetaId(r.Attributes.TvgId) == channelId)?.FirstOrDefault();

            if (channel is not null)
            {
                var channelInternalId = MetaHelpers.CreateMetaId(channel.Attributes.TvgId);
                channelMeta = new Meta
                {
                    Id = channelInternalId,
                    Name = channel.Title.RawTitle,
                    Type = "tv",
                    Poster = channel.Attributes.TvgLogo
                };
            }

            return new MetaResult { Meta = channelMeta };
        }

        public async static Task<StreamResult> GetChannelStreamsAsync(IStreamRetriever m3uRetriever, string channelId)
        {  
            var channelsPlaylist = await m3uRetriever.GetStreams();

            var channelsStreams = channelsPlaylist.Medias.Where(r => MetaHelpers.CreateMetaId(r.Attributes.TvgId) == channelId)
                .Select( v => new Stream { Title = v.Title.RawTitle, Url = v.MediaFile } ).ToArray(); 


            return new StreamResult { Streams =  channelsStreams };
        }
    }
}
