namespace Nsim
{
    using Encog.ML.Train;
    using Encog.Neural.Networks.Training;
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Windows;
    using System.Xml.Linq;

    public class LearningRateTrainerDecorator<T> : TrainerDecorator<T>, ILearningRate where T: IMLTrain
    {
        private IMLTrain _x74038d67405f0227;
        [CompilerGenerated]
        private double x3766481f03fcb7b1;

        public override FrameworkElement GetConfigControl()
        {
            return new LearningRateConfig(this);
        }

        public override IMLTrain GetTrainer([Optional, DefaultParameterValue(false)] bool forceNew)
        {
            // This item is obfuscated and can not be translated.
        }

        protected override XElement GetXml()
        {
            XElement xml = base.GetXml();
            xml.Add(new XAttribute("LearningRate", this.LearningRate));
            return xml;
        }

        protected override void SetXml(XElement xml)
        {
            base.SetXml(xml);
            this.LearningRate = xml.DoubleAttribute("LearningRate", this.LearningRate);
        }

        public double LearningRate
        {
            [CompilerGenerated]
            get
            {
                return this.x3766481f03fcb7b1;
            }
            [CompilerGenerated]
            set
            {
                this.x3766481f03fcb7b1 = value;
            }
        }
    }
}

