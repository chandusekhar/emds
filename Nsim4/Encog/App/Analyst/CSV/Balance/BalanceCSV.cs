namespace Encog.App.Analyst.CSV.Balance
{
    using Encog.App.Analyst.CSV.Basic;
    using Encog.Util.CSV;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class BalanceCSV : BasicFile
    {
        private IDictionary<string, int> _x4de68924842740c8;

        public void Analyze(FileInfo inputFile, bool headers, CSVFormat format)
        {
            base.InputFilename = inputFile;
            base.ExpectInputHeaders = headers;
            base.InputFormat = format;
            base.Analyzed = true;
            base.PerformBasicCounts();
        }

        public string DumpCounts()
        {
            StringBuilder builder = new StringBuilder();
            using (IEnumerator<string> enumerator = this._x4de68924842740c8.Keys.GetEnumerator())
            {
                string current;
                goto Label_004C;
            Label_0019:
                builder.Append(current);
                builder.Append(" : ");
                builder.Append(this._x4de68924842740c8[current]);
                builder.Append("\n");
            Label_004C:
                if (!enumerator.MoveNext())
                {
                    if (0 != 0)
                    {
                    }
                }
                else
                {
                    current = enumerator.Current;
                    goto Label_0019;
                }
            }
            return builder.ToString();
        }

        public void Process(FileInfo outputFile, int targetField, int countPer)
        {
            ReadCSV dcsv;
            LoadedRow row;
            string str;
            int num;
            base.ValidateAnalyzed();
            StreamWriter tw = base.PrepareOutputFile(outputFile);
            this._x4de68924842740c8 = new Dictionary<string, int>();
            goto Label_0129;
        Label_0019:
            if (dcsv.Next())
            {
                goto Label_0056;
            }
        Label_0021:
            base.ReportDone(false);
            dcsv.Close();
            tw.Close();
            if ((((uint) countPer) | 0x7fffffff) == 0)
            {
                goto Label_0106;
            }
            if (8 == 0)
            {
                goto Label_0129;
            }
            return;
        Label_0056:
            if (!base.ShouldStop())
            {
                row = new LoadedRow(dcsv);
                base.UpdateStatus(false);
                goto Label_00FD;
            }
            goto Label_0021;
        Label_00AC:
            num = this._x4de68924842740c8[str];
        Label_00BA:
            if (num < countPer)
            {
                base.WriteRow(tw, row);
                num++;
            }
            this._x4de68924842740c8[str] = num;
            if ((((uint) countPer) + ((uint) num)) >= 0)
            {
                goto Label_0019;
            }
            if ((((uint) num) - ((uint) targetField)) <= uint.MaxValue)
            {
                goto Label_0056;
            }
        Label_00FD:
            str = row.Data[targetField];
        Label_0106:
            if (this._x4de68924842740c8.ContainsKey(str))
            {
                goto Label_00AC;
            }
            goto Label_0158;
        Label_0129:
            dcsv = new ReadCSV(base.InputFilename.ToString(), base.ExpectInputHeaders, base.InputFormat);
            if (((uint) num) >= 0)
            {
                base.ResetStatus();
                goto Label_0019;
            }
        Label_0158:
            if ((((uint) num) - ((uint) countPer)) <= uint.MaxValue)
            {
                num = 0;
                if (0xff != 0)
                {
                }
                goto Label_00BA;
            }
            goto Label_00AC;
        }

        public IDictionary<string, int> Counts
        {
            get
            {
                return this._x4de68924842740c8;
            }
        }
    }
}

