namespace Encog.Util.Normalize.Segregate.Index
{
    using System;

    [Serializable]
    public class IndexRangeSegregator : IndexSegregator
    {
        private readonly int _endingIndex;
        private readonly int _startingIndex;

        public IndexRangeSegregator()
        {
        }

        public IndexRangeSegregator(int startingIndex, int endingIndex)
        {
            this._startingIndex = startingIndex;
            this._endingIndex = endingIndex;
        }

        public override bool ShouldInclude()
        {
            bool flag = (base.CurrentIndex >= this._startingIndex) && (base.CurrentIndex <= this._endingIndex);
            base.RollIndex();
            return flag;
        }

        public int EndingIndex
        {
            get
            {
                return this._endingIndex;
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

