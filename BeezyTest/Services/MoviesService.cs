using BeezyTest.Config;
using BeezyTest.Helpers;
using BeezyTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeezyTest.Services
{
    public class MoviesService : IMoviesService
    {
        #region Const

        private readonly string API_KEY_PARAM_NAME = "api_key=";
        private readonly string POPULARITY_DESC_ORDER = "sort_by=popularity.desc";
        private readonly string POPULARITY_ASC_ORDER = "sort_by=popularity.asc";
        private readonly string WITH_GENRES_FILTER_PARAM_NAME = "with_genres=";
        private readonly string PRIMARY_RELEASE_LESS_PARAM_NAME = "primary_release_date.lte=";
        private readonly string PAGE_PARAM_NAME = "page=";
        private readonly string GENRES_OR_SEPARATOR = "|";
        private readonly string ApiKey;
        private readonly string BaseUrl;
        private readonly string DiscoverMoviesService;

        #endregion

        #region Constructor 

        public MoviesService(IConfigManager configManager)
        {
            ApiKey = configManager.GetApiDatabaseKey();
            BaseUrl = configManager.GetUrlMovieDatabaseUrlBase();
            DiscoverMoviesService = configManager.GetDiscoverMoviesService();

        }

        #endregion


        #region Public Methods

        public List<string> GetLessPopularMovies(int numOfMovies, List<long> filteredGenres = null)
        {
           
            return GetMovies(numOfMovies, POPULARITY_ASC_ORDER, filteredGenres);

        }

        public List<string> GetMostPopularMovies(int numOfMovies, List<long> filteredGenres = null)
        {
            return GetMovies(numOfMovies, POPULARITY_DESC_ORDER, filteredGenres);
        }

        #endregion

        #region Private Methods

        private List<string> GetMovies(int numOfMovies, string popularityOrder, List<long> filteredGenres)
        {
            int page = 1;
            List<string> selectedMovies = new List<string>();

            while (selectedMovies.Count < numOfMovies)
            {
                string urlParams = GetUrlParameters(popularityOrder, page, filteredGenres);
                DiscoveredMovies movies = APICallHelper.RunAsync<DiscoveredMovies>(BaseUrl, urlParams.ToString()).GetAwaiter().GetResult();
                if (movies.TotalResults < numOfMovies)
                    throw new Exception("There aren't enough movies in the database.");

                selectedMovies.AddRange(movies.Results.Select(x => x.Title));
                page++;
            }

            return selectedMovies.Take(numOfMovies).ToList();
        }


       

        private string GetUrlParameters(string popularityOrder, int page, List<long> filteredGenres)
        {
            StringBuilder urlParams = new StringBuilder();
            urlParams.Append($"{DiscoverMoviesService}?{API_KEY_PARAM_NAME}{ApiKey}");
            urlParams.Append($"&{popularityOrder}");
            if (filteredGenres != null && filteredGenres.Any())
            {
                urlParams.Append($"&{WITH_GENRES_FILTER_PARAM_NAME}{string.Join(GENRES_OR_SEPARATOR, filteredGenres.ToArray())}");
            }
            urlParams.Append($"&{PRIMARY_RELEASE_LESS_PARAM_NAME}{DateTime.Now.ToString("yyyy-MM-dd")}");
            urlParams.Append($"&{PAGE_PARAM_NAME}{page}");
            return urlParams.ToString();
        }

        #endregion



    }
}