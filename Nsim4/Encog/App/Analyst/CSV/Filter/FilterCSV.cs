namespace Encog.App.Analyst.CSV.Filter
{
    using Encog.App.Analyst.CSV.Basic;
    using Encog.Util.CSV;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class FilterCSV : BasicFile
    {
        private readonly IList<ExcludedField> _x327e2ccdf75911ca = new List<ExcludedField>();
        private int _xa893fbcbca51543c;

        public void Analyze(FileInfo inputFile, bool headers, CSVFormat format)
        {
            base.InputFilename = inputFile;
            base.ExpectInputHeaders = headers;
            base.InputFormat = format;
            base.Analyzed = true;
            base.PerformBasicCounts();
        }

        public void Exclude(int fieldNumber, string fieldValue)
        {
            this._x327e2ccdf75911ca.Add(new ExcludedField(fieldNumber, fieldValue));
        }

        public void Process(FileInfo outputFile)
        {
            StreamWriter writer;
            LoadedRow row;
            ReadCSV csv = new ReadCSV(base.InputFilename.ToString(), base.ExpectInputHeaders, base.InputFormat);
            if (0 == 0)
            {
                goto Label_00B7;
            }
        Label_0023:
            csv.Close();
            return;
        Label_0034:
            writer.Close();
            goto Label_0073;
        Label_003E:
            if (csv.Next())
            {
                goto Label_0062;
            }
        Label_0046:
            base.ReportDone(false);
            if (-1 != 0)
            {
                if (-1 != 0)
                {
                    if (0 != 0)
                    {
                        goto Label_00C6;
                    }
                    goto Label_0034;
                }
                goto Label_0073;
            }
        Label_0054:
            if (0 == 0)
            {
                goto Label_003E;
            }
        Label_0062:
            if (!base.ShouldStop())
            {
                base.UpdateStatus(false);
                if (0 != 0)
                {
                    goto Label_0034;
                }
                row = new LoadedRow(csv);
                goto Label_0076;
            }
            goto Label_0046;
        Label_0073:
            if (0 == 0)
            {
                if (-2147483648 == 0)
                {
                    return;
                }
                goto Label_0023;
            }
        Label_0076:
            if (this.x023aea3c4dad7033(row))
            {
                base.WriteRow(writer, row);
                if (0 == 0)
                {
                    this._xa893fbcbca51543c++;
                    if (0xff == 0)
                    {
                        goto Label_0076;
                    }
                    goto Label_003E;
                }
                if (0 == 0)
                {
                    goto Label_0076;
                }
            }
            else
            {
                goto Label_0054;
            }
        Label_00B7:
            writer = base.PrepareOutputFile(outputFile);
            this._xa893fbcbca51543c = 0;
        Label_00C6:
            base.ResetStatus();
            goto Label_003E;
        }

        private bool x023aea3c4dad7033(LoadedRow xa806b754814b9ae0)
        {
            <>c__DisplayClass1 class2;
            LoadedRow row = xa806b754814b9ae0;
            return this._x327e2ccdf75911ca.All<ExcludedField>(new Func<ExcludedField, bool>(class2.<ShouldProcess>b__0));
        }

        public IList<ExcludedField> Excluded
        {
            get
            {
                return this._x327e2ccdf75911ca;
            }
        }

        public int FilteredRowCount
        {
            get
            {
                return this._xa893fbcbca51543c;
            }
        }
    }
}

