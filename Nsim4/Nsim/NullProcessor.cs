namespace Nsim
{
    using Encog.ML.Data;
    using Encog.ML.Data.Basic;
    using System;
    using System.Xml.Linq;

    public class NullProcessor : IConfigurable, IDataProcessor
    {
        public void ConfigureProcessor(BasicMLDataSet data)
        {
        }

        public BasicMLDataSet ProcessDataSet(BasicMLDataSet dataToProcess)
        {
            return dataToProcess;
        }

        public IMLDataPair ProcessDataVector(IMLDataPair vectorToProcess)
        {
            return vectorToProcess;
        }

        public IMLData ProcessIdealVector(IMLData row)
        {
            return row;
        }

        public IMLData ProcessInputVector(IMLData row)
        {
            return row;
        }

        public BasicMLDataSet RestoreDataSet(BasicMLDataSet dataToRestore)
        {
            return dataToRestore;
        }

        public IMLDataPair RestoreDataVector(IMLDataPair vectorToProcess)
        {
            return vectorToProcess;
        }

        public IMLData RestoreIdealVector(IMLData row)
        {
            return row;
        }

        public IMLData RestoreInputVector(IMLData row)
        {
            return row;
        }

        public bool IsUsed
        {
            get
            {
                return true;
            }
        }

        public XElement Xml
        {
            get
            {
                return null;
            }
            set
            {
            }
        }
    }
}

