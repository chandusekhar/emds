namespace Encog.Neural.SOM.Training.Neighborhood
{
    using Encog.MathUtil;
    using Encog.MathUtil.Matrices;
    using Encog.ML.Data;
    using Encog.Neural.SOM;
    using System;

    public class BestMatchingUnit
    {
        private double _x3eba85d02deab94c;
        private readonly SOMNetwork _x7af5fe5ee7d4a6c7;

        public BestMatchingUnit(SOMNetwork som)
        {
            this._x7af5fe5ee7d4a6c7 = som;
        }

        public int CalculateBMU(IMLData input)
        {
            double num2;
            int num3;
            double num4;
            int num = 0;
            goto Label_0107;
        Label_0067:
            if (num3 < this._x7af5fe5ee7d4a6c7.OutputCount)
            {
                num4 = this.CalculateEuclideanDistance(this._x7af5fe5ee7d4a6c7.Weights, input, num3);
                if (1 != 0)
                {
                    goto Label_00E9;
                }
                goto Label_0101;
            }
        Label_003A:
            if (num2 > this._x3eba85d02deab94c)
            {
                this._x3eba85d02deab94c = num2;
                if ((((uint) num4) - ((uint) num4)) <= uint.MaxValue)
                {
                    if ((((uint) num) - ((uint) num2)) >= 0)
                    {
                        return num;
                    }
                    goto Label_003A;
                }
            }
            else
            {
                if (((uint) num) > uint.MaxValue)
                {
                    goto Label_009E;
                }
                if (((uint) num4) >= 0)
                {
                    if ((((uint) num2) + ((uint) num)) >= 0)
                    {
                        return num;
                    }
                    if (((uint) num) >= 0)
                    {
                        goto Label_0107;
                    }
                }
                else
                {
                    goto Label_0067;
                }
            }
        Label_008A:
            if ((((uint) num2) & 0) != 0)
            {
                goto Label_00E9;
            }
        Label_009E:
            num3++;
            goto Label_0067;
        Label_00E9:
            if (num4 >= num2)
            {
                if (((uint) num2) <= uint.MaxValue)
                {
                    if (((uint) num) > uint.MaxValue)
                    {
                        goto Label_0111;
                    }
                    goto Label_009E;
                }
                goto Label_0107;
            }
        Label_0101:
            num2 = num4;
            num = num3;
            goto Label_008A;
        Label_0107:
            num2 = double.MaxValue;
        Label_0111:
            num3 = 0;
            goto Label_0067;
        }

        public double CalculateEuclideanDistance(Matrix matrix, IMLData input, int outputNeuron)
        {
            int num2;
            double num3;
            double a = 0.0;
            if (((uint) num3) >= 0)
            {
                num2 = 0;
                goto Label_0026;
            }
        Label_001C:
            a += num3 * num3;
            num2++;
        Label_0026:
            if (num2 < input.Count)
            {
                num3 = input[num2] - matrix[num2, outputNeuron];
                if ((((uint) num2) - ((uint) num3)) <= uint.MaxValue)
                {
                    goto Label_001C;
                }
            }
            return BoundMath.Sqrt(a);
        }

        public void Reset()
        {
            this._x3eba85d02deab94c = double.MinValue;
        }

        public double WorstDistance
        {
            get
            {
                return this._x3eba85d02deab94c;
            }
        }
    }
}

