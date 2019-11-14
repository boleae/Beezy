using BeezyTest.Helpers;
using BeezyTest.Models;
using BeezyTest.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeezyTest.Services
{
    public class GenresCacheService : IGenresService
    {
        private readonly string ALL_GENRES_KEY_CACHE = "AllGenresCache";

        private readonly IGenresService _genresService;

        public GenresCacheService()
        {
            _genresService = Container.Resolve<IGenresService>(BeezyTestEnums.ServiceType.Api);
        }

        public Dictionary<string, long> GetAllGenres()
        {
            Dictionary<string, long> allGenres = new Dictionary<string, long>();
            if (!CacheHelper.Get(ALL_GENRES_KEY_CACHE, out allGenres))
            {
                allGenres = _genresService.GetAllGenres();
                if (allGenres.Count > 0)
                    CacheHelper.Add(allGenres, ALL_GENRES_KEY_CACHE);
            }

            return allGenres;
        }
    }
}