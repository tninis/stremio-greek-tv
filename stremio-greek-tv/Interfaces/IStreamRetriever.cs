using m3uParser.Model;
using System.Threading.Tasks;

namespace stremio_greek_tv.Interfaces
{
    public interface IStreamRetriever
    {
        Task<Extm3u> GetStreams();
    }
}
