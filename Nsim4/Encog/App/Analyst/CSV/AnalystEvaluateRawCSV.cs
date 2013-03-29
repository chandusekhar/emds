namespace Encog.App.Analyst.CSV
{
    using Encog.App.Analyst;
    using Encog.App.Analyst.CSV.Basic;
    using Encog.App.Analyst.Script.Normalize;
    using Encog.App.Quant;
    using Encog.ML;
    using Encog.ML.Data;
    using Encog.ML.Data.Basic;
    using Encog.Util.CSV;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class AnalystEvaluateRawCSV : BasicFile
    {
        private int _x43f451310e815b76;
        private EncogAnalyst _x554f16462d8d4675;
        private int _x98cf41c6b0eaf6ab;
        private int _xb52d4a98fad404da;

        public void Analyze(EncogAnalyst theAnalyst, FileInfo inputFile, bool headers, CSVFormat format)
        {
            object[] objArray;
            base.InputFilename = inputFile;
            base.ExpectInputHeaders = headers;
            base.InputFormat = format;
            this._x554f16462d8d4675 = theAnalyst;
            if ((((uint) headers) - ((uint) headers)) >= 0)
            {
                base.Analyzed = true;
                if (0 == 0)
                {
                    base.PerformBasicCounts();
                    this._x43f451310e815b76 = this._x554f16462d8d4675.DetermineInputCount();
                    this._x98cf41c6b0eaf6ab = this._x554f16462d8d4675.DetermineOutputCount();
                    this._xb52d4a98fad404da = base.InputHeadings.Length - this._x43f451310e815b76;
                    while ((base.InputHeadings.Length != this._x43f451310e815b76) && (base.InputHeadings.Length != (this._x43f451310e815b76 + this._x98cf41c6b0eaf6ab)))
                    {
                        objArray = new object[7];
                        if (0 != 0)
                        {
                            goto Label_0064;
                        }
                        objArray[0] = "Invalid number of columns(";
                        if (0 == 0)
                        {
                            objArray[1] = base.InputHeadings.Length;
                            objArray[2] = "), must match input(";
                            objArray[3] = this._x43f451310e815b76;
                            objArray[4] = ") count or input+output(";
                            objArray[5] = this._x43f451310e815b76 + this._x98cf41c6b0eaf6ab;
                            goto Label_005C;
                        }
                        if (0x7fffffff == 0)
                        {
                            return;
                        }
                    }
                    return;
                }
                return;
            }
        Label_005C:
            objArray[6] = ") count.";
        Label_0064:
            throw new AnalystError(string.Concat(objArray));
        }

        public void Process(FileInfo outputFile, IMLRegression method)
        {
            IMLData data;
            StreamWriter writer;
            LoadedRow row;
            int num;
            int num2;
            string str;
            double num3;
            IMLData data2;
            int num4;
            double num5;
            object[] objArray;
            ReadCSV csv = new ReadCSV(base.InputFilename.ToString(), base.ExpectInputHeaders, base.InputFormat);
            goto Label_0285;
        Label_006D:
            if (csv.Next())
            {
                base.UpdateStatus(false);
                row = new LoadedRow(csv, this._xb52d4a98fad404da);
                num = 0;
                if ((((uint) num2) | 4) == 0)
                {
                    goto Label_011D;
                }
                goto Label_010D;
            }
            if ((((uint) num3) & 0) == 0)
            {
                base.ReportDone(false);
                writer.Close();
                csv.Close();
                if ((((uint) num) + ((uint) num3)) < 0)
                {
                    if ((((uint) num) - ((uint) num2)) <= uint.MaxValue)
                    {
                        goto Label_010D;
                    }
                    goto Label_00D5;
                }
            }
            if ((((uint) num) & 0) == 0)
            {
                return;
            }
            goto Label_0165;
        Label_00A6:
            if (((uint) num5) < 0)
            {
                goto Label_01F9;
            }
            num4++;
        Label_00C1:
            if (num4 < this._x98cf41c6b0eaf6ab)
            {
                num5 = data2[num4];
                row.Data[num++] = base.InputFormat.Format(num5, base.Precision);
                goto Label_00A6;
            }
            base.WriteRow(writer, row);
            goto Label_006D;
        Label_00D5:
            data2 = method.Compute(data);
            num4 = 0;
            goto Label_00C1;
        Label_00F6:
            if (num2 < this._x43f451310e815b76)
            {
                str = row.Data[num2];
                goto Label_011D;
            }
        Label_0100:
            num += this._xb52d4a98fad404da;
            goto Label_00D5;
        Label_010D:
            num2 = 0;
            goto Label_00F6;
        Label_011D:
            num3 = base.InputFormat.Parse(str);
            data[num2] = num3;
            num++;
            num2++;
            goto Label_00F6;
        Label_0165:
            if (0 != 0)
            {
                goto Label_00A6;
            }
            goto Label_006D;
        Label_01C8:
            data = new BasicMLData(method.InputCount);
            writer = this.x972236628de6c041(outputFile);
            if ((((uint) num) | 2) == 0)
            {
                goto Label_0100;
            }
            base.ResetStatus();
            goto Label_0165;
        Label_01F9:
            objArray[2] = " inputs, however, the data has ";
            if ((((uint) num4) + ((uint) num)) <= uint.MaxValue)
            {
                objArray[3] = this._x43f451310e815b76;
                objArray[4] = " inputs.";
                throw new AnalystError(string.Concat(objArray));
            }
        Label_0285:
            if (((((uint) num2) | 15) != 0) && (method.InputCount == this._x43f451310e815b76))
            {
                goto Label_01C8;
            }
            objArray = new object[5];
            objArray[0] = "This machine learning method has ";
            if ((((uint) num) - ((uint) num4)) > uint.MaxValue)
            {
                goto Label_01C8;
            }
            objArray[1] = method.InputCount;
            goto Label_01F9;
        }

        private StreamWriter x972236628de6c041(FileInfo x2608fe0a208c787d)
        {
            StreamWriter writer2;
            try
            {
                StringBuilder builder;
                StreamWriter writer = new StreamWriter(x2608fe0a208c787d.OpenWrite());
            Label_0013:
                if (base.ProduceOutputHeaders)
                {
                    goto Label_018B;
                }
            Label_001E:
                writer2 = writer;
                goto Label_0183;
            Label_0026:
                if (1 != 0)
                {
                }
                using (IEnumerator<AnalystField> enumerator = this._x554f16462d8d4675.Script.Normalize.NormalizedFields.GetEnumerator())
                {
                    AnalystField field;
                    goto Label_0052;
                Label_004B:
                    if (-1 == 0)
                    {
                        goto Label_005F;
                    }
                Label_0052:
                    if (enumerator.MoveNext())
                    {
                        goto Label_0069;
                    }
                    goto Label_0098;
                Label_005F:
                    if (field.Input)
                    {
                        goto Label_007A;
                    }
                    goto Label_0052;
                Label_0069:
                    field = enumerator.Current;
                    if (4 == 0)
                    {
                        goto Label_0098;
                    }
                    goto Label_005F;
                Label_007A:
                    field.AddRawHeadings(builder, null, base.OutputFormat);
                    goto Label_004B;
                }
            Label_0098:
                if (this._xb52d4a98fad404da > 0)
                {
                    using (IEnumerator<AnalystField> enumerator2 = this._x554f16462d8d4675.Script.Normalize.NormalizedFields.GetEnumerator())
                    {
                        AnalystField current;
                        goto Label_00D1;
                    Label_00C2:
                        if (current.Output)
                        {
                            goto Label_00E7;
                        }
                        if (15 == 0)
                        {
                            goto Label_00C2;
                        }
                    Label_00D1:
                        if (!enumerator2.MoveNext())
                        {
                            goto Label_0109;
                        }
                        current = enumerator2.Current;
                        if (0 == 0)
                        {
                            goto Label_00C2;
                        }
                    Label_00E7:
                        current.AddRawHeadings(builder, "ideal:", base.OutputFormat);
                        goto Label_00D1;
                    }
                }
            Label_0109:
                using (IEnumerator<AnalystField> enumerator3 = this._x554f16462d8d4675.Script.Normalize.NormalizedFields.GetEnumerator())
                {
                    AnalystField field3;
                    goto Label_0147;
                Label_0129:
                    field3.AddRawHeadings(builder, "output:", base.OutputFormat);
                    goto Label_0147;
                Label_013E:
                    if (field3.Output)
                    {
                        goto Label_0129;
                    }
                Label_0147:
                    if (enumerator3.MoveNext() || (0x7fffffff == 0))
                    {
                        field3 = enumerator3.Current;
                        goto Label_013E;
                    }
                }
                writer.WriteLine(builder.ToString());
                goto Label_001E;
            Label_0183:
                if (0 == 0)
                {
                    return writer2;
                }
                goto Label_0013;
            Label_018B:
                builder = new StringBuilder();
                goto Label_0026;
            }
            catch (IOException exception)
            {
                throw new QuantError(exception);
            }
            return writer2;
        }
    }
}

