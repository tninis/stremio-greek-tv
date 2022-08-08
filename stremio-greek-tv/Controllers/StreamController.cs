using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class StreamController : ControllerBase
    {
        readonly IStreamRetriever _m3uRetriever;
        public StreamController(IStreamRetriever m3uRetriever)
        {
            _m3uRetriever = m3uRetriever;
        }

        [HttpGet("{type}/{id}")]
        public async Task<StreamResult> Get(string type, string id)
        {
            var dictId = id.Split('.')[0];
            return  await ChannelsData.GetChannelStreamsAsync(_m3uRetriever,dictId);
        }
    }
}
