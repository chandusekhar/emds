namespace Encog.ML.Factory
{
    using Encog;
    using Encog.Engine.Network.Activation;
    using Encog.Plugin;
    using System;
    using System.Collections.Generic;

    public class MLActivationFactory
    {
        public const string AF_BIPOLAR = "bipolar";
        public const string AF_COMPETITIVE = "comp";
        public const string AF_GAUSSIAN = "gauss";
        public const string AF_LINEAR = "linear";
        public const string AF_LOG = "log";
        public const string AF_RAMP = "ramp";
        public const string AF_SIGMOID = "sigmoid";
        public const string AF_SIN = "sin";
        public const string AF_SOFTMAX = "softmax";
        public const string AF_STEP = "step";
        public const string AF_TANH = "tanh";

        public IActivationFunction Create(string fn)
        {
            using (IEnumerator<EncogPluginBase> enumerator = EncogFramework.Instance.Plugins.GetEnumerator())
            {
                EncogPluginBase base2;
                IActivationFunction function;
                IActivationFunction function2;
                goto Label_0017;
            Label_0014:
                if (function != null)
                {
                    goto Label_0023;
                }
            Label_0017:
                if (enumerator.MoveNext())
                {
                    goto Label_003A;
                }
                goto Label_0071;
            Label_0023:
                function2 = function;
                if (0x7fffffff == 0)
                {
                    goto Label_0017;
                }
                return function2;
            Label_0030:
                if (base2 is IEncogPluginService1)
                {
                    goto Label_004F;
                }
                goto Label_005E;
            Label_003A:
                base2 = enumerator.Current;
                if (3 == 0)
                {
                    goto Label_0014;
                }
                if (3 != 0)
                {
                    goto Label_0030;
                }
            Label_004F:
                function = ((IEncogPluginService1) base2).CreateActivationFunction(fn);
                goto Label_0014;
            Label_005E:
                if (2 != 0)
                {
                    goto Label_0017;
                }
            }
        Label_0071:
            return null;
        }
    }
}

