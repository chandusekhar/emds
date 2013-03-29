namespace Encog.MathUtil.LIBSVM
{
    using System;

    internal abstract class xf094e3229d63c9be
    {
        private readonly svm_node[][] x08db3aeabb253cb1;
        private readonly double[] x4f9e236643454e9f;
        private readonly double x83735b10b6a3d76d;
        private readonly double x987b3666f8a37f90;
        private readonly int xbcd9612004129925;
        private readonly double xc7c4e9c099884228;

        internal xf094e3229d63c9be(int l, svm_node[][] x_, svm_parameter param)
        {
            int num;
        Label_00C5:
            this.xbcd9612004129925 = param.kernel_type;
        Label_0075:
            if ((((uint) num) | 0x80000000) != 0)
            {
                this.x83735b10b6a3d76d = param.degree;
                do
                {
                    this.xc7c4e9c099884228 = param.gamma;
                    this.x987b3666f8a37f90 = param.coef0;
                    if (0xff != 0)
                    {
                        this.x08db3aeabb253cb1 = (svm_node[][]) x_.Clone();
                        if (this.xbcd9612004129925 != 2)
                        {
                            this.x4f9e236643454e9f = null;
                            if (0 == 0)
                            {
                                if (0 == 0)
                                {
                                    return;
                                }
                                goto Label_00C5;
                            }
                            goto Label_0075;
                        }
                        this.x4f9e236643454e9f = new double[l];
                    }
                }
                while (2 == 0);
            }
            for (num = 0; num < l; num++)
            {
                this.x4f9e236643454e9f[num] = x99240096a9e3842c(this.x08db3aeabb253cb1[num], this.x08db3aeabb253cb1[num]);
            }
        }

        internal abstract float[] get_x6648d9580110b138(int xe3e287548b3d01f5, int xb5964a891b6cf7c3);
        internal virtual double x1e221c4999144ac5(int x7b28e8a789372508, int x1148d0e8cc982c04)
        {
            switch (this.xbcd9612004129925)
            {
                case 0:
                    return x99240096a9e3842c(this.x08db3aeabb253cb1[x7b28e8a789372508], this.x08db3aeabb253cb1[x1148d0e8cc982c04]);

                case 1:
                    return Math.Pow((this.xc7c4e9c099884228 * x99240096a9e3842c(this.x08db3aeabb253cb1[x7b28e8a789372508], this.x08db3aeabb253cb1[x1148d0e8cc982c04])) + this.x987b3666f8a37f90, this.x83735b10b6a3d76d);

                case 2:
                    return Math.Exp(-this.xc7c4e9c099884228 * ((this.x4f9e236643454e9f[x7b28e8a789372508] + this.x4f9e236643454e9f[x1148d0e8cc982c04]) - (2.0 * x99240096a9e3842c(this.x08db3aeabb253cb1[x7b28e8a789372508], this.x08db3aeabb253cb1[x1148d0e8cc982c04]))));

                case 3:
                    return xcb156489dc62ed23((this.xc7c4e9c099884228 * x99240096a9e3842c(this.x08db3aeabb253cb1[x7b28e8a789372508], this.x08db3aeabb253cb1[x1148d0e8cc982c04])) + this.x987b3666f8a37f90);
            }
            return 0.0;
        }

        internal virtual void x89083ecc6edaa4e0(int x7b28e8a789372508, int x1148d0e8cc982c04)
        {
            svm_node[] _nodeArray = this.x08db3aeabb253cb1[x7b28e8a789372508];
            this.x08db3aeabb253cb1[x7b28e8a789372508] = this.x08db3aeabb253cb1[x1148d0e8cc982c04];
            this.x08db3aeabb253cb1[x1148d0e8cc982c04] = _nodeArray;
            if (this.x4f9e236643454e9f != null)
            {
                double num = this.x4f9e236643454e9f[x7b28e8a789372508];
                this.x4f9e236643454e9f[x7b28e8a789372508] = this.x4f9e236643454e9f[x1148d0e8cc982c04];
                this.x4f9e236643454e9f[x1148d0e8cc982c04] = num;
            }
        }

        internal static double x99240096a9e3842c(svm_node[] x08db3aeabb253cb1, svm_node[] x1e218ceaee1bb583)
        {
            int num4;
            int num5;
            double num = 0.0;
            int length = x08db3aeabb253cb1.Length;
            int num3 = x1e218ceaee1bb583.Length;
            if (0 == 0)
            {
                num4 = 0;
                num5 = 0;
            }
            goto Label_007F;
        Label_000F:
            if ((((uint) num5) - ((uint) num4)) <= uint.MaxValue)
            {
                if (0x7fffffff != 0)
                {
                }
                return num;
            }
        Label_007F:
            if (num4 < length)
            {
                goto Label_00BC;
            }
            if (((((uint) length) | 4) != 0) && ((((uint) length) + ((uint) num)) >= 0))
            {
                if ((((uint) num) & 0) != 0)
                {
                    goto Label_00A4;
                }
                if ((((uint) num3) + ((uint) num5)) >= 0)
                {
                    return num;
                }
                goto Label_00D0;
            }
            goto Label_000F;
        Label_00A4:
            if ((((uint) num) - ((uint) num)) >= 0)
            {
                goto Label_007F;
            }
        Label_00BC:
            if (num5 < num3)
            {
                if (x08db3aeabb253cb1[num4].index == x1e218ceaee1bb583[num5].index)
                {
                    num += x08db3aeabb253cb1[num4++].value_Renamed * x1e218ceaee1bb583[num5++].value_Renamed;
                }
                else if ((((uint) length) + ((uint) num5)) <= uint.MaxValue)
                {
                    goto Label_00D0;
                }
                goto Label_007F;
            }
            goto Label_000F;
        Label_00D0:
            if (x08db3aeabb253cb1[num4].index > x1e218ceaee1bb583[num5].index)
            {
                num5++;
                goto Label_007F;
            }
            num4++;
            goto Label_00A4;
        }

        internal static double xc60aa42cfbd0c1ed(svm_node[] x08db3aeabb253cb1, svm_node[] x1e218ceaee1bb583, svm_parameter x0d173b5435b4d6ad)
        {
            double num;
            int length;
            int num3;
            int num4;
            int num5;
            int num7 = x0d173b5435b4d6ad.kernel_type;
            switch (num7)
            {
                case 0:
                    return x99240096a9e3842c(x08db3aeabb253cb1, x1e218ceaee1bb583);

                case 1:
                    return Math.Pow((x0d173b5435b4d6ad.gamma * x99240096a9e3842c(x08db3aeabb253cb1, x1e218ceaee1bb583)) + x0d173b5435b4d6ad.coef0, x0d173b5435b4d6ad.degree);

                case 2:
                    num = 0.0;
                    length = x08db3aeabb253cb1.Length;
                    num3 = x1e218ceaee1bb583.Length;
                    num4 = 0;
                    num5 = 0;
                    goto Label_0095;

                case 3:
                    return xcb156489dc62ed23((x0d173b5435b4d6ad.gamma * x99240096a9e3842c(x08db3aeabb253cb1, x1e218ceaee1bb583)) + x0d173b5435b4d6ad.coef0);

                default:
                    goto Label_021B;
            }
        Label_008D:
            if (num4 < length)
            {
                num += x08db3aeabb253cb1[num4].value_Renamed * x08db3aeabb253cb1[num4].value_Renamed;
                if ((((uint) length) - ((uint) num)) <= uint.MaxValue)
                {
                    goto Label_0111;
                }
                goto Label_00DF;
            }
            if ((((uint) length) + ((uint) num4)) < 0)
            {
                goto Label_021B;
            }
            while (num5 < num3)
            {
                num += x1e218ceaee1bb583[num5].value_Renamed * x1e218ceaee1bb583[num5].value_Renamed;
                num5++;
            }
            return Math.Exp(-x0d173b5435b4d6ad.gamma * num);
        Label_0095:
            if (num4 < length)
            {
                if (num5 < num3)
                {
                    if (x08db3aeabb253cb1[num4].index != x1e218ceaee1bb583[num5].index)
                    {
                        goto Label_00DF;
                    }
                    double num6 = x08db3aeabb253cb1[num4++].value_Renamed - x1e218ceaee1bb583[num5++].value_Renamed;
                    num += num6 * num6;
                    goto Label_0095;
                }
                goto Label_008D;
            }
            if ((((uint) num5) + ((uint) num7)) < 0)
            {
                goto Label_00F2;
            }
            if ((((uint) num) - ((uint) length)) <= uint.MaxValue)
            {
                goto Label_008D;
            }
        Label_00DF:
            if (x08db3aeabb253cb1[num4].index > x1e218ceaee1bb583[num5].index)
            {
                num += x1e218ceaee1bb583[num5].value_Renamed * x1e218ceaee1bb583[num5].value_Renamed;
                num5++;
                goto Label_0095;
            }
        Label_00F2:
            num += x08db3aeabb253cb1[num4].value_Renamed * x08db3aeabb253cb1[num4].value_Renamed;
            num4++;
            if (0xff != 0)
            {
                goto Label_0095;
            }
        Label_0111:
            if ((((uint) num5) - ((uint) length)) <= uint.MaxValue)
            {
                num4++;
            }
            goto Label_008D;
        Label_021B:
            return 0.0;
        }

        private static double xcb156489dc62ed23(double x08db3aeabb253cb1)
        {
            double num = Math.Exp(x08db3aeabb253cb1);
            return (1.0 - (2.0 / ((num * num) + 1.0)));
        }
    }
}

