namespace Encog.Util.Logging
{
    using Encog;
    using System;

    public class EncogLogging
    {
        public const int LevelCritical = 3;
        public const int LevelDebug = 0;
        public const int LevelDisable = 4;
        public const int LevelError = 2;
        public const int LevelInfo = 1;

        public static void Log(Exception t)
        {
            Log(2, t);
        }

        public static void Log(int level, Exception t)
        {
            EncogFramework.Instance.LoggingPlugin.Log(level, t);
        }

        public static void Log(int level, string message)
        {
            EncogFramework.Instance.LoggingPlugin.Log(level, message);
        }

        public int CurrentLevel
        {
            get
            {
                return EncogFramework.Instance.LoggingPlugin.LogLevel;
            }
        }
    }
}

