namespace Encog.Neural.BAM
{
    using Encog.MathUtil.Matrices;
    using Encog.ML;
    using Encog.ML.Data;
    using Encog.Neural;
    using Encog.Neural.Networks;
    using System;

    [Serializable]
    public class BAMNetwork : BasicML
    {
        private int _f1Count;
        private int _f2Count;
        private Matrix _weightsF1ToF2;
        private Matrix _weightsF2ToF1;

        public BAMNetwork()
        {
        }

        public BAMNetwork(int theF1Count, int theF2Count)
        {
            this._f1Count = theF1Count;
            this._f2Count = theF2Count;
            this._weightsF1ToF2 = new Matrix(this._f1Count, this._f2Count);
            this._weightsF2ToF1 = new Matrix(this._f2Count, this._f1Count);
        }

        public void AddPattern(IMLData inputPattern, IMLData outputPattern)
        {
            for (int i = 0; i < this._f1Count; i++)
            {
                for (int j = 0; j < this._f2Count; j++)
                {
                    int num3 = (int) (inputPattern[i] * outputPattern[j]);
                    this._weightsF1ToF2.Add(i, j, (double) num3);
                    if (0 == 0)
                    {
                        this._weightsF2ToF1.Add(j, i, (double) num3);
                    }
                    if (8 == 0)
                    {
                        return;
                    }
                }
            }
        }

        public void Clear()
        {
            this._weightsF1ToF2.Clear();
            this._weightsF2ToF1.Clear();
        }

        public IMLData Compute(IMLData input)
        {
            throw new NeuralNetworkError("Compute on BasicNetwork cannot be used, rather call the compute(NeuralData) method on the BAMLogic.");
        }

        public NeuralDataMapping Compute(NeuralDataMapping input)
        {
            bool flag;
            bool flag2;
            do
            {
                flag = PropagateLayer(this._weightsF1ToF2, input.From, input.To);
                flag2 = PropagateLayer(this._weightsF2ToF1, input.To, input.From);
            }
            while (!flag && !flag2);
            return null;
        }

        private static double GetWeight(Matrix matrix, IMLData input, int x, int y)
        {
            if (matrix.Rows != input.Count)
            {
                return matrix[x, y];
            }
            return matrix[y, x];
        }

        private static bool PropagateLayer(Matrix matrix, IMLData input, IMLData output)
        {
            double num2;
            int num3;
            int num4;
            bool flag = true;
            int x = 0;
            goto Label_0019;
        Label_0009:
            if (num4 != ((int) output[x]))
            {
                goto Label_0042;
            }
        Label_0015:
            x++;
        Label_0019:
            if (x < output.Count)
            {
                num2 = 0.0;
                num3 = 0;
                goto Label_00DC;
            }
            return flag;
        Label_0042:
            flag = false;
            output[x] = num4;
            goto Label_0015;
        Label_0050:
            if (num2 == 0.0)
            {
                if ((((uint) x) + ((uint) x)) > uint.MaxValue)
                {
                    return flag;
                }
                goto Label_0015;
            }
        Label_0078:
            if (num2 < 0.0)
            {
                num4 = -1;
                goto Label_0009;
            }
        Label_0087:
            num4 = 1;
            if ((((uint) flag) | uint.MaxValue) == 0)
            {
                goto Label_0050;
            }
            if ((((uint) flag) - ((uint) x)) > uint.MaxValue)
            {
                goto Label_012B;
            }
            if ((((uint) num4) | 15) != 0)
            {
                goto Label_0009;
            }
            if ((((uint) num4) | 15) != 0)
            {
                goto Label_0042;
            }
        Label_00DC:
            if (num3 < input.Count)
            {
                num2 += GetWeight(matrix, input, x, num3) * input[num3];
            }
            else
            {
                if ((((uint) num3) & 0) == 0)
                {
                    goto Label_0050;
                }
                goto Label_0078;
            }
        Label_012B:
            num3++;
            if (8 != 0)
            {
                goto Label_00DC;
            }
            goto Label_0087;
        }

        public override void UpdateProperties()
        {
        }

        public int F1Count
        {
            get
            {
                return this._f1Count;
            }
            set
            {
                this._f1Count = value;
            }
        }

        public int F2Count
        {
            get
            {
                return this._f2Count;
            }
            set
            {
                this._f2Count = value;
            }
        }

        public Matrix WeightsF1ToF2
        {
            get
            {
                return this._weightsF1ToF2;
            }
            set
            {
                this._weightsF1ToF2 = value;
            }
        }

        public Matrix WeightsF2ToF1
        {
            get
            {
                return this._weightsF2ToF1;
            }
            set
            {
                this._weightsF2ToF1 = value;
            }
        }
    }
}

