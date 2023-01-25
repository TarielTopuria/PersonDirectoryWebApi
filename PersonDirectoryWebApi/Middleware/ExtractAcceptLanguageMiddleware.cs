using Microsoft.Extensions.Primitives;
using System.Net;

namespace PersonDirectoryWebApi.Middleware
{
    public class ExtractAcceptLanguageMiddleware
    {
        private readonly RequestDelegate _next;

        public ExtractAcceptLanguageMiddleware(RequestDelegate next) => _next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            const string HeaderKeyName = "accept-language";
            context.Request.Headers.TryGetValue(HeaderKeyName, out StringValues headerValue);
            if (headerValue != "en-US")
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                await context.Response.WriteAsync("Invalid accept-language header. Only 'en-US' is accepted.");
                return;
            }
            else
            {
                context.Items.Add(HeaderKeyName, $"{headerValue}-received");
            }

            await _next(context);
        }
    }
}
