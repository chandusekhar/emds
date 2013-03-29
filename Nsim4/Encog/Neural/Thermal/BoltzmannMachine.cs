namespace Encog.Neural.Thermal
{
    using Encog.MathUtil;
    using Encog.MathUtil.Randomize;
    using Encog.ML.Data;
    using Encog.ML.Data.Specific;
    using Encog.Util;
    using System;

    [Serializable]
    public class BoltzmannMachine : ThermalNetwork
    {
        private int _annealCycles;
        [NonSerialized]
        private int[] _off;
        [NonSerialized]
        private int[] _on;
        private int _runCycles;
        private double _temperature;
        private double[] _threshold;
        public const string ParamAnnealCycles = "annealCycles";
        public const string ParamRunCycles = "runCycles";

        public BoltzmannMachine()
        {
            this._annealCycles = 100;
            this._runCycles = 0x3e8;
        }

        public BoltzmannMachine(int neuronCount) : base(neuronCount)
        {
            this._annealCycles = 100;
            this._runCycles = 0x3e8;
            this._threshold = new double[neuronCount];
        }

        public sealed override IMLData Compute(IMLData input)
        {
            BiPolarMLData data = new BiPolarMLData(input.Count);
            EngineArray.ArrayCopy(input.Data, base.CurrentState.Data);
            this.Run();
            EngineArray.ArrayCopy(base.CurrentState.Data, data.Data);
            return data;
        }

        public void DecreaseTemperature(double d)
        {
            this._temperature *= d;
        }

        public void EstablishEquilibrium()
        {
            int num2;
            int num3;
            int num5;
            int num6;
            int neuronCount = base.NeuronCount;
            goto Label_0191;
        Label_001C:
            base.CurrentState.SetBoolean(num6, this._on[num6] > this._off[num6]);
            num6++;
        Label_0043:
            if (num6 < neuronCount)
            {
                goto Label_001C;
            }
            return;
        Label_010E:
            while (num3 < (this._runCycles * neuronCount))
            {
                this.Run((int) RangeRandomizer.Randomize(0.0, (double) (neuronCount - 1)));
                num3++;
            }
            int num4 = 0;
        Label_000C:
            if (num4 < (this._annealCycles * neuronCount))
            {
                num5 = (int) RangeRandomizer.Randomize(0.0, (double) (neuronCount - 1));
                this.Run(num5);
                if (!base.CurrentState.GetBoolean(num5))
                {
                    this._off[num5]++;
                }
                else
                {
                    this._on[num5]++;
                }
                num4++;
                if ((((uint) num6) + ((uint) num4)) < 0)
                {
                    goto Label_0134;
                }
                if ((((uint) neuronCount) + ((uint) num2)) >= 0)
                {
                    goto Label_000C;
                }
                goto Label_010E;
            }
            num6 = 0;
            goto Label_0043;
        Label_0120:
            num3 = 0;
            goto Label_010E;
        Label_012B:
            if (num2 < neuronCount)
            {
                this._on[num2] = 0;
                if ((((uint) neuronCount) + ((uint) num6)) < 0)
                {
                    goto Label_001C;
                }
                this._off[num2] = 0;
                if (((uint) neuronCount) <= uint.MaxValue)
                {
                    if ((((uint) num2) + ((uint) num2)) <= uint.MaxValue)
                    {
                        goto Label_01FA;
                    }
                    goto Label_0191;
                }
            }
            else
            {
                goto Label_0120;
            }
        Label_0134:
            if ((((uint) num5) - ((uint) neuronCount)) < 0)
            {
                goto Label_0191;
            }
        Label_014C:
            num2 = 0;
            goto Label_012B;
        Label_0191:
            if (this._on == null)
            {
                this._on = new int[neuronCount];
                this._off = new int[neuronCount];
                if ((((uint) num3) - ((uint) num4)) <= uint.MaxValue)
                {
                    goto Label_0134;
                }
            }
            else
            {
                if (((uint) num3) < 0)
                {
                    goto Label_0043;
                }
                goto Label_014C;
            }
        Label_01FA:
            if ((((uint) neuronCount) | 2) != 0)
            {
                num2++;
                goto Label_012B;
            }
            goto Label_0120;
        }

        public void Run()
        {
            int num2;
            int neuronCount = base.NeuronCount;
            if (((uint) num2) >= 0)
            {
            }
            for (num2 = 0; num2 < neuronCount; num2++)
            {
                this.Run(num2);
            }
        }

        public void Run(int i)
        {
            int neuronCount = base.NeuronCount;
            double num3 = 0.0;
            int toNeuron = 0;
            while (true)
            {
                if (toNeuron < neuronCount)
                {
                    num3 += base.GetWeight(i, toNeuron) * (base.CurrentState.GetBoolean(toNeuron) ? ((double) 1) : ((double) 0));
                }
                else
                {
                    num3 -= this._threshold[i];
                    double num4 = 1.0 / (1.0 + BoundMath.Exp(-num3 / this._temperature));
                    base.CurrentState.SetBoolean(i, RangeRandomizer.Randomize(0.0, 1.0) <= num4);
                    return;
                }
                toNeuron++;
            }
        }

        public override void UpdateProperties()
        {
        }

        public int AnnealCycles
        {
            get
            {
                return this._annealCycles;
            }
            set
            {
                this._annealCycles = value;
            }
        }

        public override int InputCount
        {
            get
            {
                return base.NeuronCount;
            }
        }

        public override int OutputCount
        {
            get
            {
                return base.NeuronCount;
            }
        }

        public int RunCycles
        {
            get
            {
                return this._runCycles;
            }
            set
            {
                this._runCycles = value;
            }
        }

        public double Temperature
        {
            get
            {
                return this._temperature;
            }
            set
            {
                this._temperature = value;
            }
        }

        public double[] Threshold
        {
            get
            {
                return this._threshold;
            }
            set
            {
                this._threshold = value;
            }
        }
    }
}

