namespace Encog.Plugin
{
    using Encog.Engine.Network.Activation;
    using Encog.ML;
    using Encog.ML.Data;
    using Encog.ML.Train;
    using System;

    public interface IEncogPluginService1 : EncogPluginBase
    {
        IActivationFunction CreateActivationFunction(string name);
        IMLMethod CreateMethod(string methodType, string architecture, int input, int output);
        IMLTrain CreateTraining(IMLMethod method, IMLDataSet training, string type, string args);
    }
}

