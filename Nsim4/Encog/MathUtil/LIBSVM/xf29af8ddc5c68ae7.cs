namespace Encog.MathUtil.LIBSVM
{
    using System;

    internal class xf29af8ddc5c68ae7
    {
        internal double[] x0043d86b33a97e1a;
        internal sbyte[] x1e218ceaee1bb583;
        internal double[] x26463655896fd90a;
        internal double x34ece0b1f98e7c82;
        internal int[] x3a8944dd364d7988;
        internal static readonly double x3f5ff8076fbf0702 = double.PositiveInfinity;
        internal const sbyte x43307ad5d6c3ee1e = 2;
        internal xf094e3229d63c9be x6648d9580110b138;
        internal double[] x6ad505c7ef981b0e;
        internal const sbyte x8ad3ade3f1f67fd6 = 1;
        internal const sbyte x9ad171c66b854384 = 0;
        internal int x9fc3ee03a439f6f0;
        internal int xa6ab0c05af75ec81;
        internal bool xb7ef94501c7fde4f;
        internal sbyte[] xc2730e9ae2855ac0;
        internal double xc7984f54f516d44e;
        internal double xcf0012763522c2a0;
        internal double[] xe7ebe10fa44d8d49;

        internal virtual double get_x857912840ffd015f(int x7b28e8a789372508)
        {
            if (this.x1e218ceaee1bb583[x7b28e8a789372508] <= 0)
            {
                return this.x34ece0b1f98e7c82;
            }
            return this.xcf0012763522c2a0;
        }

        internal virtual void x22c1a1a99dd27273(int x9fc3ee03a439f6f0, xf094e3229d63c9be x6648d9580110b138, double[] xe39569e0d3945457, sbyte[] x61a54ade09eff232, double[] x3947acd065ba0f13, double xcf0012763522c2a0, double x34ece0b1f98e7c82, double xc7984f54f516d44e, x99ad839b8792c4f3 x0a6250b187271ea3, int xe7f03bc283d49981)
        {
            int num;
            int num2;
            int num3;
            float[] numArray;
            double num4;
            int num5;
            int num6;
            int[] numArray2;
            int num8;
            int num9;
            float[] numArray3;
            float[] numArray4;
            double num10;
            double num11;
            double num12;
            double num13;
            double num14;
            double num15;
            double num16;
            double num17;
            double num18;
            double num19;
            int num20;
            bool flag2;
            int num21;
            double num22;
            int num23;
            int num24;
            this.x9fc3ee03a439f6f0 = x9fc3ee03a439f6f0;
            if ((((uint) num19) | 0xfffffffe) == 0)
            {
                goto Label_01F3;
            }
            this.x6648d9580110b138 = x6648d9580110b138;
            this.xe7ebe10fa44d8d49 = new double[xe39569e0d3945457.Length];
            xe39569e0d3945457.CopyTo(this.xe7ebe10fa44d8d49, 0);
            goto Label_0E7B;
        Label_00B9:
            while (num23 < x9fc3ee03a439f6f0)
            {
                num22 += this.x6ad505c7ef981b0e[num23] * (this.x26463655896fd90a[num23] + this.xe7ebe10fa44d8d49[num23]);
                num23++;
            }
            x0a6250b187271ea3.xa59bff7708de3a18 = num22 / 2.0;
            if ((((uint) xe7f03bc283d49981) + ((uint) num14)) >= 0)
            {
                num24 = 0;
                while (num24 < x9fc3ee03a439f6f0)
                {
                    x3947acd065ba0f13[this.x3a8944dd364d7988[num24]] = this.x6ad505c7ef981b0e[num24];
                    num24++;
                }
                if ((((uint) num14) & 0) == 0)
                {
                    if ((((uint) xe7f03bc283d49981) - ((uint) num16)) < 0)
                    {
                        return;
                    }
                    if ((((uint) num9) - ((uint) num5)) > uint.MaxValue)
                    {
                        goto Label_03C0;
                    }
                }
                x0a6250b187271ea3.x60d6bc12901483fc = xcf0012763522c2a0;
                x0a6250b187271ea3.x85baaa32728ba9e2 = x34ece0b1f98e7c82;
                return;
            }
            return;
        Label_00EE:
            x0a6250b187271ea3.x7c844fa40367c8be = this.x73ce32110d615317();
        Label_00FB:
            if ((((uint) num21) + ((uint) num9)) < 0)
            {
                goto Label_0202;
            }
            num22 = 0.0;
            num23 = 0;
            goto Label_00B9;
        Label_0165:
            num21 = 0;
            while (num21 < x9fc3ee03a439f6f0)
            {
                this.x0043d86b33a97e1a[num21] += num11 * numArray4[num21];
                num21++;
            }
            if (((uint) num16) <= uint.MaxValue)
            {
                goto Label_0770;
            }
            goto Label_0373;
        Label_01DD:
            if (num21 < x9fc3ee03a439f6f0)
            {
                this.x0043d86b33a97e1a[num21] += num10 * numArray3[num21];
                goto Label_024F;
            }
        Label_01F3:
            if (flag2 == this.xafe0f470f560f6d3(num9))
            {
                goto Label_0A81;
            }
        Label_0202:
            numArray4 = x6648d9580110b138.get_x6648d9580110b138(num9, x9fc3ee03a439f6f0);
            if (flag2)
            {
                num21 = 0;
            Label_019F:
                if (num21 < x9fc3ee03a439f6f0)
                {
                    this.x0043d86b33a97e1a[num21] -= num11 * numArray4[num21];
                    num21++;
                    if ((((uint) num20) | 8) != 0)
                    {
                        if ((((uint) num5) - ((uint) xcf0012763522c2a0)) <= uint.MaxValue)
                        {
                            if ((((uint) xc7984f54f516d44e) - ((uint) num13)) < 0)
                            {
                                goto Label_0ACA;
                            }
                            goto Label_019F;
                        }
                        goto Label_0165;
                    }
                    goto Label_0277;
                }
                goto Label_0A81;
            }
            goto Label_0165;
        Label_0214:
            if ((((uint) num12) & 0) != 0)
            {
                goto Label_0BAF;
            }
            goto Label_01DD;
        Label_024F:
            num21++;
            goto Label_01DD;
        Label_0277:
            if ((((uint) num24) + ((uint) num19)) > uint.MaxValue)
            {
                goto Label_0B8A;
            }
        Label_0292:
            if (num21 < x9fc3ee03a439f6f0)
            {
                this.x0043d86b33a97e1a[num21] -= num10 * numArray3[num21];
            }
            else
            {
                if (((uint) num2) > uint.MaxValue)
                {
                    goto Label_09AC;
                }
                goto Label_01F3;
            }
        Label_031A:
            num21++;
            goto Label_0277;
        Label_0373:
            num19 = this.x6ad505c7ef981b0e[num9] - num13;
            num20 = 0;
            while (num20 < this.xa6ab0c05af75ec81)
            {
                this.x26463655896fd90a[num20] += (numArray3[num20] * num18) + (numArray4[num20] * num19);
                num20++;
            }
            bool flag = this.xafe0f470f560f6d3(num8);
            flag2 = this.xafe0f470f560f6d3(num9);
            this.x3ba1f55281c03c4f(num8);
            this.x3ba1f55281c03c4f(num9);
            if (flag != this.xafe0f470f560f6d3(num8))
            {
                numArray3 = x6648d9580110b138.get_x6648d9580110b138(num8, x9fc3ee03a439f6f0);
            }
            else
            {
                goto Label_01F3;
            }
            if ((((uint) num13) + ((uint) flag)) > uint.MaxValue)
            {
                goto Label_0D55;
            }
            if (!flag)
            {
                num21 = 0;
                goto Label_0214;
            }
            num21 = 0;
            goto Label_0292;
        Label_03C0:
            if ((((uint) num5) + ((uint) num6)) > uint.MaxValue)
            {
                goto Label_046E;
            }
        Label_03F5:
            num18 = this.x6ad505c7ef981b0e[num8] - num12;
            if (((uint) num18) >= 0)
            {
                goto Label_0373;
            }
            goto Label_0770;
        Label_0433:
            if (this.x6ad505c7ef981b0e[num8] < 0.0)
            {
                this.x6ad505c7ef981b0e[num8] = 0.0;
                this.x6ad505c7ef981b0e[num9] = num17;
                goto Label_03C0;
            }
            goto Label_03F5;
        Label_044B:
            if (this.x6ad505c7ef981b0e[num9] > num11)
            {
                this.x6ad505c7ef981b0e[num9] = num11;
                goto Label_04A4;
            }
            goto Label_03F5;
        Label_045F:
            if (num17 > num11)
            {
                goto Label_044B;
            }
            goto Label_0433;
        Label_046E:
            if (this.x6ad505c7ef981b0e[num9] > num11)
            {
                this.x6ad505c7ef981b0e[num9] = num11;
                if (((uint) num11) <= uint.MaxValue)
                {
                    this.x6ad505c7ef981b0e[num8] = num11 + num15;
                    goto Label_03F5;
                }
                goto Label_06FF;
            }
            if ((((uint) num22) + ((uint) num20)) < 0)
            {
                goto Label_044B;
            }
            goto Label_03F5;
        Label_04A4:
            this.x6ad505c7ef981b0e[num8] = num17 - num11;
            if ((((uint) num17) - ((uint) x9fc3ee03a439f6f0)) < 0)
            {
                goto Label_0433;
            }
            goto Label_03F5;
        Label_050A:
            this.x6ad505c7ef981b0e[num9] = 0.0;
            this.x6ad505c7ef981b0e[num8] = num17;
            if ((((uint) num14) & 0) == 0)
            {
                goto Label_045F;
            }
        Label_053E:
            if (this.x6ad505c7ef981b0e[num9] < 0.0)
            {
                goto Label_050A;
            }
            if ((((uint) num3) + ((uint) num15)) >= 0)
            {
                goto Label_045F;
            }
            goto Label_04A4;
        Label_058B:
            this.x6ad505c7ef981b0e[num9] = num17 - num10;
            if ((((uint) flag2) | 3) == 0)
            {
                goto Label_07FC;
            }
            goto Label_045F;
        Label_05B9:
            this.x6ad505c7ef981b0e[num9] += num16;
            if (num17 <= num10)
            {
                goto Label_053E;
            }
            if (this.x6ad505c7ef981b0e[num8] <= num10)
            {
                goto Label_045F;
            }
        Label_05ED:
            this.x6ad505c7ef981b0e[num8] = num10;
            if ((((uint) num4) + ((uint) num2)) <= uint.MaxValue)
            {
                goto Label_058B;
            }
            if ((((uint) num10) & 0) != 0)
            {
                goto Label_09AC;
            }
            if ((((uint) num24) - ((uint) num20)) <= uint.MaxValue)
            {
                if (((uint) x34ece0b1f98e7c82) <= uint.MaxValue)
                {
                    goto Label_053E;
                }
                goto Label_050A;
            }
            goto Label_05B9;
        Label_06FF:
            if ((((uint) num10) | 2) != 0)
            {
                goto Label_05B9;
            }
        Label_0717:
            this.x6ad505c7ef981b0e[num8] = num10;
            this.x6ad505c7ef981b0e[num9] = num10 - num15;
            goto Label_03F5;
        Label_0735:
            if (num15 <= (num10 - num11))
            {
                if ((((uint) num17) & 0) == 0)
                {
                    goto Label_046E;
                }
                goto Label_05B9;
            }
            if (this.x6ad505c7ef981b0e[num8] <= num10)
            {
                goto Label_03F5;
            }
            goto Label_0717;
        Label_0770:
            if ((((uint) xe7f03bc283d49981) - ((uint) x34ece0b1f98e7c82)) >= 0)
            {
                goto Label_0A81;
            }
            if ((((uint) num22) + ((uint) num16)) >= 0)
            {
                goto Label_07FC;
            }
        Label_07A3:
            this.x6ad505c7ef981b0e[num9] = -num15;
            if (((uint) num) < 0)
            {
                goto Label_05ED;
            }
            if ((((uint) num19) & 0) != 0)
            {
                goto Label_0292;
            }
            if (((uint) num18) <= uint.MaxValue)
            {
                goto Label_0735;
            }
        Label_07FC:
            if (this.x6ad505c7ef981b0e[num8] >= 0.0)
            {
                goto Label_0735;
            }
            this.x6ad505c7ef981b0e[num8] = 0.0;
            goto Label_07A3;
        Label_0998:
            num8 = numArray2[0];
            num9 = numArray2[1];
            num6++;
            while (true)
            {
                numArray3 = x6648d9580110b138.get_x6648d9580110b138(num8, this.xa6ab0c05af75ec81);
                numArray4 = x6648d9580110b138.get_x6648d9580110b138(num9, this.xa6ab0c05af75ec81);
                num10 = this.get_x857912840ffd015f(num8);
                num11 = this.get_x857912840ffd015f(num9);
                num12 = this.x6ad505c7ef981b0e[num8];
                num13 = this.x6ad505c7ef981b0e[num9];
                if (this.x1e218ceaee1bb583[num8] == this.x1e218ceaee1bb583[num9])
                {
                    num16 = (this.x26463655896fd90a[num8] - this.x26463655896fd90a[num9]) / ((double) Math.Max((float) ((numArray3[num8] + numArray4[num9]) - (2f * numArray3[num9])), (float) 0f));
                    num17 = this.x6ad505c7ef981b0e[num8] + this.x6ad505c7ef981b0e[num9];
                    if ((((uint) num13) + ((uint) num16)) < 0)
                    {
                        goto Label_024F;
                    }
                    this.x6ad505c7ef981b0e[num8] -= num16;
                    goto Label_06FF;
                }
                num14 = (-this.x26463655896fd90a[num8] - this.x26463655896fd90a[num9]) / ((double) Math.Max((float) ((numArray3[num8] + numArray4[num9]) + (2f * numArray3[num9])), (float) 0f));
                num15 = this.x6ad505c7ef981b0e[num8] - this.x6ad505c7ef981b0e[num9];
                this.x6ad505c7ef981b0e[num8] += num14;
                if ((((uint) num8) | 0x7fffffff) != 0)
                {
                    if ((((uint) num9) - ((uint) num)) >= 0)
                    {
                        this.x6ad505c7ef981b0e[num9] += num14;
                        if (num15 > 0.0)
                        {
                            if (this.x6ad505c7ef981b0e[num9] >= 0.0)
                            {
                                goto Label_0735;
                            }
                            this.x6ad505c7ef981b0e[num9] = 0.0;
                        }
                        else
                        {
                            goto Label_07FC;
                        }
                    }
                    if ((((uint) xe7f03bc283d49981) + ((uint) num2)) <= uint.MaxValue)
                    {
                        this.x6ad505c7ef981b0e[num8] = num15;
                        goto Label_0735;
                    }
                    if ((((uint) num2) & 0) == 0)
                    {
                        goto Label_07FC;
                    }
                    goto Label_0C6B;
                }
            }
        Label_09AC:
            this.xa6ab0c05af75ec81 = x9fc3ee03a439f6f0;
            if (this.x3c0f9db5299ea9bb(numArray2) != 0)
            {
                goto Label_00EE;
            }
            int num7 = 1;
            goto Label_0998;
        Label_09C5:
            if (this.x3c0f9db5299ea9bb(numArray2) != 0)
            {
                this.xf5b89b08d9497860();
                goto Label_09AC;
            }
            goto Label_0998;
        Label_0A81:
            if (num6 > 0x2710)
            {
                goto Label_00EE;
            }
            while (true)
            {
                if (--num7 != 0)
                {
                    if ((((uint) num) - ((uint) num)) > uint.MaxValue)
                    {
                        goto Label_0277;
                    }
                    goto Label_09C5;
                }
                num7 = Math.Min(x9fc3ee03a439f6f0, 0x3e8);
                if (xe7f03bc283d49981 == 0)
                {
                    goto Label_09C5;
                }
                this.x572e6a691aa05e0a();
                if (((uint) num5) <= uint.MaxValue)
                {
                    goto Label_09C5;
                }
            }
        Label_0A8F:
            if (num3 < x9fc3ee03a439f6f0)
            {
                goto Label_0AE8;
            }
            num6 = 0;
            if ((((uint) num2) - ((uint) num5)) < 0)
            {
                goto Label_0E7B;
            }
            num7 = Math.Min(x9fc3ee03a439f6f0, 0x3e8) + 1;
            numArray2 = new int[2];
            goto Label_0A81;
        Label_0ACA:
            if (num5 < x9fc3ee03a439f6f0)
            {
                this.x0043d86b33a97e1a[num5] += this.get_x857912840ffd015f(num3) * numArray[num5];
                num5++;
                if ((((uint) num3) & 0) == 0)
                {
                    if ((((uint) flag2) | 15) != 0)
                    {
                        goto Label_0ACA;
                    }
                    if (((uint) flag) < 0)
                    {
                        goto Label_01F3;
                    }
                    goto Label_0AE8;
                }
                goto Label_0BAF;
            }
            if ((((uint) num17) & 0) != 0)
            {
                goto Label_031A;
            }
            goto Label_0AF4;
        Label_0AE8:
            if (!this.xedd159ce5b36c393(num3))
            {
                numArray = x6648d9580110b138.get_x6648d9580110b138(num3, x9fc3ee03a439f6f0);
                goto Label_0BAF;
            }
        Label_0AF4:
            num3++;
            if (((uint) num20) <= uint.MaxValue)
            {
                goto Label_0A8F;
            }
            goto Label_0A81;
        Label_0B17:
            num5 = 0;
            goto Label_0ACA;
        Label_0B8A:
            while (num5 < x9fc3ee03a439f6f0)
            {
                this.x26463655896fd90a[num5] += num4 * numArray[num5];
                num5++;
            }
            if (!this.xafe0f470f560f6d3(num3))
            {
                goto Label_0AF4;
            }
            if ((((uint) num5) & 0) == 0)
            {
                goto Label_0B17;
            }
        Label_0BAF:
            num4 = this.x6ad505c7ef981b0e[num3];
        Label_0BB9:
            num5 = 0;
            if ((((uint) num7) | 8) != 0)
            {
                goto Label_0B8A;
            }
            goto Label_0B17;
        Label_0C1B:
            if (num3 >= x9fc3ee03a439f6f0)
            {
                if ((((uint) flag) + ((uint) num7)) < 0)
                {
                    goto Label_045F;
                }
                if (((uint) num10) > uint.MaxValue)
                {
                    goto Label_00B9;
                }
                if (((uint) num23) > uint.MaxValue)
                {
                    if ((((uint) num20) & 0) != 0)
                    {
                        goto Label_045F;
                    }
                    goto Label_0433;
                }
                num3 = 0;
                goto Label_0A8F;
            }
        Label_0C6B:
            this.x26463655896fd90a[num3] = this.xe7ebe10fa44d8d49[num3];
            this.x0043d86b33a97e1a[num3] = 0.0;
            num3++;
            goto Label_0C1B;
        Label_0D2A:
            this.xcf0012763522c2a0 = xcf0012763522c2a0;
            this.x34ece0b1f98e7c82 = x34ece0b1f98e7c82;
            if ((((uint) num4) + ((uint) num24)) > uint.MaxValue)
            {
                goto Label_0A81;
            }
        Label_0D55:
            this.xc7984f54f516d44e = xc7984f54f516d44e;
            if ((((uint) num10) - ((uint) num13)) > uint.MaxValue)
            {
                goto Label_00FB;
            }
            if ((((uint) xe7f03bc283d49981) + ((uint) num7)) > uint.MaxValue)
            {
                goto Label_0214;
            }
            this.xb7ef94501c7fde4f = false;
            if ((((uint) flag2) + ((uint) num10)) <= uint.MaxValue)
            {
                this.xc2730e9ae2855ac0 = new sbyte[x9fc3ee03a439f6f0];
                for (num = 0; num < x9fc3ee03a439f6f0; num++)
                {
                    this.x3ba1f55281c03c4f(num);
                }
                this.x3a8944dd364d7988 = new int[x9fc3ee03a439f6f0];
                num2 = 0;
                while (true)
                {
                    if (num2 >= x9fc3ee03a439f6f0)
                    {
                        this.xa6ab0c05af75ec81 = x9fc3ee03a439f6f0;
                        this.x26463655896fd90a = new double[x9fc3ee03a439f6f0];
                        this.x0043d86b33a97e1a = new double[x9fc3ee03a439f6f0];
                        num3 = 0;
                        goto Label_0C1B;
                    }
                    this.x3a8944dd364d7988[num2] = num2;
                    num2++;
                }
            }
            goto Label_0D2A;
        Label_0E7B:
            this.x1e218ceaee1bb583 = new sbyte[x61a54ade09eff232.Length];
            x61a54ade09eff232.CopyTo(this.x1e218ceaee1bb583, 0);
            if ((((uint) num18) & 0) != 0)
            {
                goto Label_03C0;
            }
            if ((((uint) num8) + ((uint) num22)) > uint.MaxValue)
            {
                goto Label_0998;
            }
            this.x6ad505c7ef981b0e = new double[x3947acd065ba0f13.Length];
            x3947acd065ba0f13.CopyTo(this.x6ad505c7ef981b0e, 0);
            if ((((uint) num6) + ((uint) x34ece0b1f98e7c82)) < 0)
            {
                goto Label_0BB9;
            }
            if ((((uint) num14) - ((uint) num14)) < 0)
            {
                goto Label_058B;
            }
            goto Label_0D2A;
        }

        internal virtual void x3ba1f55281c03c4f(int x7b28e8a789372508)
        {
            if (this.x6ad505c7ef981b0e[x7b28e8a789372508] < this.get_x857912840ffd015f(x7b28e8a789372508))
            {
                if (this.x6ad505c7ef981b0e[x7b28e8a789372508] > 0.0)
                {
                    this.xc2730e9ae2855ac0[x7b28e8a789372508] = 2;
                    if ((((uint) x7b28e8a789372508) + ((uint) x7b28e8a789372508)) < 0)
                    {
                    }
                }
                else
                {
                    this.xc2730e9ae2855ac0[x7b28e8a789372508] = 0;
                }
            }
            else
            {
                this.xc2730e9ae2855ac0[x7b28e8a789372508] = 1;
            }
        }

        internal virtual int x3c0f9db5299ea9bb(int[] xb201bb6b1c78e422)
        {
            int num2;
            double num3;
            int num4;
            int num5;
            double num = -x3f5ff8076fbf0702;
            if ((((uint) num3) + ((uint) num5)) <= uint.MaxValue)
            {
                goto Label_0248;
            }
            if ((((uint) num) - ((uint) num2)) > uint.MaxValue)
            {
                if (2 != 0)
                {
                    goto Label_0132;
                }
                goto Label_014A;
            }
        Label_008B:
            if ((num + num3) < this.xc7984f54f516d44e)
            {
                return 1;
            }
            if (((((uint) num3) - ((uint) num3)) < 0) && ((((uint) num) | 0x7fffffff) == 0))
            {
                goto Label_008B;
            }
            xb201bb6b1c78e422[0] = num2;
            xb201bb6b1c78e422[1] = num4;
            if (((uint) num5) < 0)
            {
                goto Label_014A;
            }
            if (((uint) num3) > uint.MaxValue)
            {
                goto Label_01CF;
            }
            return 0;
        Label_00BE:
            num5++;
            if ((((uint) num2) - ((uint) num4)) > uint.MaxValue)
            {
                goto Label_00BE;
            }
            if ((((uint) num4) + ((uint) num3)) > uint.MaxValue)
            {
                goto Label_01E1;
            }
        Label_00F7:
            if (num5 < this.xa6ab0c05af75ec81)
            {
                if (this.x1e218ceaee1bb583[num5] != 1)
                {
                    goto Label_014A;
                }
                if (this.xafe0f470f560f6d3(num5))
                {
                    goto Label_01BE;
                }
                if (0 == 0)
                {
                    goto Label_01CF;
                }
                goto Label_0248;
            }
            goto Label_008B;
        Label_0106:
            if (this.xedd159ce5b36c393(num5))
            {
                goto Label_00BE;
            }
        Label_0114:
            if (this.x26463655896fd90a[num5] > num)
            {
                num = this.x26463655896fd90a[num5];
                num2 = num5;
            }
            goto Label_00BE;
        Label_0132:
            if (-this.x26463655896fd90a[num5] > num3)
            {
                num3 = -this.x26463655896fd90a[num5];
                if (((uint) num5) <= uint.MaxValue)
                {
                    num4 = num5;
                }
            }
            goto Label_0106;
        Label_014A:
            if (this.xafe0f470f560f6d3(num5))
            {
                goto Label_0106;
            }
            goto Label_0132;
        Label_01BE:
            if (!this.xedd159ce5b36c393(num5) && (this.x26463655896fd90a[num5] > num3))
            {
                num3 = this.x26463655896fd90a[num5];
                num4 = num5;
            }
            goto Label_00BE;
        Label_01CF:
            if (4 != 0)
            {
                goto Label_020B;
            }
        Label_01D6:
            num = -this.x26463655896fd90a[num5];
        Label_01E1:
            num2 = num5;
            if (((uint) num3) >= 0)
            {
                if ((((uint) num) | 2) == 0)
                {
                    goto Label_020B;
                }
                goto Label_01BE;
            }
            if (((uint) num5) > uint.MaxValue)
            {
                goto Label_0114;
            }
        Label_020B:
            if (-this.x26463655896fd90a[num5] > num)
            {
                goto Label_01D6;
            }
            goto Label_01BE;
        Label_0248:
            num2 = -1;
            num3 = -x3f5ff8076fbf0702;
            num4 = -1;
            num5 = 0;
            goto Label_00F7;
        }

        internal virtual void x572e6a691aa05e0a()
        {
            int num;
            int num2;
            int num3;
            double num4;
            double num5;
            int[] numArray = new int[2];
            goto Label_03D2;
        Label_000C:
            num3--;
        Label_0010:
            if (num3 >= this.xa6ab0c05af75ec81)
            {
            Label_010F:
                if (this.xedd159ce5b36c393(num3))
                {
                    if (this.x1e218ceaee1bb583[num3] != 1)
                    {
                        goto Label_0063;
                    }
                    if ((((uint) num4) <= uint.MaxValue) && (-this.x26463655896fd90a[num3] >= num4))
                    {
                        if (((uint) num) >= 0)
                        {
                            goto Label_008E;
                        }
                        goto Label_010F;
                    }
                    goto Label_000C;
                }
            }
            else
            {
                if (2 != 0)
                {
                    return;
                }
                goto Label_0063;
            }
        Label_0055:
            if (this.xafe0f470f560f6d3(num3))
            {
                if (this.x1e218ceaee1bb583[num3] != 1)
                {
                    if (this.x26463655896fd90a[num3] < num4)
                    {
                        goto Label_000C;
                    }
                    if (0 != 0)
                    {
                        goto Label_01D7;
                    }
                    if (((uint) num4) >= 0)
                    {
                        goto Label_008E;
                    }
                }
                else if ((((uint) num4) - ((uint) num5)) < 0)
                {
                    goto Label_01A8;
                }
                if (this.x26463655896fd90a[num3] >= num5)
                {
                    goto Label_008E;
                }
            }
            goto Label_000C;
        Label_0063:
            if (-this.x26463655896fd90a[num3] < num5)
            {
                goto Label_000C;
            }
            if ((((uint) num4) - ((uint) num3)) > uint.MaxValue)
            {
                goto Label_01D7;
            }
        Label_008E:
            this.x89083ecc6edaa4e0(num3, this.xa6ab0c05af75ec81);
            this.xa6ab0c05af75ec81++;
            num3++;
            if ((((uint) num) + ((uint) num3)) > uint.MaxValue)
            {
                goto Label_01BC;
            }
            if (((uint) num3) >= 0)
            {
                goto Label_000C;
            }
            goto Label_0055;
        Label_0190:
            this.xb7ef94501c7fde4f = true;
            this.xf5b89b08d9497860();
            num3 = this.x9fc3ee03a439f6f0 - 1;
            goto Label_0010;
        Label_01A8:
            if ((((uint) num4) & 0) == 0)
            {
                goto Label_0190;
            }
        Label_01BC:
            if (-(num4 + num5) <= (this.xc7984f54f516d44e * 10.0))
            {
                goto Label_0190;
            }
            return;
        Label_01D7:
            num3++;
        Label_01DB:
            if (num3 < this.xa6ab0c05af75ec81)
            {
                if (!this.xedd159ce5b36c393(num3))
                {
                    if (!this.xafe0f470f560f6d3(num3))
                    {
                        goto Label_01D7;
                    }
                    if (this.x1e218ceaee1bb583[num3] != 1)
                    {
                        if (this.x26463655896fd90a[num3] < num4)
                        {
                            goto Label_0234;
                        }
                        goto Label_01D7;
                    }
                    if (((uint) num4) >= 0)
                    {
                        if (((((uint) num5) | 15) != 0) && (((uint) num4) <= uint.MaxValue))
                        {
                            if (this.x26463655896fd90a[num3] >= num5)
                            {
                                goto Label_01D7;
                            }
                            if ((((uint) num3) - ((uint) num4)) <= uint.MaxValue)
                            {
                                goto Label_0234;
                            }
                            goto Label_03D2;
                        }
                        if ((((uint) num3) + ((uint) num5)) > uint.MaxValue)
                        {
                            goto Label_0375;
                        }
                        goto Label_01D7;
                    }
                    if (((uint) num2) <= uint.MaxValue)
                    {
                        goto Label_01DB;
                    }
                }
                if (this.x1e218ceaee1bb583[num3] == 1)
                {
                    if (-this.x26463655896fd90a[num3] >= num4)
                    {
                        goto Label_01D7;
                    }
                    goto Label_0234;
                }
                if (-this.x26463655896fd90a[num3] < num5)
                {
                    goto Label_0234;
                }
                goto Label_01D7;
            }
            if (!this.xb7ef94501c7fde4f)
            {
                goto Label_01BC;
            }
            if (0 == 0)
            {
                return;
            }
            goto Label_01A8;
        Label_0234:
            this.xa6ab0c05af75ec81--;
            this.x89083ecc6edaa4e0(num3, this.xa6ab0c05af75ec81);
            if (0 != 0)
            {
                goto Label_01BC;
            }
            num3--;
            if (((uint) num2) > uint.MaxValue)
            {
                return;
            }
            goto Label_01D7;
        Label_0375:
            if ((((uint) num3) | 0x7fffffff) != 0)
            {
                num5 = this.x1e218ceaee1bb583[num] * this.x26463655896fd90a[num];
                num3 = 0;
            }
            goto Label_01DB;
        Label_03D2:
            if ((((uint) num5) - ((uint) num3)) <= uint.MaxValue)
            {
                if (this.x3c0f9db5299ea9bb(numArray) != 0)
                {
                    return;
                }
                num = numArray[0];
                num2 = numArray[1];
                num4 = -this.x1e218ceaee1bb583[num2] * this.x26463655896fd90a[num2];
                goto Label_0375;
            }
        }

        internal virtual bool x619c04c90d9075b2(int x7b28e8a789372508)
        {
            return (this.xc2730e9ae2855ac0[x7b28e8a789372508] == 2);
        }

        internal virtual double x73ce32110d615317()
        {
            double num;
            int num6;
            double num7;
            int num2 = 0;
            double num3 = x3f5ff8076fbf0702;
            double num4 = -x3f5ff8076fbf0702;
            double num5 = 0.0;
            goto Label_017F;
        Label_0042:
            num6++;
        Label_0048:
            if (num6 < this.xa6ab0c05af75ec81)
            {
                num7 = this.x1e218ceaee1bb583[num6] * this.x26463655896fd90a[num6];
                goto Label_00F8;
            }
            if (num2 <= 0)
            {
                num = (num3 + num4) / 2.0;
            }
            else if ((((uint) num4) - ((uint) num)) <= uint.MaxValue)
            {
                return (num5 / ((double) num2));
            }
            if ((((uint) num5) & 0) != 0)
            {
                if ((((uint) num6) | uint.MaxValue) == 0)
                {
                    goto Label_00A4;
                }
            }
            else
            {
                if (((uint) num) >= 0)
                {
                    return num;
                }
                goto Label_00CC;
            }
        Label_0095:
            num4 = Math.Max(num4, num7);
            goto Label_0042;
        Label_00A4:
            if (this.x1e218ceaee1bb583[num6] < 0)
            {
                num3 = Math.Min(num3, num7);
                goto Label_0042;
            }
            goto Label_0095;
        Label_00CC:
            if ((((uint) num2) - ((uint) num7)) < 0)
            {
                if ((((uint) num7) | 0xfffffffe) == 0)
                {
                    goto Label_00F8;
                }
                goto Label_011C;
            }
            goto Label_00A4;
        Label_00F8:
            if (this.xedd159ce5b36c393(num6))
            {
                if (this.x1e218ceaee1bb583[num6] <= 0)
                {
                    num4 = Math.Max(num4, num7);
                    goto Label_0042;
                }
                num3 = Math.Min(num3, num7);
                if ((((uint) num6) | 3) != 0)
                {
                    goto Label_0042;
                }
                goto Label_017F;
            }
        Label_011C:
            if (!this.xafe0f470f560f6d3(num6))
            {
                num2++;
                num5 += num7;
                goto Label_0042;
            }
            goto Label_00CC;
        Label_017F:
            num6 = 0;
            goto Label_0048;
        }

        internal virtual void x89083ecc6edaa4e0(int x7b28e8a789372508, int x1148d0e8cc982c04)
        {
            sbyte num;
            sbyte num3;
            double num4;
            int num6;
            double num7;
            this.x6648d9580110b138.x89083ecc6edaa4e0(x7b28e8a789372508, x1148d0e8cc982c04);
            goto Label_0142;
        Label_0012:
            this.x0043d86b33a97e1a[x1148d0e8cc982c04] = num7;
            if ((((uint) x7b28e8a789372508) - ((uint) x7b28e8a789372508)) < 0)
            {
                goto Label_0115;
            }
            if ((((uint) num4) + ((uint) num3)) <= uint.MaxValue)
            {
                return;
            }
        Label_004F:
            num6 = this.x3a8944dd364d7988[x7b28e8a789372508];
            this.x3a8944dd364d7988[x7b28e8a789372508] = this.x3a8944dd364d7988[x1148d0e8cc982c04];
            this.x3a8944dd364d7988[x1148d0e8cc982c04] = num6;
        Label_0073:
            num7 = this.x0043d86b33a97e1a[x7b28e8a789372508];
            this.x0043d86b33a97e1a[x7b28e8a789372508] = this.x0043d86b33a97e1a[x1148d0e8cc982c04];
            goto Label_0012;
        Label_0115:
            num3 = this.xc2730e9ae2855ac0[x7b28e8a789372508];
            this.xc2730e9ae2855ac0[x7b28e8a789372508] = this.xc2730e9ae2855ac0[x1148d0e8cc982c04];
            this.xc2730e9ae2855ac0[x1148d0e8cc982c04] = num3;
            num4 = this.x6ad505c7ef981b0e[x7b28e8a789372508];
            if (0 != 0)
            {
                goto Label_0012;
            }
            this.x6ad505c7ef981b0e[x7b28e8a789372508] = this.x6ad505c7ef981b0e[x1148d0e8cc982c04];
            if (-1 == 0)
            {
                goto Label_0073;
            }
            this.x6ad505c7ef981b0e[x1148d0e8cc982c04] = num4;
            double num5 = this.xe7ebe10fa44d8d49[x7b28e8a789372508];
            this.xe7ebe10fa44d8d49[x7b28e8a789372508] = this.xe7ebe10fa44d8d49[x1148d0e8cc982c04];
            this.xe7ebe10fa44d8d49[x1148d0e8cc982c04] = num5;
            if (((uint) num4) >= 0)
            {
                goto Label_004F;
            }
        Label_0142:
            num = this.x1e218ceaee1bb583[x7b28e8a789372508];
            this.x1e218ceaee1bb583[x7b28e8a789372508] = this.x1e218ceaee1bb583[x1148d0e8cc982c04];
            this.x1e218ceaee1bb583[x1148d0e8cc982c04] = num;
            double num2 = this.x26463655896fd90a[x7b28e8a789372508];
            this.x26463655896fd90a[x7b28e8a789372508] = this.x26463655896fd90a[x1148d0e8cc982c04];
            this.x26463655896fd90a[x1148d0e8cc982c04] = num2;
            goto Label_0115;
        }

        internal virtual bool xafe0f470f560f6d3(int x7b28e8a789372508)
        {
            return (this.xc2730e9ae2855ac0[x7b28e8a789372508] == 1);
        }

        internal virtual bool xedd159ce5b36c393(int x7b28e8a789372508)
        {
            return (this.xc2730e9ae2855ac0[x7b28e8a789372508] == 0);
        }

        internal virtual void xf5b89b08d9497860()
        {
            int num;
            double num2;
            if (this.xa6ab0c05af75ec81 != this.x9fc3ee03a439f6f0)
            {
                num = this.xa6ab0c05af75ec81;
                goto Label_010B;
            }
            return;
        Label_0016:
            num++;
        Label_001A:
            if (num < this.xa6ab0c05af75ec81)
            {
            Label_0057:
                if (this.x619c04c90d9075b2(num))
                {
                    float[] numArray = this.x6648d9580110b138.get_x6648d9580110b138(num, this.x9fc3ee03a439f6f0);
                Label_00B6:
                    if (((uint) num) >= 0)
                    {
                        int num3;
                        num2 = this.x6ad505c7ef981b0e[num];
                        if ((((uint) num) + ((uint) num)) >= 0)
                        {
                            if (8 == 0)
                            {
                                goto Label_010B;
                            }
                            if (-2 == 0)
                            {
                                goto Label_00B6;
                            }
                            num3 = this.xa6ab0c05af75ec81;
                        }
                        while (num3 < this.x9fc3ee03a439f6f0)
                        {
                            this.x26463655896fd90a[num3] += num2 * numArray[num3];
                            num3++;
                        }
                        if (1 != 0)
                        {
                            goto Label_0016;
                        }
                        goto Label_0057;
                    }
                }
                goto Label_0016;
            }
            if ((((uint) num2) + ((uint) num2)) > uint.MaxValue)
            {
            }
            return;
        Label_010B:
            while (num < this.x9fc3ee03a439f6f0)
            {
                this.x26463655896fd90a[num] = this.x0043d86b33a97e1a[num] + this.xe7ebe10fa44d8d49[num];
                num++;
            }
            num = 0;
            goto Label_001A;
        }

        internal class x99ad839b8792c4f3
        {
            internal double x60d6bc12901483fc;
            internal double x7c844fa40367c8be;
            internal double x85baaa32728ba9e2;
            internal double xa59bff7708de3a18;
            internal double xb55b340ae3a3e4e0;
        }
    }
}

