namespace Encog.App.Quant.Indicators
{
    using Encog.App.Analyst.CSV.Basic;
    using Encog.App.Quant;
    using Encog.Util.CSV;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class ProcessIndicators : BasicCachedFile
    {
        public void Process(FileInfo output)
        {
            base.ValidateAnalyzed();
            this.x0193cbe69ee46985();
            this.x08af8e36ac9914b5();
            this.x6cf5ef95c0436286();
            this.x1946c594c0dc53f6(output);
        }

        public void RenameColumn(int index, string newName)
        {
            base.ColumnMapping.Remove(base.Columns[index].Name);
            base.Columns[index].Name = newName;
            base.ColumnMapping[newName] = base.Columns[index];
        }

        private void x0193cbe69ee46985()
        {
            foreach (BaseCachedColumn column in base.Columns)
            {
                column.Allocate(base.RecordCount);
            }
        }

        private void x08af8e36ac9914b5()
        {
            ReadCSV dcsv = null;
            try
            {
                int num;
                double num2;
                dcsv = new ReadCSV(base.InputFilename.ToString(), base.ExpectInputHeaders, base.InputFormat);
                goto Label_006B;
            Label_0021:
                num++;
                if ((((uint) num2) & 0) == 0)
                {
                }
            Label_005E:
                while (dcsv.Next())
                {
                    if (!base.ShouldStop())
                    {
                        goto Label_0075;
                    }
                    if ((((uint) num2) + ((uint) num)) <= uint.MaxValue)
                    {
                        break;
                    }
                }
                return;
            Label_006B:
                base.ResetStatus();
                num = 0;
                goto Label_005E;
            Label_0075:
                base.UpdateStatus("Reading data");
                using (IEnumerator<BaseCachedColumn> enumerator = base.Columns.GetEnumerator())
                {
                    BaseCachedColumn column;
                    FileData data;
                Label_008F:
                    if (enumerator.MoveNext() || ((((uint) num) + ((uint) num)) > uint.MaxValue))
                    {
                        goto Label_011D;
                    }
                    goto Label_0021;
                Label_00BD:
                    if (column.Input)
                    {
                        goto Label_00D8;
                    }
                    goto Label_008F;
                Label_00C7:
                    if (0 == 0)
                    {
                    }
                    goto Label_008F;
                Label_00CC:
                    if (column is FileData)
                    {
                        goto Label_00BD;
                    }
                    goto Label_00C7;
                Label_00D8:
                    data = (FileData) column;
                    string str = dcsv.Get(data.Index);
                    num2 = base.InputFormat.Parse(str);
                    data.Data[num] = num2;
                    goto Label_008F;
                Label_0111:
                    if (0 == 0)
                    {
                        goto Label_00CC;
                    }
                    goto Label_00BD;
                Label_011D:
                    column = enumerator.Current;
                    goto Label_0111;
                }
            }
            finally
            {
                base.ReportDone("Reading data");
                if (dcsv != null)
                {
                    dcsv.Close();
                }
            }
        }

        private void x1946c594c0dc53f6(FileInfo xb41a802ca5fde63b)
        {
            StreamWriter writer = null;
            try
            {
                StringBuilder builder;
                int num;
                int num2;
                int num3;
                double num4;
                base.ResetStatus();
                goto Label_0216;
            Label_000D:
                if (((((uint) num4) - ((uint) num)) >= 0) && ((((uint) num4) & 0) == 0))
                {
                    return;
                }
            Label_003C:
                base.UpdateStatus("Writing data");
                StringBuilder builder2 = new StringBuilder();
            Label_004E:
                using (IEnumerator<BaseCachedColumn> enumerator2 = base.Columns.GetEnumerator())
                {
                    BaseCachedColumn current;
                    goto Label_00A2;
                Label_005D:
                    if (((uint) num2) > uint.MaxValue)
                    {
                        goto Label_00A2;
                    }
                    goto Label_007B;
                Label_0071:
                    if (builder2.Length > 0)
                    {
                        goto Label_00C1;
                    }
                Label_007B:
                    num4 = current.Data[num3];
                    builder2.Append(base.InputFormat.Format(num4, base.Precision));
                Label_00A2:
                    if (!enumerator2.MoveNext())
                    {
                        goto Label_00E7;
                    }
                    current = enumerator2.Current;
                    if (!current.Output)
                    {
                        goto Label_00A2;
                    }
                    goto Label_0071;
                Label_00C1:
                    builder2.Append(base.InputFormat.Separator);
                    goto Label_005D;
                }
            Label_00E7:
                writer.WriteLine(builder2.ToString());
                num3++;
            Label_00FA:
                if (num3 <= num2)
                {
                    goto Label_003C;
                }
                goto Label_000D;
            Label_010D:
                num2 = this.x4b767d45405143d9;
                num3 = num;
                goto Label_00FA;
            Label_011A:
                num = this.x12f8e011f246374c;
                goto Label_0239;
            Label_0126:
                builder = new StringBuilder();
                using (IEnumerator<BaseCachedColumn> enumerator = base.Columns.GetEnumerator())
                {
                    BaseCachedColumn column;
                    goto Label_0154;
                Label_013B:
                    builder.Append(column.Name);
                    builder.Append("\"");
                Label_0154:
                    if (enumerator.MoveNext())
                    {
                        goto Label_01A3;
                    }
                    goto Label_01DD;
                Label_0164:
                    if (builder.Length > 0)
                    {
                        goto Label_01B5;
                    }
                    if (((uint) num2) <= uint.MaxValue)
                    {
                    }
                Label_017F:
                    builder.Append("\"");
                    if ((((uint) num3) + ((uint) num3)) >= 0)
                    {
                        goto Label_01C9;
                    }
                Label_01A3:
                    column = enumerator.Current;
                    if (!column.Output)
                    {
                        goto Label_0154;
                    }
                    goto Label_0164;
                Label_01B5:
                    builder.Append(base.InputFormat.Separator);
                    goto Label_017F;
                Label_01C9:
                    if (0 == 0)
                    {
                        goto Label_013B;
                    }
                }
            Label_01DD:
                writer.WriteLine(builder.ToString());
                goto Label_011A;
            Label_01EE:
                if (base.ExpectInputHeaders)
                {
                    goto Label_0126;
                }
                if ((((uint) num3) | 8) == 0)
                {
                    goto Label_004E;
                }
                goto Label_0224;
            Label_0216:
                writer = new StreamWriter(xb41a802ca5fde63b.Create());
                goto Label_01EE;
            Label_0224:
                if (((uint) num) <= uint.MaxValue)
                {
                    goto Label_011A;
                }
            Label_0239:
                if (((uint) num2) <= uint.MaxValue)
                {
                    goto Label_010D;
                }
                goto Label_003C;
            }
            catch (IOException exception)
            {
                throw new QuantError(exception);
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }
        }

        private void x6cf5ef95c0436286()
        {
            using (IEnumerator<BaseCachedColumn> enumerator = base.Columns.GetEnumerator())
            {
                BaseCachedColumn column;
                Indicator indicator;
                goto Label_0017;
            Label_0010:
                if (-2147483648 == 0)
                {
                    goto Label_004A;
                }
            Label_0017:
                if (enumerator.MoveNext())
                {
                    goto Label_0080;
                }
                return;
            Label_0029:
                if (15 != 0)
                {
                    goto Label_0017;
                }
            Label_0034:
                if (!column.Output)
                {
                    if (-2147483648 == 0)
                    {
                        goto Label_0063;
                    }
                    if (4 != 0)
                    {
                        goto Label_0010;
                    }
                }
            Label_004A:
                if (!(column is Indicator))
                {
                    if (0 == 0)
                    {
                        if (0 != 0)
                        {
                        }
                        goto Label_0017;
                    }
                    if (15 != 0)
                    {
                        goto Label_004A;
                    }
                }
            Label_0063:
                indicator = (Indicator) column;
                indicator.Calculate(base.ColumnMapping, base.RecordCount);
                goto Label_0029;
            Label_0080:
                column = enumerator.Current;
                goto Label_0034;
            }
        }

        private int x12f8e011f246374c
        {
            get
            {
                int num = 0;
                using (IEnumerator<BaseCachedColumn> enumerator = base.Columns.GetEnumerator())
                {
                    BaseCachedColumn current;
                    Indicator indicator;
                    goto Label_0027;
                Label_0010:
                    num = Math.Max(indicator.BeginningIndex, num);
                    goto Label_0027;
                Label_001F:
                    if (current is Indicator)
                    {
                        goto Label_005E;
                    }
                Label_0027:
                    while (!enumerator.MoveNext())
                    {
                        if (((uint) num) <= uint.MaxValue)
                        {
                            return num;
                        }
                    }
                    current = enumerator.Current;
                    if ((((uint) num) & 0) == 0)
                    {
                        goto Label_001F;
                    }
                Label_005E:
                    indicator = (Indicator) current;
                    goto Label_0010;
                }
            }
        }

        private int x4b767d45405143d9
        {
            get
            {
                int num = base.RecordCount - 1;
                foreach (BaseCachedColumn column in base.Columns)
                {
                    if (!(column is Indicator))
                    {
                        continue;
                    }
                    Indicator indicator = (Indicator) column;
                Label_002D:
                    num = Math.Min(indicator.EndingIndex, num);
                }
                if ((((uint) num) - ((uint) num)) < 0)
                {
                    goto Label_002D;
                }
                return num;
            }
        }
    }
}

