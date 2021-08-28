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
    public class CatalogController : ControllerBase
    {
        [HttpGet("{type}/{id}")]
        public JsonResult Get(string type, string id)
        { 
            Meta[] metaPreviews = new Meta[0];

            if(type == "tv")
                metaPreviews = ChannelsData.GetChannelsCatalog();  

            return new JsonResult(new { metas = metaPreviews });
        }  
    }
}
