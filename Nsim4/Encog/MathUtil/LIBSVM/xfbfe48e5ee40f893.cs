namespace Encog.MathUtil.LIBSVM
{
    using System;

    internal class xfbfe48e5ee40f893 : xf094e3229d63c9be
    {
        private readonly xb730a77005d16cc1 x1f31bf6ca58166a1;
        private readonly sbyte[] x32dce50116aa0f1e;
        private readonly float[][] x5cafa8d49ea71ea1;
        private readonly int x9fc3ee03a439f6f0;
        private int xafb0a999075e2e6a;
        private readonly int[] xc0c4c459c6ccbd00;

        internal xfbfe48e5ee40f893(svm_problem prob, svm_parameter param) : base(prob.l, prob.x, param)
        {
            int num;
            int num2;
            if (((uint) num) > uint.MaxValue)
            {
                goto Label_005C;
            }
            this.x9fc3ee03a439f6f0 = prob.l;
            if ((((uint) num) - ((uint) num2)) > uint.MaxValue)
            {
                if ((((uint) num2) + ((uint) num)) > uint.MaxValue)
                {
                    goto Label_0115;
                }
            }
            else
            {
                goto Label_0115;
            }
        Label_0024:
            this.x5cafa8d49ea71ea1[num2] = new float[2 * this.x9fc3ee03a439f6f0];
            num2++;
        Label_003D:
            if (num2 < 2)
            {
                goto Label_0024;
            }
            this.xafb0a999075e2e6a = 0;
            if (0 == 0)
            {
                return;
            }
            goto Label_00C0;
        Label_005C:
            num2 = 0;
            goto Label_003D;
        Label_00C0:
            this.xc0c4c459c6ccbd00 = new int[2 * this.x9fc3ee03a439f6f0];
            for (num = 0; num < this.x9fc3ee03a439f6f0; num++)
            {
                this.x32dce50116aa0f1e[num] = 1;
                this.x32dce50116aa0f1e[num + this.x9fc3ee03a439f6f0] = -1;
                this.xc0c4c459c6ccbd00[num] = num;
                this.xc0c4c459c6ccbd00[num + this.x9fc3ee03a439f6f0] = num;
            }
            this.x5cafa8d49ea71ea1 = new float[2][];
            goto Label_005C;
        Label_0115:
            this.x1f31bf6ca58166a1 = new xb730a77005d16cc1(this.x9fc3ee03a439f6f0, (int) (param.cache_size * 1048576.0));
            this.x32dce50116aa0f1e = new sbyte[2 * this.x9fc3ee03a439f6f0];
            goto Label_00C0;
        }

        internal override float[] get_x6648d9580110b138(int x7b28e8a789372508, int xb5964a891b6cf7c3)
        {
            int num2;
            float[] numArray2;
            sbyte num3;
            int num4;
            float[][] numArray = new float[1][];
            if ((((uint) num2) + ((uint) num4)) >= 0)
            {
                int num = this.xc0c4c459c6ccbd00[x7b28e8a789372508];
                if (((((uint) num4) - ((uint) num3)) > uint.MaxValue) || (this.x1f31bf6ca58166a1.get_x4a3f0a05c02f235f(num, numArray, this.x9fc3ee03a439f6f0) < this.x9fc3ee03a439f6f0))
                {
                    num2 = 0;
                    if ((((uint) num) + ((uint) num3)) < 0)
                    {
                        goto Label_0047;
                    }
                    while (num2 < this.x9fc3ee03a439f6f0)
                    {
                        numArray[0][num2] = (float) this.x1e221c4999144ac5(num, num2);
                    Label_00D6:
                        num2++;
                    }
                }
                numArray2 = this.x5cafa8d49ea71ea1[this.xafb0a999075e2e6a];
                this.xafb0a999075e2e6a = 1 - this.xafb0a999075e2e6a;
                num3 = this.x32dce50116aa0f1e[x7b28e8a789372508];
                if (((uint) num) > uint.MaxValue)
                {
                    goto Label_00D6;
                }
                num4 = 0;
                goto Label_0047;
            }
        Label_0022:
            numArray2[num4] = (num3 * this.x32dce50116aa0f1e[num4]) * numArray[0][this.xc0c4c459c6ccbd00[num4]];
            num4++;
        Label_0047:
            if (num4 < xb5964a891b6cf7c3)
            {
                goto Label_0022;
            }
            return numArray2;
        }

        internal override void x89083ecc6edaa4e0(int x7b28e8a789372508, int x1148d0e8cc982c04)
        {
            sbyte num = this.x32dce50116aa0f1e[x7b28e8a789372508];
            if ((((uint) num) - ((uint) x1148d0e8cc982c04)) <= uint.MaxValue)
            {
                this.x32dce50116aa0f1e[x7b28e8a789372508] = this.x32dce50116aa0f1e[x1148d0e8cc982c04];
            }
            this.x32dce50116aa0f1e[x1148d0e8cc982c04] = num;
            int num2 = this.xc0c4c459c6ccbd00[x7b28e8a789372508];
            this.xc0c4c459c6ccbd00[x7b28e8a789372508] = this.xc0c4c459c6ccbd00[x1148d0e8cc982c04];
            this.xc0c4c459c6ccbd00[x1148d0e8cc982c04] = num2;
        }
    }
}

