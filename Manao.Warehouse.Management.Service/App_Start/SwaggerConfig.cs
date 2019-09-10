using Manao.Warehouse.Management.Service;
using Swashbuckle.Application;
using System.Reflection;
using System.Web.Http;
using WebActivatorEx;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace Manao.Warehouse.Management.Service
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            Assembly thisAssembly = typeof(SwaggerConfig).Assembly;
            GlobalConfiguration.Configuration
                                           .EnableSwagger(c => c.SingleApiVersion("v1", "Customer.Inquiry.Service"))
                                           .EnableSwaggerUi();
        }
    }
}
