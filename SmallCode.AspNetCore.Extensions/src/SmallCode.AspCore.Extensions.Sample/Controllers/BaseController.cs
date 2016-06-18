using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmallCode.AspNetCore.Extensions.Controllers;
using SmallCode.AspCore.Extensions.Sample.Models;
using Microsoft.Extensions.DependencyInjection;
using SmallCode.AspNetCore.Extensions.Models;
using Microsoft.EntityFrameworkCore;

namespace SmallCode.AspCore.Extensions.Sample.Controllers
{
    public class BaseController : SCBaseController
    {
        public User CurrentUser { set; get; }

        public SampleContext db { get { return HttpContext.RequestServices.GetService<SampleContext>(); } }

        public override void OnInit()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                CurrentUser = db.Users.Where(x => x.UserName == HttpContext.User.Identity.Name).SingleOrDefault();
                ViewBag.CurrentUser = CurrentUser;
            }
            base.OnInit();
        }

        public override void SaveLog()
        {
            string url = HttpContext.Request.Path.Value;
            string ip = HttpContext.Request.HttpContext.Connection.RemoteIpAddress.ToString();
            Log log = new Log()
            {
                Description = "访问了" + url,
                Level = LogLevel.记录,
                Ip = ip,
            };
            db.Logs.Add(log);
            db.SaveChanges();
        }

    }
}
