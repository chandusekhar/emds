namespace Encog.ML
{
    using Encog.ML.Data;
    using System;
    using System.Collections.Generic;

    public interface IMLCluster
    {
        void Add(IMLData pair);
        IMLDataSet CreateDataSet();
        IMLData Get(int pos);
        void Remove(IMLData data);
        int Size();

        IList<IMLData> Data { get; }
    }
}

