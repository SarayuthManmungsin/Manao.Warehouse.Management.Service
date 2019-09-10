using Microsoft.AspNet.WebApi.Extensions.Compression.Server;
using System.Net.Http.Extensions.Compression.Core.Compressors;
using System.Web.Http;

namespace Manao.Warehouse.Management.Service
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Only show error on local running only
            config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.LocalOnly;

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Filters.Add(new AsyncLoggingFilter());

            // this is implement on an initialize state, restart web application to trigger.
            config.MessageHandlers.Insert(0, new ServerCompressionHandler(new GZipCompressor(), new DeflateCompressor()));

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
