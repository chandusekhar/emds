namespace Encog.Plugin.SystemPlugin
{
    using Encog.Engine.Network.Activation;
    using Encog.Plugin;
    using System;
    using System.Text;
    using System.Threading;

    public class SystemLoggingPlugin : IEncogPluginLogging1, EncogPluginBase
    {
        private int x6b468d6a6158972e = 4;
        private bool xdc8dbadcba269cc7 = false;

        public void CalculateGradient(double[] gradients, double[] layerOutput, double[] weights, double[] layerDelta, IActivationFunction af, int index, int fromLayerIndex, int fromLayerSize, int toLayerIndex, int toLayerSize)
        {
        }

        public int CalculateLayer(double[] weights, double[] layerOutput, int startIndex, int outputIndex, int outputSize, int inputIndex, int inputSize)
        {
            return 0;
        }

        public void Log(int level, Exception t)
        {
            this.Log(level, t.ToString());
        }

        public void Log(int level, string message)
        {
            StringBuilder builder;
            int num;
            if (this.x6b468d6a6158972e > level)
            {
                return;
            }
            if ((((uint) num) - ((uint) level)) >= 0)
            {
                DateTime now = DateTime.Now;
                builder = new StringBuilder();
                builder.Append(now.ToString());
                if (((uint) level) < 0)
                {
                    goto Label_0065;
                }
            Label_01D0:
                builder.Append(" [");
                num = level;
                if ((((uint) level) - ((uint) num)) < 0)
                {
                    if ((((uint) level) - ((uint) num)) < 0)
                    {
                        return;
                    }
                    goto Label_0130;
                }
                switch (num)
                {
                    case 0:
                        builder.Append("DEBUG");
                        if ((((uint) level) + ((uint) num)) > uint.MaxValue)
                        {
                            goto Label_01D0;
                        }
                        if ((((uint) level) + ((uint) level)) > uint.MaxValue)
                        {
                            goto Label_0130;
                        }
                        goto Label_00B2;

                    case 1:
                        goto Label_0130;

                    case 2:
                        builder.Append("ERROR");
                        goto Label_00B2;

                    case 3:
                        builder.Append("CRITICAL");
                        goto Label_00B2;
                }
                builder.Append("?");
                goto Label_00B2;
            }
            if ((((uint) num) & 0) == 0)
            {
                goto Label_0130;
            }
            goto Label_0072;
        Label_0065:
            if (this.x6b468d6a6158972e > 2)
            {
                Console.Error.WriteLine(builder.ToString());
                if (0 == 0)
                {
                    return;
                }
            }
            else
            {
                Console.Out.WriteLine(builder.ToString());
                return;
            }
        Label_0072:
            builder.Append("]: ");
            builder.Append(message);
            if (this.xdc8dbadcba269cc7)
            {
                goto Label_0065;
            }
            if (-1 == 0)
            {
            }
            return;
        Label_00B2:
            builder.Append("][");
            builder.Append(Thread.CurrentThread.Name);
            if ((((uint) level) + ((uint) level)) <= uint.MaxValue)
            {
                if (0 == 0)
                {
                    if ((((uint) level) - ((uint) num)) > uint.MaxValue)
                    {
                        return;
                    }
                    goto Label_0072;
                }
            }
            else
            {
                goto Label_00B2;
            }
        Label_0130:
            builder.Append("INFO");
            goto Label_00B2;
        }

        public void StartConsoleLogging()
        {
            this.StopLogging();
            this.xdc8dbadcba269cc7 = true;
            this.LogLevel = 0;
        }

        public void StopLogging()
        {
            this.xdc8dbadcba269cc7 = false;
        }

        public int LogLevel
        {
            get
            {
                return this.x6b468d6a6158972e;
            }
            set
            {
                this.x6b468d6a6158972e = value;
            }
        }

        public string PluginDescription
        {
            get
            {
                return "This is the built in logging for Encog, it logs to either a file or System.out";
            }
        }

        public string PluginName
        {
            get
            {
                return "HRI-System-Logging";
            }
        }

        public int PluginServiceType
        {
            get
            {
                return 1;
            }
        }

        public int PluginType
        {
            get
            {
                return 1;
            }
        }
    }
}

