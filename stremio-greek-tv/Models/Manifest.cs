using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stremio_greek_tv.Models
{
    public class Manifest
    {
        public string Id { get; set; }       
        public string Version { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string[] Types { get; set; }
        public Catalog[] Catalogs { get; set; }
        public object[] Resources { get; set; }
        public string[] IdPrefixes { get; set; }
    }
}
