using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NLog;
using NLog.Web;
using SLH.Common;

namespace SLH
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SetNlogAppPath();
            CreateHostBuilder(args).Build().Run();
            NLog.LogManager.Shutdown();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                }).UseNLog();

        private static void SetNlogAppPath()
        {
            GlobalDiagnosticsContext.Set("appbasepath", BaseHelper.GetCurrentDirectoryPath());
        }
    }
}