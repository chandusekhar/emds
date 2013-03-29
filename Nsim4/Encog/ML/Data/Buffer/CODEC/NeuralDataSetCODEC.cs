namespace Encog.ML.Data.Buffer.CODEC
{
    using Encog.ML.Data;
    using Encog.ML.Data.Basic;
    using Encog.Util;
    using System;
    using System.Collections.Generic;

    public class NeuralDataSetCODEC : IDataSetCODEC
    {
        private int _x08b9e0820ab2b457;
        private IEnumerator<IMLDataPair> _x2f53dbd7a1295c54;
        private int _x7e648b416c264559;
        private readonly IMLDataSet _xae416c08bf6984a9;

        public NeuralDataSetCODEC(IMLDataSet dataset)
        {
            this._xae416c08bf6984a9 = dataset;
            this._x7e648b416c264559 = dataset.InputSize;
            this._x08b9e0820ab2b457 = dataset.IdealSize;
        }

        public void Close()
        {
        }

        public void PrepareRead()
        {
            this._x2f53dbd7a1295c54 = this._xae416c08bf6984a9.GetEnumerator();
        }

        public void PrepareWrite(int recordCount, int inputSize, int idealSize)
        {
            this._x7e648b416c264559 = inputSize;
            this._x08b9e0820ab2b457 = idealSize;
        }

        public bool Read(double[] input, double[] ideal, ref double significance)
        {
            if (!this._x2f53dbd7a1295c54.MoveNext())
            {
                return false;
            }
            IMLDataPair current = this._x2f53dbd7a1295c54.Current;
            if (-1 != 0)
            {
            }
            EngineArray.ArrayCopy(current.Input.Data, input);
            EngineArray.ArrayCopy(current.Ideal.Data, ideal);
            significance = current.Significance;
            return true;
        }

        public void Write(double[] input, double[] ideal, double significance)
        {
            IMLDataPair pair = BasicMLDataPair.CreatePair(this._x7e648b416c264559, this._x08b9e0820ab2b457);
            EngineArray.ArrayCopy(input, pair.Input.Data);
            EngineArray.ArrayCopy(ideal, pair.Ideal.Data);
            pair.Significance = significance;
        }

        public int IdealSize
        {
            get
            {
                return this._x08b9e0820ab2b457;
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

