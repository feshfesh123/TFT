using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TFTB.Server.Shared
{
    public class ApiJsonResult : ActionResult
    {
        private HttpStatusCode _statusCode;
        private object _result;
        public ApiJsonResult(object result, HttpStatusCode statusCode)
        {
            _result = result;
            _statusCode = statusCode;
        }
        public ApiJsonResult(HttpStatusCode statusCode)
        {
            _statusCode = statusCode;
        }
        public override Task ExecuteResultAsync(ActionContext context)
        {
            var httpContext = context.HttpContext;
            var request = httpContext.Request;
            var response = httpContext.Response;

            response.ContentType = "application/json; charset=utf-8";
            response.StatusCode = (int)_statusCode;

            var writeFactory = httpContext.RequestServices.GetRequiredService<IHttpResponseStreamWriterFactory>();
            var options = httpContext.RequestServices.GetRequiredService<IOptions<MvcJsonOptions>>().Value;
            var serializerSettings = options.SerializerSettings;

            using (var writer = writeFactory.CreateWriter(response.Body, Encoding.UTF8))
            {
                using (var jsonWriter = new JsonTextWriter(writer))
                {
                    jsonWriter.CloseOutput = false;
                    var jsonSerialzier = JsonSerializer.Create(serializerSettings);
                    jsonSerialzier.Serialize(jsonWriter, _result);
                }
            }

            return Task.CompletedTask;
        }
    }
}
