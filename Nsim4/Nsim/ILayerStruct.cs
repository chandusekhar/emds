namespace Nsim
{
    using Encog.Neural.Networks.Layers;
    using System;

    public interface ILayerStruct : IConfigurable
    {
        BasicLayer GetLayer();

        IActivationStruct ActivationFunction { get; }

        int Size { get; }
    }
}

