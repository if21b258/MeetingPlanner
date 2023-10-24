namespace MeetingPlannerBL.Logging
{
    public class Log4NetWrapper : ILoggerWrapper
    {
        private log4net.ILog _logger;

        private Log4NetWrapper(log4net.ILog logger)
        {
            _logger = logger;
        }

        public static Log4NetWrapper CreateLogger(string configPath)
        {
            if (!File.Exists(configPath))
            {
                throw new ArgumentException("Does not exist.", nameof(configPath));
            }

            log4net.Config.XmlConfigurator.Configure(new FileInfo(configPath));


            var logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            return new Log4NetWrapper(logger);
        }

        public void Debug(string message)
        {
            _logger.Debug(message);
        }

        public void Info(string message)
        {
            _logger.Info(message);
        }

        public void Warn(string message)
        {
            _logger.Warn(message);
        }

        public void Error(string message)
        {
            _logger.Error(message);
        }

        public void Fatal(string message)
        {
            _logger.Fatal(message);
        }
    }
}
