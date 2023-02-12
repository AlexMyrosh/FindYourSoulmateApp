using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System;
using PL.Constants;

namespace PL.MiddleWares
{
    public class UserIdCookiesMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            Guid userId;
            if (context.Request.Cookies[UserConstants.UserIdCookieKey] == null)
            {
                userId = Guid.NewGuid();
                var options = new CookieOptions
                {
                    Expires = DateTimeOffset.MaxValue
                };
                context.Response.Cookies.Append(UserConstants.UserIdCookieKey, userId.ToString(), options);
            }
            else
            {
                userId = new Guid(context.Request.Cookies[UserConstants.UserIdCookieKey]);
            }

            context.Items[UserConstants.UserIdCookieKey] = userId;

            await next.Invoke(context);
        }

    }
}
