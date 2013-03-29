namespace Encog.Neural.RBF.Training
{
    using Encog.MathUtil.RBF;
    using Encog.Util;
    using System;

    public class SVD
    {
        public static double MAX(double a, double b)
        {
            if (a <= b)
            {
                return b;
            }
            return a;
        }

        public static int MIN(int m, int n)
        {
            if (m >= n)
            {
                return n;
            }
            return m;
        }

        public static double Pythag(double a, double b)
        {
            double num = Math.Abs(a);
            double num2 = Math.Abs(b);
            if (num <= num2)
            {
                if (num2 != 0.0)
                {
                    return (num2 * Math.Sqrt(1.0 + ((num / num2) * (num / num2))));
                }
                return 0.0;
            }
            return (num * Math.Sqrt(1.0 + ((num2 / num) * (num2 / num))));
        }

        public static double SIGN(double a, double b)
        {
            if (b < 0.0)
            {
                return -Math.Abs(a);
            }
            return Math.Abs(a);
        }

        public static void Svdbksb(double[][] u, double[] w, double[][] v, double[][] b, double[][] x)
        {
            int num2;
            int num3;
            int num5;
            int num6;
            double num7;
            double[] numArray;
            int length = u.Length;
            goto Label_0207;
        Label_0009:
            if (num2 < num5)
            {
                goto Label_005F;
            }
            num6++;
        Label_0014:
            if (num6 < b[0].Length)
            {
                goto Label_01E6;
            }
            if (((uint) num2) >= 0)
            {
                return;
            }
            goto Label_014D;
        Label_005F:
            num7 = 0.0;
            for (int i = 0; i < num5; i++)
            {
                num7 += v[num2][i] * numArray[i];
            Label_007D:;
            }
            x[num2][num6] = num7;
            num2++;
            if ((((uint) num5) - ((uint) num6)) <= uint.MaxValue)
            {
                if ((((uint) num5) - ((uint) length)) <= uint.MaxValue)
                {
                    goto Label_0165;
                }
            }
            else
            {
                goto Label_005F;
            }
        Label_00A7:
            if ((((uint) num6) + ((uint) num2)) < 0)
            {
                goto Label_0217;
            }
        Label_00C2:
            numArray[num2] = num7;
            num2++;
        Label_00CC:
            if (num2 < num5)
            {
                num7 = 0.0;
                if (((uint) num6) < 0)
                {
                    goto Label_01E6;
                }
            }
            else
            {
                if ((((uint) num5) + ((uint) num6)) < 0)
                {
                    goto Label_0187;
                }
                num2 = 0;
                goto Label_0009;
            }
        Label_00F5:
            if (w[num2] != 0.0)
            {
                num3 = 0;
                goto Label_0187;
            }
            if ((((uint) num5) - ((uint) num5)) <= uint.MaxValue)
            {
                goto Label_00A7;
            }
        Label_0108:
            if ((((uint) num6) - ((uint) num5)) < 0)
            {
                goto Label_00F5;
            }
            goto Label_00C2;
        Label_014D:
            if (num3 < length)
            {
                num7 += u[num3][num2] * b[num3][num6];
                num3++;
                if (0 == 0)
                {
                    goto Label_0221;
                }
                goto Label_0207;
            }
            if ((((uint) num2) & 0) == 0)
            {
                num7 /= w[num2];
                goto Label_0108;
            }
        Label_0165:
            if ((((uint) num2) + ((uint) length)) >= 0)
            {
                goto Label_0009;
            }
            return;
        Label_0187:
            if (((uint) num6) < 0)
            {
                goto Label_005F;
            }
            goto Label_014D;
        Label_01E6:
            num2 = 0;
            if (-2 == 0)
            {
                goto Label_007D;
            }
            goto Label_00CC;
        Label_0207:
            num5 = u[0].Length;
            numArray = new double[num5];
        Label_0217:
            num6 = 0;
            if (15 != 0)
            {
                if (((uint) num7) < 0)
                {
                    goto Label_00CC;
                }
                goto Label_0014;
            }
        Label_0221:
            if ((((uint) length) - ((uint) length)) >= 0)
            {
                goto Label_014D;
            }
        }

        public static void Svdcmp(double[][] a, double[] w, double[][] v)
        {
            bool flag;
            int num;
            int num2;
            int num3;
            int num4;
            int num5;
            int num7;
            double num8;
            double num9;
            double num10;
            double num11;
            double num12;
            double num13;
            double num14;
            double num15;
            double num16;
            double num17;
            int length;
            int num19;
            double[] numArray;
            double num20;
            int index = 0;
            goto Label_13C3;
        Label_0008:
            num5--;
        Label_000E:
            if (num5 >= 0)
            {
                num2 = 0;
            }
            else
            {
                if ((((uint) num5) - ((uint) num11)) <= uint.MaxValue)
                {
                    if (-2147483648 != 0)
                    {
                        goto Label_03C4;
                    }
                    goto Label_02F9;
                }
                goto Label_02CF;
            }
        Label_0022:
            if (num2 < 30)
            {
                flag = true;
                index = num5;
                goto Label_0819;
            }
            if ((((uint) num15) - ((uint) num)) <= uint.MaxValue)
            {
                goto Label_0008;
            }
        Label_0042:
            if (num4 < length)
            {
                num16 = a[num4][num3];
                num17 = a[num4][num];
                goto Label_0110;
            }
            num3++;
            if ((((uint) num12) - ((uint) num11)) < 0)
            {
                goto Label_0540;
            }
        Label_006A:
            if (num3 <= num7)
            {
                num = num3 + 1;
                num11 = numArray[num];
                num16 = w[num];
                goto Label_0368;
            }
            numArray[index] = 0.0;
            numArray[num5] = num10;
            w[num5] = num15;
            num2++;
            goto Label_0022;
        Label_0110:
            a[num4][num3] = (num16 * num9) + (num17 * num13);
            if (((uint) num5) < 0)
            {
                goto Label_0870;
            }
            if ((((uint) num17) - ((uint) num3)) > uint.MaxValue)
            {
                goto Label_0BDB;
            }
            if ((((uint) num) + ((uint) num14)) < 0)
            {
                goto Label_063C;
            }
            a[num4][num] = (num17 * num9) - (num16 * num13);
            num4++;
            if ((((uint) num16) & 0) != 0)
            {
                goto Label_0368;
            }
            goto Label_0042;
        Label_012B:
            num10 = (num9 * num11) + (num13 * num16);
            num15 = (num9 * num16) - (num13 * num11);
            num4 = 0;
            goto Label_0042;
        Label_017C:
            if (num17 != 0.0)
            {
                num17 = 1.0 / num17;
            }
            else
            {
                if ((((uint) num13) | 0x7fffffff) == 0)
                {
                    goto Label_0974;
                }
                goto Label_012B;
            }
        Label_01C8:
            num9 = num10 * num17;
        Label_01CF:
            num13 = num12 * num17;
            if ((((uint) num16) - ((uint) num17)) <= uint.MaxValue)
            {
                if ((((uint) num9) + ((uint) length)) < 0)
                {
                    goto Label_017C;
                }
                goto Label_012B;
            }
        Label_02CF:
            num11 = (num11 * num9) - (num15 * num13);
            num12 = num16 * num13;
            num16 *= num9;
            num4 = 0;
        Label_0216:
            if (num4 < num19)
            {
                num15 = v[num4][num3];
                if ((((uint) index) - ((uint) num2)) <= uint.MaxValue)
                {
                    num17 = v[num4][num];
                    v[num4][num3] = (num15 * num9) + (num17 * num13);
                    if ((((uint) num11) - ((uint) num20)) < 0)
                    {
                        goto Label_06FA;
                    }
                    if ((((uint) num2) + ((uint) num11)) <= uint.MaxValue)
                    {
                        v[num4][num] = (num17 * num9) - (num15 * num13);
                        num4++;
                        goto Label_0216;
                    }
                }
            }
            else
            {
                num17 = Pythag(num10, num12);
            }
            if ((((uint) num11) | 15) != 0)
            {
                w[num3] = num17;
                goto Label_017C;
            }
            goto Label_01C8;
        Label_02F9:
            if ((((uint) num10) | 0xfffffffe) == 0)
            {
                goto Label_0D80;
            }
            num17 = Pythag(num10, num12);
            numArray[num3] = num17;
        Label_0325:
            num9 = num10 / num17;
            num13 = num12 / num17;
            num10 = (num15 * num9) + (num11 * num13);
            if ((((uint) num20) & 0) == 0)
            {
                goto Label_02CF;
            }
            goto Label_03C4;
        Label_0368:
            num12 = num13 * num11;
            num11 = num9 * num11;
            goto Label_02F9;
        Label_037F:
            if ((((uint) num8) + ((uint) num2)) < 0)
            {
                goto Label_0AE1;
            }
            num9 = num13 = 1.0;
            num3 = index;
            if ((((uint) num5) & 0) == 0)
            {
                goto Label_006A;
            }
            goto Label_02F9;
        Label_03C4:
            if ((((uint) num12) - ((uint) index)) <= uint.MaxValue)
            {
                return;
            }
            if ((((uint) length) - ((uint) num7)) <= uint.MaxValue)
            {
                goto Label_13C3;
            }
            if ((((uint) length) - ((uint) num2)) <= uint.MaxValue)
            {
                goto Label_0C73;
            }
        Label_0415:
            num10 = (((num16 - num17) * (num16 + num17)) + ((num11 - num12) * (num11 + num12))) / ((2.0 * num12) * num16);
            num11 = Pythag(num10, 1.0);
            num10 = (((num15 - num17) * (num15 + num17)) + (num12 * ((num16 / (num10 + SIGN(num11, num10))) - num12))) / num15;
            goto Label_037F;
        Label_048D:
            num11 = numArray[num7];
        Label_04FE:
            if (((uint) num4) <= uint.MaxValue)
            {
                num12 = numArray[num5];
                goto Label_0D14;
            }
        Label_0510:
            if (num3 >= num19)
            {
                goto Label_0008;
            }
            v[num3][num5] = -v[num3][num5];
            if ((((uint) num20) & 0) != 0)
            {
                goto Label_0C45;
            }
        Label_0540:
            num3++;
            goto Label_0510;
        Label_0563:
            if (num17 >= 0.0)
            {
                goto Label_0008;
            }
        Label_0573:
            w[num5] = -num17;
            num3 = 0;
            goto Label_0510;
        Label_0588:
            num17 = w[num5];
            if ((((uint) length) & 0) == 0)
            {
                if (index == num5)
                {
                    goto Label_0563;
                }
                if ((((uint) flag) - ((uint) flag)) < 0)
                {
                    goto Label_0A9D;
                }
                num15 = w[index];
                num7 = num5 - 1;
                if ((((uint) num19) + ((uint) num14)) > uint.MaxValue)
                {
                    goto Label_0DCB;
                }
                if ((((uint) num) - ((uint) num5)) <= uint.MaxValue)
                {
                    num16 = w[num7];
                    goto Label_048D;
                }
                goto Label_04FE;
            }
            if ((((uint) num5) + ((uint) num3)) < 0)
            {
                goto Label_1164;
            }
            goto Label_078B;
        Label_05C7:
            if (flag)
            {
                goto Label_07E0;
            }
            if ((((uint) num7) & 0) == 0)
            {
                if ((((uint) num8) + ((uint) num3)) <= uint.MaxValue)
                {
                    goto Label_0588;
                }
                goto Label_060E;
            }
        Label_05CF:
            if ((Math.Abs(num10) + num8) != num8)
            {
                goto Label_0760;
            }
            goto Label_0588;
        Label_060E:
            if (((uint) num8) < 0)
            {
                goto Label_07E0;
            }
            num3++;
            if (((uint) length) > uint.MaxValue)
            {
                goto Label_0AD9;
            }
        Label_063C:
            if (num3 < length)
            {
                num16 = a[num3][num7];
                num17 = a[num3][num];
                a[num3][num7] = (num16 * num9) + (num17 * num13);
                a[num3][num] = (num17 * num9) - (num16 * num13);
                goto Label_060E;
            }
            num++;
        Label_0645:
            if (num < (num5 + 1))
            {
                num10 = num13 * numArray[num];
                numArray[num] = num9 * numArray[num];
                if ((((uint) num11) + ((uint) num11)) > uint.MaxValue)
                {
                    goto Label_0E91;
                }
                if (((uint) num3) <= uint.MaxValue)
                {
                    goto Label_05CF;
                }
                goto Label_0760;
            }
            if ((((uint) num12) + ((uint) num11)) < 0)
            {
            }
            goto Label_0588;
        Label_06A8:
            num13 = -num10 * num12;
            num3 = 0;
            goto Label_063C;
        Label_06FA:
            num9 = num11 * num12;
            if ((((uint) num10) - ((uint) num14)) <= uint.MaxValue)
            {
                goto Label_06A8;
            }
            goto Label_063C;
        Label_0760:
            num11 = w[num];
            num12 = Pythag(num10, num11);
            if ((((uint) num7) - ((uint) num2)) <= uint.MaxValue)
            {
                do
                {
                    w[num] = num12;
                    if ((((uint) num16) - ((uint) num)) < 0)
                    {
                        goto Label_0E07;
                    }
                }
                while ((((uint) num7) + ((uint) num)) > uint.MaxValue);
                num12 = 1.0 / num12;
                goto Label_06FA;
            }
        Label_078B:
            if (((uint) num16) <= uint.MaxValue)
            {
                if ((((uint) num2) - ((uint) num15)) < 0)
                {
                    goto Label_12D9;
                }
                goto Label_0563;
            }
            goto Label_0D14;
        Label_07E0:
            num9 = 0.0;
            num13 = 1.0;
            num = index;
            if ((((uint) flag) + ((uint) num10)) >= 0)
            {
                goto Label_0645;
            }
        Label_0819:
            if (index < 0)
            {
                goto Label_05C7;
            }
            num7 = index - 1;
            if ((Math.Abs(numArray[index]) + num8) == num8)
            {
                flag = false;
                goto Label_05C7;
            }
            if ((Math.Abs(w[num7]) + num8) == num8)
            {
                goto Label_05C7;
            }
            index--;
            goto Label_0819;
        Label_0843:
            if (num >= 0)
            {
                index = num + 1;
                goto Label_0A9D;
            }
            num5 = num19 - 1;
            goto Label_000E;
        Label_0870:
            a[num][num]++;
            num--;
            goto Label_0843;
        Label_08AD:
            num3 = num;
            while (num3 < length)
            {
                a[num3][num] = 0.0;
                num3++;
            }
            if ((((uint) num) + ((uint) flag)) > uint.MaxValue)
            {
                goto Label_0325;
            }
            goto Label_0870;
        Label_090B:
            num3++;
        Label_090F:
            if (num3 < num19)
            {
                num13 = 0.0;
                num5 = index;
                while (num5 < length)
                {
                    num13 += a[num5][num] * a[num5][num3];
                    num5++;
                }
                num10 = (num13 / a[num][num]) * num11;
                num5 = num;
                if ((((uint) num17) - ((uint) num11)) >= 0)
                {
                    goto Label_0974;
                }
            }
            else
            {
                num3 = num;
                while (num3 < length)
                {
                    a[num3][num] *= num11;
                    num3++;
                }
                goto Label_0870;
            }
        Label_0934:
            if ((((uint) num11) - ((uint) num)) > uint.MaxValue)
            {
                goto Label_01CF;
            }
        Label_094F:
            a[num5][num3] += num10 * a[num5][num];
            num5++;
        Label_0974:
            if (num5 < length)
            {
                goto Label_094F;
            }
            goto Label_090B;
        Label_0A68:
            if (num >= 0)
            {
                if (num < (num19 - 1))
                {
                    goto Label_0B09;
                }
                goto Label_0AC5;
            }
            num = MIN(length, num19) - 1;
            if ((((uint) num20) - ((uint) num2)) < 0)
            {
                goto Label_1142;
            }
            goto Label_0843;
        Label_0A9D:
            num11 = w[num];
            if (((uint) index) < 0)
            {
                goto Label_06A8;
            }
            num3 = index;
        Label_0A05:
            if (num3 < num19)
            {
                a[num][num3] = 0.0;
                if (((uint) num8) >= 0)
                {
                    num3++;
                    goto Label_0A05;
                }
                goto Label_0A68;
            }
            if (num11 != 0.0)
            {
                num11 = 1.0 / num11;
                num3 = index;
                goto Label_090F;
            }
            if (((uint) num7) < 0)
            {
                goto Label_0C73;
            }
            if ((((uint) num13) - ((uint) num2)) >= 0)
            {
                if ((((uint) num15) - ((uint) num8)) >= 0)
                {
                    goto Label_08AD;
                }
                goto Label_0D14;
            }
            goto Label_0934;
        Label_0AC5:
            v[num][num] = 1.0;
            num11 = numArray[num];
        Label_0AD9:
            index = num;
            if ((((uint) index) & 0) == 0)
            {
                num--;
                goto Label_0A68;
            }
            goto Label_0D14;
        Label_0AE1:
            num3 = index;
            while (num3 < num19)
            {
                v[num3][num] = num20 = 0.0;
                v[num][num3] = num20;
                num3++;
            }
            goto Label_0AC5;
        Label_0B09:
            if (num11 != 0.0)
            {
                num3 = index;
                while (num3 < num19)
                {
                    v[num3][num] = (a[num][num3] / a[num][index]) / num11;
                Label_0BDB:
                    num3++;
                }
                num3 = index;
                if ((((uint) num19) + ((uint) num12)) <= uint.MaxValue)
                {
                    goto Label_0B5F;
                }
                goto Label_0B74;
            }
            if (((uint) num10) < 0)
            {
                goto Label_0573;
            }
            goto Label_0AE1;
        Label_0B30:
            v[num5][num3] += num13 * v[num5][num];
            num5++;
        Label_0B55:
            if (num5 < num19)
            {
                goto Label_0B30;
            }
            num3++;
        Label_0B5F:
            if (num3 >= num19)
            {
                goto Label_0AE1;
            }
        Label_0B74:
            num13 = 0.0;
            num5 = index;
        Label_0B9D:
            while (num5 < num19)
            {
                num13 += a[num][num5] * v[num5][num3];
                num5++;
            }
            if ((((uint) num10) + ((uint) num4)) >= 0)
            {
                num5 = index;
                goto Label_0B55;
            }
            goto Label_0B30;
        Label_0C26:
            num8 = MAX(num8, Math.Abs(w[num]) + Math.Abs(numArray[num]));
            num++;
        Label_0C45:
            if (num < num19)
            {
                goto Label_1373;
            }
            num = num19 - 1;
            goto Label_0A68;
        Label_0C73:
            if ((((uint) num5) & 0) != 0)
            {
                goto Label_0C26;
            }
        Label_0C87:
            if (num14 != 0.0)
            {
                num5 = index - 1;
                do
                {
                    if (num5 < num19)
                    {
                        a[num][num5] /= num14;
                        if (((uint) num12) > uint.MaxValue)
                        {
                            goto Label_08AD;
                        }
                    }
                    else
                    {
                        num10 = a[num][index - 1];
                        num11 = -SIGN(Math.Sqrt(num13), num10);
                        num12 = (num10 * num11) - num13;
                        if ((((uint) num10) & 0) != 0)
                        {
                            goto Label_0CB7;
                        }
                        break;
                    }
                    num13 += a[num][num5] * a[num][num5];
                    num5++;
                }
                while ((((uint) num16) | 4) != 0);
                a[num][index - 1] = num10 - num11;
                num5 = index - 1;
                goto Label_0E97;
            }
            goto Label_0C26;
        Label_0CB7:
            if ((((uint) num4) + ((uint) num3)) < 0)
            {
                goto Label_0DB7;
            }
            goto Label_0C26;
        Label_0D14:
            if ((((uint) num10) | 4) != 0)
            {
                goto Label_0415;
            }
            goto Label_037F;
        Label_0D80:
            if ((((uint) length) & 0) != 0)
            {
                goto Label_048D;
            }
            goto Label_0C73;
        Label_0D99:
            a[num][num5] *= num14;
            num5++;
        Label_0DB7:
            if (num5 < num19)
            {
                goto Label_0D99;
            }
            goto Label_0C26;
        Label_0DC7:
            num3++;
        Label_0DCB:
            if (num3 < length)
            {
                num13 = 0.0;
                for (num5 = index - 1; num5 < num19; num5++)
                {
                    num13 += a[num3][num5] * a[num][num5];
                    if ((((uint) num3) - ((uint) num10)) < 0)
                    {
                        goto Label_090F;
                    }
                    if (((uint) num17) > uint.MaxValue)
                    {
                        goto Label_0042;
                    }
                }
                goto Label_0ED8;
            }
            num5 = index - 1;
            goto Label_0DB7;
        Label_0DDB:
            a[num3][num5] += num13 * numArray[num5];
            num5++;
        Label_0DFF:
            if (num5 < num19)
            {
                goto Label_0DDB;
            }
            goto Label_0DC7;
        Label_0E07:
            num5 = index - 1;
            if ((((uint) num7) - ((uint) num4)) > uint.MaxValue)
            {
                goto Label_0DC7;
            }
            goto Label_0DFF;
        Label_0E91:
            num5++;
        Label_0E97:
            if (num5 < num19)
            {
                numArray[num5] = a[num][num5] / num12;
                goto Label_0E91;
            }
            num3 = index - 1;
            if ((((uint) num7) + ((uint) num13)) > uint.MaxValue)
            {
                goto Label_0B9D;
            }
            if ((((uint) num10) + ((uint) num15)) <= uint.MaxValue)
            {
                goto Label_0DCB;
            }
        Label_0ED8:
            if ((((uint) num12) + ((uint) num19)) >= 0)
            {
                goto Label_0E07;
            }
            if (((uint) num9) >= 0)
            {
                goto Label_0DDB;
            }
            goto Label_0D99;
        Label_0FFC:
            if (num5 < num19)
            {
                num14 += Math.Abs(a[num][num5]);
                if (((uint) num7) >= 0)
                {
                    if (((uint) num10) <= uint.MaxValue)
                    {
                        num5++;
                    }
                    goto Label_0FFC;
                }
            }
            else
            {
                goto Label_0C87;
            }
        Label_1031:
            w[num] = num14 * num11;
            num11 = num13 = num14 = 0.0;
            if ((((num + 1) > length) && ((((uint) num12) - ((uint) num20)) >= 0)) && ((((uint) num4) + ((uint) length)) >= 0))
            {
                goto Label_0CB7;
            }
            if ((num + 1) != num19)
            {
                num5 = index - 1;
                goto Label_0FFC;
            }
            if ((((uint) num17) - ((uint) num3)) >= 0)
            {
                if ((((uint) length) + ((uint) num9)) < 0)
                {
                    goto Label_0C87;
                }
                if ((((uint) num17) & 0) == 0)
                {
                    goto Label_0C26;
                }
                if ((((uint) flag) - ((uint) num16)) > uint.MaxValue)
                {
                    goto Label_0110;
                }
                goto Label_0B09;
            }
            goto Label_0D80;
        Label_106B:
            if ((((uint) num15) + ((uint) num8)) >= 0)
            {
                goto Label_1031;
            }
        Label_10F0:
            if (num14 != 0.0)
            {
                goto Label_128F;
            }
            if ((((uint) num2) + ((uint) num4)) < 0)
            {
                goto Label_106B;
            }
            if ((((uint) num16) - ((uint) num12)) >= 0)
            {
                goto Label_1031;
            }
            goto Label_0FFC;
        Label_112A:
            if (num3 < num19)
            {
                num13 = 0.0;
                num5 = num;
                goto Label_1164;
            }
            num5 = num;
            while (num5 < length)
            {
                a[num5][num] *= num14;
                num5++;
            }
            goto Label_1031;
        Label_1142:
            if (num5 < length)
            {
                a[num5][num3] += num10 * a[num5][num];
                if ((((uint) num17) - ((uint) num4)) >= 0)
                {
                    num5++;
                    goto Label_1142;
                }
                goto Label_125A;
            }
            num3++;
            if ((((uint) num11) - ((uint) num5)) <= uint.MaxValue)
            {
                goto Label_125A;
            }
        Label_1164:
            while (num5 < length)
            {
                num13 += a[num5][num] * a[num5][num3];
                num5++;
                if ((((uint) num) | 3) == 0)
                {
                    if (((uint) num16) > uint.MaxValue)
                    {
                        goto Label_090B;
                    }
                    goto Label_12C3;
                }
            }
            num10 = num13 / num12;
            num5 = num;
            goto Label_1142;
        Label_1235:
            if (num5 < length)
            {
                a[num5][num] /= num14;
                num13 += a[num5][num] * a[num5][num];
                goto Label_134D;
            }
            num10 = a[num][num];
            num11 = -SIGN(Math.Sqrt(num13), num10);
            num12 = (num10 * num11) - num13;
            a[num][num] = num10 - num11;
            num3 = index - 1;
            goto Label_112A;
        Label_125A:
            if ((((uint) num7) | 0x7fffffff) != 0)
            {
                goto Label_112A;
            }
            goto Label_106B;
        Label_128F:
            num5 = num;
            goto Label_1235;
        Label_12C3:
            num14 += Math.Abs(a[num5][num]);
            num5++;
        Label_12D9:
            if (num5 < length)
            {
                goto Label_12C3;
            }
            if ((((uint) index) - ((uint) index)) >= 0)
            {
                if (((uint) num11) <= uint.MaxValue)
                {
                    goto Label_10F0;
                }
                goto Label_128F;
            }
        Label_134D:
            if (((uint) num16) >= 0)
            {
                if ((((uint) length) + ((uint) num9)) <= uint.MaxValue)
                {
                    num5++;
                    if (((uint) num4) < 0)
                    {
                        goto Label_13AB;
                    }
                    goto Label_1235;
                }
                goto Label_106B;
            }
            if ((((uint) num9) & 0) == 0)
            {
                goto Label_13C3;
            }
        Label_1373:
            index = num + 2;
            numArray[num] = num14 * num11;
            if ((((uint) num13) | 3) != 0)
            {
                num11 = num13 = num14 = 0.0;
                if ((((uint) num5) & 0) != 0)
                {
                    goto Label_000E;
                }
                if (num < length)
                {
                    num5 = num;
                    goto Label_12D9;
                }
                if (((uint) index) <= uint.MaxValue)
                {
                    goto Label_106B;
                }
                goto Label_10F0;
            }
            goto Label_13C3;
        Label_13AB:
            num11 = num14 = num8 = 0.0;
            num = 0;
            goto Label_0C45;
        Label_13C3:
            num7 = 0;
            length = a.Length;
            num19 = a[0].Length;
            numArray = new double[num19];
            goto Label_13AB;
        }

        public static double Svdfit(double[][] x, double[][] y, double[][] a, IRadialBasisFunction[] funcs)
        {
            int num;
            int num2;
            int num3;
            double num4;
            double num5;
            double num6;
            double num7;
            double[][] numArray;
            double[][] numArray2;
            double[] numArray3;
            double num9;
            double num8 = 1E-13;
            goto Label_0254;
        Label_0010:
            if (num < y.Length)
            {
                num7 = 0.0;
                for (num2 = 0; num2 < funcs.Length; num2++)
                {
                    num7 += a[num2][num3] * funcs[num2].Calculate(x[num]);
                }
                num5 = y[num][num3] - num7;
                num9 += num5 * num5;
                num++;
                if (((uint) num9) >= 0)
                {
                    goto Label_0010;
                }
                goto Label_0057;
            }
        Label_0016:
            num3++;
        Label_001A:
            if (num3 < y[0].Length)
            {
                num = 0;
                if ((((uint) num7) | 15) != 0)
                {
                    goto Label_0010;
                }
                goto Label_010E;
            }
        Label_0057:
            if ((((uint) num8) + ((uint) num)) >= 0)
            {
                return Math.Sqrt(num9 / ((double) (y.Length * y[0].Length)));
            }
            goto Label_0254;
        Label_00F9:
            num2 = 0;
            while (num2 < funcs.Length)
            {
                if (numArray3[num2] < num6)
                {
                    numArray3[num2] = 0.0;
                }
                num2++;
            }
            Svdbksb(numArray, numArray3, numArray2, y, a);
            goto Label_013E;
        Label_010E:
            num4 = numArray3[num2];
            goto Label_011C;
        Label_0115:
            if (numArray3[num2] > num4)
            {
                goto Label_010E;
            }
        Label_011C:
            num2++;
        Label_0120:
            if (num2 < funcs.Length)
            {
                goto Label_0115;
            }
            num6 = num8 * num4;
            if (((uint) num9) >= 0)
            {
                goto Label_00F9;
            }
        Label_013E:
            if ((((uint) num) - ((uint) num7)) >= 0)
            {
                num9 = 0.0;
                num3 = 0;
                goto Label_001A;
            }
            goto Label_0010;
        Label_0254:
            if (((uint) num6) > uint.MaxValue)
            {
                goto Label_0016;
            }
            if ((((uint) num5) + ((uint) num3)) <= uint.MaxValue)
            {
                numArray = EngineArray.AllocateDouble2D(x.Length, funcs.Length);
            }
            numArray2 = EngineArray.AllocateDouble2D(funcs.Length, funcs.Length);
            numArray3 = new double[funcs.Length];
            num = 0;
            if (-2 != 0)
            {
            Label_018D:
                if (num < x.Length)
                {
                    num2 = 0;
                }
                else
                {
                    Svdcmp(numArray, numArray3, numArray2);
                    if (((uint) num) > uint.MaxValue)
                    {
                        goto Label_011C;
                    }
                    if (0 != 0)
                    {
                        goto Label_001A;
                    }
                    num4 = 0.0;
                    num2 = 0;
                    goto Label_0120;
                }
                while (true)
                {
                    if (num2 < funcs.Length)
                    {
                        numArray[num][num2] = funcs[num2].Calculate(x[num]);
                    }
                    else
                    {
                        if ((((uint) num3) | 1) == 0)
                        {
                            goto Label_00F9;
                        }
                        if ((((uint) num7) + ((uint) num5)) >= 0)
                        {
                            num++;
                        }
                        goto Label_018D;
                    }
                    num2++;
                    if (((uint) num3) <= uint.MaxValue)
                    {
                    }
                }
            }
            if (((uint) num8) <= uint.MaxValue)
            {
                goto Label_0115;
            }
            if ((((uint) num2) & 0) == 0)
            {
                goto Label_010E;
            }
            goto Label_0010;
        }
    }
}

