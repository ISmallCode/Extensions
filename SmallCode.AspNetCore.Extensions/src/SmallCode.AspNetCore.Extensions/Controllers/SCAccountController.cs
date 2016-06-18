using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SmallCode.AspNetCore.Extensions.Controllers
{
    public class SCAccountController : Controller
    {
        /// <summary>
        /// 传入票据登录
        /// </summary>
        /// <param name="claims"></param>
        public async void SignInAsync(List<Claim> claims)
        {
            await HttpContext.Authentication.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                               new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme)));
        }

        /// <summary>
        /// 增加用户名当作票据
        /// </summary>
        /// <param name="UserName"></param>
        public async void SignInAsync(string UserName)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, UserName));
            await HttpContext.Authentication.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                               new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme)));
        }

        /// <summary>
        /// 注销
        /// </summary>
        public async void SignOutAsync()
        {
            await HttpContext.Authentication.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}
