using Manao.Warehouse.Management.IoC;
using Manao.Warehouse.Management.Utils;
using System.Web.Http;

namespace Manao.Warehouse.Management.Service
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            LogConfig.Configure(Server);
            LogService.Init();

            GlobalConfiguration.Configure(WebApiConfig.Register);
            ObjectFactory.Initialize(UnityConfig.Register(GlobalConfiguration.Configuration));
            GlobalConfiguration.Configure(BsonConfig.Register);
            GlobalConfiguration.Configure(PartialFieldConfig.Register);
            GlobalConfiguration.Configuration.EnsureInitialized();
        }
    }
}
