namespace Encog.Util.CSV
{
    using Encog;
    using System;

    public class CSVError : EncogError
    {
        public CSVError(Exception e) : base(e)
        {
        }

        public CSVError(string str) : base(str)
        {
        }
    }
}

