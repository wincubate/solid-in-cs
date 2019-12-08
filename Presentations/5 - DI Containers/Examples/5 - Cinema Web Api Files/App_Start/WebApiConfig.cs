using Cinema.DataAccess.Sql;
using Cinema.Domain;
using Cinema.Domain.Interfaces;
using Cinema.UI.WebApi.Models;
using System.Web.Http;
using Unity;

namespace Cinema.UI.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Composition Root
            IUnityContainer container = new UnityContainer();
            container
                .RegisterType<IMovieService, MovieService>()
                .RegisterType<IMovieRepository, SqlMovieRepository>()
                .RegisterSingleton<ITimeProvider, DefaultTimeProvider>()
                .RegisterType<IUserContext, NullUserContext>()
                ;

            config.DependencyResolver = new UnityResolver(container);

            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Remove the XML formatter
            config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}
