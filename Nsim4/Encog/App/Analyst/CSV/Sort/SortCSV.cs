namespace Encog.App.Analyst.CSV.Sort
{
    using Encog.App.Analyst.CSV.Basic;
    using Encog.Util.CSV;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class SortCSV : BasicFile
    {
        private readonly List<SortedField> _x0be0482b5fb3b33d = new List<SortedField>();
        private readonly List<LoadedRow> _x4a3f0a05c02f235f = new List<LoadedRow>();

        public void Process(FileInfo inputFile, FileInfo outputFile, bool headers, CSVFormat format)
        {
            base.InputFilename = inputFile;
            base.ExpectInputHeaders = headers;
            base.InputFormat = format;
            this.xcc7d420ca2a80044();
            do
            {
                this.x116e636386480d14();
                this.x64b4cdf32944d344(outputFile);
            }
            while ((((uint) headers) | 1) == 0);
        }

        private void x116e636386480d14()
        {
            IComparer<LoadedRow> comparer = new RowComparator(this);
            this._x4a3f0a05c02f235f.Sort(comparer);
        }

        private void x64b4cdf32944d344(FileInfo x2608fe0a208c787d)
        {
            bool[] flagArray;
            bool flag;
            int num;
            int num2;
            StreamWriter writer = base.PrepareOutputFile(x2608fe0a208c787d);
            if ((((uint) flag) - ((uint) num2)) <= uint.MaxValue)
            {
                flagArray = new bool[base.Count];
            }
            if ((((uint) num) & 0) == 0)
            {
                flag = true;
            }
            base.ResetStatus();
            using (List<LoadedRow>.Enumerator enumerator = this._x4a3f0a05c02f235f.GetEnumerator())
            {
                LoadedRow row;
                StringBuilder builder;
                goto Label_0068;
            Label_004E:
                if (num2 < base.Count)
                {
                    goto Label_00E4;
                }
                writer.WriteLine(builder.ToString());
            Label_0068:
                if (enumerator.MoveNext())
                {
                    goto Label_01F7;
                }
                goto Label_00C5;
            Label_0076:
                if ((((uint) num) - ((uint) flag)) >= 0)
                {
                }
                builder.Append(row.Data[num2]);
            Label_009F:
                num2++;
                goto Label_004E;
            Label_00A7:
                builder.Append("\"");
                goto Label_009F;
            Label_00B8:
                if (flagArray[num2])
                {
                    goto Label_0101;
                }
                goto Label_0076;
            Label_00C5:
                if (-2147483648 != 0)
                {
                    goto Label_021F;
                }
                if (((uint) flag) <= uint.MaxValue)
                {
                    goto Label_01A5;
                }
            Label_00E4:
                if (num2 > 0)
                {
                    goto Label_0158;
                }
                if ((((uint) flag) + ((uint) num2)) >= 0)
                {
                    goto Label_00B8;
                }
            Label_0101:
                builder.Append("\"");
                builder.Append(row.Data[num2]);
                if ((((uint) flag) & 0) != 0)
                {
                    goto Label_01D8;
                }
                if ((((uint) num) + ((uint) num2)) <= uint.MaxValue)
                {
                    goto Label_00A7;
                }
                goto Label_01A5;
            Label_0158:
                builder.Append(",");
                if ((((uint) num) + ((uint) num)) <= uint.MaxValue)
                {
                }
                if (((uint) num2) <= uint.MaxValue)
                {
                    goto Label_00B8;
                }
                goto Label_00E4;
            Label_0196:
                if (flag)
                {
                    goto Label_01A5;
                }
            Label_0199:
                builder = new StringBuilder();
                num2 = 0;
                goto Label_004E;
            Label_01A5:
                num = 0;
            Label_01D8:
                while (num < base.Count)
                {
                    try
                    {
                        string str = row.Data[num];
                        base.InputFormat.Parse(str);
                        flagArray[num] = false;
                    }
                    catch (Exception)
                    {
                        flagArray[num] = true;
                    }
                    num++;
                }
                flag = false;
                goto Label_0199;
            Label_01F7:
                row = enumerator.Current;
                base.UpdateStatus("Writing output");
                goto Label_0196;
            }
        Label_021F:
            base.ReportDone("Writing output");
            writer.Close();
        }

        private void xcc7d420ca2a80044()
        {
            int num;
            base.ResetStatus();
            ReadCSV csv = new ReadCSV(base.InputFilename.ToString(), base.ExpectInputHeaders, base.InputFormat);
            goto Label_00AB;
        Label_0018:
            csv.Close();
            return;
        Label_005B:
            if (!base.ShouldStop())
            {
                base.UpdateStatus("Reading input file");
                LoadedRow item = new LoadedRow(csv);
                this._x4a3f0a05c02f235f.Add(item);
                goto Label_00AB;
            }
        Label_0063:
            base.Count = csv.ColumnCount;
            if (((((uint) num) - ((uint) num)) >= 0) && !base.ExpectInputHeaders)
            {
                goto Label_0018;
            }
            base.InputHeadings = new string[csv.ColumnCount];
            for (num = 0; num < csv.ColumnCount; num++)
            {
                base.InputHeadings[num] = csv.ColumnNames[num];
            }
            if (3 != 0)
            {
                if (2 != 0)
                {
                    goto Label_0018;
                }
                goto Label_005B;
            }
        Label_00AB:
            if (!csv.Next())
            {
                goto Label_0063;
            }
            goto Label_005B;
        }

        public IList<SortedField> SortOrder
        {
            get
            {
                return this._x0be0482b5fb3b33d;
            }
        }
    }
}

