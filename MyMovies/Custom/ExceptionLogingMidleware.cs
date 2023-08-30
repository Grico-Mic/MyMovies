using Microsoft.AspNetCore.Http;
using MyMovies.Common.Models;
using MyMovies.Common.Services;
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

        public async Task Invoke(HttpContext httpContext , ILogService logService)
        {
            try
            {
              await _next(httpContext);

            }
            catch (Exception ex)
            {
                var logData = new LogData() { Type = LogType.Error, DateCreated = DateTime.Now, Message = ex.ToString() };
                logService.Log(logData);
                throw;
            }
        }
    }
}
