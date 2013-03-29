namespace Nsim
{
    using Encog.ML.Train;
    using Encog.Neural.Networks.Training.Lma;
    using Encog.Util.Concurrency;
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Windows;
    using System.Xml.Linq;

    public class LevenbergMarquardtTrainingTrainerDecorator : TrainerDecorator<LevenbergMarquardtTraining>
    {
        private IMLTrain _x74038d67405f0227;
        [CompilerGenerated]
        private bool x896e4f94a9a5fb84;

        public LevenbergMarquardtTrainingTrainerDecorator()
        {
            this.UseBayesianRegularization = false;
        }

        public override FrameworkElement GetConfigControl()
        {
            return new LevenbergMarquardtTrainingTrainerConfig(this);
        }

        public override IMLTrain GetTrainer([Optional, DefaultParameterValue(false)] bool forceNew)
        {
            // This item is obfuscated and can not be translated.
            xf8efd7615008d32e service;
            LevenbergMarquardtTraining training;
            bool flag = !forceNew;
            if (2 != 0)
            {
                goto Label_0109;
            }
        Label_0018:
            return this._x74038d67405f0227;
        Label_0027:
            if (!flag)
            {
                ((IMultiThreadable) this._x74038d67405f0227).ThreadCount = App.Services.GetService<x15b8c53ba4818b71>().x3ca5a760576c2053.Value;
                if (((uint) forceNew) < 0)
                {
                }
            }
            if ((((uint) flag) + ((uint) flag)) >= 0)
            {
                if ((((uint) forceNew) & 0) == 0)
                {
                    goto Label_0018;
                }
                goto Label_0109;
            }
        Label_0095:
            training = new LevenbergMarquardtTraining(service.x5b0926ce641e48a7, service.xddda66ad7e26f074);
            training.UseBayesianRegularization = this.UseBayesianRegularization;
            this._x74038d67405f0227 = training;
            if (this._x74038d67405f0227 is IMultiThreadable)
            {
                int? nullable = App.Services.GetService<x15b8c53ba4818b71>().x3ca5a760576c2053;
                if (((uint) flag) > uint.MaxValue)
                {
                    goto Label_0027;
                }
            }
            flag = true;
            goto Label_0027;
        Label_0109:
            if (0 == 0)
            {
                if (!flag)
                {
                    this._x74038d67405f0227 = null;
                }
                if (this._x74038d67405f0227 != null)
                {
                    goto Label_0018;
                }
            }
            service = App.Services.GetService<xf8efd7615008d32e>();
            goto Label_0095;
        }

        protected override XElement GetXml()
        {
            XElement xml = base.GetXml();
            xml.Add(new XAttribute("UseBayesianRegularization", this.UseBayesianRegularization));
            return xml;
        }

        protected override void SetXml(XElement xml)
        {
            base.SetXml(xml);
            this.UseBayesianRegularization = xml.Attribute("UseBayesianRegularization").AsBool(this.UseBayesianRegularization);
        }

        public bool UseBayesianRegularization
        {
            [CompilerGenerated]
            get
            {
                return this.x896e4f94a9a5fb84;
            }
            [CompilerGenerated]
            set
            {
                this.x896e4f94a9a5fb84 = value;
            }
        }
    }
}

