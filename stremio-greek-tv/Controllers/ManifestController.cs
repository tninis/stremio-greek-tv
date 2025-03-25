using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using stremio_greek_tv.Helpers;

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
