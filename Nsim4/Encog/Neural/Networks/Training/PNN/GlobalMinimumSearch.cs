namespace Encog.Neural.Networks.Training.PNN
{
    using System;

    public class GlobalMinimumSearch
    {
        private double _x6650a9a61c6142e3;
        private double _x9b9be9a08b5115a8;
        private double _xaa76c33ed453ba57;
        private double _xb3a0be2328bf1529;
        private double _xb6acbfc039c06679;
        private double _xe75e43d266eef799;
        public const double Cgold = 0.381966;

        public double Brentmin(int maxIterations, double maxError, double eps, double tol, ICalculationCriteria network, double y)
        {
            // This item is obfuscated and can not be translated.
        }

        public void FindBestRange(double low, double high, int numberOfPoints, bool useLog, double minError, ICalculationCriteria network)
        {
            int num;
            int num2;
            double num3;
            double num4;
            double num5;
            double num6;
            bool flag;
            bool flag2;
            if (numberOfPoints >= 0)
            {
                flag = false;
                if (((uint) num5) < 0)
                {
                    if ((((uint) high) - ((uint) num6)) < 0)
                    {
                        goto Label_0642;
                    }
                    if ((((uint) minError) - ((uint) useLog)) >= 0)
                    {
                        goto Label_054D;
                    }
                    goto Label_0574;
                }
                goto Label_0782;
            }
            if ((((uint) high) - ((uint) flag)) >= 0)
            {
                numberOfPoints = -numberOfPoints;
                flag = true;
                goto Label_0782;
            }
            if (((uint) useLog) >= 0)
            {
                goto Label_0639;
            }
            if ((((uint) flag2) & 0) == 0)
            {
                goto Label_0355;
            }
            goto Label_0094;
        Label_0064:
            if (num2 == 0)
            {
                goto Label_01F4;
            }
            if ((((uint) num3) | 0x7fffffff) == 0)
            {
                goto Label_033B;
            }
            if ((((uint) num2) - ((uint) num2)) >= 0)
            {
                if (((uint) useLog) <= uint.MaxValue)
                {
                    return;
                }
                goto Label_0639;
            }
            if ((((uint) useLog) - ((uint) num6)) >= 0)
            {
                goto Label_0355;
            }
            if ((((uint) flag) - ((uint) numberOfPoints)) >= 0)
            {
                goto Label_0222;
            }
            goto Label_0191;
        Label_0094:
            num5 *= 3.0;
            if (useLog)
            {
                this._x6650a9a61c6142e3 /= num5;
            }
            else
            {
                this._x6650a9a61c6142e3 -= num5;
            }
            goto Label_01F4;
        Label_0191:
            if (this._xaa76c33ed453ba57 > this._x9b9be9a08b5115a8)
            {
                return;
            }
            if (((((uint) numberOfPoints) + ((uint) flag2)) <= uint.MaxValue) || (((uint) num4) <= uint.MaxValue))
            {
                if ((this._xaa76c33ed453ba57 == this._x9b9be9a08b5115a8) && (this._x9b9be9a08b5115a8 == this._xb3a0be2328bf1529))
                {
                    return;
                }
                this._xb6acbfc039c06679 = this._xe75e43d266eef799;
                this._xb3a0be2328bf1529 = this._x9b9be9a08b5115a8;
                this._xe75e43d266eef799 = this._x6650a9a61c6142e3;
                this._x9b9be9a08b5115a8 = this._xaa76c33ed453ba57;
                if (((uint) flag) <= uint.MaxValue)
                {
                    goto Label_0094;
                }
                if (((uint) high) >= 0)
                {
                    goto Label_0222;
                }
                if (0x7fffffff != 0)
                {
                    goto Label_02E5;
                }
                if (((uint) minError) >= 0)
                {
                    goto Label_0064;
                }
            }
            else
            {
                goto Label_0191;
            }
        Label_01F4:
            this._xaa76c33ed453ba57 = network.CalcErrorWithSingleSigma(this._x6650a9a61c6142e3);
            if (this._xaa76c33ed453ba57 >= 0.0)
            {
                goto Label_0191;
            }
            return;
        Label_0222:
            if (!flag2)
            {
                goto Label_0305;
            }
            goto Label_0064;
        Label_028F:
            this._x6650a9a61c6142e3 = this._xe75e43d266eef799;
            this._xaa76c33ed453ba57 = this._x9b9be9a08b5115a8;
            this._xe75e43d266eef799 = this._xb6acbfc039c06679;
            this._x9b9be9a08b5115a8 = this._xb3a0be2328bf1529;
            num5 *= 3.0;
            if ((((uint) num6) - ((uint) low)) >= 0)
            {
                if (((uint) num3) < 0)
                {
                    goto Label_047F;
                }
                if (!useLog)
                {
                    this._xb6acbfc039c06679 += num5;
                }
                else
                {
                    this._xb6acbfc039c06679 *= num5;
                }
                goto Label_0305;
            }
        Label_02E5:
            if (this._x9b9be9a08b5115a8 != this._xb3a0be2328bf1529)
            {
                if ((((uint) num6) - ((uint) num5)) > uint.MaxValue)
                {
                    goto Label_0488;
                }
                goto Label_028F;
            }
            return;
        Label_0305:
            this._xb3a0be2328bf1529 = network.CalcErrorWithSingleSigma(this._xb6acbfc039c06679);
            if (((uint) num) >= 0)
            {
                if (this._xb3a0be2328bf1529 > this._x9b9be9a08b5115a8)
                {
                    return;
                }
            }
            else
            {
                return;
            }
        Label_033B:
            if (this._xaa76c33ed453ba57 != this._x9b9be9a08b5115a8)
            {
                goto Label_028F;
            }
            goto Label_02E5;
        Label_0355:
            if (((uint) minError) > uint.MaxValue)
            {
                goto Label_054D;
            }
        Label_036A:
            if ((((uint) num4) + ((uint) minError)) > uint.MaxValue)
            {
                goto Label_0305;
            }
            if ((((uint) numberOfPoints) & 0) != 0)
            {
                goto Label_058C;
            }
            this._xb6acbfc039c06679 = this._xe75e43d266eef799 + num5;
            goto Label_0222;
        Label_03CC:
            if ((((uint) num5) & 0) != 0)
            {
                goto Label_042D;
            }
            if ((((uint) flag2) | 3) == 0)
            {
                return;
            }
            goto Label_0415;
        Label_03FD:
            if ((((uint) high) - ((uint) num5)) < 0)
            {
                goto Label_03CC;
            }
        Label_0415:
            this._x6650a9a61c6142e3 = this._xe75e43d266eef799 - num5;
            goto Label_0355;
        Label_042D:
            if (useLog)
            {
                goto Label_045F;
            }
            goto Label_03FD;
        Label_0440:
            if (num < numberOfPoints)
            {
                goto Label_06F6;
            }
            if ((((uint) num2) + ((uint) num5)) <= uint.MaxValue)
            {
                goto Label_042D;
            }
        Label_045F:
            this._x6650a9a61c6142e3 = this._xe75e43d266eef799 / num5;
            this._xb6acbfc039c06679 = this._xe75e43d266eef799 * num5;
            goto Label_0222;
        Label_047F:
            if (useLog)
            {
                num3 *= num5;
            }
            else
            {
                num3 += num5;
            }
        Label_0488:
            num++;
            if ((((uint) num6) | 1) == 0)
            {
                goto Label_01F4;
            }
            if ((((uint) high) & 0) == 0)
            {
                goto Label_0440;
            }
            goto Label_047F;
        Label_04D8:
            num6 = num4;
            if (((this._x9b9be9a08b5115a8 <= minError) && (num2 > 0)) && flag2)
            {
                goto Label_042D;
            }
            goto Label_047F;
        Label_054D:
            if (num == (num2 + 1))
            {
                this._xb3a0be2328bf1529 = num4;
                flag2 = true;
                goto Label_04D8;
            }
            if ((((uint) num2) - ((uint) num6)) > uint.MaxValue)
            {
                goto Label_0574;
            }
            if ((((uint) num5) & 0) != 0)
            {
                if (((uint) num6) < 0)
                {
                    goto Label_03CC;
                }
                goto Label_0732;
            }
            if (((uint) useLog) >= 0)
            {
                if ((((uint) flag) + ((uint) numberOfPoints)) <= uint.MaxValue)
                {
                    goto Label_0661;
                }
                if ((((uint) num6) - ((uint) high)) <= uint.MaxValue)
                {
                    goto Label_062D;
                }
                goto Label_05D2;
            }
            if ((((uint) useLog) & 0) != 0)
            {
                goto Label_054D;
            }
        Label_056C:
            if (num == 0)
            {
                if ((((uint) num6) + ((uint) flag)) < 0)
                {
                    goto Label_068B;
                }
                goto Label_0639;
            }
            goto Label_058C;
        Label_0574:
            if ((((uint) numberOfPoints) + ((uint) high)) > uint.MaxValue)
            {
                goto Label_056C;
            }
        Label_058C:
            if (num4 < this._x9b9be9a08b5115a8)
            {
                goto Label_068B;
            }
            if (0 != 0)
            {
                goto Label_06CA;
            }
            goto Label_054D;
        Label_05D2:
            flag2 = false;
            if ((((uint) num2) | 0xff) == 0)
            {
                goto Label_036A;
            }
            goto Label_04D8;
        Label_062D:
            this._xaa76c33ed453ba57 = num6;
            goto Label_05D2;
        Label_0639:
            num2 = num;
            this._xe75e43d266eef799 = num3;
        Label_0642:
            this._x9b9be9a08b5115a8 = num4;
            if ((((uint) minError) - ((uint) flag)) <= uint.MaxValue)
            {
                goto Label_062D;
            }
        Label_0661:
            if ((((uint) numberOfPoints) | 0x80000000) != 0)
            {
                goto Label_04D8;
            }
            goto Label_03FD;
        Label_068B:
            if ((((uint) useLog) | 0x80000000) == 0)
            {
                goto Label_056C;
            }
            goto Label_0639;
        Label_06CA:
            num4 = network.CalcErrorWithSingleSigma(num3);
            goto Label_056C;
        Label_06F6:
            if (num > 0)
            {
                if ((((uint) num3) - ((uint) numberOfPoints)) <= uint.MaxValue)
                {
                    goto Label_06CA;
                }
                goto Label_058C;
            }
        Label_0732:
            if (flag)
            {
                num4 = this._x9b9be9a08b5115a8;
                goto Label_056C;
            }
            if ((((uint) num4) | 15) != 0)
            {
                goto Label_06CA;
            }
            if (((uint) minError) <= uint.MaxValue)
            {
            }
            goto Label_06F6;
        Label_0782:
            if (useLog)
            {
                num5 = Math.Exp(Math.Log(high / low) / ((double) (numberOfPoints - 1)));
            }
            else
            {
                num5 = (high - low) / ((double) (numberOfPoints - 1));
            }
            num3 = low;
            num6 = 0.0;
            num2 = -1;
            flag2 = false;
            num = 0;
            goto Label_0440;
        }

        public double X1
        {
            get
            {
                return this._x6650a9a61c6142e3;
            }
            set
            {
                this._x6650a9a61c6142e3 = value;
            }
        }

        public double X2
        {
            get
            {
                return this._xe75e43d266eef799;
            }
            set
            {
                this._xe75e43d266eef799 = value;
            }
        }

        public double X3
        {
            get
            {
                return this._xb6acbfc039c06679;
            }
            set
            {
                this._xb6acbfc039c06679 = value;
            }
        }

        public double Y1
        {
            get
            {
                return this._xaa76c33ed453ba57;
            }
            set
            {
                this._xaa76c33ed453ba57 = value;
            }
        }

        public double Y2
        {
            get
            {
                return this._x9b9be9a08b5115a8;
            }
            set
            {
                this._x9b9be9a08b5115a8 = value;
            }
        }

        public double Y3
        {
            get
            {
                return this._xb3a0be2328bf1529;
            }
            set
            {
                this._xb3a0be2328bf1529 = value;
            }
        }
    }
}

