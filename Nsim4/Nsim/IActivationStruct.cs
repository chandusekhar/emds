namespace Nsim
{
    using Encog.Engine.Network.Activation;

    public interface IActivationStruct : IConfigurable
    {
        IActivationFunction GetActivation();
    }
}

