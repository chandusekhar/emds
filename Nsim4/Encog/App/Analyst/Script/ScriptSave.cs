namespace Encog.App.Analyst.Script
{
    using Encog.App.Analyst;
    using Encog.App.Analyst.Script.Normalize;
    using Encog.App.Analyst.Script.Prop;
    using Encog.App.Analyst.Script.Segregate;
    using Encog.App.Analyst.Script.Task;
    using Encog.Persist;
    using Encog.Util.Arrayutil;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class ScriptSave
    {
        private readonly AnalystScript _x594135906c55045c;

        public ScriptSave(AnalystScript theScript)
        {
            this._x594135906c55045c = theScript;
        }

        public void Save(Stream stream)
        {
            EncogWriteHelper helper = new EncogWriteHelper(stream);
            if (0 == 0)
            {
                this.x4ec53e22935ca8a4(helper, "HEADER", "DATASOURCE");
                goto Label_00BF;
            }
        Label_000D:
            this.xb65907545d46dd44(helper);
            this.x3d1973763c1ba5f6(helper);
            helper.Flush();
            return;
        Label_0094:
            this.x4ec53e22935ca8a4(helper, "RANDOMIZE", "CONFIG");
            if (-2 == 0)
            {
                goto Label_00C8;
            }
            goto Label_00DD;
        Label_00BF:
            this.x2cf4bfede7840d5b(helper);
            if (this._x594135906c55045c.Fields == null)
            {
                goto Label_0094;
            }
        Label_00C8:
            this.x80a029c2a0fbca61(helper);
            this.x6f59fa9537dbb843(helper);
            if (2 != 0)
            {
                if (0 != 0)
                {
                    goto Label_00BF;
                }
                goto Label_0094;
            }
        Label_00DD:
            if (0 == 0)
            {
                this.x4ec53e22935ca8a4(helper, "CLUSTER", "CONFIG");
                this.x4ec53e22935ca8a4(helper, "BALANCE", "CONFIG");
                if (this._x594135906c55045c.Segregate.SegregateTargets != null)
                {
                    this.x312a5c458079831e(helper);
                }
                else if (0 != 0)
                {
                    goto Label_00BF;
                }
                this.x4ec53e22935ca8a4(helper, "GENERATE", "CONFIG");
            }
            goto Label_000D;
        }

        private void x2cf4bfede7840d5b(EncogWriteHelper xa58d1d9c6fa55c59)
        {
            this.x4ec53e22935ca8a4(xa58d1d9c6fa55c59, "SETUP", "CONFIG");
            xa58d1d9c6fa55c59.AddSubSection("FILENAMES");
            foreach (string str in this._x594135906c55045c.Properties.Filenames)
            {
                string filename = this._x594135906c55045c.Properties.GetFilename(str);
                FileInfo info = new FileInfo(filename);
                xa58d1d9c6fa55c59.WriteProperty(str, info.DirectoryName.Equals(this._x594135906c55045c.BasePath, StringComparison.InvariantCultureIgnoreCase) ? info.Name : filename);
            }
            if (0x7fffffff != 0)
            {
            }
        }

        private void x312a5c458079831e(EncogWriteHelper xa58d1d9c6fa55c59)
        {
            AnalystSegregateTarget[] segregateTargets;
            int num;
            this.x4ec53e22935ca8a4(xa58d1d9c6fa55c59, "SEGREGATE", "CONFIG");
            if (((uint) num) >= 0)
            {
                goto Label_007E;
            }
        Label_0023:
            xa58d1d9c6fa55c59.WriteLine();
            num++;
        Label_002D:
            if (num < segregateTargets.Length)
            {
                AnalystSegregateTarget target = segregateTargets[num];
                if (4 != 0)
                {
                    if (15 != 0)
                    {
                        xa58d1d9c6fa55c59.AddColumn(target.File);
                        xa58d1d9c6fa55c59.AddColumn(target.Percent);
                        if (15 == 0)
                        {
                            return;
                        }
                        goto Label_0023;
                    }
                    goto Label_009F;
                }
            }
            else
            {
                return;
            }
        Label_007E:
            xa58d1d9c6fa55c59.AddSubSection("FILES");
            xa58d1d9c6fa55c59.AddColumn("file");
            xa58d1d9c6fa55c59.AddColumn("percent");
        Label_009F:
            xa58d1d9c6fa55c59.WriteLine();
            segregateTargets = this._x594135906c55045c.Segregate.SegregateTargets;
            num = 0;
            if ((((uint) num) - ((uint) num)) < 0)
            {
                goto Label_009F;
            }
            goto Label_002D;
        }

        private void x3d1973763c1ba5f6(EncogWriteHelper xa58d1d9c6fa55c59)
        {
            xa58d1d9c6fa55c59.AddSection("TASKS");
            List<string> list = this._x594135906c55045c.Tasks.Keys.ToList<string>();
            list.Sort();
            foreach (string str in list)
            {
                if (0 == 0)
                {
                }
                AnalystTask task = this._x594135906c55045c.GetTask(str);
                xa58d1d9c6fa55c59.AddSubSection(task.Name);
                foreach (string str2 in task.Lines)
                {
                    xa58d1d9c6fa55c59.AddLine(str2);
                }
            }
        }

        private void x4ec53e22935ca8a4(EncogWriteHelper xa58d1d9c6fa55c59, string xb32f8dd719a105db, string x1640122bb0e29c3e)
        {
            List<PropertyEntry> entries;
            if (!xb32f8dd719a105db.Equals(xa58d1d9c6fa55c59.CurrentSection))
            {
                xa58d1d9c6fa55c59.AddSection(xb32f8dd719a105db);
            }
            xa58d1d9c6fa55c59.AddSubSection(x1640122bb0e29c3e);
            if (0 == 0)
            {
                entries = PropertyConstraints.Instance.GetEntries(xb32f8dd719a105db, x1640122bb0e29c3e);
            }
            entries.Sort();
            using (List<PropertyEntry>.Enumerator enumerator = entries.GetEnumerator())
            {
                PropertyEntry entry;
                string str2;
                string[] strArray;
                goto Label_0059;
            Label_003C:
                if (15 != 0)
                {
                }
                xa58d1d9c6fa55c59.WriteProperty(entry.Name, str2 ?? "");
            Label_0059:
                if (enumerator.MoveNext())
                {
                    goto Label_00BC;
                }
                goto Label_00B5;
            Label_0064:
                strArray[3] = "_";
                strArray[4] = entry.Name;
                string name = string.Concat(strArray);
            Label_007F:
                str2 = this._x594135906c55045c.Properties.GetPropertyString(name);
                goto Label_003C;
            Label_0095:
                if (0 != 0)
                {
                    goto Label_007F;
                }
                strArray = new string[5];
                strArray[0] = xb32f8dd719a105db;
                strArray[1] = ":";
                strArray[2] = x1640122bb0e29c3e;
                goto Label_0064;
            Label_00B5:
                if (4 != 0)
                {
                    return;
                }
            Label_00BC:
                entry = enumerator.Current;
                goto Label_0095;
            }
        }

        private void x6f59fa9537dbb843(EncogWriteHelper xa58d1d9c6fa55c59)
        {
            this.x4ec53e22935ca8a4(xa58d1d9c6fa55c59, "NORMALIZE", "CONFIG");
            xa58d1d9c6fa55c59.AddSubSection("RANGE");
            xa58d1d9c6fa55c59.AddColumn("name");
            xa58d1d9c6fa55c59.AddColumn("io");
            if (0 == 0)
            {
            }
            xa58d1d9c6fa55c59.AddColumn("timeSlice");
            xa58d1d9c6fa55c59.AddColumn("action");
            xa58d1d9c6fa55c59.AddColumn("high");
            xa58d1d9c6fa55c59.AddColumn("low");
            xa58d1d9c6fa55c59.WriteLine();
            using (IEnumerator<AnalystField> enumerator = this._x594135906c55045c.Normalize.NormalizedFields.GetEnumerator())
            {
                AnalystField field;
            Label_0060:
                if (enumerator.MoveNext())
                {
                    goto Label_015A;
                }
                return;
            Label_008D:
                xa58d1d9c6fa55c59.AddColumn(field.NormalizedHigh);
                xa58d1d9c6fa55c59.AddColumn(field.NormalizedLow);
                xa58d1d9c6fa55c59.WriteLine();
                if (0 == 0)
                {
                    goto Label_0060;
                }
                goto Label_008D;
            Label_00B0:
                xa58d1d9c6fa55c59.AddColumn("single");
                if (2 == 0)
                {
                    goto Label_015A;
                }
                goto Label_008D;
            Label_00C9:
                xa58d1d9c6fa55c59.AddColumn("pass");
                goto Label_008D;
            Label_00D6:
                xa58d1d9c6fa55c59.AddColumn("oneof");
                goto Label_008D;
            Label_00E3:
                xa58d1d9c6fa55c59.AddColumn("equilateral");
                goto Label_008D;
            Label_00F7:
                xa58d1d9c6fa55c59.AddColumn("range");
                goto Label_008D;
            Label_010C:
                xa58d1d9c6fa55c59.AddColumn(field.TimeSlice);
                switch (field.Action)
                {
                    case NormalizationAction.PassThrough:
                        goto Label_00C9;

                    case NormalizationAction.Normalize:
                        goto Label_00F7;

                    case NormalizationAction.Ignore:
                        break;

                    case NormalizationAction.OneOf:
                        goto Label_00D6;

                    case NormalizationAction.Equilateral:
                        goto Label_00E3;

                    case NormalizationAction.SingleField:
                        goto Label_00B0;

                    default:
                        throw new AnalystError("Unknown action: " + field.Action);
                }
                xa58d1d9c6fa55c59.AddColumn("ignore");
                if (15 != 0)
                {
                    goto Label_018C;
                }
                if (0 != 0)
                {
                    goto Label_0060;
                }
            Label_015A:
                field = enumerator.Current;
                xa58d1d9c6fa55c59.AddColumn(field.Name);
                xa58d1d9c6fa55c59.AddColumn(field.Input ? "input" : "output");
                goto Label_010C;
            Label_018C:
                if (4 != 0)
                {
                    goto Label_008D;
                }
                goto Label_0060;
            }
        }

        private void x80a029c2a0fbca61(EncogWriteHelper xa58d1d9c6fa55c59)
        {
            DataField field;
            DataField field2;
            DataField[] fieldArray;
            int num;
            DataField[] fields;
            int num2;
            this.x4ec53e22935ca8a4(xa58d1d9c6fa55c59, "DATA", "CONFIG");
            if ((((uint) num) | 8) != 0)
            {
                xa58d1d9c6fa55c59.AddSubSection("STATS");
            }
            goto Label_031C;
        Label_0033:
            if (((uint) num2) > uint.MaxValue)
            {
                goto Label_0062;
            }
        Label_0045:
            num2++;
        Label_004B:
            if (num2 < fields.Length)
            {
                field2 = fields[num2];
                if (0x7fffffff != 0)
                {
                    goto Label_0058;
                }
                goto Label_0170;
            }
            if ((((uint) num2) | 0x7fffffff) != 0)
            {
                if ((((uint) num2) | uint.MaxValue) != 0)
                {
                    return;
                }
                goto Label_031C;
            }
            goto Label_01F9;
        Label_0058:
            if (field2.Class)
            {
                using (IEnumerator<AnalystClassItem> enumerator = field2.ClassMembers.GetEnumerator())
                {
                    goto Label_00AE;
                Label_0090:
                    if ((((uint) num) | 3) == 0)
                    {
                        goto Label_0045;
                    }
                    xa58d1d9c6fa55c59.WriteLine();
                Label_00AE:
                    if (enumerator.MoveNext())
                    {
                        AnalystClassItem current = enumerator.Current;
                        xa58d1d9c6fa55c59.AddColumn(field2.Name);
                        xa58d1d9c6fa55c59.AddColumn(current.Code);
                        xa58d1d9c6fa55c59.AddColumn(current.Name);
                        xa58d1d9c6fa55c59.AddColumn(current.Count);
                        goto Label_0090;
                    }
                    goto Label_0045;
                }
            }
            goto Label_0033;
        Label_0062:
            if ((((uint) num) & 0) != 0)
            {
                goto Label_0058;
            }
            goto Label_0045;
        Label_0170:
            xa58d1d9c6fa55c59.AddColumn("code");
            if ((((uint) num2) + ((uint) num)) > uint.MaxValue)
            {
                goto Label_0033;
            }
            xa58d1d9c6fa55c59.AddColumn("name");
            xa58d1d9c6fa55c59.WriteLine();
            if ((((uint) num2) & 0) == 0)
            {
                fields = this._x594135906c55045c.Fields;
                num2 = 0;
                if (0 != 0)
                {
                    goto Label_0331;
                }
                if (((uint) num2) > uint.MaxValue)
                {
                    goto Label_0058;
                }
                goto Label_004B;
            }
            goto Label_01F9;
        Label_01B3:
            if (num < fieldArray.Length)
            {
                field = fieldArray[num];
                goto Label_0369;
            }
            xa58d1d9c6fa55c59.Flush();
            xa58d1d9c6fa55c59.AddSubSection("CLASSES");
            xa58d1d9c6fa55c59.AddColumn("field");
            goto Label_0170;
        Label_01F9:
            xa58d1d9c6fa55c59.AddColumn(field.Real);
            xa58d1d9c6fa55c59.AddColumn(field.Max);
            xa58d1d9c6fa55c59.AddColumn(field.Min);
            xa58d1d9c6fa55c59.AddColumn(field.Mean);
            xa58d1d9c6fa55c59.AddColumn(field.StandardDeviation);
            xa58d1d9c6fa55c59.WriteLine();
            num++;
            if (8 == 0)
            {
                goto Label_0062;
            }
            goto Label_01B3;
        Label_031C:
            if (3 == 0)
            {
                goto Label_0045;
            }
            xa58d1d9c6fa55c59.AddColumn("name");
        Label_0331:
            xa58d1d9c6fa55c59.AddColumn("isclass");
            xa58d1d9c6fa55c59.AddColumn("iscomplete");
        Label_0347:
            xa58d1d9c6fa55c59.AddColumn("isint");
            if ((((uint) num) & 0) == 0)
            {
                xa58d1d9c6fa55c59.AddColumn("isreal");
                xa58d1d9c6fa55c59.AddColumn("amax");
                xa58d1d9c6fa55c59.AddColumn("amin");
                xa58d1d9c6fa55c59.AddColumn("mean");
                xa58d1d9c6fa55c59.AddColumn("sdev");
                xa58d1d9c6fa55c59.WriteLine();
                fieldArray = this._x594135906c55045c.Fields;
                num = 0;
                goto Label_01B3;
            }
        Label_0369:
            if ((((uint) num) & 0) == 0)
            {
                xa58d1d9c6fa55c59.AddColumn(field.Name);
                xa58d1d9c6fa55c59.AddColumn(field.Class);
                if ((((uint) num2) + ((uint) num)) < 0)
                {
                    goto Label_0347;
                }
            }
            xa58d1d9c6fa55c59.AddColumn(field.Complete);
            xa58d1d9c6fa55c59.AddColumn(field.Integer);
            goto Label_01F9;
        }

        private void xb65907545d46dd44(EncogWriteHelper xa58d1d9c6fa55c59)
        {
            this.x4ec53e22935ca8a4(xa58d1d9c6fa55c59, "ML", "CONFIG");
            this.x4ec53e22935ca8a4(xa58d1d9c6fa55c59, "ML", "TRAIN");
        }
    }
}

