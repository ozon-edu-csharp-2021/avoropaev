using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;

namespace MerchandiseService.Infrastructure.Middlewares
{
    public class HTTPRequestResponseLoggerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<HTTPRequestResponseLoggerMiddleware> _logger; 
        
        public HTTPRequestResponseLoggerMiddleware(RequestDelegate next, ILogger<HTTPRequestResponseLoggerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await LogRequest(context);
            await _next(context);
            await LogResponse(context);
        }

        private async Task LogResponse(HttpContext context)
        {
            try
            {
                context.Request.EnableBuffering();
                string loggingHeader = LogHeader(context.Response.Headers);
                
                _logger.LogInformation("Header response logged");
                _logger.LogInformation(loggingHeader);
                
                context.Request.Body.Position = 0;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Could not log response body");
            }
        }

        private async Task LogRequest(HttpContext context)
        {
            try
            {
                context.Request.EnableBuffering();
                string loggingHeader = LogHeader(context.Request.Headers);
                
                _logger.LogInformation("Header request logged");
                _logger.LogInformation(loggingHeader);
                
                _logger.LogInformation(context.Request.Path);
                _logger.LogInformation("Route request logged");
                context.Request.Body.Position = 0;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Could not log request body");
            }
        }

        private string LogHeader(IDictionary<string, StringValues> headers)
        {
            string loggingHeader = "";
            foreach (var header in headers)
            {
                loggingHeader += $"Key: {header.Key}, ";
                loggingHeader += "Values: ";
                foreach (var value in header.Value)
                {
                    loggingHeader += value;
                }
                loggingHeader += ";\n";
            }
            Console.WriteLine(loggingHeader);
            return loggingHeader;
        }
        
    }
}