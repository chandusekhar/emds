namespace Encog.MathUtil.LIBSVM
{
    using System;

    [Serializable]
    public class svm_parameter : ICloneable
    {
        public double C;
        public const int C_SVC = 0;
        public double cache_size;
        public double coef0;
        public double degree;
        public double eps;
        public const int EPSILON_SVR = 3;
        public double gamma;
        public int kernel_type;
        public const int LINEAR = 0;
        public int nr_weight;
        public double nu;
        public const int NU_SVC = 1;
        public const int NU_SVR = 4;
        public const int ONE_CLASS = 2;
        public double p;
        public const int POLY = 1;
        public int probability;
        public const int RBF = 2;
        public int shrinking;
        public const int SIGMOID = 3;
        public int svm_type;
        public double[] weight;
        public int[] weight_label;

        public virtual object Clone()
        {
            try
            {
                return base.MemberwiseClone();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}

