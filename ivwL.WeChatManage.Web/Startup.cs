using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using ivwL.WeChat.Utilities;

namespace ivwL.WeChatManage.Web
{
    public class Startup
    {

        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) => Configuration = configuration;
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            CacheData.AppSettings = Configuration.GetSection("AppSettings").Get<AppSettings>();
            CacheData.ConnectionStrings = Configuration.GetSection("ConnectionStrings").Get<ConnectionStrings>();

            services.AddSession(a =>
            {
                a.IdleTimeout = TimeSpan.FromMinutes(CacheData.AppSettings.CacheEffectiveTime);
            });
            services.AddOptions();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddMemoryCache();
            services.AddDistributedMemoryCache();

            services.AddLogging();

            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.AreaViewLocationFormats.Clear();
                options.AreaViewLocationFormats.Add("/{2}/{1}/{0}.cshtml");
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseSession();
            app.UseStaticFiles();
            app.UseDefaultFiles();
            app.UseAuthorization();
            app.UseMyStaticHttpContext();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=account}/{action=index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "area",
                    pattern: "{area:exists}/{controller}/{action}/{id?}");
            });
        }
    }
}
