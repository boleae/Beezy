using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace BeezyTest.Config
{
    public class WebConfigManager : IConfigManager
    {

       

        public string GetApiDatabaseKey()
        {
            return ConfigurationManager.AppSettings["MovieDatabaseApiKey"];
        }

        public string GetDiscoverMoviesService()
        {
            return ConfigurationManager.AppSettings["DiscoverMoviesService"];
        }

       
        public string GetUrlMovieDatabaseUrlBase()
        {
            return ConfigurationManager.AppSettings["UrlMovieDatabaseBaseUrl"];
        }

        public string GetGenresMoviesService()
        {
            return ConfigurationManager.AppSettings["GenresMoviesService"];
        }

        
    }
}