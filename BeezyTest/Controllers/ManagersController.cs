using BeezyTest.Helpers;
using BeezyTest.Models;
using BeezyTest.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using BeezyTest.Extensions;
using log4net;
using BeezyTest.Log;
using System.Text;
using System.Web.Http.ModelBinding;

namespace BeezyTest.Controllers
{
    public class ManagersController : ApiController
    {

        private readonly ICinemaService _cinemaService;
        private readonly IMoviesService _moviesService;
        private readonly IGenresService _genresService;
        private readonly ILogger _logger;


        public ManagersController(ICinemaService cinemaService,
                                    IMoviesService moviesService,
                                    IGenresService genresService,
                                    ILogger logger)
        {
            _cinemaService = cinemaService;
            _moviesService = moviesService;
            _genresService = genresService;
            _logger = logger;
           
        }

        [HttpGet]
        [Route("api/managers/upcomming-movies")]
        public IHttpActionResult GetUpcomingMovies([FromBody]UpcomingMoviesRequest request)
        {
            return InternalServerError(new NotImplementedException("Operación no implementada"));
        }

        [HttpGet]
        [Route("api/managers/billboard")]
        public IHttpActionResult GetBillboard([FromBody]StandarBillboardRequest request)
        {
            return InternalServerError(new NotImplementedException("Operación no implementada"));
        }


       
        [CacheWebApi(Duration =20)]
        [HttpGet]
        [Route("api/managers/intelligent-billboard")]
        public IHttpActionResult GetIntelligentBillboard([FromBody]SmartBillboardRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelErrors());
            }
                
            try
            {
                List<Billboard> billBoard = new List<Billboard>();
                List<long> filterGenresForBigRooms = null;
                List<long> filterGenresForSmallRooms = null;
                if (request.CheckSimilarMovies)
                {
                    filterGenresForBigRooms = GetFilterGenres(request.City, RoomType.Big);
                    filterGenresForSmallRooms = GetFilterGenres(request.City, RoomType.Small);
                }

                List<string> moviesForBigRooms = _moviesService.GetMostPopularMovies(request.NumberOfWeeks * request.ScreensInBigRooms, filterGenresForBigRooms);
                List<string> moviesForSmallRooms = _moviesService.GetLessPopularMovies(request.NumberOfWeeks * request.ScreensInSmallRooms, filterGenresForSmallRooms);

                List<string>[] moviesBigRoomsGrouped = moviesForBigRooms.ChunkBy(request.ScreensInBigRooms).ToArray();
                List<string>[] moviesSmallRoomsGrouped = moviesForSmallRooms.ChunkBy(request.ScreensInSmallRooms).ToArray();

                for (int i = 0; i < request.NumberOfWeeks; i++)
                {
                    Billboard weeklyBillBoard = new Billboard();
                    weeklyBillBoard.IdWeek = i + 1;
                    weeklyBillBoard.Movies.AddRange(moviesBigRoomsGrouped[i]);
                    weeklyBillBoard.Movies.AddRange(moviesSmallRoomsGrouped[i]);
                    billBoard.Add(weeklyBillBoard);

                }

                return Ok(billBoard);
            }
            catch(Exception ex)
            {
                _logger.PublishException(ex);
                return InternalServerError(ex);
            }
            
        }

     


        private string ModelErrors()
        {
            StringBuilder errorMessage = new StringBuilder();
            foreach(var value in  ModelState.Values)
            {
                foreach(var error in  value.Errors)
                {
                    errorMessage.Append(error.Exception != null ? error.Exception.Message : error.ErrorMessage);
                    errorMessage.Append(Environment.NewLine);
                }
            }

            return errorMessage.ToString();
        }




        private List<long> GetFilterGenres(string city, RoomType roomType)
        {
            List<string> mostPopularGenres = _cinemaService.GetMostPopularGenres(city, roomType);
            return _genresService.GetAllGenres().Where(x => mostPopularGenres.Contains(x.Key)).
                                                        Select(x => x.Value).ToList();
        }

         
    }
}
