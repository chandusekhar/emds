namespace Nsim
{
    using Encog.ML.Data;
    using Encog.ML.Data.Basic;
    using Encog.Neural.Networks;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Xml.Linq;

    internal static class x97d09efa0c4ea9c0
    {
        public static double[] CalcData(BasicMLDataSet data)
        {
            BasicNetwork network;
            double num;
            int num2;
            double num3;
            ChartWindow window;
            <>c__DisplayClass5 class2;
            bool flag;
            double[] res;
            XElement xml = App.Services.GetService<x1a44f162f55467a5>().Xml;
            if ((((uint) num) - ((uint) flag)) > uint.MaxValue)
            {
                goto Label_00F6;
            }
            if (1 != 0)
            {
                if ((((uint) num3) - ((uint) num2)) < 0)
                {
                    double[] numArray;
                    return numArray;
                }
                App.Services.GetService<xf8efd7615008d32e>().x4ab8973167965816();
                network = App.Services.GetService<xf8efd7615008d32e>().x5b0926ce641e48a7;
                data = App.Services.GetService<IDataProcessor>().ProcessDataSet(data);
                num = network.CalculateError(data);
                res = new double[network.InputCount];
                num2 = 0;
                goto Label_00E9;
            }
        Label_003D:
            window = new ChartWindow {
                chart = { Title = "Значимость параметров" },
                barSeries = { ItemsSource = Enumerable.Select<double, Tuple<double, bool>>(res, new Func<double, Tuple<double, bool>>(class2, this.<CalcData>b__4)) }
            };
            window.ShowDialog();
            App.Services.GetService<x1a44f162f55467a5>().Xml = xml;
            return res;
        Label_00C0:
            if (flag)
            {
                goto Label_00F6;
            }
            num3 = res.Max();
            num2 = 0;
            while (true)
            {
                flag = num2 < network.InputCount;
                if (flag)
                {
                    res[num2] /= num3;
                }
                else
                {
                    GC.Collect();
                    goto Label_003D;
                }
                num2++;
            }
        Label_00E9:
            flag = num2 < network.InputCount;
            goto Label_00C0;
        Label_00F6:
            res[num2] = network.CalculateError(data.xf266aaef11483efa(num2)) - num;
            if ((((uint) num2) | 15) != 0)
            {
                num2++;
                if ((((uint) num2) + ((uint) flag)) > uint.MaxValue)
                {
                    goto Label_003D;
                }
                goto Label_00E9;
            }
            goto Label_00C0;
        }

        public static BasicMLDataSet xf266aaef11483efa(this BasicMLDataSet x4a3f0a05c02f235f, int xc4f9f0b1fd52f7ed)
        {
            <>c__DisplayClass2 class2;
            bool flag;
            int colToNull = xc4f9f0b1fd52f7ed;
            BasicMLDataSet set = x4a3f0a05c02f235f.Clone() as BasicMLDataSet;
            Random random = new Random(5);
            double num = Enumerable.Min<IMLDataPair>(set, new Func<IMLDataPair, double>(class2, (IntPtr) this.<GetCloned>b__0));
            double num2 = Enumerable.Max<IMLDataPair>(set, new Func<IMLDataPair, double>(class2, (IntPtr) this.<GetCloned>b__1));
            IEnumerator<IMLDataPair> enumerator = set.GetEnumerator();
            try
            {
                IMLDataPair pair;
                goto Label_008A;
            Label_0052:
                pair = enumerator.Current;
                pair.InputArray[colToNull] = (random.NextDouble() * (num2 - num)) + num;
                if (((uint) flag) <= uint.MaxValue)
                {
                }
            Label_008A:
                flag = enumerator.MoveNext();
                if (flag)
                {
                    goto Label_0052;
                }
            }
            finally
            {
                flag = enumerator == null;
                while (!flag)
                {
                    enumerator.Dispose();
                    break;
                }
            }
            BasicMLDataSet set2 = set;
            if (8 != 0)
            {
            }
            return set2;
        }
    }
}

