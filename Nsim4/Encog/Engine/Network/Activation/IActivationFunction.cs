namespace Encog.Engine.Network.Activation
{
    using System;

    public interface IActivationFunction : ICloneable
    {
        void ActivationFunction(double[] d, int start, int size);
        double DerivativeFunction(double b, double a);
        bool HasDerivative();

        string[] ParamNames { get; }

        double[] Params { get; }
    }
}

