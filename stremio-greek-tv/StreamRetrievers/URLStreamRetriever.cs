using m3uParser;
using m3uParser.Model;
using stremio_greek_tv.Interfaces;
using System.Net.Http;
using System.Threading.Tasks;

namespace stremio_greek_tv.StreamRetrievers
{
    public class URLStreamRetriever : IStreamRetriever
    {
        private readonly string _url;
        public URLStreamRetriever(string url)
        {
            _url = url;
        }
        public async Task<Extm3u> GetStreams()
        {            
            return await M3U.ParseFromUrlAsync(_url);
        }
    }
}
