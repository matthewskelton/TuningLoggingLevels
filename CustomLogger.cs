using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using log4net;

namespace Tuning_Logging_Levels
{
    public enum CustomLogLevel
    {
        Trace,
        Debug,
        Info,
        Warning,
        Error,
        Fatal
    }

    public class CustomLogger
    {
        public static void Log(string message, CustomLogLevel level)
        {
            // ...
            ILog logger = log4net.LogManager.GetLogger("CustomLogger");
            switch (level)
            {
                // ...
                case CustomLogLevel.Info:  logger.Info(message); break;
                case CustomLogLevel.Error: logger.Error(message); break;
                // ...
            }
        }
    }

    public class DecoupledLogger
    {
        public static void Log(EventID eventID, string message)
        {
            // ...
            ILog logger = log4net.LogManager.GetLogger("DecoupledLogger");

            CustomLogLevel level = GetLevelForEventID(eventID);
            switch (level)
            {
                // ...
                case CustomLogLevel.Info: logger.Info(message); break;
                case CustomLogLevel.Error: logger.Error(message); break;
                // ...
            }
        }

        private static CustomLogLevel GetLevelForEventID(EventID eventID)
        {
            throw new NotImplementedException();
        }
    }

}