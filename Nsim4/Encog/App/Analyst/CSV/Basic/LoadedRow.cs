namespace Encog.App.Analyst.CSV.Basic
{
    using Encog.Util.CSV;
    using System;

    public class LoadedRow
    {
        private readonly string[] _x4a3f0a05c02f235f;

        public LoadedRow(ReadCSV csv) : this(csv, 0)
        {
        }

        public LoadedRow(ReadCSV csv, int extra)
        {
            int count;
            int num2;
            if ((((uint) num2) + ((uint) count)) >= 0)
            {
            }
            count = csv.GetCount();
            this._x4a3f0a05c02f235f = new string[count + extra];
            for (num2 = 0; num2 < count; num2++)
            {
                this._x4a3f0a05c02f235f[num2] = csv.Get(num2);
            }
        }

        public string[] Data
        {
            get
            {
                return this._x4a3f0a05c02f235f;
            }
        }
    }
}

