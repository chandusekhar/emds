namespace Nsim
{
    using System;
    using System.Xml.Linq;

    internal class x1a44f162f55467a5 : IConfigurable
    {
        public XElement Xml
        {
            get
            {
                XElement element = new XElement("NeuroProject");
                while (true)
                {
                    element.x20ef846b7fe0cd42<INetStruct>("NetStruct");
                    element.x20ef846b7fe0cd42<ITrainerStruct>("TrainerConfig");
                    element.x20ef846b7fe0cd42<IRandomStruct>("RandomConfig");
                    element.x20ef846b7fe0cd42<IDataProcessor>("DataProcessor");
                    do
                    {
                        XElement element2;
                        if (0 != 0)
                        {
                            return element2;
                        }
                        element.x20ef846b7fe0cd42<x35a0e88a31c66173>("TrainingStopParams");
                        element.x20ef846b7fe0cd42<ITrainData>("TrainData");
                        element.x20ef846b7fe0cd42<ITestData>("TestData");
                        if (-1 != 0)
                        {
                            element.x20ef846b7fe0cd42<ICheckData>("CheckData");
                            element.x20ef846b7fe0cd42<ICalcData>("CalcData");
                            if (2 != 0)
                            {
                                element.x20ef846b7fe0cd42<x9d88849cdb32703c>("ErrorGraphData");
                                element.x20ef846b7fe0cd42<xf8efd7615008d32e>("NetData");
                                if (0 == 0)
                                {
                                    return element;
                                }
                            }
                            return element2;
                        }
                    }
                    while (0 != 0);
                }
            }
            set
            {
                value.x9f74ccae27c47030<INetStruct>("NetStruct");
                value.x9f74ccae27c47030<ITrainerStruct>("TrainerConfig");
                value.x9f74ccae27c47030<IRandomStruct>("RandomConfig");
                value.x9f74ccae27c47030<IDataProcessor>("DataProcessor");
                if (4 != 0)
                {
                    value.x9f74ccae27c47030<x35a0e88a31c66173>("TrainingStopParams");
                }
                else
                {
                    return;
                }
                do
                {
                    value.x9f74ccae27c47030<ITrainData>("TrainData");
                    value.x9f74ccae27c47030<ITestData>("TestData");
                    value.x9f74ccae27c47030<ICheckData>("CheckData");
                    value.x9f74ccae27c47030<ICalcData>("CalcData");
                    value.x9f74ccae27c47030<x9d88849cdb32703c>("ErrorGraphData");
                    value.x9f74ccae27c47030<xf8efd7615008d32e>("NetData");
                }
                while (0 != 0);
            }
        }
    }
}

