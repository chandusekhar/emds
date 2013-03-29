namespace Encog.Util.Normalize.Output.Nominal
{
    using Encog.MathUtil;
    using Encog.Util.Normalize.Input;
    using Encog.Util.Normalize.Output;
    using System;
    using System.Collections.Generic;

    [Serializable]
    public class OutputEquilateral : BasicOutputField
    {
        private int _currentValue;
        private Encog.MathUtil.Equilateral _equilateral;
        private readonly double _high;
        private readonly IList<NominalItem> _items;
        private readonly double _low;

        public OutputEquilateral() : this(1.0, -1.0)
        {
        }

        public OutputEquilateral(double low, double high)
        {
            this._items = new List<NominalItem>();
            this._high = high;
            this._low = low;
        }

        public void AddItem(IInputField inputField, double value)
        {
            this.AddItem(inputField, value - 0.1, value + 0.1);
        }

        public void AddItem(IInputField inputField, double low, double high)
        {
            NominalItem item = new NominalItem(inputField, low, high);
            this._items.Add(item);
        }

        public override double Calculate(int subfield)
        {
            return this._equilateral.Encode(this._currentValue)[subfield];
        }

        public override void RowInit()
        {
            int num = 0;
            goto Label_002E;
        Label_0007:
            if (this._equilateral == null)
            {
                this._equilateral = new Encog.MathUtil.Equilateral(this._items.Count, this._high, this._low);
                goto Label_0060;
            }
            return;
        Label_002E:
            while (num < this._items.Count)
            {
                NominalItem item = this._items[num];
                if (item.IsInRange())
                {
                    this._currentValue = num;
                    if ((((uint) num) + ((uint) num)) <= uint.MaxValue)
                    {
                        break;
                    }
                    goto Label_0060;
                }
                num++;
            }
            goto Label_0007;
        Label_0060:
            if ((((uint) num) <= uint.MaxValue) && ((((uint) num) | 0x7fffffff) != 0))
            {
                if (((uint) num) >= 0)
                {
                    return;
                }
                goto Label_002E;
            }
            goto Label_0007;
        }

        public Encog.MathUtil.Equilateral Equilateral
        {
            get
            {
                return this._equilateral;
            }
        }

        public double High
        {
            get
            {
                return this._high;
            }
        }

        public double Low
        {
            get
            {
                return this._low;
            }
        }

        public override int SubfieldCount
        {
            get
            {
                return (this._items.Count - 1);
            }
        }
    }
}

