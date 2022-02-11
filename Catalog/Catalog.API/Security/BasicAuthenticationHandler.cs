using Catalog.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Catalog.API.Security
{
    public class BasicAuthenticationHandler : AuthenticationHandler<BasicAuthenticationOption>
    {
        private IUserService userService;

        public BasicAuthenticationHandler(IOptionsMonitor<BasicAuthenticationOption> optionsMonitor, ILoggerFactory loggerFactory, UrlEncoder
          urlEncoder, ISystemClock clock, IUserService userService) : base(optionsMonitor, loggerFactory, urlEncoder, clock)
        {
            this.userService = userService;
        }
        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            //1. "Authorization" var mı?
            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return Task.FromResult(AuthenticateResult.NoResult());
            }

            if (!AuthenticationHeaderValue.TryParse(Request.Headers["Authorization"],out AuthenticationHeaderValue headerValue))
            {
                return Task.FromResult(AuthenticateResult.NoResult());

            }

            if (!headerValue.Scheme.Equals("Basic",StringComparison.OrdinalIgnoreCase))
            {
                return Task.FromResult(AuthenticateResult.NoResult());
            }

            var headerValueBytes = Convert.FromBase64String(headerValue.Parameter);
            string userNameAndPassword = Encoding.UTF8.GetString(headerValueBytes);

            var userName = userNameAndPassword.Split(':')[0];
            var password = userNameAndPassword.Split(':')[1];

            var user = userService.ValidateUser(userName, password);
            if (user==null)
            {
                return Task.FromResult(AuthenticateResult.Fail("Kullanıcı adı ya da şifre yanlış"));
            }

            Claim[] claims = new[]
            {
                new Claim(ClaimTypes.Name,userName),
                new Claim(ClaimTypes.Email,user.MailAddress),

            };
            ClaimsIdentity identity = new ClaimsIdentity(claims, Scheme.Name);
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);
            AuthenticationTicket ticket = new AuthenticationTicket(claimsPrincipal, Scheme.Name);
            return Task.FromResult(AuthenticateResult.Success(ticket));


        }


    }
}
