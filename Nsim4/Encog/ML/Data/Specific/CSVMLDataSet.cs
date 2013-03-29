namespace Encog.ML.Data.Specific
{
    using Encog.ML.Data.Basic;
    using Encog.ML.Data.Buffer;
    using Encog.ML.Data.Buffer.CODEC;
    using Encog.Util.CSV;
    using System;

    public class CSVMLDataSet : BasicMLDataSet
    {
        private readonly int _x08b9e0820ab2b457;
        private readonly CSVFormat _x5786461d089b10a0;
        private readonly int _x7e648b416c264559;
        private readonly bool _x94e6ca5ac178dbd0;
        private readonly string _xb41a802ca5fde63b;

        public CSVMLDataSet(string filename, int inputSize, int idealSize, bool headers) : this(filename, inputSize, idealSize, headers, CSVFormat.English, false)
        {
        }

        public CSVMLDataSet(string filename, int inputSize, int idealSize, bool headers, CSVFormat format, bool expectSignificance)
        {
            this._xb41a802ca5fde63b = filename;
            this._x7e648b416c264559 = inputSize;
            if (-2 != 0)
            {
                this._x08b9e0820ab2b457 = idealSize;
            }
            this._x5786461d089b10a0 = format;
            this._x94e6ca5ac178dbd0 = headers;
            IDataSetCODEC codec = new CSVDataCODEC(filename, format, headers, inputSize, idealSize, expectSignificance);
            MemoryDataLoader loader2 = new MemoryDataLoader(codec) {
                Result = this
            };
            loader2.External2Memory();
        }

        public string Filename
        {
            get
            {
                return this._xb41a802ca5fde63b;
            }
        }

        public CSVFormat Format
        {
            get
            {
                return this._x5786461d089b10a0;
            }
        }

        public bool Headers
        {
            get
            {
                return this._x94e6ca5ac178dbd0;
            }
        }

        public override int IdealSize
        {
            get
            {
                return this._x08b9e0820ab2b457;
            }
        }

        public override int InputSize
        {
            get
            {
                return this._x7e648b416c264559;
            }
        }
    }
}

