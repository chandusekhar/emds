namespace Encog.App.Quant.Loader.Yahoo
{
    using Encog.App.Quant;
    using Encog.Util;
    using Encog.Util.CSV;
    using Encog.Util.HTTP;
    using Encog.Util.Time;
    using System;
    using System.IO;
    using System.Net;
    using System.Runtime.CompilerServices;
    using System.Text;

    public class YahooDownload
    {
        public const string IndexDjia = "^dji";
        public const string IndexNasdaq = "^ixic";
        public const string IndexSp500 = "^gspc";
        [CompilerGenerated]
        private int x04109b657595c91e;

        public YahooDownload()
        {
            this.Precision = 10;
        }

        public void LoadAllData(string ticker, string output, CSVFormat outputFormat, DateTime from, DateTime to)
        {
            try
            {
                HttpWebResponse response;
                ReadCSV dcsv;
                TextWriter writer;
                DateTime time;
                double num;
                double num2;
                double num3;
                double num4;
                double num5;
                long num6;
                StringBuilder builder;
                Uri requestUri = x38c212309d8d5dd3(ticker, from, to);
                goto Label_029A;
            Label_0010:
                builder.Append(outputFormat.Format(num, this.Precision));
                writer.WriteLine(builder.ToString());
            Label_0034:
                if (dcsv.Next())
                {
                    goto Label_01E2;
                }
                writer.Close();
                return;
            Label_0049:
                builder.Append(outputFormat.Separator);
                builder.Append(outputFormat.Format(num3, this.Precision));
                builder.Append(outputFormat.Separator);
                builder.Append(num6);
                builder.Append(outputFormat.Separator);
                if ((((uint) num4) + ((uint) num2)) >= 0)
                {
                    goto Label_0010;
                }
                return;
            Label_00B3:
                builder.Append(outputFormat.Format(num2, this.Precision));
                builder.Append(outputFormat.Separator);
                builder.Append(outputFormat.Format(num4, this.Precision));
                if ((((uint) num6) | 4) == 0)
                {
                    goto Label_0034;
                }
                builder.Append(outputFormat.Separator);
            Label_0116:
                builder.Append(outputFormat.Format(num5, this.Precision));
                goto Label_0192;
            Label_012E:
                builder.Append(NumericDateUtil.DateTime2Long(time));
                builder.Append(outputFormat.Separator);
                builder.Append(NumericDateUtil.x93295384d7a86d9d(time));
                if ((((uint) num6) | 3) == 0)
                {
                    goto Label_020C;
                }
                if (-2147483648 == 0)
                {
                    goto Label_01FE;
                }
                builder.Append(outputFormat.Separator);
                goto Label_00B3;
            Label_0192:
                if (0 == 0)
                {
                    goto Label_0049;
                }
                return;
            Label_019D:
                builder = new StringBuilder();
                if (((uint) num4) >= 0)
                {
                    goto Label_012E;
                }
                goto Label_027A;
            Label_01BE:
                num5 = dcsv.GetDouble("low");
                num6 = (long) dcsv.GetDouble("volume");
                goto Label_0243;
            Label_01E2:
                time = dcsv.GetDate("date");
                num = dcsv.GetDouble("adj close");
            Label_01FE:
                num2 = dcsv.GetDouble("open");
            Label_020C:
                num3 = dcsv.GetDouble("close");
                num4 = dcsv.GetDouble("high");
                if ((((uint) num3) - ((uint) num4)) <= uint.MaxValue)
                {
                    goto Label_01BE;
                }
            Label_0243:
                if ((((uint) num6) & 0) == 0)
                {
                    goto Label_019D;
                }
            Label_0257:
                writer.WriteLine("date,time,open price,high price,low price,close price,volume,adjusted price");
                if (((uint) num) >= 0)
                {
                    goto Label_0034;
                }
                goto Label_019D;
            Label_027A:
                if ((((uint) num5) & 0) != 0)
                {
                    goto Label_0116;
                }
                goto Label_0257;
            Label_029A:
                response = (HttpWebResponse) WebRequest.Create(requestUri).GetResponse();
                Stream responseStream = response.GetResponseStream();
                if (((uint) num5) < 0)
                {
                    goto Label_00B3;
                }
                dcsv = new ReadCSV(responseStream, true, CSVFormat.English);
                writer = new StreamWriter(output);
                goto Label_027A;
            }
            catch (WebException exception)
            {
                throw new QuantError(exception);
            }
        }

        private static Uri x38c212309d8d5dd3(string x96e4701dec47675e, DateTime x7f8a886f51b477eb, DateTime x3ed4f4f0195b98d7)
        {
            FormUtility utility;
            byte[] buffer;
            MemoryStream os = new MemoryStream();
            goto Label_012A;
        Label_000B:
            buffer = os.GetBuffer();
            string uriString = "http://ichart.finance.yahoo.com/table.csv?" + StringUtil.FromBytes(buffer);
            if (3 != 0)
            {
                return new Uri(uriString);
            }
        Label_012A:
            utility = new FormUtility(os, null);
            utility.Add("s", x96e4701dec47675e);
            utility.Add("a", (x7f8a886f51b477eb.Month - 1));
            utility.Add("b", x7f8a886f51b477eb.Day);
            if (2 == 0)
            {
                goto Label_000B;
            }
            utility.Add("c", x7f8a886f51b477eb.Year);
            utility.Add("d", (x3ed4f4f0195b98d7.Month - 1));
        Label_010C:
            utility.Add("e", x3ed4f4f0195b98d7.Day);
            utility.Add("f", x3ed4f4f0195b98d7.Year);
            utility.Add("g", "d");
            utility.Add("ignore", ".csv");
            os.Close();
            if (8 != 0)
            {
                if (0 != 0)
                {
                    goto Label_010C;
                }
                goto Label_000B;
            }
            goto Label_012A;
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
    }
}

