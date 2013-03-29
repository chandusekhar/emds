namespace Encog.App.Analyst.CSV.Basic
{
    using System;
    using System.Runtime.CompilerServices;

    public class FileData : BaseCachedColumn
    {
        public const string Close = "close";
        public const string Date = "date";
        public const string High = "high";
        public const string Low = "low";
        public const string Open = "open";
        public const string Time = "time";
        public const string Volume = "volume";
        [CompilerGenerated]
        private int x2c232604070cc09d;

        public FileData(string theName, int theIndex, bool theInput, bool theOutput) : base(theName, theInput, theOutput)
        {
            base.Output = theOutput;
            this.Index = theIndex;
        }

        public int Index
        {
            [CompilerGenerated]
            get
            {
                return this.x2c232604070cc09d;
            }
            [CompilerGenerated]
            set
            {
                this.x2c232604070cc09d = value;
            }
        }
    }
}

