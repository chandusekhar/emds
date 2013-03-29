namespace Nsim
{
    using Encog.ML.Data;
    using Encog.ML.Data.Basic;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;

    internal static class x57162336149345a9
    {
        public static double[] x8e46c20a382f5c57(this BasicMLDataSet xb84e142a2d790b60)
        {
            Func<IMLDataPair, int, double> func2;
            <>c__DisplayClasse classe;
            bool flag;
            BasicMLDataSet dataSet = xb84e142a2d790b60;
            xd9dac609ec6b6137(dataSet);
            double[] numArray = new double[dataSet.IdealSize];
            Func<IMLDataPair, int, double> func = null;
            goto Label_00D8;
        Label_0021:
            if (i >= dataSet.IdealSize)
            {
                return numArray;
            }
            if (func == null)
            {
                func = new Func<IMLDataPair, int, double>(classe, (IntPtr) this.<GetOtnError>b__8);
            }
            double num = Enumerable.Select<IMLDataPair, double>(dataSet, func).Sum() / ((double) dataSet.Count);
            if (func2 == null)
            {
                func2 = new Func<IMLDataPair, int, double>(classe, (IntPtr) this.<GetOtnError>b__9);
            }
            double num2 = Enumerable.Select<IMLDataPair, double>(dataSet, func2).Sum();
        Label_00A2:
            numArray[i] = (100.0 * (num2 / ((double) dataSet.Count))) / num;
            i++;
            goto Label_0021;
        Label_00D8:
            func2 = null;
            if ((((uint) flag) + ((uint) num2)) < 0)
            {
                goto Label_00A2;
            }
            int i = 0;
            if (0 == 0)
            {
                goto Label_0021;
            }
            goto Label_00D8;
        }

        private static void xd9dac609ec6b6137(IEnumerable<IMLDataPair> xb84e142a2d790b60)
        {
            bool flag;
            xf8efd7615008d32e service = App.Services.GetService<xf8efd7615008d32e>();
            IDataProcessor processor = App.Services.GetService<IDataProcessor>();
            IEnumerator<IMLDataPair> enumerator = xb84e142a2d790b60.GetEnumerator();
            try
            {
                IMLDataPair pair;
                IMLData data;
            Label_0024:
                flag = enumerator.MoveNext();
                if (flag)
                {
                    goto Label_0099;
                }
                if ((((uint) flag) | 4) == 0)
                {
                    return;
                }
                goto Label_0085;
            Label_004B:
                data = processor.ProcessInputVector(new BasicMLData(pair.InputArray));
                IMLData row = service.x5b0926ce641e48a7.Compute(data);
                IMLData data3 = processor.RestoreIdealVector(row);
                pair.CalcedArray = data3.Data;
                goto Label_0024;
            Label_0085:
                if ((((uint) flag) & 0) == 0)
                {
                    return;
                }
            Label_0099:
                pair = enumerator.Current;
                if (((uint) flag) >= 0)
                {
                    goto Label_004B;
                }
            }
            finally
            {
                flag = enumerator == null;
                while (!flag)
                {
                    enumerator.Dispose();
                    if (((uint) flag) > uint.MaxValue)
                    {
                    }
                    break;
                }
            }
        }

        public static double[] xde3e9f8cc0169fde(this BasicMLDataSet xb84e142a2d790b60)
        {
            double num;
            double num2;
            Func<IMLDataPair, int, double> func2;
            <>c__DisplayClass6 class2;
            double[] numArray2;
            BasicMLDataSet dataSet = xb84e142a2d790b60;
            xd9dac609ec6b6137(dataSet);
            if ((((uint) num2) - ((uint) num2)) < 0)
            {
                goto Label_0068;
            }
            double[] numArray = new double[dataSet.IdealSize];
            if (4 == 0)
            {
                goto Label_0082;
            }
            Func<IMLDataPair, int, double> func = null;
            if (15 != 0)
            {
                func2 = null;
                int i;
                if ((((uint) num2) & 0) != 0)
                {
                    return numArray2;
                }
                goto Label_0082;
            }
            return numArray2;
        Label_004D:
            if (i < dataSet.IdealSize)
            {
                if (func == null)
                {
                    func = new Func<IMLDataPair, int, double>(class2, (IntPtr) this.<GetRmssError>b__0);
                }
                num = Enumerable.Select<IMLDataPair, double>(dataSet, func).Sum() / ((double) dataSet.Count);
                goto Label_00CD;
            }
        Label_0068:
            numArray2 = numArray;
            if ((((uint) num) & 0) == 0)
            {
                return numArray2;
            }
        Label_0082:;
            i = 0;
            if (0 == 0)
            {
                goto Label_004D;
            }
        Label_00CD:
            if (func2 == null)
            {
                func2 = new Func<IMLDataPair, int, double>(class2, (IntPtr) this.<GetRmssError>b__1);
            }
            num2 = Enumerable.Select<IMLDataPair, double>(dataSet, func2).Sum();
            if (15 != 0)
            {
                numArray[i] = (100.0 * Math.Sqrt(num2 / ((double) (dataSet.Count - 1L)))) / num;
                i++;
                goto Label_004D;
            }
            return numArray2;
        }
    }
}

