using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SmallCode.AspNetCore.Extensions.Controllers
{
    public class SmallCodeBaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            OnInit();
            base.OnActionExecuting(context);
        }

        public virtual void OnInit()
        {

        }
    }
}
