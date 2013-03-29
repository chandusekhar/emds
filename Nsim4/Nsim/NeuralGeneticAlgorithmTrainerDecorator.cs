namespace Nsim
{
    using Encog.MathUtil.Randomize;
    using Encog.ML.Train;
    using Encog.Neural.Networks.Training;
    using Encog.Neural.Networks.Training.Genetic;
    using Encog.Util.Concurrency;
    using System;
    using System.Runtime.InteropServices;
    using System.Windows;
    using System.Xml.Linq;

    public class NeuralGeneticAlgorithmTrainerDecorator : TrainerDecorator<Backpropagation>
    {
        private int _x2885e355919ef9a4;
        private double _x48d4138f9dc4e523;
        private IMLTrain _x74038d67405f0227;
        private double _x7ce0f440503caa05;

        public NeuralGeneticAlgorithmTrainerDecorator()
        {
            this.MutationPercent = 0.05;
            this.PopulationSize = 300;
            this.PercentToMate = 0.3;
            this._x74038d67405f0227 = null;
        }

        public override FrameworkElement GetConfigControl()
        {
            return new NeuralGeneticAlgorithmTrainerConfig(this);
        }

        public override IMLTrain GetTrainer([Optional, DefaultParameterValue(false)] bool forceNew)
        {
            bool flag = !forceNew;
            while (!flag)
            {
                this._x74038d67405f0227 = null;
                break;
            }
            goto Label_0121;
        Label_000C:
            return this._x74038d67405f0227;
        Label_0121:
            flag = this._x74038d67405f0227 != null;
        Label_012F:
            if (((((uint) flag) | 0x7fffffff) != 0) && flag)
            {
                goto Label_000C;
            }
            xf8efd7615008d32e service = App.Services.GetService<xf8efd7615008d32e>();
            IRandomizer randomizer = new GaussianRandomizer(0.0, 0.4);
            ICalculateScore calculateScore = new TrainingSetScore(service.xddda66ad7e26f074);
            this._x74038d67405f0227 = new NeuralGeneticAlgorithm(service.x5b0926ce641e48a7, randomizer, calculateScore, this.PopulationSize, this.MutationPercent, this.PercentToMate);
            if (-1 != 0)
            {
                flag = !App.Services.GetService<x15b8c53ba4818b71>().x3ca5a760576c2053.HasValue;
                if ((((uint) flag) + ((uint) flag)) < 0)
                {
                    IMLTrain train;
                    return train;
                }
                if (!flag)
                {
                    ((IMultiThreadable) this._x74038d67405f0227).ThreadCount = App.Services.GetService<x15b8c53ba4818b71>().x3ca5a760576c2053.Value;
                }
                if ((((uint) flag) + ((uint) forceNew)) > uint.MaxValue)
                {
                    goto Label_012F;
                }
                goto Label_000C;
            }
            goto Label_0121;
        }

        protected override XElement GetXml()
        {
            XElement xml = base.GetXml();
            do
            {
                xml.Add(new XAttribute("MutationPercent", this.MutationPercent));
                xml.Add(new XAttribute("PopulationSize", this.PopulationSize));
            }
            while (0 != 0);
            xml.Add(new XAttribute("PercentToMate", this.PercentToMate));
            return xml;
        }

        protected override void SetXml(XElement xml)
        {
            base.SetXml(xml);
            this.MutationPercent = xml.DoubleAttribute("MutationPercent", this.MutationPercent);
            this.PopulationSize = xml.IntAttribute("PopulationSize", this.PopulationSize);
            this.PercentToMate = xml.DoubleAttribute("PercentToMate", this.PercentToMate);
            this._x74038d67405f0227 = null;
        }

        public double MutationPercent
        {
            get
            {
                return this._x48d4138f9dc4e523;
            }
            set
            {
                this._x48d4138f9dc4e523 = value;
                this._x74038d67405f0227 = null;
            }
        }

        public double PercentToMate
        {
            get
            {
                return this._x7ce0f440503caa05;
            }
            set
            {
                this._x7ce0f440503caa05 = value;
                this._x74038d67405f0227 = null;
            }
        }

        public int PopulationSize
        {
            get
            {
                return this._x2885e355919ef9a4;
            }
            set
            {
                this._x2885e355919ef9a4 = value;
                this._x74038d67405f0227 = null;
            }
        }
    }
}

