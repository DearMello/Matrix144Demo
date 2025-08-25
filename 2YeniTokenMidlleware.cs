using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace lanetMiddlewareapp
{
    public class _2YeniTokenMidlleware
    {
        private readonly RequestDelegate _next;
        public _2YeniTokenMidlleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            context.Response.Headers["refreshToken"] = DateTime.Now.AddMinutes(5).ToString();
            await _next(context);
        }
    }
}
