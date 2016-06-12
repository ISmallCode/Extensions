using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmallCode.AspNetCore.Extensions.Controllers;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SmallCode.AspCore.Extensions.Sample.Controllers
{
    public class BaseController : SmallCodeBaseController
    {
        public override void OnInit()
        {
            base.OnInit();
        }
    }
}
