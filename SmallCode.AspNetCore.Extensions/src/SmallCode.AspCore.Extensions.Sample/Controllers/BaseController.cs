using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmallCode.AspNetCore.Extensions.Controllers;
using SmallCode.AspCore.Extensions.Sample.Models;
using Microsoft.Extensions.DependencyInjection;
using SmallCode.AspNetCore.Extensions.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SmallCode.AspCore.Extensions.Sample.Controllers
{
    public class BaseController : SmallCodeBaseController
    {
        public SampleContext db { get { return HttpContext.RequestServices.GetService<SampleContext>(); } }

        public override void OnInit()
        {
            base.OnInit();
        }

        public bool SaveLog(Log log)
        {
            bool flag = false;
            db.Logs.Add(log);
            flag = db.SaveChanges() > 0;
            return flag;
        }

    }
}
