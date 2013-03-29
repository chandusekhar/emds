namespace Encog.ML.Data.Market.Loader
{
    using Encog.ML.Data.Market;
    using Encog.Util.CSV;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.CompilerServices;

    public class CSVLoader : IMarketLoader
    {
        public List<MarketDataType> TypesLoaded = new List<MarketDataType>();
        [CompilerGenerated]
        private string x04109b657595c91e;
        [CompilerGenerated]
        private CSVFormat x635d23df968f69c1;
        [CompilerGenerated]
        private string x8ab51fbe6b354044;
        [CompilerGenerated]
        private string xa2d6488bffd0c98e;

        public CSVFormat fromStringCSVFormattoCSVFormat(string csvformat)
        {
            string str = csvformat;
            if (str != null)
            {
                if (str == "Decimal Point")
                {
                    if (2 != 0)
                    {
                        this.x9c5d9c5f2c877175 = CSVFormat.DecimalPoint;
                        if (0 == 0)
                        {
                            goto Label_00A6;
                        }
                    }
                    else
                    {
                        goto Label_00A6;
                    }
                }
                if (str == "Decimal Comma")
                {
                    this.x9c5d9c5f2c877175 = CSVFormat.DecimalComma;
                }
                else if (!(str == "English Format"))
                {
                    if (str == "EG Format")
                    {
                        this.x9c5d9c5f2c877175 = CSVFormat.EgFormat;
                    }
                }
                else
                {
                    this.x9c5d9c5f2c877175 = CSVFormat.English;
                }
            }
        Label_00A6:
            return this.x9c5d9c5f2c877175;
        }

        public string GetFile(string file)
        {
            throw new NotImplementedException();
        }

        public ICollection<LoadedMarketData> Load(TickerSymbol ticker, IList<MarketDataType> dataNeeded, DateTime from, DateTime to)
        {
            CSVFormLoader loader;
            ICollection<LoadedMarketData> is2 = new List<LoadedMarketData>();
            if (0 == 0)
            {
                loader = new CSVFormLoader();
                if ((0 == 0) && !File.Exists(loader.Chosenfile))
                {
                    return null;
                }
            }
            this.x9c5d9c5f2c877175 = loader.format;
            foreach (MarketDataType type in loader.TypesLoaded)
            {
                this.TypesLoaded.Add(type);
            }
            this.x21d82b8f3e4c4642 = loader.DateTimeFormatTextBox.Text;
            return this.ReadAndCallLoader(ticker, dataNeeded, from, to, loader.Chosenfile);
        }

        public ICollection<LoadedMarketData> ReadAndCallLoader(TickerSymbol symbol, IList<MarketDataType> neededTypes, DateTime from, DateTime to, string File)
        {
            try
            {
                ReadCSV dcsv;
                DateTime time;
                double num;
                double num2;
                double num3;
                double num4;
                double num5;
                LoadedMarketData data;
                ICollection<LoadedMarketData> is3;
                ICollection<LoadedMarketData> is2 = new List<LoadedMarketData>();
                goto Label_0109;
            Label_000B:
                is3 = is2;
                if ((((uint) num5) + ((uint) num4)) >= 0)
                {
                    return is3;
                }
                if ((((uint) num3) & 0) == 0)
                {
                    goto Label_0088;
                }
            Label_003D:
                is2.Add(data);
            Label_0045:
                if (dcsv.Next())
                {
                    goto Label_00EF;
                }
            Label_0050:
                dcsv.Close();
                if (0 == 0)
                {
                    goto Label_000B;
                }
                goto Label_0088;
            Label_005E:
                data.SetData(MarketDataType.High, num3);
                data.SetData(MarketDataType.Low, num4);
                data.SetData(MarketDataType.Close, num2);
                data.SetData(MarketDataType.Volume, num5);
                goto Label_003D;
            Label_0088:
                num2 = dcsv.GetDouble("High");
                num3 = dcsv.GetDouble("Low");
                num4 = dcsv.GetDouble("Close");
                num5 = dcsv.GetDouble("Volume");
                new LoadedMarketData(time, symbol).SetData(MarketDataType.Open, num);
                if (((uint) num3) >= 0)
                {
                    goto Label_005E;
                }
                goto Label_003D;
            Label_00EF:
                time = dcsv.GetDate("Time");
                num = dcsv.GetDouble("Open");
                goto Label_0088;
            Label_0109:
                dcsv = new ReadCSV(File, true, this.x9c5d9c5f2c877175);
                if (((uint) num3) > uint.MaxValue)
                {
                    goto Label_000B;
                }
                dcsv.DateFormat = this.x21d82b8f3e4c4642.Normalize();
                if (((uint) num3) > uint.MaxValue)
                {
                    goto Label_0050;
                }
                goto Label_0045;
            }
            catch (Exception exception)
            {
                Console.WriteLine("Something went wrong reading the csv");
                Console.WriteLine("Something went wrong reading the csv:" + exception.Message);
            }
            Console.WriteLine("Something went wrong reading the csv");
            return null;
        }

        private string x21d82b8f3e4c4642
        {
            [CompilerGenerated]
            get
            {
                return this.xa2d6488bffd0c98e;
            }
            [CompilerGenerated]
            set
            {
                this.xa2d6488bffd0c98e = value;
            }
        }

        private string x532f6ea9ef2353a1
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

        private CSVFormat x9c5d9c5f2c877175
        {
            [CompilerGenerated]
            get
            {
                return this.x635d23df968f69c1;
            }
            [CompilerGenerated]
            set
            {
                this.x635d23df968f69c1 = value;
            }
        }

        private string xd9b0e71de6b2ac41
        {
            [CompilerGenerated]
            get
            {
                return this.x8ab51fbe6b354044;
            }
            [CompilerGenerated]
            set
            {
                this.x8ab51fbe6b354044 = value;
            }
        }
    }
}

