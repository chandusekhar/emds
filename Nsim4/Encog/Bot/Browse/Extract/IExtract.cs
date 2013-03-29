namespace Encog.Bot.Browse.Extract
{
    using Encog.Bot.Browse;
    using System;
    using System.Collections.Generic;

    public interface IExtract
    {
        void AddListener(IExtractListener listener);
        void Extract(WebPage page);
        IList<object> ExtractList(WebPage page);
        void RemoveListener(IExtractListener listener);

        ICollection<IExtractListener> Listeners { get; }
    }
}

