namespace Encog.MathUtil.Matrices.Decomposition
{
    using Encog.MathUtil;
    using Encog.MathUtil.Matrices;
    using Encog.Util;
    using System;

    public class EigenvalueDecomposition
    {
        private readonly double[] e;
        private readonly double[] x054594f0edd1dc88;
        private double x208fa096f46adc5e;
        private readonly bool x41d3cb18b77e8f0d;
        private readonly int x57e9faf3ffdc07cc;
        private readonly double[] x73f821c71fe1e676;
        private double x80920100966c59a8;
        private readonly double[][] x9b4602d5e4f04fcb;
        private readonly double[][] xe24dd90acb923d68;

        public EigenvalueDecomposition(Matrix matrix)
        {
            double[][] data;
            int num;
            int num2;
            int num3;
            int num4;
            int num5;
            int num6;
            if (0 == 0)
            {
                data = matrix.Data;
                this.x57e9faf3ffdc07cc = matrix.Cols;
                this.x9b4602d5e4f04fcb = EngineArray.AllocateDouble2D(this.x57e9faf3ffdc07cc, this.x57e9faf3ffdc07cc);
                this.x73f821c71fe1e676 = new double[this.x57e9faf3ffdc07cc];
                this.e = new double[this.x57e9faf3ffdc07cc];
                if (((uint) num) > uint.MaxValue)
                {
                    goto Label_0191;
                }
                this.x41d3cb18b77e8f0d = true;
            }
            goto Label_01DF;
        Label_0011:
            if (num6 < this.x57e9faf3ffdc07cc)
            {
                goto Label_0067;
            }
            if ((((uint) num6) - ((uint) num4)) < 0)
            {
                goto Label_0011;
            }
            num5++;
        Label_0039:
            if (num5 < this.x57e9faf3ffdc07cc)
            {
                num6 = 0;
                if (0 != 0)
                {
                    goto Label_0039;
                }
                goto Label_0011;
            }
            this.x2b2099f4409958c3();
            this.xc63fe709fa5c8b33();
            if ((((uint) num) - ((uint) num4)) >= 0)
            {
                return;
            }
        Label_0067:
            this.xe24dd90acb923d68[num6][num5] = data[num6][num5];
            num6++;
            goto Label_0011;
        Label_0089:
            this.xe24dd90acb923d68 = EngineArray.AllocateDouble2D(this.x57e9faf3ffdc07cc, this.x57e9faf3ffdc07cc);
            this.x054594f0edd1dc88 = new double[this.x57e9faf3ffdc07cc];
            num5 = 0;
            goto Label_0039;
        Label_00D6:
            if (num4 < this.x57e9faf3ffdc07cc)
            {
                this.x9b4602d5e4f04fcb[num3][num4] = data[num3][num4];
                num4++;
                if ((((uint) num4) + ((uint) num5)) < 0)
                {
                    goto Label_017A;
                }
                if ((((uint) num3) & 0) == 0)
                {
                    goto Label_00D6;
                }
                goto Label_0195;
            }
            num3++;
        Label_00E4:
            if (num3 >= this.x57e9faf3ffdc07cc)
            {
                this.xce4ff3ba0c1ec350();
                this.xc46d13fa38efe36f();
                if (((uint) num5) <= uint.MaxValue)
                {
                    if (1 != 0)
                    {
                        return;
                    }
                    return;
                }
                goto Label_01DF;
            }
            num4 = 0;
            goto Label_00D6;
        Label_017A:
            if ((num < this.x57e9faf3ffdc07cc) & this.x41d3cb18b77e8f0d)
            {
                num2 = 0;
                goto Label_01AE;
            }
            if (!this.x41d3cb18b77e8f0d)
            {
                goto Label_0089;
            }
        Label_0191:
            num3 = 0;
            if ((((uint) num4) & 0) == 0)
            {
                goto Label_00E4;
            }
            goto Label_00D6;
        Label_0195:
            if (((uint) num) < 0)
            {
                goto Label_0089;
            }
            num2++;
        Label_01AE:
            if ((num2 < this.x57e9faf3ffdc07cc) & this.x41d3cb18b77e8f0d)
            {
                this.x41d3cb18b77e8f0d = data[num2][num] == data[num][num2];
                if ((((uint) num2) + ((uint) num)) >= 0)
                {
                    goto Label_0195;
                }
                goto Label_00D6;
            }
            num++;
            if ((((uint) num6) | 8) == 0)
            {
                goto Label_01AE;
            }
            goto Label_017A;
        Label_01DF:
            num = 0;
            goto Label_017A;
        }

        public double[] getImagEigenvalues()
        {
            return this.e;
        }

        private void x2b2099f4409958c3()
        {
            double num4;
            int num5;
            double num6;
            int num7;
            double num8;
            int num9;
            int num11;
            int num12;
            int num13;
            double num14;
            int num15;
            int num17;
            int num18;
            int num19;
            int num20;
            int num21;
            double num22;
            int num23;
            int num24;
            int num = 0;
            int num2 = this.x57e9faf3ffdc07cc - 1;
            int index = num + 1;
            goto Label_0244;
        Label_001F:
            num19--;
        Label_0025:
            if (num19 >= (num + 1))
            {
                goto Label_0095;
            }
            if ((((uint) num20) + ((uint) num6)) <= uint.MaxValue)
            {
                if ((((uint) num18) - ((uint) num22)) >= 0)
                {
                    return;
                }
                goto Label_05FD;
            }
            goto Label_007A;
        Label_004B:
            if (((uint) num12) < 0)
            {
                goto Label_0095;
            }
            if ((((uint) num5) + ((uint) num12)) < 0)
            {
                goto Label_0365;
            }
            goto Label_001F;
        Label_007A:
            num24++;
        Label_0080:
            if (num24 <= num2)
            {
                this.x9b4602d5e4f04fcb[num24][num21] += num22 * this.x054594f0edd1dc88[num24];
                goto Label_0134;
            }
            num21++;
        Label_008B:
            if (num21 <= num2)
            {
                goto Label_0178;
            }
            goto Label_004B;
        Label_0095:
            if (this.xe24dd90acb923d68[num19][num19 - 1] != 0.0)
            {
                num20 = num19 + 1;
                if (((uint) num17) < 0)
                {
                    goto Label_0178;
                }
                while (num20 <= num2)
                {
                    this.x054594f0edd1dc88[num20] = this.xe24dd90acb923d68[num20][num19 - 1];
                    num20++;
                }
                num21 = num19;
                goto Label_008B;
            }
            if ((((uint) num7) - ((uint) num22)) > uint.MaxValue)
            {
                goto Label_004B;
            }
            goto Label_001F;
        Label_00BE:
            if (num23 <= num2)
            {
                num22 += this.x054594f0edd1dc88[num23] * this.x9b4602d5e4f04fcb[num23][num21];
                if ((((uint) num23) & 0) != 0)
                {
                    goto Label_0231;
                }
                if (-2147483648 != 0)
                {
                    num23++;
                    goto Label_00BE;
                }
            }
            else
            {
                num22 = (num22 / this.x054594f0edd1dc88[num19]) / this.xe24dd90acb923d68[num19][num19 - 1];
                num24 = num19;
                goto Label_0080;
            }
        Label_0134:
            if (((uint) num14) >= 0)
            {
                goto Label_007A;
            }
            goto Label_00BE;
        Label_0178:
            num22 = 0.0;
            num23 = num19;
            goto Label_00BE;
        Label_01D3:
            if (num17 >= this.x57e9faf3ffdc07cc)
            {
                num19 = num2 - 1;
                goto Label_0025;
            }
            num18 = 0;
            while (num18 < this.x57e9faf3ffdc07cc)
            {
                this.x9b4602d5e4f04fcb[num17][num18] = (num17 == num18) ? 1.0 : 0.0;
                num18++;
            }
            num17++;
            goto Label_01D3;
        Label_0231:
            if (num4 != 0.0)
            {
                goto Label_0661;
            }
        Label_0240:
            index++;
        Label_0244:
            if (index <= (num2 - 1))
            {
                goto Label_06EA;
            }
            num17 = 0;
            goto Label_01D3;
        Label_02C6:
            this.x054594f0edd1dc88[index] = num4 * this.x054594f0edd1dc88[index];
            if (((uint) num7) <= uint.MaxValue)
            {
                goto Label_03ED;
            }
            goto Label_0393;
        Label_0324:
            if (num13 <= num2)
            {
                goto Label_0425;
            }
            goto Label_02C6;
        Label_0365:
            if (num15 >= index)
            {
                goto Label_03BA;
            }
            if ((((uint) num9) - ((uint) num2)) > uint.MaxValue)
            {
                goto Label_008B;
            }
            num14 /= num6;
            int num16 = index;
            while (num16 <= num2)
            {
                this.xe24dd90acb923d68[num13][num16] -= num14 * this.x054594f0edd1dc88[num16];
                num16++;
            }
            if (((uint) num18) < 0)
            {
                goto Label_0661;
            }
            if ((((uint) num22) & 0) != 0)
            {
                goto Label_0240;
            }
            num13++;
            goto Label_0324;
        Label_0393:
            if ((((uint) num21) + ((uint) num14)) <= uint.MaxValue)
            {
            }
            num15--;
            goto Label_0365;
        Label_03BA:
            num14 += this.x054594f0edd1dc88[num15] * this.xe24dd90acb923d68[num13][num15];
            if ((((uint) num23) + ((uint) num6)) <= uint.MaxValue)
            {
                goto Label_0393;
            }
        Label_03ED:
            if ((((uint) num22) & 0) == 0)
            {
                this.xe24dd90acb923d68[index][index - 1] = num4 * num8;
                if (((uint) num6) < 0)
                {
                    if ((((uint) num5) - ((uint) num13)) >= 0)
                    {
                        goto Label_03BA;
                    }
                    if ((((uint) num5) | 15) != 0)
                    {
                        goto Label_0393;
                    }
                    goto Label_02C6;
                }
            }
            if (((uint) num12) < 0)
            {
                goto Label_0438;
            }
            goto Label_0240;
        Label_0425:
            num14 = 0.0;
            num15 = num2;
            goto Label_0365;
        Label_0438:
            if ((((uint) num11) + ((uint) num16)) < 0)
            {
                goto Label_01D3;
            }
        Label_0453:
            num13 = 0;
            goto Label_0324;
        Label_0466:
            num9++;
        Label_046C:
            if (num9 < this.x57e9faf3ffdc07cc)
            {
                double num10 = 0.0;
                num11 = num2;
            Label_04DC:
                if (num11 >= index)
                {
                    num10 += this.x054594f0edd1dc88[num11] * this.xe24dd90acb923d68[num11][num9];
                    if ((((uint) num16) - ((uint) num14)) >= 0)
                    {
                        if ((((uint) num) + ((uint) num7)) <= uint.MaxValue)
                        {
                            if ((((uint) num18) - ((uint) num14)) < 0)
                            {
                                goto Label_06EA;
                            }
                            num11--;
                            if ((((uint) num22) + ((uint) num4)) >= 0)
                            {
                                goto Label_04DC;
                            }
                        }
                        else
                        {
                            goto Label_04DC;
                        }
                    }
                    goto Label_05FD;
                }
                num10 /= num6;
                if (((uint) num4) < 0)
                {
                    goto Label_0393;
                }
                for (num12 = index; num12 <= num2; num12++)
                {
                    this.xe24dd90acb923d68[num12][num9] -= num10 * this.x054594f0edd1dc88[num12];
                }
                goto Label_0466;
            }
            if ((((uint) index) - ((uint) num16)) >= 0)
            {
                goto Label_0438;
            }
            if (((uint) num14) < 0)
            {
                goto Label_0466;
            }
            goto Label_0425;
        Label_05D0:
            if (num7 >= index)
            {
                this.x054594f0edd1dc88[num7] = this.xe24dd90acb923d68[num7][index - 1] / num4;
                if ((((uint) num9) & 0) == 0)
                {
                    goto Label_05FD;
                }
                if (((uint) num4) >= 0)
                {
                }
                goto Label_06EA;
            }
            num8 = Math.Sqrt(num6);
            if (this.x054594f0edd1dc88[index] > 0.0)
            {
                num8 = -num8;
            }
            num6 -= this.x054594f0edd1dc88[index] * num8;
            this.x054594f0edd1dc88[index] -= num8;
            num9 = index;
            goto Label_046C;
        Label_05FD:
            num6 += this.x054594f0edd1dc88[num7] * this.x054594f0edd1dc88[num7];
            if ((((uint) num14) + ((uint) num6)) > uint.MaxValue)
            {
                goto Label_0466;
            }
            num7--;
            goto Label_05D0;
        Label_0661:
            num6 = 0.0;
            num7 = num2;
            goto Label_05D0;
        Label_06EA:
            num4 = 0.0;
            num5 = index;
            if ((((uint) num7) & 0) != 0)
            {
                goto Label_0453;
            }
            while (num5 <= num2)
            {
                num4 += Math.Abs(this.xe24dd90acb923d68[num5][index - 1]);
                num5++;
            }
            goto Label_0231;
        }

        private void x48ce4fc45b8350d5(double xd7f8db0aea3ba1f7, double x2a06971d5c6f475d, double xde19f8c8d279ef7b, double x42d9aaf1c2a4437b)
        {
            double num;
            double num2;
            if (Math.Abs(xde19f8c8d279ef7b) <= Math.Abs(x42d9aaf1c2a4437b))
            {
                num = xde19f8c8d279ef7b / x42d9aaf1c2a4437b;
                num2 = x42d9aaf1c2a4437b + (num * xde19f8c8d279ef7b);
                this.x208fa096f46adc5e = ((num * xd7f8db0aea3ba1f7) + x2a06971d5c6f475d) / num2;
                if ((((uint) num) & 0) == 0)
                {
                }
                this.x80920100966c59a8 = ((num * x2a06971d5c6f475d) - xd7f8db0aea3ba1f7) / num2;
                if ((((uint) num2) - ((uint) num2)) <= uint.MaxValue)
                {
                    return;
                }
            }
            else if ((((uint) xde19f8c8d279ef7b) - ((uint) num)) > uint.MaxValue)
            {
                return;
            }
            num = x42d9aaf1c2a4437b / xde19f8c8d279ef7b;
            num2 = xde19f8c8d279ef7b + (num * x42d9aaf1c2a4437b);
            this.x208fa096f46adc5e = (xd7f8db0aea3ba1f7 + (num * x2a06971d5c6f475d)) / num2;
            this.x80920100966c59a8 = (x2a06971d5c6f475d - (num * xd7f8db0aea3ba1f7)) / num2;
        }

        private void xc46d13fa38efe36f()
        {
            double num2;
            double num3;
            double num4;
            int num5;
            int num6;
            int num7;
            double num8;
            double num9;
            double num10;
            double num11;
            double num12;
            int num13;
            double num14;
            double num15;
            double num16;
            double num17;
            double num18;
            double num19;
            int num20;
            int num22;
            int num23;
            double num24;
            int num26;
            int index = 1;
            if ((((uint) num18) | 8) != 0)
            {
                while (true)
                {
                    if (index >= this.x57e9faf3ffdc07cc)
                    {
                        this.e[this.x57e9faf3ffdc07cc - 1] = 0.0;
                        num2 = 0.0;
                        num3 = 0.0;
                        num4 = Math.Pow(2.0, -52.0);
                        goto Label_06A0;
                    }
                    this.e[index - 1] = this.e[index];
                    index++;
                }
            }
            if ((((uint) num10) - ((uint) num20)) <= uint.MaxValue)
            {
                goto Label_057B;
            }
            goto Label_01CE;
        Label_006C:
            if (num26 < this.x57e9faf3ffdc07cc)
            {
                num24 = this.x9b4602d5e4f04fcb[num26][num22];
                this.x9b4602d5e4f04fcb[num26][num22] = this.x9b4602d5e4f04fcb[num26][num23];
                if ((((uint) num16) + ((uint) num23)) <= uint.MaxValue)
                {
                    this.x9b4602d5e4f04fcb[num26][num23] = num24;
                    if ((((uint) num17) | 8) == 0)
                    {
                        goto Label_0557;
                    }
                    num26++;
                    goto Label_006C;
                }
                goto Label_01FD;
            }
        Label_0076:
            num22++;
        Label_007C:
            if (num22 < (this.x57e9faf3ffdc07cc - 1))
            {
                num23 = num22;
                if ((((uint) num4) - ((uint) num2)) <= uint.MaxValue)
                {
                    goto Label_0146;
                }
                goto Label_01A4;
            }
            goto Label_01FD;
        Label_0146:
            num24 = this.x73f821c71fe1e676[num22];
            int num25 = num22 + 1;
            while (num25 < this.x57e9faf3ffdc07cc)
            {
                if (this.x73f821c71fe1e676[num25] < num24)
                {
                    num23 = num25;
                    num24 = this.x73f821c71fe1e676[num25];
                }
                num25++;
                if ((((uint) num9) - ((uint) num12)) > uint.MaxValue)
                {
                    goto Label_057B;
                }
            }
            if (num23 == num22)
            {
                goto Label_0076;
            }
            this.x73f821c71fe1e676[num23] = this.x73f821c71fe1e676[num22];
            this.x73f821c71fe1e676[num22] = num24;
            num26 = 0;
            goto Label_006C;
        Label_016D:
            num5++;
        Label_0173:
            if (num5 < this.x57e9faf3ffdc07cc)
            {
                goto Label_0646;
            }
            num22 = 0;
            goto Label_007C;
        Label_01A4:
            this.x73f821c71fe1e676[num5] += num2;
            this.e[num5] = 0.0;
            goto Label_016D;
        Label_01CE:
            if (num6 > num5)
            {
                num7 = 0;
                goto Label_05C8;
            }
            if (((uint) num23) <= uint.MaxValue)
            {
                goto Label_01A4;
            }
            goto Label_0146;
        Label_01FD:
            if ((((uint) num11) - ((uint) num17)) >= 0)
            {
                return;
            }
            goto Label_057B;
        Label_022E:
            if (num20 >= num5)
            {
                num16 = num15;
                num15 = num14;
                num19 = num18;
                num8 = num14 * this.e[num20];
            }
            else
            {
                num9 = ((((-num18 * num19) * num16) * num17) * this.e[num5]) / num11;
                this.e[num5] = num18 * num9;
                this.x73f821c71fe1e676[num5] = num14 * num9;
                if (Math.Abs(this.e[num5]) > (num4 * num3))
                {
                    goto Label_05C8;
                }
                if (0 == 0)
                {
                    goto Label_01A4;
                }
            }
        Label_03FF:
            if ((((uint) num11) - ((uint) num4)) < 0)
            {
                goto Label_06A0;
            }
            if ((((uint) num22) + ((uint) index)) <= uint.MaxValue)
            {
                num12 = num14 * num9;
                num10 = EncogMath.Hypot(num9, this.e[num20]);
                this.e[num20 + 1] = num18 * num10;
                num18 = this.e[num20] / num10;
                num14 = num9 / num10;
                num9 = (num14 * this.x73f821c71fe1e676[num20]) - (num18 * num8);
                this.x73f821c71fe1e676[num20 + 1] = num12 + (num18 * ((num14 * num8) + (num18 * this.x73f821c71fe1e676[num20])));
                int num21 = 0;
                if ((((uint) num10) - ((uint) num13)) >= 0)
                {
                    if ((((uint) num17) + ((uint) num6)) > uint.MaxValue)
                    {
                        if (((((uint) num8) & 0) == 0) && ((((uint) num16) + ((uint) num16)) > uint.MaxValue))
                        {
                            goto Label_007C;
                        }
                        goto Label_0602;
                    }
                    while (true)
                    {
                        if (num21 < this.x57e9faf3ffdc07cc)
                        {
                            num12 = this.x9b4602d5e4f04fcb[num21][num20 + 1];
                        }
                        else
                        {
                            if (((uint) num12) <= uint.MaxValue)
                            {
                                num20--;
                                goto Label_022E;
                            }
                            goto Label_01CE;
                        }
                        this.x9b4602d5e4f04fcb[num21][num20 + 1] = (num18 * this.x9b4602d5e4f04fcb[num21][num20]) + (num14 * num12);
                        if ((((uint) num8) + ((uint) num10)) > uint.MaxValue)
                        {
                            goto Label_006C;
                        }
                        this.x9b4602d5e4f04fcb[num21][num20] = (num14 * this.x9b4602d5e4f04fcb[num21][num20]) - (num18 * num12);
                        num21++;
                    }
                }
                goto Label_03FF;
            }
            goto Label_057B;
        Label_0498:
            num13 = num5 + 2;
            while (num13 < this.x57e9faf3ffdc07cc)
            {
                this.x73f821c71fe1e676[num13] -= num12;
                num13++;
            }
            num2 += num12;
            num9 = this.x73f821c71fe1e676[num6];
            num14 = 1.0;
            num15 = num14;
            num16 = num14;
            num17 = this.e[num5 + 1];
            if ((((uint) num9) | 15) == 0)
            {
                goto Label_0602;
            }
            num18 = 0.0;
            num19 = 0.0;
            num20 = num6 - 1;
            goto Label_022E;
        Label_050C:
            this.x73f821c71fe1e676[num5] = this.e[num5] / (num9 + num10);
            if ((((uint) num17) & 0) != 0)
            {
                goto Label_0646;
            }
            this.x73f821c71fe1e676[num5 + 1] = this.e[num5] * (num9 + num10);
            num11 = this.x73f821c71fe1e676[num5 + 1];
            num12 = num8 - this.x73f821c71fe1e676[num5];
            goto Label_0498;
        Label_0557:
            num10 = -num10;
            goto Label_050C;
        Label_057B:
            num9 = (this.x73f821c71fe1e676[num5 + 1] - num8) / (2.0 * this.e[num5]);
            num10 = EncogMath.Hypot(num9, 1.0);
            if (num9 < 0.0)
            {
                goto Label_0557;
            }
            if (((uint) num18) < 0)
            {
                goto Label_0498;
            }
            goto Label_050C;
        Label_05C8:
            num7++;
            num8 = this.x73f821c71fe1e676[num5];
            goto Label_057B;
        Label_05F8:
            if (num6 >= this.x57e9faf3ffdc07cc)
            {
                goto Label_01CE;
            }
        Label_0602:
            if (Math.Abs(this.e[num6]) > (num4 * num3))
            {
                num6++;
                goto Label_05F8;
            }
            goto Label_01CE;
        Label_0646:
            num3 = Math.Max(num3, Math.Abs(this.x73f821c71fe1e676[num5]) + Math.Abs(this.e[num5]));
            num6 = num5;
            if (((uint) num12) < 0)
            {
                goto Label_016D;
            }
            if ((((uint) num24) | 2) != 0)
            {
                goto Label_05F8;
            }
            goto Label_057B;
        Label_06A0:
            num5 = 0;
            goto Label_0173;
        }

        private void xc63fe709fa5c8b33()
        {
            // This item is obfuscated and can not be translated.
        }

        private void xce4ff3ba0c1ec350()
        {
            int num2;
            double num3;
            double num4;
            int num5;
            int num6;
            int num7;
            double num8;
            double num9;
            int num10;
            int num11;
            int num12;
            int num13;
            double num14;
            int num15;
            int num16;
            int num17;
            int num18;
            double num19;
            int num20;
            int num21;
            double num22;
            int num23;
            int num25;
            int num26;
            int index = 0;
            goto Label_08C0;
        Label_0022:
            num26++;
            if ((((uint) num25) + ((uint) num15)) > uint.MaxValue)
            {
                goto Label_0232;
            }
        Label_0043:
            if (num26 >= this.x57e9faf3ffdc07cc)
            {
                this.x9b4602d5e4f04fcb[this.x57e9faf3ffdc07cc - 1][this.x57e9faf3ffdc07cc - 1] = 1.0;
                this.e[0] = 0.0;
                if (((uint) num4) >= 0)
                {
                    return;
                }
                goto Label_0241;
            }
            this.x73f821c71fe1e676[num26] = this.x9b4602d5e4f04fcb[this.x57e9faf3ffdc07cc - 1][num26];
            this.x9b4602d5e4f04fcb[this.x57e9faf3ffdc07cc - 1][num26] = 0.0;
            goto Label_0022;
        Label_00A1:
            if (num18 < (this.x57e9faf3ffdc07cc - 1))
            {
                this.x9b4602d5e4f04fcb[this.x57e9faf3ffdc07cc - 1][num18] = this.x9b4602d5e4f04fcb[num18][num18];
                if ((((uint) num7) + ((uint) index)) < 0)
                {
                    goto Label_00DC;
                }
                this.x9b4602d5e4f04fcb[num18][num18] = 1.0;
                if ((((uint) num21) - ((uint) num4)) < 0)
                {
                    goto Label_01E3;
                }
                num19 = this.x73f821c71fe1e676[num18 + 1];
                if (num19 == 0.0)
                {
                    goto Label_017C;
                }
                goto Label_0241;
            }
            num26 = 0;
            goto Label_0043;
        Label_00DC:
            if ((((uint) num23) + ((uint) num2)) > uint.MaxValue)
            {
                goto Label_0811;
            }
            goto Label_00A1;
        Label_0173:
            if (num21 <= num18)
            {
                goto Label_0232;
            }
        Label_017C:
            num25 = 0;
        Label_00B5:
            if (num25 <= num18)
            {
                this.x9b4602d5e4f04fcb[num25][num18 + 1] = 0.0;
                num25++;
                if ((((uint) num23) + ((uint) num2)) <= uint.MaxValue)
                {
                    goto Label_00B5;
                }
                goto Label_01DE;
            }
            num18++;
            if ((((uint) num3) + ((uint) num9)) < 0)
            {
                goto Label_04B1;
            }
            goto Label_00DC;
        Label_01A8:
            if (num23 <= num18)
            {
                goto Label_01FE;
            }
            if (((uint) num26) < 0)
            {
                goto Label_0458;
            }
            int num24 = 0;
            if ((((uint) num6) + ((uint) num14)) >= 0)
            {
                while (num24 <= num18)
                {
                    this.x9b4602d5e4f04fcb[num24][num21] -= num22 * this.x73f821c71fe1e676[num24];
                    num24++;
                }
                num21++;
                goto Label_0173;
            }
        Label_01DE:
            num23 = 0;
            goto Label_01A8;
        Label_01E3:
            if ((((uint) num22) | 8) == 0)
            {
                goto Label_05E8;
            }
        Label_01FE:
            num22 += this.x9b4602d5e4f04fcb[num23][num18 + 1] * this.x9b4602d5e4f04fcb[num23][num21];
            num23++;
            goto Label_01A8;
        Label_0232:
            num22 = 0.0;
            goto Label_01DE;
        Label_0241:
            num20 = 0;
            while (num20 <= num18)
            {
                this.x73f821c71fe1e676[num20] = this.x9b4602d5e4f04fcb[num20][num18 + 1] / num19;
                num20++;
            }
            num21 = 0;
            goto Label_0173;
        Label_02CE:
            if (num2 > 0)
            {
                num3 = 0.0;
                num4 = 0.0;
                goto Label_08A3;
            }
            num18 = 0;
            goto Label_00A1;
        Label_0348:
            if (num16 < num2)
            {
                num8 = this.x73f821c71fe1e676[num16];
                num9 = this.e[num16];
                goto Label_043A;
            }
        Label_034D:
            this.x73f821c71fe1e676[num2] = num4;
            num2--;
            goto Label_02CE;
        Label_0365:
            num17 = num16;
            goto Label_03A6;
        Label_036B:
            this.x9b4602d5e4f04fcb[num17][num16] -= (num8 * this.e[num17]) + (num9 * this.x73f821c71fe1e676[num17]);
            num17++;
        Label_03A6:
            if (num17 <= (num2 - 1))
            {
                goto Label_036B;
            }
            this.x73f821c71fe1e676[num16] = this.x9b4602d5e4f04fcb[num2 - 1][num16];
            this.x9b4602d5e4f04fcb[num2][num16] = 0.0;
            num16++;
            goto Label_0348;
        Label_043A:
            if ((((uint) num8) + ((uint) num16)) >= 0)
            {
                goto Label_0365;
            }
        Label_0452:
            num13++;
        Label_0458:
            if (num13 < num2)
            {
                goto Label_04B1;
            }
            num14 = num8 / (num4 + num4);
            if ((((uint) num13) | 0xfffffffe) == 0)
            {
                goto Label_0636;
            }
            num15 = 0;
            while (num15 < num2)
            {
                this.e[num15] -= num14 * this.x73f821c71fe1e676[num15];
                if ((((uint) num13) + ((uint) num22)) < 0)
                {
                    goto Label_0365;
                }
                num15++;
            }
            if ((((uint) num23) + ((uint) num15)) <= uint.MaxValue)
            {
                num16 = 0;
                goto Label_0348;
            }
            goto Label_043A;
        Label_0499:
            if (num11 < num2)
            {
                num8 = this.x73f821c71fe1e676[num11];
                this.x9b4602d5e4f04fcb[num11][num2] = num8;
                num9 = this.e[num11] + (this.x9b4602d5e4f04fcb[num11][num11] * num8);
                num12 = num11 + 1;
                goto Label_054B;
            }
        Label_04A1:
            num8 = 0.0;
            num13 = 0;
            goto Label_0458;
        Label_04B1:
            this.e[num13] /= num4;
            num8 += this.e[num13] * this.x73f821c71fe1e676[num13];
            if (((uint) num14) >= 0)
            {
                if ((((uint) num3) - ((uint) num14)) <= uint.MaxValue)
                {
                    if ((((uint) num6) - ((uint) num9)) >= 0)
                    {
                        goto Label_0452;
                    }
                    goto Label_08C0;
                }
                goto Label_05D3;
            }
            goto Label_0566;
        Label_054B:
            while (num12 <= (num2 - 1))
            {
                num9 += this.x9b4602d5e4f04fcb[num12][num11] * this.x73f821c71fe1e676[num12];
                this.e[num12] += this.x9b4602d5e4f04fcb[num12][num11] * num8;
                num12++;
            }
            this.e[num11] = num9;
            num11++;
            goto Label_0499;
        Label_0566:
            num11 = 0;
        Label_0569:
            if (((uint) num10) < 0)
            {
                goto Label_0615;
            }
            goto Label_0499;
        Label_05D3:
            if (((uint) num22) > uint.MaxValue)
            {
                goto Label_01E3;
            }
        Label_05E8:
            this.e[num10] = 0.0;
            if ((((uint) num11) + ((uint) num22)) > uint.MaxValue)
            {
                goto Label_036B;
            }
        Label_0615:
            num10++;
            if ((((uint) num22) - ((uint) index)) > uint.MaxValue)
            {
                goto Label_054B;
            }
        Label_0636:
            if (num10 < num2)
            {
                goto Label_05E8;
            }
            goto Label_0566;
        Label_0674:
            this.e[num2] = num3 * num9;
            if ((((uint) num18) + ((uint) num10)) > uint.MaxValue)
            {
                goto Label_0022;
            }
            num4 -= num8 * num9;
            this.x73f821c71fe1e676[num2 - 1] = num8 - num9;
            if ((((uint) num11) + ((uint) num13)) > uint.MaxValue)
            {
                goto Label_04A1;
            }
            num10 = 0;
            goto Label_0636;
        Label_07A1:
            if ((((uint) num10) | 1) == 0)
            {
                goto Label_054B;
            }
        Label_07BC:
            this.e[num2] = this.x73f821c71fe1e676[num2 - 1];
            num6 = 0;
        Label_0724:
            if (num6 < num2)
            {
                this.x73f821c71fe1e676[num6] = this.x9b4602d5e4f04fcb[num2 - 1][num6];
                if ((((uint) num21) - ((uint) num15)) < 0)
                {
                    goto Label_08A3;
                }
                this.x9b4602d5e4f04fcb[num2][num6] = 0.0;
                this.x9b4602d5e4f04fcb[num6][num2] = 0.0;
                num6++;
                if ((((uint) num11) + ((uint) num7)) >= 0)
                {
                    if ((((uint) num18) - ((uint) num12)) <= uint.MaxValue)
                    {
                        goto Label_0724;
                    }
                    goto Label_0452;
                }
                goto Label_07A1;
            }
            goto Label_034D;
        Label_0811:
            if (num3 != 0.0)
            {
                for (num7 = 0; num7 < num2; num7++)
                {
                    this.x73f821c71fe1e676[num7] /= num3;
                    num4 += this.x73f821c71fe1e676[num7] * this.x73f821c71fe1e676[num7];
                }
                if ((((uint) num26) | 0xfffffffe) != 0)
                {
                    num8 = this.x73f821c71fe1e676[num2 - 1];
                    num9 = Math.Sqrt(num4);
                    if (num8 > 0.0)
                    {
                        num9 = -num9;
                    }
                    goto Label_0674;
                }
                goto Label_05D3;
            }
            if (((uint) num14) >= 0)
            {
                goto Label_07A1;
            }
        Label_0832:
            num5 = 0;
            while (num5 < num2)
            {
                num3 += Math.Abs(this.x73f821c71fe1e676[num5]);
                num5++;
            }
            if (((uint) num6) < 0)
            {
                goto Label_07BC;
            }
            goto Label_0811;
        Label_08A3:
            if ((((uint) num15) - ((uint) num5)) > uint.MaxValue)
            {
                goto Label_0674;
            }
            goto Label_0832;
        Label_08C0:
            if (index >= this.x57e9faf3ffdc07cc)
            {
                num2 = this.x57e9faf3ffdc07cc - 1;
                if ((((uint) num20) - ((uint) num23)) < 0)
                {
                    goto Label_0569;
                }
                goto Label_02CE;
            }
            this.x73f821c71fe1e676[index] = this.x9b4602d5e4f04fcb[this.x57e9faf3ffdc07cc - 1][index];
            index++;
            goto Label_08C0;
        }

        public Matrix D
        {
            get
            {
                int num2;
                Matrix matrix = new Matrix(this.x57e9faf3ffdc07cc, this.x57e9faf3ffdc07cc);
                double[][] data = matrix.Data;
                int index = 0;
                goto Label_001B;
            Label_0017:
                index++;
            Label_001B:
                if (index < this.x57e9faf3ffdc07cc)
                {
                    num2 = 0;
                    goto Label_00C9;
                }
                if ((((uint) index) + ((uint) num2)) <= uint.MaxValue)
                {
                    return matrix;
                }
                if ((((uint) num2) + ((uint) index)) >= 0)
                {
                    goto Label_00FC;
                }
            Label_0047:
                if (this.e[index] < 0.0)
                {
                    data[index][index - 1] = this.e[index];
                    if ((((uint) num2) - ((uint) index)) < 0)
                    {
                        goto Label_0047;
                    }
                }
                else
                {
                    goto Label_0017;
                }
                if (((uint) index) > uint.MaxValue)
                {
                    goto Label_0047;
                }
                goto Label_0017;
            Label_00C9:
                if (num2 >= this.x57e9faf3ffdc07cc)
                {
                    data[index][index] = this.x73f821c71fe1e676[index];
                    if (this.e[index] > 0.0)
                    {
                        data[index][index + 1] = this.e[index];
                        goto Label_0017;
                    }
                    goto Label_0047;
                }
            Label_00FC:
                data[index][num2] = 0.0;
                num2++;
                if ((((uint) num2) - ((uint) num2)) >= 0)
                {
                }
                goto Label_00C9;
            }
        }

        public double[] RealEigenvalues
        {
            get
            {
                return this.x73f821c71fe1e676;
            }
        }

        public Matrix V
        {
            get
            {
                return new Matrix(this.x9b4602d5e4f04fcb);
            }
        }
    }
}

