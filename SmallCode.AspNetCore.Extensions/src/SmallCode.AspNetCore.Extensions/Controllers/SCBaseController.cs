using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using SmallCode.AspNetCore.Extensions.Models;

namespace SmallCode.AspNetCore.Extensions.Controllers
{
    public class SCBaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            OnInit();
            SaveLog();
            base.OnActionExecuting(context);
        }

        public virtual void OnInit()
        {

        }

        public virtual void SaveLog()
        {

        }

        
    }
}
