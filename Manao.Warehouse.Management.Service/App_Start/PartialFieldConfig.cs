using PartialResponse.Net.Http.Formatting;
using System.Web.Http;

namespace Manao.Warehouse.Management.Service
{
    public static class PartialFieldConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Formatters.Clear();
            config.Formatters.Add(new PartialJsonMediaTypeFormatter { IgnoreCase = true });
        }
    }
}