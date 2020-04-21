using GeodesyApi.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GeodesyApi.Web.Middleware
{
    public class IdCookieModdleware
    {
        private readonly RequestDelegate _next;
        private readonly UserManager<ApplicationUser> UserManager;

        public IdCookieModdleware(RequestDelegate next, UserManager<ApplicationUser> userManager)
        {
            _next = next;
            this.UserManager = userManager;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            if (httpContext.User != null && httpContext.User.Identity.IsAuthenticated)
            {
                var currenUser = await this.UserManager.FindByNameAsync(httpContext.User.Identity.Name);
                var userId = currenUser.Id;

                var claims = new List<Claim>
            {
                new Claim("UserId", userId)
            };

                var appIdentity = new ClaimsIdentity(claims);
                httpContext.User.AddIdentity(appIdentity);
            }

            await _next(httpContext);
        }
    }
}
