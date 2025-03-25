using stremio_greek_tv.Models;
using System.IO;
using System;
using Microsoft.AspNetCore.Hosting;
using System.Linq;
using System.Text.Json;

namespace stremio_greek_tv.Helpers
{
    public static class ManifestHelpers
    {
        private static IWebHostEnvironment _env;
        public static void Initialize(IWebHostEnvironment env)
        {
            _env = env;
        }
        public static Manifest GetManifest()
        {
            var manifestPath = Path.Combine(AppContext.BaseDirectory, $"manifest.{_env.EnvironmentName}.json");
            using (StreamReader r = new StreamReader(manifestPath))
            {
                string json = r.ReadToEnd();
                return JsonSerializer.Deserialize<Manifest>(json);
            }
        }

        public static string IdPrefix => GetManifest()?.IdPrefixes?.FirstOrDefault();
    }
}
