namespace Encog.Neural.Flat.Train.Prop
{
    using Encog;
    using Encog.Engine.Network.Activation;
    using Encog.MathUtil;
    using Encog.ML.Data;
    using Encog.Neural.Error;
    using Encog.Neural.Flat;
    using Encog.Neural.Flat.Train;
    using Encog.Util;
    using Encog.Util.Concurrency;
    using System;
    using System.Runtime.CompilerServices;

    public abstract class TrainFlatNetworkProp : ITrainFlatNetwork
    {
        private double _x0093bfd92e5498b1;
        private double[] _x0ba854627e1326f9;
        private readonly double[] _x135f4ca6b0437cfc;
        private int _x47b4ed2c32cb276e;
        private readonly IMLDataSet _x823a2b9c8bf459c5;
        private readonly FlatNetwork _x87a7fc6a72741c2e;
        private readonly IMLDataSet _x9d091b0a73271a88;
        private GradientWorker[] _xb542b50e13b3ecac;
        private Exception _xb8f73f2bca8b57ea;
        private int _xc2715388adc0d1f8;
        protected internal double CurrentError;
        protected internal double[] Gradients;
        [CompilerGenerated]
        private bool x79652992a2d90101;
        [CompilerGenerated]
        private IErrorFunction xaf762aa7e66c5f0c;

        protected TrainFlatNetworkProp(FlatNetwork network, IMLDataSet training)
        {
        Label_0036:
            this._x823a2b9c8bf459c5 = training;
            if (0x7fffffff != 0)
            {
                this._x87a7fc6a72741c2e = network;
                this.Gradients = new double[this._x87a7fc6a72741c2e.Weights.Length];
            }
            this._x135f4ca6b0437cfc = new double[this._x87a7fc6a72741c2e.Weights.Length];
            if (4 != 0)
            {
                this._x9d091b0a73271a88 = training;
                this._xc2715388adc0d1f8 = 0;
                this._xb8f73f2bca8b57ea = null;
                this.FixFlatSpot = true;
                this.ErrorFunction = new LinearErrorFunction();
                if (0xff == 0)
                {
                    goto Label_0036;
                }
            }
        }

        public virtual void CalculateGradients()
        {
            int num;
            if (this._xb542b50e13b3ecac != null)
            {
                goto Label_00B9;
            }
            goto Label_00B3;
        Label_002A:
            this.CurrentError = this._x0093bfd92e5498b1 / ((double) this._xb542b50e13b3ecac.Length);
            return;
        Label_00B3:
            this.xd586e0c16bdae7fc();
        Label_00B9:
            if (this._x87a7fc6a72741c2e.HasContext)
            {
                this._xb542b50e13b3ecac[0].Network.ClearContext();
            }
            this._x0093bfd92e5498b1 = 0.0;
            if ((((uint) num) & 0) != 0)
            {
                goto Label_00B9;
            }
        Label_0012:
            if (this._xb542b50e13b3ecac.Length > 1)
            {
                TaskGroup group = EngineConcurrency.Instance.CreateTaskGroup();
                GradientWorker[] workerArray = this._xb542b50e13b3ecac;
                num = 0;
                while (num < workerArray.Length)
                {
                    GradientWorker task = workerArray[num];
                    EngineConcurrency.Instance.ProcessTask(task, group);
                    num++;
                }
                if ((((uint) num) - ((uint) num)) >= 0)
                {
                    if (0x7fffffff == 0)
                    {
                        goto Label_0012;
                    }
                    if (4 == 0)
                    {
                        return;
                    }
                    group.WaitForComplete();
                    if (0 == 0)
                    {
                        goto Label_002A;
                    }
                }
                else
                {
                    goto Label_002A;
                }
                goto Label_00B3;
            }
            this._xb542b50e13b3ecac[0].Run();
            goto Label_002A;
        }

        public virtual void FinishTraining()
        {
        }

        public abstract void InitOthers();
        public virtual void Iteration()
        {
            GradientWorker[] workerArray;
            int num;
            this._x47b4ed2c32cb276e++;
            this.CalculateGradients();
            if (this._x87a7fc6a72741c2e.Limited)
            {
                this.LearnLimited();
                goto Label_00A9;
            }
            this.Learn();
            if (((uint) num) >= 0)
            {
                if (0 == 0)
                {
                }
                goto Label_00A9;
            }
        Label_009C:
            num = 0;
            while (num < workerArray.Length)
            {
                GradientWorker worker = workerArray[num];
                EngineArray.ArrayCopy(this._x87a7fc6a72741c2e.Weights, 0, worker.Weights, 0, this._x87a7fc6a72741c2e.Weights.Length);
                num++;
            }
            if ((1 == 0) || this._x87a7fc6a72741c2e.HasContext)
            {
                this.x9e4a53e1bba49db4();
                if ((((uint) num) + ((uint) num)) < 0)
                {
                }
            }
            if (this._xb8f73f2bca8b57ea != null)
            {
                throw new EncogError(this._xb8f73f2bca8b57ea);
            }
            return;
        Label_00A9:
            workerArray = this._xb542b50e13b3ecac;
            goto Label_009C;
        }

        public void Iteration(int count)
        {
            for (int i = 0; i < count; i++)
            {
                this.Iteration();
            }
        }

        protected internal void Learn()
        {
            double[] weights = this._x87a7fc6a72741c2e.Weights;
            int index = 0;
            if (((uint) index) >= 0)
            {
                if (((uint) index) <= uint.MaxValue)
                {
                    goto Label_005D;
                }
            }
            else
            {
                return;
            }
        Label_0022:
            weights[index] += this.UpdateWeight(this.Gradients, this._x135f4ca6b0437cfc, index);
            this.Gradients[index] = 0.0;
            index++;
        Label_005D:
            if (index < this.Gradients.Length)
            {
                goto Label_0022;
            }
        }

        protected internal void LearnLimited()
        {
            double connectionLimit = this._x87a7fc6a72741c2e.ConnectionLimit;
            double[] weights = this._x87a7fc6a72741c2e.Weights;
            int index = 0;
        Label_0011:
            if (index < this.Gradients.Length)
            {
                if (Math.Abs(weights[index]) >= connectionLimit)
                {
                    weights[index] += this.UpdateWeight(this.Gradients, this._x135f4ca6b0437cfc, index);
                    if ((((uint) connectionLimit) & 0) == 0)
                    {
                        goto Label_0035;
                    }
                }
                weights[index] = 0.0;
            }
            else
            {
                return;
            }
        Label_0035:
            this.Gradients[index] = 0.0;
            index++;
            goto Label_0011;
        }

        public void Report(double[] gradients, double error, Exception ex)
        {
            lock (this)
            {
                int num;
                if (ex != null)
                {
                    goto Label_003A;
                }
                if (0xff != 0)
                {
                    goto Label_0059;
                }
            Label_0012:
                if ((((uint) error) + ((uint) error)) > uint.MaxValue)
                {
                    goto Label_007C;
                }
                this._x0093bfd92e5498b1 += error;
                goto Label_0090;
            Label_003A:
                this._xb8f73f2bca8b57ea = ex;
                if ((((uint) error) - ((uint) num)) >= 0)
                {
                    goto Label_0090;
                }
            Label_0059:
                num = 0;
            Label_007C:
                while (num < gradients.Length)
                {
                    this.Gradients[num] += gradients[num];
                    num++;
                }
                goto Label_0012;
            Label_0090:;
            }
        }

        public abstract double UpdateWeight(double[] gradients, double[] lastGradient, int index);
        private void x9e4a53e1bba49db4()
        {
            double[] numArray;
            int index = 0;
            if ((((uint) index) - ((uint) index)) <= uint.MaxValue)
            {
                goto Label_0083;
            }
        Label_004D:
            numArray = this._xb542b50e13b3ecac[index].Network.LayerOutput;
            if (0 == 0)
            {
            }
            double[] layerOutput = this._xb542b50e13b3ecac[index + 1].Network.LayerOutput;
            EngineArray.ArrayCopy(numArray, layerOutput);
            index++;
        Label_0083:
            if (index >= (this._xb542b50e13b3ecac.Length - 1))
            {
                EngineArray.ArrayCopy(this._xb542b50e13b3ecac[this._xb542b50e13b3ecac.Length - 1].Network.LayerOutput, this._x87a7fc6a72741c2e.LayerOutput);
                if (0 == 0)
                {
                    return;
                }
            }
            goto Label_004D;
        }

        private void xd586e0c16bdae7fc()
        {
            IActivationFunction function;
            DetermineWorkload workload;
            int num2;
            this._x0ba854627e1326f9 = new double[this._x87a7fc6a72741c2e.ActivationFunctions.Length];
            if (!this.FixFlatSpot)
            {
                EngineArray.Fill(this._x0ba854627e1326f9, (double) 0.0);
                goto Label_0045;
            }
            int index = 0;
            if ((((uint) num2) - ((uint) num2)) >= 0)
            {
                goto Label_012E;
            }
            goto Label_014D;
        Label_001D:
            this.InitOthers();
            if (8 != 0)
            {
                return;
            }
        Label_0045:
            workload = new DetermineWorkload(this._xc2715388adc0d1f8, (int) this._x9d091b0a73271a88.Count);
            this._xb542b50e13b3ecac = new GradientWorker[workload.ThreadCount];
            num2 = 0;
            foreach (IntRange range in workload.CalculateWorkers())
            {
                this._xb542b50e13b3ecac[num2++] = new GradientWorker((FlatNetwork) this._x87a7fc6a72741c2e.Clone(), this, this._x9d091b0a73271a88.OpenAdditional(), range.Low, range.High, this._x0ba854627e1326f9, this.ErrorFunction);
            }
            goto Label_001D;
            if ((((uint) index) + ((uint) index)) <= uint.MaxValue)
            {
                goto Label_001D;
            }
        Label_0101:
            this._x0ba854627e1326f9[index] = 0.0;
            if ((((uint) index) - ((uint) num2)) < 0)
            {
                if ((((uint) num2) + ((uint) index)) > uint.MaxValue)
                {
                    goto Label_014D;
                }
                goto Label_0101;
            }
        Label_012A:
            index++;
        Label_012E:
            if (index < this._x87a7fc6a72741c2e.ActivationFunctions.Length)
            {
                function = this._x87a7fc6a72741c2e.ActivationFunctions[index];
            }
            else
            {
                goto Label_0045;
            }
        Label_014D:
            if (function is ActivationSigmoid)
            {
                this._x0ba854627e1326f9[index] = 0.1;
                goto Label_012A;
            }
            goto Label_0101;
        }

        public double Error
        {
            get
            {
                return this.CurrentError;
            }
        }

        public IErrorFunction ErrorFunction
        {
            [CompilerGenerated]
            get
            {
                return this.xaf762aa7e66c5f0c;
            }
            [CompilerGenerated]
            set
            {
                this.xaf762aa7e66c5f0c = value;
            }
        }

        public bool FixFlatSpot
        {
            [CompilerGenerated]
            get
            {
                return this.x79652992a2d90101;
            }
            [CompilerGenerated]
            set
            {
                this.x79652992a2d90101 = value;
            }
        }

        public int IterationNumber
        {
            get
            {
                return this._x47b4ed2c32cb276e;
            }
            set
            {
                this._x47b4ed2c32cb276e = value;
            }
        }

        public double[] LastGradient
        {
            get
            {
                return this._x135f4ca6b0437cfc;
            }
        }

        public FlatNetwork Network
        {
            get
            {
                return this._x87a7fc6a72741c2e;
            }
        }

        public int NumThreads
        {
            get
            {
                return this._xc2715388adc0d1f8;
            }
            set
            {
                this._xc2715388adc0d1f8 = value;
            }
        }

        public IMLDataSet Training
        {
            get
            {
                return this._x823a2b9c8bf459c5;
            }
        }
    }
}

