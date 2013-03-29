namespace Nsim
{
    using System.Collections.Generic;

    public interface IHiddenLayers : IConfigurable
    {
        IActivationStruct ActivationFunction { get; }

        IEnumerable<ILayerStruct> Layers { get; }
    }
}

