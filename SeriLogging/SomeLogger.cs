namespace SeriLogging
    {
    public class SomeLogger : ISomeLogger
        {
        private Serilog.ILogger _logger;
        private string _name;
        private string _activityId;
        private string logger;

        public SomeLogger (string logger,string activityId,string name)
            {
            this._name       = name;
            this._activityId = activityId;
            this.logger     = logger;
            _logger         = SomeLoggerFactory.CreateLogger(logger,activityId,name);
            }
        public void Info(string msg)
            {
            _logger.Information(msg);
            }
        public void Error(string msg)
            {
            _logger.Error(msg);
            }
        public void Warning(string msg)
            {
            _logger.Warning(msg);
            }
        }
    }
