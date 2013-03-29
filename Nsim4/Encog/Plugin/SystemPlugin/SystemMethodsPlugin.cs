namespace Encog.Plugin.SystemPlugin
{
    using Encog;
    using Encog.Engine.Network.Activation;
    using Encog.ML;
    using Encog.ML.Data;
    using Encog.ML.Factory.Method;
    using Encog.ML.Train;
    using Encog.Plugin;
    using System;

    public class SystemMethodsPlugin : EncogPluginBase, IEncogPluginService1
    {
        private FeedforwardFactory x1bcf18090c05bbbd = new FeedforwardFactory();
        private SOMFactory x9eb63acea5b4b6a4 = new SOMFactory();
        private RBFNetworkFactory xb2839564ad053e80 = new RBFNetworkFactory();
        private SVMFactory xc0e7cfa6d6f1a7b0 = new SVMFactory();
        private PNNFactory xf3cb8f61ba71df43 = new PNNFactory();

        public IActivationFunction CreateActivationFunction(string name)
        {
            return null;
        }

        public IMLMethod CreateMethod(string methodType, string architecture, int input, int output)
        {
            if (!"feedforward".Equals(methodType))
            {
                if ("rbfnetwork".Equals(methodType))
                {
                    return this.xb2839564ad053e80.Create(architecture, input, output);
                }
                if ("svm".Equals(methodType))
                {
                    return this.xc0e7cfa6d6f1a7b0.Create(architecture, input, output);
                }
                goto Label_0043;
            }
            if ((((uint) output) + ((uint) input)) >= 0)
            {
                return this.x1bcf18090c05bbbd.Create(architecture, input, output);
            }
        Label_002D:
            if ("pnn".Equals(methodType))
            {
                goto Label_0062;
            }
            if (2 != 0)
            {
                throw new EncogError("Unknown method type: " + methodType);
            }
        Label_0043:
            if ("svm".Equals(methodType))
            {
                return this.x9eb63acea5b4b6a4.Create(architecture, input, output);
            }
            if (((uint) output) >= 0)
            {
                goto Label_002D;
            }
        Label_0062:
            return this.xf3cb8f61ba71df43.Create(architecture, input, output);
        }

        public IMLTrain CreateTraining(IMLMethod method, IMLDataSet training, string type, string args)
        {
            return null;
        }

        public string PluginDescription
        {
            get
            {
                return "This plugin provides the built in machine learning methods for Encog.";
            }
        }

        public string PluginName
        {
            get
            {
                return "HRI-System-Methods";
            }
        }

        public int PluginServiceType
        {
            get
            {
                return 0;
            }
        }

        public int PluginType
        {
            get
            {
                return 1;
            }
        }
    }
}

