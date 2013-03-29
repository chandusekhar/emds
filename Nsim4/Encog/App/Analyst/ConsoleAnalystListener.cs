namespace Encog.App.Analyst
{
    using Encog.ML.Train;
    using Encog.Util;
    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    public class ConsoleAnalystListener : IAnalystListener
    {
        private bool _x7053348d2ed32cc2;
        private readonly Stopwatch _x7e449cf8c84697bd = new Stopwatch();
        private bool _x9c634a5895db7e70;
        private string _xcd6e8e7cbb7973db = "";

        public void Report(int total, int current, string message)
        {
            if (total == 0)
            {
                Console.Out.WriteLine(current + " : " + message);
            }
            else
            {
                Console.Out.WriteLine(string.Concat(new object[] { current, "/", total, " : ", message }));
            }
        }

        public void ReportCommandBegin(int total, int current, string name)
        {
            Console.Out.WriteLine();
            if (total == 0)
            {
                Console.Out.WriteLine(string.Concat(new object[] { "Beginning Task#", current, " : ", name }));
                if ((((uint) current) & 0) != 0)
                {
                    return;
                }
            }
            else
            {
                Console.Out.WriteLine(string.Concat(new object[] { "Beginning Task#", current, "/", total, " : ", name }));
            }
            this._xcd6e8e7cbb7973db = name;
            if ((((uint) current) - ((uint) total)) >= 0)
            {
                this._x7e449cf8c84697bd.Start();
            }
        }

        public void ReportCommandEnd(bool cancel)
        {
            // This item is obfuscated and can not be translated.
            string str = "";
            if (1 == 0)
            {
                if ((((uint) cancel) | 8) == 0)
                {
                    goto Label_000B;
                }
                goto Label_0030;
            }
            goto Label_00A0;
        Label_000B:
            if (cancel)
            {
            }
        Label_0030:
            str = "canceled";
            Console.Out.WriteLine("Task " + this._xcd6e8e7cbb7973db + " " + str + ", task elapsed time " + Format.FormatTimeSpan((int) (this._x7e449cf8c84697bd.ElapsedMilliseconds / 0x3e8L)));
            if ((((uint) cancel) + ((uint) cancel)) >= 0)
            {
                return;
            }
        Label_00A0:
            this._x9c634a5895db7e70 = false;
            this._x7e449cf8c84697bd.Stop();
            goto Label_000B;
        }

        public void ReportTraining(IMLTrain train)
        {
            Console.Out.WriteLine("Iteration #" + Format.FormatInteger(train.IterationNumber) + " Error:" + Format.FormatPercent(train.Error) + " elapsed time = " + Format.FormatTimeSpan((int) (this._x7e449cf8c84697bd.ElapsedMilliseconds / 0x3e8L)));
        }

        public virtual void ReportTrainingBegin()
        {
        }

        public virtual void ReportTrainingEnd()
        {
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void RequestCancelCommand()
        {
            this._x9c634a5895db7e70 = true;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void RequestShutdown()
        {
            this._x7053348d2ed32cc2 = true;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public bool ShouldShutDown()
        {
            return this._x7053348d2ed32cc2;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public bool ShouldStopCommand()
        {
            return this._x9c634a5895db7e70;
        }
    }
}

