using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeezyTest.Models
{
    public class TVShowRecommendation:Recommendation
    {
        [JsonProperty(PropertyName ="numberOfSeasons")]
        public int NumberOfSeasons { get; set; }
        [JsonProperty(PropertyName ="numberOfEpisodies")]
        public int NumberOfEpisodies { get; set; }
        [JsonProperty(PropertyName ="isConcluded")]
        public bool IsConcluded { get; set; }

    }
}