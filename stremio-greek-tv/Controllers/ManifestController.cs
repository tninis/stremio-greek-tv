using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using stremio_greek_tv.Helpers;
using stremio_greek_tv.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace stremio_greek_tv.Controllers
{    
    [ApiController]
    public class ManifestController : ControllerBase
    {
        private readonly ILogger<ManifestController> _logger;
        private readonly IWebHostEnvironment _env;

        public ManifestController(ILogger<ManifestController> logger, IWebHostEnvironment env)
        {
            _logger = logger;
            _env = env;
        }

        [Route("manifest.json")]
        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult(ManifestHelpers.GetManifest());
        }
        
    }
}
