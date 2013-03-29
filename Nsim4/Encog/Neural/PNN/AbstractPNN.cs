namespace Encog.Neural.PNN
{
    using Encog.ML;
    using Encog.ML.Data;
    using System;
    using System.Runtime.CompilerServices;

    [Serializable]
    public abstract class AbstractPNN : BasicML
    {
        private int[] _confusion;
        private readonly double[] _deriv;
        private readonly double[] _deriv2;
        private readonly int _inputCount;
        private readonly PNNKernelType _kernel;
        private readonly int _outputCount;
        private readonly PNNOutputMode _outputMode;

        protected AbstractPNN(PNNKernelType kernel, PNNOutputMode outputMode, int inputCount, int outputCount)
        {
            while ((((uint) inputCount) + ((uint) inputCount)) >= 0)
            {
                this._kernel = kernel;
                this._outputMode = outputMode;
                this._inputCount = inputCount;
                if (((uint) inputCount) < 0)
                {
                    goto Label_0020;
                }
                this._outputCount = outputCount;
                this.Trained = false;
                this.Error = double.MinValue;
                if (0 == 0)
                {
                    this._confusion = null;
                    goto Label_006C;
                }
            }
            return;
        Label_0020:
            if (((((uint) inputCount) | 0xfffffffe) != 0) && (((uint) inputCount) >= 0))
            {
                if ((((uint) outputCount) & 0) == 0)
                {
                    return;
                }
                goto Label_006C;
            }
        Label_0038:
            if (this._outputMode == PNNOutputMode.Classification)
            {
                this._confusion = new int[this._outputCount + 1];
                goto Label_0020;
            }
            return;
        Label_006C:
            this.Exclude = -1;
            this._deriv = new double[inputCount];
            this._deriv2 = new double[inputCount];
            goto Label_0038;
        }

        public abstract IMLData Compute(IMLData input);
        public void ResetConfusion()
        {
        }

        public double[] Deriv
        {
            get
            {
                return this._deriv;
            }
        }

        public double[] Deriv2
        {
            get
            {
                return this._deriv2;
            }
        }

        public double Error { get; set; }

        public int Exclude { get; set; }

        public int InputCount
        {
            get
            {
                return this._inputCount;
            }
        }

        public PNNKernelType Kernel
        {
            get
            {
                return this._kernel;
            }
        }

        public int OutputCount
        {
            get
            {
                return this._outputCount;
            }
        }

        public PNNOutputMode OutputMode
        {
            get
            {
                return this._outputMode;
            }
        }

        public bool SeparateClass { get; set; }

        public bool Trained { get; set; }
    }
}

