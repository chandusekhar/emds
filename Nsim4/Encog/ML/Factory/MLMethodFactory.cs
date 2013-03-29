namespace Encog.ML.Factory
{
    using Encog;
    using Encog.ML;
    using Encog.Plugin;
    using System;
    using System.Collections.Generic;

    public class MLMethodFactory
    {
        public const string TypeFeedforward = "feedforward";
        public const string TypePNN = "pnn";
        public const string TypeRbfnetwork = "rbfnetwork";
        public const string TypeSOM = "som";
        public const string TypeSVM = "svm";

        public IMLMethod Create(string methodType, string architecture, int input, int output)
        {
            using (IEnumerator<EncogPluginBase> enumerator = EncogFramework.Instance.Plugins.GetEnumerator())
            {
            Label_0017:
                if (enumerator.MoveNext())
                {
                    EncogPluginBase current = enumerator.Current;
                    if (!(current is IEncogPluginService1))
                    {
                        goto Label_0017;
                    }
                    IMLMethod method = ((IEncogPluginService1) current).CreateMethod(methodType, architecture, input, output);
                    if ((((uint) output) & 0) == 0)
                    {
                        if (method == null)
                        {
                            goto Label_0017;
                        }
                        IMLMethod method2 = method;
                        if (((uint) output) <= uint.MaxValue)
                        {
                            return method2;
                        }
                    }
                }
            }
            throw new EncogError("Unknown method type: " + methodType);
        }
    }
}

