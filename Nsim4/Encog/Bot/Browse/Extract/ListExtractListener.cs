namespace Encog.Bot.Browse.Extract
{
    using System;
    using System.Collections.Generic;

    public class ListExtractListener : IExtractListener
    {
        private readonly IList<object> _x8a0b266419f09a55 = new List<object>();

        public void FoundData(object obj)
        {
            this._x8a0b266419f09a55.Add(obj);
        }

        public IList<object> List
        {
            get
            {
                return this._x8a0b266419f09a55;
            }
        }
    }
}

