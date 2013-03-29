namespace Encog.Neural.CPN.Training
{
    using Encog.MathUtil.Error;
    using Encog.ML;
    using Encog.ML.Data;
    using Encog.ML.Train;
    using Encog.Neural.CPN;
    using Encog.Neural.Networks.Training;
    using Encog.Neural.Networks.Training.Propagation;
    using Encog.Util;
    using System;
    using System.Collections.Generic;

    public class TrainOutstar : BasicTraining, ILearningRate
    {
        private bool _x268cb8b20222b0dc;
        private readonly IMLDataSet _x823a2b9c8bf459c5;
        private readonly CPNNetwork _x87a7fc6a72741c2e;
        private double _x9b481c22b6706459;

        public TrainOutstar(CPNNetwork theNetwork, IMLDataSet theTraining, double theLearningRate) : base(TrainingImplementationType.Iterative)
        {
            this._x268cb8b20222b0dc = true;
            this._x87a7fc6a72741c2e = theNetwork;
            this._x823a2b9c8bf459c5 = theTraining;
            this._x9b481c22b6706459 = theLearningRate;
        }

        public sealed override void Iteration()
        {
            if (this._x268cb8b20222b0dc)
            {
                this.xabfa4e7d76a2422c();
            }
            ErrorCalculation calculation = new ErrorCalculation();
            using (IEnumerator<IMLDataPair> enumerator = this._x823a2b9c8bf459c5.GetEnumerator())
            {
                IMLDataPair pair;
                IMLData data;
                int num;
                int num2;
                double num3;
                IMLData data2;
                goto Label_005E;
            Label_0023:
                if (num2 < this._x87a7fc6a72741c2e.OutstarCount)
                {
                    goto Label_0091;
                }
            Label_0032:
                data2 = this._x87a7fc6a72741c2e.ComputeOutstar(data);
                calculation.UpdateError(data2.Data, pair.Ideal.Data, pair.Significance);
            Label_005E:
                if (!enumerator.MoveNext() && ((((uint) num2) - ((uint) num3)) <= uint.MaxValue))
                {
                    goto Label_014D;
                }
                goto Label_00D2;
            Label_0084:
                num2++;
                goto Label_0124;
            Label_0091:
                num3 = this._x9b481c22b6706459 * (pair.Ideal[num2] - this._x87a7fc6a72741c2e.WeightsInstarToOutstar[num, num2]);
                this._x87a7fc6a72741c2e.WeightsInstarToOutstar.Add(num, num2, num3);
                goto Label_0084;
            Label_00D2:
                pair = enumerator.Current;
                data = this._x87a7fc6a72741c2e.ComputeInstar(pair.Input);
                num = EngineArray.IndexOfLargest(data.Data);
                num2 = 0;
                if ((((uint) num2) <= uint.MaxValue) && (-2 == 0))
                {
                    goto Label_0032;
                }
                goto Label_0023;
            Label_0124:
                if ((((uint) num) - ((uint) num)) <= uint.MaxValue)
                {
                    goto Label_0023;
                }
            }
        Label_014D:
            this.Error = calculation.Calculate();
        }

        public sealed override TrainingContinuation Pause()
        {
            return null;
        }

        public sealed override void Resume(TrainingContinuation state)
        {
        }

        private void xabfa4e7d76a2422c()
        {
            int num = 0;
        Label_0004:
            if (num >= this._x87a7fc6a72741c2e.OutstarCount)
            {
                this._x268cb8b20222b0dc = false;
            }
            else
            {
                int num2 = 0;
                foreach (IMLDataPair pair in this._x823a2b9c8bf459c5)
                {
                    this._x87a7fc6a72741c2e.WeightsInstarToOutstar[num2++, num] = pair.Ideal[num];
                }
                num++;
                goto Label_0004;
            }
        }

        public sealed override bool CanContinue
        {
            get
            {
                return false;
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
                return this._x87a7fc6a72741c2e;
            }
        }
    }
}

