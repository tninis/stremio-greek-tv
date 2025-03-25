using System.Text.Json.Serialization;

namespace stremio_greek_tv.Models
{
    public class Catalog
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

    public class CatalogResult
    {
        public Meta[] Metas { get; set; }
    }
}
