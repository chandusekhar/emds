namespace Encog.Util.Normalize.Input
{
    using Encog.ML.Data;
    using System;

    [Serializable]
    public class InputFieldMLDataSet : BasicInputField
    {
        private readonly IMLDataSet _data;
        private readonly int _offset;

        public InputFieldMLDataSet(bool usedForNetworkInput, IMLDataSet data, int offset)
        {
            this._data = data;
            this._offset = offset;
            base.UsedForNetworkInput = usedForNetworkInput;
        }

        public IMLDataSet NeuralDataSet
        {
            get
            {
                return this._data;
            }
        }

        public int Offset
        {
            get
            {
                return this._offset;
            }
        }
    }
}

