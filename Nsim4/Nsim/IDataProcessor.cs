namespace Nsim
{
    using Encog.ML.Data;
    using Encog.ML.Data.Basic;
    using System;

    public interface IDataProcessor : IConfigurable
    {
        void ConfigureProcessor(BasicMLDataSet data);
        BasicMLDataSet ProcessDataSet(BasicMLDataSet dataToProcess);
        IMLDataPair ProcessDataVector(IMLDataPair vectorToProcess);
        IMLData ProcessIdealVector(IMLData row);
        IMLData ProcessInputVector(IMLData row);
        BasicMLDataSet RestoreDataSet(BasicMLDataSet dataToRestore);
        IMLDataPair RestoreDataVector(IMLDataPair vectorTorestore);
        IMLData RestoreIdealVector(IMLData row);
        IMLData RestoreInputVector(IMLData row);

        bool IsUsed { get; }
    }
}

