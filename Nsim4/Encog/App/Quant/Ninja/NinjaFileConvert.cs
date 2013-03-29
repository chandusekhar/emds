namespace Encog.App.Quant.Ninja
{
    using Encog.App.Analyst.CSV.Basic;
    using Encog.Util.CSV;
    using System;
    using System.IO;
    using System.Text;

    public class NinjaFileConvert : BasicCachedFile
    {
        public override void Analyze(FileInfo input, bool headers, CSVFormat format)
        {
            base.Analyze(input, headers, format);
        }

        public void Process(string target)
        {
            TextWriter writer;
            StringBuilder builder;
            ReadCSV csv = new ReadCSV(base.InputFilename.ToString(), base.ExpectInputHeaders, base.InputFormat);
            if (0 == 0)
            {
                goto Label_01BE;
            }
            if (4 != 0)
            {
                goto Label_0038;
            }
        Label_002A:
            if (0 != 0)
            {
                goto Label_01D2;
            }
            writer.Close();
            return;
        Label_0038:
            if (0 != 0)
            {
                goto Label_01DA;
            }
            writer.WriteLine(builder.ToString());
        Label_004A:
            if (csv.Next())
            {
                goto Label_01DA;
            }
            base.ReportDone(false);
            csv.Close();
            goto Label_002A;
        Label_0154:
            builder.Append(base.GetColumnData("date", csv));
            builder.Append(" ");
            builder.Append(base.GetColumnData("time", csv));
        Label_0186:
            builder.Append(";");
            builder.Append(base.InputFormat.Format(double.Parse(base.GetColumnData("open", csv)), base.Precision));
            if (0 == 0)
            {
                builder.Append(";");
                builder.Append(base.InputFormat.Format(double.Parse(base.GetColumnData("high", csv)), base.Precision));
                builder.Append(";");
                builder.Append(base.InputFormat.Format(double.Parse(base.GetColumnData("low", csv)), base.Precision));
                builder.Append(";");
                builder.Append(base.InputFormat.Format(double.Parse(base.GetColumnData("close", csv)), base.Precision));
                if (0 == 0)
                {
                    builder.Append(";");
                    builder.Append(base.InputFormat.Format(double.Parse(base.GetColumnData("volume", csv)), base.Precision));
                }
                goto Label_0038;
            }
        Label_01BE:
            if (0x7fffffff == 0)
            {
                goto Label_0154;
            }
            writer = new StreamWriter(target);
            base.ResetStatus();
        Label_01D2:
            if (0 != 0)
            {
                goto Label_0186;
            }
            goto Label_004A;
        Label_01DA:
            builder = new StringBuilder();
            base.UpdateStatus(false);
            goto Label_0154;
        }
    }
}

