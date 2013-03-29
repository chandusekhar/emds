namespace Nsim
{
    using Encog.ML.Train;
    using System;
    using System.Runtime.InteropServices;

    public interface ITrainerStruct : IConfigurable
    {
        IMLTrain GetTrainer([Optional, DefaultParameterValue(false)] bool forceNew);
    }
}

