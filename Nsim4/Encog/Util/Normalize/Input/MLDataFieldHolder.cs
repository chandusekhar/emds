namespace Encog.Util.Normalize.Input
{
    using Encog.ML.Data;
    using System;
    using System.Collections.Generic;

    [Serializable]
    public class MLDataFieldHolder
    {
        private readonly InputFieldMLDataSet _field;
        private readonly IEnumerator<IMLDataPair> _iterator;
        private IMLDataPair _pair;

        public MLDataFieldHolder(IEnumerator<IMLDataPair> iterator, InputFieldMLDataSet field)
        {
            this._iterator = iterator;
            this._field = field;
        }

        public IEnumerator<IMLDataPair> GetEnumerator()
        {
            return this._iterator;
        }

        public void ObtainPair()
        {
            this._iterator.MoveNext();
            this._pair = this._iterator.Current;
        }

        public InputFieldMLDataSet Field
        {
            get
            {
                return this._field;
            }
        }

        public IMLDataPair Pair
        {
            get
            {
                return this._pair;
            }
            set
            {
                this._pair = value;
            }
        }
    }
}

