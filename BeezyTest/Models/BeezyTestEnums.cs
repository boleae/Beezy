using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeezyTest.Models
{
    public static class BeezyTestEnums
    {
        public enum ServiceType
        {
            [SearchValue("cache")]
            Cache,
            [SearchValue("api")]
            Api,
            [SearchValue("database")]
            Database
        } 


    }
}