using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeezyTest.Models
{
   
    public class Recommendation
    {
        [JsonProperty(PropertyName ="title")]
        public string Title { get; set; }
        [JsonProperty(PropertyName ="overview")]
        public string Overview { get; set; }
        [JsonProperty(PropertyName ="genre")]
        public string Genre { get; set; }
        [JsonProperty(PropertyName ="language")]
        public string Language { get; set; }
        [JsonProperty(PropertyName ="releaseDate")]
        public DateTime ReleaseDate { get; set; }
        [JsonProperty(PropertyName ="website")]
        public string WebSite { get; set; }
        [JsonProperty(PropertyName ="keywords")]
        public List<string> AssociatedKeywords { get; set; }
    }
}