using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BeezyTest.Models
{

    public class ManagerRequest
    {
        [JsonProperty(PropertyName ="checkSimilarMovies")]
        public bool CheckSimilarMovies { get; set; }
    }


    public class UpcomingMoviesRequest:ManagerRequest
    {
        [JsonProperty( "ageRateCountry")]
        public string CertificationCountry { get; set; }
        [JsonProperty(PropertyName ="ageRate")]
        public string AgeRate { get; set; }
        [JsonProperty(PropertyName ="genre")]
        public string Genre { get; set; }

    }

    public class BillboardRequest:ManagerRequest
    {
        [Range(1,24)]
        [Required()]
        [JsonProperty(PropertyName = "numberOfWeeks")]
        public int NumberOfWeeks { get; set; }
        [JsonProperty(PropertyName = "city")]
        public string City { get; set; }

    }

    public class StandarBillboardRequest:BillboardRequest
    {
        [JsonProperty(PropertyName = "numberOfScreen")]
        public int NumberOfScreens { get; set; }
    }

    public class SmartBillboardRequest:BillboardRequest
    {

        [Range(1, 50)]
        [Required]
        [JsonProperty(PropertyName = "screensBigRooms")]
        public int ScreensInBigRooms { get; set; }
        [Range(1, 50)]
        [Required]
        [JsonProperty(PropertyName = "screensSmallRooms")]
        public int ScreensInSmallRooms { get; set; }

    }
}

   


   