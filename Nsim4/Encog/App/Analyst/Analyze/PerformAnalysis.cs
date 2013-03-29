namespace Encog.App.Analyst.Analyze
{
    using Encog.App.Analyst;
    using Encog.App.Analyst.Script;
    using Encog.App.Analyst.Util;
    using Encog.Util.CSV;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class PerformAnalysis
    {
        private readonly AnalystFileFormat _x5786461d089b10a0;
        private readonly AnalystScript _x594135906c55045c;
        private readonly bool _x94e6ca5ac178dbd0;
        private AnalyzedField[] _xa942970cc8a85fd4;
        private readonly string _xb41a802ca5fde63b;

        public PerformAnalysis(AnalystScript theScript, string theFilename, bool theHeaders, AnalystFileFormat theFormat)
        {
            this._xb41a802ca5fde63b = theFilename;
            this._x94e6ca5ac178dbd0 = theHeaders;
            this._x5786461d089b10a0 = theFormat;
            this._x594135906c55045c = theScript;
        }

        public void Process(EncogAnalyst target)
        {
            string text1;
            int num;
            int num2;
            string str;
            bool flag;
            bool flag2;
            bool flag3;
            AnalyzedField field3;
            int num3;
            IList<AnalystClassItem> analyzedClassMembers;
            IList<AnalystClassItem> classMembers;
            int num4;
            DataField[] fieldArray;
            int num5;
            AnalyzedField[] fieldArray2;
            int num6;
            AnalyzedField[] fieldArray3;
            int num7;
            AnalyzedField[] fieldArray4;
            int num8;
            CSVFormat format = ConvertStringConst.ConvertToCSVFormat(this._x5786461d089b10a0);
            ReadCSV dcsv = new ReadCSV(this._xb41a802ca5fde63b, this._x94e6ca5ac178dbd0, format);
        Label_0676:
            if (dcsv.Next())
            {
                if (this._xa942970cc8a85fd4 == null)
                {
                    this.xd2a854890d89a856(dcsv);
                }
                num = 0;
                while (num < dcsv.ColumnCount)
                {
                    if (this._xa942970cc8a85fd4 != null)
                    {
                        this._xa942970cc8a85fd4[num].Analyze1(dcsv.Get(num));
                    }
                    num++;
                }
                if (((uint) num2) >= 0)
                {
                    goto Label_0676;
                }
            }
            else if (this._xa942970cc8a85fd4 != null)
            {
                fieldArray2 = this._xa942970cc8a85fd4;
            }
            else
            {
                if ((((uint) num8) & 0) == 0)
                {
                    goto Label_05F5;
                }
                goto Label_05D0;
            }
            if ((((uint) num2) - ((uint) flag2)) >= 0)
            {
                for (num6 = 0; num6 < fieldArray2.Length; num6++)
                {
                    fieldArray2[num6].CompletePass1();
                }
                goto Label_05F5;
            }
            goto Label_05D0;
        Label_0011:
            num5++;
            if (((uint) num2) < 0)
            {
                goto Label_0251;
            }
        Label_002C:
            if (num5 < fieldArray.Length)
            {
                fieldArray[num5] = this._xa942970cc8a85fd4[num5].FinalizeField();
                if ((((uint) num6) + ((uint) num)) <= uint.MaxValue)
                {
                    goto Label_0011;
                }
                if ((((uint) num8) | 3) != 0)
                {
                    goto Label_00E8;
                }
            }
            else
            {
                if (((uint) flag2) > uint.MaxValue)
                {
                    goto Label_0336;
                }
                target.Script.Fields = fieldArray;
                return;
            }
        Label_00A6:
            if (this._xa942970cc8a85fd4.Length == target.Script.Fields.Length)
            {
                num3 = 0;
                goto Label_00EE;
            }
            if ((((uint) flag3) & 0) != 0)
            {
                goto Label_0248;
            }
        Label_00D7:
            fieldArray = new DataField[this._xa942970cc8a85fd4.Length];
            if ((((uint) num6) + ((uint) num4)) >= 0)
            {
                num5 = 0;
                goto Label_002C;
            }
            goto Label_0011;
        Label_00E8:
            num3++;
        Label_00EE:
            if (num3 < this._xa942970cc8a85fd4.Length)
            {
                this._xa942970cc8a85fd4[num3].Name = target.Script.Fields[num3].Name;
                if (!this._xa942970cc8a85fd4[num3].Class)
                {
                    goto Label_00E8;
                }
                analyzedClassMembers = this._xa942970cc8a85fd4[num3].AnalyzedClassMembers;
                classMembers = target.Script.Fields[num3].ClassMembers;
                if (classMembers.Count != analyzedClassMembers.Count)
                {
                    goto Label_00E8;
                }
                num4 = 0;
                if (((uint) num2) > uint.MaxValue)
                {
                    goto Label_0341;
                }
                goto Label_0195;
            }
            goto Label_00D7;
        Label_018F:
            num4++;
        Label_0195:
            if (num4 < classMembers.Count)
            {
                if (analyzedClassMembers[num4].Code.Equals(classMembers[num4].Code))
                {
                    analyzedClassMembers[num4].Name = classMembers[num4].Name;
                }
                goto Label_018F;
            }
            goto Label_00E8;
        Label_0238:
            if (num8 < fieldArray4.Length)
            {
                field3 = fieldArray4[num8];
                if ((((uint) num) & 0) != 0)
                {
                    goto Label_02FF;
                }
                if (field3.Class)
                {
                    if (flag)
                    {
                        goto Label_0350;
                    }
                    if (((uint) num4) <= uint.MaxValue)
                    {
                        goto Label_03E6;
                    }
                    goto Label_040F;
                }
                goto Label_0251;
            }
            if (target.Script.Fields != null)
            {
                goto Label_00A6;
            }
            if ((((uint) num8) + ((uint) num5)) > uint.MaxValue)
            {
                goto Label_0341;
            }
            goto Label_00D7;
        Label_0248:
            if (field3.Integer && (field3.AnalyzedClassMembers.Count <= 2))
            {
                if ((((uint) num6) - ((uint) num5)) >= 0)
                {
                    if ((((uint) num7) | 4) == 0)
                    {
                        goto Label_059B;
                    }
                    field3.Class = false;
                }
                else
                {
                    if ((((uint) flag2) + ((uint) num8)) >= 0)
                    {
                        goto Label_0350;
                    }
                    goto Label_02FF;
                }
            }
        Label_0251:
            num8++;
            goto Label_0238;
        Label_02FF:
            if (!flag2 && (field3.Real && !field3.Integer))
            {
                field3.Class = false;
            }
            goto Label_0248;
        Label_030B:
            if ((((uint) flag3) - ((uint) num2)) >= 0)
            {
                goto Label_02FF;
            }
        Label_0341:
            while (!field3.Real)
            {
                field3.Class = false;
                goto Label_02FF;
            Label_0336:
                if (field3.Integer)
                {
                    goto Label_030B;
                }
            }
            goto Label_0368;
        Label_0350:
            if (flag3)
            {
                goto Label_02FF;
            }
            if ((((uint) num5) & 0) == 0)
            {
                goto Label_0336;
            }
        Label_0368:
            if ((((uint) flag) - ((uint) num4)) >= 0)
            {
                goto Label_02FF;
            }
            goto Label_030B;
        Label_03E6:
            if (!field3.Integer)
            {
                goto Label_0350;
            }
        Label_040F:
            field3.Class = false;
            if ((((uint) num7) + ((uint) flag)) < 0)
            {
                goto Label_05F5;
            }
            if ((((uint) num3) + ((uint) flag)) > uint.MaxValue)
            {
                goto Label_04D6;
            }
            if ((((uint) num3) & 0) == 0)
            {
                goto Label_0350;
            }
            goto Label_03E6;
        Label_04A8:
            dcsv.Close();
        Label_04AE:
            text1 = this._x594135906c55045c.Properties.GetPropertyString("SETUP:CONFIG_allowedClasses");
            if (text1 != null)
            {
                str = text1;
            }
            else
            {
                if (0 != 0)
                {
                    goto Label_02FF;
                }
                str = "";
            }
            flag = str.Contains("int");
            if (str.Contains("real"))
            {
            }
            flag2 = true;
            flag3 = str.Contains("string");
            fieldArray4 = this._xa942970cc8a85fd4;
            num8 = 0;
            goto Label_0238;
        Label_04D6:
            if (num7 >= fieldArray3.Length)
            {
            }
            AnalyzedField field2 = fieldArray3[num7];
            if (((uint) num4) < 0)
            {
                goto Label_04AE;
            }
            field2.CompletePass2();
            num7++;
            if ((((uint) num4) + ((uint) num2)) < 0)
            {
                goto Label_018F;
            }
            if ((((uint) num3) + ((uint) flag)) >= 0)
            {
                goto Label_04D6;
            }
        Label_0554:
            if (((uint) flag) > uint.MaxValue)
            {
                goto Label_059B;
            }
            goto Label_04D6;
            if ((((uint) num2) | 0x7fffffff) != 0)
            {
                if ((((uint) flag2) - ((uint) num3)) >= 0)
                {
                    goto Label_04A8;
                }
                goto Label_05D0;
            }
        Label_058B:
            num2++;
        Label_0591:
            if (num2 < dcsv.ColumnCount)
            {
                goto Label_05D0;
            }
        Label_059B:
            if (dcsv.Next())
            {
                num2 = 0;
                goto Label_0591;
            }
            if (this._xa942970cc8a85fd4 != null)
            {
                fieldArray3 = this._xa942970cc8a85fd4;
                num7 = 0;
                goto Label_0554;
            }
            goto Label_04A8;
        Label_05D0:
            if (this._xa942970cc8a85fd4 != null)
            {
                this._xa942970cc8a85fd4[num2].Analyze2(dcsv.Get(num2));
            }
            goto Label_058B;
        Label_05F5:
            dcsv.Close();
            if (((uint) num) >= 0)
            {
            }
            dcsv = new ReadCSV(this._xb41a802ca5fde63b, this._x94e6ca5ac178dbd0, format);
            goto Label_059B;
        }

        public sealed override string ToString()
        {
            StringBuilder builder = new StringBuilder("[");
            builder.Append(base.GetType().Name);
            if (0xff != 0)
            {
                builder.Append(" filename=");
                builder.Append(this._xb41a802ca5fde63b);
                builder.Append(", headers=");
            }
            builder.Append(this._x94e6ca5ac178dbd0);
            builder.Append("]");
            return builder.ToString();
        }

        private void x4a9608d3049df252(ReadCSV xe4aa442e12986e06)
        {
            this._xa942970cc8a85fd4 = new AnalyzedField[xe4aa442e12986e06.ColumnCount];
            for (int i = 0; (i < this._xa942970cc8a85fd4.Length) || (0 != 0); i++)
            {
                this._xa942970cc8a85fd4[i] = new AnalyzedField(this._x594135906c55045c, "field:" + (i + 1));
            }
        }

        private void x7e640a0bc3eeb27e(ReadCSV xe4aa442e12986e06)
        {
            int num;
            CSVHeaders headers = new CSVHeaders(xe4aa442e12986e06.ColumnNames);
            if (3 != 0)
            {
                this._xa942970cc8a85fd4 = new AnalyzedField[xe4aa442e12986e06.ColumnCount];
                num = 0;
                goto Label_0031;
            }
        Label_0013:
            this._xa942970cc8a85fd4[num] = new AnalyzedField(this._x594135906c55045c, headers.GetHeader(num));
            num++;
        Label_0031:
            if (num >= this._xa942970cc8a85fd4.Length)
            {
                return;
            }
            if (num >= xe4aa442e12986e06.ColumnCount)
            {
                throw new AnalystError("CSV header count does not match column count");
            }
            if (((uint) num) >= 0)
            {
            }
            goto Label_0013;
        }

        private void xd2a854890d89a856(ReadCSV xe4aa442e12986e06)
        {
            if (this._x94e6ca5ac178dbd0)
            {
                this.x7e640a0bc3eeb27e(xe4aa442e12986e06);
            }
            else
            {
                this.x4a9608d3049df252(xe4aa442e12986e06);
            }
        }
    }
}

