using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace MyMovies.Custom
{
    public class ExceptionLogingMidleware
    {
        private readonly RequestDelegate _next;

        public ExceptionLogingMidleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
              await _next(httpContext);

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
