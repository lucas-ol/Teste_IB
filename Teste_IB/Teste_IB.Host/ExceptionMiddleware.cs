using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teste_IB.Host
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            this._logger = loggerFactory?.CreateLogger<ExceptionMiddleware>() ?? throw new ArgumentNullException(nameof(loggerFactory));
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }           
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception {ex}");
                httpContext.Response.Clear();
                httpContext.Response.ContentType = "application/json";
                httpContext.Response.StatusCode = 500;

                await httpContext.Response.WriteAsync(Newtonsoft.Json.JsonConvert.SerializeObject(ex));
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class CommunicationExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }
    }

}

