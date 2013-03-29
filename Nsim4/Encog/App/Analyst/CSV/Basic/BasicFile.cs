namespace Encog.App.Analyst.CSV.Basic
{
    using Encog;
    using Encog.App.Analyst.Script;
    using Encog.App.Quant;
    using Encog.Util.CSV;
    using System;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Text;

    public class BasicFile : QuantTask
    {
        private int _x0bbe62a955420d6f;
        private int _x0fc76c1cbf843310;
        private FileInfo _x2359c5c214012e59;
        private int _x27621a3c307a4a9a;
        private CSVFormat _x3bd332f47a4845e2;
        private bool _x43fca1001863b3cd;
        private string[] _x4f6082340db02fc8;
        private bool _x525a82e24ad75a48;
        private bool _x54d89fa16687eadd;
        private bool _x57602a0a0d178a2e;
        private int _x5ddd6074bcb3c34a;
        private IStatusReportable _x64343a0786fb9a3f;
        private CSVFormat _x7f5d219ee339dd39;
        private int _x88770833a11cfa1a;
        [CompilerGenerated]
        private int x04109b657595c91e;
        [CompilerGenerated]
        private AnalystScript xd0e67254b567bc8c;
        private const int xe1f802aa3c709eb6 = 0x2710;

        public BasicFile()
        {
            this.Precision = 10;
            this._x64343a0786fb9a3f = new NullStatusReportable();
            this._x0bbe62a955420d6f = 0x2710;
            if (-2 != 0)
            {
                this._x525a82e24ad75a48 = true;
                this.ResetStatus();
            }
        }

        public static void AppendSeparator(StringBuilder line, CSVFormat format)
        {
            if (line.Length > 0)
            {
                while (!line.ToString().EndsWith(format.Separator))
                {
                    line.Append(format.Separator);
                    break;
                }
            }
        }

        public void PerformBasicCounts()
        {
            int num;
            ReadCSV dcsv;
            if (this._x3bd332f47a4845e2 != null)
            {
                goto Label_00BB;
            }
            goto Label_00EF;
        Label_003F:
            this._x88770833a11cfa1a = num;
            if ((((uint) num) + ((uint) num)) <= uint.MaxValue)
            {
                this._x5ddd6074bcb3c34a = dcsv.ColumnCount;
                this.ReadHeaders(dcsv);
                goto Label_00A7;
            }
        Label_007E:
            if (0 == 0)
            {
                if (0 != 0)
                {
                    goto Label_0084;
                }
                goto Label_003F;
            }
            if (0 != 0)
            {
                goto Label_003F;
            }
        Label_0084:
            if (dcsv.Next())
            {
                while (!this._x57602a0a0d178a2e)
                {
                    this.UpdateStatus(true);
                    num++;
                    if (0 == 0)
                    {
                        goto Label_0084;
                    }
                }
                goto Label_007E;
            }
            if ((((uint) num) - ((uint) num)) >= 0)
            {
                goto Label_003F;
            }
        Label_00A7:
            if (((uint) num) <= uint.MaxValue)
            {
                if (((uint) num) > uint.MaxValue)
                {
                    goto Label_003F;
                }
                dcsv.Close();
                this.ReportDone(true);
                if (0 == 0)
                {
                    return;
                }
            }
            goto Label_00EF;
        Label_00BB:
            this.ResetStatus();
            num = 0;
            dcsv = new ReadCSV(this._x2359c5c214012e59.ToString(), this._x54d89fa16687eadd, this._x7f5d219ee339dd39);
            goto Label_0084;
        Label_00EF:
            this._x3bd332f47a4845e2 = this._x7f5d219ee339dd39;
            goto Label_00BB;
        }

        public StreamWriter PrepareOutputFile(FileInfo outputFile)
        {
            StreamWriter writer2;
            try
            {
                StreamWriter writer;
                StringBuilder builder;
                string str;
                int num;
                string[] strArray;
                int num2;
                outputFile.Delete();
                goto Label_0149;
            Label_000B:
                if ((((uint) num2) + ((uint) num2)) > uint.MaxValue)
                {
                    goto Label_0083;
                }
                if (0 != 0)
                {
                    goto Label_0033;
                }
                num++;
            Label_002A:
                if (num < this._x5ddd6074bcb3c34a)
                {
                    goto Label_0048;
                }
            Label_0033:
                writer.WriteLine(builder.ToString());
                return writer;
            Label_0044:
                num = 0;
                goto Label_002A;
            Label_0048:
                builder.Append("\"field:");
                builder.Append((int) (num + 1));
                builder.Append("\"");
                goto Label_000B;
            Label_0073:
                if (this._x4f6082340db02fc8 != null)
                {
                    goto Label_012D;
                }
                goto Label_0044;
            Label_0083:
                if (num2 < strArray.Length)
                {
                    goto Label_00A1;
                }
                goto Label_0033;
            Label_008D:
                builder.Append("\"");
                num2++;
                goto Label_0083;
            Label_00A1:
                str = strArray[num2];
                if (builder.Length > 0)
                {
                    builder.Append(this._x3bd332f47a4845e2.Separator);
                }
                builder.Append("\"");
                builder.Append(str);
                goto Label_008D;
            Label_00E0:
                num2 = 0;
                goto Label_0083;
            Label_00E7:
                if (0 != 0)
                {
                    goto Label_0101;
                }
                goto Label_00E0;
            Label_00F9:
                if (this._x3bd332f47a4845e2 == null)
                {
                    goto Label_016B;
                }
            Label_0101:
                if (!this._x525a82e24ad75a48)
                {
                    return writer;
                }
            Label_010C:
                builder = new StringBuilder();
                if ((((uint) num) + ((uint) num2)) >= 0)
                {
                    goto Label_0073;
                }
            Label_012D:
                strArray = this._x4f6082340db02fc8;
                if ((((uint) num) & 0) == 0)
                {
                    goto Label_00E7;
                }
            Label_0149:
                writer = new StreamWriter(outputFile.OpenWrite());
                if ((((uint) num2) & 0) != 0)
                {
                    goto Label_010C;
                }
                goto Label_00F9;
            Label_016B:
                this._x3bd332f47a4845e2 = this._x7f5d219ee339dd39;
                if ((((uint) num) - ((uint) num)) > uint.MaxValue)
                {
                    goto Label_010C;
                }
                goto Label_0101;
            }
            catch (IOException exception)
            {
                throw new QuantError(exception);
            }
            return writer2;
        }

        public void ReadHeaders(ReadCSV csv)
        {
            int num;
            int num2;
            DataField[] fieldArray;
            int num3;
            if (!this._x54d89fa16687eadd)
            {
                this._x4f6082340db02fc8 = new string[csv.ColumnCount];
                num2 = 0;
                if (-2147483648 == 0)
                {
                    return;
                }
                if ((((uint) num) - ((uint) num)) >= 0)
                {
                    goto Label_0010;
                }
            }
            this._x4f6082340db02fc8 = new string[csv.ColumnCount];
            for (num = 0; num < csv.ColumnCount; num++)
            {
                this._x4f6082340db02fc8[num] = csv.ColumnNames[num];
            }
            return;
        Label_0010:
            if (this.Script != null)
            {
                goto Label_007A;
            }
        Label_0018:
            if (num2 >= csv.ColumnCount)
            {
                if (((uint) num) >= 0)
                {
                    return;
                }
                if ((((uint) num) | uint.MaxValue) == 0)
                {
                    goto Label_0086;
                }
            }
            else
            {
                this._x4f6082340db02fc8[num2] = "field:" + num2;
                num2++;
                goto Label_0018;
            }
        Label_007A:
            fieldArray = this.Script.Fields;
        Label_0086:
            num3 = 0;
            if (((uint) num3) < 0)
            {
                goto Label_0018;
            }
        Label_0071:
            if (num3 < fieldArray.Length)
            {
                DataField field = fieldArray[num3];
                if ((((uint) num) + ((uint) num3)) <= uint.MaxValue)
                {
                    this._x4f6082340db02fc8[num2++] = field.Name;
                    num3++;
                    goto Label_0071;
                }
                goto Label_0010;
            }
            goto Label_0018;
        }

        public void ReportDone(bool isAnalyzing)
        {
            this._x64343a0786fb9a3f.Report(this._x88770833a11cfa1a, this._x88770833a11cfa1a, isAnalyzing ? "Done analyzing" : "Done processing");
        }

        public void ReportDone(string task)
        {
            this._x64343a0786fb9a3f.Report(this._x88770833a11cfa1a, this._x88770833a11cfa1a, task);
        }

        public void RequestStop()
        {
            this._x57602a0a0d178a2e = true;
        }

        public void ResetStatus()
        {
            this._x0fc76c1cbf843310 = 0;
            this._x27621a3c307a4a9a = 0;
        }

        public bool ShouldStop()
        {
            return this._x57602a0a0d178a2e;
        }

        public sealed override string ToString()
        {
            StringBuilder builder = new StringBuilder("[");
            builder.Append(base.GetType().Name);
            if (-1 != 0)
            {
                builder.Append(" inputFilename=");
                builder.Append(this._x2359c5c214012e59);
                builder.Append(", recordCount=");
            }
            builder.Append(this._x88770833a11cfa1a);
            builder.Append("]");
            return builder.ToString();
        }

        public void UpdateStatus(bool isAnalyzing)
        {
            this.UpdateStatus(isAnalyzing ? "Analyzing" : "Processing");
        }

        public void UpdateStatus(string task)
        {
            bool flag = false;
            if (this._x27621a3c307a4a9a != 0)
            {
                goto Label_0056;
            }
            flag = true;
            if (0xff == 0)
            {
                goto Label_0056;
            }
            if (0 == 0)
            {
                if ((((uint) flag) + ((uint) flag)) < 0)
                {
                    return;
                }
                goto Label_0056;
            }
        Label_002A:
            this._x64343a0786fb9a3f.Report(this._x88770833a11cfa1a, this._x27621a3c307a4a9a, task);
            return;
        Label_0056:
            this._x27621a3c307a4a9a++;
            this._x0fc76c1cbf843310++;
            if (this._x0fc76c1cbf843310 >= this._x0bbe62a955420d6f)
            {
                this._x0fc76c1cbf843310 = 0;
                flag = true;
            }
            if (!flag)
            {
                if (((uint) flag) <= uint.MaxValue)
                {
                    return;
                }
                goto Label_0056;
            }
            goto Label_002A;
        }

        public void ValidateAnalyzed()
        {
            if (!this._x43fca1001863b3cd)
            {
                throw new QuantError("File must be analyzed first.");
            }
        }

        public void WriteRow(StreamWriter tw, LoadedRow row)
        {
            string[] strArray;
            int num;
            StringBuilder line = new StringBuilder();
            if (0 == 0)
            {
                goto Label_004B;
            }
        Label_000F:
            while (num >= strArray.Length)
            {
                tw.WriteLine(line.ToString());
                if (-2 != 0)
                {
                    if (8 != 0)
                    {
                        return;
                    }
                    goto Label_004B;
                }
            }
            string str = strArray[num];
        Label_002E:
            AppendSeparator(line, this._x3bd332f47a4845e2);
            line.Append(str);
            num++;
            goto Label_000F;
        Label_004B:
            strArray = row.Data;
            num = 0;
            if (2 == 0)
            {
                goto Label_002E;
            }
            goto Label_000F;
        }

        public bool Analyzed
        {
            get
            {
                return this._x43fca1001863b3cd;
            }
            set
            {
                this._x43fca1001863b3cd = value;
            }
        }

        public int Count
        {
            get
            {
                return this._x5ddd6074bcb3c34a;
            }
            set
            {
                this._x5ddd6074bcb3c34a = value;
            }
        }

        public bool ExpectInputHeaders
        {
            get
            {
                return this._x54d89fa16687eadd;
            }
            set
            {
                this._x54d89fa16687eadd = value;
            }
        }

        public FileInfo InputFilename
        {
            get
            {
                return this._x2359c5c214012e59;
            }
            set
            {
                this._x2359c5c214012e59 = value;
            }
        }

        public CSVFormat InputFormat
        {
            get
            {
                return this._x7f5d219ee339dd39;
            }
            set
            {
                this._x7f5d219ee339dd39 = value;
            }
        }

        public string[] InputHeadings
        {
            get
            {
                return this._x4f6082340db02fc8;
            }
            set
            {
                this._x4f6082340db02fc8 = value;
            }
        }

        public CSVFormat OutputFormat
        {
            get
            {
                return this._x3bd332f47a4845e2;
            }
            set
            {
                this._x3bd332f47a4845e2 = value;
            }
        }

        public int Precision
        {
            [CompilerGenerated]
            get
            {
                return this.x04109b657595c91e;
            }
            [CompilerGenerated]
            set
            {
                this.x04109b657595c91e = value;
            }
        }

        public bool ProduceOutputHeaders
        {
            get
            {
                return this._x525a82e24ad75a48;
            }
            set
            {
                this._x525a82e24ad75a48 = value;
            }
        }

        public int RecordCount
        {
            get
            {
                if (!this._x43fca1001863b3cd)
                {
                    throw new QuantError("Must analyze file first.");
                }
                return this._x88770833a11cfa1a;
            }
            set
            {
                this._x88770833a11cfa1a = value;
            }
        }

        public IStatusReportable Report
        {
            get
            {
                return this._x64343a0786fb9a3f;
            }
            set
            {
                this._x64343a0786fb9a3f = value;
            }
        }

        public int ReportInterval
        {
            get
            {
                return this._x0bbe62a955420d6f;
            }
            set
            {
                this._x0bbe62a955420d6f = value;
            }
        }

        public AnalystScript Script
        {
            [CompilerGenerated]
            get
            {
                return this.xd0e67254b567bc8c;
            }
            [CompilerGenerated]
            set
            {
                this.xd0e67254b567bc8c = value;
            }
        }
    }
}

