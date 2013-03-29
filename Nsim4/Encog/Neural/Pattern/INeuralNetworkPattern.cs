namespace Encog.Neural.Pattern
{
    using Encog.Engine.Network.Activation;
    using Encog.ML;
    using System;

    public interface INeuralNetworkPattern
    {
        void AddHiddenLayer(int count);
        void Clear();
        IMLMethod Generate();

        IActivationFunction ActivationFunction { set; }

        int InputNeurons { set; }

        int OutputNeurons { set; }
    }
}

