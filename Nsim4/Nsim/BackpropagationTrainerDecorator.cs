namespace Nsim
{
    using Encog.ML.Train;
    using Encog.Neural.Networks.Training.Propagation.Back;
    using Encog.Util.Concurrency;
    using System;
    using System.Runtime.InteropServices;
    using System.Windows;
    using System.Xml.Linq;

    public class BackpropagationTrainerDecorator : TrainerDecorator<Backpropagation>
    {
        private IMLTrain _x74038d67405f0227;
        private double _x9b481c22b6706459;
        private double _xef52c16be8e501c9;

        public BackpropagationTrainerDecorator()
        {
            this.Momentum = 0.5;
            this.LearningRate = 0.8;
            this._x74038d67405f0227 = null;
        }

        public override FrameworkElement GetConfigControl()
        {
            return new BackpropagationTrainerConfig(this);
        }

        public override IMLTrain GetTrainer([Optional, DefaultParameterValue(false)] bool forceNew)
        {
            xf8efd7615008d32e xfefdde;
            bool flag = !forceNew;
            if (((((uint) flag) - ((uint) forceNew)) >= 0) && flag)
            {
                if (0 != 0)
                {
                    goto Label_00C7;
                }
            }
            else
            {
                this._x74038d67405f0227 = null;
            }
            flag = this._x74038d67405f0227 != null;
        Label_0012:
            if (!flag)
            {
                goto Label_00C7;
            }
        Label_0018:
            return this._x74038d67405f0227;
        Label_00C7:
            xfefdde = App.Services.GetService<xf8efd7615008d32e>();
            while (true)
            {
                this._x74038d67405f0227 = new Backpropagation(xfefdde.x5b0926ce641e48a7, xfefdde.xddda66ad7e26f074, this.LearningRate, this.Momentum);
                flag = !App.Services.GetService<x15b8c53ba4818b71>().x3ca5a760576c2053.HasValue;
                if (!flag)
                {
                    ((IMultiThreadable) this._x74038d67405f0227).ThreadCount = App.Services.GetService<x15b8c53ba4818b71>().x3ca5a760576c2053.Value;
                }
                if ((((uint) flag) & 0) == 0)
                {
                    if (((((uint) flag) - ((uint) forceNew)) <= uint.MaxValue) && (8 != 0))
                    {
                        goto Label_0018;
                    }
                    goto Label_0012;
                }
            }
        }

        protected override XElement GetXml()
        {
            XElement xml = base.GetXml();
            xml.Add(new XAttribute("LearningRate", this.LearningRate));
            xml.Add(new XAttribute("Momentum", this.Momentum));
            return xml;
        }

        protected override void SetXml(XElement xml)
        {
            base.SetXml(xml);
            this.Momentum = xml.DoubleAttribute("Momentum", this.Momentum);
            this.LearningRate = xml.DoubleAttribute("LearningRate", this.LearningRate);
            this._x74038d67405f0227 = null;
        }

        public double LearningRate
        {
            get
            {
                return this._x9b481c22b6706459;
            }
            set
            {
                this._x9b481c22b6706459 = value;
                this._x74038d67405f0227 = null;
            }
        }

        public double Momentum
        {
            get
            {
                return this._xef52c16be8e501c9;
            }
            set
            {
                this._xef52c16be8e501c9 = value;
                this._x74038d67405f0227 = null;
            }
        }
    }
}

