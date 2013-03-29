namespace MatrixLibrary
{
    using System;
    using System.Reflection;
    using System.Runtime.InteropServices;

    public class Matrix
    {
        private double[,] x6b2bf248b3d627d6;

        public Matrix(double[,] Mat)
        {
            this.x6b2bf248b3d627d6 = (double[,]) Mat.Clone();
        }

        public Matrix(int noRows, int noCols)
        {
            this.x6b2bf248b3d627d6 = new double[noRows, noCols];
        }

        public static double[,] Add(double[,] Mat1, double[,] Mat2)
        {
            double[,] numArray;
            int num;
            int num2;
            int num3;
            int num4;
            int num5;
            int num6;
            try
            {
                x665968ea622b9927(Mat1, out num3, out num4);
                x665968ea622b9927(Mat2, out num5, out num6);
                if ((num3 != num5) || (num4 != num6))
                {
                    throw new xd695dad7cec4293d();
                }
                numArray = new double[num3 + 1, num4 + 1];
                num = 0;
                goto Label_004F;
            }
            catch
            {
                throw new x5ed344f47a2ec6bc();
            }
        Label_002B:
            if ((((uint) num4) - ((uint) num5)) < 0)
            {
                goto Label_008E;
            }
            return numArray;
        Label_004F:
            if (num <= num3)
            {
                num2 = 0;
                goto Label_008E;
            }
            if ((((uint) num6) + ((uint) num3)) < 0)
            {
                goto Label_004F;
            }
            if (((uint) num5) >= 0)
            {
                if (((uint) num4) > uint.MaxValue)
                {
                    double[,] numArray2;
                    return numArray2;
                }
                goto Label_002B;
            }
        Label_0089:
            num2++;
        Label_008E:
            if (num2 <= num4)
            {
                numArray[num, num2] = Mat1[num, num2] + Mat2[num, num2];
                goto Label_0089;
            }
            num++;
            goto Label_004F;
        }

        public static Matrix Add(Matrix Mat1, Matrix Mat2)
        {
            return new Matrix(Add(Mat1.x6b2bf248b3d627d6, Mat2.x6b2bf248b3d627d6));
        }

        public static double[,] CrossProduct(double[,] V1, double[,] V2)
        {
            // This item is obfuscated and can not be translated.
            double num;
            double num3;
            int num4;
            int num5;
            int num6;
            bool flag;
            double[,] numArray = new double[3, 1];
            try
            {
                int num7;
                x665968ea622b9927(V1, out num4, out num5);
                x665968ea622b9927(V2, out num6, out num7);
                if (num4 != 2)
                {
                    flag = false;
                }
                else
                {
                    flag = num5 == 0;
                }
                goto Label_01BA;
            }
            catch
            {
                throw new x5ed344f47a2ec6bc();
            }
        Label_0033:
            numArray[2, 0] = num3;
            double[,] numArray2 = numArray;
            if ((((uint) num6) & 0) != 0)
            {
                goto Label_010E;
            }
            return numArray2;
        Label_00E3:
            num = (V1[1, 0] * V2[2, 0]) - (V1[2, 0] * V2[1, 0]);
            double num2 = (V1[2, 0] * V2[0, 0]) - (V1[0, 0] * V2[2, 0]);
            if (-2 == 0)
            {
                goto Label_0129;
            }
            if ((((uint) flag) <= uint.MaxValue) && ((((uint) num5) & 0) == 0))
            {
                num3 = (V1[0, 0] * V2[1, 0]) - (V1[1, 0] * V2[0, 0]);
                numArray[0, 0] = num;
                numArray[1, 0] = num2;
            }
            goto Label_0033;
        Label_010E:
            if ((((uint) num4) + ((uint) num4)) > uint.MaxValue)
            {
                goto Label_016E;
            }
        Label_0127:
            flag = false;
        Label_0129:
            if (flag)
            {
                goto Label_00E3;
            }
            throw new xb36c46347391c047();
            if (0 != 0)
            {
                goto Label_01BA;
            }
            if ((((uint) num2) + ((uint) num5)) <= uint.MaxValue)
            {
                goto Label_00E3;
            }
        Label_0151:
            if (num6 == 2)
            {
                goto Label_0127;
            }
            if ((((uint) num5) - ((uint) num5)) >= 0)
            {
                goto Label_010E;
            }
        Label_016E:
            if ((((uint) num5) + ((uint) flag)) < 0)
            {
                goto Label_0151;
            }
            goto Label_0127;
        Label_01BA:
            if (!flag)
            {
                throw new xb36c46347391c047();
            }
            goto Label_0151;
        }

        public static double[] CrossProduct(double[] V1, double[] V2)
        {
            double num2;
            int num4;
            int num5;
            double[] numArray2;
            bool flag;
            double[] numArray = new double[2];
            try
            {
                x665968ea622b9927(V1, out num4);
                x665968ea622b9927(V2, out num5);
                flag = num4 == 2;
                if (((((uint) num2) - ((uint) num4)) > uint.MaxValue) || !flag)
                {
                    throw new xb36c46347391c047();
                }
                goto Label_00BD;
            }
            catch
            {
                throw new x5ed344f47a2ec6bc();
            }
            return numArray2;
        Label_0075:
            if (!flag)
            {
                throw new xb36c46347391c047();
            }
            double num = (V1[1] * V2[2]) - (V1[2] * V2[1]);
            num2 = (V1[2] * V2[0]) - (V1[0] * V2[2]);
            double num3 = (V1[0] * V2[1]) - (V1[1] * V2[0]);
            numArray[0] = num;
            numArray[1] = num2;
            numArray[2] = num3;
            return numArray;
        Label_00BD:
            flag = num5 == 2;
            goto Label_0075;
            if (((((uint) flag) + ((uint) num4)) >= 0) && ((((uint) num3) + ((uint) num5)) < 0))
            {
                goto Label_0075;
            }
            goto Label_00BD;
        }

        public static Matrix CrossProduct(Matrix V1, Matrix V2)
        {
            return new Matrix(CrossProduct(V1.x6b2bf248b3d627d6, V2.x6b2bf248b3d627d6));
        }

        public static double Det(Matrix Mat)
        {
            return Det(Mat.x6b2bf248b3d627d6);
        }

        public static double Det(double[,] Mat)
        {
            int num;
            int num2;
            int num3;
            int num4;
            int num5;
            double[,] numArray;
            double num6;
            double num7;
            double num8;
            int num9;
            int num10;
            double num11;
            bool flag;
            try
            {
                numArray = (double[,]) Mat.Clone();
                x665968ea622b9927(Mat, out num9, out num10);
                goto Label_0365;
            }
            catch
            {
                throw new x5ed344f47a2ec6bc();
            }
        Label_002D:
            if (!flag)
            {
                num3 = num2 + 1;
                if ((((uint) num11) + ((uint) num)) > uint.MaxValue)
                {
                    goto Label_00B7;
                }
                num4 = num3;
                if ((((uint) num) + ((uint) num6)) >= 0)
                {
                    goto Label_0078;
                }
                goto Label_01BF;
            }
        Label_0034:
            num2++;
        Label_0039:
            if (num2 <= num)
            {
                flag = numArray[num2, num2] != 0.0;
                goto Label_01F1;
            }
            return num8;
        Label_0078:
            flag = num4 <= num;
            if (((uint) flag) < 0)
            {
                goto Label_02A4;
            }
            if (flag)
            {
                num5 = num3;
                goto Label_01BF;
            }
            if (((uint) num11) >= 0)
            {
                if (0 == 0)
                {
                    goto Label_0034;
                }
                goto Label_002D;
            }
            goto Label_0078;
        Label_00B7:
            if ((((uint) num3) + ((uint) flag)) < 0)
            {
                goto Label_002D;
            }
            if ((((uint) num2) - ((uint) num2)) <= uint.MaxValue)
            {
                if ((((uint) num8) - ((uint) num3)) <= uint.MaxValue)
                {
                    if (((uint) num6) <= uint.MaxValue)
                    {
                        num4++;
                        goto Label_0078;
                    }
                    goto Label_0365;
                }
                goto Label_02A4;
            }
            goto Label_01D7;
        Label_01BF:
            if ((((uint) num8) + ((uint) num11)) <= uint.MaxValue)
            {
            Label_00F2:
                flag = num5 <= num;
                if ((((uint) num7) | 2) != 0)
                {
                    if ((((uint) num11) + ((uint) num)) < 0)
                    {
                        goto Label_02DC;
                    }
                    if (flag)
                    {
                        numArray[num4, num5] -= numArray[num4, num2] * (numArray[num2, num5] / num7);
                        num5++;
                        goto Label_00F2;
                    }
                    goto Label_00B7;
                }
            }
        Label_01D7:
            if ((((uint) num11) + ((uint) num3)) > uint.MaxValue)
            {
                goto Label_023B;
            }
            goto Label_01F8;
        Label_01F1:
            if (!flag)
            {
                goto Label_0303;
            }
        Label_01F8:
            num7 = numArray[num2, num2];
            num8 *= num7;
            if ((((uint) num9) & 0) != 0)
            {
                if (0 != 0)
                {
                    goto Label_038E;
                }
                goto Label_033D;
            }
            flag = num2 >= num;
            goto Label_002D;
        Label_023B:
            if (flag)
            {
                num6 = numArray[num4, num5];
                numArray[num4, num5] = numArray[num4, num2];
                numArray[num4, num2] = num6;
                num4++;
            }
            else
            {
                num8 = -num8;
                goto Label_01D7;
            }
        Label_026B:
            flag = num4 <= num;
            goto Label_023B;
        Label_02A4:
            while ((num5 < num) && (numArray[num2, num5] == 0.0))
            {
                num5++;
            }
            flag = numArray[num2, num5] != 0.0;
        Label_02DC:
            if (flag)
            {
                num4 = num2;
                goto Label_026B;
            }
            return 0.0;
        Label_0303:
            num5 = num2;
            goto Label_02A4;
        Label_033D:
            num = num9;
            num8 = 1.0;
            if ((((uint) num11) + ((uint) num11)) < 0)
            {
                goto Label_01F1;
            }
            if ((((uint) num7) + ((uint) num11)) >= 0)
            {
                num2 = 0;
                goto Label_0039;
            }
            if ((((uint) num8) + ((uint) num9)) >= 0)
            {
                goto Label_0303;
            }
            goto Label_02A4;
        Label_0365:
            flag = num9 == num10;
            if ((((uint) num4) + ((uint) num)) <= uint.MaxValue)
            {
                goto Label_038E;
            }
        Label_0386:
            throw new x88b4d441126e16b3();
        Label_038E:
            if (!flag)
            {
                goto Label_0386;
            }
            goto Label_033D;
        }

        public static double DotProduct(double[] V1, double[] V2)
        {
            double num3;
            try
            {
                int num;
                int num2;
                x665968ea622b9927(V1, out num);
                x665968ea622b9927(V2, out num2);
                bool flag = num == 2;
                if (((((uint) num2) + ((uint) num2)) > uint.MaxValue) || !flag)
                {
                    throw new xb36c46347391c047();
                }
                flag = num2 == 2;
                if (0 == 0)
                {
                    if (!flag)
                    {
                        throw new xb36c46347391c047();
                    }
                    num3 = ((V1[0] * V2[0]) + (V1[1] * V2[1])) + (V1[2] * V2[2]);
                }
                return num3;
            }
            catch
            {
                throw new x5ed344f47a2ec6bc();
            }
            return num3;
        }

        public static double DotProduct(Matrix V1, Matrix V2)
        {
            return DotProduct(V1.x6b2bf248b3d627d6, V2.x6b2bf248b3d627d6);
        }

        public static double DotProduct(double[,] V1, double[,] V2)
        {
            int num;
            int num2;
            int num3;
            int num4;
            double num5;
            bool flag;
            try
            {
                x665968ea622b9927(V1, out num, out num2);
                x665968ea622b9927(V2, out num3, out num4);
                goto Label_00D4;
            }
            catch
            {
                throw new x5ed344f47a2ec6bc();
            }
        Label_0043:
            return (((V1[0, 0] * V2[0, 0]) + (V1[1, 0] * V2[1, 0])) + (V1[2, 0] * V2[2, 0]));
            if ((((uint) num5) + ((uint) num4)) < 0)
            {
                goto Label_00E2;
            }
        Label_00D4:
            flag = (num == 2) && (num2 == 0);
        Label_00E2:
            while (!flag)
            {
                if ((((uint) num4) + ((uint) flag)) <= uint.MaxValue)
                {
                    throw new xb36c46347391c047();
                }
            }
            if ((num3 != 2) || (num4 != 0))
            {
                throw new xb36c46347391c047();
            }
            goto Label_0043;
        }

        public static void Eigen(double[,] Mat, out double[,] d, out double[,] v)
        {
            // This item is obfuscated and can not be translated.
        }

        public static void Eigen(Matrix Mat, out Matrix d, out Matrix v)
        {
            double[,] numArray;
            double[,] numArray2;
            Eigen(Mat.x6b2bf248b3d627d6, out numArray, out numArray2);
            d = new Matrix(numArray);
            v = new Matrix(numArray2);
        }

        public override bool Equals(object obj)
        {
            try
            {
                return (this == ((Matrix) obj));
            }
            catch
            {
                return false;
            }
        }

        public static double[,] Identity(int n)
        {
            double[,] numArray = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                numArray[i, i] = 1.0;
            }
            return numArray;
        }

        public static Matrix Inverse(Matrix Mat)
        {
            return new Matrix(Inverse(Mat.x6b2bf248b3d627d6));
        }

        public static double[,] Inverse(double[,] Mat)
        {
            double[,] numArray;
            double[,] numArray2;
            double num;
            double num2;
            int num3;
            int num4;
            int num5;
            int num6;
            int num7;
            int num8;
            int num9;
            int num10;
            int num11;
            bool flag;
            try
            {
                x665968ea622b9927(Mat, out num3, out num4);
                numArray2 = (double[,]) Mat.Clone();
                if (num3 != num4)
                {
                    throw new x88b4d441126e16b3();
                }
                flag = Det(Mat) != 0.0;
                if (((((uint) num2) - ((uint) num8)) >= 0) && flag)
                {
                    goto Label_03BC;
                }
                goto Label_0422;
            }
            catch
            {
                throw new x5ed344f47a2ec6bc();
            }
        Label_002C:
            if (flag)
            {
                flag = Math.Abs(numArray2[num9, num9]) >= 1E-10;
                if ((((uint) flag) - ((uint) num)) >= 0)
                {
                    if (flag)
                    {
                        goto Label_019C;
                    }
                    goto Label_02C5;
                }
                goto Label_028C;
            }
            return numArray;
        Label_0054:
            flag = num9 <= num5;
            goto Label_002C;
        Label_012E:
            flag = num10 <= num5;
        Label_0139:
            if (flag)
            {
                numArray2[num10, num9] = num * numArray2[num10, num9];
                numArray[num10, num9] = num * numArray[num10, num9];
            }
            else
            {
                num10 = 0;
                while (num10 <= num5)
                {
                    flag = num10 != num9;
                    if (((((uint) num3) + ((uint) num2)) >= 0) && ((((uint) num3) - ((uint) num8)) > uint.MaxValue))
                    {
                        goto Label_0422;
                    }
                    if (((uint) num6) < 0)
                    {
                        goto Label_02C5;
                    }
                    if (flag)
                    {
                        num2 = numArray2[num9, num10];
                        if (0 != 0)
                        {
                            goto Label_0139;
                        }
                        num11 = 0;
                        while (num11 <= num5)
                        {
                            numArray2[num11, num10] -= num2 * numArray2[num11, num9];
                            numArray[num11, num10] -= num2 * numArray[num11, num9];
                            num11++;
                        }
                    }
                    num10++;
                }
                num9++;
                goto Label_0054;
            }
            num10++;
            goto Label_012E;
        Label_019C:
            num = 1.0 / numArray2[num9, num9];
            num10 = 0;
            goto Label_012E;
        Label_01C8:
            num10++;
        Label_01CE:
            if (num10 <= num5)
            {
                goto Label_028C;
            }
        Label_01E0:;
            goto Label_019C;
        Label_0221:
            if (0 != 0)
            {
                goto Label_0248;
            }
        Label_020B:
            if (num11 <= num5)
            {
                numArray2[num11, num9] += numArray2[num11, num10];
                if (((uint) num10) <= uint.MaxValue)
                {
                    numArray[num11, num9] += numArray[num11, num10];
                    num11++;
                    goto Label_020B;
                }
                goto Label_019C;
            }
            goto Label_01E0;
        Label_0248:
            if (!flag)
            {
                goto Label_01C8;
            }
            flag = Math.Abs(numArray2[num9, num10]) <= 1E-10;
            if (((((uint) num2) + ((uint) num)) >= 0) && flag)
            {
                goto Label_01C8;
            }
            num11 = 0;
            goto Label_0221;
        Label_028C:
            flag = num10 != num9;
            goto Label_0248;
        Label_02C5:
            num10 = num9 + 1;
            if ((((uint) num) + ((uint) num7)) < 0)
            {
                goto Label_03C4;
            }
            goto Label_01CE;
        Label_02F3:
            if (num8 <= num5)
            {
                num7 = 0;
                if (((uint) num2) >= 0)
                {
                    goto Label_039E;
                }
                if ((((uint) num4) - ((uint) num4)) > uint.MaxValue)
                {
                    goto Label_03BC;
                }
                goto Label_0385;
            }
            num9 = 0;
            goto Label_0054;
        Label_034A:
            if (((uint) num8) > uint.MaxValue)
            {
                goto Label_002C;
            }
            if (!flag)
            {
                numArray[num8, num8] = 1.0;
                if (2 != 0)
                {
                    num8++;
                    goto Label_02F3;
                }
                goto Label_028C;
            }
        Label_0385:
            numArray[num7, num8] = 0.0;
            num7++;
        Label_039E:
            flag = num7 <= num5;
            goto Label_034A;
        Label_03BC:
            num5 = num3;
            num6 = num4;
        Label_03C4:
            numArray = new double[num5 + 1, num5 + 1];
            num8 = 0;
            goto Label_02F3;
        Label_0422:
            throw new x5bf8ec34e656b594();
            if (2 == 0)
            {
                goto Label_0221;
            }
            if (((uint) num4) >= 0)
            {
                goto Label_03BC;
            }
            goto Label_034A;
        }

        public static bool IsEqual(double[,] Mat1, double[,] Mat2)
        {
            // This item is obfuscated and can not be translated.
            int num2;
            int num3;
            int num4;
            int num5;
            int num6;
            int num7;
            bool flag2;
            double num = 1E-14;
            try
            {
                x665968ea622b9927(Mat1, out num2, out num3);
                x665968ea622b9927(Mat2, out num4, out num5);
                if (num2 != num4)
                {
                }
                goto Label_0108;
            }
            catch
            {
                throw new x5ed344f47a2ec6bc();
            }
        Label_0035:
            if (num6 <= num2)
            {
                num7 = 0;
            }
            else
            {
                return true;
            }
        Label_0056:
            if (num7 <= num3)
            {
                flag2 = Math.Abs((double) (Mat1[num6, num7] - Mat2[num6, num7])) <= num;
                if (((((uint) num3) + ((uint) num6)) <= uint.MaxValue) || (((uint) flag2) >= 0))
                {
                    if (!flag2)
                    {
                        return false;
                    }
                    num7++;
                    goto Label_0056;
                }
            }
            else
            {
                num6++;
            }
            goto Label_0035;
        Label_00D8:
            num6 = 0;
            goto Label_0035;
        Label_00E7:
            throw new xd695dad7cec4293d();
            if ((((uint) num5) + ((uint) num6)) <= uint.MaxValue)
            {
                goto Label_00D8;
            }
        Label_0108:
            flag2 = false;
            if (((uint) num6) < 0)
            {
                goto Label_0056;
            }
            if (((uint) num4) <= uint.MaxValue)
            {
                if (!flag2)
                {
                    goto Label_00E7;
                }
                goto Label_00D8;
            }
            if (1 == 0)
            {
                goto Label_0035;
            }
            goto Label_00E7;
        }

        public static bool IsEqual(Matrix Mat1, Matrix Mat2)
        {
            return IsEqual(Mat1.x6b2bf248b3d627d6, Mat2.x6b2bf248b3d627d6);
        }

        public static void LU(Matrix Mat, out Matrix L, out Matrix U, out Matrix P)
        {
            double[,] numArray;
            double[,] numArray2;
            double[,] numArray3;
            LU(Mat.x6b2bf248b3d627d6, out numArray, out numArray2, out numArray3);
            L = new Matrix(numArray);
            U = new Matrix(numArray2);
            P = new Matrix(numArray3);
        }

        public static void LU(double[,] Mat, out double[,] L, out double[,] U, out double[,] P)
        {
            double[,] numArray;
            int num;
            int num2;
            int num3;
            int num4;
            int num5;
            int num6;
            int num7;
            double num8;
            double num9;
            double num10;
            double num11;
            int[] numArray2;
            double[] numArray3;
            double num12;
            int num13;
            double[,] numArray4;
            double[,] numArray5;
            bool flag;
            try
            {
                numArray = (double[,]) Mat.Clone();
                x665968ea622b9927(Mat, out num4, out num5);
                if (num4 != num5)
                {
                    throw new x88b4d441126e16b3();
                }
                num6 = 0;
                num7 = num4;
                num11 = 1E-20;
                numArray2 = new int[num7 + 1];
                numArray3 = new double[num7 * 10];
                goto Label_08DA;
            }
            catch
            {
                throw new x5ed344f47a2ec6bc();
            }
        Label_002C:
            if (!flag)
            {
                if (((uint) num2) >= 0)
                {
                    return;
                }
                goto Label_05D0;
            }
            xb08222189d83333b(P, num, numArray2[num]);
            num++;
        Label_0047:
            flag = num <= num7;
            goto Label_002C;
        Label_0053:
            U = numArray5;
            P = Identity(num7 + 1);
        Label_0062:
            num = 0;
            goto Label_0047;
        Label_008D:
            flag = num <= num7;
            if (flag)
            {
                num2 = 0;
            }
            else
            {
                L = numArray4;
                goto Label_01B5;
            }
        Label_00CA:
            if (num2 <= num13)
            {
                flag = num == 0;
                if ((((uint) num) - ((uint) num5)) < 0)
                {
                    goto Label_039D;
                }
                goto Label_0138;
            }
            num13++;
            num++;
            goto Label_008D;
        Label_00E3:
            flag = num != num2;
            if (!flag)
            {
                numArray4[num, num2] = 1.0;
                if ((((uint) num12) - ((uint) num13)) < 0)
                {
                    goto Label_0707;
                }
                if ((((uint) num12) - ((uint) num10)) < 0)
                {
                    goto Label_01B5;
                }
            }
            numArray5[num7 - num, num7 - num2] = numArray[num7 - num, num7 - num2];
            num2++;
            goto Label_00CA;
        Label_0138:
            if (!flag)
            {
                numArray4[num, num2] = numArray[num, num2];
                if ((((uint) num8) - ((uint) num9)) > uint.MaxValue)
                {
                    goto Label_0062;
                }
                goto Label_00E3;
            }
            if ((((uint) num11) + ((uint) num8)) >= 0)
            {
                goto Label_00E3;
            }
            goto Label_00CA;
        Label_01B5:
            if ((((uint) flag) | 2) != 0)
            {
                if ((((uint) num2) - ((uint) num3)) >= 0)
                {
                    if ((((uint) num) | 0xff) != 0)
                    {
                        goto Label_0053;
                    }
                    goto Label_05D0;
                }
                goto Label_04DB;
            }
        Label_01CD:
            if ((((uint) num11) - ((uint) num12)) < 0)
            {
                goto Label_06E9;
            }
            num = 0;
            goto Label_008D;
        Label_01F9:
            numArray4 = new double[num7 + 1, num7 + 1];
        Label_0208:
            numArray5 = new double[num7 + 1, num7 + 1];
            goto Label_01CD;
        Label_021B:
            numArray[num7, num7] = num11;
        Label_022D:
            num13 = 0;
            goto Label_01F9;
        Label_0232:
            if (num2 <= num7)
            {
                goto Label_06FB;
            }
            flag = numArray[num7, num7] != 0.0;
            if ((((uint) num9) | 4) != 0)
            {
                if (!flag)
                {
                    goto Label_021B;
                }
                goto Label_022D;
            }
            goto Label_01F9;
        Label_027C:
            flag = num <= num7;
            if (flag)
            {
                goto Label_02AD;
            }
        Label_028B:
            num2++;
            if ((((uint) num10) | 0x7fffffff) == 0)
            {
                goto Label_0807;
            }
            goto Label_0232;
        Label_02AD:
            numArray[num, num2] *= num10;
            num++;
            goto Label_027C;
        Label_02D0:
            num10 = 1.0 / numArray[num2, num2];
            if ((((uint) num4) | 0x80000000) == 0)
            {
                goto Label_064F;
            }
            num = num2 + 1;
            goto Label_027C;
        Label_0349:
            numArray2[num2] = num6;
            flag = num2 == num7;
            if (flag)
            {
                goto Label_028B;
            }
            flag = numArray[num2, num2] != 0.0;
            if ((((uint) num) + ((uint) num3)) < 0)
            {
                goto Label_08DA;
            }
            if (((((uint) num5) & 0) == 0) && flag)
            {
                if (((uint) num6) <= uint.MaxValue)
                {
                    goto Label_02D0;
                }
                goto Label_02AD;
            }
            numArray[num2, num2] = num11;
            goto Label_02D0;
        Label_0388:
            if (((uint) num2) > uint.MaxValue)
            {
                goto Label_06FB;
            }
        Label_039D:
            if (flag)
            {
                num10 = numArray[num6, num3];
                numArray[num6, num3] = numArray[num2, num3];
                numArray[num2, num3] = num10;
                if (((uint) num11) > uint.MaxValue)
                {
                    goto Label_008D;
                }
                if ((((uint) flag) + ((uint) num9)) >= 0)
                {
                    num3++;
                    goto Label_03F8;
                }
                goto Label_0388;
            }
            num12 = -num12;
            numArray3[num6] = numArray3[num2];
            goto Label_0349;
        Label_03F8:
            flag = num3 <= num7;
            if ((((uint) num9) + ((uint) num9)) >= 0)
            {
                goto Label_0388;
            }
        Label_041A:
            num3 = 0;
            goto Label_03F8;
        Label_0478:
            flag = num2 == num6;
            if ((((uint) num8) + ((uint) num)) > uint.MaxValue)
            {
                goto Label_039D;
            }
            if (!flag)
            {
                goto Label_041A;
            }
            goto Label_0349;
        Label_04A2:
            num++;
        Label_04A7:
            if (num <= num7)
            {
                num9 = numArray[num, num2];
                flag = num2 <= 0;
                if (0 == 0)
                {
                    if (((((uint) num6) - ((uint) num6)) <= uint.MaxValue) && flag)
                    {
                        goto Label_052E;
                    }
                    num3 = 0;
                    goto Label_0563;
                }
                goto Label_05D0;
            }
            goto Label_0478;
        Label_04DB:
            if (flag)
            {
                goto Label_04A2;
            }
            if ((((uint) num13) & 0) == 0)
            {
                num6 = num;
                num8 = num10;
                if (((uint) num11) < 0)
                {
                    goto Label_0138;
                }
                goto Label_04A2;
            }
            goto Label_0478;
        Label_052E:
            num10 = numArray3[num] * Math.Abs(num9);
            flag = num10 < num8;
            if ((((uint) num4) & 0) == 0)
            {
                goto Label_04DB;
            }
            goto Label_0053;
        Label_0563:
            while (num3 <= (num2 - 1))
            {
                num9 -= numArray[num, num3] * numArray[num3, num2];
                num3++;
            }
            numArray[num, num2] = num9;
            goto Label_052E;
        Label_05A8:
            num = num2;
            goto Label_04A7;
        Label_05D0:
            num8 = 0.0;
            if (((uint) num3) < 0)
            {
                goto Label_090A;
            }
            goto Label_05A8;
        Label_0610:
            flag = num <= (num2 - 1);
            if ((((uint) num7) & 0) == 0)
            {
                if (flag)
                {
                    goto Label_06E9;
                }
                goto Label_05D0;
            }
        Label_062F:
            numArray[num, num2] = num9;
        Label_0643:
            num++;
            goto Label_0610;
        Label_064F:
            if (!flag)
            {
                if ((((uint) num8) - ((uint) num)) <= uint.MaxValue)
                {
                    goto Label_062F;
                }
                if ((((uint) num12) + ((uint) num13)) <= uint.MaxValue)
                {
                    goto Label_06AA;
                }
            }
            num9 -= numArray[num, num3] * numArray[num3, num2];
            num3++;
        Label_069D:
            flag = num3 <= (num - 1);
            goto Label_064F;
        Label_06AA:
            flag = num <= 0;
            if (((uint) num10) > uint.MaxValue)
            {
                goto Label_07E8;
            }
            if (flag)
            {
                goto Label_0643;
            }
        Label_06CD:
            num3 = 0;
            goto Label_069D;
        Label_06E9:
            num9 = numArray[num, num2];
            goto Label_06AA;
        Label_06FB:
            flag = num2 <= 0;
            if (!flag)
            {
                num = 0;
                goto Label_0610;
            }
            goto Label_05D0;
        Label_0707:
            flag = num <= num7;
            if ((((uint) num4) + ((uint) num8)) > uint.MaxValue)
            {
                goto Label_05A8;
            }
            if (flag)
            {
                num8 = 0.0;
                num2 = 0;
                goto Label_082E;
            }
            if ((((uint) flag) & 0) != 0)
            {
                goto Label_06CD;
            }
            num2 = 0;
            if ((((uint) num7) + ((uint) num)) < 0)
            {
                goto Label_06AA;
            }
            goto Label_0232;
        Label_0770:
            numArray3[num] = 1.0 / num8;
            if ((((uint) num6) & 0) != 0)
            {
                goto Label_0563;
            }
            num++;
            if ((((uint) flag) - ((uint) num11)) < 0)
            {
                goto Label_027C;
            }
            if ((((uint) num9) - ((uint) num12)) >= 0)
            {
                goto Label_0707;
            }
            goto Label_06AA;
        Label_07E8:
            flag = num8 != 0.0;
        Label_0807:
            while (!flag)
            {
                throw new x9bc2cd3442d39564();
            }
            goto Label_0770;
        Label_0813:
            num2++;
            if ((((uint) num7) & 0) != 0)
            {
                goto Label_021B;
            }
        Label_082E:
            flag = num2 <= num7;
            if ((((uint) num3) <= uint.MaxValue) && ((((uint) num12) + ((uint) num8)) <= uint.MaxValue))
            {
                if (flag)
                {
                    flag = Math.Abs(numArray[num, num2]) <= num8;
                    if ((0 == 0) && flag)
                    {
                        goto Label_0813;
                    }
                    num8 = Math.Abs(numArray[num, num2]);
                    if ((((uint) num7) - ((uint) num8)) >= 0)
                    {
                        goto Label_0813;
                    }
                }
                else
                {
                    goto Label_07E8;
                }
            }
            goto Label_0770;
        Label_08DA:
            if (((uint) num3) < 0)
            {
                goto Label_0208;
            }
            if ((((uint) num13) | 0x7fffffff) == 0)
            {
                goto Label_01F9;
            }
        Label_090A:
            num12 = 1.0;
            num = 0;
            goto Label_0707;
        }

        public static Matrix Multiply(Matrix Mat1, Matrix Mat2)
        {
            // This item is obfuscated and can not be translated.
            Matrix matrix;
            if (((Mat1.NoRows == 3) && (Mat2.NoRows == 3)) && (Mat1.NoCols != 1))
            {
            }
            bool flag = true;
            if (-2147483648 != 0)
            {
                if (!flag)
                {
                    return new Matrix(CrossProduct(Mat1.x6b2bf248b3d627d6, Mat2.x6b2bf248b3d627d6));
                }
                return new Matrix(Multiply(Mat1.x6b2bf248b3d627d6, Mat2.x6b2bf248b3d627d6));
            }
            return matrix;
        }

        public static double[,] Multiply(double[,] Mat1, double[,] Mat2)
        {
            double[,] numArray;
            int num;
            int num2;
            int num3;
            int num4;
            int num6;
            int num7;
            int num8;
            bool flag;
            double num5 = 0.0;
            try
            {
                x665968ea622b9927(Mat1, out num, out num2);
                x665968ea622b9927(Mat2, out num3, out num4);
                goto Label_0199;
            }
            catch
            {
                throw new x5ed344f47a2ec6bc();
            }
        Label_004C:
            num6++;
        Label_0052:
            if (num6 <= num)
            {
                num7 = 0;
                goto Label_00BD;
            }
            return numArray;
        Label_006B:
            if (flag)
            {
                num8 = 0;
                goto Label_0164;
            }
            if ((((uint) num2) - ((uint) num6)) >= 0)
            {
                if ((((uint) num7) + ((uint) num2)) <= uint.MaxValue)
                {
                    if ((((uint) num2) + ((uint) num7)) > uint.MaxValue)
                    {
                        double[,] numArray2;
                        return numArray2;
                    }
                    goto Label_004C;
                }
                if ((((uint) num4) - ((uint) flag)) <= uint.MaxValue)
                {
                    goto Label_0199;
                }
                goto Label_0142;
            }
            if (((uint) num6) <= uint.MaxValue)
            {
                goto Label_00CA;
            }
        Label_009F:
            numArray[num6, num7] = num5;
            num5 = 0.0;
            num7++;
        Label_00BD:
            flag = num7 <= num4;
            goto Label_006B;
        Label_00CA:
            if (((uint) num3) < 0)
            {
                return numArray;
            }
            if (!flag)
            {
                if (((uint) num7) > uint.MaxValue)
                {
                    goto Label_0052;
                }
                if (((uint) num2) >= 0)
                {
                    goto Label_009F;
                }
                goto Label_006B;
            }
        Label_0142:
            num5 += Mat1[num6, num8] * Mat2[num8, num7];
            num8++;
        Label_0164:
            flag = num8 <= num2;
            goto Label_00CA;
        Label_0184:
            numArray = new double[num + 1, num4 + 1];
            num6 = 0;
            goto Label_0052;
        Label_0199:
            if (num2 != num3)
            {
                throw new xd695dad7cec4293d();
            }
            goto Label_0184;
            if (((uint) num7) < 0)
            {
                goto Label_009F;
            }
            goto Label_0184;
        }

        public static double[,] OneD_2_TwoD(double[] Mat)
        {
            int num;
            double[,] numArray;
            int num2;
            double[,] numArray2;
            bool flag;
            try
            {
                x665968ea622b9927(Mat, out num);
                goto Label_0063;
            }
            catch
            {
                throw new x5ed344f47a2ec6bc();
            }
            return numArray2;
        Label_0063:
            numArray = new double[num + 1, 1];
            if ((((uint) num2) & 0) != 0)
            {
                goto Label_0063;
            }
            num2 = 0;
        Label_0044:
            flag = num2 <= num;
            if (flag)
            {
                numArray[num2, 0] = Mat[num2];
                num2++;
                goto Label_0044;
            }
            if (((uint) num) <= uint.MaxValue)
            {
                if (((uint) flag) >= 0)
                {
                    numArray2 = numArray;
                }
            }
            else
            {
                goto Label_0063;
            }
            if (0 != 0)
            {
            }
            return numArray2;
        }

        public static Matrix operator +(Matrix Mat1, Matrix Mat2)
        {
            return new Matrix(Add(Mat1.x6b2bf248b3d627d6, Mat2.x6b2bf248b3d627d6));
        }

        public static Matrix operator /(Matrix Mat, double Value)
        {
            return new Matrix(ScalarDivide(Value, Mat.x6b2bf248b3d627d6));
        }

        public static bool operator ==(Matrix Mat1, Matrix Mat2)
        {
            return IsEqual(Mat1.x6b2bf248b3d627d6, Mat2.x6b2bf248b3d627d6);
        }

        public static bool operator !=(Matrix Mat1, Matrix Mat2)
        {
            return !IsEqual(Mat1.x6b2bf248b3d627d6, Mat2.x6b2bf248b3d627d6);
        }

        public static Matrix operator *(Matrix Mat1, Matrix Mat2)
        {
            if (Mat1.NoRows == 3)
            {
                bool flag;
                while ((Mat2.NoRows == 3) && ((((uint) flag) - ((uint) flag)) > uint.MaxValue))
                {
                }
            }
            if ((Mat1.NoCols != 1) || (Mat1.NoCols != 1))
            {
                return new Matrix(Multiply(Mat1.x6b2bf248b3d627d6, Mat2.x6b2bf248b3d627d6));
            }
            return new Matrix(CrossProduct(Mat1.x6b2bf248b3d627d6, Mat2.x6b2bf248b3d627d6));
        }

        public static Matrix operator *(Matrix Mat, double Value)
        {
            return new Matrix(ScalarMultiply(Value, Mat.x6b2bf248b3d627d6));
        }

        public static Matrix operator *(double Value, Matrix Mat)
        {
            return new Matrix(ScalarMultiply(Value, Mat.x6b2bf248b3d627d6));
        }

        public static Matrix operator -(Matrix Mat1, Matrix Mat2)
        {
            return new Matrix(Subtract(Mat1.x6b2bf248b3d627d6, Mat2.x6b2bf248b3d627d6));
        }

        public static double[,] PINV(double[,] Mat)
        {
            int num;
            int num2;
            int num3;
            int num4;
            int num5;
            double[,] numArray2;
            double[,] numArray3;
            double[,] numArray4;
            double num6;
            double num7;
            double num8;
            double[,] numArray5;
            double[,] numArray6;
            double[,] numArray7;
            double[,] numArray8;
            bool flag;
            double num9 = 0.0;
            try
            {
                double[,] numArray = (double[,]) Mat.Clone();
                x665968ea622b9927(Mat, out num2, out num3);
                goto Label_0464;
            }
            catch
            {
                throw new x5ed344f47a2ec6bc();
            }
        Label_006D:
            if ((((uint) num4) | 0xff) != 0)
            {
                return numArray8;
            }
        Label_0091:
            num++;
        Label_0096:
            flag = num < num2;
            if ((((uint) num9) | 1) == 0)
            {
                goto Label_033F;
            }
            if (flag)
            {
                goto Label_017F;
            }
            numArray8 = Transpose(numArray4);
            if (((uint) flag) <= uint.MaxValue)
            {
                goto Label_006D;
            }
            if ((((uint) num7) | 0x80000000) != 0)
            {
                return numArray8;
            }
            goto Label_0106;
        Label_00D0:
            flag = num4 < num3;
            if (flag)
            {
                num5 = 0;
                if ((((uint) flag) + ((uint) num9)) < 0)
                {
                    goto Label_01EA;
                }
            Label_0164:
                flag = num5 < num3;
                if (!flag)
                {
                    numArray4[num, num4] = num7;
                    num7 = 0.0;
                    if (((uint) num) <= uint.MaxValue)
                    {
                        goto Label_0106;
                    }
                }
                else
                {
                    num7 += numArray3[num, num5] * numArray7[num4, num5];
                    num5++;
                    goto Label_0164;
                }
                goto Label_017F;
            }
            goto Label_0091;
        Label_0106:
            if (((uint) flag) < 0)
            {
                goto Label_0427;
            }
            num4++;
            goto Label_00D0;
        Label_017F:
            num4 = 0;
            goto Label_00D0;
        Label_01BB:
            if (flag)
            {
                num5 = 0;
                goto Label_0250;
            }
            if ((((uint) num7) + ((uint) num5)) < 0)
            {
                return numArray8;
            }
            num++;
        Label_01E2:
            flag = num < num2;
            if (flag)
            {
                num4 = 0;
                if ((((uint) num8) - ((uint) num8)) >= 0)
                {
                    goto Label_02BE;
                }
                goto Label_0464;
            }
            num = 0;
            goto Label_0096;
        Label_01EA:
            num7 = 0.0;
            num4++;
        Label_01FC:
            flag = num4 < num3;
            if (((uint) num7) > uint.MaxValue)
            {
                goto Label_0096;
            }
            goto Label_01BB;
        Label_022D:
            if (num5 < num3)
            {
                if (numArray2[num5, num4] <= num8)
                {
                    goto Label_02A8;
                }
                goto Label_0283;
            }
            if ((((uint) num9) + ((uint) num5)) >= 0)
            {
                numArray3[num, num4] = num7;
                goto Label_01EA;
            }
        Label_0250:
            if ((((uint) num3) + ((uint) num2)) <= uint.MaxValue)
            {
                goto Label_022D;
            }
        Label_0283:
            num7 += numArray5[num, num5] * (1.0 / numArray2[num5, num4]);
        Label_02A8:
            num5++;
            goto Label_022D;
        Label_02BE:
            if (((uint) num7) < 0)
            {
                goto Label_00D0;
            }
            goto Label_01FC;
        Label_02FA:
            num = 0;
        Label_0314:
            flag = num < num3;
            if (flag)
            {
                numArray2[num, num] = numArray6[num, num];
                num++;
                goto Label_0314;
            }
            num = 0;
            if ((((uint) num) + ((uint) num8)) >= 0)
            {
                goto Label_01E2;
            }
        Label_0334:
            if (!flag)
            {
                num8 = (num2 * num9) * num6;
                goto Label_02FA;
            }
            if (0 == 0)
            {
                num8 = (num3 * num9) * num6;
                goto Label_02FA;
            }
            goto Label_01E2;
        Label_033F:
            if (((uint) num5) < 0)
            {
                goto Label_01BB;
            }
            flag = num2 <= num3;
            goto Label_0334;
        Label_041E:
            numArray4 = new double[num2, num3];
        Label_0427:
            numArray2 = new double[num3, num3];
            num7 = 0.0;
            num = 0;
        Label_03A2:
            flag = num <= numArray6.GetUpperBound(0);
            if (flag)
            {
                flag = num != 0;
                if (((((uint) num6) + ((uint) flag)) > uint.MaxValue) || !flag)
                {
                    num9 = numArray6[0, 0];
                }
            }
            else
            {
                goto Label_049C;
            }
            flag = num9 >= numArray6[num, num];
            if ((((uint) num7) + ((uint) num9)) <= uint.MaxValue)
            {
                if ((((uint) num) + ((uint) num5)) <= uint.MaxValue)
                {
                    if (((uint) num5) >= 0)
                    {
                        if (!flag)
                        {
                            num9 = numArray6[num, num];
                        }
                        num++;
                        goto Label_03A2;
                    }
                    goto Label_049C;
                }
            }
            else
            {
                goto Label_041E;
            }
        Label_0464:
            SVD(Mat, out numArray6, out numArray5, out numArray7);
            num6 = 2.2204E-16;
            num2++;
            num3++;
            numArray3 = new double[num2, num3];
            goto Label_041E;
        Label_049C:
            if ((((uint) flag) | 3) != 0)
            {
                goto Label_033F;
            }
            goto Label_02BE;
        }

        public static Matrix PINV(Matrix Mat)
        {
            return new Matrix(PINV(Mat.x6b2bf248b3d627d6));
        }

        public static string PrintMat(double[,] Mat)
        {
            int num;
            int num2;
            int num3;
            int num4;
            int num5;
            int num6;
            string str;
            int length;
            int[] numArray;
            string str2;
            string str3;
            string str4;
            string str5;
            bool flag;
            try
            {
                x665968ea622b9927(Mat, out num, out num2);
                goto Label_0458;
            }
            catch
            {
                throw new x5ed344f47a2ec6bc();
            }
        Label_003B:
            if (flag)
            {
                num5 = 0;
                goto Label_00DE;
            }
            return str4;
        Label_004B:
            str3 = "";
            if (0 != 0)
            {
                goto Label_0460;
            }
            num4++;
        Label_005D:
            flag = num4 <= num;
            if (((uint) num) <= uint.MaxValue)
            {
                goto Label_003B;
            }
            return str5;
        Label_0085:
            str4 = str4 + str3;
            if (((uint) num2) < 0)
            {
                goto Label_02DD;
            }
            goto Label_004B;
        Label_00C9:
            if (((uint) num2) > uint.MaxValue)
            {
                goto Label_02D3;
            }
        Label_00DE:
            flag = num5 <= num2;
        Label_00E8:
            if (flag)
            {
                flag = num4 != 0;
                if (flag)
                {
                    goto Label_029D;
                }
                goto Label_03D8;
            }
            flag = num4 == num;
            if (!flag)
            {
                str4 = str4 + str3 + "\n";
                str3 = "";
            }
            goto Label_0085;
        Label_00FA:
            str3 = str3 + "  " + Mat[num4, num5].ToString("0.0000");
            num5++;
            if ((((uint) num3) - ((uint) num2)) <= uint.MaxValue)
            {
                goto Label_00C9;
            }
        Label_019F:
            flag = numArray[num5] <= length;
            if (flag)
            {
                goto Label_00FA;
            }
            if (4 != 0)
            {
                if ((((uint) num4) + ((uint) num5)) >= 0)
                {
                    goto Label_0277;
                }
                goto Label_021D;
            }
        Label_01BB:
            num3++;
        Label_01BF:
            flag = num3 <= (numArray[num5] - length);
            if (flag)
            {
                str3 = str3 + "  ";
                goto Label_0262;
            }
            str3 = str3 + " ";
            goto Label_00FA;
        Label_0208:
            num3 = 1;
            goto Label_01BF;
        Label_021D:
            if (!str.StartsWith("-"))
            {
                length = str.Length;
                goto Label_019F;
            }
        Label_0235:
            length = str.Length;
            flag = numArray[num5] < length;
            if ((((uint) num6) | 15) != 0)
            {
                if (flag)
                {
                    goto Label_00FA;
                }
                goto Label_0208;
            }
        Label_0262:
            if (((uint) num6) >= 0)
            {
                goto Label_01BB;
            }
        Label_0277:
            if (((uint) num) <= uint.MaxValue)
            {
                num3 = 1;
            Label_0155:
                flag = num3 <= (numArray[num5] - length);
                if ((((uint) num) | 2) != 0)
                {
                    if (flag)
                    {
                        str3 = str3 + "  ";
                        num3++;
                        goto Label_0155;
                    }
                    goto Label_00FA;
                }
                goto Label_00C9;
            }
            goto Label_004B;
        Label_029D:
            str = Mat[num4, num5].ToString("0.0000");
            goto Label_021D;
        Label_02B9:
            if (((uint) num4) < 0)
            {
                goto Label_00E8;
            }
            goto Label_029D;
        Label_02D3:
            numArray[num5] = numArray[num5];
        Label_02DD:
            if (((((uint) num2) + ((uint) length)) >= 0) && (((uint) num6) <= uint.MaxValue))
            {
                goto Label_02B9;
            }
        Label_02F5:
            if (!flag)
            {
                goto Label_02D3;
            }
            goto Label_02B9;
        Label_0312:
            num6++;
        Label_0319:
            flag = num6 <= num;
            if (!flag)
            {
                flag = !str2.StartsWith("-");
                goto Label_02F5;
            }
        Label_0368:
            str = Mat[num6, num5].ToString("0.0000");
            length = str.Length;
            if ((((uint) num3) - ((uint) num2)) > uint.MaxValue)
            {
                goto Label_004B;
            }
            flag = numArray[num5] >= length;
            if (flag)
            {
                goto Label_0312;
            }
            if ((((uint) num4) & 0) != 0)
            {
                goto Label_0235;
            }
            numArray[num5] = length;
            str2 = str;
            if (0 == 0)
            {
                goto Label_0312;
            }
            goto Label_0368;
        Label_03D8:
            numArray[num5] = 0;
            num6 = 0;
            goto Label_0319;
        Label_0458:
            str4 = "";
        Label_0460:
            str2 = "";
            if ((((uint) num2) + ((uint) num4)) < 0)
            {
                goto Label_0085;
            }
            str3 = "";
            if ((((uint) num3) - ((uint) num5)) < 0)
            {
                goto Label_0208;
            }
            numArray = new int[num2 + 1];
            num4 = 0;
            if (((uint) num3) <= uint.MaxValue)
            {
                if ((((uint) num6) + ((uint) flag)) > uint.MaxValue)
                {
                    goto Label_03D8;
                }
                goto Label_005D;
            }
            if (((uint) num3) <= uint.MaxValue)
            {
                goto Label_0368;
            }
            goto Label_0458;
        }

        public static string PrintMat(Matrix Mat)
        {
            return PrintMat(Mat.x6b2bf248b3d627d6);
        }

        public static int Rank(double[,] Mat)
        {
            double[,] numArray;
            double[,] numArray2;
            double[,] numArray3;
            double num4;
            int num5;
            bool flag;
            int num = 0;
            try
            {
                int num2;
                int num3;
                x665968ea622b9927(Mat, out num2, out num3);
                goto Label_0098;
            }
            catch
            {
                throw new x5ed344f47a2ec6bc();
            }
        Label_001F:
            if (num5 <= numArray.GetUpperBound(0))
            {
            Label_0050:
                flag = Math.Abs(numArray[num5, num5]) <= num4;
                if (!flag)
                {
                    num++;
                    if (((uint) num) > uint.MaxValue)
                    {
                        goto Label_0050;
                    }
                }
            }
            else
            {
                return num;
            }
            num5++;
            goto Label_001F;
            if (((uint) flag) < 0)
            {
                goto Label_001F;
            }
        Label_0098:
            num4 = 2.2204E-16;
            SVD(Mat, out numArray, out numArray2, out numArray3);
            num5 = 0;
            goto Label_001F;
        }

        public static int Rank(Matrix Mat)
        {
            return Rank(Mat.x6b2bf248b3d627d6);
        }

        public static Matrix ScalarDivide(double Value, Matrix Mat)
        {
            return new Matrix(ScalarDivide(Value, Mat.x6b2bf248b3d627d6));
        }

        public static double[,] ScalarDivide(double Value, double[,] Mat)
        {
            int num;
            int num2;
            int num3;
            int num4;
            double[,] numArray;
            bool flag;
            try
            {
                x665968ea622b9927(Mat, out num3, out num4);
                goto Label_006B;
            }
            catch
            {
                throw new x5ed344f47a2ec6bc();
            }
        Label_001A:
            if (flag)
            {
                numArray[num, num2] = Mat[num, num2] / Value;
                num2++;
                goto Label_0050;
            }
            num++;
        Label_0022:
            if (num > num3)
            {
                return numArray;
            }
            num2 = 0;
        Label_0050:
            flag = num2 <= num4;
            if (((uint) Value) <= uint.MaxValue)
            {
                goto Label_001A;
            }
        Label_006B:
            numArray = new double[num3 + 1, num4 + 1];
            num = 0;
            if (((uint) num) < 0)
            {
                return numArray;
            }
            goto Label_0022;
        }

        public static Matrix ScalarMultiply(double Value, Matrix Mat)
        {
            return new Matrix(ScalarMultiply(Value, Mat.x6b2bf248b3d627d6));
        }

        public static double[,] ScalarMultiply(double Value, double[,] Mat)
        {
            int num;
            int num2;
            int num3;
            int num4;
            double[,] numArray;
            double[,] numArray2;
            bool flag;
            try
            {
                x665968ea622b9927(Mat, out num3, out num4);
                numArray = new double[num3 + 1, num4 + 1];
                num = 0;
                goto Label_0042;
            }
            catch
            {
                throw new x5ed344f47a2ec6bc();
            }
            return numArray2;
        Label_0042:
            flag = num <= num3;
            if (flag)
            {
                num2 = 0;
                if ((((uint) Value) + ((uint) flag)) < 0)
                {
                    return numArray2;
                }
            }
            else
            {
                return numArray;
            }
            while (true)
            {
                flag = num2 <= num4;
                if (flag)
                {
                    numArray[num, num2] = Mat[num, num2] * Value;
                }
                else
                {
                    num++;
                    goto Label_0042;
                }
                if ((((uint) num) < 0) || (((uint) num) > uint.MaxValue))
                {
                    return numArray;
                }
                num2++;
            }
        }

        public static double[,] SolveLinear(double[,] MatA, double[,] MatB)
        {
            double[,] numArray;
            double[,] numArray2;
            double num;
            int num2;
            int num3;
            int num4;
            int num5;
            int num6;
            int num7;
            int num8;
            int num9;
            int num10;
            double num11;
            double num12;
            double num13;
            double num14;
            int[] numArray3;
            double[] numArray4;
            double num15;
            bool flag;
            try
            {
                numArray = (double[,]) MatA.Clone();
                numArray2 = (double[,]) MatB.Clone();
                x665968ea622b9927(numArray, out num7, out num8);
                flag = num7 == num8;
                if ((2 == 0) || !flag)
                {
                    throw new x88b4d441126e16b3();
                }
                goto Label_08FF;
            }
            catch
            {
                throw new x5ed344f47a2ec6bc();
            }
            return numArray2;
        Label_0070:
            flag = num2 >= 0;
            if (0 != 0)
            {
                goto Label_03CD;
            }
            if (flag)
            {
                num = numArray2[num2, 0];
                if (num2 >= num10)
                {
                    goto Label_009E;
                }
                num4 = num2 + 1;
            }
            else
            {
                return numArray2;
            }
        Label_008E:
            while (num4 <= num10)
            {
                num -= numArray[num2, num4] * numArray2[num4, 0];
                num4++;
            }
        Label_009E:
            numArray2[num2, 0] = num / numArray[num2, num2];
            num2--;
            if (((uint) num14) < 0)
            {
                goto Label_0335;
            }
            goto Label_0070;
        Label_010B:
            if ((((uint) num4) - ((uint) num2)) > uint.MaxValue)
            {
                goto Label_0160;
            }
        Label_013D:
            numArray2[num2, 0] = num;
            num2++;
        Label_014B:
            flag = num2 <= num10;
            if (flag)
            {
                num6 = numArray3[num2];
                if ((((uint) num) - ((uint) num8)) > uint.MaxValue)
                {
                    goto Label_01D8;
                }
                if ((((uint) num13) | 2) != 0)
                {
                    num = numArray2[num6, 0];
                    numArray2[num6, 0] = numArray2[num2, 0];
                    flag = num3 == -1;
                    goto Label_0181;
                }
                goto Label_019C;
            }
            num2 = num10;
            goto Label_0070;
        Label_0160:
            if (!flag)
            {
                num3 = num2;
                goto Label_010B;
            }
            if ((((uint) num13) - ((uint) num2)) < 0)
            {
                goto Label_0632;
            }
            if ((((uint) num9) + ((uint) num2)) < 0)
            {
                goto Label_010B;
            }
            goto Label_013D;
        Label_0181:
            if (!flag)
            {
                num4 = num3;
                goto Label_01DE;
            }
            flag = num == 0.0;
            goto Label_0160;
        Label_019C:
            if (((uint) num3) < 0)
            {
                goto Label_04A5;
            }
            if (flag)
            {
                num -= numArray[num2, num4] * numArray2[num4, 0];
            }
            else
            {
                goto Label_013D;
            }
        Label_01D8:
            num4++;
        Label_01DE:
            flag = num4 <= (num2 - 1);
            goto Label_019C;
        Label_025C:
            num3 = -1;
            num2 = 0;
            if ((((uint) num8) + ((uint) num5)) <= uint.MaxValue)
            {
                if ((((uint) num15) + ((uint) flag)) <= uint.MaxValue)
                {
                    if ((((uint) num10) - ((uint) num5)) <= uint.MaxValue)
                    {
                        goto Label_014B;
                    }
                    goto Label_03CD;
                }
                if (((uint) num4) > uint.MaxValue)
                {
                    goto Label_08FF;
                }
                if ((((uint) num4) - ((uint) num)) < 0)
                {
                    goto Label_0400;
                }
                goto Label_039B;
            }
            if ((((uint) num13) | 4) != 0)
            {
                goto Label_0331;
            }
            if ((((uint) num) - ((uint) num13)) >= 0)
            {
                goto Label_02F3;
            }
            goto Label_02D8;
        Label_0263:
            flag = numArray[num10, num10] != 0.0;
            if (flag)
            {
                goto Label_025C;
            }
        Label_027F:
            numArray[num10, num10] = num14;
            goto Label_025C;
        Label_02D8:
            num4++;
        Label_02DF:
            if (num4 <= num10)
            {
                flag = num4 <= 0;
                if (flag)
                {
                    goto Label_05ED;
                }
                if ((((uint) num10) + ((uint) flag)) > uint.MaxValue)
                {
                    goto Label_02D8;
                }
                num2 = 0;
                if ((((uint) num8) & 0) != 0)
                {
                    goto Label_008E;
                }
                if ((((uint) num10) + ((uint) num14)) <= uint.MaxValue)
                {
                    goto Label_0653;
                }
                goto Label_06CF;
            }
            goto Label_0263;
        Label_02F3:
            if (flag)
            {
                goto Label_039B;
            }
        Label_02FA:
            if ((((uint) num6) & 0) != 0)
            {
                goto Label_046B;
            }
            if ((((uint) num3) | uint.MaxValue) == 0)
            {
                goto Label_052E;
            }
            goto Label_02D8;
        Label_0331:
            num2++;
        Label_0335:
            flag = num2 <= num10;
            if (((uint) num) >= 0)
            {
                goto Label_02F3;
            }
            goto Label_0263;
        Label_039B:
            numArray[num2, num4] *= num13;
            goto Label_0331;
        Label_03CD:
            num13 = 1.0 / numArray[num4, num4];
            num2 = num4 + 1;
            goto Label_0335;
        Label_0400:
            if (!flag)
            {
                numArray[num4, num4] = num14;
            }
            goto Label_03CD;
        Label_0406:
            numArray3[num4] = num9;
            flag = num4 == num10;
            if (flag)
            {
                goto Label_02D8;
            }
            if ((((uint) num6) + ((uint) flag)) > uint.MaxValue)
            {
                goto Label_02FA;
            }
            flag = numArray[num4, num4] != 0.0;
            goto Label_0400;
        Label_046B:
            if ((((uint) num8) - ((uint) num8)) > uint.MaxValue)
            {
                goto Label_0400;
            }
            num15 = -num15;
        Label_0488:
            numArray4[num9] = numArray4[num4];
            goto Label_0406;
        Label_0499:
            numArray[num4, num5] = num13;
        Label_04A5:
            num5++;
        Label_04AC:
            flag = num5 <= num10;
            if (flag)
            {
                num13 = numArray[num9, num5];
                numArray[num9, num5] = numArray[num4, num5];
                if ((((uint) num) - ((uint) num15)) <= uint.MaxValue)
                {
                    goto Label_0499;
                }
            }
            else
            {
                goto Label_046B;
            }
        Label_0512:
            if (flag)
            {
                num12 = numArray[num2, num4];
                flag = num4 <= 0;
                if (((uint) num15) <= uint.MaxValue)
                {
                    if (flag)
                    {
                        goto Label_0568;
                    }
                    num5 = 0;
                }
                goto Label_058C;
            }
            flag = num4 == num9;
            if (!flag)
            {
                num5 = 0;
            }
            else
            {
                goto Label_0406;
            }
            if ((((uint) num8) + ((uint) num13)) < 0)
            {
                goto Label_05BA;
            }
            goto Label_04AC;
        Label_052E:
            flag = num2 <= num10;
            if ((((uint) num) | 8) != 0)
            {
                goto Label_0512;
            }
            goto Label_0499;
        Label_0568:
            num13 = numArray4[num2] * Math.Abs(num12);
            if (num13 >= num11)
            {
                num9 = num2;
                num11 = num13;
            }
            num2++;
            goto Label_052E;
        Label_058C:
            flag = num5 <= (num4 - 1);
            if (!flag)
            {
                numArray[num2, num4] = num12;
                goto Label_0568;
            }
        Label_05BA:
            num12 -= numArray[num2, num5] * numArray[num5, num4];
            if (((uint) num6) < 0)
            {
                goto Label_0632;
            }
            num5++;
            goto Label_058C;
        Label_05ED:
            num11 = 0.0;
            num2 = num4;
            goto Label_052E;
        Label_0632:
            if (!flag)
            {
                num5 = 0;
                if ((((uint) num15) & 0) != 0)
                {
                    goto Label_0488;
                }
                goto Label_06A6;
            }
            if (((uint) num15) < 0)
            {
                goto Label_03CD;
            }
        Label_064E:
            num2++;
        Label_0653:
            if (num2 <= (num4 - 1))
            {
                num12 = numArray[num2, num4];
                goto Label_06CF;
            }
            goto Label_05ED;
        Label_06A6:
            flag = num5 <= (num2 - 1);
            if ((((uint) num13) + ((uint) num13)) < 0)
            {
                goto Label_052E;
            }
            if (!flag)
            {
                numArray[num2, num4] = num12;
                goto Label_064E;
            }
            num12 -= numArray[num2, num5] * numArray[num5, num4];
            num5++;
            goto Label_06A6;
        Label_06CF:
            flag = num2 <= 0;
            goto Label_0632;
        Label_0779:
            if (num2 <= num10)
            {
                num11 = 0.0;
                num4 = 0;
                goto Label_07B9;
            }
            num4 = 0;
            goto Label_02DF;
        Label_07B3:
            num4++;
        Label_07B9:
            if (num4 <= num10)
            {
                if (Math.Abs(numArray[num2, num4]) <= num11)
                {
                    goto Label_07B3;
                }
                num11 = Math.Abs(numArray[num2, num4]);
                if (((uint) num3) >= 0)
                {
                    if ((((uint) num12) + ((uint) num11)) <= uint.MaxValue)
                    {
                        goto Label_07B3;
                    }
                    goto Label_06CF;
                }
            }
            else
            {
                flag = num11 != 0.0;
                if ((((uint) num4) - ((uint) flag)) > uint.MaxValue)
                {
                    goto Label_06A6;
                }
                if (!flag)
                {
                    throw new x9bc2cd3442d39564();
                }
                numArray4[num2] = 1.0 / num11;
                num2++;
                if ((((uint) num9) - ((uint) num)) <= uint.MaxValue)
                {
                    goto Label_0779;
                }
                goto Label_02DF;
            }
        Label_0861:
            num15 = 1.0;
            num2 = 0;
            goto Label_0779;
        Label_08FF:
            flag = (numArray2.GetUpperBound(0) == num7) && (numArray2.GetUpperBound(1) == 0);
            if (!flag)
            {
                throw new xd695dad7cec4293d();
            }
            num9 = 0;
            if ((((uint) num2) + ((uint) num)) >= 0)
            {
                num10 = num7;
                num14 = 1E-20;
                if ((((uint) num11) & 0) != 0)
                {
                    goto Label_0181;
                }
                numArray3 = new int[num10 + 1];
                numArray4 = new double[num10 * 10];
                goto Label_0861;
            }
            goto Label_027F;
        }

        public static Matrix SolveLinear(Matrix MatA, Matrix MatB)
        {
            return new Matrix(SolveLinear(MatA.x6b2bf248b3d627d6, MatB.x6b2bf248b3d627d6));
        }

        public static double[,] Subtract(double[,] Mat1, double[,] Mat2)
        {
            // This item is obfuscated and can not be translated.
        }

        public static Matrix Subtract(Matrix Mat1, Matrix Mat2)
        {
            return new Matrix(Subtract(Mat1.x6b2bf248b3d627d6, Mat2.x6b2bf248b3d627d6));
        }

        public static void SVD(Matrix Mat, out Matrix S, out Matrix U, out Matrix V)
        {
            double[,] numArray;
            double[,] numArray2;
            double[,] numArray3;
            SVD(Mat.x6b2bf248b3d627d6, out numArray, out numArray2, out numArray3);
            S = new Matrix(numArray);
            U = new Matrix(numArray2);
            V = new Matrix(numArray3);
        }

        public static void SVD(double[,] Mat_, out double[,] S_, out double[,] U_, out double[,] V_)
        {
            double num35;
            double num1;
            int num;
            int num2;
            int num3;
            int num4;
            int num5;
            int num6;
            double[] numArray;
            double[,] numArray2;
            double[,] numArray3;
            int num7;
            int num8;
            int num9;
            int num10;
            int num11;
            int num12;
            int num13;
            int num14;
            int num15;
            int num16;
            double[,] numArray4;
            double[,] numArray5;
            double[,] numArray6;
            double num17;
            double num18;
            double num19;
            double num20;
            double num21;
            double num22;
            double num23;
            double num24;
            double num25;
            double num26;
            double[] numArray7;
            bool flag;
            double num27;
            try
            {
                x665968ea622b9927(Mat_, out num, out num2);
                goto Label_1ECC;
            }
            catch
            {
                throw new x5ed344f47a2ec6bc();
            }
        Label_0020:
            U_ = numArray4;
            goto Label_13E2;
        Label_0029:
            if (num13 <= num4)
            {
                num15 = 1;
            }
            else
            {
                goto Label_0020;
            }
        Label_008C:
            flag = num15 <= num6;
            if (!flag)
            {
                num13++;
                if ((((uint) num15) - ((uint) num9)) >= 0)
                {
                    goto Label_0029;
                }
                goto Label_0020;
            }
            numArray4[num13 - 1, num15 - 1] = numArray2[num13, num15];
            num15++;
            if ((((uint) num3) + ((uint) num10)) >= 0)
            {
                if ((((uint) num7) | uint.MaxValue) == 0)
                {
                    goto Label_01E3;
                }
                if ((((uint) num11) & 0) != 0)
                {
                    goto Label_1956;
                }
                if ((((uint) num18) + ((uint) num10)) < 0)
                {
                    goto Label_016B;
                }
                goto Label_008C;
            }
        Label_00F7:
            numArray6[num13 - 1, num15 - 1] = numArray3[num13, num15];
        Label_0111:
            num15++;
        Label_0117:
            if (num15 <= num6)
            {
                goto Label_00F7;
            }
            num13++;
        Label_012C:
            flag = num13 <= num6;
            if (!flag)
            {
                V_ = numArray6;
                num13 = 1;
                goto Label_0029;
            }
        Label_0145:
            num15 = 1;
            goto Label_0117;
        Label_014A:
            if (!flag)
            {
                S_ = numArray5;
                num13 = 1;
                goto Label_012C;
            }
        Label_0157:
            numArray5[num13 - 1, num13 - 1] = numArray[num13];
        Label_016B:
            num13++;
        Label_0171:
            flag = num13 <= num6;
            goto Label_014A;
        Label_01E3:
            num9--;
            if ((((uint) num12) - ((uint) num)) > uint.MaxValue)
            {
                goto Label_0F22;
            }
            if ((((uint) num16) + ((uint) num15)) < 0)
            {
                goto Label_0585;
            }
        Label_0220:
            flag = num9 >= 1;
            if ((((uint) num17) + ((uint) num11)) >= 0)
            {
                if (((uint) num14) > uint.MaxValue)
                {
                    goto Label_1AB5;
                }
                if (flag)
                {
                    num14 = 1;
                    if ((((uint) num11) - ((uint) num5)) <= uint.MaxValue)
                    {
                        if ((((uint) num24) + ((uint) num8)) <= uint.MaxValue)
                        {
                            goto Label_0257;
                        }
                        goto Label_0E80;
                    }
                    goto Label_0C0C;
                }
                numArray5 = new double[num6, num6];
                numArray6 = new double[num6, num6];
                numArray4 = new double[num4, num6];
                num13 = 1;
                if ((((uint) num25) + ((uint) num12)) > uint.MaxValue)
                {
                    goto Label_0D99;
                }
                goto Label_0171;
            }
        Label_0242:
            numArray7[num9] = num19;
        Label_0249:
            numArray[num9] = num24;
            num14++;
        Label_0257:
            flag = num14 <= 30;
            if (flag)
            {
                goto Label_0ABF;
            }
            goto Label_01E3;
        Label_0271:
            flag = num15 <= num11;
            if (flag)
            {
                num13 = num15 + 1;
                num20 = numArray7[num13];
                goto Label_053B;
            }
            numArray7[num10] = 0.0;
            goto Label_0242;
        Label_036F:
            num24 = (num18 * num25) - (num22 * num20);
            num16 = 1;
            while (true)
            {
                flag = num16 <= num3;
                if (flag)
                {
                    num25 = numArray2[num16, num15];
                    if ((((uint) num2) - ((uint) flag)) < 0)
                    {
                        goto Label_0DCA;
                    }
                    num26 = numArray2[num16, num13];
                    numArray2[num16, num15] = (num25 * num18) + (num26 * num22);
                    numArray2[num16, num13] = (num26 * num18) - (num25 * num22);
                }
                else
                {
                    if ((((uint) num10) | 15) == 0)
                    {
                        goto Label_042A;
                    }
                    num15++;
                    goto Label_0271;
                }
                num16++;
            }
        Label_039F:
            num19 = (num18 * num20) + (num22 * num25);
            if ((((uint) num12) + ((uint) num2)) < 0)
            {
                goto Label_0111;
            }
            goto Label_036F;
        Label_03CA:
            numArray[num15] = num26;
            flag = num26 == 0.0;
            if ((((uint) num22) | 15) == 0)
            {
                goto Label_148A;
            }
            if (!flag)
            {
                num26 = 1.0 / num26;
                if ((((uint) num18) - ((uint) num3)) >= 0)
                {
                    num18 = num19 * num26;
                    num22 = num21 * num26;
                    goto Label_039F;
                }
                goto Label_0271;
            }
            if ((((uint) num7) & 0) != 0)
            {
                goto Label_0B2F;
            }
            goto Label_039F;
        Label_0414:
            num16++;
        Label_041B:
            if (num16 <= num5)
            {
                goto Label_0484;
            }
        Label_042A:
            num26 = xa7f911a89f00277e(num19, num21);
            if (((uint) num19) >= 0)
            {
                goto Label_03CA;
            }
        Label_0484:
            num24 = numArray3[num16, num15];
            if ((((uint) num8) + ((uint) num20)) >= 0)
            {
                num26 = numArray3[num16, num13];
                numArray3[num16, num15] = (num24 * num18) + (num26 * num22);
                numArray3[num16, num13] = (num26 * num18) - (num24 * num22);
                goto Label_0414;
            }
            goto Label_03CA;
        Label_04D9:
            num21 = num25 * num22;
            num25 *= num18;
            num16 = 1;
            goto Label_041B;
        Label_0504:
            numArray7[num15] = num26;
            num18 = num19 / num26;
            num22 = num21 / num26;
            num19 = (num24 * num18) + (num20 * num22);
            if (((uint) flag) >= 0)
            {
                num20 = (num20 * num18) - (num24 * num22);
                goto Label_04D9;
            }
            goto Label_0242;
        Label_053B:
            num25 = numArray[num13];
            num21 = num22 * num20;
            num20 = num18 * num20;
            if (((uint) num2) <= uint.MaxValue)
            {
                num26 = xa7f911a89f00277e(num19, num21);
                goto Label_0504;
            }
        Label_0562:
            num15 = num10;
            if ((((uint) num20) + ((uint) num9)) > uint.MaxValue)
            {
                goto Label_1D58;
            }
            goto Label_0271;
        Label_0585:
            num18 = num22 = 1.0;
            goto Label_0562;
        Label_0621:
            num20 = numArray7[num11];
            if ((((uint) num12) - ((uint) num11)) <= uint.MaxValue)
            {
                if ((((uint) num15) - ((uint) num4)) <= uint.MaxValue)
                {
                    num21 = numArray7[num9];
                    num19 = (((num25 - num26) * (num25 + num26)) + ((num20 - num21) * (num20 + num21))) / ((2.0 * num21) * num25);
                    num20 = xa7f911a89f00277e(num19, 1.0);
                    num19 = (((num24 - num26) * (num24 + num26)) + (num21 * ((num25 / (num19 + x0428c55343267861(num20, num19))) - num21))) / num24;
                }
                if ((((uint) num13) - ((uint) num15)) >= 0)
                {
                    goto Label_0585;
                }
                if ((((uint) num27) | 3) != 0)
                {
                    goto Label_07FD;
                }
                goto Label_0704;
            }
            goto Label_065F;
        Label_0649:
            num24 = numArray[num10];
        Label_0650:
            num11 = num9 - 1;
            num25 = numArray[num11];
            goto Label_0621;
        Label_065F:
            if (((((uint) num3) | uint.MaxValue) != 0) && flag)
            {
                goto Label_0649;
            }
            Console.WriteLine("No convergence in 30 SVDCMP iterations");
            if (((uint) num25) >= 0)
            {
                goto Label_0649;
            }
            goto Label_0621;
        Label_0704:
            if ((((uint) num23) - ((uint) num5)) < 0)
            {
                goto Label_140C;
            }
            goto Label_01E3;
        Label_0771:
            while (num15 <= num5)
            {
                numArray3[num15, num9] = -numArray3[num15, num9];
                num15++;
            }
            goto Label_0704;
        Label_0790:
            num15 = 1;
            if ((((uint) num19) | 15) != 0)
            {
                goto Label_0771;
            }
            goto Label_07FD;
        Label_07B0:
            num26 = numArray[num9];
            flag = num10 != num9;
            if (!flag)
            {
                flag = num26 >= 0.0;
            }
            else
            {
                flag = num14 != 30;
                if (((uint) num24) >= 0)
                {
                    goto Label_065F;
                }
                if (((uint) num16) <= uint.MaxValue)
                {
                    goto Label_07FD;
                }
                goto Label_0771;
            }
            if (!flag)
            {
                numArray[num9] = -num26;
                goto Label_0790;
            }
            goto Label_01E3;
        Label_07DF:
            if (num13 <= num9)
            {
                num19 = num22 * numArray7[num13];
                flag = (Math.Abs(num19) + num17) == num17;
                if ((((uint) num12) + ((uint) num11)) <= uint.MaxValue)
                {
                    goto Label_0814;
                }
                goto Label_09C1;
            }
            goto Label_07B0;
        Label_07FD:
            if (((uint) num22) > uint.MaxValue)
            {
                goto Label_0650;
            }
            if ((((uint) num7) + ((uint) num5)) <= uint.MaxValue)
            {
                goto Label_0835;
            }
        Label_0814:
            if (!flag)
            {
                goto Label_09C1;
            }
        Label_0835:
            num13++;
            if ((((uint) num) + ((uint) num10)) >= 0)
            {
                goto Label_07DF;
            }
            goto Label_07B0;
        Label_08AB:
            flag = num15 <= num3;
            if ((((uint) num23) - ((uint) num22)) > uint.MaxValue)
            {
                goto Label_126A;
            }
            if (flag)
            {
                num25 = numArray2[num15, num11];
                if ((((uint) num11) + ((uint) num14)) < 0)
                {
                    goto Label_0A5F;
                }
                if ((((uint) num5) - ((uint) num19)) > uint.MaxValue)
                {
                    goto Label_154F;
                }
                num26 = numArray2[num15, num13];
            }
            else
            {
                if (((uint) num6) < 0)
                {
                    goto Label_04D9;
                }
                if ((((uint) num19) + ((uint) num11)) > uint.MaxValue)
                {
                    goto Label_0E72;
                }
                goto Label_07FD;
            }
            numArray2[num15, num11] = (num25 * num18) + (num26 * num22);
            numArray2[num15, num13] = (num26 * num18) - (num25 * num22);
            if (((uint) num22) >= 0)
            {
                goto Label_13C7;
            }
            goto Label_0E80;
        Label_09C1:
            num20 = numArray[num13];
            num21 = xa7f911a89f00277e(num19, num20);
            numArray[num13] = num21;
        Label_09DB:
            num21 = 1.0 / num21;
            num18 = num20 * num21;
            num22 = -num19 * num21;
            num15 = 1;
            goto Label_08AB;
        Label_0A5F:
            flag = num10 >= 1;
            if ((((uint) num4) - ((uint) num13)) > uint.MaxValue)
            {
                goto Label_0157;
            }
            if (flag)
            {
                num11 = num10 - 1;
                if (((Math.Abs(numArray7[num10]) + num17) == num17) && (((uint) num16) <= uint.MaxValue))
                {
                    num12 = 0;
                }
                else
                {
                    flag = (Math.Abs(numArray[num11]) + num17) != num17;
                    if (flag)
                    {
                        num10--;
                        if ((((uint) num22) | 0xfffffffe) == 0)
                        {
                            goto Label_1471;
                        }
                        goto Label_0A5F;
                    }
                }
            }
            flag = num12 == 0;
            if (!flag)
            {
                num18 = 0.0;
            }
            else
            {
                goto Label_07B0;
            }
            num22 = 1.0;
            num13 = num10;
            goto Label_07DF;
        Label_0ABF:
            num12 = 1;
            num10 = num9;
            goto Label_0A5F;
        Label_0B2F:
            num9 = num5;
            goto Label_0220;
        Label_0B3E:
            num1 = numArray2[num13, num13];
            num1[0]++;
            num13--;
        Label_0B65:
            if (num13 >= 1)
            {
                num10 = num13 + 1;
                num20 = numArray[num13];
                if (((uint) num7) > uint.MaxValue)
                {
                    goto Label_0FD9;
                }
                flag = num13 >= num5;
                if (flag)
                {
                    goto Label_0E80;
                }
                num15 = num10;
                goto Label_0F4F;
            }
            goto Label_0B2F;
        Label_0C0C:
            flag = num15 <= num3;
        Label_0C16:
            if (((uint) num19) < 0)
            {
                goto Label_140C;
            }
            if (flag)
            {
                double num28 = numArray2[num15, num13];
                num28[0] *= num20;
                num15++;
                if ((((uint) num4) + ((uint) num17)) < 0)
                {
                    goto Label_09DB;
                }
                goto Label_0C0C;
            }
            goto Label_0B3E;
        Label_0C59:
            num15 = num13;
            if ((((uint) num16) + ((uint) num)) < 0)
            {
                goto Label_120E;
            }
            if ((((uint) num) - ((uint) num11)) <= uint.MaxValue)
            {
                goto Label_0C0C;
            }
            goto Label_0E80;
        Label_0CC0:
            flag = num15 <= num5;
            if ((((uint) num19) + ((uint) num2)) < 0)
            {
                goto Label_1306;
            }
            if ((((uint) num19) + ((uint) num21)) < 0)
            {
                goto Label_0249;
            }
            if (flag)
            {
                goto Label_0E72;
            }
            if (((uint) num6) < 0)
            {
            }
            goto Label_0C59;
        Label_0D7E:
            if ((((uint) num) - ((uint) num23)) < 0)
            {
                goto Label_0F22;
            }
        Label_0D99:
            flag = num9 <= num3;
            if (!flag)
            {
                num19 = (num22 / numArray2[num13, num13]) * num20;
                num9 = num13;
                do
                {
                    flag = num9 <= num3;
                    if (flag)
                    {
                        double num29 = numArray2[num9, num15];
                        num29[0] += num19 * numArray2[num9, num13];
                    }
                    else
                    {
                        num15++;
                        if ((((uint) num5) + ((uint) num14)) > uint.MaxValue)
                        {
                            goto Label_0650;
                        }
                        goto Label_0CC0;
                    }
                    num9++;
                }
                while ((((uint) num10) + ((uint) num2)) <= uint.MaxValue);
                goto Label_0C59;
            }
        Label_0DCA:
            num22 += numArray2[num9, num13] * numArray2[num9, num15];
            if ((((uint) num2) + ((uint) num13)) < 0)
            {
                goto Label_0F4F;
            }
            num9++;
            if ((((uint) num22) + ((uint) num13)) > uint.MaxValue)
            {
                goto Label_154F;
            }
            goto Label_0D7E;
        Label_0E72:
            num22 = 0.0;
            if ((((uint) num15) - ((uint) num6)) <= uint.MaxValue)
            {
                num9 = num10;
                if ((((uint) num15) - ((uint) flag)) > uint.MaxValue)
                {
                    goto Label_111F;
                }
                goto Label_0D99;
            }
            goto Label_0D7E;
        Label_0E80:
            flag = num20 == 0.0;
            if (flag)
            {
                for (num15 = num13; num15 <= num3; num15++)
                {
                    numArray2[num15, num13] = 0.0;
                }
                goto Label_0B3E;
            }
            if ((((uint) num2) + ((uint) num18)) > uint.MaxValue)
            {
                goto Label_1E04;
            }
            num20 = 1.0 / num20;
            flag = num13 == num5;
            if (((((uint) num20) - ((uint) num2)) <= uint.MaxValue) && flag)
            {
                goto Label_0C59;
            }
            num15 = num10;
            goto Label_0CC0;
        Label_0F22:
            flag = num15 <= num5;
            if (((uint) num21) > uint.MaxValue)
            {
                goto Label_1A97;
            }
            if (flag)
            {
                numArray2[num13, num15] = 0.0;
                num15++;
                goto Label_0F22;
            }
            if ((((uint) num11) - ((uint) num12)) >= 0)
            {
                goto Label_0E80;
            }
            goto Label_13C7;
        Label_0F4F:
            if ((((uint) num17) + ((uint) num5)) > uint.MaxValue)
            {
                goto Label_0414;
            }
            if ((((uint) num16) | 1) != 0)
            {
                goto Label_0F22;
            }
        Label_0FBD:
            if (flag)
            {
                goto Label_12F5;
            }
            num13 = num5;
            goto Label_0B65;
        Label_0FD9:
            flag = num13 >= 1;
            if (0 == 0)
            {
                if (((uint) num5) <= uint.MaxValue)
                {
                    goto Label_137C;
                }
                goto Label_12F5;
            }
            goto Label_1088;
        Label_0FEE:
            num10 = num13;
            num13--;
            goto Label_0FD9;
        Label_0FFE:
            numArray3[num13, num13] = 1.0;
            num20 = numArray7[num13];
            goto Label_0FEE;
        Label_1034:
            if (!flag)
            {
                goto Label_1306;
            }
            goto Label_0FFE;
        Label_105E:
            flag = num15 <= num5;
            if (!flag)
            {
                if (((((uint) num2) & 0) == 0) && ((((uint) num4) | 0x7fffffff) == 0))
                {
                    goto Label_1034;
                }
                goto Label_0FFE;
            }
        Label_1088:
            numArray3[num15, num13] = num27 = 0.0;
            numArray3[num13, num15] = num27;
            if ((((uint) num7) + ((uint) num3)) <= uint.MaxValue)
            {
                num15++;
                if ((((uint) num4) + ((uint) num25)) > uint.MaxValue)
                {
                    goto Label_11C5;
                }
                goto Label_105E;
            }
            goto Label_0FEE;
        Label_10DD:
            if (!flag)
            {
                num15 = num10;
                goto Label_12A2;
            }
        Label_10E4:
            num15 = num10;
            if ((((uint) num15) - ((uint) num11)) < 0)
            {
                goto Label_0C16;
            }
            goto Label_105E;
        Label_111F:
            flag = num15 <= num5;
            if ((((uint) num26) - ((uint) num7)) < 0)
            {
                goto Label_12A2;
            }
            if (((uint) num7) < 0)
            {
                goto Label_0504;
            }
            if (flag)
            {
                goto Label_1238;
            }
            if ((((uint) num15) & 0) == 0)
            {
                goto Label_10E4;
            }
            goto Label_137C;
        Label_11C5:
            if (!flag)
            {
                num9 = num10;
            Label_11B4:
                flag = num9 <= num5;
                if (flag)
                {
                    double num30 = numArray3[num9, num15];
                    num30[0] += num22 * numArray3[num9, num13];
                    num9++;
                    goto Label_11B4;
                }
                if ((((uint) num7) - ((uint) num13)) >= 0)
                {
                    num15++;
                    if ((((uint) num5) & 0) != 0)
                    {
                        goto Label_1238;
                    }
                }
                if ((((uint) num16) - ((uint) num14)) >= 0)
                {
                    goto Label_111F;
                }
                goto Label_10DD;
            }
            num22 += numArray2[num13, num9] * numArray3[num9, num15];
            if ((((uint) num) + ((uint) num16)) < 0)
            {
                goto Label_053B;
            }
            num9++;
        Label_120E:
            flag = num9 <= num5;
            if ((((uint) num5) + ((uint) num)) < 0)
            {
                goto Label_0145;
            }
            goto Label_11C5;
        Label_1238:
            num22 = 0.0;
            num9 = num10;
            goto Label_120E;
        Label_126A:
            if (flag)
            {
                numArray3[num15, num13] = (numArray2[num13, num15] / numArray2[num13, num10]) / num20;
                num15++;
                goto Label_12A2;
            }
        Label_126E:
            num15 = num10;
            goto Label_111F;
        Label_12A2:
            flag = num15 <= num5;
            if ((((uint) num15) - ((uint) num13)) < 0)
            {
                goto Label_1E13;
            }
            goto Label_126A;
        Label_12F5:
            flag = num13 >= num5;
            goto Label_1034;
        Label_1306:
            flag = num20 == 0.0;
            goto Label_10DD;
        Label_1331:
            if (num13 <= num5)
            {
                num10 = num13 + 1;
                numArray7[num13] = num23 * num20;
                num20 = num22 = num23 = 0.0;
                if ((((uint) num6) - ((uint) num13)) >= 0)
                {
                    goto Label_1B75;
                }
                goto Label_1BC2;
            }
            num13 = num5;
            goto Label_0FD9;
        Label_1355:
            num17 = Math.Max(num17, Math.Abs(numArray[num13]) + Math.Abs(numArray7[num13]));
        Label_1373:
            num13++;
            goto Label_1331;
        Label_137C:
            if ((((uint) num2) - ((uint) num11)) <= uint.MaxValue)
            {
                goto Label_0FBD;
            }
        Label_1394:
            if (((uint) num24) >= 0)
            {
                goto Label_1355;
            }
            goto Label_0FBD;
        Label_13C7:
            if ((((uint) num3) - ((uint) num13)) <= uint.MaxValue)
            {
                num15++;
                goto Label_08AB;
            }
        Label_13E2:
            if ((((uint) num23) & 0) == 0)
            {
                return;
            }
            goto Label_1ECC;
        Label_140C:
            flag = num9 <= num5;
            if (!flag)
            {
                if ((((uint) num23) + ((uint) num2)) <= uint.MaxValue)
                {
                    goto Label_1394;
                }
                goto Label_1459;
            }
            double num31 = numArray2[num13, num9];
            num31[0] *= num23;
        Label_1451:
            num9++;
            goto Label_140C;
        Label_1459:
            if (0 != 0)
            {
                goto Label_126E;
            }
        Label_145F:
            flag = num15 <= num3;
            if (flag)
            {
                num22 = 0.0;
                if ((((uint) num25) + ((uint) num12)) < 0)
                {
                    goto Label_1801;
                }
                if ((((uint) num) - ((uint) num17)) < 0)
                {
                    goto Label_0B65;
                }
                num9 = num10;
                if ((((uint) num11) + ((uint) num19)) >= 0)
                {
                    goto Label_1642;
                }
                goto Label_161A;
            }
        Label_1471:
            num9 = num10;
            goto Label_140C;
        Label_148A:
            num15++;
            goto Label_1459;
        Label_1493:
            flag = num9 <= num5;
            if (0 == 0)
            {
                if (flag)
                {
                    double num32 = numArray2[num15, num9];
                    num32[0] += num22 * numArray7[num9];
                    if ((((uint) num22) - ((uint) num8)) < 0)
                    {
                        goto Label_17A7;
                    }
                    num9++;
                    goto Label_1493;
                }
                goto Label_148A;
            }
        Label_14A1:
            num9 = num10;
            if ((((uint) num8) - ((uint) num11)) > uint.MaxValue)
            {
                goto Label_0FD9;
            }
            goto Label_1493;
        Label_154F:
            flag = num9 <= num5;
            if (flag)
            {
                num22 += numArray2[num15, num9] * numArray2[num13, num9];
                if ((((uint) num21) - ((uint) num2)) < 0)
                {
                    goto Label_1E0C;
                }
                num9++;
                goto Label_154F;
            }
            goto Label_14A1;
        Label_161A:
            flag = num9 <= num5;
            if (((uint) num26) <= uint.MaxValue)
            {
                if (flag)
                {
                    numArray7[num9] = numArray2[num13, num9] / num21;
                    num9++;
                    goto Label_161A;
                }
                if ((((uint) num18) + ((uint) num11)) > uint.MaxValue)
                {
                    goto Label_0ABF;
                }
                if (num13 == num3)
                {
                    goto Label_1471;
                }
                num15 = num10;
                goto Label_145F;
            }
            goto Label_1642;
        Label_163C:
            num9 = num10;
            goto Label_161A;
        Label_1642:
            if ((((uint) num2) - ((uint) num5)) <= uint.MaxValue)
            {
                goto Label_154F;
            }
        Label_165D:
            if ((((uint) num24) + ((uint) num12)) >= 0)
            {
                goto Label_1394;
            }
            goto Label_1ECC;
        Label_16AD:
            flag = num9 <= num5;
            if (flag)
            {
                double num33 = numArray2[num13, num9];
                num33[0] /= num23;
            }
            else
            {
                num19 = numArray2[num13, num10];
                num20 = -x0428c55343267861(Math.Sqrt(num22), num19);
                num21 = (num19 * num20) - num22;
                numArray2[num13, num10] = num19 - num20;
                if ((((uint) num5) | 0xff) != 0)
                {
                    if (((uint) num) >= 0)
                    {
                        if ((((uint) num10) + ((uint) num10)) >= 0)
                        {
                            goto Label_163C;
                        }
                        goto Label_1ECC;
                    }
                    goto Label_1D98;
                }
                goto Label_1726;
            }
        Label_16E6:
            num22 += numArray2[num13, num9] * numArray2[num13, num9];
            num9++;
            if ((((uint) num16) - ((uint) num17)) > uint.MaxValue)
            {
                goto Label_0790;
            }
            goto Label_16AD;
        Label_1726:
            num9 = num10;
            goto Label_16AD;
        Label_179C:
            flag = num9 <= num5;
        Label_17A7:
            if (flag)
            {
                num23 += Math.Abs(numArray2[num13, num9]);
            }
            else
            {
                flag = num23 == 0.0;
                if ((((uint) num3) + ((uint) num8)) < 0)
                {
                    goto Label_09DB;
                }
                if (!flag)
                {
                    goto Label_1726;
                }
                goto Label_165D;
            }
            num9++;
            if ((((uint) num21) - ((uint) num24)) > uint.MaxValue)
            {
                goto Label_0649;
            }
            goto Label_179C;
            if (num13 <= num3)
            {
            }
        Label_17EC:
            flag = (((uint) num5) >= 0) || (num13 == num5);
            if (!flag)
            {
                num9 = num10;
                goto Label_179C;
            }
            goto Label_1355;
        Label_1801:
            numArray[num13] = num23 * num20;
            num20 = num22 = num23 = 0.0;
            goto Label_17EC;
        Label_188F:
            num9 = num13;
        Label_187B:
            flag = num9 <= num3;
            if (flag)
            {
                double num34 = numArray2[num9, num13];
                num34[0] *= num23;
                num9++;
                goto Label_187B;
            }
            goto Label_1801;
        Label_18B6:
            flag = num15 <= num5;
            goto Label_19D7;
        Label_18C6:
            num35 = numArray2[num9, num15];
            num35[0] += num19 * numArray2[num9, num13];
            num9++;
        Label_18F1:
            flag = num9 <= num3;
            if (flag)
            {
                goto Label_18C6;
            }
            if (0 == 0)
            {
                if ((((uint) num27) - ((uint) num15)) <= uint.MaxValue)
                {
                    num15++;
                    if (((uint) num4) > uint.MaxValue)
                    {
                        goto Label_1DE3;
                    }
                    goto Label_18B6;
                }
                goto Label_19D7;
            }
        Label_192A:
            num22 += numArray2[num9, num13] * numArray2[num9, num15];
            num9++;
        Label_194C:
            flag = num9 <= num3;
        Label_1956:
            if (flag)
            {
                goto Label_192A;
            }
            num19 = num22 / num21;
            if (((uint) num4) >= 0)
            {
                num9 = num13;
                goto Label_18F1;
            }
            if ((((uint) num) - ((uint) num15)) < 0)
            {
                goto Label_1E73;
            }
            goto Label_18C6;
        Label_19D7:
            if ((((uint) num5) & 0) == 0)
            {
                if (flag)
                {
                    num22 = 0.0;
                    num9 = num13;
                    if ((((uint) num16) | 4) == 0)
                    {
                        goto Label_0D7E;
                    }
                    goto Label_194C;
                }
                goto Label_188F;
            }
            if (0x7fffffff != 0)
            {
                goto Label_1C6D;
            }
            goto Label_1B75;
        Label_1A97:
            flag = num23 == 0.0;
            if (!flag)
            {
                num9 = num13;
                do
                {
                    flag = num9 <= num3;
                    if (!flag)
                    {
                        num19 = numArray2[num13, num13];
                        num20 = -x0428c55343267861(Math.Sqrt(num22), num19);
                        num21 = (num19 * num20) - num22;
                        numArray2[num13, num13] = num19 - num20;
                        flag = num13 == num5;
                        if ((((uint) num15) & 0) == 0)
                        {
                            if (flag)
                            {
                                goto Label_188F;
                            }
                            num15 = num10;
                            goto Label_18B6;
                        }
                        goto Label_1B75;
                    }
                    double num36 = numArray2[num9, num13];
                    num36[0] /= num23;
                    num22 += numArray2[num9, num13] * numArray2[num9, num13];
                    num9++;
                }
                while ((((uint) num11) + ((uint) num20)) >= 0);
                goto Label_1B1D;
            }
            goto Label_1801;
        Label_1AB5:
            num9++;
        Label_1ABB:
            flag = num9 <= num3;
            if (flag)
            {
                num23 += Math.Abs(numArray2[num9, num13]);
                goto Label_1AB5;
            }
            goto Label_1A97;
        Label_1AFF:
            num9 = num13;
            goto Label_1ABB;
        Label_1B1D:
            if ((((uint) num5) + ((uint) num20)) < 0)
            {
                goto Label_00F7;
            }
            if ((((uint) num14) & 0) == 0)
            {
                if (!flag)
                {
                    goto Label_1AFF;
                }
                if ((((uint) flag) + ((uint) num11)) >= 0)
                {
                    goto Label_1801;
                }
                goto Label_1726;
            }
            if (0 != 0)
            {
                goto Label_1373;
            }
            if ((((uint) num8) + ((uint) num19)) > uint.MaxValue)
            {
                goto Label_0D99;
            }
            goto Label_1AFF;
        Label_1B75:
            flag = num13 > num3;
            goto Label_1B1D;
        Label_1BC2:
            num23 = 0.0;
            num17 = 0.0;
            num13 = 1;
            goto Label_1331;
        Label_1C6D:
            num7++;
        Label_1C73:
            if ((((uint) num12) - ((uint) num5)) < 0)
            {
                goto Label_16E6;
            }
        Label_1C8E:
            flag = num7 <= (num + 1);
            if (!flag)
            {
                numArray3 = new double[num6 + 1, num6 + 1];
                numArray = new double[num6 + 1];
                numArray7 = new double[100];
                num10 = 0;
                if (((uint) num9) < 0)
                {
                    goto Label_0649;
                }
                num11 = 0;
                num20 = 0.0;
                if ((((uint) num15) + ((uint) num)) > uint.MaxValue)
                {
                    goto Label_0B3E;
                }
                if ((((uint) num17) | 1) != 0)
                {
                    goto Label_1BC2;
                }
                goto Label_1C6D;
            }
        Label_1D58:
            num8 = 1;
            if ((((uint) num24) + ((uint) num10)) < 0)
            {
                goto Label_1493;
            }
        Label_1CF4:
            flag = num8 <= (num2 + 1);
            while (flag)
            {
                numArray2[num7, num8] = Mat_[num7 - 1, num8 - 1];
                if ((((uint) num21) + ((uint) num7)) <= uint.MaxValue)
                {
                    num8++;
                    goto Label_1CF4;
                }
            }
            if (((uint) num15) >= 0)
            {
                goto Label_1C6D;
            }
        Label_1D98:
            numArray2 = new double[num3 + 1, num5 + 1];
            num7 = 1;
            if ((((uint) num12) & 0) != 0)
            {
                goto Label_1451;
            }
            if ((((uint) num12) + ((uint) num8)) < 0)
            {
                goto Label_1E73;
            }
            goto Label_1C8E;
        Label_1DD8:
            if (!flag)
            {
                goto Label_1E46;
            }
            num4 = num3;
            num6 = num5;
        Label_1DE3:
            if ((((uint) num25) - ((uint) num13)) >= 0)
            {
                if ((((uint) num19) + ((uint) num17)) >= 0)
                {
                    goto Label_1D98;
                }
                goto Label_163C;
            }
            goto Label_1ECC;
        Label_1E04:
            num6 = num4 = num3;
            goto Label_1D98;
        Label_1E0C:
            if (!flag)
            {
                num3 = num5;
                if ((((uint) num23) - ((uint) flag)) <= uint.MaxValue)
                {
                    if ((((uint) num12) - ((uint) num7)) > uint.MaxValue)
                    {
                        goto Label_1C73;
                    }
                    num4 = num6 = num5;
                    goto Label_1D98;
                }
                goto Label_1DD8;
            }
        Label_1E13:
            flag = num3 <= num5;
            if ((((uint) num3) & 0) != 0)
            {
                goto Label_036F;
            }
            if (((uint) num7) >= 0)
            {
                goto Label_1DD8;
            }
        Label_1E46:
            num5 = num3;
            if ((((uint) num5) & 0) != 0)
            {
                goto Label_014A;
            }
            if (((uint) num9) >= 0)
            {
                goto Label_1E04;
            }
        Label_1E73:
            if ((((uint) num19) & 0) == 0)
            {
                goto Label_1E13;
            }
            if (((uint) num26) <= uint.MaxValue)
            {
                goto Label_1E0C;
            }
            goto Label_1E04;
        Label_1ECC:
            num3 = num + 1;
            num5 = num2 + 1;
            flag = num3 >= num5;
            goto Label_1E0C;
        }

        public override string ToString()
        {
            return PrintMat(this.x6b2bf248b3d627d6);
        }

        public static double[,] Transpose(double[,] Mat)
        {
            double[,] numArray;
            int num;
            int num2;
            int num3;
            int num4;
            double[,] numArray2;
            bool flag;
            try
            {
                x665968ea622b9927(Mat, out num3, out num4);
                numArray = new double[num4 + 1, num3 + 1];
                num = 0;
                if ((((uint) num) - ((uint) num2)) > uint.MaxValue)
                {
                    goto Label_0054;
                }
                goto Label_006A;
            }
            catch
            {
                throw new x5ed344f47a2ec6bc();
            }
        Label_001D:
            if (flag)
            {
                num2 = 0;
                goto Label_0058;
            }
            if ((((uint) num2) - ((uint) num2)) < 0)
            {
                goto Label_006A;
            }
            return numArray;
        Label_0054:
            num2++;
        Label_0058:
            if (num2 <= num4)
            {
                numArray[num2, num] = Mat[num, num2];
                goto Label_0054;
            }
            num++;
        Label_006A:
            flag = num <= num3;
            if (((uint) num3) >= 0)
            {
                goto Label_001D;
            }
            return numArray2;
        }

        public static Matrix Transpose(Matrix Mat)
        {
            return new Matrix(Transpose(Mat.x6b2bf248b3d627d6));
        }

        public static double[] TwoD_2_OneD(double[,] Mat)
        {
            int num;
            double[] numArray;
            int num3;
            bool flag;
            try
            {
                int num2;
                x665968ea622b9927(Mat, out num, out num2);
                flag = num2 == 0;
                if (0 == 0)
                {
                    if ((((uint) num3) & 0) == 0)
                    {
                        if (!flag)
                        {
                            goto Label_0082;
                        }
                        if ((((uint) num3) + ((uint) num2)) <= uint.MaxValue)
                        {
                            numArray = new double[num + 1];
                            goto Label_0052;
                        }
                    }
                    else
                    {
                        goto Label_0082;
                    }
                }
            }
            catch
            {
                throw new x5ed344f47a2ec6bc();
            }
        Label_001A:
            num3++;
            if ((((uint) num3) + ((uint) flag)) < 0)
            {
                goto Label_0052;
            }
        Label_0037:
            if (num3 <= num)
            {
                numArray[num3] = Mat[num3, 0];
                goto Label_001A;
            }
            return numArray;
        Label_0052:
            num3 = 0;
            goto Label_0037;
        Label_0082:
            throw new xd695dad7cec4293d();
        }

        public static double VectorMagnitude(double[,] V)
        {
            // This item is obfuscated and can not be translated.
            int num;
            double num3;
            try
            {
                int num2;
                x665968ea622b9927(V, out num, out num2);
                goto Label_0079;
            }
            catch
            {
                throw new x5ed344f47a2ec6bc();
            }
            return num3;
        Label_0079:
            if (num != 2)
            {
            }
            while (true)
            {
                if (true)
                {
                    throw new xb36c46347391c047();
                }
                return Math.Sqrt(((V[0, 0] * V[0, 0]) + (V[1, 0] * V[1, 0])) + (V[2, 0] * V[2, 0]));
                if (((uint) num3) <= uint.MaxValue)
                {
                    goto Label_0079;
                }
            }
        }

        public static double VectorMagnitude(Matrix V)
        {
            return VectorMagnitude(V.x6b2bf248b3d627d6);
        }

        public static double VectorMagnitude(double[] V)
        {
            int num;
            try
            {
                x665968ea622b9927(V, out num);
            }
            catch
            {
                throw new x5ed344f47a2ec6bc();
            }
            while (num != 2)
            {
                double num2;
                if ((((uint) num2) & 0) == 0)
                {
                    throw new xb36c46347391c047();
                }
            }
            return Math.Sqrt(((V[0] * V[0]) + (V[1] * V[1])) + (V[2] * V[2]));
        }

        private static double x0428c55343267861(double x19218ffab70283ef, double xe7ebe10fa44d8d49)
        {
            if (xe7ebe10fa44d8d49 < 0.0)
            {
                return -Math.Abs(x19218ffab70283ef);
            }
            return Math.Abs(x19218ffab70283ef);
        }

        private static void x665968ea622b9927(double[] xbf77e26cef504bea, out int xa19781cfbe8b4961)
        {
            xa19781cfbe8b4961 = xbf77e26cef504bea.GetUpperBound(0);
        }

        private static void x665968ea622b9927(double[,] xbf77e26cef504bea, out int xa19781cfbe8b4961, out int x2f00dc9f5cd11802)
        {
            xa19781cfbe8b4961 = xbf77e26cef504bea.GetUpperBound(0);
            x2f00dc9f5cd11802 = xbf77e26cef504bea.GetUpperBound(1);
        }

        private static double x79b878e5ece364b8(double x19218ffab70283ef)
        {
            return (x19218ffab70283ef * x19218ffab70283ef);
        }

        private static double xa7f911a89f00277e(double x19218ffab70283ef, double xe7ebe10fa44d8d49)
        {
            double num3;
            double num = Math.Abs(x19218ffab70283ef);
            if (-1 != 0)
            {
                double num2 = Math.Abs(xe7ebe10fa44d8d49);
                if (num <= num2)
                {
                    num3 = (num2 == 0.0) ? 0.0 : (num2 * Math.Sqrt(1.0 + x79b878e5ece364b8(num / num2)));
                    if ((((uint) num2) + ((uint) xe7ebe10fa44d8d49)) < 0)
                    {
                    }
                    return num3;
                }
                return (num * Math.Sqrt(1.0 + x79b878e5ece364b8(num2 / num)));
            }
            return num3;
        }

        private static void xb08222189d83333b(double[,] xbf77e26cef504bea, int xa19781cfbe8b4961, int x5f19a36127815d19)
        {
            int upperBound = xbf77e26cef504bea.GetUpperBound(0);
            double[,] numArray = new double[1, upperBound + 1];
            int num2 = 0;
            if ((((uint) x5f19a36127815d19) + ((uint) num2)) >= 0)
            {
                goto Label_0041;
            }
        Label_001C:
            xbf77e26cef504bea[xa19781cfbe8b4961, num2] = xbf77e26cef504bea[x5f19a36127815d19, num2];
            xbf77e26cef504bea[x5f19a36127815d19, num2] = numArray[0, num2];
            num2++;
        Label_0041:
            if (num2 <= upperBound)
            {
                numArray[0, num2] = xbf77e26cef504bea[xa19781cfbe8b4961, num2];
                goto Label_001C;
            }
        }

        private static void xd7749c2e3652c828(double x4b101060f4767186, double xe24dd90acb923d68, double xe4115acdf4fbfccc, double xa0db54712cc6b16c, double[,] x19218ffab70283ef, int x7b28e8a789372508, int x1148d0e8cc982c04, int x51ae3b338384d896, int x9fc3ee03a439f6f0)
        {
            x4b101060f4767186 = x19218ffab70283ef[x7b28e8a789372508, x1148d0e8cc982c04];
            xe24dd90acb923d68 = x19218ffab70283ef[x51ae3b338384d896, x9fc3ee03a439f6f0];
            x19218ffab70283ef[x7b28e8a789372508, x1148d0e8cc982c04] = x4b101060f4767186 - (xe4115acdf4fbfccc * (xe24dd90acb923d68 + (x4b101060f4767186 * xa0db54712cc6b16c)));
            x19218ffab70283ef[x51ae3b338384d896, x9fc3ee03a439f6f0] = xe24dd90acb923d68 + (xe4115acdf4fbfccc * (x4b101060f4767186 - (xe24dd90acb923d68 * xa0db54712cc6b16c)));
        }

        public double this[int Row, int Col]
        {
            get
            {
                return this.x6b2bf248b3d627d6[Row, Col];
            }
            set
            {
                this.x6b2bf248b3d627d6[Row, Col] = value;
            }
        }

        public int NoCols
        {
            get
            {
                return (this.x6b2bf248b3d627d6.GetUpperBound(1) + 1);
            }
            set
            {
                this.x6b2bf248b3d627d6 = new double[this.x6b2bf248b3d627d6.GetUpperBound(0), value];
            }
        }

        public int NoRows
        {
            get
            {
                return (this.x6b2bf248b3d627d6.GetUpperBound(0) + 1);
            }
            set
            {
                this.x6b2bf248b3d627d6 = new double[value, this.x6b2bf248b3d627d6.GetUpperBound(0)];
            }
        }

        public double[,] toArray
        {
            get
            {
                return this.x6b2bf248b3d627d6;
            }
        }
    }
}

