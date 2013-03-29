namespace Encog.MathUtil
{
    using System;

    [Serializable]
    public class Equilateral
    {
        private readonly double[][] _matrix;
        public const int MinEq = 3;

        public Equilateral(int count, double high, double low)
        {
            this._matrix = Equilat(count, high, low);
        }

        public int Decode(double[] activations)
        {
            int num2;
            int num3;
            double distance;
            double positiveInfinity = double.PositiveInfinity;
            goto Label_0057;
        Label_0024:
            if (num3 < this._matrix.GetLength(0))
            {
                distance = this.GetDistance(activations, num3);
                if ((((uint) distance) >= 0) && (distance >= positiveInfinity))
                {
                    goto Label_003F;
                }
            }
            else
            {
                if (((uint) distance) <= uint.MaxValue)
                {
                    return num2;
                }
                goto Label_0057;
            }
            positiveInfinity = distance;
            num2 = num3;
        Label_003F:
            num3++;
            if ((((uint) num3) | 8) == 0)
            {
                return num2;
            }
            goto Label_0024;
        Label_0057:
            num2 = -1;
            if (0 != 0)
            {
                goto Label_003F;
            }
            num3 = 0;
            goto Label_0024;
        }

        public double[] Encode(int set)
        {
            return this._matrix[set];
        }

        private static double[][] Equilat(int n, double high, double low)
        {
            int num;
            int num2;
            double num3;
            double num4;
            int num5;
            int num6;
            int num7;
            int num8;
            int num9;
            double[][] numArray = new double[n][];
            if ((((uint) num8) & 0) == 0)
            {
                goto Label_0281;
            }
        Label_001E:
            if ((((uint) num4) - ((uint) num3)) < 0)
            {
                goto Label_01BD;
            }
            return numArray;
        Label_003E:
            num9++;
        Label_0044:
            if (num9 < numArray.GetLength(0))
            {
                int index = 0;
                while (index < numArray[0].GetLength(0))
                {
                    numArray[num9][index] = (((numArray[num9][index] - -1.0) / 2.0) * (high - low)) + low;
                    index++;
                    if ((((uint) num5) | 3) == 0)
                    {
                        goto Label_015C;
                    }
                }
                if ((((uint) num5) & 0) != 0)
                {
                    goto Label_0281;
                }
                if (8 != 0)
                {
                    goto Label_003E;
                }
                goto Label_010A;
            }
            if ((((uint) num6) & 0) == 0)
            {
                goto Label_001E;
            }
            if (((uint) num) >= 0)
            {
                goto Label_010A;
            }
        Label_00EF:
            if (num2 < n)
            {
                num3 = num2;
                num4 = Math.Sqrt((num3 * num3) - 1.0) / num3;
                num5 = 0;
                goto Label_01CA;
            }
            num9 = 0;
            goto Label_0044;
        Label_010A:
            numArray[num2][num2 - 1] = 1.0;
            num2++;
            if ((((uint) num2) + ((uint) num5)) <= uint.MaxValue)
            {
                goto Label_00EF;
            }
            goto Label_003E;
        Label_0140:
            if (num8 < (num2 - 1))
            {
                goto Label_015C;
            }
            goto Label_010A;
        Label_0152:
            if (num7 < num2)
            {
                goto Label_0178;
            }
            num8 = 0;
            goto Label_0140;
        Label_015C:
            numArray[num2][num8] = 0.0;
            num8++;
            goto Label_020D;
        Label_0178:
            numArray[num7][num2 - 1] = num3;
            if ((((uint) num6) + ((uint) num6)) <= uint.MaxValue)
            {
                num7++;
                goto Label_0152;
            }
            goto Label_020D;
        Label_019E:
            numArray[num5][num6] *= num4;
            num6++;
        Label_01BD:
            if (num6 < (num2 - 1))
            {
                goto Label_019E;
            }
            num5++;
        Label_01CA:
            if (num5 < num2)
            {
                num6 = 0;
                goto Label_01BD;
            }
            num3 = -1.0 / num3;
            num7 = 0;
            goto Label_0152;
        Label_020D:
            if (((uint) num2) <= uint.MaxValue)
            {
                goto Label_0140;
            }
        Label_021F:
            if ((((uint) num9) & 0) != 0)
            {
                goto Label_015C;
            }
            numArray[0][0] = -1.0;
            numArray[1][0] = 1.0;
            num2 = 2;
            goto Label_00EF;
        Label_0281:
            num = 0;
        Label_027B:
            if (num < n)
            {
                numArray[num] = new double[n - 1];
                num++;
                if ((((uint) low) - ((uint) num9)) > uint.MaxValue)
                {
                    goto Label_0178;
                }
                if ((((uint) num3) + ((uint) num9)) <= uint.MaxValue)
                {
                    if ((((uint) num6) | 2) == 0)
                    {
                        goto Label_019E;
                    }
                    goto Label_027B;
                }
            }
            goto Label_021F;
        }

        public double GetDistance(double[] data, int set)
        {
            double d = 0.0;
            for (int i = 0; i < data.GetLength(0); i++)
            {
                d += Math.Pow(data[i] - this._matrix[set][i], 2.0);
            }
            return Math.Sqrt(d);
        }

        public int GetSmallestDistance(double[] data)
        {
            double num2;
            int num3;
            double distance;
            int num = -1;
            if ((((uint) num3) - ((uint) distance)) <= uint.MaxValue)
            {
                goto Label_00B3;
            }
        Label_001F:
            if (num3 < this._matrix.Length)
            {
                distance = this.GetDistance(data, num3);
                if (((uint) num2) > uint.MaxValue)
                {
                    goto Label_001F;
                }
            }
            else
            {
                if (0 == 0)
                {
                    if (-1 != 0)
                    {
                        return num;
                    }
                    goto Label_00B3;
                }
                goto Label_001F;
            }
        Label_0032:
            if (num == -1)
            {
                goto Label_006A;
            }
            if (distance < num2)
            {
                goto Label_0040;
            }
        Label_003A:
            num3++;
            if (((uint) distance) < 0)
            {
            }
            goto Label_001F;
        Label_0040:
            if (((((uint) num3) + ((uint) num3)) > uint.MaxValue) && (((uint) num3) >= 0))
            {
                goto Label_0032;
            }
        Label_006A:
            num = num3;
            num2 = distance;
            goto Label_003A;
        Label_00B3:
            num2 = double.MaxValue;
            num3 = 0;
            if ((((uint) num) & 0) != 0)
            {
                goto Label_0040;
            }
            goto Label_001F;
        }
    }
}

