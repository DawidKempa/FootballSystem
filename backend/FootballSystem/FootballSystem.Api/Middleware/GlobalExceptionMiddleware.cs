
using System.Net;
using System.Text.Json;

namespace FootballSystem.Api.Middleware
{
    public class GlobalExceptionMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Response.ContentType = "application/json";

                var error = new {message = ex.Message};

                await context.Response.WriteAsync(JsonSerializer.Serialize(error));
            }
        }
    }
}
