using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ivwL.WeChat.Utilities
{
    public class MyHttpContext
    {
        private static IHttpContextAccessor _accessor;
        public static HttpContext Current => _accessor.HttpContext;
        internal static void Configure(IHttpContextAccessor accessor) => _accessor = accessor;
    }

    public static class StaticMyHttpContext
    {
        public static void AddMyHttpContextAccessor(this IServiceCollection services) => services.AddSingleton<IHttpContextAccessor, IHttpContextAccessor>();
        public static void UseMyStaticHttpContext(this IApplicationBuilder app) => MyHttpContext.Configure(app.ApplicationServices.GetService<IHttpContextAccessor>());
    }
}
