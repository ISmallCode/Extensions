using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using SmallCode.AspNetCore.Extensions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace SmallCode.AspNetCore.Extensions.Middlewares
{
    public static class TraceLogMiddleware
    {
        public static IApplicationBuilder UseTraceLog(this IApplicationBuilder app, Func<Log, bool> func)
        {
            return app.UseMiddleware<TraceLog>(func);
        }
    }

    public class TraceLog
    {
        private readonly RequestDelegate next;
        private readonly Func<Log, bool> func;
        public TraceLog(RequestDelegate next, Func<Log, bool> _func)
        {
            this.next = next;
            func = _func;
        }
        public async Task Invoke(HttpContext context)
        {

            string ip = context.Request.HttpContext.Connection.RemoteIpAddress.ToString();
            try
            {
                string url = context.Request.Path.Value;
                Log log = new Log()
                {
                    Description = "访问了" + url,
                    Level = LogLevel.记录,
                    Ip = ip,
                };
                func(log);
                await next(context);
            }
            catch (Exception ex)
            {
                Log log = new Log()
                {
                    Description = ex.Message,
                    Level = LogLevel.记录,
                    Ip = ip,
                };
                func(log);
                context.Response.Redirect("/Home/Error");
            }
        }
    }

}
