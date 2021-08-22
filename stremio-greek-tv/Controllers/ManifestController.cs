using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using stremio_greek_tv.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stremio_greek_tv.Controllers
{    
    [ApiController]
    public class ManifestController : ControllerBase
    {
        private static readonly Manifest manifest = new Manifest
        {
            Id = "tninis.greek.tv.channels",
            Version = "0.0.2",
            Name = "Greek TV",
            Description = "Greek TV Stremio Add-on",
            Resources = new object[] {
                "catalog",
                 new {
                        Name = "meta",
                        Types = new string []{"tv"},
                        IdPrefixes = new string []{ Constants.IdPrefix }
                    },
                "meta",
                "stream"
            },
            Types = new string[] { "tv" },
            Catalogs  = new Catalog[]
            {
                new Catalog{ Type = "tv", Id = "GreekTV", Name = "GreekTV" }
            } 
        };

        [Route("manifest.json")]
        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult(manifest);
        }
    }
}
