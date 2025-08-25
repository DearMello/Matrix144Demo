using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace lanetMiddlewareapp
{
    public class _1TokenYoxlaMiddleware
    {
        private readonly RequestDelegate _next;
        public _1TokenYoxlaMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Headers["token"].ToString();
            var tokenhisseleri = token.Split(':');
            var herfler = tokenhisseleri[0];
            var vaxt = int.Parse(tokenhisseleri[1]);

            if(herfler.Length != 5)
            {
                context.Response.StatusCode = 401;
                return;
            }

            int saat = vaxt / 100;
            int deqiqe = vaxt % 100;

            int indi = DateTime.Now.Hour * 100 + DateTime.Now.Minute;
            if(vaxt > indi)
            {
                context.Response.StatusCode = 401;
                return;
            }

            await _next(context);
        }
    }
}
