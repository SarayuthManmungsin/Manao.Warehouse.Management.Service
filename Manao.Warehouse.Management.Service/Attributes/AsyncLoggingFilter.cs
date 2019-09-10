using Manao.Warehouse.Management.Utils;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Manao.Warehouse.Management.Service
{
    internal sealed class AsyncLoggingFilter : ContextAwareActionFilterAttribute
    {
        public override async Task OnActionExecutingAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            HttpRequestMessage request = actionContext.Request;

            // get content size and start requesting performance measure
            StartPerformanceMeasurement(request);
            await Task.Factory.StartNew(() => LogService.Info(string.Format("[{0}] [{1} : <{2}> : >>][{3}], {4:N2}KB.",
                                                            request.Method.Method,
                                                            GetClientIp(actionContext.Request),
                                                            "ManaoUser",
                                                            request.RequestUri,
                                                            GetContentSize(request.Content)
                                                            )));
        }

        public override async Task OnActionExecutedAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            HttpResponseMessage response = actionExecutedContext.Response;
            HttpRequestMessage request = actionExecutedContext.Request;

            // get content size and stop requesting measure performance
            string ipAddress = GetClientIp(request);
            int elapseTime = StopPerformanceMeasurement(request);
            string logMessage = string.Format("[Res:{0} : <<][Cached 304] {1}ms 0.00KB.", ipAddress, elapseTime);
            if (response != null)
            {
                logMessage = string.Format("[{0}] [{1} : <{2}> : <<][{3} {4}] {5}, {6}ms {7:N2}KB.",
                                    response.RequestMessage.Method.Method,
                                    ipAddress,
                                    "ManaoUser",
                                    (int)response.StatusCode,
                                    response.StatusCode,
                                    response.RequestMessage.RequestUri,
                                    elapseTime,
                                    GetContentSize(response));
            }

            await Task.Factory.StartNew(() => LogService.Info(logMessage));
        }
    }
}