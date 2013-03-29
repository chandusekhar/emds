namespace Encog.ML
{
    using System;

    public interface IMLClustering : IMLMethod
    {
        void Iteration();
        void Iteration(int count);
        int NumClusters();

        IMLCluster[] Clusters { get; }
    }
}

