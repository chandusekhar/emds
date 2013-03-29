namespace Encog.MathUtil.LIBSVM
{
    using System;

    internal sealed class x4964dba9a96eb09f : xf29af8ddc5c68ae7
    {
        private xf29af8ddc5c68ae7.x99ad839b8792c4f3 x0a6250b187271ea3;

        internal override void x22c1a1a99dd27273(int x9fc3ee03a439f6f0, xf094e3229d63c9be x6648d9580110b138, double[] xe7ebe10fa44d8d49, sbyte[] x1e218ceaee1bb583, double[] x6ad505c7ef981b0e, double xcf0012763522c2a0, double x34ece0b1f98e7c82, double xc7984f54f516d44e, xf29af8ddc5c68ae7.x99ad839b8792c4f3 x0a6250b187271ea3, int xe7f03bc283d49981)
        {
            this.x0a6250b187271ea3 = x0a6250b187271ea3;
            base.x22c1a1a99dd27273(x9fc3ee03a439f6f0, x6648d9580110b138, xe7ebe10fa44d8d49, x1e218ceaee1bb583, x6ad505c7ef981b0e, xcf0012763522c2a0, x34ece0b1f98e7c82, xc7984f54f516d44e, x0a6250b187271ea3, xe7f03bc283d49981);
        }

        internal override int x3c0f9db5299ea9bb(int[] xb201bb6b1c78e422)
        {
            int num2;
            double num3;
            int num4;
            double num5;
            int num6;
            double num7;
            int num8;
            int num9;
            double num = -xf29af8ddc5c68ae7.x3f5ff8076fbf0702;
            if (-1 != 0)
            {
                goto Label_039D;
            }
            goto Label_01BC;
        Label_004D:
            xb201bb6b1c78e422[1] = num4;
            if ((((uint) num9) | 2) == 0)
            {
                goto Label_023B;
            }
            goto Label_03E1;
        Label_00AF:
            if ((((uint) num9) + ((uint) num7)) < 0)
            {
                goto Label_00F6;
            }
        Label_00E1:
            num9++;
        Label_00E7:
            if (num9 < base.xa6ab0c05af75ec81)
            {
                if (base.x1e218ceaee1bb583[num9] == 1)
                {
                    goto Label_02E6;
                }
                goto Label_023B;
            }
            if (Math.Max((double) (num + num3), (double) (num5 + num7)) < base.xc7984f54f516d44e)
            {
                return 1;
            }
            if ((num + num3) <= (num5 + num7))
            {
                xb201bb6b1c78e422[0] = num6;
                xb201bb6b1c78e422[1] = num8;
                if ((((uint) num3) - ((uint) num5)) <= uint.MaxValue)
                {
                    if ((((uint) num) + ((uint) num6)) >= 0)
                    {
                        if (((((uint) num8) | 0xfffffffe) != 0) && ((((uint) num) + ((uint) num)) < 0))
                        {
                            goto Label_004D;
                        }
                        goto Label_03E1;
                    }
                    goto Label_01BC;
                }
                goto Label_014D;
            }
            xb201bb6b1c78e422[0] = num2;
            goto Label_004D;
        Label_00F6:
            if ((((uint) num2) | 2) == 0)
            {
                goto Label_0175;
            }
            if ((((uint) num8) >= 0) && ((((uint) num9) + ((uint) num3)) <= uint.MaxValue))
            {
                goto Label_00E1;
            }
            goto Label_00AF;
        Label_014D:
            if (base.x26463655896fd90a[num9] <= num7)
            {
                goto Label_00AF;
            }
            num7 = base.x26463655896fd90a[num9];
            num8 = num9;
            goto Label_00F6;
        Label_0175:
            if (!this.xedd159ce5b36c393(num9))
            {
                if (base.x26463655896fd90a[num9] > num3)
                {
                    num3 = base.x26463655896fd90a[num9];
                    num4 = num9;
                }
                else if (((uint) num7) > uint.MaxValue)
                {
                    goto Label_037C;
                }
            }
            goto Label_00E1;
        Label_01BC:
            if (this.xedd159ce5b36c393(num9))
            {
                goto Label_00E1;
            }
            if (0 == 0)
            {
                if ((((uint) num2) | 1) != 0)
                {
                    goto Label_014D;
                }
                goto Label_01BC;
            }
        Label_023B:
            if (!this.xafe0f470f560f6d3(num9))
            {
                if ((((uint) num4) - ((uint) num9)) <= uint.MaxValue)
                {
                    if ((((uint) num7) | 15) == 0)
                    {
                        if ((((uint) num2) - ((uint) num4)) > uint.MaxValue)
                        {
                            goto Label_0360;
                        }
                        if (-2147483648 == 0)
                        {
                            goto Label_023B;
                        }
                    }
                    if (-base.x26463655896fd90a[num9] > num5)
                    {
                        num5 = -base.x26463655896fd90a[num9];
                        num6 = num9;
                    }
                    else
                    {
                        goto Label_01BC;
                    }
                }
                if ((((uint) num6) - ((uint) num3)) < 0)
                {
                    goto Label_023B;
                }
            }
            goto Label_01BC;
        Label_02E6:
            if (this.xafe0f470f560f6d3(num9))
            {
                goto Label_0175;
            }
        Label_02F0:
            if (-base.x26463655896fd90a[num9] <= num)
            {
                if ((((uint) num9) + ((uint) num7)) >= 0)
                {
                    if ((((uint) num4) + ((uint) num4)) > uint.MaxValue)
                    {
                        goto Label_0358;
                    }
                    goto Label_0175;
                }
                if ((((uint) num7) + ((uint) num7)) > uint.MaxValue)
                {
                    goto Label_02E6;
                }
                if ((((uint) num6) & 0) == 0)
                {
                    goto Label_023B;
                }
                goto Label_039D;
            }
            num = -base.x26463655896fd90a[num9];
        Label_0358:
            num2 = num9;
            goto Label_0175;
        Label_0360:
            num8 = -1;
            num9 = 0;
            goto Label_00E7;
        Label_037C:
            num6 = -1;
            num7 = -xf29af8ddc5c68ae7.x3f5ff8076fbf0702;
            if ((((uint) num2) & 0) == 0)
            {
                goto Label_0360;
            }
            goto Label_02E6;
        Label_039D:
            if ((((uint) num) + ((uint) num8)) > uint.MaxValue)
            {
                goto Label_02E6;
            }
            if ((((uint) num) + ((uint) num4)) < 0)
            {
                goto Label_02F0;
            }
            num2 = -1;
            num3 = -xf29af8ddc5c68ae7.x3f5ff8076fbf0702;
            num4 = -1;
            num5 = -xf29af8ddc5c68ae7.x3f5ff8076fbf0702;
            goto Label_037C;
        Label_03E1:
            return 0;
        }

        internal override void x572e6a691aa05e0a()
        {
            double num2;
            double num3;
            double num4;
            int num5;
            double num6;
            double num7;
            double num8;
            double num9;
            double num = -xf29af8ddc5c68ae7.x3f5ff8076fbf0702;
            if ((((uint) num3) + ((uint) num7)) >= 0)
            {
                goto Label_0529;
            }
            goto Label_009B;
        Label_003C:
            num5--;
        Label_0042:
            if (num5 >= base.xa6ab0c05af75ec81)
            {
                if (!this.xedd159ce5b36c393(num5))
                {
                    if (this.xafe0f470f560f6d3(num5))
                    {
                        goto Label_00C1;
                    }
                }
                else if (base.x1e218ceaee1bb583[num5] == 1)
                {
                    if (-base.x26463655896fd90a[num5] >= num6)
                    {
                        goto Label_0062;
                    }
                }
                else if ((((uint) num9) <= uint.MaxValue) && (-base.x26463655896fd90a[num5] >= num8))
                {
                    goto Label_0062;
                }
                goto Label_003C;
            }
            return;
        Label_0062:
            this.x89083ecc6edaa4e0(num5, base.xa6ab0c05af75ec81);
            base.xa6ab0c05af75ec81++;
            if (((uint) num) > uint.MaxValue)
            {
                goto Label_0155;
            }
            num5++;
            goto Label_003C;
        Label_009B:
            if (base.x26463655896fd90a[num5] < num9)
            {
                goto Label_003C;
            }
            goto Label_0062;
        Label_00C1:
            if (base.x1e218ceaee1bb583[num5] != 1)
            {
                goto Label_009B;
            }
            if (base.x26463655896fd90a[num5] >= num7)
            {
                goto Label_0062;
            }
            goto Label_003C;
        Label_010E:
            this.xf5b89b08d9497860();
            num5 = base.x9fc3ee03a439f6f0 - 1;
            goto Label_0042;
        Label_013A:
            base.xb7ef94501c7fde4f = true;
            goto Label_010E;
        Label_014D:
            if (base.xb7ef94501c7fde4f)
            {
                return;
            }
        Label_0155:
            if (Math.Max(-(num6 + num7), -(num8 + num9)) <= (base.xc7984f54f516d44e * 10.0))
            {
                goto Label_0339;
            }
            if ((((uint) num8) & 0) != 0)
            {
                goto Label_014D;
            }
            return;
        Label_019A:
            num5++;
        Label_01A0:
            if (num5 < base.xa6ab0c05af75ec81)
            {
                goto Label_025C;
            }
            if ((((uint) num) | 15) != 0)
            {
                goto Label_014D;
            }
            goto Label_0339;
        Label_01AF:
            base.xa6ab0c05af75ec81--;
            if (((uint) num2) > uint.MaxValue)
            {
                goto Label_010E;
            }
            this.x89083ecc6edaa4e0(num5, base.xa6ab0c05af75ec81);
            num5--;
            goto Label_019A;
        Label_0204:
            if (base.x26463655896fd90a[num5] >= num9)
            {
                goto Label_019A;
            }
            goto Label_01AF;
        Label_025C:
            if (this.xedd159ce5b36c393(num5))
            {
                goto Label_0283;
            }
            if (this.xafe0f470f560f6d3(num5))
            {
                if (base.x1e218ceaee1bb583[num5] != 1)
                {
                    if (((uint) num6) > uint.MaxValue)
                    {
                        goto Label_0461;
                    }
                    if ((((uint) num4) - ((uint) num7)) <= uint.MaxValue)
                    {
                        goto Label_0204;
                    }
                    goto Label_02BC;
                }
                if (base.x26463655896fd90a[num5] < num7)
                {
                    goto Label_01AF;
                }
                goto Label_019A;
            }
            if (((uint) num4) <= uint.MaxValue)
            {
                goto Label_019A;
            }
            goto Label_0204;
        Label_026D:
            if (-base.x26463655896fd90a[num5] < num6)
            {
                goto Label_01AF;
            }
            goto Label_019A;
        Label_0283:
            if (base.x1e218ceaee1bb583[num5] == 1)
            {
                goto Label_026D;
            }
            if (-base.x26463655896fd90a[num5] < num8)
            {
                goto Label_01AF;
            }
            goto Label_019A;
        Label_02BC:
            if ((((uint) num7) + ((uint) num7)) >= 0)
            {
                goto Label_0283;
            }
            if (-2 != 0)
            {
                goto Label_026D;
            }
            goto Label_0204;
        Label_0339:
            if ((((uint) num5) | 0x7fffffff) != 0)
            {
                if (-2 != 0)
                {
                    goto Label_013A;
                }
                goto Label_009B;
            }
            goto Label_0529;
        Label_036A:
            num9 = -num3;
            if (0 != 0)
            {
                goto Label_019A;
            }
            num5 = 0;
            if ((((uint) num4) | 1) != 0)
            {
                goto Label_01A0;
            }
        Label_038F:
            if (base.x26463655896fd90a[num5] > num4)
            {
                num4 = base.x26463655896fd90a[num5];
            }
            else if (((uint) num8) > uint.MaxValue)
            {
                goto Label_013A;
            }
        Label_03B0:
            num5++;
            if (((uint) num9) < 0)
            {
                goto Label_026D;
            }
        Label_03CB:
            if (num5 < base.xa6ab0c05af75ec81)
            {
                if (this.xafe0f470f560f6d3(num5))
                {
                    goto Label_03E2;
                }
                if (base.x1e218ceaee1bb583[num5] != 1)
                {
                    goto Label_04B7;
                }
                goto Label_0461;
            }
            num6 = -num2;
            num7 = -num;
            num8 = -num4;
            goto Label_036A;
        Label_03E2:
            if (!this.xedd159ce5b36c393(num5))
            {
                if (base.x1e218ceaee1bb583[num5] != 1)
                {
                    goto Label_038F;
                }
            }
            else
            {
                goto Label_03B0;
            }
            if (base.x26463655896fd90a[num5] > num2)
            {
                num2 = base.x26463655896fd90a[num5];
            }
            goto Label_03B0;
        Label_0461:
            if (-base.x26463655896fd90a[num5] > num)
            {
                num = -base.x26463655896fd90a[num5];
                goto Label_03E2;
            }
            if ((((uint) num5) & 0) == 0)
            {
                if ((((uint) num8) - ((uint) num6)) <= uint.MaxValue)
                {
                    if (((uint) num5) < 0)
                    {
                        return;
                    }
                    if (((uint) num6) >= 0)
                    {
                    }
                    goto Label_03E2;
                }
                goto Label_0529;
            }
            if ((((uint) num4) & 0) != 0)
            {
                if (0 != 0)
                {
                    goto Label_00C1;
                }
                if ((((uint) num6) - ((uint) num)) >= 0)
                {
                    goto Label_025C;
                }
                if ((((uint) num2) + ((uint) num4)) >= 0)
                {
                    goto Label_02BC;
                }
                goto Label_0339;
            }
            if ((((uint) num9) + ((uint) num7)) > uint.MaxValue)
            {
                goto Label_036A;
            }
        Label_04B7:
            if (-base.x26463655896fd90a[num5] > num3)
            {
                num3 = -base.x26463655896fd90a[num5];
            }
            goto Label_03E2;
        Label_0529:
            num2 = -xf29af8ddc5c68ae7.x3f5ff8076fbf0702;
            num3 = -xf29af8ddc5c68ae7.x3f5ff8076fbf0702;
            num4 = -xf29af8ddc5c68ae7.x3f5ff8076fbf0702;
            num5 = 0;
            goto Label_03CB;
        }

        internal override double x73ce32110d615317()
        {
            int num2;
            double num3;
            double num4;
            double num5;
            double num6;
            double num7;
            double num8;
            int num9;
            double num10;
            double num11;
            int num = 0;
            if (((uint) num11) <= uint.MaxValue)
            {
                goto Label_02A2;
            }
            goto Label_012B;
        Label_001C:
            if (num2 > 0)
            {
                num11 = num8 / ((double) num2);
                goto Label_0030;
            }
        Label_0020:
            num11 = (num4 + num6) / 2.0;
        Label_0030:
            this.x0a6250b187271ea3.xb55b340ae3a3e4e0 = (num10 + num11) / 2.0;
            return ((num10 - num11) / 2.0);
        Label_0088:
            if (num9 < base.xa6ab0c05af75ec81)
            {
                if (base.x1e218ceaee1bb583[num9] != 1)
                {
                    if ((((uint) num2) | 8) != 0)
                    {
                        goto Label_012B;
                    }
                    goto Label_02A2;
                }
                goto Label_019A;
            }
            if (num <= 0)
            {
                num10 = (num3 + num5) / 2.0;
                goto Label_001C;
            }
            num10 = num7 / ((double) num);
            if ((((uint) num5) & 0) == 0)
            {
                goto Label_001C;
            }
            goto Label_0020;
        Label_009F:
            if (((uint) num10) < 0)
            {
                goto Label_001C;
            }
        Label_00B4:
            num9++;
            goto Label_0088;
        Label_011D:
            if (this.xedd159ce5b36c393(num9))
            {
                goto Label_013F;
            }
            while (!this.xafe0f470f560f6d3(num9))
            {
                num2++;
                num8 += base.x26463655896fd90a[num9];
                if (((uint) num11) >= 0)
                {
                    goto Label_009F;
                }
            }
            num6 = Math.Max(num6, base.x26463655896fd90a[num9]);
            if ((((uint) num7) & 0) == 0)
            {
                goto Label_00B4;
            }
            goto Label_009F;
        Label_012B:
            if ((((uint) num9) & 0) == 0)
            {
                goto Label_011D;
            }
        Label_013F:
            num4 = Math.Min(num4, base.x26463655896fd90a[num9]);
            goto Label_00B4;
        Label_0159:
            num7 += base.x26463655896fd90a[num9];
            goto Label_00B4;
        Label_019A:
            if (this.xedd159ce5b36c393(num9))
            {
                goto Label_01E7;
            }
        Label_01A4:
            if (this.xafe0f470f560f6d3(num9))
            {
                num5 = Math.Max(num5, base.x26463655896fd90a[num9]);
                goto Label_00B4;
            }
            num++;
            goto Label_0159;
        Label_01E7:
            num3 = Math.Min(num3, base.x26463655896fd90a[num9]);
            goto Label_00B4;
        Label_02A2:
            if ((((uint) num) - ((uint) num8)) > uint.MaxValue)
            {
                goto Label_00B4;
            }
            if ((((uint) num2) & 0) == 0)
            {
                num2 = 0;
                num3 = xf29af8ddc5c68ae7.x3f5ff8076fbf0702;
                num4 = xf29af8ddc5c68ae7.x3f5ff8076fbf0702;
                num5 = -xf29af8ddc5c68ae7.x3f5ff8076fbf0702;
                if ((((uint) num9) - ((uint) num3)) > uint.MaxValue)
                {
                    goto Label_011D;
                }
                if ((((uint) num3) + ((uint) num4)) <= uint.MaxValue)
                {
                    if ((((uint) num4) | 3) == 0)
                    {
                        goto Label_01A4;
                    }
                    num6 = -xf29af8ddc5c68ae7.x3f5ff8076fbf0702;
                    num7 = 0.0;
                    if ((((uint) num6) - ((uint) num9)) < 0)
                    {
                        if ((((uint) num11) & 0) == 0)
                        {
                            goto Label_019A;
                        }
                        goto Label_01E7;
                    }
                    num8 = 0.0;
                    num9 = 0;
                    goto Label_0088;
                }
            }
            goto Label_0159;
        }
    }
}

