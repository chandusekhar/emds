namespace Encog.ML.Data.Market.Loader
{
    using Encog.ML.Data.Market;
    using Encog.Util;
    using Encog.Util.CSV;
    using Encog.Util.HTTP;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;

    public class YahooFinanceLoader : IMarketLoader
    {
        public string GetFile(string file)
        {
            throw new NotImplementedException();
        }

        public ICollection<LoadedMarketData> Load(TickerSymbol ticker, IList<MarketDataType> dataNeeded, DateTime from, DateTime to)
        {
            ICollection<LoadedMarketData> is2 = new List<LoadedMarketData>();
            HttpWebResponse response = (HttpWebResponse) WebRequest.Create(x38c212309d8d5dd3(ticker, from, to)).GetResponse();
            using (Stream stream = response.GetResponseStream())
            {
                DateTime time;
                double num;
                double num2;
                double num3;
                double num4;
                double num5;
                double num6;
                LoadedMarketData data;
                ReadCSV dcsv = new ReadCSV(stream, true, CSVFormat.DecimalPoint);
                goto Label_005B;
            Label_003F:
                data.SetData(MarketDataType.Open, num2);
            Label_0049:
                data.SetData(MarketDataType.Volume, num6);
                is2.Add(data);
            Label_005B:
                if (dcsv.Next())
                {
                    goto Label_01AF;
                }
                dcsv.Close();
                stream.Close();
                if ((((uint) num) - ((uint) num5)) <= uint.MaxValue)
                {
                    goto Label_0125;
                }
                if ((((uint) num) & 0) == 0)
                {
                    goto Label_00B0;
                }
            Label_00A4:
                data.SetData(MarketDataType.Low, num5);
                goto Label_003F;
            Label_00B0:
                data.SetData(MarketDataType.AdjustedClose, num);
                do
                {
                    data.SetData(MarketDataType.Open, num2);
                    if ((((uint) num) - ((uint) num6)) > uint.MaxValue)
                    {
                        goto Label_0049;
                    }
                    data.SetData(MarketDataType.Close, num3);
                    data.SetData(MarketDataType.High, num4);
                }
                while ((((uint) num5) - ((uint) num3)) > uint.MaxValue);
                if (((uint) num2) >= 0)
                {
                    goto Label_00A4;
                }
                goto Label_003F;
            Label_0125:
                if (((uint) num2) >= 0)
                {
                    return is2;
                }
                goto Label_005B;
            Label_013C:
                num6 = dcsv.GetDouble("volume");
                data = new LoadedMarketData(time, ticker);
                if ((((uint) num2) | 2) == 0)
                {
                    goto Label_017C;
                }
                goto Label_00B0;
            Label_016E:
                num2 = dcsv.GetDouble("open");
            Label_017C:
                num3 = dcsv.GetDouble("close");
                num4 = dcsv.GetDouble("high");
                num5 = dcsv.GetDouble("low");
                goto Label_013C;
            Label_01AF:
                time = dcsv.GetDate("date");
                num = dcsv.GetDouble("adj close");
                if ((((uint) num3) + ((uint) num6)) <= uint.MaxValue)
                {
                    goto Label_016E;
                }
                goto Label_00B0;
            }
        }

        private static Uri x38c212309d8d5dd3(TickerSymbol x96e4701dec47675e, DateTime x7f8a886f51b477eb, DateTime x3ed4f4f0195b98d7)
        {
            byte[] buffer;
            MemoryStream os = new MemoryStream();
            FormUtility utility = new FormUtility(os, null);
            utility.Add("s", x96e4701dec47675e.Symbol.ToUpper());
            if (0 == 0)
            {
                utility.Add("a", (x7f8a886f51b477eb.Month - 1));
                utility.Add("b", x7f8a886f51b477eb.Day);
                if (4 == 0)
                {
                    goto Label_0018;
                }
                utility.Add("c", x7f8a886f51b477eb.Year);
                utility.Add("d", (x3ed4f4f0195b98d7.Month - 1));
                utility.Add("e", x3ed4f4f0195b98d7.Day);
                utility.Add("f", x3ed4f4f0195b98d7.Year);
                utility.Add("g", "d");
                goto Label_0061;
            }
        Label_000B:
            if (0x7fffffff == 0)
            {
                goto Label_0061;
            }
            os.Close();
        Label_0018:
            buffer = os.GetBuffer();
            return new Uri("http://ichart.finance.yahoo.com/table.csv?" + StringUtil.FromBytes(buffer));
        Label_0061:
            utility.Add("ignore", ".csv");
            goto Label_000B;
        }
    }
}

