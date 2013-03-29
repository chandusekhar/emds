namespace Nsim
{
    using Encog.ML.Data;
    using Encog.ML.Data.Basic;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FunctionalPreprocessorBase
    {
        protected static readonly Func<double, double>[] Functions;
        protected static readonly int FunctionsCount = 11;
        protected static readonly string[] FunctionTitles;

        static FunctionalPreprocessorBase()
        {
            goto Label_01AA;
        Label_0059:
            FunctionTitles[7] = "КореньТретьейСтепени(X)";
            if (0 == 0)
            {
            }
            Functions[8] = new Func<double, double>(null, (IntPtr) xbe016755c9220cec);
            FunctionTitles[8] = "Ln(X)";
            if (2 != 0)
            {
                if (0 == 0)
                {
                    Functions[9] = new Func<double, double>(null, (IntPtr) x8570b57025969d68);
                    FunctionTitles[9] = "Sin(X)";
                    Functions[10] = new Func<double, double>(null, (IntPtr) xb1e0e9de1ea48efc);
                    FunctionTitles[10] = "Tg(X)";
                    if (1 != 0)
                    {
                        return;
                    }
                    goto Label_0102;
                }
                goto Label_00B2;
            }
        Label_008E:
            FunctionTitles[6] = "Корень(X)";
            Functions[7] = new Func<double, double>(null, (IntPtr) xdfb7b34114e098fc);
            if (0 != 0)
            {
                goto Label_0188;
            }
            goto Label_0059;
        Label_00B2:
            Functions[5] = new Func<double, double>(null, (IntPtr) x9c749dbd981c6e5b);
            FunctionTitles[5] = "1/X*X*X";
            Functions[6] = new Func<double, double>(null, (IntPtr) x2c656f67c9fa2169);
            goto Label_008E;
        Label_0102:
            Functions[4] = new Func<double, double>(null, (IntPtr) x26c0497cb6d16d45);
            if (0 == 0)
            {
                FunctionTitles[4] = "1/X*X";
                goto Label_00B2;
            }
            return;
        Label_0188:
            FunctionTitles[1] = "X*X";
            Functions[2] = new Func<double, double>(null, (IntPtr) xda195742e45e2fd4);
            if (0 == 0)
            {
                FunctionTitles[2] = "X*X*X";
                Functions[3] = new Func<double, double>(null, (IntPtr) x25895157ffbf1e5c);
                FunctionTitles[3] = "1/X";
                goto Label_0102;
            }
        Label_01AA:
            if (0 != 0)
            {
                goto Label_0059;
            }
            Functions = new Func<double, double>[FunctionsCount];
            FunctionTitles = new string[FunctionsCount];
            if (0 != 0)
            {
                goto Label_008E;
            }
            Functions[0] = new Func<double, double>(null, (IntPtr) X);
            FunctionTitles[0] = "X";
            Functions[1] = new Func<double, double>(null, (IntPtr) xb7520d4adc7a6aaa);
            goto Label_0188;
        }

        protected double GenericCorrelation(BasicMLDataSet data, Func<double, double> inFunc, Func<double, double> idFunc, int inNum, int idNum)
        {
            double num;
            double num2;
            double num3;
            double num4;
            double num6;
            bool flag;
            goto Label_01DA;
        Label_0170:
            num6 = Math.Abs((double) (num / (Math.Sqrt(num2) * Math.Sqrt(num3))));
            if (0 != 0)
            {
            }
            return num6;
        Label_01DA:;
            if ((((uint) num) | 0x80000000) == 0)
            {
                return num6;
            }
            do
            {
                num = 0.0;
                num2 = 0.0;
            }
            while ((((uint) num6) - ((uint) num4)) > uint.MaxValue);
            if ((((uint) flag) - ((uint) idNum)) >= 0)
            {
                <>c__DisplayClass2 class2;
                num3 = 0.0;
                num4 = Enumerable.Sum<IMLDataPair>(data, new Func<IMLDataPair, double>(class2, (IntPtr) this.<GenericCorrelation>b__0)) / ((double) data.Count<IMLDataPair>());
                double num5 = Enumerable.Sum<IMLDataPair>(data, new Func<IMLDataPair, double>(class2, (IntPtr) this.<GenericCorrelation>b__1)) / ((double) data.Count<IMLDataPair>());
                using (IEnumerator<IMLDataPair> enumerator = data.GetEnumerator())
                {
                    goto Label_0149;
                Label_0062:
                    if (!flag && ((((uint) num5) - ((uint) num4)) >= 0))
                    {
                        goto Label_0170;
                    }
                    IMLDataPair current = enumerator.Current;
                    num += (inFunc.Invoke(current.InputArray[inNum]) - num4) * (idFunc.Invoke(current.IdealArray[idNum]) - num5);
                    num2 += (inFunc.Invoke(current.InputArray[inNum]) - num4) * (inFunc.Invoke(current.InputArray[inNum]) - num4);
                    num3 += (idFunc.Invoke(current.IdealArray[idNum]) - num5) * (idFunc.Invoke(current.IdealArray[idNum]) - num5);
                Label_0149:
                    flag = enumerator.MoveNext();
                    if (0 == 0)
                    {
                        goto Label_0062;
                    }
                }
                goto Label_0170;
            }
            goto Label_01DA;
        }

        protected static double X(double x)
        {
            return x;
        }

        private static double x25895157ffbf1e5c(double x08db3aeabb253cb1)
        {
            return (1.0 / x08db3aeabb253cb1);
        }

        private static double x26c0497cb6d16d45(double x08db3aeabb253cb1)
        {
            return ((1.0 / x08db3aeabb253cb1) * x08db3aeabb253cb1);
        }

        private static double x2c656f67c9fa2169(double x08db3aeabb253cb1)
        {
            return Math.Pow(x08db3aeabb253cb1, 0.5);
        }

        private static double x8570b57025969d68(double x08db3aeabb253cb1)
        {
            return Math.Sin(x08db3aeabb253cb1);
        }

        private static double x9c749dbd981c6e5b(double x08db3aeabb253cb1)
        {
            return (((1.0 / x08db3aeabb253cb1) * x08db3aeabb253cb1) * x08db3aeabb253cb1);
        }

        private static double xb1e0e9de1ea48efc(double x08db3aeabb253cb1)
        {
            return Math.Tan(x08db3aeabb253cb1);
        }

        private static double xb7520d4adc7a6aaa(double x08db3aeabb253cb1)
        {
            return (x08db3aeabb253cb1 * x08db3aeabb253cb1);
        }

        private static double xbe016755c9220cec(double x08db3aeabb253cb1)
        {
            return Math.Log(x08db3aeabb253cb1);
        }

        private static double xda195742e45e2fd4(double x08db3aeabb253cb1)
        {
            return ((x08db3aeabb253cb1 * x08db3aeabb253cb1) * x08db3aeabb253cb1);
        }

        private static double xdfb7b34114e098fc(double x08db3aeabb253cb1)
        {
            return Math.Pow(x08db3aeabb253cb1, 0.33333333333333331);
        }
    }
}

