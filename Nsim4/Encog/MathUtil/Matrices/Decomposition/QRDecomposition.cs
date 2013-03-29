namespace Encog.MathUtil.Matrices.Decomposition
{
    using Encog.MathUtil;
    using Encog.MathUtil.Matrices;
    using System;

    public class QRDecomposition
    {
        private readonly double[][] x1e2b930239385f93;
        private readonly int x57e9faf3ffdc07cc;
        private readonly double[] x5f131619608f051b;
        private readonly int x6088325dec1baa2a;

        public QRDecomposition(Matrix A)
        {
            int num;
            double num2;
            int num3;
            int num4;
            int num5;
            double num6;
            int num7;
            int num8;
            goto Label_02FC;
        Label_000B:
            if (num < this.x57e9faf3ffdc07cc)
            {
                num2 = 0.0;
                num3 = num;
                while (num3 < this.x6088325dec1baa2a)
                {
                    num2 = EncogMath.Hypot(num2, this.x1e2b930239385f93[num3][num]);
                    num3++;
                }
                if (num2 != 0.0)
                {
                    if (this.x1e2b930239385f93[num][num] >= 0.0)
                    {
                        goto Label_025B;
                    }
                }
                else
                {
                    if (((uint) num) < 0)
                    {
                        goto Label_0073;
                    }
                    goto Label_0069;
                }
                goto Label_029E;
            }
            if ((((uint) num8) & 0) == 0)
            {
                goto Label_0092;
            }
        Label_002B:
            if ((((uint) num4) - ((uint) num)) < 0)
            {
                goto Label_015B;
            }
        Label_0069:
            this.x5f131619608f051b[num] = -num2;
        Label_0073:
            num++;
            if ((((uint) num7) + ((uint) num)) >= 0)
            {
                goto Label_000B;
            }
        Label_0092:
            if ((((uint) num2) - ((uint) num4)) >= 0)
            {
                if ((((uint) num6) & 0) == 0)
                {
                    return;
                }
                if (((uint) num) >= 0)
                {
                    goto Label_02FC;
                }
                goto Label_019F;
            }
        Label_00AA:
            while (num8 < this.x6088325dec1baa2a)
            {
                this.x1e2b930239385f93[num8][num5] += num6 * this.x1e2b930239385f93[num8][num];
                if ((((uint) num4) - ((uint) num3)) >= 0)
                {
                    goto Label_00FD;
                }
            }
            num5++;
        Label_00BA:
            if (num5 < this.x57e9faf3ffdc07cc)
            {
                num6 = 0.0;
                if ((((uint) num3) + ((uint) num5)) > uint.MaxValue)
                {
                    goto Label_01C2;
                }
                num7 = num;
                if ((((uint) num8) - ((uint) num6)) < 0)
                {
                    goto Label_0069;
                }
                goto Label_015B;
            }
            goto Label_002B;
        Label_00FD:
            num8++;
            goto Label_00AA;
        Label_015B:
            while (num7 < this.x6088325dec1baa2a)
            {
                num6 += this.x1e2b930239385f93[num7][num] * this.x1e2b930239385f93[num7][num5];
                num7++;
            }
            num6 = -num6 / this.x1e2b930239385f93[num][num];
            num8 = num;
            goto Label_00AA;
        Label_019F:
            this.x1e2b930239385f93[num][num]++;
        Label_01C2:
            num5 = num + 1;
            goto Label_00BA;
        Label_0250:
            while (num4 < this.x6088325dec1baa2a)
            {
                this.x1e2b930239385f93[num4][num] /= num2;
                num4++;
                if ((((uint) num2) + ((uint) num5)) < 0)
                {
                    goto Label_029E;
                }
            }
            goto Label_019F;
        Label_025B:
            num4 = num;
            if ((((uint) num7) & 0) != 0)
            {
                goto Label_00FD;
            }
            goto Label_0250;
        Label_029E:
            num2 = -num2;
            if ((((uint) num5) - ((uint) num5)) < 0)
            {
                goto Label_0250;
            }
            goto Label_025B;
        Label_02FC:
            this.x1e2b930239385f93 = A.GetArrayCopy();
            this.x6088325dec1baa2a = A.Rows;
            this.x57e9faf3ffdc07cc = A.Cols;
            this.x5f131619608f051b = new double[this.x57e9faf3ffdc07cc];
            num = 0;
            goto Label_000B;
        }

        public bool IsFullRank()
        {
            for (int i = 0; i < this.x57e9faf3ffdc07cc; i++)
            {
                do
                {
                    if (this.x5f131619608f051b[i] == 0.0)
                    {
                        return false;
                    }
                }
                while (-2147483648 == 0);
            }
            return true;
        }

        public Matrix Solve(Matrix B)
        {
            int num;
            double[][] numArray;
            int num2;
            int num3;
            double num4;
            int num5;
            int num6;
            int num7;
            int num9;
            int num10;
            if ((B.Rows != this.x6088325dec1baa2a) && ((((uint) num7) + ((uint) num)) <= uint.MaxValue))
            {
                throw new MatrixError("Matrix row dimensions must agree.");
            }
            if (!this.IsFullRank())
            {
                throw new MatrixError("Matrix is rank deficient.");
            }
            goto Label_0275;
        Label_00E2:
            num7 = this.x57e9faf3ffdc07cc - 1;
        Label_0016:
            if (num7 >= 0)
            {
                int index = 0;
                while (index < num)
                {
                    numArray[num7][index] /= this.x5f131619608f051b[num7];
                    index++;
                }
                num9 = 0;
            Label_002E:
                if (num9 < num7)
                {
                    num10 = 0;
                    if ((((uint) index) - ((uint) num7)) <= uint.MaxValue)
                    {
                        while (num10 < num)
                        {
                            numArray[num9][num10] -= numArray[num7][num10] * this.x1e2b930239385f93[num9][num7];
                            if (((uint) num3) < 0)
                            {
                                goto Label_00E2;
                            }
                            num10++;
                        }
                        num9++;
                        goto Label_002E;
                    }
                    goto Label_0016;
                }
                num7--;
            }
            else
            {
                return new Matrix(numArray).GetMatrix(0, this.x57e9faf3ffdc07cc - 1, 0, num - 1);
            }
            if (((uint) num2) <= uint.MaxValue)
            {
                goto Label_0016;
            }
            goto Label_0139;
        Label_0108:
            if (num3 < num)
            {
                num4 = 0.0;
                if ((((uint) num9) - ((uint) num10)) > uint.MaxValue)
                {
                    goto Label_0127;
                }
                num5 = num2;
                while (true)
                {
                    if (num5 >= this.x6088325dec1baa2a)
                    {
                        num4 = -num4 / this.x1e2b930239385f93[num2][num2];
                        num6 = num2;
                        goto Label_013F;
                    }
                    num4 += this.x1e2b930239385f93[num5][num2] * numArray[num5][num3];
                    num5++;
                    if ((((uint) num10) | 0xff) == 0)
                    {
                        goto Label_0275;
                    }
                }
            }
            if ((((uint) num3) - ((uint) num9)) <= uint.MaxValue)
            {
            }
        Label_0127:
            num2++;
        Label_012B:
            if (num2 < this.x57e9faf3ffdc07cc)
            {
                num3 = 0;
                goto Label_0108;
            }
            goto Label_00E2;
        Label_0139:
            num6++;
        Label_013F:
            if (num6 < this.x6088325dec1baa2a)
            {
                numArray[num6][num3] += num4 * this.x1e2b930239385f93[num6][num2];
                if ((((uint) num2) + ((uint) num6)) <= uint.MaxValue)
                {
                    goto Label_0139;
                }
            }
            else
            {
                num3++;
                if (((uint) num2) >= 0)
                {
                    if ((((uint) num5) & 0) != 0)
                    {
                        goto Label_012B;
                    }
                    goto Label_0108;
                }
                goto Label_00E2;
            }
        Label_0260:
            numArray = B.GetArrayCopy();
            num2 = 0;
            goto Label_012B;
        Label_0275:
            num = B.Cols;
            goto Label_0260;
        }

        public Matrix H
        {
            get
            {
                double[][] numArray;
                int num;
                int num2;
                Matrix matrix = new Matrix(this.x6088325dec1baa2a, this.x57e9faf3ffdc07cc);
                if ((((uint) num) + ((uint) num2)) <= uint.MaxValue)
                {
                    goto Label_0096;
                }
            Label_002D:
                if (num < this.x6088325dec1baa2a)
                {
                    num2 = 0;
                    if (0 != 0)
                    {
                        goto Label_0065;
                    }
                }
                else
                {
                    return matrix;
                }
            Label_003E:
                if (num2 >= this.x57e9faf3ffdc07cc)
                {
                    num++;
                    if (0 == 0)
                    {
                        if ((((uint) num) + ((uint) num)) <= uint.MaxValue)
                        {
                            if ((((uint) num) + ((uint) num)) > uint.MaxValue)
                            {
                                return matrix;
                            }
                            goto Label_002D;
                        }
                        goto Label_0096;
                    }
                    if (0 != 0)
                    {
                    }
                }
                else if (num >= num2)
                {
                    numArray[num][num2] = this.x1e2b930239385f93[num][num2];
                    goto Label_0065;
                }
                numArray[num][num2] = 0.0;
            Label_0065:
                num2++;
                goto Label_003E;
            Label_0096:
                numArray = matrix.Data;
                num = 0;
                goto Label_002D;
            }
        }

        public Matrix Q
        {
            get
            {
                double[][] data;
                int num;
                int num2;
                int num3;
                double num4;
                int num5;
                int num6;
                Matrix matrix = new Matrix(this.x6088325dec1baa2a, this.x57e9faf3ffdc07cc);
                if ((((uint) num) + ((uint) num)) >= 0)
                {
                    data = matrix.Data;
                    num = this.x57e9faf3ffdc07cc - 1;
                }
                else
                {
                    goto Label_0176;
                }
            Label_0049:
                if (num >= 0)
                {
                    num2 = 0;
                    goto Label_0188;
                }
                if ((((uint) num) | 0x80000000) != 0)
                {
                    if (((uint) num5) <= uint.MaxValue)
                    {
                        return matrix;
                    }
                    goto Label_0176;
                }
            Label_0068:
                if ((((uint) num) - ((uint) num3)) > uint.MaxValue)
                {
                    goto Label_00F6;
                }
                num6++;
            Label_0089:
                if (num6 < this.x6088325dec1baa2a)
                {
                    data[num6][num3] += num4 * this.x1e2b930239385f93[num6][num];
                    if ((((uint) num6) | 0x80000000) == 0)
                    {
                        return matrix;
                    }
                    goto Label_0068;
                }
            Label_0093:
                num3++;
            Label_0099:
                if (num3 < this.x57e9faf3ffdc07cc)
                {
                    if (this.x1e2b930239385f93[num][num] == 0.0)
                    {
                        goto Label_0093;
                    }
                    num4 = 0.0;
                    num5 = num;
                }
                else
                {
                    num--;
                    if ((((uint) num2) & 0) != 0)
                    {
                        goto Label_0089;
                    }
                    goto Label_0049;
                }
            Label_00F6:
                if (num5 < this.x6088325dec1baa2a)
                {
                    num4 += this.x1e2b930239385f93[num5][num] * data[num5][num3];
                }
                else
                {
                    num4 = -num4 / this.x1e2b930239385f93[num][num];
                    num6 = num;
                    if ((((uint) num6) + ((uint) num2)) < 0)
                    {
                        goto Label_0176;
                    }
                    goto Label_0089;
                }
                num5++;
                goto Label_00F6;
            Label_0176:
                data[num2][num] = 0.0;
                num2++;
            Label_0188:
                if (num2 < this.x6088325dec1baa2a)
                {
                    goto Label_0176;
                }
                data[num][num] = 1.0;
                num3 = num;
                goto Label_0099;
            }
        }

        public Matrix R
        {
            get
            {
                double[][] data;
                int num;
                int num2;
                Matrix matrix = new Matrix(this.x57e9faf3ffdc07cc, this.x57e9faf3ffdc07cc);
                if (((uint) num) >= 0)
                {
                    data = matrix.Data;
                    num = 0;
                    goto Label_0061;
                }
                if ((((uint) num) | 0x7fffffff) != 0)
                {
                    goto Label_0061;
                }
            Label_0042:
                data[num][num2] = 0.0;
            Label_0050:
                num2++;
            Label_0054:
                if (num2 < this.x57e9faf3ffdc07cc)
                {
                    if (num < num2)
                    {
                        data[num][num2] = this.x1e2b930239385f93[num][num2];
                        goto Label_0050;
                    }
                    if (0 == 0)
                    {
                        if ((((uint) num) & 0) == 0)
                        {
                            if (num == num2)
                            {
                                goto Label_0076;
                            }
                            goto Label_0042;
                        }
                        if (4 == 0)
                        {
                            goto Label_0054;
                        }
                        goto Label_0076;
                    }
                    if (((uint) num2) > uint.MaxValue)
                    {
                        return matrix;
                    }
                    goto Label_00B7;
                }
                num++;
            Label_0061:
                if (num < this.x57e9faf3ffdc07cc)
                {
                    goto Label_00B7;
                }
                return matrix;
            Label_0076:
                data[num][num2] = this.x5f131619608f051b[num];
                goto Label_0050;
            Label_00B7:
                num2 = 0;
                goto Label_0054;
            }
        }
    }
}

