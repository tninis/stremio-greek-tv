using System.Text.Json.Serialization;

namespace stremio_greek_tv.Models
{
    public class Manifest
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("version")]
        public string Version { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("logo")]
        public string Logo { get; set; }

        [JsonPropertyName("types")]
        public string[] Types { get; set; }

        [JsonPropertyName("catalogs")]
        public Catalog[] Catalogs { get; set; }

        [JsonPropertyName("resources")]
        public object[] Resources { get; set; }

        [JsonPropertyName("idPrefixes")]
        public string[] IdPrefixes { get; set; }
    }
}
