using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Infrastructure.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                //await context.Response.WriteAsync(exception.Message);
            }
        }
    }
}
