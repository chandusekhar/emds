namespace Encog.Plugin
{
    using System;

    public interface IEncogPluginLogging1 : EncogPluginBase
    {
        void Log(int level, Exception t);
        void Log(int level, string message);

        int LogLevel { get; }
    }
}

