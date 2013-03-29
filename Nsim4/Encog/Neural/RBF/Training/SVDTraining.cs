namespace Encog.Neural.Rbf.Training
{
    using Encog.MathUtil.RBF;
    using Encog.ML;
    using Encog.ML.Data;
    using Encog.ML.Train;
    using Encog.Neural.Networks.Training;
    using Encog.Neural.Networks.Training.Propagation;
    using Encog.Neural.RBF;
    using Encog.Neural.RBF.Training;
    using Encog.Util;
    using Encog.Util.Simple;
    using System;

    public class SVDTraining : BasicTraining
    {
        private readonly RBFNetwork x87a7fc6a72741c2e;

        public SVDTraining(RBFNetwork network_0, IMLDataSet training) : base(TrainingImplementationType.OnePass)
        {
            while (-2147483648 != 0)
            {
                if (network_0.OutputCount != 1)
                {
                    break;
                }
                this.Training = training;
                this.x87a7fc6a72741c2e = network_0;
                if (0 != 0)
                {
                    break;
                }
                return;
            }
            throw new TrainingError("SVD requires an output layer with a single neuron.");
        }

        public void FlatToMatrix(double[] flat, int start, double[][] matrix)
        {
            int num3;
            int num4;
            int length = matrix.Length;
            int num2 = matrix[0].Length;
            goto Label_004B;
        Label_001C:
            if (num4 >= length)
            {
                return;
            }
            int index = 0;
            while (index < num2)
            {
                matrix[num4][index] = flat[num3++];
                index++;
            }
            num4++;
            if (((uint) num4) >= 0)
            {
                goto Label_001C;
            }
        Label_004B:
            num3 = start;
            if ((((uint) length) - ((uint) index)) > uint.MaxValue)
            {
                goto Label_001C;
            }
            num4 = 0;
            if ((((uint) num3) | 2) == 0)
            {
                return;
            }
            goto Label_001C;
        }

        public sealed override void Iteration()
        {
            IRadialBasisFunction function;
            ObjectPair<double[][], double[][]> pair;
            double[][] numArray;
            int length = this.x87a7fc6a72741c2e.RBF.Length;
            IRadialBasisFunction[] funcs = new IRadialBasisFunction[length];
            int index = 0;
            goto Label_00A7;
        Label_0013:
            this.FlatToMatrix(this.x87a7fc6a72741c2e.Flat.Weights, 0, numArray);
            this.Error = SVD.Svdfit(pair.A, pair.B, numArray, funcs);
            this.MatrixToFlat(numArray, this.x87a7fc6a72741c2e.Flat.Weights, 0);
            return;
        Label_00A7:
            if (index < length)
            {
                function = this.x87a7fc6a72741c2e.RBF[index];
            }
            else
            {
                pair = TrainingSetUtil.TrainingToArray(this.Training);
                numArray = EngineArray.AllocateDouble2D(length, this.x87a7fc6a72741c2e.OutputCount);
                if (4 != 0)
                {
                    goto Label_0013;
                }
            }
            funcs[index] = function;
            if ((((uint) index) | uint.MaxValue) == 0)
            {
                return;
            }
            index++;
            if (-2147483648 == 0)
            {
                goto Label_0013;
            }
            goto Label_00A7;
        }

        public void MatrixToFlat(double[][] matrix, double[] flat, int start)
        {
            int num4;
            int num5;
            int length = matrix.Length;
            int num2 = matrix[0].Length;
            int num3 = start;
            goto Label_005C;
        Label_0006:
            num5++;
            if ((((uint) length) & 0) != 0)
            {
                goto Label_005C;
            }
        Label_0020:
            if (num5 < num2)
            {
                flat[num3++] = matrix[num4][num5];
                goto Label_0006;
            }
            if ((((uint) num5) & 0) == 0)
            {
            }
            num4++;
        Label_003D:
            if (num4 < length)
            {
                num5 = 0;
                if ((((uint) start) + ((uint) num4)) >= 0)
                {
                    goto Label_0020;
                }
                goto Label_0006;
            }
            return;
        Label_005C:
            num4 = 0;
            goto Label_003D;
        }

        public override TrainingContinuation Pause()
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

        public override IMLMethod Method
        {
            get
            {
                return this.x87a7fc6a72741c2e;
            }
        }
    }
}

