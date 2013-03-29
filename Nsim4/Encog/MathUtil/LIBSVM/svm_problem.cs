namespace Encog.MathUtil.LIBSVM
{
    using System;

    [Serializable]
    public class svm_problem
    {
        public int l;
        public svm_node[][] x;
        public double[] y;
    }
}

