namespace Encog.Util.Normalize.Segregate.Index
{
    using System;

    [Serializable]
    public class IndexSampleSegregator : IndexSegregator
    {
        private readonly int _endingIndex;
        private readonly int _sampleSize;
        private readonly int _startingIndex;

        public IndexSampleSegregator()
        {
        }

        public IndexSampleSegregator(int startingIndex, int endingIndex, int sampleSize)
        {
            this._sampleSize = sampleSize;
            this._startingIndex = startingIndex;
            this._endingIndex = endingIndex;
        }

        public override bool ShouldInclude()
        {
            int num = base.CurrentIndex % this._sampleSize;
            base.RollIndex();
            while ((num >= this._startingIndex) || ((((uint) num) + ((uint) num)) < 0))
            {
                return (num <= this._endingIndex);
            }
            return false;
        }

        public int EndingIndex
        {
            get
            {
                return this._endingIndex;
            }
        }

        public int SampleSize
        {
            get
            {
                return this._sampleSize;
            }
        }

        public int StartingIndex
        {
            get
            {
                return this._startingIndex;
            }
        }
    }
}

