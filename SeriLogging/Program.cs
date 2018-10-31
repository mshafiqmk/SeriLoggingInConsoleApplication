using System;
using Serilog;

namespace SeriLogging
    {
    class Program
        {
        static void Main (string[] args)
            {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Console()
                .WriteTo.File($"log.txt", rollingInterval:RollingInterval.Day,rollOnFileSizeLimit:true)
                .CreateLogger();

            var input = new
                {
                    Latitude = 25,
                    Longitude = 134
                };
            var time = 34;
            Log.Information($"Processed {input} in {time} ms. ");
            Log.Information("Hello, SeriLog");
            Log.Error("Some Error");
            Log.CloseAndFlush();
            Console.WriteLine ("Hello World!");

            var logger  = new SomeLogger("ShafiqLogger",Guid.NewGuid().ToString(),"Program.cs");
            logger.Info("Info : Some Info Message For Testing");
            logger.Error("Error : Some Error Occurs ");
            }
        }
    }
