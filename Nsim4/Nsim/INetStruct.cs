namespace Nsim
{
    using Encog.Neural.Networks;

    public interface INetStruct : IConfigurable
    {
        BasicNetwork GetNewNetwork();

        IHiddenLayers HiddenLayers { get; }

        ILayerStruct InputLayer { get; }

        ILayerStruct OutputLayer { get; }
    }
}

