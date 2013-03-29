namespace Encog.Plugin.SystemPlugin
{
    using Encog;
    using Encog.Engine.Network.Activation;
    using Encog.ML;
    using Encog.ML.Data;
    using Encog.ML.Factory.Train;
    using Encog.ML.Train;
    using Encog.Plugin;
    using System;

    public class SystemTrainingPlugin : EncogPluginBase, IEncogPluginService1
    {
        private SCGFactory x18a6fb2989ad1c96 = new SCGFactory();
        private GeneticFactory x1e12b933f8c42681 = new GeneticFactory();
        private ManhattanFactory x1e81014c4750a5da = new ManhattanFactory();
        private RPROPFactory x62bceb215352e154 = new RPROPFactory();
        private ClusterSOMFactory x62ed8b00fe853dcf = new ClusterSOMFactory();
        private QuickPropFactory x83770f923623564b = new QuickPropFactory();
        private BackPropFactory x87b2f2b20b9785b8 = new BackPropFactory();
        private SVMFactory xc0e7cfa6d6f1a7b0 = new SVMFactory();
        private AnnealFactory xc9219144facaec1b = new AnnealFactory();
        private RBFSVDFactory xd28d7933428bfec8 = new RBFSVDFactory();
        private LMAFactory xd950e9a874b78a08 = new LMAFactory();
        private SVMSearchFactory xeba17a6fbab1950e = new SVMSearchFactory();
        private PNNTrainFactory xf3cb8f61ba71df43 = new PNNTrainFactory();
        private NeighborhoodSOMFactory xfb94dffcab6e5c84 = new NeighborhoodSOMFactory();

        public IActivationFunction CreateActivationFunction(string name)
        {
            return null;
        }

        public IMLMethod CreateMethod(string methodType, string architecture, int input, int output)
        {
            return null;
        }

        public IMLTrain CreateTraining(IMLMethod method, IMLDataSet training, string type, string args)
        {
            string str = args;
            goto Label_0221;
        Label_0008:
            if (string.Compare("pnn", type) == 0)
            {
                return this.xf3cb8f61ba71df43.Create(method, training, str);
            }
            if (string.Compare("qprop", type) != 0)
            {
                if (8 != 0)
                {
                    if (2 != 0)
                    {
                        goto Label_00CB;
                    }
                    goto Label_006E;
                }
                goto Label_003A;
            }
        Label_0017:
            return this.x83770f923623564b.Create(method, training, str);
        Label_003A:
            if (string.Compare("rbf-svd", type) != 0)
            {
                goto Label_0008;
            }
            return this.xd28d7933428bfec8.Create(method, training, str);
        Label_006E:
            if (string.Compare("manhattan", type) == 0)
            {
                return this.x1e81014c4750a5da.Create(method, training, str);
            }
            if (0 == 0)
            {
                goto Label_003A;
            }
            goto Label_00CB;
        Label_009E:
            if (string.Compare("genetic", type) == 0)
            {
                return this.x1e12b933f8c42681.Create(method, training, str);
            }
            if (15 == 0)
            {
                goto Label_0008;
            }
            if ((3 != 0) && (string.Compare("som-cluster", type) != 0))
            {
                goto Label_006E;
            }
            return this.x62ed8b00fe853dcf.Create(method, training, str);
        Label_00CB:
            if (0 == 0)
            {
                throw new EncogError("Unknown training type: " + type);
            }
            goto Label_0221;
        Label_00F7:
            return this.xc9219144facaec1b.Create(method, training, str);
        Label_0197:
            if (string.Compare("scg", type) != 0)
            {
                if (string.Compare("lma", type) == 0)
                {
                    if (0x7fffffff != 0)
                    {
                        return this.xd950e9a874b78a08.Create(method, training, str);
                    }
                    goto Label_0017;
                }
                if (string.Compare("svm-train", type) == 0)
                {
                    if (-2 != 0)
                    {
                        return this.xc0e7cfa6d6f1a7b0.Create(method, training, str);
                    }
                    goto Label_0221;
                }
                if (string.Compare("svm-search", type) == 0)
                {
                    return this.xeba17a6fbab1950e.Create(method, training, str);
                }
                if (string.Compare("som-neighborhood", type) == 0)
                {
                    if (-1 == 0)
                    {
                        goto Label_0008;
                    }
                    if (0 == 0)
                    {
                        return this.xfb94dffcab6e5c84.Create(method, training, str);
                    }
                    if (1 == 0)
                    {
                        if (0 == 0)
                        {
                            if (0 != 0)
                            {
                                goto Label_0219;
                            }
                            if (8 == 0)
                            {
                                goto Label_01A4;
                            }
                            goto Label_00F7;
                        }
                        goto Label_009E;
                    }
                }
                if (string.Compare("anneal", type) == 0)
                {
                    goto Label_00F7;
                }
                goto Label_009E;
            }
        Label_01A4:
            return this.x18a6fb2989ad1c96.Create(method, training, str);
        Label_01DC:
            if (string.Compare("backprop", type) != 0)
            {
                goto Label_0197;
            }
        Label_01F3:
            return this.x87b2f2b20b9785b8.Create(method, training, str);
        Label_0219:
            str = "";
            goto Label_0224;
        Label_0221:
            if (str == null)
            {
                goto Label_0219;
            }
        Label_0224:
            if (string.Compare("rprop", type) != 0)
            {
                goto Label_01DC;
            }
            if (0 == 0)
            {
                if (0 == 0)
                {
                    return this.x62bceb215352e154.Create(method, training, str);
                }
                goto Label_0008;
            }
            if (-2 != 0)
            {
                goto Label_01F3;
            }
            if (0 == 0)
            {
                goto Label_0197;
            }
            if ((0 == 0) && (0 == 0))
            {
                goto Label_01DC;
            }
            goto Label_0221;
        }

        public string PluginDescription
        {
            get
            {
                return "This plugin provides the built in training methods for Encog.";
            }
        }

        public string PluginName
        {
            get
            {
                return "HRI-System-Training";
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

