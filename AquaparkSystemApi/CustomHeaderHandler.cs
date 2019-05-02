using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace AquaparkSystemApi
{
    public class CustomHeaderHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            return base.SendAsync(request, cancellationToken)
                .ContinueWith((task) =>
                {
                    HttpResponseMessage response = task.Result;
                    response.Headers.Add("Access-Control-Allow-Origin", "*");
                    return response;
                });
        }
    }
}