namespace Encog.MathUtil.Error
{
    using System;

    public class ErrorCalculation
    {
        private int _x89c6b52fd1c4115c;
        private static ErrorCalculationMode _xa4aa8b4150b11435 = ErrorCalculationMode.MSE;
        private double _xbcdc6307f8846679;

        public double Calculate()
        {
            if (this._x89c6b52fd1c4115c == 0)
            {
                if (0 == 0)
                {
                    return 0.0;
                }
            }
            else
            {
                switch (Mode)
                {
                    case ErrorCalculationMode.RMS:
                        return this.CalculateRMS();

                    case ErrorCalculationMode.MSE:
                        break;

                    default:
                        return this.CalculateMSE();
                }
            }
            return this.CalculateMSE();
        }

        public double CalculateMSE()
        {
            if (this._x89c6b52fd1c4115c == 0)
            {
                return 0.0;
            }
            return (this._xbcdc6307f8846679 / ((double) this._x89c6b52fd1c4115c));
        }

        public double CalculateRMS()
        {
            if (this._x89c6b52fd1c4115c == 0)
            {
                return 0.0;
            }
            return Math.Sqrt(this._xbcdc6307f8846679 / ((double) this._x89c6b52fd1c4115c));
        }

        public void Reset()
        {
            this._xbcdc6307f8846679 = 0.0;
            this._x89c6b52fd1c4115c = 0;
        }

        public void UpdateError(double actual, double ideal)
        {
            double num = ideal - actual;
            this._xbcdc6307f8846679 += num * num;
            this._x89c6b52fd1c4115c++;
        }

        public void UpdateError(double[] actual, double[] ideal, double significance)
        {
            int index = 0;
            while (true)
            {
                double num2;
                while ((index < actual.Length) || ((((uint) index) & 0) != 0))
                {
                    num2 = ideal[index] - actual[index];
                    this._xbcdc6307f8846679 += num2 * num2;
                    index++;
                }
                this._x89c6b52fd1c4115c += ideal.Length;
                if ((((uint) num2) + ((uint) significance)) <= uint.MaxValue)
                {
                    return;
                }
            }
        }

        public static ErrorCalculationMode Mode
        {
            get
            {
                return _xa4aa8b4150b11435;
            }
            set
            {
                _xa4aa8b4150b11435 = value;
            }
        }
    }
}

