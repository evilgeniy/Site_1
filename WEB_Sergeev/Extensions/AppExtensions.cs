﻿using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_Sergeev.Middleware;

namespace WEB_Sergeev.Extensions
{
    public static class AppExtensions
    {
        public static IApplicationBuilder UseFileLogging(this
       IApplicationBuilder app)
        => app.UseMiddleware<LogMiddleware>();
    }
}
