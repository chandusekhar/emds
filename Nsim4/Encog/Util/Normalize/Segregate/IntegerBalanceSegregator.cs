namespace Encog.Util.Normalize.Segregate
{
    using Encog.Util.Normalize;
    using Encog.Util.Normalize.Input;
    using System;
    using System.Collections.Generic;
    using System.Text;

    [Serializable]
    public class IntegerBalanceSegregator : ISegregator
    {
        private readonly int _count;
        private DataNormalization _normalization;
        private readonly IDictionary<int, int> _runningCounts;
        private readonly IInputField _target;

        public IntegerBalanceSegregator()
        {
            this._runningCounts = new Dictionary<int, int>();
        }

        public IntegerBalanceSegregator(IInputField target, int count)
        {
            this._runningCounts = new Dictionary<int, int>();
            this._target = target;
            this._count = count;
        }

        public string DumpCounts()
        {
            StringBuilder builder = new StringBuilder();
            using (IEnumerator<int> enumerator = this._runningCounts.Keys.GetEnumerator())
            {
                goto Label_0025;
            Label_0019:
                builder.Append(" count\n");
            Label_0025:
                if (enumerator.MoveNext())
                {
                    int current = enumerator.Current;
                    int num2 = this._runningCounts[current];
                    builder.Append(current);
                    builder.Append(" -> ");
                    builder.Append(num2);
                    goto Label_0019;
                }
            }
            return builder.ToString();
        }

        public void Init(DataNormalization normalization)
        {
            this._normalization = normalization;
        }

        public void PassInit()
        {
            this._runningCounts.Clear();
        }

        public bool ShouldInclude()
        {
            int currentValue = (int) this._target.CurrentValue;
            int num2 = 0;
        Label_0020:
            if (this._runningCounts.ContainsKey(currentValue))
            {
                num2 = this._runningCounts[currentValue];
            }
            if (num2 < this._count)
            {
                if ((((uint) num2) & 0) == 0)
                {
                    num2++;
                    this._runningCounts[currentValue] = num2;
                    return true;
                }
                goto Label_0020;
            }
            return false;
        }

        public int Count
        {
            get
            {
                return this._count;
            }
        }

        public DataNormalization Owner
        {
            get
            {
                return this._normalization;
            }
        }

        public IDictionary<int, int> RunningCounts
        {
            get
            {
                return this._runningCounts;
            }
        }

        public IInputField Target
        {
            get
            {
                return this._target;
            }
        }
    }
}

