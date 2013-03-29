namespace Encog.ML.Data.Buffer
{
    using Encog;
    using Encog.ML.Data;
    using Encog.ML.Data.Basic;
    using Encog.ML.Data.Buffer.CODEC;
    using System;
    using System.Runtime.CompilerServices;

    public class MemoryDataLoader
    {
        private readonly IDataSetCODEC _x75d376891c19d365;
        [CompilerGenerated]
        private BasicMLDataSet x16dda60c3d61d62d;
        [CompilerGenerated]
        private IStatusReportable x23bce9651860d8f2;

        public MemoryDataLoader(IDataSetCODEC codec)
        {
            this._x75d376891c19d365 = codec;
            this.x658c509a55e4e71a = new NullStatusReportable();
        }

        public IMLDataSet External2Memory()
        {
            double[] numArray;
            double[] numArray2;
            int num;
            int num2;
            double num3;
            IMLData data;
            IMLData data2;
            IMLDataPair pair;
            this.x658c509a55e4e71a.Report(0, 0, "Importing to memory");
            goto Label_0166;
        Label_0017:
            if (1 == 0)
            {
                goto Label_011C;
            }
        Label_0021:
            if (this._x75d376891c19d365.Read(numArray, numArray2, ref num3))
            {
                data = null;
                data2 = new BasicMLData(numArray);
                goto Label_00FF;
            }
            this._x75d376891c19d365.Close();
            this.x658c509a55e4e71a.Report(0, 0, "Done importing to memory");
            return this.Result;
        Label_0065:
            this.x658c509a55e4e71a.Report(0, num, "Importing...");
            goto Label_0017;
        Label_00B8:
            pair = new BasicMLDataPair(data2, data);
            pair.Significance = num3;
            if (0 != 0)
            {
                goto Label_0166;
            }
            this.Result.Add(pair);
            if ((((uint) num3) - ((uint) num2)) >= 0)
            {
                num++;
                if ((((uint) num) & 0) != 0)
                {
                    goto Label_016E;
                }
                if ((((uint) num) + ((uint) num)) < 0)
                {
                    goto Label_00B8;
                }
            }
            if (3 != 0)
            {
                num2++;
                if (num2 < 0x2710)
                {
                    goto Label_0021;
                }
                num2 = 0;
                goto Label_0065;
            }
            goto Label_0017;
        Label_00FF:
            if (this._x75d376891c19d365.IdealSize <= 0)
            {
                goto Label_00B8;
            }
        Label_011C:
            data = new BasicMLData(numArray2);
            if (0x7fffffff == 0)
            {
                goto Label_00FF;
            }
            goto Label_00B8;
        Label_0166:
            if (this.Result == null)
            {
                this.Result = new BasicMLDataSet();
                if (0 == 0)
                {
                    if (((uint) num3) > uint.MaxValue)
                    {
                        goto Label_0065;
                    }
                }
                else
                {
                    goto Label_01A6;
                }
            }
        Label_016E:
            numArray = new double[this._x75d376891c19d365.InputSize];
            numArray2 = new double[this._x75d376891c19d365.IdealSize];
            this._x75d376891c19d365.PrepareRead();
            num = 0;
            num2 = 0;
            num3 = 1.0;
        Label_01A6:
            if ((((uint) num2) + ((uint) num)) <= uint.MaxValue)
            {
                goto Label_0021;
            }
            goto Label_00B8;
        }

        public IDataSetCODEC CODEC
        {
            get
            {
                return this._x75d376891c19d365;
            }
        }

        public BasicMLDataSet Result
        {
            [CompilerGenerated]
            get
            {
                return this.x16dda60c3d61d62d;
            }
            [CompilerGenerated]
            set
            {
                this.x16dda60c3d61d62d = value;
            }
        }

        private IStatusReportable x658c509a55e4e71a
        {
            [CompilerGenerated]
            get
            {
                return this.x23bce9651860d8f2;
            }
            [CompilerGenerated]
            set
            {
                this.x23bce9651860d8f2 = value;
            }
        }
    }
}

