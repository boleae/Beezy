using BeezyTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BeezyTest.Controllers
{
    public class ViewersController : ApiController
    {
        [HttpGet]
        [Route("api/viewers/movies")]
        public IEnumerable<Recommendation> GetMovies([FromBody]ViewerRequest preferences)
        {
            throw new NotImplementedException("Operación no implementada");
        }

        [HttpGet]
        [Route("api/viewers/tv-shows")]
        public IEnumerable<TVShowRecommendation> GetTvShows([FromBody]ViewerRequest preferences)
        {
            throw new NotImplementedException("Operación no implementada");
        }

        [HttpGet]
        [Route("api/viewers/documentaries")]
        public IEnumerable<Recommendation> GetDocumentaries([FromBody]ViewerRequest preferences)
        {
            throw new NotImplementedException("Operación no implementada");
        }

    }
}
