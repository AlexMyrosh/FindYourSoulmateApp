using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System;

namespace Presentation_Layer.MiddleWares
{
    public class UserIdCookiesMiddleware : IMiddleware
    {
        private const string CookieKey = "UserId";

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var userId = Guid.NewGuid();
            if (context.Request.Cookies[CookieKey] == null)
            {
                var options = new CookieOptions
                {
                    Expires = DateTimeOffset.MaxValue
                };
                context.Response.Cookies.Append(CookieKey, userId.ToString(), options);
            }
            else
            {
                userId = new Guid(context.Request.Cookies[CookieKey]);
            }

            context.Items[CookieKey] = userId;

            await next.Invoke(context);
        }

    }
}
