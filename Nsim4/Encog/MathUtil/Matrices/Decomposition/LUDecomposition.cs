namespace Encog.MathUtil.Matrices.Decomposition
{
    using Encog.MathUtil.Matrices;
    using Encog.Util;
    using System;

    public class LUDecomposition
    {
        private readonly int x57e9faf3ffdc07cc;
        private readonly int x6088325dec1baa2a;
        private readonly double[][] x6f7a05b81c35b16c;
        private readonly int xa0cac978920221b7;
        private readonly int[] xf4c1900fcf4a6b03;

        public LUDecomposition(Matrix A)
        {
            int num;
            double[] numArray;
            double[] numArray2;
            int num2;
            int num3;
            int num4;
            int num5;
            double num6;
            int num7;
            int num8;
            int num9;
            int num10;
            double num11;
            int num12;
            int num13;
            double num14;
            goto Label_03A9;
        Label_000B:
            if ((num2 < this.x6088325dec1baa2a) & (this.x6f7a05b81c35b16c[num2][num2] != 0.0))
            {
                num13 = num2 + 1;
                if ((((uint) num4) | 0x80000000) != 0)
                {
                    goto Label_0070;
                }
                goto Label_03A9;
            }
            if ((((uint) num10) + ((uint) num5)) < 0)
            {
                goto Label_005C;
            }
        Label_004A:
            num2++;
        Label_004E:
            if (num2 < this.x57e9faf3ffdc07cc)
            {
                num3 = 0;
                goto Label_02C7;
            }
            return;
        Label_005C:
            num13++;
        Label_0062:
            if (num13 < this.x6088325dec1baa2a)
            {
                this.x6f7a05b81c35b16c[num13][num2] /= this.x6f7a05b81c35b16c[num2][num2];
                goto Label_005C;
            }
            goto Label_004A;
        Label_0070:
            if ((((uint) num10) - ((uint) num5)) > uint.MaxValue)
            {
                goto Label_0372;
            }
            goto Label_0062;
        Label_0120:
            while (num10 < this.x57e9faf3ffdc07cc)
            {
                num11 = this.x6f7a05b81c35b16c[num8][num10];
                this.x6f7a05b81c35b16c[num8][num10] = this.x6f7a05b81c35b16c[num2][num10];
                this.x6f7a05b81c35b16c[num2][num10] = num11;
                num10++;
            }
            if (((uint) num14) <= uint.MaxValue)
            {
                num12 = this.xf4c1900fcf4a6b03[num8];
                this.xf4c1900fcf4a6b03[num8] = this.xf4c1900fcf4a6b03[num2];
                this.xf4c1900fcf4a6b03[num2] = num12;
                this.xa0cac978920221b7 = -this.xa0cac978920221b7;
                goto Label_000B;
            }
        Label_0167:
            num9++;
        Label_016D:
            if (num9 < this.x6088325dec1baa2a)
            {
                if (Math.Abs(numArray2[num9]) > Math.Abs(numArray2[num8]))
                {
                    goto Label_01C7;
                }
                goto Label_0167;
            }
            if (num8 != num2)
            {
                num10 = 0;
                goto Label_0120;
            }
            goto Label_000B;
        Label_01C7:
            num8 = num9;
            goto Label_0260;
        Label_01CD:
            num8 = num2;
            num9 = num2 + 1;
            goto Label_016D;
        Label_0207:
            if (num4 < this.x6088325dec1baa2a)
            {
                numArray = this.x6f7a05b81c35b16c[num4];
                num5 = Math.Min(num4, num2);
                goto Label_0291;
            }
            if ((((uint) num7) & 0) == 0)
            {
                goto Label_01CD;
            }
            if ((((uint) num7) - ((uint) num7)) >= 0)
            {
                goto Label_01C7;
            }
        Label_0260:
            if ((((uint) num8) - ((uint) num10)) >= 0)
            {
                if ((((uint) num8) - ((uint) num11)) >= 0)
                {
                    if ((((uint) num11) & 0) == 0)
                    {
                        goto Label_0167;
                    }
                    goto Label_0070;
                }
                if ((((uint) num14) + ((uint) num9)) < 0)
                {
                    goto Label_004E;
                }
                if (0 != 0)
                {
                    goto Label_0291;
                }
                goto Label_02F4;
            }
            goto Label_0207;
        Label_0291:
            num6 = 0.0;
            num7 = 0;
        Label_01DA:
            if (num7 < num5)
            {
                num6 += numArray[num7] * numArray2[num7];
                num7++;
                if (-2147483648 != 0)
                {
                    goto Label_01DA;
                }
                goto Label_0260;
            }
            numArray[num2] = numArray2[num4] -= num6;
            if (0 != 0)
            {
                goto Label_01CD;
            }
            num4++;
            goto Label_0207;
        Label_02C7:
            if (num3 >= this.x6088325dec1baa2a)
            {
                num4 = 0;
                goto Label_0207;
            }
        Label_02F4:
            numArray2[num3] = this.x6f7a05b81c35b16c[num3][num2];
            if ((((uint) num12) - ((uint) num5)) > uint.MaxValue)
            {
                goto Label_0120;
            }
            if ((((uint) num11) - ((uint) num9)) <= uint.MaxValue)
            {
                num3++;
                goto Label_02C7;
            }
            goto Label_0207;
        Label_0372:
            while (num < this.x6088325dec1baa2a)
            {
                this.xf4c1900fcf4a6b03[num] = num;
                num++;
            }
            if (((uint) num8) > uint.MaxValue)
            {
                goto Label_0120;
            }
            this.xa0cac978920221b7 = 1;
            numArray2 = new double[this.x6088325dec1baa2a];
            num2 = 0;
            goto Label_004E;
        Label_03A9:
            this.x6f7a05b81c35b16c = A.GetArrayCopy();
            this.x6088325dec1baa2a = A.Rows;
            this.x57e9faf3ffdc07cc = A.Cols;
            this.xf4c1900fcf4a6b03 = new int[this.x6088325dec1baa2a];
            num = 0;
            goto Label_0372;
        }

        public double Det()
        {
            if (this.x6088325dec1baa2a != this.x57e9faf3ffdc07cc)
            {
                throw new MatrixError("Matrix must be square.");
            }
            double num = this.xa0cac978920221b7;
            if ((((uint) num) | 8) != 0)
            {
                for (int i = 0; i < this.x57e9faf3ffdc07cc; i++)
                {
                    num *= this.x6f7a05b81c35b16c[i][i];
                }
            }
            return num;
        }

        public double[][] Inverse()
        {
            int length;
            int num2;
            int num3;
            double[][] numArray;
            double[][] numArray2;
            int num4;
            int num5;
            int num6;
            int num7;
            int num8;
            int num9;
            int num10;
            int num11;
            int num12;
            if (this.IsNonsingular)
            {
                length = this.x6f7a05b81c35b16c.Length;
                num2 = this.x6f7a05b81c35b16c[0].Length;
                num3 = length;
                numArray = this.x6f7a05b81c35b16c;
                goto Label_028C;
            }
            if ((((uint) length) + ((uint) num3)) <= uint.MaxValue)
            {
                goto Label_029A;
            }
            goto Label_0099;
        Label_002B:
            if (num11 < num9)
            {
                num12 = 0;
                if ((((uint) num5) - ((uint) num4)) > uint.MaxValue)
                {
                    goto Label_0142;
                }
                if ((((uint) num7) - ((uint) num8)) >= 0)
                {
                    goto Label_0099;
                }
                goto Label_029A;
            }
            num9--;
        Label_003A:
            if (num9 >= 0)
            {
                num10 = 0;
                goto Label_00FC;
            }
            if (((uint) num12) <= uint.MaxValue)
            {
                return numArray2;
            }
        Label_0054:
            numArray2[num11][num12] -= numArray2[num9][num12] * numArray[num11][num9];
            num12++;
            if ((((uint) num11) & 0) != 0)
            {
                goto Label_0163;
            }
        Label_0099:
            if (num12 < num3)
            {
                goto Label_0054;
            }
        Label_009E:
            num11++;
            goto Label_002B;
        Label_00D7:
            numArray2[num9][num10] /= numArray[num9][num9];
            num10++;
        Label_00FC:
            if (num10 < num3)
            {
                goto Label_00D7;
            }
            num11 = 0;
            goto Label_002B;
        Label_0129:
            if (num6 < num2)
            {
                num7 = num6 + 1;
                goto Label_0163;
            }
            num9 = num2 - 1;
            goto Label_003A;
        Label_013D:
            if (num8 < num3)
            {
                numArray2[num7][num8] -= numArray2[num6][num8] * numArray[num7][num6];
                if (((((uint) num10) - ((uint) num7)) >= 0) && ((((uint) num6) + ((uint) num4)) < 0))
                {
                    goto Label_009E;
                }
                if (((uint) num4) >= 0)
                {
                    goto Label_016A;
                }
                goto Label_01FA;
            }
        Label_0142:
            num7++;
            if ((((uint) num10) + ((uint) num4)) > uint.MaxValue)
            {
                goto Label_0054;
            }
        Label_0163:
            if (num7 < num2)
            {
                num8 = 0;
                goto Label_013D;
            }
            num6++;
            goto Label_0129;
        Label_016A:
            num8++;
            if ((((uint) num4) | 3) != 0)
            {
                if (((uint) num2) <= uint.MaxValue)
                {
                    goto Label_013D;
                }
                goto Label_00D7;
            }
            goto Label_0200;
        Label_01FA:
            num4++;
        Label_0200:
            if (num4 < length)
            {
                num5 = this.xf4c1900fcf4a6b03[num4];
                if ((((uint) num7) - ((uint) num4)) <= uint.MaxValue)
                {
                    numArray2[num4][num5] = 1.0;
                    if ((((uint) length) & 0) != 0)
                    {
                        goto Label_00FC;
                    }
                    if (((uint) num12) >= 0)
                    {
                        goto Label_01FA;
                    }
                    goto Label_016A;
                }
            }
            else
            {
                num6 = 0;
                goto Label_0129;
            }
        Label_028C:
            numArray2 = EngineArray.AllocateDouble2D(length, num2);
            num4 = 0;
            goto Label_0200;
        Label_029A:
            throw new MatrixError("Matrix is singular");
        }

        public double[] Solve(double[] value_ren)
        {
            int num;
            double[] numArray;
            int num2;
            int length;
            int num4;
            double[][] numArray2;
            double[] numArray3;
            int num5;
            int num6;
            int num7;
            int num8;
            if (value_ren != null)
            {
                goto Label_020A;
            }
            if ((((uint) num4) + ((uint) num)) <= uint.MaxValue)
            {
                throw new MatrixError("value");
            }
            goto Label_005A;
        Label_003A:
            if (num7 >= 0)
            {
                num8 = num4 - 1;
                if ((((uint) num5) - ((uint) num2)) < 0)
                {
                    goto Label_014E;
                }
                goto Label_0083;
            }
            if ((((uint) num4) + ((uint) num2)) >= 0)
            {
                return numArray3;
            }
        Label_005A:
            numArray3[num7] -= numArray2[num7][num8] * numArray3[num8];
            num8--;
        Label_0083:
            if (num8 > num7)
            {
                goto Label_005A;
            }
            numArray3[num7] /= numArray2[num7][num7];
            num7--;
            if ((((uint) length) + ((uint) num8)) <= uint.MaxValue)
            {
                if ((((uint) num) & 0) != 0)
                {
                    goto Label_017A;
                }
                goto Label_003A;
            }
            return numArray3;
        Label_00CC:
            if (num5 < length)
            {
                goto Label_014E;
            }
            num7 = length - 1;
            goto Label_003A;
        Label_010F:
            if (num6 >= num5)
            {
                num5++;
                goto Label_00CC;
            }
            numArray3[num5] -= numArray2[num5][num6] * numArray3[num6];
            num6++;
            goto Label_010F;
        Label_014E:
            numArray3[num5] = numArray[num5];
            num6 = 0;
            goto Label_010F;
        Label_0166:
            while (num2 < numArray.Length)
            {
                numArray[num2] = value_ren[this.xf4c1900fcf4a6b03[num2]];
                num2++;
            }
            length = this.x6f7a05b81c35b16c[0].Length;
            if (0 != 0)
            {
                goto Label_01CC;
            }
        Label_017A:
            num4 = this.x6f7a05b81c35b16c[0].Length;
            numArray2 = this.x6f7a05b81c35b16c;
            if (0 == 0)
            {
                numArray3 = new double[num];
                num5 = 0;
                goto Label_00CC;
            }
            goto Label_010F;
        Label_01A7:
            if (!this.IsNonsingular)
            {
                throw new MatrixError("Matrix is singular");
            }
            num = value_ren.Length;
            if (1 == 0)
            {
                goto Label_0166;
            }
            numArray = new double[num];
        Label_01CC:
            num2 = 0;
            goto Label_0166;
            if ((((uint) num6) - ((uint) length)) >= 0)
            {
                goto Label_020A;
            }
        Label_01E8:
            throw new MatrixError("Invalid matrix dimensions.");
            if ((((uint) num5) <= uint.MaxValue) && (0 == 0))
            {
            }
            goto Label_01A7;
        Label_020A:
            if (value_ren.Length != this.x6f7a05b81c35b16c.Length)
            {
                goto Label_01E8;
            }
            goto Label_01A7;
        }

        public Matrix Solve(Matrix B)
        {
            int cols;
            Matrix matrix;
            double[][] data;
            int num2;
            int num3;
            int num4;
            int num5;
            int num6;
            int num7;
            int num8;
            if (B.Rows == this.x6088325dec1baa2a)
            {
                while (!this.IsNonsingular)
                {
                    throw new MatrixError("Matrix is singular.");
                }
                cols = B.Cols;
                matrix = B.GetMatrix(this.xf4c1900fcf4a6b03, 0, cols - 1);
                data = matrix.Data;
                goto Label_0237;
            }
            goto Label_0251;
        Label_0016:
            if (num7 < num5)
            {
                num8 = 0;
                goto Label_0050;
            }
            num5--;
            if ((((uint) num6) - ((uint) num6)) > uint.MaxValue)
            {
                goto Label_013D;
            }
        Label_003D:
            if (num5 >= 0)
            {
                goto Label_00CB;
            }
            return matrix;
        Label_004A:
            num8++;
        Label_0050:
            if (num8 < cols)
            {
                data[num7][num8] -= data[num5][num8] * this.x6f7a05b81c35b16c[num7][num5];
                if (0 != 0)
                {
                    goto Label_00CB;
                }
                goto Label_004A;
            }
            num7++;
            goto Label_0016;
        Label_00CB:
            num6 = 0;
        Label_0097:
            if (num6 < cols)
            {
                data[num5][num6] /= this.x6f7a05b81c35b16c[num5][num5];
                if ((((uint) num6) + ((uint) num2)) <= uint.MaxValue)
                {
                    if (0 == 0)
                    {
                        num6++;
                        if ((((uint) num6) + ((uint) num8)) > uint.MaxValue)
                        {
                            goto Label_0237;
                        }
                        goto Label_0097;
                    }
                    goto Label_004A;
                }
                goto Label_01A1;
            }
            num7 = 0;
            goto Label_0016;
        Label_013D:
            if (num2 < this.x57e9faf3ffdc07cc)
            {
                num3 = num2 + 1;
                goto Label_0187;
            }
            if (((uint) num4) >= 0)
            {
                goto Label_01D4;
            }
        Label_015B:
            num4++;
        Label_0161:
            if (num4 < cols)
            {
                data[num3][num4] -= data[num2][num4] * this.x6f7a05b81c35b16c[num3][num2];
                goto Label_015B;
            }
            if ((((uint) num5) | 1) != 0)
            {
                num3++;
            }
        Label_0187:
            if (num3 >= this.x57e9faf3ffdc07cc)
            {
                num2++;
                if (2 != 0)
                {
                    if ((((uint) num7) - ((uint) cols)) > uint.MaxValue)
                    {
                        goto Label_0251;
                    }
                    goto Label_013D;
                }
                goto Label_01D4;
            }
        Label_01A1:
            num4 = 0;
            goto Label_0161;
        Label_01D4:
            if ((((uint) num8) + ((uint) num8)) <= uint.MaxValue)
            {
                num5 = this.x57e9faf3ffdc07cc - 1;
                goto Label_003D;
            }
            goto Label_00CB;
        Label_0237:
            num2 = 0;
            if ((((uint) num8) + ((uint) num6)) >= 0)
            {
                goto Label_013D;
            }
        Label_0251:
            throw new MatrixError("Matrix row dimensions must agree.");
        }

        public double[] DoublePivot
        {
            get
            {
                double[] numArray = new double[this.x6088325dec1baa2a];
                int index = 0;
                while (index < this.x6088325dec1baa2a)
                {
                    numArray[index] = this.xf4c1900fcf4a6b03[index];
                    index++;
                    if (0xff != 0)
                    {
                    }
                }
                return numArray;
            }
        }

        public bool IsNonsingular
        {
            get
            {
                int index = 0;
                while (index < this.x57e9faf3ffdc07cc)
                {
                    if (this.x6f7a05b81c35b16c[index][index] == 0.0)
                    {
                        goto Label_0031;
                    }
                    index++;
                    if (0xff == 0)
                    {
                        goto Label_0031;
                    }
                }
                return true;
            Label_0031:
                return false;
            }
        }

        public Matrix L
        {
            get
            {
                int num2;
                Matrix matrix = new Matrix(this.x6088325dec1baa2a, this.x57e9faf3ffdc07cc);
                double[][] data = matrix.Data;
                int index = 0;
                goto Label_0028;
            Label_0017:
                num2++;
            Label_001B:
                if (num2 < this.x57e9faf3ffdc07cc)
                {
                    if (index <= num2)
                    {
                        if (index != num2)
                        {
                            data[index][num2] = 0.0;
                            if ((((uint) index) - ((uint) num2)) > uint.MaxValue)
                            {
                                return matrix;
                            }
                        }
                        else
                        {
                            data[index][num2] = 1.0;
                        }
                        goto Label_0017;
                    }
                    goto Label_007C;
                }
                index++;
            Label_0028:
                if (index < this.x6088325dec1baa2a)
                {
                    num2 = 0;
                    goto Label_001B;
                }
                if ((((uint) index) + ((uint) index)) >= 0)
                {
                    return matrix;
                }
            Label_007C:
                data[index][num2] = this.x6f7a05b81c35b16c[index][num2];
                goto Label_0017;
            }
        }

        public int[] Pivot
        {
            get
            {
                int num;
                int[] numArray = new int[this.x6088325dec1baa2a];
                if ((((uint) num) + ((uint) num)) <= uint.MaxValue)
                {
                    num = 0;
                }
                while (num < this.x6088325dec1baa2a)
                {
                    numArray[num] = this.xf4c1900fcf4a6b03[num];
                    num++;
                }
                return numArray;
            }
        }

        public Matrix U
        {
            get
            {
                int num;
                int num2;
                Matrix matrix = new Matrix(this.x57e9faf3ffdc07cc, this.x57e9faf3ffdc07cc);
                double[][] data = matrix.Data;
                goto Label_00D5;
            Label_0017:
                if (num < this.x57e9faf3ffdc07cc)
                {
                    num2 = 0;
                    goto Label_004F;
                }
                if ((((uint) num) - ((uint) num2)) <= uint.MaxValue)
                {
                    if ((((uint) num2) | 0x7fffffff) != 0)
                    {
                        return matrix;
                    }
                    if ((((uint) num) - ((uint) num2)) >= 0)
                    {
                        goto Label_00D5;
                    }
                    if ((((uint) num) | 0xfffffffe) != 0)
                    {
                        goto Label_0070;
                    }
                    goto Label_00C3;
                }
            Label_004B:
                num2++;
            Label_004F:
                if (num2 >= this.x57e9faf3ffdc07cc)
                {
                    num++;
                    if (((uint) num) <= uint.MaxValue)
                    {
                        goto Label_0017;
                    }
                    goto Label_004B;
                }
            Label_0070:
                if (num > num2)
                {
                    if (0 != 0)
                    {
                        goto Label_004F;
                    }
                    data[num][num2] = 0.0;
                    goto Label_004B;
                }
            Label_00C3:
                data[num][num2] = this.x6f7a05b81c35b16c[num][num2];
                if (0 == 0)
                {
                    goto Label_004B;
                }
            Label_00D5:
                num = 0;
                goto Label_0017;
            }
        }
    }
}

