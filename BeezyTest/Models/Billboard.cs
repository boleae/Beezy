using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeezyTest.Models
{
  
    public class Billboard
    {
        public Billboard()
        {
            Movies = new List<string>();
        }

        [JsonProperty(PropertyName ="week")]
        public int IdWeek { get; set; }
        [JsonProperty(PropertyName ="movies")]
        public List<string> Movies { get; set; }
       
    }
    

}