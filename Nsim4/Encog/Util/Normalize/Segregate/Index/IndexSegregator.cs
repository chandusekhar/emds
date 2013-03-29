namespace Encog.Util.Normalize.Segregate.Index
{
    using Encog.Util.Normalize;
    using Encog.Util.Normalize.Segregate;
    using System;

    [Serializable]
    public abstract class IndexSegregator : ISegregator
    {
        private int _currentIndex;
        private DataNormalization _normalization;

        protected IndexSegregator()
        {
        }

        public void Init(DataNormalization normalization)
        {
            this._normalization = normalization;
        }

        public void PassInit()
        {
            this._currentIndex = 0;
        }

        public void RollIndex()
        {
            this._currentIndex++;
        }

        public abstract bool ShouldInclude();

        public int CurrentIndex
        {
            get
            {
                return this._currentIndex;
            }
        }

        public DataNormalization Owner
        {
            get
            {
                return this._normalization;
            }
        }
    }
}

