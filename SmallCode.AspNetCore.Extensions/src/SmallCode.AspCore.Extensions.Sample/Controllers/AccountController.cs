using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmallCode.AspNetCore.Extensions.Controllers;
using SmallCode.AspCore.Extensions.Sample.Models;
using SmallCode.AspNetCore.Extensions.Extensions;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace SmallCode.AspCore.Extensions.Sample.Controllers
{

    public class AccountController : BaseController
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string UserName, string Password, string ReturnUrl)
        {
            if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(Password))
            {
                ModelState.AddModelError("", "用户名或者密码不能为空");
            }
            else
            {
                Password = Password.ToMD5();
                User user = db.Users.Where(x => x.UserName == UserName).FirstOrDefault();
                if (user != null)
                {

                    var claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.Name, UserName));

                    ///登录写入cookie 设置过期时间 这个时间是滑动时间　不是绝对的时间
                    await HttpContext.Authentication.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                              new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme)),
                              new AuthenticationProperties { ExpiresUtc = DateTime.UtcNow.AddMinutes(30) });

                    if (string.IsNullOrEmpty(ReturnUrl))
                    {
                        return Redirect("/Home/Index");
                    }
                    else
                        return Redirect(ReturnUrl);

                }
                else
                    ModelState.AddModelError("", "用户名或者密码错误");
            }
            return View();
        }

    }
}
