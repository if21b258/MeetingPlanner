namespace MeetingPlannerBL.Logging
{
    public static class LoggerFactory
    {
        public static ILoggerWrapper GetLogger()
        {
            return Log4NetWrapper.CreateLogger("./log4net.config");
        }
    }
}
