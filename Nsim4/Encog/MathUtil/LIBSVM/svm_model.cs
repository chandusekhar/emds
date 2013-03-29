namespace Encog.MathUtil.LIBSVM
{
    using System;

    [Serializable]
    public class svm_model
    {
        internal int l;
        internal int[] label;
        internal int nr_class;
        internal int[] nSV;
        internal svm_parameter param;
        internal double[] probA;
        internal double[] probB;
        internal double[] rho;
        public svm_node[][] SV;
        internal double[][] sv_coef;
    }
}

