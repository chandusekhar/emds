namespace Encog.ML.Factory.Method
{
    using Encog.ML;
    using Encog.ML.Factory;
    using System;

    public class FeedforwardFactory
    {
        private MLActivationFactory _x64b16fcabdb0518e = new MLActivationFactory();
        public const string CantDefineAct = "Can't define activation function before first layer.";

        public IMLMethod Create(string architecture, int input, int output)
        {
            // This item is obfuscated and can not be translated.
        }
    }
}

