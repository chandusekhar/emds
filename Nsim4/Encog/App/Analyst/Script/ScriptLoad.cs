namespace Encog.App.Analyst.Script
{
    using Encog.App.Analyst;
    using Encog.App.Analyst.Script.Normalize;
    using Encog.App.Analyst.Script.Prop;
    using Encog.App.Analyst.Script.Segregate;
    using Encog.App.Analyst.Script.Task;
    using Encog.Persist;
    using Encog.Util.Arrayutil;
    using Encog.Util.CSV;
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class ScriptLoad
    {
        private readonly AnalystScript _x594135906c55045c;
        public const int ColumnFive = 5;
        public const int ColumnFour = 4;
        public const int ColumnOne = 1;
        public const int ColumnThree = 3;
        public const int ColumnTwo = 2;

        public ScriptLoad(AnalystScript theScript)
        {
            this._x594135906c55045c = theScript;
        }

        public void Load(Stream stream)
        {
            EncogReadHelper helper = null;
            try
            {
                EncogFileSection section;
                helper = new EncogReadHelper(stream);
                while ((section = helper.ReadNextSection()) != null)
                {
                    this.xf9edee23632d6876(section);
                }
                this._x594135906c55045c.Init();
            }
            finally
            {
                if (helper != null)
                {
                    helper.Close();
                }
            }
        }

        private void x23a952ae96385f94(EncogFileSection xb32f8dd719a105db)
        {
            this._x594135906c55045c.Normalize.NormalizedFields.Clear();
            bool flag = true;
            using (IEnumerator<string> enumerator = xb32f8dd719a105db.Lines.GetEnumerator())
            {
                string str;
                IList<string> list;
                string str2;
                bool flag2;
                int num;
                string str3;
                double num2;
                double num3;
                NormalizationAction oneOf;
                AnalystField field;
                AnalystField field2;
                goto Label_0047;
            Label_0026:
                this._x594135906c55045c.Normalize.NormalizedFields.Add(field);
                goto Label_0047;
            Label_003F:
                if (!flag)
                {
                    goto Label_02B1;
                }
                flag = false;
            Label_0047:
                if (enumerator.MoveNext())
                {
                    goto Label_02C2;
                }
                goto Label_0064;
            Label_0055:
                field2.Output = flag2;
                field = field2;
                goto Label_0026;
            Label_0064:
                if (((uint) num2) >= 0)
                {
                    goto Label_009C;
                }
            Label_0076:
                if ((((uint) flag) + ((uint) flag2)) > uint.MaxValue)
                {
                    goto Label_0145;
                }
                field2.TimeSlice = num;
                goto Label_0055;
            Label_009C:
                if ((((uint) num3) | 0xff) != 0)
                {
                    return;
                }
                goto Label_00DA;
            Label_00CA:
                field2 = new AnalystField(str2, oneOf, num2, num3);
                goto Label_0076;
            Label_00DA:
                if (str3.Equals("equilateral"))
                {
                    goto Label_013D;
                }
                if (str3.Equals("single"))
                {
                    oneOf = NormalizationAction.SingleField;
                    goto Label_00CA;
                }
                if (!str3.Equals("oneof"))
                {
                    throw new AnalystError("Unknown field type:" + str3);
                }
                oneOf = NormalizationAction.OneOf;
                if (0xff != 0)
                {
                    goto Label_00CA;
                }
                goto Label_0076;
            Label_011D:
                if ((((uint) num3) + ((uint) num3)) < 0)
                {
                    goto Label_024D;
                }
                goto Label_00DA;
            Label_013D:
                oneOf = NormalizationAction.Equilateral;
                goto Label_00CA;
            Label_0145:
                if (((uint) flag) > uint.MaxValue)
                {
                    goto Label_0177;
                }
            Label_0157:
                if (str3.Equals("pass"))
                {
                    goto Label_0177;
                }
                goto Label_00DA;
            Label_016F:
                oneOf = NormalizationAction.Ignore;
                goto Label_00CA;
            Label_0177:
                oneOf = NormalizationAction.PassThrough;
                goto Label_00CA;
            Label_017F:
                if ((((uint) flag) - ((uint) flag2)) < 0)
                {
                    goto Label_00DA;
                }
                if (!str3.Equals("ignore"))
                {
                    goto Label_0157;
                }
                if (((uint) flag) >= 0)
                {
                    goto Label_016F;
                }
                if (((uint) num2) >= 0)
                {
                    goto Label_00DA;
                }
                if ((((uint) num3) - ((uint) flag2)) <= uint.MaxValue)
                {
                    goto Label_0145;
                }
                goto Label_011D;
            Label_01E9:
                oneOf = NormalizationAction.Normalize;
                goto Label_00CA;
            Label_01F1:
                if (str3.Equals("range"))
                {
                    goto Label_01E9;
                }
                goto Label_017F;
            Label_0215:
                num3 = CSVFormat.EgFormat.Parse(list[5]);
                goto Label_01F1;
            Label_022D:
                str2 = list[0];
                flag2 = list[1].ToLower().Equals("output");
            Label_024D:
                num = int.Parse(list[2]);
                str3 = list[3];
                if ((((uint) flag2) - ((uint) num3)) > uint.MaxValue)
                {
                    goto Label_022D;
                }
                num2 = CSVFormat.EgFormat.Parse(list[4]);
                if ((((uint) flag2) + ((uint) num)) <= uint.MaxValue)
                {
                    goto Label_0215;
                }
                goto Label_01F1;
            Label_02B1:
                list = EncogFileSection.SplitColumns(str);
                goto Label_022D;
            Label_02C2:
                str = enumerator.Current;
                goto Label_003F;
            }
        }

        private void x3ed9c05d3bbdec37(EncogFileSection xb32f8dd719a105db)
        {
            bool flag;
            AnalystSegregateTarget[] targetArray;
            IList<AnalystSegregateTarget> list = new List<AnalystSegregateTarget>();
        Label_003D:
            flag = true;
            if (-1 != 0)
            {
            }
            using (IEnumerator<string> enumerator = xb32f8dd719a105db.Lines.GetEnumerator())
            {
                string str;
                IList<string> list2;
                AnalystSegregateTarget target;
            Label_0055:
                if (enumerator.MoveNext())
                {
                    goto Label_00A0;
                }
                goto Label_00C0;
            Label_0060:
                flag = false;
                goto Label_0055;
            Label_0064:
                list.Add(target);
                goto Label_0055;
            Label_006E:
                list2 = EncogFileSection.SplitColumns(str);
                string theFile = list2[0];
                if (-2 == 0)
                {
                    goto Label_0060;
                }
                int thePercent = int.Parse(list2[1]);
                target = new AnalystSegregateTarget(theFile, thePercent);
                goto Label_0064;
            Label_00A0:
                str = enumerator.Current;
                if (!flag && (0 == 0))
                {
                    goto Label_006E;
                }
                goto Label_0060;
            }
        Label_00C0:
            targetArray = new AnalystSegregateTarget[list.Count];
            int index = 0;
            if ((((uint) flag) | 0xff) != 0)
            {
                while (index < targetArray.Length)
                {
                    targetArray[index] = list[index];
                    index++;
                }
                this._x594135906c55045c.Segregate.SegregateTargets = targetArray;
                if (0 != 0)
                {
                    goto Label_003D;
                }
            }
        }

        private void x5e3dc7f2e4f7d693(EncogFileSection xb32f8dd719a105db)
        {
            AnalystTask task = new AnalystTask(xb32f8dd719a105db.SubSectionName);
            foreach (string str in xb32f8dd719a105db.Lines)
            {
                task.Lines.Add(str);
            }
            this._x594135906c55045c.AddTask(task);
        }

        private void x63659fc10ec15c58(EncogFileSection xb32f8dd719a105db)
        {
            IDictionary<string, string> dictionary = xb32f8dd719a105db.ParseParams();
            this._x594135906c55045c.Properties.ClearFilenames();
            foreach (KeyValuePair<string, string> pair in dictionary)
            {
                this._x594135906c55045c.Properties.SetFilename(pair.Key, pair.Value);
            }
        }

        private void xcc624bb62259df2c(string xb32f8dd719a105db, string x1640122bb0e29c3e, string xc15bd84e01929885, string x99e24f2bbe06f21b)
        {
            PropertyEntry entry = PropertyConstraints.Instance.GetEntry(xb32f8dd719a105db, x1640122bb0e29c3e, xc15bd84e01929885);
            if (entry == null)
            {
                throw new AnalystError("Unknown property: " + PropertyEntry.DotForm(xb32f8dd719a105db, x1640122bb0e29c3e, xc15bd84e01929885));
            }
            entry.Validate(xb32f8dd719a105db, x1640122bb0e29c3e, xc15bd84e01929885, x99e24f2bbe06f21b);
        }

        private void xeb630b6ed5f8b04a(EncogFileSection xb32f8dd719a105db)
        {
            bool flag;
            bool flag2;
            bool flag4;
            bool flag5;
            DataField[] fieldArray;
            int num5;
            IList<DataField> list = new List<DataField>();
            goto Label_0054;
        Label_0034:
            fieldArray[num5] = list[num5];
            num5++;
        Label_0047:
            if (num5 < fieldArray.Length)
            {
                goto Label_0034;
            }
            this._x594135906c55045c.Fields = fieldArray;
            if ((((uint) flag2) - ((uint) flag4)) >= 0)
            {
                return;
            }
        Label_0054:
            flag = true;
            using (IEnumerator<string> enumerator = xb32f8dd719a105db.Lines.GetEnumerator())
            {
                string str;
                IList<string> list2;
                string str2;
                bool flag3;
                double num;
                double num2;
                double num3;
                double num4;
                DataField field2;
                goto Label_007F;
            Label_0065:
                if (!flag)
                {
                    goto Label_0257;
                }
                if (((uint) flag3) >= 0)
                {
                }
                flag = false;
            Label_007F:
                if (enumerator.MoveNext())
                {
                    goto Label_0269;
                }
                goto Label_02A5;
            Label_008D:
                field2.StandardDeviation = num4;
                DataField item = field2;
            Label_009A:
                list.Add(item);
                goto Label_007F;
            Label_00AB:
                field2.Integer = flag4;
                field2.Real = flag5;
                field2.Max = num;
                field2.Min = num2;
                field2.Mean = num3;
                goto Label_008D;
            Label_00DD:
                field2.Complete = flag3;
                if ((((uint) flag) + ((uint) num)) >= 0)
                {
                    goto Label_00AB;
                }
                if ((((uint) flag) + ((uint) flag)) >= 0)
                {
                    goto Label_0182;
                }
            Label_0119:
                if ((((uint) num2) & 0) != 0)
                {
                    goto Label_0257;
                }
            Label_0130:
                num2 = CSVFormat.EgFormat.Parse(list2[6]);
                num3 = CSVFormat.EgFormat.Parse(list2[7]);
                num4 = CSVFormat.EgFormat.Parse(list2[8]);
                field2 = new DataField(str2) {
                    Class = flag2
                };
                if (0xff != 0)
                {
                    goto Label_00DD;
                }
            Label_0182:
                if ((((uint) flag) | 0xfffffffe) == 0)
                {
                    goto Label_0130;
                }
                if ((((uint) num2) | 8) != 0)
                {
                    goto Label_0119;
                }
                goto Label_00DD;
            Label_01C4:
                num = CSVFormat.EgFormat.Parse(list2[5]);
                if ((((uint) num) & 0) == 0)
                {
                    goto Label_0182;
                }
                goto Label_0269;
            Label_01F3:
                if (((uint) flag4) < 0)
                {
                    goto Label_009A;
                }
                str2 = list2[0];
                flag2 = int.Parse(list2[1]) > 0;
                flag3 = int.Parse(list2[2]) > 0;
                flag4 = int.Parse(list2[3]) > 0;
                flag5 = int.Parse(list2[4]) > 0;
                goto Label_01C4;
            Label_0257:
                list2 = EncogFileSection.SplitColumns(str);
                goto Label_01F3;
            Label_0269:
                str = enumerator.Current;
                goto Label_0065;
            }
            if (((uint) flag5) > uint.MaxValue)
            {
                goto Label_0034;
            }
        Label_02A5:
            fieldArray = new DataField[list.Count];
            num5 = 0;
            goto Label_0047;
        }

        private void xee831a85a4a1093a(EncogFileSection xb32f8dd719a105db)
        {
            int num;
            DataField[] fieldArray;
            int num2;
            Dictionary<string, List<AnalystClassItem>> dictionary = new Dictionary<string, List<AnalystClassItem>>();
            bool flag = true;
            using (IEnumerator<string> enumerator = xb32f8dd719a105db.Lines.GetEnumerator())
            {
                string str;
                IList<string> list;
                string str2;
                string str3;
                string str4;
                DataField field;
                List<AnalystClassItem> list2;
            Label_00E2:
                if (enumerator.MoveNext())
                {
                    goto Label_0263;
                }
                if (((uint) num) >= 0)
                {
                    goto Label_02A4;
                }
                goto Label_0144;
            Label_0102:
                flag = false;
            Label_0104:
                if (-2147483648 == 0)
                {
                    goto Label_0102;
                }
                goto Label_00E2;
            Label_010D:
                list2.Add(new AnalystClassItem(str3, str4, num));
                goto Label_00E2;
            Label_0121:
                if (!flag)
                {
                    goto Label_0270;
                }
                goto Label_0102;
            Label_0129:
                if (!dictionary.ContainsKey(str2))
                {
                    goto Label_0163;
                }
                list2 = dictionary[str2];
                if (0 == 0)
                {
                    goto Label_010D;
                }
                goto Label_0102;
            Label_0144:
                dictionary[str2] = list2;
                goto Label_010D;
            Label_015A:
                if (field == null)
                {
                    goto Label_0215;
                }
                goto Label_0129;
            Label_0163:
                list2 = new List<AnalystClassItem>();
                if ((((uint) num2) - ((uint) flag)) <= uint.MaxValue)
                {
                    goto Label_0144;
                }
                if ((((uint) num) - ((uint) flag)) <= uint.MaxValue)
                {
                    goto Label_0263;
                }
                if ((((uint) flag) & 0) != 0)
                {
                    if ((((uint) flag) + ((uint) num2)) > uint.MaxValue)
                    {
                        goto Label_0104;
                    }
                    goto Label_0129;
                }
            Label_01D4:
                str4 = list[2];
                num = int.Parse(list[3]);
                field = this._x594135906c55045c.FindDataField(str2);
                if ((((uint) num2) + ((uint) flag)) >= 0)
                {
                    goto Label_015A;
                }
            Label_0215:
                throw new AnalystError("Attempting to add class to unknown field: " + str4);
                if ((((uint) num) - ((uint) num)) < 0)
                {
                    goto Label_0144;
                }
                goto Label_024F;
            Label_0246:
                if (list.Count < 4)
                {
                    throw new AnalystError("Invalid data class: " + str);
                }
            Label_024F:
                str2 = list[0];
                str3 = list[1];
                goto Label_01D4;
            Label_0263:
                str = enumerator.Current;
                goto Label_0121;
            Label_0270:
                list = EncogFileSection.SplitColumns(str);
                goto Label_0246;
            }
        Label_02A4:
            fieldArray = this._x594135906c55045c.Fields;
            num2 = 0;
            while (true)
            {
                DataField field2;
                if (num2 < fieldArray.Length)
                {
                    field2 = fieldArray[num2];
                }
                else if (0xff != 0)
                {
                    return;
                }
                if (field2.Class)
                {
                    List<AnalystClassItem> list3 = dictionary[field2.Name];
                Label_000B:
                    if (list3 != null)
                    {
                        list3.Sort();
                        if ((0x7fffffff == 0) || ((((uint) flag) - ((uint) num)) < 0))
                        {
                            goto Label_000B;
                        }
                        field2.ClassMembers.Clear();
                        foreach (AnalystClassItem item in list3)
                        {
                            field2.ClassMembers.Add(item);
                        }
                    }
                }
                num2++;
            }
        }

        private void xf9edee23632d6876(EncogFileSection xb32f8dd719a105db)
        {
            string sectionName = xb32f8dd719a105db.SectionName;
            string subSectionName = xb32f8dd719a105db.SubSectionName;
            if (!sectionName.Equals("SETUP"))
            {
                goto Label_041D;
            }
            if (0x7fffffff == 0)
            {
                if (2 != 0)
                {
                    goto Label_0366;
                }
                goto Label_03A8;
            }
            if (0x7fffffff == 0)
            {
                if (0x7fffffff == 0)
                {
                    return;
                }
                goto Label_041D;
            }
            if (0x7fffffff == 0)
            {
                goto Label_00C3;
            }
            if ((0 == 0) && !subSectionName.Equals("CONFIG", StringComparison.InvariantCultureIgnoreCase))
            {
                goto Label_041D;
            }
            this.xff55b61ba453487f(xb32f8dd719a105db);
            return;
        Label_000E:
            if (subSectionName.Equals("CONFIG", StringComparison.InvariantCultureIgnoreCase))
            {
                goto Label_0044;
            }
            if (3 == 0)
            {
                goto Label_03ED;
            }
            return;
        Label_002D:
            if (!sectionName.Equals("BALANCE"))
            {
                return;
            }
            goto Label_000E;
        Label_0044:
            this.xff55b61ba453487f(xb32f8dd719a105db);
            return;
        Label_0055:
            if (!sectionName.Equals("TASKS"))
            {
                goto Label_002D;
            }
            if (subSectionName.Length <= 0)
            {
                if (3 != 0)
                {
                    goto Label_002D;
                }
                if (0 == 0)
                {
                    goto Label_000E;
                }
                if (0 != 0)
                {
                    goto Label_03FF;
                }
                goto Label_0044;
            }
            this.x5e3dc7f2e4f7d693(xb32f8dd719a105db);
            return;
        Label_0088:
            if (!sectionName.Equals("ML") || !subSectionName.Equals("TRAIN", StringComparison.InvariantCultureIgnoreCase))
            {
                goto Label_0055;
            }
            this.xff55b61ba453487f(xb32f8dd719a105db);
            if (-2147483648 != 0)
            {
                return;
            }
            goto Label_00C3;
        Label_00B3:
            if (subSectionName.Equals("CONFIG", StringComparison.InvariantCultureIgnoreCase))
            {
                this.xff55b61ba453487f(xb32f8dd719a105db);
                return;
            }
            goto Label_0088;
        Label_00C3:
            if (0 != 0)
            {
                goto Label_00B3;
            }
            goto Label_0088;
        Label_00DC:
            if (!sectionName.Equals("ML"))
            {
                goto Label_0088;
            }
            goto Label_00B3;
        Label_0105:
            if (!sectionName.Equals("HEADER"))
            {
                goto Label_00DC;
            }
            if (-2 != 0)
            {
                if (8 != 0)
                {
                    if (subSectionName.Equals("DATASOURCE", StringComparison.InvariantCultureIgnoreCase))
                    {
                        this.xff55b61ba453487f(xb32f8dd719a105db);
                        return;
                    }
                    if (1 == 0)
                    {
                        goto Label_02C5;
                    }
                    goto Label_00DC;
                }
                goto Label_0055;
            }
            if (-2147483648 != 0)
            {
                goto Label_0136;
            }
        Label_0120:
            if (!subSectionName.Equals("CONFIG", StringComparison.InvariantCultureIgnoreCase))
            {
                if (0 != 0)
                {
                    goto Label_0366;
                }
                goto Label_0105;
            }
        Label_0136:
            this.xff55b61ba453487f(xb32f8dd719a105db);
            return;
        Label_013E:
            if (sectionName.Equals("GENERATE"))
            {
                goto Label_0120;
            }
            goto Label_0105;
        Label_0164:
            if (!sectionName.Equals("SEGREGATE"))
            {
                if (4 == 0)
                {
                    return;
                }
                goto Label_013E;
            }
        Label_01A4:
            if (!subSectionName.Equals("FILES", StringComparison.InvariantCultureIgnoreCase))
            {
                goto Label_013E;
            }
            if (0 == 0)
            {
                this.x3ed9c05d3bbdec37(xb32f8dd719a105db);
                if (0 == 0)
                {
                    return;
                }
                goto Label_02F2;
            }
            if (0 == 0)
            {
                goto Label_0293;
            }
            if (0 == 0)
            {
                return;
            }
            goto Label_022C;
        Label_01CE:
            if (!sectionName.Equals("SEGREGATE"))
            {
                goto Label_0164;
            }
            if (!subSectionName.Equals("CONFIG", StringComparison.InvariantCultureIgnoreCase))
            {
                if (-2147483648 == 0)
                {
                    return;
                }
                if (3 == 0)
                {
                    return;
                }
                if (-2147483648 == 0)
                {
                    goto Label_0210;
                }
                if (0 != 0)
                {
                    goto Label_01A4;
                }
                goto Label_0164;
            }
            this.xff55b61ba453487f(xb32f8dd719a105db);
            if (-2 != 0)
            {
            }
            return;
        Label_0203:
            if (!sectionName.Equals("RANDOMIZE"))
            {
                goto Label_01CE;
            }
        Label_0210:
            if (subSectionName.Equals("CONFIG", StringComparison.InvariantCultureIgnoreCase))
            {
                this.xff55b61ba453487f(xb32f8dd719a105db);
                return;
            }
            goto Label_01CE;
        Label_022C:
            if (sectionName.Equals("SERIES"))
            {
                goto Label_027B;
            }
            goto Label_0203;
        Label_0259:
            if (!sectionName.Equals("CLUSTER"))
            {
                goto Label_022C;
            }
        Label_0266:
            if (subSectionName.Equals("CONFIG", StringComparison.InvariantCultureIgnoreCase))
            {
                this.xff55b61ba453487f(xb32f8dd719a105db);
                return;
            }
            if (-1 != 0)
            {
                goto Label_022C;
            }
        Label_027B:
            if (!subSectionName.Equals("CONFIG", StringComparison.InvariantCultureIgnoreCase))
            {
                goto Label_0203;
            }
            this.xff55b61ba453487f(xb32f8dd719a105db);
            return;
        Label_0293:
            if (subSectionName.Equals("CONFIG", StringComparison.InvariantCultureIgnoreCase))
            {
                this.xff55b61ba453487f(xb32f8dd719a105db);
                return;
            }
            if (0 == 0)
            {
                goto Label_0259;
            }
            goto Label_0266;
        Label_02C5:
            if (subSectionName.Equals("CONFIG", StringComparison.InvariantCultureIgnoreCase))
            {
                goto Label_02FF;
            }
        Label_02D3:
            if (!sectionName.Equals("NORMALIZE"))
            {
                goto Label_0259;
            }
            if (-1 != 0)
            {
                goto Label_0293;
            }
            return;
        Label_02F2:
            if (0x7fffffff != 0)
            {
                goto Label_02C5;
            }
            if (0 != 0)
            {
                goto Label_013E;
            }
        Label_02FF:
            this.xff55b61ba453487f(xb32f8dd719a105db);
            return;
        Label_0309:
            if (sectionName.Equals("NORMALIZE"))
            {
                if (subSectionName.Equals("RANGE", StringComparison.InvariantCultureIgnoreCase))
                {
                    this.x23a952ae96385f94(xb32f8dd719a105db);
                    return;
                }
                if (8 == 0)
                {
                    return;
                }
            }
            if (!sectionName.Equals("NORMALIZE"))
            {
                goto Label_02D3;
            }
            if (-2 != 0)
            {
                goto Label_02F2;
            }
            if (0 == 0)
            {
                goto Label_02C5;
            }
        Label_0348:
            if (subSectionName.Equals("CLASSES", StringComparison.InvariantCultureIgnoreCase))
            {
                this.xee831a85a4a1093a(xb32f8dd719a105db);
                if (0 == 0)
                {
                    return;
                }
                goto Label_0293;
            }
            goto Label_0309;
        Label_0366:
            if (!sectionName.Equals("DATA"))
            {
                goto Label_0309;
            }
            if (15 != 0)
            {
                goto Label_0348;
            }
            goto Label_02C5;
        Label_038D:
            if (subSectionName.Equals("STATS", StringComparison.InvariantCultureIgnoreCase))
            {
                this.xeb630b6ed5f8b04a(xb32f8dd719a105db);
                return;
            }
            goto Label_0366;
        Label_03A8:
            if (!sectionName.Equals("DATA"))
            {
                goto Label_0366;
            }
            goto Label_038D;
        Label_03D4:
            if (0 != 0)
            {
                goto Label_03FF;
            }
            goto Label_03A8;
        Label_03ED:
            if (subSectionName.Equals("CONFIG", StringComparison.InvariantCultureIgnoreCase))
            {
                this.xff55b61ba453487f(xb32f8dd719a105db);
                return;
            }
            if (0xff != 0)
            {
                goto Label_03A8;
            }
            goto Label_03D4;
        Label_03FF:
            if (!sectionName.Equals("DATA") && (15 != 0))
            {
                if (0 != 0)
                {
                    goto Label_03D4;
                }
                if (0 == 0)
                {
                    goto Label_03A8;
                }
                goto Label_038D;
            }
            goto Label_03ED;
        Label_041D:
            if (!sectionName.Equals("SETUP") || !subSectionName.Equals("FILENAMES", StringComparison.InvariantCultureIgnoreCase))
            {
                goto Label_03FF;
            }
            this.x63659fc10ec15c58(xb32f8dd719a105db);
        }

        private void xff55b61ba453487f(EncogFileSection xb32f8dd719a105db)
        {
            // This item is obfuscated and can not be translated.
        }
    }
}

