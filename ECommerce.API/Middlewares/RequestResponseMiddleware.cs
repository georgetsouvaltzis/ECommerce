using Microsoft.AspNetCore.Http;
using Serilog;
using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace ECommerce.API.Middlewares
{
    public class RequestResponseMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestResponseMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {

            Log.Information($"Requester's IP Address:{context.Connection.RemoteIpAddress}, " +
                $"{Environment.NewLine} Request route: {context.Request.Path}");

            var originalBodystream = context.Response.Body;

            try
            {
                using (var responseBody = new MemoryStream())
                {
                    context.Response.Body = responseBody;

                    await _next(context);
                    context.Response.Body.Seek(0, SeekOrigin.Begin);

                    var body = await new StreamReader(responseBody).ReadToEndAsync();

                    responseBody.Position = 0;
                    Log.Information($"Response value: {body}");

                    await responseBody.CopyToAsync(originalBodystream);

                }
            }

            finally
            {
                context.Response.Body = originalBodystream;
            }

        }
    }
}
