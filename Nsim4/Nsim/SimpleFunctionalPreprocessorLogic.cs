namespace Nsim
{
    using Encog.ML.Data;
    using Encog.ML.Data.Basic;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Xml.Linq;

    public class SimpleFunctionalPreprocessorLogic : FunctionalPreprocessorBase, IConfigurable, IDataProcessor
    {
        public int[] Optc;
        [CompilerGenerated]
        private static Func<XElement, int> x66406001675ff321;
        [CompilerGenerated]
        private CorrelationSelector x6d0372bf32d0b518;
        [CompilerGenerated]
        private bool xb3e9a1b14f5cda01;

        public SimpleFunctionalPreprocessorLogic()
        {
            this.CorrelationSelectMode = CorrelationSelector.Mean;
        }

        public void ConfigureProcessor(BasicMLDataSet data)
        {
            int num;
            int num2;
            int num3;
            int num4;
            double num5;
            double[] numArray2;
            int[] numArray3;
            int num6;
            int num7;
            bool flag;
            this.Optc = new int[data.InputSize];
            if ((((uint) num7) + ((uint) flag)) < 0)
            {
                goto Label_028E;
            }
            double[,,] numArray = new double[data.InputSize, data.IdealSize, FunctionalPreprocessorBase.FunctionsCount];
            goto Label_0780;
        Label_0017:
            if (num2 < data.InputSize)
            {
                numArray3 = new int[FunctionalPreprocessorBase.FunctionsCount];
                num3 = 0;
                goto Label_0141;
            }
            return;
        Label_006A:
            flag = num < FunctionalPreprocessorBase.FunctionsCount;
            if (flag)
            {
                flag = numArray3[num] <= num7;
                if (((((uint) num4) - ((uint) num6)) >= 0) && flag)
                {
                    if (((uint) num6) >= 0)
                    {
                        goto Label_008F;
                    }
                    goto Label_0135;
                }
                goto Label_00C8;
            }
            this.Optc[num2] = num6;
            num2++;
            if (0 != 0)
            {
                goto Label_04CD;
            }
            if ((((uint) num6) | 15) == 0)
            {
                goto Label_0652;
            }
            if (((uint) flag) >= 0)
            {
                goto Label_0017;
            }
            return;
        Label_008F:
            if ((((uint) num7) & 0) != 0)
            {
                goto Label_059D;
            }
        Label_00A6:
            num++;
            goto Label_006A;
        Label_00C8:
            num7 = numArray3[num];
            num6 = num;
            goto Label_00A6;
        Label_0114:
            num6 = 0;
            num7 = numArray3[0];
            num = 0;
            goto Label_006A;
        Label_0135:
            while (flag)
            {
                flag = numArray[num2, num3, num] <= num5;
                if (flag)
                {
                    goto Label_016B;
                }
                if (((uint) num7) >= 0)
                {
                    if ((((uint) flag) - ((uint) flag)) > uint.MaxValue)
                    {
                        goto Label_0611;
                    }
                    num5 = numArray[num2, num3, num];
                    num4 = num;
                    goto Label_016B;
                }
            }
            num3++;
        Label_0141:
            flag = num3 < data.IdealSize;
            if (0 != 0)
            {
                goto Label_06EA;
            }
            if (flag)
            {
                num4 = 0;
                num5 = numArray[num2, num3, 0];
                num = 0;
                goto Label_0186;
            }
            goto Label_0114;
        Label_016B:
            numArray3[num4]++;
            num++;
        Label_0186:
            flag = num < FunctionalPreprocessorBase.FunctionsCount;
            if (((uint) num7) > uint.MaxValue)
            {
                goto Label_04D8;
            }
            goto Label_0135;
        Label_021B:
            if ((((uint) num6) | 0xff) == 0)
            {
                goto Label_0780;
            }
        Label_0236:
            num2 = 0;
            goto Label_0017;
        Label_0283:
            flag = num2 < data.InputSize;
        Label_028E:
            if (flag)
            {
                numArray2 = new double[FunctionalPreprocessorBase.FunctionsCount];
                num = 0;
                if ((((uint) num2) | 1) != 0)
                {
                }
                goto Label_0383;
            }
            if ((((uint) flag) - ((uint) num4)) < 0)
            {
                goto Label_00C8;
            }
        Label_02B1:
            flag = this.CorrelationSelectMode != CorrelationSelector.Vote;
            if (((uint) num) >= 0)
            {
                if ((((uint) num5) + ((uint) num5)) <= uint.MaxValue)
                {
                    if (!flag)
                    {
                        goto Label_0236;
                    }
                    if (((uint) num4) <= uint.MaxValue)
                    {
                        return;
                    }
                    goto Label_008F;
                }
                goto Label_021B;
            }
        Label_02D1:
            num2++;
            if (((uint) num7) > uint.MaxValue)
            {
                goto Label_03D3;
            }
            if ((((uint) num6) + ((uint) num)) > uint.MaxValue)
            {
                goto Label_0784;
            }
            goto Label_0283;
        Label_02F7:
            flag = num < FunctionalPreprocessorBase.FunctionsCount;
        Label_0301:
            if (flag)
            {
                flag = numArray2[num] <= num5;
            }
            else
            {
                this.Optc[num2] = num4;
                if (((uint) flag) >= 0)
                {
                    goto Label_02D1;
                }
                goto Label_021B;
            }
        Label_0328:
            if (!flag)
            {
                num5 = numArray2[num];
                num4 = num;
                if ((((uint) num4) - ((uint) num5)) > uint.MaxValue)
                {
                    goto Label_0301;
                }
                goto Label_03D3;
            }
        Label_032C:
            num++;
            goto Label_03E8;
        Label_0383:
            flag = num < FunctionalPreprocessorBase.FunctionsCount;
            if (flag)
            {
                num3 = 0;
            }
            else
            {
                num5 = numArray2[0];
                num4 = 0;
                num = 0;
                goto Label_02F7;
            }
        Label_03BE:
            flag = num3 < data.IdealSize;
            if (flag)
            {
                numArray2[num] += numArray[num2, num3, num];
                num3++;
                goto Label_03BE;
            }
            num++;
            goto Label_0383;
        Label_03D3:
            if (((uint) num2) <= uint.MaxValue)
            {
                goto Label_032C;
            }
        Label_03E8:
            if ((((uint) num4) + ((uint) num5)) >= 0)
            {
                if (4 != 0)
                {
                    if ((((uint) num3) + ((uint) num2)) >= 0)
                    {
                        goto Label_02F7;
                    }
                    goto Label_021B;
                }
                goto Label_071B;
            }
            if ((((uint) num4) & 0) == 0)
            {
                goto Label_05E4;
            }
            goto Label_04EA;
        Label_0461:
            if (!flag)
            {
                num2 = 0;
                if ((((uint) num3) - ((uint) num6)) > uint.MaxValue)
                {
                    goto Label_06BB;
                }
                if (((uint) num5) >= 0)
                {
                    goto Label_04B8;
                }
                goto Label_05E4;
            }
        Label_0468:
            flag = this.CorrelationSelectMode != CorrelationSelector.Mean;
            if ((((uint) num2) + ((uint) num5)) < 0)
            {
                goto Label_0780;
            }
            if (flag)
            {
                goto Label_02B1;
            }
            num2 = 0;
            goto Label_0283;
        Label_04B8:
            flag = num2 < data.InputSize;
            if (flag)
            {
                num4 = 0;
                if ((((uint) flag) | 0xfffffffe) == 0)
                {
                    goto Label_032C;
                }
                goto Label_059D;
            }
            if (((uint) flag) >= 0)
            {
                if ((((uint) num5) & 0) == 0)
                {
                    goto Label_0468;
                }
                goto Label_0461;
            }
            goto Label_04EA;
        Label_04CD:
            if (!flag)
            {
                goto Label_055E;
            }
        Label_04D4:
            num++;
        Label_04D8:
            if (num < FunctionalPreprocessorBase.FunctionsCount)
            {
                flag = numArray[num2, num3, num] <= num5;
                if ((((uint) flag) & 0) == 0)
                {
                    goto Label_04CD;
                }
                goto Label_055E;
            }
            num3++;
        Label_04EA:
            flag = num3 < data.IdealSize;
            if (flag)
            {
                num = 0;
                goto Label_04D8;
            }
            this.Optc[num2] = num4;
            num2++;
            goto Label_04B8;
        Label_055E:
            num5 = numArray[num2, num3, num];
            num4 = num;
            if ((((uint) num3) + ((uint) num4)) > uint.MaxValue)
            {
                goto Label_0328;
            }
            goto Label_04D4;
        Label_059D:
            num5 = numArray[num2, 0, 0];
            num3 = 0;
            goto Label_04EA;
        Label_05E4:
            if ((((uint) flag) | 3) == 0)
            {
                goto Label_0135;
            }
        Label_05FF:
            if (num2 < data.InputSize)
            {
                num3 = 0;
                goto Label_0652;
            }
        Label_0611:
            flag = this.CorrelationSelectMode != CorrelationSelector.Max;
            if (((uint) num) <= uint.MaxValue)
            {
                goto Label_0461;
            }
            goto Label_04B8;
        Label_0652:
            flag = num3 < data.IdealSize;
            if (flag)
            {
                num = 0;
            }
            else
            {
                num2++;
                goto Label_05E4;
            }
        Label_06BB:
            flag = num < FunctionalPreprocessorBase.FunctionsCount;
            if ((((uint) num3) + ((uint) num6)) >= 0)
            {
                if (0 == 0)
                {
                    do
                    {
                        if (flag)
                        {
                            goto Label_06EA;
                        }
                    }
                    while ((((uint) num6) - ((uint) num3)) > uint.MaxValue);
                    num3++;
                }
                goto Label_0652;
            }
            goto Label_071B;
        Label_06EA:
            numArray[num2, num3, num] = this.xc673bdb68956bba8(data, FunctionalPreprocessorBase.Functions[num], num2, num3);
            if ((((uint) num2) | 15) != 0)
            {
                if ((0x7fffffff != 0) && ((((uint) num) + ((uint) num3)) < 0))
                {
                    goto Label_0114;
                }
                num++;
                goto Label_06BB;
            }
        Label_071B:
            num++;
        Label_071F:
            if (num < this.Optc.Length)
            {
                goto Label_0784;
            }
            num2 = 0;
            goto Label_05FF;
        Label_0780:
            num = 0;
            goto Label_071F;
        Label_0784:
            this.Optc[num] = 0;
            goto Label_071B;
        }

        public string DecodeC()
        {
            <>c__DisplayClass5 class2;
            if (8 != 0)
            {
            }
            string str = string.Empty;
            return Enumerable.Aggregate<int, string>(this.Optc, str, new Func<string, int, string>(class2, (IntPtr) this.<DecodeC>b__4));
        }

        public BasicMLDataSet ProcessDataSet(BasicMLDataSet dataToProcess)
        {
            bool flag;
            BasicMLDataSet set = new BasicMLDataSet();
            IEnumerator<IMLDataPair> enumerator = dataToProcess.GetEnumerator();
            try
            {
                IMLDataPair pair;
                goto Label_0026;
            Label_0011:
                pair = enumerator.Current;
                set.Add(this.ProcessDataVector(pair));
            Label_0026:
                flag = enumerator.MoveNext();
                do
                {
                    if (flag)
                    {
                        goto Label_0011;
                    }
                }
                while (4 == 0);
            }
            finally
            {
                flag = enumerator == null;
                while (!flag)
                {
                    enumerator.Dispose();
                    goto Label_0057;
                }
                if (2 != 0)
                {
                }
            Label_0057:;
            }
            return set;
        }

        public IMLDataPair ProcessDataVector(IMLDataPair vectorToProcess)
        {
            int num;
            bool flag;
            BasicMLData input = new BasicMLData(vectorToProcess.Input.Count);
            if ((((uint) flag) - ((uint) num)) >= 0)
            {
                num = 0;
                goto Label_0061;
            }
        Label_0023:
            if (flag)
            {
                input[num] = this.x5d3a1f6283012a22(num, vectorToProcess.InputArray[num]);
                num++;
            }
            else
            {
                return new BasicMLDataPair(input, vectorToProcess.Ideal);
            }
        Label_0061:
            flag = num < vectorToProcess.Input.Count;
            goto Label_0023;
        }

        public IMLData ProcessIdealVector(IMLData row)
        {
            return row;
        }

        public IMLData ProcessInputVector(IMLData row)
        {
            bool flag;
            BasicMLData data = new BasicMLData(row.Count);
            int num = 0;
        Label_000F:
            flag = num < row.Count;
            if (0 != 0)
            {
                goto Label_000F;
            }
            if (flag)
            {
                data[num] = this.x5d3a1f6283012a22(num, row[num]);
                num++;
                if (-2147483648 == 0)
                {
                    IMLData data2;
                    return data2;
                }
                goto Label_000F;
            }
            return data;
        }

        public BasicMLDataSet RestoreDataSet(BasicMLDataSet dataToProcess)
        {
            throw new NotImplementedException();
        }

        public IMLDataPair RestoreDataVector(IMLDataPair vectorToProcess)
        {
            throw new NotImplementedException();
        }

        public IMLData RestoreIdealVector(IMLData row)
        {
            return row;
        }

        public IMLData RestoreInputVector(IMLData row)
        {
            throw new NotImplementedException();
        }

        [CompilerGenerated]
        private static int x1980813477eae969(XElement x4bbc2c453c470189)
        {
            return x4bbc2c453c470189.Attribute("Val").AsInt(0);
        }

        private double x5d3a1f6283012a22(int x7b28e8a789372508, double xbcea506a33cf9111)
        {
            return FunctionalPreprocessorBase.Functions[this.Optc[x7b28e8a789372508]].Invoke(xbcea506a33cf9111);
        }

        private double xc673bdb68956bba8(BasicMLDataSet x4a3f0a05c02f235f, Func<double, double> x829059c1f308dc0c, int x437f2f55c5143ec3, int xc25cf86b73e79253)
        {
            double num2;
            double num = base.GenericCorrelation(x4a3f0a05c02f235f, x829059c1f308dc0c, new Func<double, double>(null, (IntPtr) FunctionalPreprocessorBase.X), x437f2f55c5143ec3, xc25cf86b73e79253);
            object[] objArray = new object[8];
            objArray[0] = x829059c1f308dc0c.Method.Name;
            objArray[1] = " ";
        Label_00BD:
            objArray[2] = x437f2f55c5143ec3;
            objArray[3] = " ";
        Label_0045:
            objArray[4] = xc25cf86b73e79253;
            objArray[5] = " = ";
            objArray[6] = num;
            objArray[7] = Environment.NewLine;
            if ((((uint) num2) & 0) != 0)
            {
                goto Label_00BD;
            }
            if ((((uint) xc25cf86b73e79253) + ((uint) num)) < 0)
            {
                goto Label_0045;
            }
            if (2 != 0)
            {
                Trace.Write(string.Concat(objArray));
                num2 = num;
                if ((((uint) xc25cf86b73e79253) & 0) == 0)
                {
                    return num2;
                }
                goto Label_0045;
            }
            return num2;
        }

        public CorrelationSelector CorrelationSelectMode
        {
            [CompilerGenerated]
            get
            {
                return this.x6d0372bf32d0b518;
            }
            [CompilerGenerated]
            set
            {
                this.x6d0372bf32d0b518 = value;
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

        public XElement Xml
        {
            get
            {
                int num;
                bool flag;
                int[] numArray;
                int num2;
                XElement element = new XElement("DataProcessor", new object[] { new XAttribute("Type", "SimpleFunctionalPreprocessorLogic"), this.x289fcfc6ab32371c(), new XAttribute("CorrelationSelectMode", this.CorrelationSelectMode) });
                if (((uint) num) >= 0)
                {
                    flag = this.Optc == null;
                    if ((((uint) num2) | 1) != 0)
                    {
                        goto Label_00A4;
                    }
                    goto Label_0126;
                }
            Label_0094:
                flag = num2 < numArray.Length;
                if (flag)
                {
                    num = numArray[num2];
                    element.Add(new XElement("Optc", new XAttribute("Val", num)));
                    if ((((uint) num2) | 15) == 0)
                    {
                        return element;
                    }
                    if ((((uint) flag) | 8) == 0)
                    {
                        XElement element2;
                        return element2;
                    }
                    num2++;
                    goto Label_0094;
                }
                return element;
            Label_00A4:
                if (flag)
                {
                    return element;
                }
            Label_0126:
                numArray = this.Optc;
                if (0x7fffffff == 0)
                {
                    goto Label_00A4;
                }
                num2 = 0;
                goto Label_0094;
            }
            set
            {
                this.IsUsed = value.xa14291458369dcd9();
                this.CorrelationSelectMode = value.Attribute("CorrelationSelectMode").AsEnumValue<CorrelationSelector>(CorrelationSelector.Max);
                this.Optc = null;
                bool flag = value.Elements("Optc").Count<XElement>() <= 0;
                if (((((uint) flag) + ((uint) flag)) < 0) || !flag)
                {
                    if (x66406001675ff321 == null)
                    {
                        x66406001675ff321 = new Func<XElement, int>(null, (IntPtr) x1980813477eae969);
                    }
                    this.Optc = Enumerable.Select<XElement, int>(value.Elements("Optc"), x66406001675ff321).ToArray<int>();
                    if (0 != 0)
                    {
                    }
                }
            }
        }
    }
}

