using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ivwL.WeChatManage.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await Task.Run(new Action(() =>
            {
                IConfigurationRoot configurationRoot = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("hosting.json", true)
                    .AddJsonFile("appsettings.json")
                    //.AddJsonFile("kestrel",true)//Kestrel·þÎñÆ÷
                    .Build();
                CreateWebHostBuilder(args, configurationRoot).Build().Run();
            }));
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args, IConfigurationRoot configurationRoot) =>
            WebHost.CreateDefaultBuilder(args)
                .UseConfiguration(configurationRoot)
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .ConfigureLogging((context, logging) =>
                {
                    logging.AddConsole();
                })
                .UseStartup<Startup>();
    }
}
