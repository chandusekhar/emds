namespace Encog.App.Analyst.CSV.Normalize
{
    using Encog;
    using Encog.App.Analyst;
    using Encog.App.Analyst.CSV;
    using Encog.App.Analyst.CSV.Basic;
    using Encog.App.Analyst.Missing;
    using Encog.App.Analyst.Script.Normalize;
    using Encog.App.Analyst.Util;
    using Encog.App.Quant;
    using Encog.Util.Arrayutil;
    using Encog.Util.CSV;
    using Encog.Util.Logging;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class AnalystNormalizeCSV : BasicFile
    {
        private EncogAnalyst _x554f16462d8d4675;
        private TimeSeriesUtil _x7acb8518c8ed6133;
        private CSVHeaders _xc5416b6511261016;

        public void Analyze(FileInfo inputFilename, bool expectInputHeaders, CSVFormat inputFormat, EncogAnalyst theAnalyst)
        {
            base.InputFilename = inputFilename;
            if (1 != 0)
            {
                base.InputFormat = inputFormat;
                base.ExpectInputHeaders = expectInputHeaders;
                this._x554f16462d8d4675 = theAnalyst;
                base.Analyzed = true;
                this._xc5416b6511261016 = new CSVHeaders(inputFilename, expectInputHeaders, inputFormat);
                foreach (AnalystField field in this._x554f16462d8d4675.Script.Normalize.NormalizedFields)
                {
                    field.Init();
                }
            }
            this._x7acb8518c8ed6133 = new TimeSeriesUtil(this._x554f16462d8d4675, true, this._xc5416b6511261016.Headers);
            if (1 != 0)
            {
            }
        }

        public static double[] ExtractFields(EncogAnalyst analyst, CSVHeaders headers, ReadCSV csv, int outputLength, bool skipOutput)
        {
            double[] numArray = new double[outputLength];
            int num = 0;
            using (IEnumerator<AnalystField> enumerator = analyst.Script.Normalize.NormalizedFields.GetEnumerator())
            {
                AnalystField field;
                int num2;
                string str;
                IHandleMissingValues values;
                double[] numArray2;
                int num3;
                double num4;
                double num5;
                double[] numArray4;
                double[] numArray5;
                int num6;
                goto Label_0070;
            Label_0022:
                if (!skipOutput)
                {
                    goto Label_02B7;
                }
            Label_0029:
                if ((((uint) skipOutput) + ((uint) num6)) > uint.MaxValue)
                {
                    goto Label_00B1;
                }
                goto Label_0070;
            Label_0043:
                if ((((uint) num4) - ((uint) outputLength)) > uint.MaxValue)
                {
                    goto Label_0022;
                }
                if (((uint) num3) > uint.MaxValue)
                {
                    goto Label_022A;
                }
            Label_0070:
                if (enumerator.MoveNext())
                {
                    goto Label_02CD;
                }
                goto Label_01C2;
            Label_007E:
                if (((uint) num2) > uint.MaxValue)
                {
                    goto Label_021B;
                }
                goto Label_0043;
            Label_009A:
                if (!field.Output)
                {
                    goto Label_02B7;
                }
                goto Label_0022;
            Label_00B1:
                num5 = numArray5[num6];
            Label_00B9:
                numArray[num++] = num5;
                num6++;
            Label_00C8:
                if (num6 < numArray5.Length)
                {
                    goto Label_00B1;
                }
                if ((((uint) num3) + ((uint) num5)) >= 0)
                {
                    goto Label_0116;
                }
            Label_00E8:
                numArray5 = field.Encode(str.Trim());
                num6 = 0;
                if ((((uint) num6) + ((uint) num5)) >= 0)
                {
                    goto Label_00C8;
                }
            Label_0116:
                if ((((uint) num4) - ((uint) num5)) <= uint.MaxValue)
                {
                    goto Label_007E;
                }
                goto Label_01C2;
            Label_0138:
                if (field.Action == NormalizationAction.Normalize)
                {
                    num4 = csv.Format.Parse(str.Trim());
                    num4 = field.Normalize(num4);
                    numArray[num++] = num4;
                    if ((((uint) outputLength) - ((uint) num6)) > uint.MaxValue)
                    {
                        goto Label_022A;
                    }
                    goto Label_0070;
                }
                if ((((uint) num2) - ((uint) outputLength)) <= uint.MaxValue)
                {
                    goto Label_00E8;
                }
                goto Label_01C2;
            Label_01A4:
                if (num3 < numArray2.Length)
                {
                    goto Label_0207;
                }
                goto Label_0070;
            Label_01B1:
                if (str.Length == 0)
                {
                    goto Label_025F;
                }
                goto Label_0138;
            Label_01C2:
                if ((((uint) num6) - ((uint) num3)) >= 0)
                {
                    return numArray;
                }
                if ((((uint) num2) - ((uint) num5)) <= uint.MaxValue)
                {
                    goto Label_02CD;
                }
                goto Label_0295;
            Label_0202:
                num3 = 0;
                goto Label_01A4;
            Label_0207:
                numArray[num++] = numArray2[num3];
                num3++;
                goto Label_02E6;
            Label_021B:
                numArray2 = values.HandleMissing(analyst, field);
                if (numArray2 != null)
                {
                    goto Label_0202;
                }
            Label_022A:
                numArray4 = null;
                if ((((uint) outputLength) | 8) != 0)
                {
                    return numArray4;
                }
                goto Label_02E6;
            Label_024E:
                if (!str.Equals("?"))
                {
                    goto Label_01B1;
                }
            Label_025F:
                values = analyst.Script.Normalize.MissingValues;
                goto Label_021B;
            Label_0273:
                if (((uint) num5) > uint.MaxValue)
                {
                    goto Label_00B9;
                }
                str = csv.Get(num2);
                goto Label_024E;
            Label_0295:
                if ((((uint) num5) | uint.MaxValue) == 0)
                {
                    goto Label_0029;
                }
                goto Label_0022;
            Label_02B7:
                num2 = headers.Find(field.Name);
                goto Label_0273;
            Label_02CD:
                field = enumerator.Current;
                if (field.Action == NormalizationAction.Ignore)
                {
                    goto Label_0070;
                }
                goto Label_009A;
            Label_02E6:
                if ((((uint) num4) - ((uint) skipOutput)) >= 0)
                {
                    goto Label_01A4;
                }
            }
            return numArray;
        }

        public void Normalize(FileInfo file)
        {
            int num;
            if (this._x554f16462d8d4675 == null)
            {
                throw new EncogError("Can't normalize yet, file has not been analyzed.");
            }
            ReadCSV csv = null;
            StreamWriter writer = null;
            try
            {
                double[] numArray;
                StringBuilder builder;
                csv = new ReadCSV(base.InputFilename.ToString(), base.ExpectInputHeaders, base.InputFormat);
                if ((((uint) num) | uint.MaxValue) != 0)
                {
                    goto Label_0110;
                }
            Label_004F:
                writer.WriteLine(builder);
                goto Label_0063;
            Label_0059:
                if (numArray != null)
                {
                    goto Label_0090;
                }
                if (1 == 0)
                {
                    goto Label_0081;
                }
            Label_0063:
                if (csv.Next() && !base.ShouldStop())
                {
                    goto Label_0105;
                }
                return;
            Label_007E:
                if (0 != 0)
                {
                    goto Label_0063;
                }
            Label_0081:
                numArray = this._x7acb8518c8ed6133.Process(numArray);
                goto Label_0059;
            Label_0090:
                builder = new StringBuilder();
                NumberList.ToList(base.OutputFormat, builder, numArray);
                goto Label_004F;
            Label_00A7:
                numArray = ExtractFields(this._x554f16462d8d4675, this._xc5416b6511261016, csv, num, false);
                if (this._x7acb8518c8ed6133.TotalDepth <= 1)
                {
                    goto Label_0059;
                }
                if (((uint) num) >= 0)
                {
                    goto Label_007E;
                }
                goto Label_004F;
            Label_00E1:
                this.x6c260f7f6142106c(writer);
            Label_00E8:
                base.ResetStatus();
                if (0 == 0)
                {
                    num = this._x554f16462d8d4675.DetermineTotalColumns();
                }
                goto Label_0063;
            Label_0105:
                base.UpdateStatus(false);
                goto Label_00A7;
            Label_0110:
                file.Delete();
                writer = new StreamWriter(file.OpenWrite());
                if (!base.ProduceOutputHeaders)
                {
                    goto Label_00E8;
                }
                goto Label_00E1;
            }
            catch (IOException exception)
            {
                throw new QuantError(exception);
            }
            finally
            {
                base.ReportDone(false);
                goto Label_01B0;
            Label_014E:
                if ((((uint) num) - ((uint) num)) > uint.MaxValue)
                {
                    goto Label_0173;
                }
                if (0 == 0)
                {
                    goto Label_01D5;
                }
                goto Label_01B0;
            Label_016E:
                if (writer != null)
                {
                    goto Label_019B;
                }
                goto Label_014E;
            Label_0173:
                if (2 == 0)
                {
                    goto Label_016E;
                }
                if ((((uint) num) - ((uint) num)) < 0)
                {
                    goto Label_0173;
                }
                goto Label_01D5;
            Label_0196:
                if (csv != null)
                {
                    goto Label_01B7;
                }
                goto Label_016E;
            Label_019B:
                try
                {
                    writer.Close();
                }
                catch (Exception exception3)
                {
                    EncogLogging.Log(exception3);
                }
                goto Label_01D5;
            Label_01B0:
                if (1 != 0)
                {
                    goto Label_0196;
                }
            Label_01B7:
                try
                {
                    csv.Close();
                }
                catch (Exception exception2)
                {
                    EncogLogging.Log(exception2);
                }
                goto Label_016E;
                if (0 == 0)
                {
                    goto Label_016E;
                }
                goto Label_014E;
            Label_01D5:;
            }
        }

        public void SetSourceFile(FileInfo file, bool headers, CSVFormat format)
        {
            base.InputFilename = file;
            base.ExpectInputHeaders = headers;
            base.InputFormat = format;
        }

        private void x6c260f7f6142106c(StreamWriter x662b9cecc8fe240a)
        {
            StringBuilder line = new StringBuilder();
            using (IEnumerator<AnalystField> enumerator = this._x554f16462d8d4675.Script.Normalize.NormalizedFields.GetEnumerator())
            {
                AnalystField field;
                int num;
                int num2;
                goto Label_006A;
            Label_0024:
                line.Append(CSVHeaders.TagColumn(field.Name, num2, field.TimeSlice, num > 1));
                line.Append('"');
                if ((((uint) num2) - ((uint) num)) < 0)
                {
                    goto Label_0092;
                }
                num2++;
            Label_0066:
                if (num2 < num)
                {
                    goto Label_0092;
                }
            Label_006A:
                if (enumerator.MoveNext())
                {
                    goto Label_00A9;
                }
                goto Label_00C6;
            Label_0075:
                num = field.ColumnsNeeded;
                if (((uint) num) < 0)
                {
                    goto Label_006A;
                }
                num2 = 0;
                goto Label_0066;
            Label_0092:
                BasicFile.AppendSeparator(line, base.InputFormat);
                line.Append('"');
                goto Label_0024;
            Label_00A9:
                field = enumerator.Current;
                goto Label_0075;
            }
        Label_00C6:
            x662b9cecc8fe240a.WriteLine(line.ToString());
        }
    }
}

