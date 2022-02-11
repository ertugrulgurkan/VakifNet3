using Catalog.API.Models;
using Catalog.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }
        [HttpPost]
        public IActionResult Login(UserLogin userLogin)
        {
            var user = userService.ValidateUser(userLogin.UserName, userLogin.Password);
            if (user != null)
            {
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.UniqueName,user.UserNAme),
                    new Claim(JwtRegisteredClaimNames.Email,user.MailAddress),

                };


                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Burada çok gizli bir cümlemiz var"));
                var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                //token oluşturuldu:
                var token = new JwtSecurityToken(
                    issuer: "turkay",
                    audience: "turkay",
                    claims: claims,
                    notBefore: DateTime.Now,
                    expires: DateTime.Now.AddHours(3),
                    signingCredentials: credential

                    );

                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });

            }

            return BadRequest(new { message = "Hatalı kullanıcı adı ya da şifre" });
        }
    }
}
