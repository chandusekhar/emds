namespace Encog.Neural.Networks.Layers
{
    using Encog.Engine.Network.Activation;
    using Encog.Neural.Networks;
    using System;

    public interface ILayer
    {
        bool HasBias();

        IActivationFunction Activation { set; }

        IActivationFunction ActivationFunction { get; }

        double BiasActivation { get; set; }

        BasicNetwork Network { get; set; }

        int NeuronCount { get; }
    }
}

