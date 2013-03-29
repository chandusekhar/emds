namespace Nsim
{
    using Encog.ML.Data;
    using Encog.ML.Data.Basic;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Xml.Linq;

    public class LinearScale : IConfigurable, IDataProcessor
    {
        [CompilerGenerated]
        private ScalerC[] x1354156a0ae60345;
        [CompilerGenerated]
        private static Func<XElement, ScalerC> x3ea1037ccf291a94;
        [CompilerGenerated]
        private ScalerC[] x7e741eb651115f7d;
        [CompilerGenerated]
        private bool xb3e9a1b14f5cda01;
        [CompilerGenerated]
        private double xe8059612d0ae5fdd;
        [CompilerGenerated]
        private static Func<XElement, ScalerC> xec790bb6d0304faa;
        [CompilerGenerated]
        private double xfafd8678a0ce65f2;

        public LinearScale()
        {
            this.A = -1.0;
            this.B = 1.0;
            this.IsUsed = true;
        }

        public void ConfigureProcessor(BasicMLDataSet dataSet)
        {
            IMLDataPair[] pairArray;
            int num;
            double num2;
            int num3;
            double num4;
            int num5;
            bool flag;
            this.InC = new ScalerC[dataSet.InputSize];
            goto Label_06B9;
        Label_0017:
            if (flag)
            {
                num2 = pairArray[0].IdealArray[num5];
                goto Label_033D;
            }
            if ((((uint) num) | uint.MaxValue) != 0)
            {
                if ((((uint) num3) | 0x7fffffff) != 0)
                {
                    return;
                }
                goto Label_06B9;
            }
            goto Label_00D3;
        Label_00A8:
            num5++;
        Label_00AF:
            flag = num5 < dataSet.IdealSize;
            if ((((uint) num5) + ((uint) num)) <= uint.MaxValue)
            {
                goto Label_0017;
            }
        Label_00D3:
            if (!flag)
            {
                flag = !num4.Equals((double) 0.0);
                if (!flag)
                {
                    this.OutC[num5].D = 1.0;
                    if ((((uint) num2) | 4) == 0)
                    {
                        goto Label_0400;
                    }
                    if (((uint) num2) >= 0)
                    {
                        goto Label_015E;
                    }
                }
                this.OutC[num5].D = this.B / num4;
                if (((uint) flag) >= 0)
                {
                    if ((((uint) num3) + ((uint) num)) <= uint.MaxValue)
                    {
                        if (((((uint) num5) - ((uint) num5)) <= uint.MaxValue) && ((((uint) num) & 0) != 0))
                        {
                            goto Label_063E;
                        }
                        this.OutC[num5].C = (this.B - this.A) / 2.0;
                        goto Label_00A8;
                    }
                    if (((uint) num3) <= uint.MaxValue)
                    {
                        goto Label_0399;
                    }
                    goto Label_036C;
                }
                goto Label_0286;
            }
            this.OutC[num5].D = (this.B - this.A) / (num4 - num2);
            this.OutC[num5].C = 1.0 * (((num2 * (this.B - this.A)) / (num4 - num2)) - this.A);
            if ((((uint) num) & 0) != 0)
            {
                goto Label_0286;
            }
            if ((((uint) num3) - ((uint) num3)) > uint.MaxValue)
            {
                goto Label_0399;
            }
            goto Label_00A8;
        Label_015E:
            this.OutC[num5].C = 0.0;
            goto Label_00A8;
        Label_0224:
            num3++;
        Label_0228:
            if (num3 >= pairArray.Count<IMLDataPair>())
            {
                flag = !num2.Equals(num4);
            }
            else
            {
                flag = pairArray[num3].IdealArray[num5] <= num4;
                if (flag)
                {
                    goto Label_0224;
                }
                num4 = pairArray[num3].IdealArray[num5];
                if ((((uint) flag) + ((uint) num2)) >= 0)
                {
                    goto Label_0224;
                }
            }
            if ((((uint) flag) - ((uint) num3)) <= uint.MaxValue)
            {
                goto Label_00D3;
            }
            goto Label_015E;
        Label_0286:
            if (num3 < pairArray.Count<IMLDataPair>())
            {
                flag = pairArray[num3].IdealArray[num5] >= num2;
                if (!flag)
                {
                    num2 = pairArray[num3].IdealArray[num5];
                }
                num3++;
                if ((((uint) flag) - ((uint) num5)) <= uint.MaxValue)
                {
                    goto Label_0286;
                }
            }
            else
            {
                num4 = pairArray[0].IdealArray[num5];
                num3 = 0;
                goto Label_0228;
            }
        Label_033D:
            num3 = 0;
            goto Label_0286;
        Label_0361:
            if (flag)
            {
                num2 = pairArray[0].InputArray[num];
                num3 = 0;
                goto Label_05C4;
            }
            num5 = 0;
            goto Label_00AF;
        Label_036C:
            this.InC[num].C = ((num2 * (this.B - this.A)) / (num4 - num2)) - this.A;
        Label_0399:
            num++;
        Label_039E:
            flag = num < dataSet.InputSize;
            goto Label_0361;
        Label_0400:
            if (!flag)
            {
                goto Label_04AF;
            }
            this.InC[num].D = this.B / num4;
            if (0 != 0)
            {
                goto Label_04CA;
            }
            this.InC[num].C = (this.B - this.A) / 2.0;
            goto Label_0399;
        Label_0484:
            flag = !num4.Equals((double) 0.0);
            if (((uint) num) <= uint.MaxValue)
            {
                goto Label_0400;
            }
        Label_04AF:
            this.InC[num].D = 1.0;
        Label_04CA:
            this.InC[num].C = 0.0;
            goto Label_0399;
        Label_0542:
            flag = pairArray[num3].InputArray[num] <= num4;
            if (!flag)
            {
                if (((uint) num2) > uint.MaxValue)
                {
                    goto Label_0017;
                }
                num4 = pairArray[num3].InputArray[num];
            }
            num3++;
        Label_057E:
            flag = num3 < pairArray.Count<IMLDataPair>();
            if ((((uint) num3) + ((uint) flag)) >= 0)
            {
                if (flag)
                {
                    goto Label_0542;
                }
                if ((((uint) num3) - ((uint) flag)) < 0)
                {
                    goto Label_0361;
                }
                flag = !num2.Equals(num4);
                if (!flag)
                {
                    goto Label_0484;
                }
                if ((((uint) num) - ((uint) num2)) < 0)
                {
                    goto Label_05A5;
                }
                this.InC[num].D = (this.B - this.A) / (num4 - num2);
                if (0 == 0)
                {
                    goto Label_036C;
                }
                goto Label_0399;
            }
            return;
        Label_0592:
            num4 = pairArray[0].InputArray[num];
            num3 = 0;
            goto Label_057E;
        Label_05A5:
            num3++;
            if ((((uint) num4) | 2) == 0)
            {
                goto Label_0484;
            }
        Label_05C4:
            flag = num3 < pairArray.Count<IMLDataPair>();
            if ((((uint) num) | 1) == 0)
            {
                goto Label_0542;
            }
            if ((((uint) num) - ((uint) num4)) < 0)
            {
                goto Label_057E;
            }
            if (flag)
            {
                flag = pairArray[num3].InputArray[num] >= num2;
            }
            else
            {
                if ((((uint) flag) + ((uint) flag)) <= uint.MaxValue)
                {
                    goto Label_0592;
                }
                if ((((uint) num3) + ((uint) num3)) >= 0)
                {
                    goto Label_0678;
                }
                goto Label_05A5;
            }
        Label_063E:
            if (!flag)
            {
                num2 = pairArray[num3].InputArray[num];
                if ((((uint) num) | 0x80000000) != 0)
                {
                    goto Label_05A5;
                }
            }
            if ((((uint) num2) + ((uint) num2)) <= uint.MaxValue)
            {
                goto Label_05A5;
            }
            goto Label_0592;
        Label_0678:
            num = 0;
            goto Label_039E;
        Label_06B9:
            this.OutC = new ScalerC[dataSet.IdealSize];
            pairArray = dataSet.ToArray<IMLDataPair>();
            goto Label_0678;
        }

        public BasicMLDataSet ProcessDataSet(BasicMLDataSet dataToProcess)
        {
            bool flag;
            BasicMLDataSet set = new BasicMLDataSet();
            IEnumerator<IMLDataPair> enumerator = dataToProcess.GetEnumerator();
            try
            {
                IMLDataPair pair;
                goto Label_003E;
            Label_0011:
                pair = enumerator.Current;
                set.Add(new BasicMLDataPair(this.ProcessInputVector(pair.Input), this.ProcessIdealVector(pair.Ideal)));
            Label_003E:
                flag = enumerator.MoveNext();
                if (flag)
                {
                    goto Label_0011;
                }
                if ((((uint) flag) - ((uint) flag)) < 0)
                {
                    goto Label_003E;
                }
            }
            finally
            {
                flag = enumerator == null;
                goto Label_0089;
            Label_006C:
                enumerator.Dispose();
                if ((((uint) flag) & 0) != 0)
                {
                    goto Label_006C;
                }
                goto Label_008D;
            Label_0089:
                if (!flag)
                {
                    goto Label_006C;
                }
            Label_008D:;
            }
            return set;
        }

        public IMLDataPair ProcessDataVector(IMLDataPair vectorToProcess)
        {
            return new BasicMLDataPair(this.ProcessInputVector(vectorToProcess.Input), this.ProcessIdealVector(vectorToProcess.Ideal));
        }

        public IMLData ProcessIdealVector(IMLData row)
        {
            BasicMLData data = new BasicMLData(row.Count);
            int num = 0;
            while (num < row.Count)
            {
                bool flag;
                data[num] = this.x7ca854d9be2e6e12(row[num], num);
                if ((((uint) flag) - ((uint) num)) > uint.MaxValue)
                {
                    break;
                }
                num++;
            }
            IMLData data2 = data;
            if ((((uint) num) & 0) != 0)
            {
            }
            return data2;
        }

        public IMLData ProcessInputVector(IMLData row)
        {
            int num;
            bool flag;
            BasicMLData data = new BasicMLData(row.Count);
            if ((((uint) num) - ((uint) flag)) >= 0)
            {
                num = 0;
            }
            while (true)
            {
                flag = num < row.Count;
                if (flag)
                {
                    data[num] = this.xeffafd493ff94c71(row[num], num);
                }
                else
                {
                    IMLData data2 = data;
                    if ((((uint) num) + ((uint) flag)) < 0)
                    {
                    }
                    return data2;
                }
                num++;
            }
        }

        public BasicMLDataSet RestoreDataSet(BasicMLDataSet dataToProcess)
        {
            BasicMLDataSet set = new BasicMLDataSet();
            using (IEnumerator<IMLDataPair> enumerator = dataToProcess.GetEnumerator())
            {
                IMLDataPair pair;
                bool flag;
                goto Label_0026;
            Label_0011:
                pair = enumerator.Current;
                set.Add(this.RestoreDataVector(pair));
            Label_0026:
                flag = enumerator.MoveNext();
                if (3 == 0)
                {
                    goto Label_0026;
                }
                if (flag)
                {
                    goto Label_0011;
                }
            }
            return set;
        }

        public IMLDataPair RestoreDataVector(IMLDataPair vectorToProcess)
        {
            return new BasicMLDataPair(this.RestoreInputVector(vectorToProcess.Input), this.RestoreIdealVector(vectorToProcess.Ideal));
        }

        public IMLData RestoreIdealVector(IMLData row)
        {
            BasicMLData data = new BasicMLData(row.Count);
            for (int i = 0; i < row.Count; i++)
            {
                data[i] = this.x06732b07a8898f0c(row[i], i);
            }
            return data;
        }

        public IMLData RestoreInputVector(IMLData row)
        {
            IMLData data2;
            BasicMLData data = new BasicMLData(row.Count);
            for (int i = 0; i < row.Count; i++)
            {
                data[i] = this.x216ca410910e9fbf(row[i], i);
            }
            if (0 == 0)
            {
                data2 = data;
            }
            return data2;
        }

        private double x06732b07a8898f0c(double xbcea506a33cf9111, int xc0c4c459c6ccbd00)
        {
            try
            {
                ScalerC rc = this.OutC[xc0c4c459c6ccbd00];
                return ((xbcea506a33cf9111 + rc.C) / rc.D);
            }
            catch (Exception)
            {
                return xbcea506a33cf9111;
            }
        }

        private double x216ca410910e9fbf(double xbcea506a33cf9111, int xc0c4c459c6ccbd00)
        {
            try
            {
                ScalerC rc = this.InC[xc0c4c459c6ccbd00];
                return ((xbcea506a33cf9111 + rc.C) / rc.D);
            }
            catch (Exception)
            {
                return xbcea506a33cf9111;
            }
        }

        [CompilerGenerated]
        private static ScalerC x716bafe7619d8264(XElement x4bbc2c453c470189)
        {
            return new ScalerC { C = x4bbc2c453c470189.Attribute("C").AsDouble(0.0), D = x4bbc2c453c470189.Attribute("D").AsDouble(0.0) };
        }

        private double x7ca854d9be2e6e12(double xbcea506a33cf9111, int xc0c4c459c6ccbd00)
        {
            try
            {
                ScalerC rc = this.OutC[xc0c4c459c6ccbd00];
                return ((xbcea506a33cf9111 * rc.D) - rc.C);
            }
            catch (Exception)
            {
                return xbcea506a33cf9111;
            }
        }

        [CompilerGenerated]
        private static ScalerC xad1d75c4f41a1f7d(XElement x4bbc2c453c470189)
        {
            return new ScalerC { C = x4bbc2c453c470189.Attribute("C").AsDouble(0.0), D = x4bbc2c453c470189.Attribute("D").AsDouble(0.0) };
        }

        private double xeffafd493ff94c71(double xbcea506a33cf9111, int xc0c4c459c6ccbd00)
        {
            try
            {
                ScalerC rc = this.InC[xc0c4c459c6ccbd00];
                return ((xbcea506a33cf9111 * rc.D) - rc.C);
            }
            catch (Exception)
            {
                return xbcea506a33cf9111;
            }
        }

        public double A
        {
            [CompilerGenerated]
            get
            {
                return this.xe8059612d0ae5fdd;
            }
            [CompilerGenerated]
            set
            {
                this.xe8059612d0ae5fdd = value;
            }
        }

        public double B
        {
            [CompilerGenerated]
            get
            {
                return this.xfafd8678a0ce65f2;
            }
            [CompilerGenerated]
            set
            {
                this.xfafd8678a0ce65f2 = value;
            }
        }

        public ScalerC[] InC
        {
            [CompilerGenerated]
            get
            {
                return this.x1354156a0ae60345;
            }
            [CompilerGenerated]
            private set
            {
                this.x1354156a0ae60345 = value;
            }
        }

        public bool IsUsed
        {
            [CompilerGenerated]
            get
            {
                return this.xb3e9a1b14f5cda01;
            }
            [CompilerGenerated]
            set
            {
                this.xb3e9a1b14f5cda01 = value;
            }
        }

        public ScalerC[] OutC
        {
            [CompilerGenerated]
            get
            {
                return this.x7e741eb651115f7d;
            }
            [CompilerGenerated]
            private set
            {
                this.x7e741eb651115f7d = value;
            }
        }

        public XElement Xml
        {
            get
            {
                bool flag;
                ScalerC[] outC;
                int num;
                XElement element = new XElement("DataProcessor", new object[] { new XAttribute("Type", "LinearScale"), this.x289fcfc6ab32371c(), new XAttribute("A", this.A), new XAttribute("B", this.B) });
                goto Label_01F5;
            Label_0086:
                if (-2147483648 == 0)
                {
                    goto Label_0191;
                }
            Label_0090:
                flag = num < outC.Length;
                if (!flag)
                {
                    return element;
                }
                ScalerC rc = outC[num];
                element.Add(new XElement("OutC", new object[] { new XAttribute("C", rc.C), new XAttribute("D", rc.D) }));
                num++;
                if (0 == 0)
                {
                    if ((((uint) flag) + ((uint) num)) >= 0)
                    {
                        goto Label_0086;
                    }
                    goto Label_01F5;
                }
                goto Label_013E;
            Label_011D:
                flag = this.OutC == null;
                if (!flag)
                {
                    outC = this.OutC;
                    num = 0;
                    goto Label_0090;
                }
                return element;
            Label_013E:
                if ((((uint) num) & 0) != 0)
                {
                    goto Label_0086;
                }
            Label_0155:
                if (num < outC.Length)
                {
                    rc = outC[num];
                }
                else
                {
                    goto Label_011D;
                }
            Label_0191:;
                element.Add(new XElement("InC", new object[] { new XAttribute("C", rc.C), new XAttribute("D", rc.D) }));
                num++;
                if ((((uint) num) | 1) != 0)
                {
                    goto Label_013E;
                }
                goto Label_0086;
            Label_01F5:
                flag = this.InC == null;
                if (!flag)
                {
                    outC = this.InC;
                    num = 0;
                    goto Label_0155;
                }
                goto Label_011D;
            }
            set
            {
                bool flag;
                this.IsUsed = value.xa14291458369dcd9();
                goto Label_0109;
            Label_0012:
                if (flag)
                {
                    return;
                }
            Label_004E:
                if (xec790bb6d0304faa == null)
                {
                    xec790bb6d0304faa = new Func<XElement, ScalerC>(null, (IntPtr) x716bafe7619d8264);
                }
                this.OutC = Enumerable.Select<XElement, ScalerC>(value.Elements("OutC"), xec790bb6d0304faa).ToArray<ScalerC>();
                goto Label_00E5;
            Label_008F:
                this.OutC = null;
                flag = value.Elements("OutC").Count<XElement>() <= 0;
                if (15 != 0)
                {
                    if ((((uint) flag) + ((uint) flag)) >= 0)
                    {
                        if (0 == 0)
                        {
                            goto Label_0012;
                        }
                        goto Label_004E;
                    }
                    goto Label_00E5;
                }
            Label_00BD:
                if (0 == 0)
                {
                    goto Label_008F;
                }
            Label_00C2:
                if (!flag)
                {
                    if (x3ea1037ccf291a94 == null)
                    {
                        x3ea1037ccf291a94 = new Func<XElement, ScalerC>(null, (IntPtr) xad1d75c4f41a1f7d);
                    }
                    this.InC = Enumerable.Select<XElement, ScalerC>(value.Elements("InC"), x3ea1037ccf291a94).ToArray<ScalerC>();
                    if (0 != 0)
                    {
                        return;
                    }
                    goto Label_00BD;
                }
                goto Label_008F;
            Label_00E5:
                if (((uint) flag) <= uint.MaxValue)
                {
                    while (true)
                    {
                        if (0 != 0)
                        {
                            goto Label_00BD;
                        }
                        if ((((uint) flag) - ((uint) flag)) > uint.MaxValue)
                        {
                            break;
                        }
                        if (-2 != 0)
                        {
                            if (3 != 0)
                            {
                                return;
                            }
                            goto Label_0109;
                        }
                        if (0 == 0)
                        {
                            goto Label_00BD;
                        }
                    }
                }
                goto Label_0012;
            Label_0109:
                this.A = value.DoubleAttribute("A", this.A);
                this.B = value.DoubleAttribute("B", this.B);
                this.InC = null;
                flag = value.Elements("InC").Count<XElement>() <= 0;
                goto Label_00C2;
            }
        }
    }
}

