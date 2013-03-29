namespace Encog.ML.Data.Buffer.CODEC
{
    using Encog.ML.Data.Buffer;
    using Encog.Util;
    using Encog.Util.CSV;
    using System;
    using System.IO;
    using System.Text;

    public class CSVDataCODEC : IDataSetCODEC
    {
        private bool _x2602a84fb5c05ca2;
        private int _x43f451310e815b76;
        private readonly CSVFormat _x5786461d089b10a0;
        private ReadCSV _x880b5c00ed0b619c;
        private readonly bool _x94e6ca5ac178dbd0;
        private TextWriter _x9c13656d94fc62d0;
        private readonly string _xb44380e048627945;
        private int _xb52d4a98fad404da;

        public CSVDataCODEC(string file, CSVFormat format, bool significance)
        {
            this._xb44380e048627945 = file;
            this._x5786461d089b10a0 = format;
            this._x2602a84fb5c05ca2 = significance;
        }

        public CSVDataCODEC(string file, CSVFormat format, bool headers, int inputCount, int idealCount, bool significance)
        {
            if ((((uint) inputCount) - ((uint) significance)) < 0)
            {
            }
        Label_0063:
            if (this._x43f451310e815b76 != 0)
            {
                throw new BufferedDataError("To export CSV, you must use the CSVDataCODEC constructor that does not specify input or ideal sizes.");
            }
        Label_006B:
            this._xb44380e048627945 = file;
            if ((((uint) inputCount) - ((uint) inputCount)) <= uint.MaxValue)
            {
                this._x5786461d089b10a0 = format;
                this._x43f451310e815b76 = inputCount;
                this._xb52d4a98fad404da = idealCount;
                this._x94e6ca5ac178dbd0 = headers;
                this._x2602a84fb5c05ca2 = significance;
                if ((((uint) headers) - ((uint) inputCount)) > uint.MaxValue)
                {
                    goto Label_0063;
                    if ((((uint) significance) + ((uint) headers)) >= 0)
                    {
                        goto Label_006B;
                    }
                    goto Label_0063;
                }
            }
        }

        public void Close()
        {
            if (this._x880b5c00ed0b619c == null)
            {
                goto Label_0014;
            }
            if (0 == 0)
            {
                goto Label_0025;
            }
        Label_000B:
            this._x9c13656d94fc62d0 = null;
            return;
        Label_0014:
            if (this._x9c13656d94fc62d0 != null)
            {
                this._x9c13656d94fc62d0.Close();
                goto Label_000B;
            }
            if (0x7fffffff != 0)
            {
                return;
            }
        Label_0025:
            this._x880b5c00ed0b619c.Close();
            this._x880b5c00ed0b619c = null;
            goto Label_0014;
        }

        public void PrepareRead()
        {
            if (this._x43f451310e815b76 == 0)
            {
                throw new BufferedDataError("To import CSV, you must use the CSVDataCODEC constructor that specifies input and ideal sizes.");
            }
            this._x880b5c00ed0b619c = new ReadCSV(this._xb44380e048627945, this._x94e6ca5ac178dbd0, this._x5786461d089b10a0);
        }

        public void PrepareWrite(int recordCount, int inputSize, int idealSize)
        {
            try
            {
                this._x43f451310e815b76 = inputSize;
                this._xb52d4a98fad404da = idealSize;
                this._x9c13656d94fc62d0 = new StreamWriter(new FileStream(this._xb44380e048627945, FileMode.Create));
            }
            catch (IOException exception)
            {
                throw new BufferedDataError(exception);
            }
        }

        public bool Read(double[] input, double[] ideal, ref double significance)
        {
            int num;
            int num3;
            if (!this._x880b5c00ed0b619c.Next())
            {
                return false;
            }
            goto Label_00A8;
        Label_005D:
            while (num3 < ideal.Length)
            {
                ideal[num3] = this._x880b5c00ed0b619c.GetDouble(num++);
                num3++;
            }
            if (((uint) num3) >= 0)
            {
                if (this._x2602a84fb5c05ca2)
                {
                    significance = this._x880b5c00ed0b619c.GetDouble(num++);
                }
                else
                {
                    significance = 1.0;
                }
                return true;
            }
        Label_00A8:
            num = 0;
            if (0 == 0)
            {
                int index = 0;
                while (index < input.Length)
                {
                    input[index] = this._x880b5c00ed0b619c.GetDouble(num++);
                    index++;
                    if (((uint) num3) < 0)
                    {
                        goto Label_005D;
                    }
                }
                num3 = 0;
            }
            goto Label_005D;
        }

        public void Write(double[] input, double[] ideal, double significance)
        {
            double[] numArray;
            StringBuilder builder;
            if (!this._x2602a84fb5c05ca2)
            {
                double[] dst = new double[input.Length + ideal.Length];
                EngineArray.ArrayCopy(input, dst);
                if (0 == 0)
                {
                    EngineArray.ArrayCopy(ideal, 0, dst, input.Length, ideal.Length);
                    StringBuilder result = new StringBuilder();
                    NumberList.ToList(this._x5786461d089b10a0, result, dst);
                    this._x9c13656d94fc62d0.WriteLine(result.ToString());
                }
                if ((((uint) significance) - ((uint) significance)) >= 0)
                {
                    return;
                }
                goto Label_00CF;
            }
            if (3 != 0)
            {
                goto Label_00CF;
            }
            if ((((uint) significance) + ((uint) significance)) >= 0)
            {
                goto Label_00A8;
            }
        Label_007C:
            this._x9c13656d94fc62d0.WriteLine(builder.ToString());
            if ((((uint) significance) + ((uint) significance)) < 0)
            {
                goto Label_00FB;
            }
            return;
        Label_00A8:
            NumberList.ToList(this._x5786461d089b10a0, builder, numArray);
            goto Label_007C;
        Label_00CF:
            numArray = new double[(input.Length + ideal.Length) + 1];
            EngineArray.ArrayCopy(input, numArray);
            EngineArray.ArrayCopy(ideal, 0, numArray, input.Length, ideal.Length);
            numArray[numArray.Length - 1] = significance;
        Label_00FB:
            builder = new StringBuilder();
            goto Label_00A8;
        }

        public int IdealSize
        {
            get
            {
                return this._xb52d4a98fad404da;
            }
        }

        public int InputSize
        {
            get
            {
                return this._x43f451310e815b76;
            }
        }
    }
}

