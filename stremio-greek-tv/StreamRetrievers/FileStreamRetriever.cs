using m3uParser;
using m3uParser.Model;
using stremio_greek_tv.Interfaces;
using System.Threading.Tasks;

namespace stremio_greek_tv.StreamRetrievers
{
    public class FileStreamRetriever : IStreamRetriever
    {
        private string _filePath;
        public FileStreamRetriever(string filePath)
        {
            _filePath = filePath;
        }
        public async Task<Extm3u> GetStreams()
        {
            return await Task.FromResult(M3U.ParseFromFile(_filePath));
        }
    }
}
