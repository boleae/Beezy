using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;

namespace BeezyTest
{
    public class CacheWebApiAttribute:ActionFilterAttribute
    {

        public int Duration { get; set; }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            actionExecutedContext.Response.Headers.CacheControl = new System.Net.Http.Headers.CacheControlHeaderValue()
            {
                MaxAge = TimeSpan.FromMinutes(Duration),
                MustRevalidate = true,
                Private = true
            };
            
        }
    }
}