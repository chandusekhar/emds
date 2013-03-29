namespace Nsim
{
    using Encog.MathUtil.Randomize;
    using System;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using System.Xml.Linq;

    public class GaussianRandomizerDecorator : RandomDecorator<GaussianRandomizer>
    {
        [CompilerGenerated]
        private double x6ed17ca562a6ced1;
        [CompilerGenerated]
        private double xcfab0225be12cc6b;

        public GaussianRandomizerDecorator()
        {
            this.M = 1.0;
            this.E = 0.3;
        }

        public override FrameworkElement GetConfigControl()
        {
            return new GaussianRandomizerConfig(this);
        }

        public override IRandomizer GetRandom()
        {
            return new GaussianRandomizer(this.M, this.E);
        }

        protected override XElement GetXml()
        {
            XElement xml = base.GetXml();
            xml.Add(new XAttribute("M", this.M));
            xml.Add(new XAttribute("E", this.E));
            return xml;
        }

        protected override void SetXml(XElement xml)
        {
            base.SetXml(xml);
            this.M = xml.DoubleAttribute("M", this.M);
            this.E = xml.DoubleAttribute("E", this.E);
        }

        public double E
        {
            [CompilerGenerated]
            get
            {
                return this.x6ed17ca562a6ced1;
            }
            [CompilerGenerated]
            set
            {
                this.x6ed17ca562a6ced1 = value;
            }
        }

        public double M
        {
            [CompilerGenerated]
            get
            {
                return this.xcfab0225be12cc6b;
            }
            [CompilerGenerated]
            set
            {
                this.xcfab0225be12cc6b = value;
            }
        }
    }
}

