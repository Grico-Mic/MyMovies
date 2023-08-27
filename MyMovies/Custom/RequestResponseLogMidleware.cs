﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovies.Custom
{
    public class RequestResponseLogMidleware
    {
        private readonly RequestDelegate _next;

        public RequestResponseLogMidleware(RequestDelegate next)
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