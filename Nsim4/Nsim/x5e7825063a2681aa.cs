namespace Nsim
{
    using Encog.ML.Data;
    using Encog.ML.Data.Basic;
    using Encog.ML.Train;
    using Encog.Neural.Networks;
    using MatrixLibrary;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Xml.Linq;

    internal class x5e7825063a2681aa : IConfigurable, xf8efd7615008d32e
    {
        private bool _x2e6053f7333f82f2;
        private xf8efd7615008d32e _x39df08e8a67b5600;
        private BasicNetwork _x87a7fc6a72741c2e;
        private IDataProcessor _x91bd2127cb8b0fed;
        private XElement _xa1c4b4b5f240fa2f;
        private double[] _xc8effc50402e80b5;
        [CompilerGenerated]
        private bool x2f8505cffe976d7b;
        [CompilerGenerated]
        private BasicMLDataSet x51db2148b67c32e9;
        [CompilerGenerated]
        private x35a0e88a31c66173 x858e5dbf7f5d7060;
        [CompilerGenerated]
        private BasicMLDataSet xc99b0d468438a6bb;
        [CompilerGenerated]
        private BasicMLDataSet xd6dd3c4488d3dcad;

        public IList<BasicMLDataPair> FindMavericks(int number, Func<int> method)
        {
            bool flag;
            List<BasicMLDataPair> list = new List<BasicMLDataPair>();
            int num = 0;
        Label_000C:
            flag = num < number;
            if (!flag)
            {
                if ((((uint) flag) | 0x7fffffff) != 0)
                {
                    IList<BasicMLDataPair> list2 = list;
                    if (((uint) num) >= 0)
                    {
                        return list2;
                    }
                    goto Label_0066;
                }
                goto Label_000C;
            }
            int num2 = method.Invoke();
            BasicMLDataPair item = this.x6b73aa01aa019d3a.Data[num2] as BasicMLDataPair;
        Label_0066:
            App.Services.GetService<ITrainData>().x443525895ac957ee(xdbd3571bcaa76e88(this.x6b73aa01aa019d3a, num2));
            list.Add(item);
            num++;
            goto Label_000C;
        }

        private void x03ee1c6d015874ac()
        {
            this.x5b0926ce641e48a7.DecodeFromArray(this._xc8effc50402e80b5);
        }

        private void x0fc00f08bd4749a0()
        {
            this._xc8effc50402e80b5 = new double[this.x5b0926ce641e48a7.EncodedArrayLength()];
            this.x5b0926ce641e48a7.EncodeToArray(this._xc8effc50402e80b5);
        }

        private void x20aee281977480cf()
        {
            bool flag;
            bool flag2 = !this._x2e6053f7333f82f2;
            if (0 == 0)
            {
                if (!flag2 || ((((uint) flag) & 0) != 0))
                {
                    return;
                }
                this._x39df08e8a67b5600 = App.Services.GetService<xf8efd7615008d32e>();
                goto Label_01BC;
            }
        Label_0136:
            this._x91bd2127cb8b0fed = App.Services.GetService<IDataProcessor>();
            this._xa1c4b4b5f240fa2f = this._x91bd2127cb8b0fed.Xml;
            this.x6b73aa01aa019d3a = App.Services.GetService<ITrainData>().xd378208b5267f7e2();
            BasicMLDataSet set = App.Services.GetService<ITestData>().xd378208b5267f7e2();
            flag = set.Count > 0L;
            if ((((uint) flag2) + ((uint) flag2)) >= 0)
            {
                flag2 = !flag;
                if (1 == 0)
                {
                }
            }
            if (!flag2)
            {
                IEnumerator<IMLDataPair> enumerator = set.GetEnumerator();
                try
                {
                    IMLDataPair pair;
                    goto Label_00F7;
                Label_00E0:
                    pair = enumerator.Current;
                    this.x6b73aa01aa019d3a.Add(pair);
                Label_00F7:
                    flag2 = enumerator.MoveNext();
                    if (flag2)
                    {
                        goto Label_00E0;
                    }
                    if ((((uint) flag) & 0) == 0)
                    {
                    }
                }
                finally
                {
                    flag2 = enumerator == null;
                    while (!flag2)
                    {
                        enumerator.Dispose();
                        break;
                    }
                }
            }
            this._x91bd2127cb8b0fed.ConfigureProcessor(this.x6b73aa01aa019d3a);
            this.x6b73aa01aa019d3a = this._x91bd2127cb8b0fed.ProcessDataSet(this.x6b73aa01aa019d3a);
            this.x5b0926ce641e48a7 = App.Services.GetService<INetStruct>().GetNewNetwork();
            App.Services.GetService<IRandomStruct>().GetRandom().Randomize(this.x5b0926ce641e48a7);
            this.x4c7d52ac8aea653f = App.Services.GetService<x35a0e88a31c66173>();
            this._x2e6053f7333f82f2 = true;
            if ((((uint) flag) & 0) == 0)
            {
                return;
            }
        Label_01BC:
            App.Services.RegisterService<xf8efd7615008d32e>(this);
            if (8 == 0)
            {
                return;
            }
            goto Label_0136;
        }

        public void x4ab8973167965816()
        {
            throw new NotImplementedException();
        }

        private Matrix x5416132d843fbf5e(BasicMLDataSet x4a3f0a05c02f235f)
        {
            int num2;
            Matrix matrix2;
            Matrix matrix3;
            bool flag;
            Matrix mat = new Matrix((int) x4a3f0a05c02f235f.Count, x4a3f0a05c02f235f.InputSize);
            int num = 0;
            goto Label_00DB;
        Label_0071:
            return new Matrix(Matrix.Identity((int) this.x6b73aa01aa019d3a.Count));
        Label_00D3:
            if (flag)
            {
                mat[num, num2] = x4a3f0a05c02f235f.Data[num].InputArray[num2];
                num2++;
                if ((((uint) flag) + ((uint) num)) < 0)
                {
                    goto Label_0071;
                }
                goto Label_0130;
            }
            num++;
        Label_00DB:
            flag = num < this.x6b73aa01aa019d3a.Count;
            do
            {
                if (flag)
                {
                    num2 = 0;
                    goto Label_0130;
                }
                matrix2 = Matrix.Transpose(mat);
                matrix3 = matrix2 * mat;
            }
            while ((((uint) num) & 0) != 0);
            if ((((uint) num2) + ((uint) num2)) <= uint.MaxValue)
            {
            Label_0058:
                flag = Matrix.Det(matrix3) != 0.0;
                if (flag)
                {
                    Matrix matrix4 = Matrix.Inverse(matrix3);
                    Matrix matrix5 = (mat * matrix4) * matrix2;
                    if ((((uint) num2) - ((uint) num)) <= uint.MaxValue)
                    {
                        return matrix5;
                    }
                    goto Label_0058;
                }
                goto Label_0071;
            }
            goto Label_00D3;
        Label_0130:
            flag = num2 < x4a3f0a05c02f235f.InputSize;
            goto Label_00D3;
        }

        private void x993b9ddd2c3f1688(int x84b2cef946064aca)
        {
            this.x03ee1c6d015874ac();
            this.xddda66ad7e26f074 = xdbd3571bcaa76e88(this.x6b73aa01aa019d3a, x84b2cef946064aca);
            IMLTrain trainer = App.Services.GetService<ITrainerStruct>().GetTrainer(true);
            trainer.Iteration(this.x4c7d52ac8aea653f.Iterations);
            this.x5b0926ce641e48a7 = trainer.Method as BasicNetwork;
        }

        public int xa1aa8795de6d838b()
        {
            Matrix matrix;
            int num;
            double num2;
            double num3;
            double num4;
            double num5;
            double num6;
            ChartWindow window2;
            Func<double, Tuple<double, bool>> func = null;
            <>c__DisplayClass10 class2;
            int num7;
            bool flag;
            if (((uint) num3) >= 0)
            {
                double mo;
                this.x20aee281977480cf();
                this.x0fc00f08bd4749a0();
                double[] res = new double[this.x6b73aa01aa019d3a.Count];
                goto Label_02AD;
            }
            if ((((uint) num4) - ((uint) num)) >= 0)
            {
                goto Label_007B;
            }
        Label_0030:
            num7 = res.ToList<double>().IndexOf(res.Max());
            if ((((uint) num5) | 4) == 0)
            {
                goto Label_01C5;
            }
            return num7;
        Label_007B:
            if ((((uint) num4) | 0x7fffffff) == 0)
            {
                goto Label_01FF;
            }
            ChartWindow window = window2;
            if (func == null)
            {
                func = new Func<double, Tuple<double, bool>>(class2, this.<FindMavericNsim41>b__e);
            }
            window.barSeries.ItemsSource = Enumerable.Select<double, Tuple<double, bool>>(res, func);
            window.barSeries.IsSelectionEnabled = false;
            window.ShowDialog();
            goto Label_0030;
        Label_017F:
            num6 = res.Max();
            num = 0;
        Label_0197:
            flag = num < res.Length;
        Label_0148:
            if (flag)
            {
                num++;
                goto Label_0197;
            }
            this.xdc3df58d08a8655f();
            if ((((uint) flag) & 0) != 0)
            {
                goto Label_0258;
            }
            flag = !this.xf69244535d02f4b9;
            if (!flag)
            {
                window2 = new ChartWindow {
                    chart = { Title = "Обнаружение выбросов" }
                };
                if ((((uint) num5) & 0) != 0)
                {
                    return num7;
                }
                if (((uint) num6) <= uint.MaxValue)
                {
                    goto Label_007B;
                }
                goto Label_0148;
            }
            if ((((uint) num) - ((uint) num2)) >= 0)
            {
                goto Label_0030;
            }
            return num7;
        Label_01C5:
            num5 = Math.Sqrt(Enumerable.Select<double, double>(res, new Func<double, double>(class2, (IntPtr) this.<FindMavericNsim41>b__d)).Sum() / ((double) res.Length));
            goto Label_017F;
        Label_01FF:
            flag = num < this.x6b73aa01aa019d3a.Count;
            if ((((uint) num) + ((uint) num6)) < 0)
            {
                goto Label_017F;
            }
            if (flag)
            {
                this.x993b9ddd2c3f1688(num);
                BasicMLDataPair inputData = this.x6b73aa01aa019d3a.Data[num].Clone() as BasicMLDataPair;
                BasicMLDataSet data = new BasicMLDataSet();
                data.Add(inputData);
                num2 = this.x5b0926ce641e48a7.CalculateError(data);
            }
            else
            {
                if (0 == 0)
                {
                    mo = res.Sum() / ((double) res.Length);
                    goto Label_01C5;
                }
                goto Label_02AD;
            }
        Label_0258:
            num3 = this.x5b0926ce641e48a7.CalculateError(this.xddda66ad7e26f074);
            num4 = (1.0 / ((double) this.x6b73aa01aa019d3a.Count)) + matrix[num, num];
            res[num] = (num2 * num4) / (1.0 - num4);
            num++;
            goto Label_01FF;
        Label_02AD:
            matrix = this.x5416132d843fbf5e(this.x6b73aa01aa019d3a);
            num = 0;
            goto Label_01FF;
        }

        public int xd73759c200f2f3a3()
        {
            int num;
            double num2;
            int index;
            ChartWindow window2;
            Func<double, Tuple<double, bool>> func = null;
            int num4;
            bool flag;
            if ((((uint) num) + ((uint) num4)) < 0)
            {
                return num4;
            }
            double[] res;
            this.x20aee281977480cf();
            this.x0fc00f08bd4749a0();
            goto Label_021A;
        Label_001E:
            window2 = new ChartWindow();
            if ((((uint) num2) + ((uint) num)) < 0)
            {
                goto Label_00A1;
            }
            window2.chart.Title = "Обнаружение выбросов";
            if (func == null)
            {
                <>c__DisplayClass3 class2;
                func = new Func<double, Tuple<double, bool>>(class2, this.<FindMaverickNsim2>b__1);
            }
            window2.barSeries.ItemsSource = Enumerable.Select<double, Tuple<double, bool>>(res, func);
            window2.barSeries.IsSelectionEnabled = false;
            window2.ShowDialog();
            return index;
        Label_0096:
            if ((0 == 0) && flag)
            {
                return index;
            }
            goto Label_001E;
        Label_00A1:
            this.xdc3df58d08a8655f();
            index = res.ToList<double>().IndexOf(res.Max());
            flag = !this.xf69244535d02f4b9;
            goto Label_0096;
        Label_00EE:
            num++;
        Label_00F3:
            flag = num < res.Length;
        Label_0101:
            if (flag)
            {
                res[num] /= num2;
                goto Label_00EE;
            }
            if ((((uint) num4) - ((uint) num4)) >= 0)
            {
                goto Label_00A1;
            }
            goto Label_0096;
        Label_021A:
            res = new double[this.x6b73aa01aa019d3a.Count];
        Label_01B1:
            this.x993b9ddd2c3f1688(-1);
            if ((((uint) index) + ((uint) num)) < 0)
            {
                goto Label_0101;
            }
            num = 0;
            if ((((uint) num4) - ((uint) index)) >= 0)
            {
                if (((uint) index) <= uint.MaxValue)
                {
                Label_018C:
                    if (num >= this.x6b73aa01aa019d3a.Count)
                    {
                        if (((uint) num2) <= uint.MaxValue)
                        {
                            goto Label_0254;
                        }
                    }
                    else
                    {
                        this.x993b9ddd2c3f1688(num);
                        if ((((uint) index) - ((uint) num2)) > uint.MaxValue)
                        {
                            goto Label_00EE;
                        }
                        res[num] = this.x5b0926ce641e48a7.CalculateError(this.x6b73aa01aa019d3a);
                        num++;
                        goto Label_018C;
                    }
                    goto Label_01B1;
                }
            }
            else
            {
                goto Label_021A;
            }
        Label_0254:
            if ((((uint) num4) | 2) != 0)
            {
                num2 = res.Max();
                num = 0;
                goto Label_00F3;
            }
            goto Label_001E;
        }

        private static BasicMLDataSet xdbd3571bcaa76e88(BasicMLDataSet x4a3f0a05c02f235f, int x35278bfb190677c4)
        {
            BasicMLDataSet set;
            bool flag;
            if (x35278bfb190677c4 >= x4a3f0a05c02f235f.Count)
            {
            }
            goto Label_0046;
            BasicMLDataSet set2 = set;
            if (0xff != 0)
            {
                return set2;
            }
        Label_0019:
            if (!flag)
            {
                return (x4a3f0a05c02f235f.Clone() as BasicMLDataSet);
            }
            set = x4a3f0a05c02f235f.Clone() as BasicMLDataSet;
            set.Data.RemoveAt(x35278bfb190677c4);
        Label_0046:
            flag = (((uint) x35278bfb190677c4) < 0) && (x35278bfb190677c4 >= 0);
            goto Label_0019;
        }

        private void xdc3df58d08a8655f()
        {
            bool flag = this._x2e6053f7333f82f2;
            goto Label_00C4;
        Label_0084:
            App.Services.RegisterService<xf8efd7615008d32e>(this._x39df08e8a67b5600);
            if ((((uint) flag) | 0xff) != 0)
            {
                this._x91bd2127cb8b0fed.Xml = this._xa1c4b4b5f240fa2f;
                if ((((uint) flag) + ((uint) flag)) <= uint.MaxValue)
                {
                    do
                    {
                        this.x6b73aa01aa019d3a = App.Services.GetService<ITrainData>().xd378208b5267f7e2();
                    }
                    while ((((uint) flag) + ((uint) flag)) < 0);
                    GC.Collect();
                    this._x2e6053f7333f82f2 = false;
                }
                return;
            }
            if ((((uint) flag) | 1) != 0)
            {
                goto Label_00C9;
            }
        Label_00C4:
            if (!flag)
            {
                return;
            }
            if (15 != 0)
            {
                goto Label_0084;
            }
        Label_00C9:
            if (3 == 0)
            {
                goto Label_00C4;
            }
            goto Label_0084;
        }

        public int xe53cd3e4075af2b3()
        {
            Matrix matrix;
            int num;
            double num2;
            double num3;
            int index;
            ChartWindow window;
            ChartWindow window2;
            Func<double, Tuple<double, bool>> func = null;
            <>c__DisplayClass9 class2;
            int num5;
            bool flag;
            goto Label_02E9;
        Label_000D:
            window = window2;
            window.ShowDialog();
            goto Label_0021;
        Label_001D:
            if (!flag)
            {
                window2 = new ChartWindow {
                    chart = { Title = "Обнаружение выбросов" }
                };
                goto Label_008B;
            }
        Label_0021:
            num5 = index;
            if ((((uint) num5) - ((uint) num)) >= 0)
            {
                if ((((uint) index) + ((uint) flag)) <= uint.MaxValue)
                {
                    return num5;
                }
                goto Label_01FD;
            }
            if ((((uint) num3) + ((uint) index)) >= 0)
            {
                goto Label_019F;
            }
            if (((uint) num) >= 0)
            {
                goto Label_0111;
            }
            goto Label_001D;
        Label_008B:
            if (func == null)
            {
                func = new Func<double, Tuple<double, bool>>(class2, this.<FindMavericNsim42>b__7);
            }
            window2.barSeries.ItemsSource = Enumerable.Select<double, Tuple<double, bool>>(class2.res, func);
            window2.barSeries.IsSelectionEnabled = false;
            if ((((uint) num) + ((uint) num)) >= 0)
            {
                if ((((uint) num2) + ((uint) num5)) <= uint.MaxValue)
                {
                    goto Label_000D;
                }
                goto Label_019F;
            }
            if (((((uint) num) + ((uint) index)) > uint.MaxValue) && (((uint) num) >= 0))
            {
                goto Label_015B;
            }
        Label_0111:
            if (num >= class2.res.Length)
            {
                this.xdc3df58d08a8655f();
                index = class2.res.ToList<double>().IndexOf(class2.res.Max());
                flag = !this.xf69244535d02f4b9;
                if (2 != 0)
                {
                    goto Label_001D;
                }
            }
        Label_015B:
            class2.res[num] /= num3;
            num++;
            goto Label_0111;
        Label_019F:
            if ((((uint) flag) - ((uint) num5)) > uint.MaxValue)
            {
                goto Label_008B;
            }
            if (((uint) num3) <= uint.MaxValue)
            {
                goto Label_0111;
            }
            goto Label_000D;
        Label_01FD:
            num++;
        Label_0202:
            flag = num < this.x6b73aa01aa019d3a.Count;
            if ((((uint) flag) + ((uint) num3)) > uint.MaxValue)
            {
                goto Label_02F7;
            }
            if (((((uint) num5) | uint.MaxValue) == 0) || !flag)
            {
                num3 = class2.res.Max();
                num = 0;
                goto Label_019F;
            }
            this.x993b9ddd2c3f1688(num);
            BasicMLDataSet data = new BasicMLDataSet();
            data.Add(this.x6b73aa01aa019d3a.Data[num].Clone() as BasicMLDataPair);
            num2 = this.x5b0926ce641e48a7.CalculateError(data);
            class2.res[num] = num2 / matrix[num, num];
            if ((((uint) num5) & 0) == 0)
            {
                goto Label_01FD;
            }
        Label_02E9:
            class2 = new <>c__DisplayClass9();
            this.x20aee281977480cf();
        Label_02F7:
            this.x0fc00f08bd4749a0();
            class2.res = new double[this.x6b73aa01aa019d3a.Count];
            matrix = this.x5416132d843fbf5e(this.x6b73aa01aa019d3a);
            do
            {
                if ((((uint) num3) + ((uint) num5)) > uint.MaxValue)
                {
                    break;
                }
                this.x993b9ddd2c3f1688(-1);
            }
            while ((((uint) index) | 0xfffffffe) == 0);
            num = 0;
            if (3 != 0)
            {
                if ((((uint) num) + ((uint) index)) >= 0)
                {
                    goto Label_0202;
                }
                goto Label_01FD;
            }
            goto Label_02E9;
        }

        protected x35a0e88a31c66173 x4c7d52ac8aea653f
        {
            [CompilerGenerated]
            get
            {
                return this.x858e5dbf7f5d7060;
            }
            [CompilerGenerated]
            set
            {
                this.x858e5dbf7f5d7060 = value;
            }
        }

        public BasicNetwork x5b0926ce641e48a7
        {
            get
            {
                return this._x87a7fc6a72741c2e;
            }
            private set
            {
                this._x87a7fc6a72741c2e = value;
            }
        }

        protected BasicMLDataSet x6b73aa01aa019d3a
        {
            [CompilerGenerated]
            get
            {
                return this.x51db2148b67c32e9;
            }
            [CompilerGenerated]
            set
            {
                this.x51db2148b67c32e9 = value;
            }
        }

        protected BasicMLDataSet xba3f69312586b31e
        {
            [CompilerGenerated]
            get
            {
                return this.xd6dd3c4488d3dcad;
            }
            [CompilerGenerated]
            set
            {
                this.xd6dd3c4488d3dcad = value;
            }
        }

        public BasicMLDataSet xddda66ad7e26f074
        {
            [CompilerGenerated]
            get
            {
                return this.xc99b0d468438a6bb;
            }
            [CompilerGenerated]
            private set
            {
                this.xc99b0d468438a6bb = value;
            }
        }

        public bool xf69244535d02f4b9
        {
            [CompilerGenerated]
            get
            {
                return this.x2f8505cffe976d7b;
            }
            [CompilerGenerated]
            set
            {
                this.x2f8505cffe976d7b = value;
            }
        }

        public XElement Xml
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}

