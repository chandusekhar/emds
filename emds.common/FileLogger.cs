using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace emds.common
{
    public class FileLogger : IDisposable
    {
        private static bool isCreate;
        private static FileLogger logger;
        private StreamWriter file;

        public const string LogFile = "log.txt";

        private FileLogger()
        {
            isCreate = true;
            file = File.CreateText(LogFile);
        }

        public static FileLogger GetLogger()
        {
            if(isCreate)
                return logger;
            else
            {
                logger = new FileLogger();
                return logger;
            }
        }

        /// <summary>
        /// Записывает строку в лог
        /// </summary>
        /// <param name="log">ЗБ. log на null не проверяется</param>
        public void WriteString(string log)
        {
            file.WriteLine(log);
        }

        public void Dispose()
        {
            isCreate = false;
            file.Flush();
            file.Dispose();
        }
    }
}
