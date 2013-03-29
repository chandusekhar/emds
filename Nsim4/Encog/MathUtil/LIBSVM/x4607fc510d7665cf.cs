namespace Encog.MathUtil.LIBSVM
{
    using System;

    internal class x4607fc510d7665cf : xf094e3229d63c9be
    {
        private readonly xb730a77005d16cc1 x1f31bf6ca58166a1;

        internal x4607fc510d7665cf(svm_problem prob, svm_parameter param) : base(prob.l, prob.x, param)
        {
            this.x1f31bf6ca58166a1 = new xb730a77005d16cc1(prob.l, (int) (param.cache_size * 1048576.0));
        }

        internal override float[] get_x6648d9580110b138(int x7b28e8a789372508, int xb5964a891b6cf7c3)
        {
            int num;
            float[][] numArray = new float[1][];
        Label_002E:
            if ((num = this.x1f31bf6ca58166a1.get_x4a3f0a05c02f235f(x7b28e8a789372508, numArray, xb5964a891b6cf7c3)) < xb5964a891b6cf7c3)
            {
                int index = num;
                if (2 == 0)
                {
                    goto Label_002E;
                }
                while (index < xb5964a891b6cf7c3)
                {
                    numArray[0][index] = (float) this.x1e221c4999144ac5(x7b28e8a789372508, index);
                    index++;
                }
                if (((((uint) index) - ((uint) index)) > uint.MaxValue) || (0 != 0))
                {
                    goto Label_002E;
                }
            }
            return numArray[0];
        }

        internal override void x89083ecc6edaa4e0(int x7b28e8a789372508, int x1148d0e8cc982c04)
        {
            this.x1f31bf6ca58166a1.x89083ecc6edaa4e0(x7b28e8a789372508, x1148d0e8cc982c04);
            base.x89083ecc6edaa4e0(x7b28e8a789372508, x1148d0e8cc982c04);
        }
    }
}

