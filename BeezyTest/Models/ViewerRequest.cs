using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeezyTest.Models
{
    public class ViewerRequest
    {
        [JsonProperty(PropertyName ="genred")]
        public List<string> GenresPreferred { get; set; }
        [JsonProperty(PropertyName ="keywords")]
        public List<string> Keywords { get; set; }
        [JsonProperty(PropertyName ="upcomingDate")]
        public DateTime UpCommingDate { get; set; }
        [JsonProperty(PropertyName ="topics")]
        public List<string> Topics { get; set; }

    }
}