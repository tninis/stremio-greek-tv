using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using stremio_greek_tv.Data;
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
        [HttpGet("{type}/{id}")]
        public JsonResult Get(string type, string id)
        {
            var dictId = id.Split('.')[0];

            Stream[] res = ChannelsData.GetChannelStreams().GetValueOrDefault(dictId);

            return new JsonResult(new { streams = res });
        }
    }
}
