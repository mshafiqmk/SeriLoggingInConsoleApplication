namespace SeriLogging
    {
    public class SomeLogger
        {
        private Serilog.ILogger _logger;
        private string name;
        private string activityId;
        private string logger;

        public SomeLogger ()
            {
            _logger = SomeLoggerFactor.CreateLogger(logger,activityId,name);
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
