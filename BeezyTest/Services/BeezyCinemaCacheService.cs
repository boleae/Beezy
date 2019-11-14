using BeezyTest.Helpers;
using BeezyTest.Models;
using BeezyTest.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeezyTest.Services
{
    public class BeezyCinemaCacheService : ICinemaService
    {
        private readonly ICinemaService _cinemaService;
        private readonly string MOST_POPULAR_GENRES_CACHE_kEY = "MostPopularGenres";

        public BeezyCinemaCacheService()
        {
            _cinemaService = Container.Resolve<ICinemaService>(BeezyTestEnums.ServiceType.Database);
        }

        public List<string> GetMostPopularGenres(string cityName, RoomType type)
        {
            List<string> mostPopularGenres = new List<string>();
            string key = $"{MOST_POPULAR_GENRES_CACHE_kEY}_{cityName}_{type.ToString()}";
            if (!CacheHelper.Get(key, out mostPopularGenres))
            {
                mostPopularGenres = this._cinemaService.GetMostPopularGenres(cityName, type);
                if (mostPopularGenres.Count > 0)
                    CacheHelper.Add(mostPopularGenres, key);

            }

            return mostPopularGenres;
        }
    }
}