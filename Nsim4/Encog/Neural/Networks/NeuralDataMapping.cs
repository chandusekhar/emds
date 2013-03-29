namespace Encog.Neural.Networks
{
    using Encog.ML.Data;
    using System;
    using System.Runtime.CompilerServices;

    public class NeuralDataMapping
    {
        [CompilerGenerated]
        private IMLData xab0af4cd6a495db4;
        [CompilerGenerated]
        private IMLData xdcedd83c8d028ba5;

        public NeuralDataMapping()
        {
            this.From = null;
            this.To = null;
        }

        public NeuralDataMapping(IMLData f, IMLData t)
        {
            this.From = f;
            this.To = t;
        }

        public static void Copy(NeuralDataMapping source, NeuralDataMapping target)
        {
            int num = 0;
            while (true)
            {
                if (num >= source.From.Count)
                {
                    for (int i = 0; i < source.To.Count; i++)
                    {
                        target.To[i] = source.To[i];
                    }
                    if ((((uint) num) - ((uint) num)) >= 0)
                    {
                        return;
                    }
                }
                else
                {
                    target.From[num] = source.From[num];
                }
                num++;
            }
        }

        public IMLData From
        {
            [CompilerGenerated]
            get
            {
                return this.xab0af4cd6a495db4;
            }
            [CompilerGenerated]
            set
            {
                this.xab0af4cd6a495db4 = value;
            }
        }

        public IMLData To
        {
            [CompilerGenerated]
            get
            {
                return this.xdcedd83c8d028ba5;
            }
            [CompilerGenerated]
            set
            {
                this.xdcedd83c8d028ba5 = value;
            }
        }
    }
}

