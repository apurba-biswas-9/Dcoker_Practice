﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace dcokerSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
             .UseContentRoot(Directory.GetCurrentDirectory())
             .ConfigureAppConfiguration((builderContext, config) =>
             {
                 var configurationBuilder = new ConfigurationBuilder();
                 configurationBuilder.AddEnvironmentVariables();
                 config.AddConfiguration(configurationBuilder.Build());
             })
             .ConfigureLogging((hostingContext, builder) =>
             {
                 builder.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                 builder.AddConsole();
                 builder.AddDebug();
             }) ;
    }
}
