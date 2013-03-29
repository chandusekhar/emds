namespace Encog.Neural.Networks.Training.Simple
{
    using Encog.MathUtil.Error;
    using Encog.ML;
    using Encog.ML.Data;
    using Encog.ML.Train;
    using Encog.Neural;
    using Encog.Neural.Networks;
    using Encog.Neural.Networks.Training;
    using Encog.Neural.Networks.Training.Propagation;
    using System;
    using System.Collections.Generic;

    public class TrainAdaline : BasicTraining, ILearningRate
    {
        private readonly IMLDataSet _x823a2b9c8bf459c5;
        private readonly BasicNetwork _x87a7fc6a72741c2e;
        private double _x9b481c22b6706459;

        public TrainAdaline(BasicNetwork network, IMLDataSet training, double learningRate) : base(TrainingImplementationType.Iterative)
        {
            if (((uint) learningRate) > uint.MaxValue)
            {
                goto Label_003B;
            }
        Label_0009:
            if (network.LayerCount > 2)
            {
                goto Label_003B;
            }
        Label_0012:
            this._x87a7fc6a72741c2e = network;
            this._x823a2b9c8bf459c5 = training;
            this._x9b481c22b6706459 = learningRate;
            return;
        Label_003B:
            throw new NeuralNetworkError("An ADALINE network only has two layers.");
            if (0x7fffffff == 0)
            {
                goto Label_0009;
            }
            goto Label_0012;
        }

        public sealed override void Iteration()
        {
            ErrorCalculation calculation = new ErrorCalculation();
            using (IEnumerator<IMLDataPair> enumerator = this._x823a2b9c8bf459c5.GetEnumerator())
            {
                IMLDataPair pair;
                IMLData data;
                int num;
                double num2;
                int num3;
                double num4;
                goto Label_0032;
            Label_0015:
                calculation.UpdateError(data.Data, pair.Ideal.Data, pair.Significance);
            Label_0032:
                if (enumerator.MoveNext())
                {
                    goto Label_010B;
                }
                if ((((uint) num2) - ((uint) num2)) > uint.MaxValue)
                {
                    goto Label_0071;
                }
                goto Label_0151;
            Label_0058:
                num3++;
            Label_005E:
                if (num3 <= this._x87a7fc6a72741c2e.InputCount)
                {
                    goto Label_00AE;
                }
                num++;
            Label_0071:
                if (num < data.Count)
                {
                    goto Label_00ED;
                }
                goto Label_0015;
            Label_0084:
                this._x87a7fc6a72741c2e.AddWeight(0, num3, num, (this._x9b481c22b6706459 * num2) * num4);
                goto Label_0058;
            Label_00A1:
                num4 = 1.0;
                goto Label_0084;
            Label_00AE:
                if (num3 == this._x87a7fc6a72741c2e.InputCount)
                {
                    goto Label_00A1;
                }
                num4 = pair.Input[num3];
                if ((((uint) num) + ((uint) num)) <= uint.MaxValue)
                {
                    goto Label_0084;
                }
                goto Label_0058;
            Label_00E6:
                num = 0;
                goto Label_0071;
            Label_00ED:
                num2 = pair.Ideal[num] - data[num];
                num3 = 0;
                goto Label_005E;
            Label_010B:
                pair = enumerator.Current;
                if ((((uint) num4) & 0) != 0)
                {
                    goto Label_00AE;
                }
                data = this._x87a7fc6a72741c2e.Compute(pair.Input);
                goto Label_00E6;
            }
        Label_0151:
            this.Error = calculation.Calculate();
        }

        public sealed override TrainingContinuation Pause()
        {
            return null;
        }

        public override void Resume(TrainingContinuation state)
        {
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

