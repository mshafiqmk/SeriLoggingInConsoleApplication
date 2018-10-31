using System;
using System.Reflection;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using Serilog.Exceptions;

namespace SeriLogging
    {
    public class SomeLoggerFactor
        {
        internal static ILogger CreateLogger (string logger,string activityId,string name)
            {
            var serverUrl = string.Empty;
            var apikey = string.Empty;
            var enricher = new ApplicationDetailsEnricher(logger,activityId,name);

            var loggerConfig = new LoggerConfiguration ()
                .WriteTo.Seq(serverUrl,apiKey:apikey,compact:true)
                .Enrich.WithExceptionDetails()
                .Enrich.With(enricher);
            ;
            var log = loggerConfig.CreateLogger();
            Log.Logger = log;
            return log;
            }

        }

    public class ApplicationDetailsEnricher : ILogEventEnricher
        {
        private readonly string _logger;
        private readonly string _activityId;
        private readonly string _funcName;

        public ApplicationDetailsEnricher (string logger ,string name, string activityId)
            {
            this._logger = logger;
            this._activityId = activityId;
            this._funcName = name;
            }
        public void Enrich (LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
            {
            var appAssembly  = Assembly.GetExecutingAssembly();
            var version      = appAssembly.GetName().Version;
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("ActivityId",_activityId));
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("Function",_funcName));
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("Logger",_logger));
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("MachineName",Environment.MachineName));
            }
        }

    }