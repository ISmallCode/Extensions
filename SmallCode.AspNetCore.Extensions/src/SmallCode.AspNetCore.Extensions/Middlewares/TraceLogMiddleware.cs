using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using SmallCode.AspNetCore.Extensions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace SmallCode.AspNetCore.Extensions.Middlewares
{
    public static class TraceLogMiddleware
    {
        public static IApplicationBuilder UseTraceLog(this IApplicationBuilder app)
        {
            return app.UseMiddleware<TraceLog>();
        }
    }

    public class TraceLog
    {
        private readonly RequestDelegate next;
        public TraceLog(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            string ip = context.Request.HttpContext.Connection.RemoteIpAddress.ToString();
            var db = context.RequestServices.GetService<SmallCodeContext>();
            try
            {
                string url = context.Request.Path.Value;
                Log log = new Log()
                {
                    Description = "访问了" + url,
                    Level = LogLevel.记录,
                    Ip = ip,
                };
                db.Logs.Add(log);
                await db.SaveChangesAsync();
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
                db.Logs.Add(log);
                await db.SaveChangesAsync();
                context.Response.Redirect("/Home/Error");
            }
        }
    }

}
