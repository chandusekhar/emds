namespace Encog.Bot.Browse.Extract
{
    using Encog.Bot.Browse;
    using System;
    using System.Collections.Generic;

    public abstract class BasicExtract : IExtract
    {
        private readonly ICollection<IExtractListener> _xa1a7b04ac1ec3821 = new List<IExtractListener>();

        protected BasicExtract()
        {
        }

        public void AddListener(IExtractListener listener)
        {
            this._xa1a7b04ac1ec3821.Add(listener);
        }

        public void Distribute(object obj)
        {
            foreach (IExtractListener listener in this._xa1a7b04ac1ec3821)
            {
                listener.FoundData(obj);
            }
        }

        public abstract void Extract(WebPage page);
        public IList<object> ExtractList(WebPage page)
        {
            this.Listeners.Clear();
            ListExtractListener listener = new ListExtractListener();
            this.AddListener(listener);
            this.Extract(page);
            return listener.List;
        }

        public void RemoveListener(IExtractListener listener)
        {
            this._xa1a7b04ac1ec3821.Remove(listener);
        }

        public ICollection<IExtractListener> Listeners
        {
            get
            {
                return this._xa1a7b04ac1ec3821;
            }
        }
    }
}

