namespace Encog.MathUtil.LIBSVM
{
    using System;

    internal class xa68541a68dd6f460 : xf094e3229d63c9be
    {
        private readonly sbyte[] x1e218ceaee1bb583;
        private readonly xb730a77005d16cc1 x1f31bf6ca58166a1;

        internal xa68541a68dd6f460(svm_problem prob, svm_parameter param, sbyte[] y_) : base(prob.l, prob.x, param)
        {
            this.x1e218ceaee1bb583 = new sbyte[y_.Length];
            y_.CopyTo(this.x1e218ceaee1bb583, 0);
            this.x1f31bf6ca58166a1 = new xb730a77005d16cc1(prob.l, (int) (param.cache_size * 1048576.0));
        }

        internal override float[] get_x6648d9580110b138(int x7b28e8a789372508, int xb5964a891b6cf7c3)
        {
            int num2;
            float[][] numArray = new float[1][];
            while (((uint) num2) >= 0)
            {
                int num;
                if ((num = this.x1f31bf6ca58166a1.get_x4a3f0a05c02f235f(x7b28e8a789372508, numArray, xb5964a891b6cf7c3)) < xb5964a891b6cf7c3)
                {
                    for (num2 = num; num2 < xb5964a891b6cf7c3; num2++)
                    {
                        numArray[0][num2] = (float) ((this.x1e218ceaee1bb583[x7b28e8a789372508] * this.x1e218ceaee1bb583[num2]) * this.x1e221c4999144ac5(x7b28e8a789372508, num2));
                    }
                }
                break;
            }
            return numArray[0];
        }

        internal override void x89083ecc6edaa4e0(int x7b28e8a789372508, int x1148d0e8cc982c04)
        {
            this.x1f31bf6ca58166a1.x89083ecc6edaa4e0(x7b28e8a789372508, x1148d0e8cc982c04);
            base.x89083ecc6edaa4e0(x7b28e8a789372508, x1148d0e8cc982c04);
            sbyte num = this.x1e218ceaee1bb583[x7b28e8a789372508];
            this.x1e218ceaee1bb583[x7b28e8a789372508] = this.x1e218ceaee1bb583[x1148d0e8cc982c04];
            this.x1e218ceaee1bb583[x1148d0e8cc982c04] = num;
        }
    }
}

