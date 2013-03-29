namespace Encog.Neural.SOM.Training.Neighborhood
{
    using Encog.MathUtil.Matrices;
    using Encog.ML;
    using Encog.ML.Data;
    using Encog.ML.Train;
    using Encog.Neural.Networks.Training;
    using Encog.Neural.Networks.Training.Propagation;
    using Encog.Neural.SOM;
    using Encog.Util;
    using Encog.Util.Logging;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class BasicTrainSOM : BasicTraining, ILearningRate
    {
        private readonly int _x0c37ff3adde9bc44;
        private double _x0fa028df803f40aa;
        private readonly INeighborhoodFunction _x3d0ce91dbd8e0b1b;
        private readonly Matrix _x42cc0dadfb982948;
        private readonly int _x57202a8751db8895;
        private double _x64078ba09fb4e08b;
        private readonly BestMatchingUnit _x703660d5c67ed8fb;
        private readonly SOMNetwork _x87a7fc6a72741c2e;
        private double _x9330e733dda6ae99;
        private double _x9689b2bdc6624bf2;
        private double _x9b481c22b6706459;
        private double _x9f14b09b934a6c82;
        private double _xbac0161d6380288b;
        private double _xd6ed827fa7f40115;
        private bool _xf7c1f63ae5cd87f7;

        public BasicTrainSOM(SOMNetwork network, double learningRate, IMLDataSet training, INeighborhoodFunction neighborhood) : base(TrainingImplementationType.Iterative)
        {
            this._x3d0ce91dbd8e0b1b = neighborhood;
            while (true)
            {
                this.Training = training;
                while (0 == 0)
                {
                    this._x9b481c22b6706459 = learningRate;
                    this._x87a7fc6a72741c2e = network;
                    this._x57202a8751db8895 = network.InputCount;
                    this._x0c37ff3adde9bc44 = network.OutputCount;
                    this._xf7c1f63ae5cd87f7 = false;
                    this.Error = 0.0;
                    this._x42cc0dadfb982948 = new Matrix(this._x57202a8751db8895, this._x0c37ff3adde9bc44);
                    this._x703660d5c67ed8fb = new BestMatchingUnit(network);
                    if (0 == 0)
                    {
                        return;
                    }
                }
            }
        }

        public void AutoDecay()
        {
            if (this._xd6ed827fa7f40115 > this._xbac0161d6380288b)
            {
                this._xd6ed827fa7f40115 += this._x0fa028df803f40aa;
            }
            while (this._x9b481c22b6706459 > this._x64078ba09fb4e08b)
            {
                this._x9b481c22b6706459 += this._x9f14b09b934a6c82;
                if (2 != 0)
                {
                    goto Label_0010;
                }
            }
            if (0 != 0)
            {
                return;
            }
        Label_0010:
            this.Neighborhood.Radius = this._xd6ed827fa7f40115;
        }

        public void Decay(double d)
        {
            this._xd6ed827fa7f40115 *= 1.0 - d;
            this._x9b481c22b6706459 *= 1.0 - d;
        }

        public void Decay(double decayRate, double decayRadius)
        {
            this._xd6ed827fa7f40115 *= 1.0 - decayRadius;
            this._x9b481c22b6706459 *= 1.0 - decayRate;
            this.Neighborhood.Radius = this._xd6ed827fa7f40115;
        }

        public sealed override void Iteration()
        {
            int[] numArray;
            double maxValue;
            EncogLogging.Log(1, "Performing SOM Training iteration.");
            if ((((uint) maxValue) + ((uint) maxValue)) >= 0)
            {
                base.PreIteration();
                this._x703660d5c67ed8fb.Reset();
                numArray = new int[this._x0c37ff3adde9bc44];
                maxValue = double.MaxValue;
            }
            IMLData input = null;
            this._x42cc0dadfb982948.Clear();
            using (IEnumerator<IMLDataPair> enumerator = this.Training.GetEnumerator())
            {
                IMLDataPair pair;
                IMLData data2;
                int num2;
                IMLData data3;
                goto Label_006A;
            Label_0042:
                if (this._xf7c1f63ae5cd87f7)
                {
                    goto Label_00AF;
                }
                goto Label_0064;
            Label_004C:
                if ((((uint) maxValue) - ((uint) maxValue)) < 0)
                {
                    goto Label_0042;
                }
            Label_0064:
                this.x350499392b8d9d27();
            Label_006A:
                if (enumerator.MoveNext())
                {
                    goto Label_0152;
                }
                goto Label_01AD;
            Label_0078:
                this.x350499392b8d9d27();
                goto Label_006A;
            Label_0089:
                if (data3[num2] < maxValue)
                {
                    goto Label_00DF;
                }
            Label_0095:
                this.x1441044d30b77751(num2, this._x87a7fc6a72741c2e.Weights, data2);
                goto Label_0042;
            Label_00AF:
                if (this.x77dc8b40d5dfd791(this._x87a7fc6a72741c2e.Weights, numArray, input))
                {
                    goto Label_006A;
                }
                if ((((uint) maxValue) + ((uint) maxValue)) >= 0)
                {
                    goto Label_0103;
                }
                if (0 != 0)
                {
                    goto Label_011B;
                }
            Label_00DF:
                maxValue = data3[num2];
                input = pair.Input;
                if (-2147483648 != 0)
                {
                }
                goto Label_0095;
            Label_0103:
                if ((((uint) maxValue) + ((uint) maxValue)) <= uint.MaxValue)
                {
                    goto Label_0078;
                }
            Label_011B:
                if (0 != 0)
                {
                    goto Label_004C;
                }
                numArray[num2]++;
                data3 = this._x87a7fc6a72741c2e.Compute(pair.Input);
                if (-2 != 0)
                {
                    goto Label_0089;
                }
                goto Label_0078;
            Label_0152:
                pair = enumerator.Current;
                data2 = pair.Input;
                num2 = this._x703660d5c67ed8fb.CalculateBMU(data2);
                if (!this._xf7c1f63ae5cd87f7)
                {
                    goto Label_0095;
                }
                if ((((uint) maxValue) - ((uint) num2)) <= uint.MaxValue)
                {
                    goto Label_011B;
                }
                goto Label_0078;
            }
            if (0 == 0)
            {
            }
        Label_01AD:
            this.Error = this._x703660d5c67ed8fb.WorstDistance / 100.0;
            base.PostIteration();
        }

        public sealed override TrainingContinuation Pause()
        {
            return null;
        }

        public override void Resume(TrainingContinuation state)
        {
        }

        public void SetAutoDecay(int plannedIterations, double startRate, double endRate, double startRadius, double endRadius)
        {
            this._x9330e733dda6ae99 = startRate;
            this._x64078ba09fb4e08b = endRate;
            if (0 == 0)
            {
                this._x9689b2bdc6624bf2 = startRadius;
                this._xbac0161d6380288b = endRadius;
                this._x0fa028df803f40aa = (endRadius - startRadius) / ((double) plannedIterations);
            }
            this._x9f14b09b934a6c82 = (endRate - startRate) / ((double) plannedIterations);
            this.SetParams(this._x9330e733dda6ae99, this._x9689b2bdc6624bf2);
        }

        public void SetParams(double rate, double radius)
        {
            this._xd6ed827fa7f40115 = radius;
            this._x9b481c22b6706459 = rate;
            this.Neighborhood.Radius = radius;
        }

        public sealed override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Rate=");
            builder.Append(Format.FormatPercent(this._x9b481c22b6706459));
            builder.Append(", Radius=");
            builder.Append(Format.FormatDouble(this._xd6ed827fa7f40115, 2));
            return builder.ToString();
        }

        public void TrainPattern(IMLData pattern)
        {
            IMLData input = pattern;
            int num = this._x703660d5c67ed8fb.CalculateBMU(input);
            this.x1441044d30b77751(num, this._x87a7fc6a72741c2e.Weights, input);
            this.x350499392b8d9d27();
        }

        private void x1441044d30b77751(int x05e293912078bf73, Matrix xa801ccff44b0c7eb, IMLData xcdaeea7afaf570ff)
        {
            for (int i = 0; i < this._x0c37ff3adde9bc44; i++)
            {
                this.x540182a378d29425(xa801ccff44b0c7eb, xcdaeea7afaf570ff, i, x05e293912078bf73);
            }
        }

        private void x3342cd5bc15ae07b(Matrix xa801ccff44b0c7eb, int x7079b5ea66d0bae1, IMLData xcdaeea7afaf570ff)
        {
            for (int i = 0; i < this._x57202a8751db8895; i++)
            {
                xa801ccff44b0c7eb[i, x7079b5ea66d0bae1] = xcdaeea7afaf570ff[i];
            }
        }

        private void x350499392b8d9d27()
        {
            this._x87a7fc6a72741c2e.Weights.Set(this._x42cc0dadfb982948);
        }

        private void x540182a378d29425(Matrix xa801ccff44b0c7eb, IMLData xcdaeea7afaf570ff, int x3bd62873fafa6252, int x05e293912078bf73)
        {
            int num = 0;
            while (true)
            {
                double num3;
                double num4;
                while (num >= this._x57202a8751db8895)
                {
                    if ((((uint) num3) + ((uint) num4)) >= 0)
                    {
                        return;
                    }
                }
                double num2 = xa801ccff44b0c7eb[num, x3bd62873fafa6252];
                if ((((uint) num3) + ((uint) num)) <= uint.MaxValue)
                {
                    num3 = xcdaeea7afaf570ff[num];
                    num4 = this.xa87d489014b43b21(num2, num3, x3bd62873fafa6252, x05e293912078bf73);
                }
                this._x42cc0dadfb982948[num, x3bd62873fafa6252] = num4;
                num++;
            }
        }

        private bool x77dc8b40d5dfd791(Matrix xa801ccff44b0c7eb, int[] x8ec2c78c1f2042c8, IMLData x418556cba16510d4)
        {
            int num2;
            IMLData data;
            int num3;
            double minValue = double.MinValue;
            goto Label_00A9;
        Label_000F:
            if (num3 < x8ec2c78c1f2042c8.Length)
            {
                if (x8ec2c78c1f2042c8[num3] != 0)
                {
                    goto Label_002C;
                }
                goto Label_0048;
            }
            if (num2 == -1)
            {
                return false;
            }
            this.x3342cd5bc15ae07b(xa801ccff44b0c7eb, num2, x418556cba16510d4);
            return true;
        Label_002C:
            num3++;
            if ((((uint) num2) + ((uint) minValue)) <= uint.MaxValue)
            {
                goto Label_0091;
            }
        Label_0048:
            if (num2 != -1)
            {
                if ((((uint) num3) | 1) == 0)
                {
                    goto Label_0048;
                }
                if (data[num3] <= minValue)
                {
                    goto Label_002C;
                }
                if (1 == 0)
                {
                    goto Label_000F;
                }
            }
            minValue = data[num3];
            if ((((uint) num3) & 0) == 0)
            {
                num2 = num3;
                goto Label_002C;
            }
        Label_0091:
            if ((((uint) minValue) + ((uint) num3)) <= uint.MaxValue)
            {
                goto Label_000F;
            }
        Label_00A9:
            num2 = -1;
            data = this._x87a7fc6a72741c2e.Compute(x418556cba16510d4);
            num3 = 0;
            goto Label_000F;
        }

        private double xa87d489014b43b21(double x088735608d2b15df, double xcdaeea7afaf570ff, int xdfdd4c581c22a0f5, int x05e293912078bf73)
        {
            return (x088735608d2b15df + ((this._x3d0ce91dbd8e0b1b.Function(xdfdd4c581c22a0f5, x05e293912078bf73) * this._x9b481c22b6706459) * (xcdaeea7afaf570ff - x088735608d2b15df)));
        }

        public sealed override bool CanContinue
        {
            get
            {
                return false;
            }
        }

        public bool ForceWinner
        {
            get
            {
                return this._xf7c1f63ae5cd87f7;
            }
            set
            {
                this._xf7c1f63ae5cd87f7 = value;
            }
        }

        public int InputNeuronCount
        {
            get
            {
                return this._x57202a8751db8895;
            }
        }

        public double LearningRate
        {
            get
            {
                return this._x9b481c22b6706459;
            }
            set
            {
                this._x9b481c22b6706459 = value;
            }
        }

        public override IMLMethod Method
        {
            get
            {
                return null;
            }
        }

        public INeighborhoodFunction Neighborhood
        {
            get
            {
                return this._x3d0ce91dbd8e0b1b;
            }
        }

        public int OutputNeuronCount
        {
            get
            {
                return this._x0c37ff3adde9bc44;
            }
        }
    }
}

