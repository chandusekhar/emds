namespace Encog.Neural.Networks.Training.PNN
{
    using Encog.Util;
    using System;

    public class DeriveMinimum
    {
        public double Calculate(int maxIterations, double maxError, double eps, double tol, ICalculationCriteria network, int n, double[] x, double ystart, double[] bs, double[] direc, double[] g, double[] h, double[] deriv2)
        {
            double num;
            double num2;
            int num3;
            int num4;
            int num5;
            int num6;
            double num7;
            double num8;
            double num9;
            double num10;
            double num11;
            int num12;
            double num13;
            int num14;
            int num16;
            double num19;
            GlobalMinimumSearch search = new GlobalMinimumSearch();
            if ((((uint) ystart) | 8) != 0)
            {
                num = network.CalcErrorWithMultipleSigma(x, direc, deriv2, true);
                num2 = 1E+30;
                num3 = 0;
                goto Label_07E4;
            }
            goto Label_03E1;
        Label_003D:
            if (num6 >= maxIterations)
            {
                if ((((uint) num19) + ((uint) num11)) < 0)
                {
                    if (((uint) num7) <= uint.MaxValue)
                    {
                        goto Label_005E;
                    }
                    goto Label_003D;
                }
                if (((uint) maxError) < 0)
                {
                    goto Label_0080;
                }
                if (((uint) num10) <= uint.MaxValue)
                {
                    return num;
                }
                goto Label_039C;
            }
        Label_005E:
            if (num >= maxError)
            {
                goto Label_071B;
            }
            return num;
        Label_0080:
            if (num5 >= 6)
            {
                goto Label_0096;
            }
        Label_0085:
            xbfc8da7bffe4bca2(n, num19, g, h, direc);
            num6++;
            goto Label_003D;
        Label_0096:
            num5 = 0;
            num19 = 0.0;
            goto Label_0085;
        Label_009D:
            if (num5 < 2)
            {
                goto Label_0080;
            }
        Label_00A2:
            if (num19 <= 1.0)
            {
                goto Label_0080;
            }
        Label_00DF:
            num19 = 1.0;
            goto Label_0080;
        Label_0213:
            if (num16 < n)
            {
                x[num16] = bs[num16] + (search.X2 * direc[num16]);
                if (((((uint) num3) | 0xfffffffe) == 0) || (x[num16] < 1E-10))
                {
                    x[num16] = 1E-10;
                }
                goto Label_0276;
            }
            double num17 = (num2 - num) / num2;
            if ((((uint) num10) - ((uint) ystart)) < 0)
            {
                goto Label_045B;
            }
            if ((((uint) num6) - ((uint) num14)) > uint.MaxValue)
            {
                goto Label_04C5;
            }
            if (num < maxError)
            {
                return num;
            }
            int index = 0;
        Label_019D:
            if (index < n)
            {
                direc[index] = -direc[index];
                if ((((uint) n) - ((uint) num13)) >= 0)
                {
                    index++;
                    goto Label_019D;
                }
            }
            else
            {
                num19 = xdf79f321ca5c3af5(n, g, direc);
            }
            if (4 != 0)
            {
                if (num19 < 0.0)
                {
                    num19 = 0.0;
                }
                if (num19 > 10.0)
                {
                    num19 = 10.0;
                }
                else if ((((uint) maxError) | 0xff) == 0)
                {
                    goto Label_06FD;
                }
                if (num17 >= 0.001)
                {
                    num5 = 0;
                }
                else
                {
                    if ((((uint) num10) | 1) == 0)
                    {
                        goto Label_0096;
                    }
                    num5++;
                }
                goto Label_009D;
            }
            if ((((uint) num12) & 0) == 0)
            {
                goto Label_029C;
            }
        Label_0276:
            num16++;
            if (0 == 0)
            {
                if (((uint) maxError) > uint.MaxValue)
                {
                    goto Label_031E;
                }
                goto Label_0213;
            }
        Label_029C:
            num = search.Brentmin(10, maxError, 1E-06, 1E-05, network, search.Y2);
        Label_02C0:
            num16 = 0;
            if ((((uint) maxIterations) - ((uint) maxError)) > uint.MaxValue)
            {
                goto Label_07E9;
            }
            goto Label_0213;
        Label_031E:
            if (num4 > 0)
            {
                num = search.Brentmin(20, maxError, eps, 1E-07, network, search.Y2);
                goto Label_02C0;
            }
            if ((((uint) num16) + ((uint) num2)) <= uint.MaxValue)
            {
                goto Label_029C;
            }
            goto Label_0276;
        Label_0365:
            if (search.Y2 >= maxError)
            {
                goto Label_031E;
            }
        Label_039C:
            if (search.Y2 < num)
            {
                num14 = 0;
                goto Label_041C;
            }
            int num15 = 0;
        Label_0391:
            if (num15 < n)
            {
                x[num15] = bs[num15];
                num15++;
                if ((((uint) n) + ((uint) num15)) >= 0)
                {
                    goto Label_0391;
                }
            }
            else
            {
                return num;
            }
            if ((((uint) num13) - ((uint) n)) >= 0)
            {
                goto Label_031E;
            }
            goto Label_0365;
        Label_03E1:
            x[num14] = bs[num14] + (search.Y2 * direc[num14]);
            if (x[num14] < 1E-10)
            {
                x[num14] = 1E-10;
            }
            num14++;
        Label_041C:
            if (num14 < n)
            {
                goto Label_03E1;
            }
            return search.Y2;
        Label_045B:
            num13 = 10.0 * num11;
        Label_0469:
            num2 = num;
            search.Y2 = num;
            search.FindBestRange(0.0, 2.0 * num13, -3, false, maxError, network);
            goto Label_0365;
        Label_04C5:
            num13 = num11;
            goto Label_0469;
        Label_04CB:
            if (num13 < 0.0)
            {
                goto Label_04C5;
            }
            if ((((uint) num17) + ((uint) maxIterations)) >= 0)
            {
                if (((uint) num9) >= 0)
                {
                    if (num13 >= (0.1 * num11))
                    {
                        if (num13 <= (10.0 * num11))
                        {
                            goto Label_0469;
                        }
                    }
                    else
                    {
                        num13 = 0.1 * num11;
                        if ((((uint) num11) - ((uint) num16)) < 0)
                        {
                            goto Label_04CB;
                        }
                        goto Label_0469;
                    }
                }
                goto Label_045B;
            }
        Label_04F0:
            num11 = 1.5 / num11;
            if (((((uint) tol) + ((uint) eps)) >= 0) && (num11 >= 0.0001))
            {
                goto Label_04CB;
            }
        Label_0516:
            num11 = 0.0001;
            goto Label_04CB;
        Label_05C6:
            if (num12 < n)
            {
                bs[num12] = x[num12];
                if (((uint) num8) > uint.MaxValue)
                {
                    goto Label_009D;
                }
            }
            else
            {
                if (Math.Abs(num8) < 1E-07)
                {
                    if ((((uint) num14) + ((uint) num4)) > uint.MaxValue)
                    {
                        goto Label_07E4;
                    }
                    num13 = 0.0;
                    if ((((uint) num19) - ((uint) ystart)) < 0)
                    {
                        goto Label_0516;
                    }
                    goto Label_04F0;
                }
                num13 = num10 / num8;
                if ((((uint) num13) - ((uint) num15)) >= 0)
                {
                    goto Label_04F0;
                }
                goto Label_05C6;
            }
        Label_0640:
            if (deriv2[num12] > num11)
            {
                num11 = deriv2[num12];
                if (((uint) num) < 0)
                {
                    goto Label_00A2;
                }
            }
            num10 += direc[num12] * g[num12];
            if ((((uint) num8) + ((uint) num8)) > uint.MaxValue)
            {
                goto Label_071B;
            }
            num8 += (direc[num12] * direc[num12]) * deriv2[num12];
            num9 += direc[num12] * direc[num12];
            num12++;
            goto Label_05C6;
        Label_06B9:
            if (++num4 >= 3)
            {
                return num;
            }
        Label_06D9:
            num8 = 0.0;
            num9 = 0.0;
            num10 = num8 = num9 = 0.0;
            num11 = 0.0001;
            num12 = 0;
            goto Label_05C6;
        Label_06F7:
            num7 = tol * num2;
        Label_06FD:
            if ((num2 - num) > num7)
            {
                num4 = 0;
                if ((((uint) num14) & 0) != 0)
                {
                    goto Label_06B9;
                }
                goto Label_06D9;
            }
            if (((uint) num9) <= uint.MaxValue)
            {
                goto Label_06B9;
            }
            return num;
        Label_071B:
            if (num2 > 1.0)
            {
                if ((((uint) num7) + ((uint) eps)) < 0)
                {
                    goto Label_003D;
                }
                if ((((uint) num8) - ((uint) num14)) <= uint.MaxValue)
                {
                    goto Label_06F7;
                }
            }
            else
            {
                num7 = tol;
                goto Label_06FD;
            }
        Label_0762:
            num5 = 0;
            num6 = 0;
            goto Label_003D;
        Label_07D7:
            direc[num3] = -direc[num3];
            num3++;
        Label_07E4:
            if (num3 < n)
            {
                goto Label_07D7;
            }
        Label_07E9:
            if (((uint) num15) > uint.MaxValue)
            {
                if ((((uint) num11) + ((uint) num13)) < 0)
                {
                    goto Label_0640;
                }
                goto Label_00DF;
            }
            do
            {
                EngineArray.ArrayCopy(direc, g);
                EngineArray.ArrayCopy(direc, h);
                if ((((uint) num5) + ((uint) maxError)) < 0)
                {
                    goto Label_06F7;
                }
                num4 = 0;
                if ((((uint) num5) - ((uint) num10)) <= uint.MaxValue)
                {
                    goto Label_0762;
                }
            }
            while ((((uint) index) - ((uint) num17)) > uint.MaxValue);
            goto Label_07D7;
        }

        private static void xbfc8da7bffe4bca2(int x57e9faf3ffdc07cc, double xdbc57c548baaa7a3, double[] x4b101060f4767186, double[] xe24dd90acb923d68, double[] x773522da759bca0d)
        {
            int index = 0;
            while (index < x57e9faf3ffdc07cc)
            {
                double num2;
                x4b101060f4767186[index] = x773522da759bca0d[index];
                xe24dd90acb923d68[index] = num2 = x4b101060f4767186[index] + (xdbc57c548baaa7a3 * xe24dd90acb923d68[index]);
                x773522da759bca0d[index] = num2;
                do
                {
                    index++;
                }
                while ((((uint) num2) - ((uint) index)) < 0);
            }
        }

        private static double xdf79f321ca5c3af5(int x57e9faf3ffdc07cc, double[] x4b101060f4767186, double[] x773522da759bca0d)
        {
            int num;
            double num2;
            double num3 = num2 = 0.0;
            if ((((uint) num2) + ((uint) num)) <= uint.MaxValue)
            {
                num = 0;
            }
            while (num < x57e9faf3ffdc07cc)
            {
                num2 += x4b101060f4767186[num] * x4b101060f4767186[num];
                num3 += (x773522da759bca0d[num] - x4b101060f4767186[num]) * x773522da759bca0d[num];
                num++;
            }
            while (num2 == 0.0)
            {
                return 0.0;
            }
            return (num3 / num2);
        }
    }
}

