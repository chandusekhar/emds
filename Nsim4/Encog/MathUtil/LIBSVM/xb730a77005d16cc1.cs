namespace Encog.MathUtil.LIBSVM
{
    using System;

    internal class xb730a77005d16cc1
    {
        private int x0ceec69a97f73617;
        private readonly xf2a930dcfe72e757[] x4cbb0cc714782977;
        private readonly xf2a930dcfe72e757 x6aaf91912a47df08;
        private readonly int x9fc3ee03a439f6f0;

        internal xb730a77005d16cc1(int l_, int size_)
        {
            int num;
            this.x9fc3ee03a439f6f0 = l_;
            goto Label_00CA;
        Label_000B:
            if (num < this.x9fc3ee03a439f6f0)
            {
                this.x4cbb0cc714782977[num] = new xf2a930dcfe72e757(this);
                if (((uint) size_) < 0)
                {
                    goto Label_00CA;
                }
                goto Label_007D;
            }
            this.x0ceec69a97f73617 /= 4;
        Label_0025:
            this.x0ceec69a97f73617 -= this.x9fc3ee03a439f6f0 * 4;
            this.x6aaf91912a47df08 = new xf2a930dcfe72e757(this);
            this.x6aaf91912a47df08.xcc36986f44d69e8f = this.x6aaf91912a47df08.x1ec81c4ce7413e94 = this.x6aaf91912a47df08;
            if ((((uint) l_) - ((uint) size_)) <= uint.MaxValue)
            {
                return;
            }
        Label_007D:
            num++;
            if (((uint) size_) < 0)
            {
                goto Label_0025;
            }
            goto Label_000B;
        Label_00CA:
            this.x0ceec69a97f73617 = size_;
            this.x4cbb0cc714782977 = new xf2a930dcfe72e757[this.x9fc3ee03a439f6f0];
            if ((((uint) num) + ((uint) size_)) <= uint.MaxValue)
            {
                num = 0;
                goto Label_000B;
            }
            goto Label_007D;
        }

        internal virtual int get_x4a3f0a05c02f235f(int xc0c4c459c6ccbd00, float[][] x4a3f0a05c02f235f, int xb5964a891b6cf7c3)
        {
            float[] numArray;
            int num2;
            xf2a930dcfe72e757 xfadcfee = this.x4cbb0cc714782977[xc0c4c459c6ccbd00];
            if (((((uint) num2) | 0x80000000) == 0) || (xfadcfee.xb5964a891b6cf7c3 > 0))
            {
                this.xbbe91b22f83938ea(xfadcfee);
            }
            int num = xb5964a891b6cf7c3 - xfadcfee.xb5964a891b6cf7c3;
            if ((0 != 0) || (num > 0))
            {
                goto Label_00EB;
            }
        Label_0023:
            this.xb91b0c69bab21504(xfadcfee);
            if ((((uint) xc0c4c459c6ccbd00) + ((uint) xb5964a891b6cf7c3)) >= 0)
            {
                x4a3f0a05c02f235f[0] = xfadcfee.x4a3f0a05c02f235f;
                return xb5964a891b6cf7c3;
            }
        Label_00C0:
            if ((1 == 0) || (xfadcfee.x4a3f0a05c02f235f != null))
            {
                Array.Copy(xfadcfee.x4a3f0a05c02f235f, 0, numArray, 0, xfadcfee.xb5964a891b6cf7c3);
            }
            xfadcfee.x4a3f0a05c02f235f = numArray;
            this.x0ceec69a97f73617 -= num;
            if ((((uint) num) | 0x80000000) == 0)
            {
                return xb5964a891b6cf7c3;
            }
            if ((((uint) num) | 8) != 0)
            {
                num2 = xfadcfee.xb5964a891b6cf7c3;
                xfadcfee.xb5964a891b6cf7c3 = xb5964a891b6cf7c3;
                xb5964a891b6cf7c3 = num2;
                goto Label_0023;
            }
        Label_00EB:
            while (this.x0ceec69a97f73617 < num)
            {
                xf2a930dcfe72e757 xfadcfee2 = this.x6aaf91912a47df08.xcc36986f44d69e8f;
                this.xbbe91b22f83938ea(xfadcfee2);
                if (((uint) num2) >= 0)
                {
                    this.x0ceec69a97f73617 += xfadcfee2.xb5964a891b6cf7c3;
                }
                xfadcfee2.x4a3f0a05c02f235f = null;
                xfadcfee2.xb5964a891b6cf7c3 = 0;
            }
            numArray = new float[xb5964a891b6cf7c3];
            goto Label_00C0;
        }

        internal virtual void x89083ecc6edaa4e0(int x7b28e8a789372508, int x1148d0e8cc982c04)
        {
            float[] numArray;
            int num;
            int num2;
            xf2a930dcfe72e757 xfadcfee;
            float num3;
            if (x7b28e8a789372508 != x1148d0e8cc982c04)
            {
                if (this.x4cbb0cc714782977[x7b28e8a789372508].xb5964a891b6cf7c3 > 0)
                {
                    goto Label_031B;
                }
                goto Label_02FA;
            }
            return;
        Label_000C:
            if (xfadcfee != this.x6aaf91912a47df08)
            {
                if (xfadcfee.xb5964a891b6cf7c3 <= x7b28e8a789372508)
                {
                    goto Label_007B;
                }
                goto Label_00A2;
            }
            if ((((uint) x1148d0e8cc982c04) + ((uint) x1148d0e8cc982c04)) < 0)
            {
                goto Label_00A2;
            }
            if ((((uint) num) - ((uint) x7b28e8a789372508)) <= uint.MaxValue)
            {
                return;
            }
            goto Label_014D;
        Label_007B:
            xfadcfee = xfadcfee.xcc36986f44d69e8f;
            if (((uint) num3) >= 0)
            {
                goto Label_000C;
            }
            goto Label_014D;
        Label_00A2:
            if (xfadcfee.xb5964a891b6cf7c3 > x1148d0e8cc982c04)
            {
                num3 = xfadcfee.x4a3f0a05c02f235f[x7b28e8a789372508];
            }
            else
            {
                if ((((uint) num) + ((uint) num)) >= 0)
                {
                    this.xbbe91b22f83938ea(xfadcfee);
                    this.x0ceec69a97f73617 += xfadcfee.xb5964a891b6cf7c3;
                    xfadcfee.x4a3f0a05c02f235f = null;
                    xfadcfee.xb5964a891b6cf7c3 = 0;
                    goto Label_007B;
                }
                goto Label_000C;
            }
        Label_0120:
            xfadcfee.x4a3f0a05c02f235f[x7b28e8a789372508] = xfadcfee.x4a3f0a05c02f235f[x1148d0e8cc982c04];
            if ((((uint) x1148d0e8cc982c04) - ((uint) x7b28e8a789372508)) < 0)
            {
                goto Label_007B;
            }
            goto Label_0171;
        Label_014D:
            xfadcfee = this.x6aaf91912a47df08.xcc36986f44d69e8f;
            if ((((uint) num3) - ((uint) x1148d0e8cc982c04)) <= uint.MaxValue)
            {
                goto Label_000C;
            }
        Label_0171:
            if ((((uint) num3) + ((uint) num)) >= 0)
            {
                if ((((uint) num3) & 0) != 0)
                {
                    goto Label_0120;
                }
                if (0 != 0)
                {
                    goto Label_02A2;
                }
                xfadcfee.x4a3f0a05c02f235f[x1148d0e8cc982c04] = num3;
                if ((((uint) x1148d0e8cc982c04) + ((uint) x1148d0e8cc982c04)) > uint.MaxValue)
                {
                    if ((((uint) num3) & 0) == 0)
                    {
                        goto Label_014D;
                    }
                    goto Label_000C;
                }
            }
            goto Label_007B;
        Label_01B3:
            if (x7b28e8a789372508 > x1148d0e8cc982c04)
            {
                goto Label_020A;
            }
            if ((((uint) num2) + ((uint) num)) >= 0)
            {
                goto Label_014D;
            }
            return;
        Label_01E2:
            if (this.x4cbb0cc714782977[x1148d0e8cc982c04].xb5964a891b6cf7c3 > 0)
            {
                this.xb91b0c69bab21504(this.x4cbb0cc714782977[x1148d0e8cc982c04]);
                goto Label_01B3;
            }
            if ((((uint) num) | 2) != 0)
            {
                goto Label_01B3;
            }
        Label_020A:
            num2 = x7b28e8a789372508;
            if (((uint) x1148d0e8cc982c04) >= 0)
            {
                x7b28e8a789372508 = x1148d0e8cc982c04;
                x1148d0e8cc982c04 = num2;
                goto Label_014D;
            }
            goto Label_01B3;
        Label_02A2:
            numArray = this.x4cbb0cc714782977[x7b28e8a789372508].x4a3f0a05c02f235f;
            this.x4cbb0cc714782977[x7b28e8a789372508].x4a3f0a05c02f235f = this.x4cbb0cc714782977[x1148d0e8cc982c04].x4a3f0a05c02f235f;
            this.x4cbb0cc714782977[x1148d0e8cc982c04].x4a3f0a05c02f235f = numArray;
            num = this.x4cbb0cc714782977[x7b28e8a789372508].xb5964a891b6cf7c3;
            this.x4cbb0cc714782977[x7b28e8a789372508].xb5964a891b6cf7c3 = this.x4cbb0cc714782977[x1148d0e8cc982c04].xb5964a891b6cf7c3;
            if (2 != 0)
            {
                this.x4cbb0cc714782977[x1148d0e8cc982c04].xb5964a891b6cf7c3 = num;
                if ((0 == 0) && (this.x4cbb0cc714782977[x7b28e8a789372508].xb5964a891b6cf7c3 <= 0))
                {
                    if ((((uint) num) - ((uint) num)) <= uint.MaxValue)
                    {
                        goto Label_01E2;
                    }
                    goto Label_01B3;
                }
                this.xb91b0c69bab21504(this.x4cbb0cc714782977[x7b28e8a789372508]);
                goto Label_01E2;
            }
            goto Label_031B;
        Label_02FA:
            if (this.x4cbb0cc714782977[x1148d0e8cc982c04].xb5964a891b6cf7c3 > 0)
            {
                this.xbbe91b22f83938ea(this.x4cbb0cc714782977[x1148d0e8cc982c04]);
            }
            goto Label_02A2;
        Label_031B:
            this.xbbe91b22f83938ea(this.x4cbb0cc714782977[x7b28e8a789372508]);
            goto Label_02FA;
        }

        private void xb91b0c69bab21504(xf2a930dcfe72e757 xe24dd90acb923d68)
        {
            xe24dd90acb923d68.xcc36986f44d69e8f = this.x6aaf91912a47df08;
            xe24dd90acb923d68.x1ec81c4ce7413e94 = this.x6aaf91912a47df08.x1ec81c4ce7413e94;
            xe24dd90acb923d68.x1ec81c4ce7413e94.xcc36986f44d69e8f = xe24dd90acb923d68;
            xe24dd90acb923d68.xcc36986f44d69e8f.x1ec81c4ce7413e94 = xe24dd90acb923d68;
        }

        private void xbbe91b22f83938ea(xf2a930dcfe72e757 xe24dd90acb923d68)
        {
            xe24dd90acb923d68.x1ec81c4ce7413e94.xcc36986f44d69e8f = xe24dd90acb923d68.xcc36986f44d69e8f;
            xe24dd90acb923d68.xcc36986f44d69e8f.x1ec81c4ce7413e94 = xe24dd90acb923d68.x1ec81c4ce7413e94;
        }

        private sealed class xf2a930dcfe72e757
        {
            internal xb730a77005d16cc1.xf2a930dcfe72e757 x1ec81c4ce7413e94;
            internal float[] x4a3f0a05c02f235f;
            private xb730a77005d16cc1 x5379072b6f8760d5;
            internal int xb5964a891b6cf7c3;
            internal xb730a77005d16cc1.xf2a930dcfe72e757 xcc36986f44d69e8f;

            public xf2a930dcfe72e757(xb730a77005d16cc1 enclosingInstance)
            {
                this.x5afd8a8ddf2b5c34(enclosingInstance);
            }

            private void x5afd8a8ddf2b5c34(xb730a77005d16cc1 x5379072b6f8760d5)
            {
                this.x5379072b6f8760d5 = x5379072b6f8760d5;
            }

            public xb730a77005d16cc1 xc76253815178e0af
            {
                get
                {
                    return this.x5379072b6f8760d5;
                }
            }
        }
    }
}

