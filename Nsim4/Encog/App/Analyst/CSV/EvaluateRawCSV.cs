namespace Encog.App.Analyst.CSV
{
    using Encog.App.Analyst;
    using Encog.App.Analyst.CSV.Basic;
    using Encog.App.Quant;
    using Encog.ML;
    using Encog.ML.Data;
    using Encog.ML.Data.Basic;
    using Encog.Util.CSV;
    using System;
    using System.IO;
    using System.Text;

    public class EvaluateRawCSV : BasicFile
    {
        private int _x43f451310e815b76;
        private int _x98cf41c6b0eaf6ab;
        private int _xb52d4a98fad404da;

        public void Analyze(IMLRegression method, FileInfo inputFile, bool headers, CSVFormat format)
        {
            object[] objArray;
            base.InputFilename = inputFile;
            base.ExpectInputHeaders = headers;
            base.InputFormat = format;
            if (((uint) headers) >= 0)
            {
                base.Analyzed = true;
            }
            base.PerformBasicCounts();
            this._x43f451310e815b76 = method.InputCount;
            this._x98cf41c6b0eaf6ab = method.OutputCount;
            this._xb52d4a98fad404da = Math.Max(base.InputHeadings.Length - this._x43f451310e815b76, 0);
            if (0x7fffffff == 0)
            {
                goto Label_00E0;
            }
            if ((((uint) headers) & 0) != 0)
            {
                goto Label_0084;
            }
            if ((((uint) headers) - ((uint) headers)) >= 0)
            {
                if (base.InputHeadings.Length == this._x43f451310e815b76)
                {
                    return;
                }
                if (3 == 0)
                {
                    return;
                }
            }
        Label_000C:
            if (base.InputHeadings.Length != (this._x43f451310e815b76 + this._x98cf41c6b0eaf6ab))
            {
                objArray = new object[7];
                goto Label_00E0;
            }
            return;
        Label_0084:
            objArray[3] = this._x43f451310e815b76;
            if ((((uint) headers) + ((uint) headers)) < 0)
            {
                goto Label_000C;
            }
            objArray[4] = ") count or input+output(";
            objArray[5] = this._x43f451310e815b76 + this._x98cf41c6b0eaf6ab;
            objArray[6] = ") count.";
            throw new AnalystError(string.Concat(objArray));
        Label_00E0:
            objArray[0] = "Invalid number of columns(";
            objArray[1] = base.InputHeadings.Length;
            objArray[2] = "), must match input(";
            goto Label_0084;
        }

        public void Process(FileInfo outputFile, IMLRegression method)
        {
            IMLData data;
            StreamWriter writer;
            LoadedRow row;
            int num;
            int num2;
            double num3;
            IMLData data2;
            int num4;
            double num5;
            object[] objArray;
            ReadCSV csv = new ReadCSV(base.InputFilename.ToString(), base.ExpectInputHeaders, base.InputFormat);
            goto Label_028E;
        Label_0022:
            if (csv.Next())
            {
                base.UpdateStatus(false);
                row = new LoadedRow(csv, this._xb52d4a98fad404da);
                num = 0;
                if ((((uint) num3) + ((uint) num4)) < 0)
                {
                    goto Label_0208;
                }
                num2 = 0;
            }
            else
            {
                if ((((uint) num5) + ((uint) num2)) < 0)
                {
                    goto Label_026E;
                }
                base.ReportDone(false);
                writer.Close();
                csv.Close();
                if (0 == 0)
                {
                    return;
                }
                goto Label_028E;
            }
        Label_0125:
            if (num2 < this._x43f451310e815b76)
            {
                string str = row.Data[num2];
                num3 = base.InputFormat.Parse(str);
                data[num2] = num3;
                if ((((uint) num5) + ((uint) num3)) <= uint.MaxValue)
                {
                    goto Label_0148;
                }
                goto Label_0196;
            }
            num += this._xb52d4a98fad404da;
        Label_013A:
            data2 = method.Compute(data);
            num4 = 0;
            goto Label_0196;
        Label_0148:
            num++;
            num2++;
            if ((((uint) num) - ((uint) num3)) > uint.MaxValue)
            {
                goto Label_01EC;
            }
            goto Label_0125;
        Label_0196:
            if ((((uint) num3) + ((uint) num3)) >= 0)
            {
            Label_008D:
                if (num4 >= this._x98cf41c6b0eaf6ab)
                {
                    base.WriteRow(writer, row);
                }
                else
                {
                    num5 = data2[num4];
                    if ((((uint) num2) - ((uint) num)) < 0)
                    {
                        goto Label_0125;
                    }
                    if ((((uint) num2) | 15) != 0)
                    {
                        row.Data[num++] = base.InputFormat.Format(num5, base.Precision);
                        num4++;
                        goto Label_008D;
                    }
                }
                if (((uint) num3) < 0)
                {
                    if (((uint) num5) <= uint.MaxValue)
                    {
                        goto Label_0125;
                    }
                    goto Label_0148;
                }
            }
            goto Label_02BE;
        Label_01EC:
            base.ResetStatus();
            goto Label_0022;
        Label_0208:
            data = new BasicMLData(method.InputCount);
            writer = this.x972236628de6c041(outputFile);
            if ((((uint) num5) + ((uint) num4)) >= 0)
            {
                goto Label_01EC;
            }
            goto Label_0125;
        Label_026E:
            objArray[4] = " inputs.";
            if (((uint) num2) < 0)
            {
                goto Label_013A;
            }
            if (((uint) num) >= 0)
            {
                throw new AnalystError(string.Concat(objArray));
            }
            goto Label_02BE;
        Label_028E:
            if (method.InputCount <= this._x43f451310e815b76)
            {
                goto Label_0208;
            }
            objArray = new object[5];
            objArray[0] = "This machine learning method has ";
            objArray[1] = method.InputCount;
            objArray[2] = " inputs, however, the data has ";
            objArray[3] = this._x43f451310e815b76;
            goto Label_026E;
        Label_02BE:
            if ((((uint) num) - ((uint) num2)) <= uint.MaxValue)
            {
                goto Label_0022;
            }
        }

        private StreamWriter x972236628de6c041(FileInfo x2608fe0a208c787d)
        {
            StreamWriter writer2;
            try
            {
                StringBuilder builder;
                int num;
                int num2;
                int num3;
                StreamWriter writer = new StreamWriter(x2608fe0a208c787d.OpenWrite());
                goto Label_0244;
            Label_0011:
                if (((uint) num2) > uint.MaxValue)
                {
                    goto Label_0244;
                }
                if (((uint) num) < 0)
                {
                    goto Label_013D;
                }
            Label_003B:
                writer.WriteLine(builder.ToString());
            Label_0047:
                writer2 = writer;
                if (((uint) num) >= 0)
                {
                    goto Label_00DF;
                }
                goto Label_0067;
            Label_0061:
                num3++;
            Label_0067:
                if (num3 < this._x98cf41c6b0eaf6ab)
                {
                    goto Label_00C0;
                }
                goto Label_003B;
            Label_0073:
                if (this._x98cf41c6b0eaf6ab > 0)
                {
                    goto Label_011A;
                }
                goto Label_0011;
            Label_0081:
                builder.Append("output:" + num3);
                if (((uint) num2) < 0)
                {
                    goto Label_0244;
                }
                builder.Append("\"");
                goto Label_0061;
            Label_00C0:
                BasicFile.AppendSeparator(builder, base.InputFormat);
                builder.Append("\"");
                goto Label_0081;
            Label_00DF:
                if ((((uint) num3) & 0) == 0)
                {
                    return writer2;
                }
            Label_00F3:
                if (-1 == 0)
                {
                    goto Label_0148;
                }
                if ((((uint) num3) - ((uint) num3)) < 0)
                {
                    goto Label_0225;
                }
                goto Label_0073;
            Label_011A:
                num3 = 0;
                if (((uint) num2) >= 0)
                {
                    goto Label_0067;
                }
                return writer2;
            Label_0139:
                num2++;
            Label_013D:
                if (num2 < this._xb52d4a98fad404da)
                {
                    goto Label_019F;
                }
                goto Label_00F3;
            Label_0148:
                if (this._xb52d4a98fad404da > 0)
                {
                    goto Label_019B;
                }
                goto Label_0256;
            Label_0153:
                builder.Append("\"");
                builder.Append("ideal:" + num2);
                builder.Append("\"");
                if (((uint) num2) <= uint.MaxValue)
                {
                    goto Label_0139;
                }
                goto Label_0256;
            Label_019B:
                num2 = 0;
                goto Label_013D;
            Label_019F:
                BasicFile.AppendSeparator(builder, base.InputFormat);
                goto Label_0153;
            Label_01B2:
                if (this._x43f451310e815b76 > 0)
                {
                    goto Label_0215;
                }
                goto Label_0148;
            Label_01C0:
                if (num < this._x43f451310e815b76)
                {
                    goto Label_0219;
                }
                goto Label_0148;
            Label_01CB:
                if (0 != 0)
                {
                    goto Label_01C0;
                }
                builder.Append("input:" + num);
                builder.Append("\"");
                num++;
                if ((((uint) num3) - ((uint) num3)) >= 0)
                {
                    goto Label_01C0;
                }
            Label_020D:
                builder = new StringBuilder();
                goto Label_01B2;
            Label_0215:
                num = 0;
                goto Label_01C0;
            Label_0219:
                BasicFile.AppendSeparator(builder, base.InputFormat);
            Label_0225:
                builder.Append("\"");
                goto Label_01CB;
            Label_0244:
                if (!base.ProduceOutputHeaders)
                {
                    goto Label_0047;
                }
                goto Label_020D;
            Label_0256:
                if ((((uint) num3) - ((uint) num)) <= uint.MaxValue)
                {
                    goto Label_0073;
                }
                goto Label_00F3;
            }
            catch (IOException exception)
            {
                throw new QuantError(exception);
            }
            return writer2;
        }
    }
}

