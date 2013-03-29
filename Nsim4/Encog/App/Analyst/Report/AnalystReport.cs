namespace Encog.App.Analyst.Report
{
    using Encog.App.Analyst;
    using Encog.App.Analyst.Script;
    using Encog.App.Analyst.Script.Normalize;
    using Encog.App.Analyst.Script.Prop;
    using Encog.Util;
    using Encog.Util.CSV;
    using Encog.Util.File;
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class AnalystReport
    {
        private int _x0fe0496cde3d05e3;
        private readonly EncogAnalyst _x554f16462d8d4675;
        private int _xed3494f8db69efb7;
        public const int EightSpan = 5;
        public const int FiveSpan = 5;

        public AnalystReport(EncogAnalyst theAnalyst)
        {
            this._x554f16462d8d4675 = theAnalyst;
        }

        public string ProduceReport()
        {
            DataField field;
            string propertyString;
            string str2;
            string str3;
            DataField[] fields;
            int num;
            HTMLReport report = new HTMLReport();
            goto Label_07C1;
        Label_00B9:
            report.EndTable();
            report.EndBody();
            report.EndHTML();
            if (0 == 0)
            {
                if ((((uint) num) + ((uint) num)) >= 0)
                {
                    if (-2147483648 != 0)
                    {
                        if (0 == 0)
                        {
                            goto Label_07E3;
                        }
                        goto Label_07C1;
                    }
                    goto Label_0668;
                }
                goto Label_0468;
            }
            goto Label_01CE;
        Label_00FD:
            report.Header("Name");
            report.Header("Filename");
            report.EndRow();
            using (IEnumerator<string> enumerator3 = this._x554f16462d8d4675.Script.Properties.Filenames.GetEnumerator())
            {
                string str4;
                string filename;
                goto Label_0055;
            Label_002F:
                if ((((uint) num) + ((uint) num)) > uint.MaxValue)
                {
                    goto Label_0076;
                }
                report.Cell(filename);
                report.EndRow();
            Label_0055:
                if (!enumerator3.MoveNext() && ((((uint) num) - ((uint) num)) >= 0))
                {
                    goto Label_00B9;
                }
            Label_0076:
                str4 = enumerator3.Current;
                filename = this._x554f16462d8d4675.Script.Properties.GetFilename(str4);
                report.BeginRow();
                report.Cell(str4);
                goto Label_002F;
            }
            goto Label_00B9;
        Label_014A:
            report.TablePair("Type", propertyString);
            report.TablePair("Architecture", str2);
            report.TablePair("Machine Learning File", str3);
            report.EndTable();
            report.H1("Files");
            report.BeginTable();
            report.BeginRow();
            goto Label_00FD;
        Label_01CE:
            report.BeginRow();
            report.Header("Name");
            if ((((uint) num) - ((uint) num)) < 0)
            {
                goto Label_03AA;
            }
            if ((((uint) num) & 0) != 0)
            {
                goto Label_076F;
            }
            report.Header("Value");
            report.EndRow();
            propertyString = this._x554f16462d8d4675.Script.Properties.GetPropertyString("ML:CONFIG_type");
            if (0xff != 0)
            {
                str2 = this._x554f16462d8d4675.Script.Properties.GetPropertyString("ML:CONFIG_architecture");
                str3 = this._x554f16462d8d4675.Script.Properties.GetPropertyString("ML:CONFIG_machineLearningFile");
                goto Label_014A;
            }
            goto Label_01CE;
        Label_030F:
            report.EndTable();
            if (0 != 0)
            {
                goto Label_0429;
            }
            report.H1("Machine Learning");
            report.BeginTable();
            goto Label_0450;
        Label_0371:
            if (num < fields.Length)
            {
                field = fields[num];
                report.BeginRow();
                report.Cell(field.Name);
                report.Cell(Format.FormatYesNo(field.Class));
                report.Cell(Format.FormatYesNo(field.Complete));
                goto Label_051B;
            }
            if (0 != 0)
            {
                goto Label_06BB;
            }
            report.EndTable();
            report.H1("Normalization");
            report.BeginTable();
            if (3 == 0)
            {
                goto Label_04B0;
            }
            report.BeginRow();
            if ((((uint) num) & 0) == 0)
            {
                report.Header("Name");
                report.Header("Action");
                report.Header("High");
                report.Header("Low");
                report.EndRow();
                using (IEnumerator<AnalystField> enumerator2 = this._x554f16462d8d4675.Script.Normalize.NormalizedFields.GetEnumerator())
                {
                    AnalystField field2;
                Label_0260:
                    if (!enumerator2.MoveNext() && ((((uint) num) - ((uint) num)) >= 0))
                    {
                        goto Label_030F;
                    }
                    goto Label_02B2;
                Label_0286:
                    report.Cell(Format.FormatDouble(field2.NormalizedHigh, 5));
                    report.Cell(Format.FormatDouble(field2.NormalizedLow, 5));
                    report.EndRow();
                    goto Label_0260;
                Label_02B2:
                    field2 = enumerator2.Current;
                    report.BeginRow();
                    if ((((uint) num) - ((uint) num)) >= 0)
                    {
                        report.Cell(field2.Name);
                        report.Cell(field2.Action.ToString());
                        goto Label_0286;
                    }
                }
                goto Label_030F;
            }
            goto Label_0450;
        Label_03AA:
            using (IEnumerator<AnalystClassItem> enumerator = field.ClassMembers.GetEnumerator())
            {
                AnalystClassItem current;
                goto Label_0400;
            Label_03B9:
                if ((((uint) num) | uint.MaxValue) != 0)
                {
                    report.Cell(current.Code);
                    report.Cell(current.Name);
                    report.Cell(Format.FormatInteger(current.Count));
                }
                report.EndRow();
            Label_0400:
                if (enumerator.MoveNext())
                {
                    current = enumerator.Current;
                    report.BeginRow();
                    goto Label_03B9;
                }
            }
        Label_0429:
            report.EndTableInCell();
            report.EndRow();
            goto Label_0445;
        Label_0437:
            if (field.ClassMembers.Count > 0)
            {
                goto Label_04BA;
            }
        Label_0445:
            num++;
            goto Label_0371;
        Label_0450:
            if ((((uint) num) + ((uint) num)) <= uint.MaxValue)
            {
                goto Label_01CE;
            }
        Label_0468:
            report.EndRow();
            goto Label_03AA;
        Label_04B0:
            if (8 != 0)
            {
                goto Label_0437;
            }
        Label_04BA:
            report.BeginRow();
        Label_04C0:
            report.Cell("&nbsp;");
            if (0 == 0)
            {
                report.BeginTableInCell(5);
                report.BeginRow();
                report.Header("Code");
                report.Header("Name");
                report.Header("Count");
            }
            goto Label_0468;
        Label_051B:
            report.Cell(Format.FormatYesNo(field.Integer));
            report.Cell(Format.FormatYesNo(field.Real));
        Label_053D:
            report.Cell(Format.FormatDouble(field.Max, 5));
            report.Cell(Format.FormatDouble(field.Min, 5));
        Label_0561:
            report.Cell(Format.FormatDouble(field.Mean, 5));
            if ((((uint) num) - ((uint) num)) <= uint.MaxValue)
            {
                report.Cell(Format.FormatDouble(field.StandardDeviation, 5));
                if ((((uint) num) | 15) == 0)
                {
                    goto Label_0437;
                }
                report.EndRow();
                if ((((uint) num) | 1) == 0)
                {
                    goto Label_051B;
                }
            }
            goto Label_04B0;
        Label_0636:
            if ((((uint) num) - ((uint) num)) > uint.MaxValue)
            {
                goto Label_00FD;
            }
            report.EndRow();
            fields = this._x554f16462d8d4675.Script.Fields;
            num = 0;
            goto Label_0371;
        Label_0668:
            report.Header("Complete?");
            report.Header("Int?");
            report.Header("Real?");
            report.Header("Max");
            report.Header("Min");
            report.Header("Mean");
            report.Header("Standard Deviation");
            if ((((uint) num) + ((uint) num)) > uint.MaxValue)
            {
                goto Label_0561;
            }
            goto Label_0636;
        Label_06BB:
            report.Header("Class?");
            if (((uint) num) > uint.MaxValue)
            {
                goto Label_014A;
            }
            if (8 != 0)
            {
                goto Label_07D9;
            }
        Label_06E4:
            report.TablePair("Missing row count", Format.FormatInteger(this._xed3494f8db69efb7));
            report.EndTable();
            report.H1("Field Ranges");
            report.BeginTable();
            if ((((uint) num) - ((uint) num)) >= 0)
            {
                report.BeginRow();
                report.Header("Name");
                if (0 != 0)
                {
                    goto Label_0636;
                }
                goto Label_06BB;
            }
            goto Label_07D9;
        Label_076F:
            report.BeginHTML();
            report.Title("Encog Analyst Report");
            report.BeginBody();
            if (-2147483648 == 0)
            {
                goto Label_053D;
            }
            if (((uint) num) >= 0)
            {
            }
            report.H1("General Statistics");
            if ((((uint) num) & 0) == 0)
            {
                report.BeginTable();
                if ((((uint) num) + ((uint) num)) < 0)
                {
                    goto Label_04C0;
                }
                report.TablePair("Total row count", Format.FormatInteger(this._x0fe0496cde3d05e3));
                if (0 == 0)
                {
                    goto Label_06E4;
                }
                goto Label_07D9;
            }
        Label_07C1:
            this.x076efb43809972d8();
            goto Label_076F;
        Label_07D9:
            if (15 != 0)
            {
                goto Label_0668;
            }
        Label_07E3:
            return report.ToString();
        }

        public void ProduceReport(FileInfo filename)
        {
            try
            {
                string str = this.ProduceReport();
                FileUtil.WriteFileAsString(filename, str);
            }
            catch (IOException exception)
            {
                throw new AnalystError(exception);
            }
        }

        private void x076efb43809972d8()
        {
            string str;
            FileInfo info;
            CSVFormat format;
            bool flag;
            ScriptProperties properties = this._x554f16462d8d4675.Script.Properties;
        Label_00AD:
            str = properties.GetPropertyString("HEADER:DATASOURCE_rawFile");
            do
            {
                info = this._x554f16462d8d4675.Script.ResolveFilename(str);
                if (((uint) flag) < 0)
                {
                    goto Label_00AD;
                }
                format = this._x554f16462d8d4675.Script.DetermineInputFormat(str);
                flag = this._x554f16462d8d4675.Script.ExpectInputHeaders(str);
            }
            while (0 != 0);
            this._x0fe0496cde3d05e3 = 0;
            if (0 == 0)
            {
                this._xed3494f8db69efb7 = 0;
                ReadCSV dcsv = new ReadCSV(info.ToString(), flag, format);
                while (dcsv.Next())
                {
                    this._x0fe0496cde3d05e3++;
                    if (dcsv.HasMissing())
                    {
                        this._xed3494f8db69efb7++;
                    }
                }
                dcsv.Close();
                if (((uint) flag) > uint.MaxValue)
                {
                    goto Label_00AD;
                }
            }
        }
    }
}

