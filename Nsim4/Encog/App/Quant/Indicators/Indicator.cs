namespace Encog.App.Quant.Indicators
{
    using Encog.App.Analyst.CSV.Basic;
    using Encog.App.Quant;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public abstract class Indicator : BaseCachedColumn
    {
        [CompilerGenerated]
        private int xacf35263800dfc76;
        [CompilerGenerated]
        private int xbec15e49ff61c63b;

        public Indicator(string name, bool input, bool output) : base(name, input, output)
        {
        }

        public abstract void Calculate(IDictionary<string, BaseCachedColumn> data, int length);
        public void Require(IDictionary<string, BaseCachedColumn> theData, string item)
        {
            if (!theData.ContainsKey(item))
            {
                throw new QuantError("To use this indicator, the underlying data must contain: " + item);
            }
        }

        public int BeginningIndex
        {
            [CompilerGenerated]
            get
            {
                return this.xbec15e49ff61c63b;
            }
            [CompilerGenerated]
            set
            {
                this.xbec15e49ff61c63b = value;
            }
        }

        public int EndingIndex
        {
            [CompilerGenerated]
            get
            {
                return this.xacf35263800dfc76;
            }
            [CompilerGenerated]
            set
            {
                this.xacf35263800dfc76 = value;
            }
        }

        public abstract int Periods { get; }
    }
}

