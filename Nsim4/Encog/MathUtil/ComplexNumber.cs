namespace Encog.MathUtil
{
    using Encog.Util;
    using System;

    public class ComplexNumber
    {
        private readonly double _x08db3aeabb253cb1;
        private readonly double _x1e218ceaee1bb583;

        public ComplexNumber(ComplexNumber other)
        {
            this._x08db3aeabb253cb1 = other.Real;
            this._x1e218ceaee1bb583 = other.Imaginary;
        }

        public ComplexNumber(double u, double v)
        {
            this._x08db3aeabb253cb1 = u;
            this._x1e218ceaee1bb583 = v;
        }

        public double Arg()
        {
            return Math.Atan2(this._x1e218ceaee1bb583, this._x08db3aeabb253cb1);
        }

        public ComplexNumber Conj()
        {
            return new ComplexNumber(this._x08db3aeabb253cb1, -this._x1e218ceaee1bb583);
        }

        public ComplexNumber Cos()
        {
            return new ComplexNumber(x96dd47ebf370a5ff(this._x1e218ceaee1bb583) * Math.Cos(this._x08db3aeabb253cb1), -x00b7cb0e4eefe32a(this._x1e218ceaee1bb583) * Math.Sin(this._x08db3aeabb253cb1));
        }

        public ComplexNumber Cosh()
        {
            return new ComplexNumber(x96dd47ebf370a5ff(this._x08db3aeabb253cb1) * Math.Cos(this._x1e218ceaee1bb583), x00b7cb0e4eefe32a(this._x08db3aeabb253cb1) * Math.Sin(this._x1e218ceaee1bb583));
        }

        public ComplexNumber Exp()
        {
            return new ComplexNumber(Math.Exp(this._x08db3aeabb253cb1) * Math.Cos(this._x1e218ceaee1bb583), Math.Exp(this._x08db3aeabb253cb1) * Math.Sin(this._x1e218ceaee1bb583));
        }

        public ComplexNumber Log()
        {
            return new ComplexNumber(Math.Log(this.Mod()), this.Arg());
        }

        public double Mod()
        {
            if (((this._x08db3aeabb253cb1 == 0.0) && (1 != 0)) && (this._x1e218ceaee1bb583 == 0.0))
            {
                return 0.0;
            }
            return Math.Sqrt((this._x08db3aeabb253cb1 * this._x08db3aeabb253cb1) + (this._x1e218ceaee1bb583 * this._x1e218ceaee1bb583));
        }

        public static ComplexNumber operator +(ComplexNumber c1, ComplexNumber c2)
        {
            return new ComplexNumber(c1.Real + c2.Real, c1.Imaginary + c2.Imaginary);
        }

        public static ComplexNumber operator /(ComplexNumber c1, ComplexNumber c2)
        {
            double num = Math.Pow(c2.Mod(), 2.0);
            return new ComplexNumber(((c1.Real * c2.Real) + (c1.Imaginary * c2.Imaginary)) / num, ((c1.Imaginary * c2.Real) - (c1.Real * c2.Imaginary)) / num);
        }

        public static ComplexNumber operator *(ComplexNumber c1, ComplexNumber c2)
        {
            return new ComplexNumber((c1.Real * c2.Real) - (c1.Imaginary * c2.Imaginary), (c1.Real * c2.Imaginary) + (c1.Imaginary * c2.Real));
        }

        public static ComplexNumber operator -(ComplexNumber c1, ComplexNumber c2)
        {
            return new ComplexNumber(c1.Real - c2.Real, c1.Imaginary - c2.Imaginary);
        }

        public static ComplexNumber operator -(ComplexNumber op)
        {
            return new ComplexNumber(-op.Real, -op.Imaginary);
        }

        public ComplexNumber Sin()
        {
            return new ComplexNumber(x96dd47ebf370a5ff(this._x1e218ceaee1bb583) * Math.Sin(this._x08db3aeabb253cb1), x00b7cb0e4eefe32a(this._x1e218ceaee1bb583) * Math.Cos(this._x08db3aeabb253cb1));
        }

        public ComplexNumber Sinh()
        {
            return new ComplexNumber(x00b7cb0e4eefe32a(this._x08db3aeabb253cb1) * Math.Cos(this._x1e218ceaee1bb583), x96dd47ebf370a5ff(this._x08db3aeabb253cb1) * Math.Sin(this._x1e218ceaee1bb583));
        }

        public ComplexNumber Sqrt()
        {
            double num = Math.Sqrt(this.Mod());
            double d = this.Arg() / 2.0;
            return new ComplexNumber(num * Math.Cos(d), num * Math.Sin(d));
        }

        public ComplexNumber Tan()
        {
            return (this.Sin() / this.Cos());
        }

        public string ToString()
        {
            object[] objArray;
            if (this._x08db3aeabb253cb1 != 0.0)
            {
                do
                {
                    if ((0 == 0) && (this._x1e218ceaee1bb583 <= 0.0))
                    {
                        if (-2147483648 == 0)
                        {
                            goto Label_00F2;
                        }
                        goto Label_0051;
                    }
                    objArray = new object[4];
                    objArray[0] = this._x08db3aeabb253cb1;
                    objArray[1] = " + ";
                    if (0 == 0)
                    {
                        objArray[2] = this._x1e218ceaee1bb583;
                        goto Label_00F2;
                    }
                }
                while (15 == 0);
                goto Label_0135;
            }
        Label_0051:
            while ((this._x08db3aeabb253cb1 != 0.0) && (this._x1e218ceaee1bb583 < 0.0))
            {
                object[] objArray2 = new object[4];
                objArray2[0] = this._x08db3aeabb253cb1;
                if (0 == 0)
                {
                    objArray2[1] = " - ";
                    objArray2[2] = -this._x1e218ceaee1bb583;
                    objArray2[3] = "i";
                    return string.Concat(objArray2);
                }
            }
            if (this._x1e218ceaee1bb583 == 0.0)
            {
                return Format.FormatDouble(this._x08db3aeabb253cb1, 4);
            }
            if (this._x08db3aeabb253cb1 != 0.0)
            {
                goto Label_0135;
            }
            return (this._x1e218ceaee1bb583 + "i");
        Label_00F2:
            objArray[3] = "i";
            return string.Concat(objArray);
        Label_0135:
            return (this._x08db3aeabb253cb1 + " + i*" + this._x1e218ceaee1bb583);
        }

        private static double x00b7cb0e4eefe32a(double x17338e069de9c29c)
        {
            return ((Math.Exp(x17338e069de9c29c) - Math.Exp(-x17338e069de9c29c)) / 2.0);
        }

        private static double x96dd47ebf370a5ff(double x17338e069de9c29c)
        {
            return ((Math.Exp(x17338e069de9c29c) + Math.Exp(-x17338e069de9c29c)) / 2.0);
        }

        public double Imaginary
        {
            get
            {
                return this._x1e218ceaee1bb583;
            }
        }

        public double Real
        {
            get
            {
                return this._x08db3aeabb253cb1;
            }
        }
    }
}

