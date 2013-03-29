namespace Encog.Neural.CPN.Training
{
    using Encog.MathUtil;
    using Encog.ML;
    using Encog.ML.Data;
    using Encog.ML.Train;
    using Encog.Neural;
    using Encog.Neural.CPN;
    using Encog.Neural.Networks.Training;
    using Encog.Neural.Networks.Training.Propagation;
    using Encog.Util;
    using System;
    using System.Collections.Generic;

    public class TrainInstar : BasicTraining, ILearningRate
    {
        private bool _x268cb8b20222b0dc;
        private readonly IMLDataSet _x823a2b9c8bf459c5;
        private readonly CPNNetwork _x87a7fc6a72741c2e;
        private double _x9b481c22b6706459;

        public TrainInstar(CPNNetwork theNetwork, IMLDataSet theTraining, double theLearningRate, bool theInitWeights) : base(TrainingImplementationType.Iterative)
        {
            this._x87a7fc6a72741c2e = theNetwork;
            this._x823a2b9c8bf459c5 = theTraining;
            this._x9b481c22b6706459 = theLearningRate;
            this._x268cb8b20222b0dc = theInitWeights;
        }

        public sealed override void Iteration()
        {
            if (this._x268cb8b20222b0dc)
            {
                this.x7ecfa86bb6039378();
            }
            double negativeInfinity = double.NegativeInfinity;
            using (IEnumerator<IMLDataPair> enumerator = this._x823a2b9c8bf459c5.GetEnumerator())
            {
                IMLDataPair pair;
                int num2;
                double num3;
                int num4;
                double num5;
                int num6;
                double num7;
            Label_0027:
                if (enumerator.MoveNext())
                {
                    goto Label_015A;
                }
                if ((((uint) negativeInfinity) + ((uint) num3)) >= 0)
                {
                    goto Label_01C7;
                }
                if (-2 != 0)
                {
                    goto Label_0197;
                }
                if ((((uint) num5) & 0) == 0)
                {
                    goto Label_015A;
                }
                goto Label_00B8;
            Label_0071:
                this._x87a7fc6a72741c2e.WeightsInputToInstar.Add(num6, num2, num7);
                num6++;
            Label_008C:
                if (num6 < this._x87a7fc6a72741c2e.InputCount)
                {
                    goto Label_00C0;
                }
                if ((((uint) num4) + ((uint) num3)) < 0)
                {
                    goto Label_014D;
                }
                goto Label_0027;
            Label_00B8:
                negativeInfinity = num3;
            Label_00BB:
                num6 = 0;
                goto Label_008C;
            Label_00C0:
                num7 = this._x9b481c22b6706459 * (pair.Input[num6] - this._x87a7fc6a72741c2e.WeightsInputToInstar[num6, num2]);
                if (((uint) num5) >= 0)
                {
                    goto Label_0071;
                }
                goto Label_0027;
            Label_0104:
                if (num3 <= negativeInfinity)
                {
                    goto Label_00BB;
                }
                goto Label_00B8;
            Label_010B:
                num5 = pair.Input[num4] - this._x87a7fc6a72741c2e.WeightsInputToInstar[num4, num2];
                num3 += num5 * num5;
                num4++;
            Label_013E:
                if (num4 < pair.Input.Count)
                {
                    goto Label_010B;
                }
            Label_014D:
                num3 = BoundMath.Sqrt(num3);
                goto Label_0104;
            Label_015A:
                pair = enumerator.Current;
                num2 = EngineArray.IndexOfLargest(this._x87a7fc6a72741c2e.ComputeInstar(pair.Input).Data);
                num3 = 0.0;
                num4 = 0;
                goto Label_013E;
            Label_0197:
                if ((((uint) num5) | 0xfffffffe) == 0)
                {
                    goto Label_0071;
                }
                goto Label_015A;
            }
        Label_01C7:
            this.Error = negativeInfinity;
        }

        public sealed override TrainingContinuation Pause()
        {
            return null;
        }

        public override void Resume(TrainingContinuation state)
        {
        }

        private void x7ecfa86bb6039378()
        {
            if (this._x823a2b9c8bf459c5.Count != this._x87a7fc6a72741c2e.InstarCount)
            {
                throw new NeuralNetworkError("If the weights are to be set from the training data, then there must be one instar neuron for each training element.");
            }
            int num = 0;
            using (IEnumerator<IMLDataPair> enumerator = this._x823a2b9c8bf459c5.GetEnumerator())
            {
                IMLDataPair current;
                int num2;
                goto Label_0068;
            Label_0034:
                this._x87a7fc6a72741c2e.WeightsInputToInstar[num2, num] = current.Input[num2];
                num2++;
            Label_0056:
                if (num2 < this._x87a7fc6a72741c2e.InputCount)
                {
                    goto Label_0034;
                }
                num++;
            Label_0068:
                if (enumerator.MoveNext() || ((((uint) num2) & 0) != 0))
                {
                    current = enumerator.Current;
                    num2 = 0;
                    goto Label_0056;
                }
            }
            this._x268cb8b20222b0dc = false;
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

