namespace Encog.ML.Data
{
    using System;
    using System.Collections.Generic;

    public interface IMLDataSet
    {
        void Add(IMLData data1);
        void Add(IMLDataPair inputData);
        void Add(IMLData inputData, IMLData idealData);
        void Close();
        IEnumerator<IMLDataPair> GetEnumerator();
        void GetRecord(long index, IMLDataPair pair);
        IMLDataSet OpenAdditional();

        int CalcedSize { get; }

        long Count { get; }

        int ErrorSize { get; }

        int IdealSize { get; }

        int InputSize { get; }

        bool Supervised { get; }
    }
}

