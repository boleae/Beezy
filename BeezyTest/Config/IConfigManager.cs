using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeezyTest.Config
{
    public interface IConfigManager
    {

        string GetApiDatabaseKey();

        string GetUrlMovieDatabaseUrlBase();

        string GetDiscoverMoviesService();

        string GetGenresMoviesService();

    }
}