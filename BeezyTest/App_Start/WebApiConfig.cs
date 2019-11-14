using BeezyTest.Config;
using BeezyTest.Helpers;
using BeezyTest.Log;
using BeezyTest.Models;
using BeezyTest.Resolver;
using BeezyTest.Services;
using BeezyTest.Unity;
using DataAccessRepository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using Unity;
using Unity.Lifetime;

namespace BeezyTest
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            Container.Register<DbContext, beezycinemaEntities>();
            Container.Register<IGenericRepository<Cinema>, EfRepository<Cinema>>();
            Container.Register<IGenericRepository<City>, EfRepository<City>>();
            Container.Register<IGenericRepository<Genre>, EfRepository<Genre>>();
            Container.Register<IGenericRepository<Movie>, EfRepository<Movie>>();
            Container.Register<IGenericRepository<MovieGenre>, EfRepository<MovieGenre>>();
            Container.Register<IGenericRepository<Room>, EfRepository<Room>>();
            Container.Register<IGenericRepository<Session>, EfRepository<Session>>();
            Container.Register<ICinemaService, BeezyCinemaCacheService>();
            Container.Register<ICinemaService, BeezyCinemaService>(BeezyTestEnums.ServiceType.Database);
            Container.Register<IConfigManager, WebConfigManager>();
            Container.Register<IGenresService, GenresCacheService>();
            Container.Register<IGenresService, GenresWebService>(BeezyTestEnums.ServiceType.Api);
            Container.Register<IMoviesService, MoviesService>();
            Container.Register<ILogger, Log4NetLogger>();
          
            config.DependencyResolver = new UnityResolver(Container.Current);

            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.None;
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            // Configuración y servicios de API web

            // Rutas de API web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
