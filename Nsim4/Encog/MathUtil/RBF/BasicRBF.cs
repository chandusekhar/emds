namespace Encog.MathUtil.RBF
{
    using System;

    [Serializable]
    public abstract class BasicRBF : IRadialBasisFunction
    {
        private double[] _center;
        private double _peak;
        private double _width;

        protected BasicRBF()
        {
        }

        public abstract double Calculate(double[] x);

        public double[] Centers
        {
            get
            {
                return this._center;
            }
            set
            {
                this._center = value;
            }
        }

        public int Dimensions
        {
            get
            {
                return this._center.Length;
            }
        }

        public double Peak
        {
            get
            {
                return this._peak;
            }
            set
            {
                this._peak = value;
            }
        }

        public double Width
        {
            get
            {
                return this._width;
            }
            set
            {
                this._width = value;
            }
        }
    }
}

