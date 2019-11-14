using BeezyTest.Config;
using BeezyTest.Helpers;
using BeezyTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeezyTest.Services
{
    public class GenresWebService : IGenresService
    {
        #region Properties

        
        private readonly string ApiKey;
        private readonly string BaseUrl;
        private readonly string GenresMoviesService;

        #endregion

        #region Constructor

        public GenresWebService(IConfigManager configManager)
        {
            ApiKey = configManager.GetApiDatabaseKey();
            BaseUrl = configManager.GetUrlMovieDatabaseUrlBase();
            GenresMoviesService = configManager.GetGenresMoviesService();
        }

        #endregion



        public Dictionary<string, long> GetAllGenres()
        {
            Dictionary<string, long> mappingNameIdGenres = new Dictionary<string, long>();
            string urlParameters = $"{GenresMoviesService}?api_key={ApiKey}";

            Genres allGenres = APICallHelper.RunAsync<Genres>(BaseUrl, urlParameters).GetAwaiter().GetResult();

            mappingNameIdGenres = allGenres.GenresList.ToDictionary(g => g.Name, g => g.Id);

            return mappingNameIdGenres;


        }
    }
}