using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace WebApiTest2.CustomMiddlewares
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        //22. Ders için yapılan geliştirme
        //public async Task Invoke(HttpContext context)
        //{
        //    var authHeader = context.Request.Headers["Authorization"];

        //    await _next(context);
        //}
        //23. Ders için yapılan geliştirme
        public async Task Invoke(HttpContext context)
        {
            var authHeader = context.Request.Headers["Authorization"];
            if (string.IsNullOrEmpty(authHeader.ToString()) == false && authHeader.ToString().StartsWith("basic", StringComparison.OrdinalIgnoreCase))
            {
                var token = authHeader.ToString().Substring(6).Trim();
                var credentialString = string.Empty;
                try
                {
                    credentialString = Encoding.UTF8.GetString(Convert.FromBase64String(token));
                }
                catch
                {
                    context.Response.StatusCode = 500;
                }
                var credentials = credentialString.Split(':');
                if(credentials[0]=="abm" && credentials[1] == "123456")
                {
                    var claims = new[]
                    {
                        new Claim("name", credentials[0]),
                        new Claim(ClaimTypes.Role, "Admin")
                    };
                    var identity = new ClaimsIdentity(claims, "Basic");
                    context.User = new ClaimsPrincipal(identity);
                }
            }
            else
            {
                context.Response.StatusCode = 401;
            }
            await _next(context);
        }
    }
}
