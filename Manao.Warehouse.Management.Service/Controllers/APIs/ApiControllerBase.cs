using Manao.Warehouse.Management.Utils;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Manao.Warehouse.Management.Service.Controllers.APIs
{
    public class ApiControllerBase : ApiController
    {
        public ApiControllerBase() { }

        protected T GetQueryArgs<T>(string key)
        {
            var query = HttpContext.Current.Request.QueryString;
            if (query.HasKeys())
                return query.Get(key).As<T>();

            return default(T);
        }

        protected HttpResponseMessage CreateResponse(object value)
        {
            return CreateResponse(HttpStatusCode.OK, value);
        }

        protected HttpResponseMessage CreateResponse(HttpStatusCode statusCode, object value)
        {
            return ActionContext.Request.CreateResponse(statusCode, value);
        }
    }
}