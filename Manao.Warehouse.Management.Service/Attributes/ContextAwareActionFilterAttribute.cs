using System.Diagnostics;
using System.Net.Http;
using System.ServiceModel.Channels;
using System.Web;
using System.Web.Http.Filters;

namespace Manao.Warehouse.Management.Service
{
    public class ContextAwareActionFilterAttribute : ActionFilterAttribute
    {
        private const string _performanceKey = "PerformanceFilter.Value";

        protected static string GetClientIp(HttpRequestMessage request)
        {
            string output = null;
            if (request.Properties.ContainsKey("MS_HttpContext"))
            {
                output = ((HttpContextWrapper)request.Properties["MS_HttpContext"]).Request.UserHostAddress;
            }
            else if (request.Properties.ContainsKey(RemoteEndpointMessageProperty.Name))
            {
                RemoteEndpointMessageProperty prop = (RemoteEndpointMessageProperty)request.Properties[RemoteEndpointMessageProperty.Name];
                output = prop.Address;
            }

            return output;
        }

        protected static float GetContentSize(HttpResponseMessage response)
        {
            return response == null ? 0 : GetContentSize(response.Content);
        }

        protected static float GetContentSize(HttpRequestMessage request)
        {
            return request == null ? 0 : GetContentSize(request.Content);
        }

        protected static float GetContentSize(HttpContent content)
        {
            // get content size
            float contentLength = 0.0f;
            if (content != null)
            {
                content.LoadIntoBufferAsync().Wait();
                contentLength = content.Headers.ContentLength.HasValue ?
                                content.Headers.ContentLength.Value / 1024.0f : 0.0f;
            }

            return contentLength;
        }

        protected static void StartPerformanceMeasurement(HttpRequestMessage request)
        {
            // start requesting performance measure
            Stopwatch stopWatch = new Stopwatch();
            request.Properties[_performanceKey] = stopWatch;
            stopWatch.Start();
        }

        protected static int StopPerformanceMeasurement(HttpRequestMessage request)
        {
            int elapseTime = 0;
            if (request.Properties.ContainsKey(_performanceKey))
            {
                Stopwatch stopwatch = request.Properties[_performanceKey] as Stopwatch;
                if (stopwatch != null)
                {
                    stopwatch.Stop();
                    elapseTime = stopwatch.Elapsed.Milliseconds;
                }
            }

            return elapseTime;
        }
    }
}