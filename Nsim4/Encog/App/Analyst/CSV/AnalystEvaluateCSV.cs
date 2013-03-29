namespace Encog.App.Analyst.CSV
{
    using Encog.App.Analyst;
    using Encog.App.Analyst.CSV.Basic;
    using Encog.App.Analyst.CSV.Normalize;
    using Encog.App.Analyst.Script.Normalize;
    using Encog.App.Analyst.Util;
    using Encog.App.Quant;
    using Encog.ML;
    using Encog.ML.Data;
    using Encog.ML.Data.Basic;
    using Encog.Util.Arrayutil;
    using Encog.Util.CSV;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class AnalystEvaluateCSV : BasicFile
    {
        private int _x1402a42b31a31090;
        private int _x146688677da5adf5;
        private EncogAnalyst _x554f16462d8d4675;
        private TimeSeriesUtil _x7acb8518c8ed6133;
        private CSVHeaders _xc5416b6511261016;

        public void Analyze(EncogAnalyst theAnalyst, FileInfo inputFile, bool headers, CSVFormat format)
        {
            base.InputFilename = inputFile;
            if ((((uint) headers) & 0) != 0)
            {
                goto Label_0063;
            }
        Label_005C:
            base.ExpectInputHeaders = headers;
        Label_0063:
            base.InputFormat = format;
            base.Analyzed = true;
            this._x554f16462d8d4675 = theAnalyst;
            base.PerformBasicCounts();
            if (((uint) headers) >= 0)
            {
                this._x146688677da5adf5 = base.InputHeadings.Length;
                this._x1402a42b31a31090 = this._x554f16462d8d4675.DetermineOutputFieldCount();
                this._xc5416b6511261016 = new CSVHeaders(base.InputHeadings);
                this._x7acb8518c8ed6133 = new TimeSeriesUtil(this._x554f16462d8d4675, false, this._xc5416b6511261016.Headers);
                if (0 != 0)
                {
                    goto Label_005C;
                }
            }
        }

        public void Process(FileInfo outputFile, IMLMethod method)
        {
            IMLData data;
            LoadedRow row;
            double[] numArray;
            IMLData data2;
            int num2;
            int num3;
            double num4;
            ReadCSV csv = new ReadCSV(base.InputFilename.ToString(), base.ExpectInputHeaders, base.InputFormat);
            int outputLength = this._x554f16462d8d4675.DetermineTotalInputFieldCount();
            StreamWriter tw = this.xf911a8958011bd6d(outputFile);
            base.ResetStatus();
            goto Label_0270;
        Label_0042:
            if ((((uint) num4) - ((uint) outputLength)) < 0)
            {
                goto Label_02CF;
            }
            using (IEnumerator<AnalystField> enumerator = this._x554f16462d8d4675.Script.Normalize.NormalizedFields.GetEnumerator())
            {
                AnalystField field;
                ClassItem item;
                goto Label_0087;
            Label_007B:
                if (field.Output)
                {
                    goto Label_012C;
                }
            Label_0087:
                if (enumerator.MoveNext())
                {
                    goto Label_0226;
                }
                goto Label_0267;
            Label_0098:
                if ((this._xc5416b6511261016.Find(field.Name) == -1) && (((uint) num3) >= 0))
                {
                    goto Label_0087;
                }
                goto Label_007B;
            Label_00C4:
                if (((uint) num2) >= 0)
                {
                    if (-2147483648 != 0)
                    {
                    }
                    num4 = field.DeNormalize(num4);
                    row.Data[num2++] = base.InputFormat.Format(num4, base.Precision);
                }
                if ((((uint) num4) | 3) == 0)
                {
                    goto Label_0234;
                }
                goto Label_0087;
            Label_012C:
                if (field.Classify)
                {
                    goto Label_01F8;
                }
            Label_0138:
                num4 = data[num3++];
                goto Label_00C4;
            Label_0156:
                row.Data[num2++] = item.Name;
                goto Label_0087;
            Label_0171:
                row.Data[num2++] = "?Unknown?";
                goto Label_0087;
            Label_018A:
                if (item == null)
                {
                    goto Label_0171;
                }
                if ((((uint) num3) + ((uint) num3)) >= 0)
                {
                    goto Label_01DB;
                }
            Label_01A6:
                num3 += field.ColumnsNeeded;
                if (((uint) num2) <= uint.MaxValue)
                {
                    goto Label_018A;
                }
                if (0 != 0)
                {
                    goto Label_0234;
                }
                if ((((uint) num2) & 0) == 0)
                {
                    goto Label_0171;
                }
            Label_01DB:
                if ((((uint) num3) - ((uint) num3)) >= 0)
                {
                    goto Label_0156;
                }
                goto Label_0138;
            Label_01F8:
                item = field.DetermineClass(num3, data.Data);
                if ((((uint) outputLength) | 0xfffffffe) != 0)
                {
                    goto Label_01A6;
                }
                goto Label_0138;
            Label_0226:
                field = enumerator.Current;
                goto Label_0098;
            Label_0234:
                if ((((uint) num3) - ((uint) outputLength)) >= 0)
                {
                    goto Label_007B;
                }
                goto Label_012C;
            }
        Label_0267:
            base.WriteRow(tw, row);
        Label_0270:
            if (csv.Next())
            {
                base.UpdateStatus(false);
                goto Label_03BA;
            }
            base.ReportDone(false);
            tw.Close();
            if (-1 == 0)
            {
                goto Label_0267;
            }
            csv.Close();
            if (2 != 0)
            {
                return;
            }
            goto Label_0042;
        Label_02B1:
            data = ((IMLRegression) method).Compute(data2);
        Label_02BF:
            num2 = this._x146688677da5adf5;
            num3 = 0;
            goto Label_0042;
        Label_02CF:
            data[0] = ((IMLClassification) method).Classify(data2);
            goto Label_02BF;
        Label_02FE:
            if (method is IMLRegression)
            {
                goto Label_02B1;
            }
            data = new BasicMLData(1);
            goto Label_03A2;
        Label_0312:
            if (numArray == null)
            {
                goto Label_0267;
            }
            data2 = new BasicMLData(numArray);
            if ((((uint) num4) + ((uint) num4)) >= 0)
            {
                if (method is IMLClassification)
                {
                    goto Label_02FE;
                }
                if ((((uint) num4) | 0x7fffffff) == 0)
                {
                    goto Label_03BA;
                }
                goto Label_02B1;
            }
        Label_0387:
            if ((((uint) num3) + ((uint) outputLength)) >= 0)
            {
                if ((((uint) num4) - ((uint) num4)) < 0)
                {
                    goto Label_0312;
                }
                goto Label_02FE;
            }
        Label_03A2:
            if ((((uint) outputLength) + ((uint) num4)) >= 0)
            {
                if ((((uint) num3) + ((uint) num4)) >= 0)
                {
                    goto Label_02CF;
                }
                goto Label_02B1;
            }
        Label_03BA:
            row = new LoadedRow(csv, this._x1402a42b31a31090);
            numArray = AnalystNormalizeCSV.ExtractFields(this._x554f16462d8d4675, this._xc5416b6511261016, csv, outputLength, true);
            if ((((uint) num3) >= 0) && (this._x7acb8518c8ed6133.TotalDepth <= 1))
            {
                if ((((uint) outputLength) & 0) == 0)
                {
                    goto Label_0312;
                }
                goto Label_0387;
            }
            numArray = this._x7acb8518c8ed6133.Process(numArray);
            goto Label_0312;
        }

        private StreamWriter xf911a8958011bd6d(FileInfo x2608fe0a208c787d)
        {
            StreamWriter writer2;
            try
            {
                StreamWriter writer;
                StringBuilder builder;
                string str;
                string[] strArray;
                int num;
                x2608fe0a208c787d.Delete();
                if ((((uint) num) & 0) == 0)
                {
                    goto Label_0196;
                }
            Label_001D:
                if (num < strArray.Length)
                {
                    goto Label_012D;
                }
                if (-2 == 0)
                {
                    return writer2;
                }
                using (IEnumerator<AnalystField> enumerator = this._x554f16462d8d4675.Script.Normalize.NormalizedFields.GetEnumerator())
                {
                    AnalystField field;
                    goto Label_005B;
                Label_0050:
                    if (!field.Ignored)
                    {
                        goto Label_00F3;
                    }
                Label_005B:
                    if (!enumerator.MoveNext() && (0 == 0))
                    {
                        goto Label_0119;
                    }
                    goto Label_00CF;
                Label_006F:
                    if (1 != 0)
                    {
                        goto Label_005B;
                    }
                Label_0078:
                    if (field.Output)
                    {
                        goto Label_0050;
                    }
                    if (0xff != 0)
                    {
                        goto Label_005B;
                    }
                    if (((uint) num) >= 0)
                    {
                        goto Label_0050;
                    }
                    goto Label_00CF;
                Label_009B:
                    builder.Append("\"Output:");
                    builder.Append(CSVHeaders.TagColumn(field.Name, 0, field.TimeSlice, false));
                    builder.Append("\"");
                    goto Label_006F;
                Label_00CF:
                    field = enumerator.Current;
                    if ((((uint) num) & 0) == 0)
                    {
                        goto Label_0078;
                    }
                    goto Label_0050;
                Label_00F3:
                    BasicFile.AppendSeparator(builder, base.OutputFormat);
                    goto Label_009B;
                }
            Label_0119:
                writer.WriteLine(builder.ToString());
                return writer;
            Label_012D:
                str = strArray[num];
                BasicFile.AppendSeparator(builder, base.OutputFormat);
                builder.Append("\"");
            Label_014B:
                builder.Append(str);
                builder.Append("\"");
                num++;
                goto Label_017E;
            Label_0167:
                strArray = base.InputHeadings;
                num = 0;
                if (-2 == 0)
                {
                    goto Label_014B;
                }
                goto Label_001D;
            Label_017E:
                if ((((uint) num) - ((uint) num)) >= 0)
                {
                    goto Label_001D;
                }
            Label_0196:
                writer = new StreamWriter(x2608fe0a208c787d.OpenWrite());
                if (!base.ProduceOutputHeaders)
                {
                    return writer;
                }
                builder = new StringBuilder();
                if ((((uint) num) + ((uint) num)) >= 0)
                {
                    goto Label_0167;
                }
                goto Label_001D;
            }
            catch (IOException exception)
            {
                throw new QuantError(exception);
            }
            return writer2;
        }
    }
}

