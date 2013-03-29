namespace Encog.App.Analyst.CSV.Basic
{
    using Encog.App.Quant;
    using Encog.Util.CSV;
    using Encog.Util.Logging;
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class BasicCachedFile : BasicFile
    {
        private readonly IList<BaseCachedColumn> _x26c511b92db96554 = new List<BaseCachedColumn>();
        private readonly IDictionary<string, BaseCachedColumn> _x5f81ddd16c23e357 = new Dictionary<string, BaseCachedColumn>();

        public void AddColumn(BaseCachedColumn column)
        {
            this._x26c511b92db96554.Add(column);
            this._x5f81ddd16c23e357[column.Name] = column;
        }

        public virtual void Analyze(FileInfo input, bool headers, CSVFormat format)
        {
            ReadCSV dcsv;
            int num2;
            bool flag;
            base.ResetStatus();
            goto Label_02AA;
        Label_0143:
            dcsv = null;
            try
            {
                string str;
                string str2;
                dcsv = new ReadCSV(input.ToString(), headers, format);
                if (0 == 0)
                {
                    goto Label_0273;
                }
                goto Label_0245;
            Label_0160:
                if (num2 < dcsv.ColumnCount)
                {
                    goto Label_0257;
                }
                if (((((uint) headers) - ((uint) headers)) <= uint.MaxValue) && (((uint) headers) <= uint.MaxValue))
                {
                    return;
                }
                goto Label_01A8;
            Label_019D:
                num2++;
                goto Label_022E;
            Label_01A8:
                str = x0049197442052640(dcsv.ColumnNames[num2]);
                goto Label_01D4;
            Label_01BF:
                str = "Column-" + (num2 + 1);
            Label_01D4:
                str2 = dcsv.Get(num2);
                flag = false;
                try
                {
                    base.InputFormat.Parse(str2);
                    flag = true;
                }
                catch (FormatException exception3)
                {
                    EncogLogging.Log(exception3);
                }
                this.AddColumn(new FileData(str, num2, flag, flag));
                if ((((uint) num2) + ((uint) flag)) <= uint.MaxValue)
                {
                    goto Label_019D;
                }
            Label_022E:
                if (((uint) flag) <= uint.MaxValue)
                {
                    goto Label_0160;
                }
                return;
            Label_0245:
                if (((uint) headers) < 0)
                {
                    goto Label_0273;
                }
            Label_0257:
                if (!headers)
                {
                    goto Label_01BF;
                }
                goto Label_01A8;
            Label_0273:
                while (!dcsv.Next())
                {
                    throw new QuantError("File is empty");
                }
                num2 = 0;
                goto Label_0160;
            }
            finally
            {
                if (dcsv != null)
                {
                    dcsv.Close();
                }
                base.Analyzed = true;
            }
            if (-1 == 0)
            {
                goto Label_0143;
            }
            if (2 != 0)
            {
                return;
            }
        Label_02AA:
            base.InputFilename = input;
            base.ExpectInputHeaders = headers;
            base.InputFormat = format;
            this._x5f81ddd16c23e357.Clear();
            this._x26c511b92db96554.Clear();
            TextReader reader = null;
            try
            {
                int num = 0;
                goto Label_0099;
            Label_002A:
                if ((((uint) num) | 0xfffffffe) != 0)
                {
                    goto Label_0049;
                }
            Label_0044:
                if (headers)
                {
                    goto Label_008E;
                }
                goto Label_0061;
            Label_0049:
                if ((((uint) num) - ((uint) num)) < 0)
                {
                    goto Label_0044;
                }
            Label_0061:
                base.RecordCount = num;
                goto Label_0143;
            Label_006A:
                num++;
            Label_006E:
                if (reader.ReadLine() != null)
                {
                    goto Label_00AC;
                }
                if ((((uint) num2) | 3) != 0)
                {
                    goto Label_0044;
                }
            Label_008E:
                num--;
                goto Label_002A;
            Label_0099:
                reader = new StreamReader(base.InputFilename.OpenRead());
                goto Label_006E;
            Label_00AC:
                base.UpdateStatus(true);
                goto Label_006A;
            }
            catch (IOException exception)
            {
                throw new QuantError(exception);
            }
            finally
            {
                base.ReportDone(true);
                goto Label_011E;
            Label_00CD:
                if ((((uint) headers) + ((uint) num2)) < 0)
                {
                    goto Label_00EC;
                }
                goto Label_0142;
            Label_00E7:
                if (reader != null)
                {
                    goto Label_0130;
                }
                goto Label_0104;
            Label_00EC:
                if ((((uint) num2) + ((uint) flag)) < 0)
                {
                    goto Label_00E7;
                }
            Label_0104:
                base.InputFilename = input;
                base.ExpectInputHeaders = headers;
                base.InputFormat = format;
                if (0 == 0)
                {
                    goto Label_00CD;
                }
                goto Label_0142;
            Label_011E:
                if (((uint) num2) <= uint.MaxValue)
                {
                    goto Label_00E7;
                }
            Label_0130:
                try
                {
                    reader.Close();
                    goto Label_0104;
                }
                catch (IOException exception2)
                {
                    throw new QuantError(exception2);
                }
                goto Label_00EC;
            Label_0142:;
            }
            goto Label_0143;
        }

        public string GetColumnData(string name, ReadCSV csv)
        {
            if (this._x5f81ddd16c23e357.ContainsKey(name))
            {
                FileData data;
                BaseCachedColumn column = this._x5f81ddd16c23e357[name];
                while (!(column is FileData))
                {
                    return null;
                }
                if (0 == 0)
                {
                    data = (FileData) column;
                }
                return csv.Get(data.Index);
            }
            return null;
        }

        private static string x0049197442052640(string xc15bd84e01929885)
        {
            string str = xc15bd84e01929885.ToLower();
            goto Label_00D9;
        Label_000C:
            if (str.IndexOf("time") != -1)
            {
                return "time";
            }
            return xc15bd84e01929885;
        Label_0047:
            if (((0 != 0) || (str.IndexOf("date") == -1)) && (xc15bd84e01929885.IndexOf("yyyy") == -1))
            {
                goto Label_000C;
            }
            return "date";
        Label_0069:
            if (str.IndexOf("hi") == -1)
            {
                if (str.IndexOf("vol") != -1)
                {
                    return "volume";
                }
                goto Label_0047;
            }
            if (15 != 0)
            {
                return "high";
            }
            return xc15bd84e01929885;
        Label_007C:
            if (4 == 0)
            {
                goto Label_0095;
            }
            if (2 != 0)
            {
                goto Label_0069;
            }
            if (0 != 0)
            {
                goto Label_000C;
            }
        Label_0090:
            if (0 != 0)
            {
                goto Label_007C;
            }
            goto Label_00CE;
        Label_0095:
            if (str.IndexOf("low") != -1)
            {
                return "low";
            }
            if (0xff != 0)
            {
                goto Label_0090;
            }
            if ((0 != 0) || (0 == 0))
            {
                goto Label_007C;
            }
        Label_00CE:
            if (0 == 0)
            {
                if (0 != 0)
                {
                    goto Label_0047;
                }
                goto Label_0069;
            }
        Label_00D9:
            if (str.IndexOf("open") != -1)
            {
                return "open";
            }
            if (str.IndexOf("close") != -1)
            {
                return "close";
            }
            goto Label_0095;
        }

        public IDictionary<string, BaseCachedColumn> ColumnMapping
        {
            get
            {
                return this._x5f81ddd16c23e357;
            }
        }

        public IList<BaseCachedColumn> Columns
        {
            get
            {
                return this._x26c511b92db96554;
            }
        }
    }
}

