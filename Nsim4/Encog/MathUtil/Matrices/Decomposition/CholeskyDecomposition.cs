namespace Encog.MathUtil.Matrices.Decomposition
{
    using Encog.MathUtil.Matrices;
    using Encog.Util;
    using System;

    public class CholeskyDecomposition
    {
        private readonly int x57e9faf3ffdc07cc;
        private readonly double[][] x9fc3ee03a439f6f0;
        private readonly bool xf8cb6c64791e1e69;

        public CholeskyDecomposition(Matrix matrix)
        {
            double[][] numArray;
            int num;
            double[] numArray2;
            double num2;
            int num3;
            double[] numArray3;
            double num4;
            int num5;
            int num6;
            goto Label_0275;
        Label_0051:
            if (num < this.x57e9faf3ffdc07cc)
            {
                numArray2 = this.x9fc3ee03a439f6f0[num];
                num2 = 0.0;
                goto Label_0218;
            }
            goto Label_0261;
        Label_0127:
            if (num3 < num)
            {
                this.x9fc3ee03a439f6f0[num3] = new double[this.x57e9faf3ffdc07cc];
                if ((((uint) num2) - ((uint) num2)) < 0)
                {
                    goto Label_021D;
                }
                numArray3 = this.x9fc3ee03a439f6f0[num3];
                num4 = 0.0;
                num5 = 0;
                goto Label_0146;
            }
            num2 = numArray[num][num] - num2;
            this.xf8cb6c64791e1e69 &= num2 > 0.0;
            this.x9fc3ee03a439f6f0[num][num] = Math.Sqrt(Math.Max(num2, 0.0));
            if ((((uint) num4) - ((uint) num3)) >= 0)
            {
                if ((((uint) num6) + ((uint) num4)) <= uint.MaxValue)
                {
                    if ((((uint) num6) - ((uint) num4)) > uint.MaxValue)
                    {
                        goto Label_027C;
                    }
                    if ((((uint) num) + ((uint) num4)) < 0)
                    {
                        goto Label_0218;
                    }
                    num6 = num + 1;
                    while (num6 < this.x57e9faf3ffdc07cc)
                    {
                        this.x9fc3ee03a439f6f0[num][num6] = 0.0;
                        if ((((uint) num4) | 3) == 0)
                        {
                            return;
                        }
                        num6++;
                    }
                    num++;
                    if ((((uint) num4) & 0) != 0)
                    {
                        goto Label_0140;
                    }
                    goto Label_0051;
                }
                goto Label_0261;
            }
            goto Label_0127;
        Label_0140:
            num5++;
        Label_0146:
            if (num5 < num3)
            {
                num4 += numArray3[num5] * numArray2[num5];
                goto Label_0140;
            }
            num4 = (numArray[num][num3] - num4) / this.x9fc3ee03a439f6f0[num3][num3];
            numArray2[num3] = num4;
            num2 += num4 * num4;
            this.xf8cb6c64791e1e69 &= numArray[num3][num] == numArray[num][num3];
            num3++;
            goto Label_0127;
        Label_0218:
            num3 = 0;
            goto Label_0127;
        Label_021D:
            this.x9fc3ee03a439f6f0 = EngineArray.AllocateDouble2D(this.x57e9faf3ffdc07cc, this.x57e9faf3ffdc07cc);
            this.xf8cb6c64791e1e69 = matrix.Cols == this.x57e9faf3ffdc07cc;
            num = 0;
            if (((uint) num3) >= 0)
            {
                goto Label_0051;
            }
            goto Label_0127;
        Label_0261:
            if ((((uint) num6) & 0) == 0)
            {
                return;
            }
        Label_0275:
            numArray = matrix.Data;
        Label_027C:
            this.x57e9faf3ffdc07cc = matrix.Rows;
            goto Label_021D;
        }

        public Matrix Solve(Matrix b)
        {
            double[][] numArray;
            int cols;
            int num2;
            int num3;
            int num4;
            int num5;
            int num6;
            int num7;
            if (b.Rows == this.x57e9faf3ffdc07cc)
            {
                goto Label_027B;
            }
            throw new MatrixError("Matrix row dimensions must agree.");
        Label_0049:
            if (num6 < cols)
            {
                goto Label_006D;
            }
            num5--;
        Label_0054:
            if (num5 < 0)
            {
                return new Matrix(numArray);
            }
        Label_0068:
            num6 = 0;
            goto Label_0049;
        Label_006D:
            num7 = num5 + 1;
            while (num7 < this.x57e9faf3ffdc07cc)
            {
                numArray[num5][num6] -= numArray[num7][num6] * this.x9fc3ee03a439f6f0[num7][num5];
                num7++;
            }
            numArray[num5][num6] /= this.x9fc3ee03a439f6f0[num5][num5];
            num6++;
            goto Label_0049;
        Label_00A4:
            num2++;
        Label_00A8:
            if (num2 < this.x57e9faf3ffdc07cc)
            {
                goto Label_01AC;
            }
            num5 = this.x57e9faf3ffdc07cc - 1;
            goto Label_0054;
        Label_00CB:
            if (num4 < num2)
            {
                goto Label_012F;
            }
            if ((((uint) cols) - ((uint) num6)) < 0)
            {
                goto Label_01AC;
            }
            numArray[num2][num3] /= this.x9fc3ee03a439f6f0[num2][num2];
            num3++;
        Label_010E:
            if (num3 < cols)
            {
                num4 = 0;
                if ((((uint) num7) + ((uint) cols)) <= uint.MaxValue)
                {
                    goto Label_016A;
                }
                goto Label_020C;
            }
            if ((((uint) num5) + ((uint) num3)) <= uint.MaxValue)
            {
                goto Label_00A4;
            }
            goto Label_00CB;
        Label_012F:
            numArray[num2][num3] -= numArray[num4][num3] * this.x9fc3ee03a439f6f0[num2][num4];
            if (8 != 0)
            {
                num4++;
                goto Label_00CB;
            }
            goto Label_00A4;
        Label_016A:
            if ((((uint) num6) - ((uint) num6)) < 0)
            {
                goto Label_006D;
            }
            goto Label_00CB;
        Label_01AC:
            num3 = 0;
            goto Label_010E;
        Label_020C:
            numArray = b.GetArrayCopy();
            cols = b.Cols;
            if ((((uint) cols) & 0) == 0)
            {
                if ((((uint) num4) | 15) == 0)
                {
                    goto Label_012F;
                }
                if ((((uint) num7) - ((uint) num7)) < 0)
                {
                    goto Label_010E;
                }
                if ((((uint) num5) - ((uint) num6)) < 0)
                {
                    goto Label_0068;
                }
                num2 = 0;
                goto Label_00A8;
            }
            goto Label_016A;
            if ((((uint) num4) + ((uint) num2)) < 0)
            {
                goto Label_010E;
            }
        Label_027B:
            while (!this.xf8cb6c64791e1e69)
            {
                throw new MatrixError("Matrix is not symmetric positive definite.");
                if ((((uint) num5) + ((uint) cols)) <= uint.MaxValue)
                {
                    break;
                }
            }
            goto Label_020C;
        }

        public bool IsSPD
        {
            get
            {
                return this.xf8cb6c64791e1e69;
            }
        }

        public Matrix L
        {
            get
            {
                return new Matrix(this.x9fc3ee03a439f6f0);
            }
        }
    }
}

