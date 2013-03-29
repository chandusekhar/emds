namespace Encog.ML.Data.Buffer.CODEC
{
    using Encog.Util;
    using System;

    public class ArrayDataCODEC : IDataSetCODEC
    {
        private int _x08b9e0820ab2b457;
        private int _x7e648b416c264559;
        private int _xc0c4c459c6ccbd00;
        private double[][] _xcdaeea7afaf570ff;
        private double[][] _xf40f2d506fd08ad7;

        public ArrayDataCODEC()
        {
        }

        public ArrayDataCODEC(double[][] input, double[][] ideal)
        {
            this._xcdaeea7afaf570ff = input;
            this._xf40f2d506fd08ad7 = ideal;
            do
            {
                this._x7e648b416c264559 = input[0].Length;
                this._x08b9e0820ab2b457 = ideal[0].Length;
            }
            while (0 != 0);
            this._xc0c4c459c6ccbd00 = 0;
        }

        public void Close()
        {
        }

        public void PrepareRead()
        {
        }

        public void PrepareWrite(int recordCount, int inputSize, int idealSize)
        {
            this._xcdaeea7afaf570ff = EngineArray.AllocateDouble2D(recordCount, inputSize);
            this._xf40f2d506fd08ad7 = EngineArray.AllocateDouble2D(recordCount, idealSize);
            this._x7e648b416c264559 = inputSize;
            this._x08b9e0820ab2b457 = idealSize;
            this._xc0c4c459c6ccbd00 = 0;
        }

        public bool Read(double[] input, double[] ideal, ref double significance)
        {
            if (this._xc0c4c459c6ccbd00 >= this._xcdaeea7afaf570ff.Length)
            {
                return false;
            }
            EngineArray.ArrayCopy(this._xcdaeea7afaf570ff[this._xc0c4c459c6ccbd00], input);
            EngineArray.ArrayCopy(this._xf40f2d506fd08ad7[this._xc0c4c459c6ccbd00], ideal);
            this._xc0c4c459c6ccbd00++;
            do
            {
                significance = 1.0;
            }
            while (4 == 0);
            return true;
        }

        public void Write(double[] input, double[] ideal, double significance)
        {
            EngineArray.ArrayCopy(input, this._xcdaeea7afaf570ff[this._xc0c4c459c6ccbd00]);
            EngineArray.ArrayCopy(ideal, this._xf40f2d506fd08ad7[this._xc0c4c459c6ccbd00]);
            this._xc0c4c459c6ccbd00++;
        }

        public double[][] Ideal
        {
            get
            {
                return this._xf40f2d506fd08ad7;
            }
        }

        public int IdealSize
        {
            get
            {
                return this._x08b9e0820ab2b457;
            }
        }

        public double[][] Input
        {
            get
            {
                return this._xcdaeea7afaf570ff;
            }
        }

        public int InputSize
        {
            get
            {
                return this._x7e648b416c264559;
            }
        }
    }
}

