using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using miniShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace miniShop.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginModel userLoginModel)
        {
            if (ModelState.IsValid)
            {
                User user = await validateUser(userLoginModel.UserName, userLoginModel.Password);
                if (user != null)
                {
                    List<Claim> claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Email,user.Email),
                        new Claim(ClaimTypes.Role,user.Role),
                        new Claim(ClaimTypes.Name,user.Name),
                    };

                    ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync(claimsPrincipal);
                    return Redirect("/");
                }
                ModelState.AddModelError("", "UserName or Password incorrect!");
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }

        private  async Task<User> validateUser(string userName, string password)
        {
            var userList = new List<User>
            {
                 new User{ Email="turkay.urkmez@dinamikzihin.com", Id=1, Name="Türkay", Role="Admin", UserName="turkayurkmez", Password="123"},
                 new User{ Email="okan.nerkis@vakifbank.com.tr", Id=2, Name="Okan", Role="Editor", UserName="onergis", Password="123"},
                 new User{ Email="gencay.karadeniz@vakifbank.com.tr", Id=3, Name="Gencay", Role="Standart", UserName="karadeniz", Password="123"},


            };

            return userList.FirstOrDefault(x => x.UserName == userName && x.Password == password);

        }
    }
}
