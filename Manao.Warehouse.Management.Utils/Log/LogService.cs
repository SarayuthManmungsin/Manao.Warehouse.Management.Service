using System;

namespace Manao.Warehouse.Management.Utils
{
    public static class LogService
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void Init()
        {
            LogService.Info(new string('-', 80));
            LogService.Info("Starting application..");
        }

        public static void Logs(LogLevel level, string message, Exception ex)
        {
            switch (level)
            {
                case LogLevel.INFO:
                    Info(message, ex);
                    break;
                case LogLevel.ERROR:
                    Error(message, ex);
                    break;
                case LogLevel.WARN:
                    Warn(message, ex);
                    break;
                default:
                    break;
            }
        }

        public static void Error(string message)
        {
            logger.Error(message);
        }
        public static void Error(string message, Exception ex)
        {
            logger.Error(message, ex);
        }

        public static void Info(string message)
        {
            logger.Info(message);
        }
        public static void Info(string message, Exception ex)
        {
            logger.Info(message, ex);
        }

        public static void Warn(string message)
        {
            logger.Warn(message);
        }
        public static void Warn(string message, Exception ex)
        {
            logger.Warn(message, ex);
        }
    }
}
