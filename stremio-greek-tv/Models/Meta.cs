namespace stremio_greek_tv.Models
{
    public class Meta
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Poster { get; set; }
        public string Description  { get; set; }
        
    }
    public class MetaResult
    {
        public Meta Meta { get; set; }
    }
}
