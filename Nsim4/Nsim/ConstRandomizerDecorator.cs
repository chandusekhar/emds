namespace Nsim
{
    using Encog.MathUtil.Randomize;
    using System;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using System.Xml.Linq;

    public class ConstRandomizerDecorator : RandomDecorator<ConstRandomizer>
    {
        [CompilerGenerated]
        private double x2ce4340e980ebb2e;

        public override FrameworkElement GetConfigControl()
        {
            return new ConstConfig(this);
        }

        public override IRandomizer GetRandom()
        {
            return new ConstRandomizer(this.Value);
        }

        protected override XElement GetXml()
        {
            XElement xml = base.GetXml();
            xml.Add(new XAttribute("Value", this.Value));
            return xml;
        }

        protected override void SetXml(XElement xml)
        {
            base.SetXml(xml);
            this.Value = xml.DoubleAttribute("Value", this.Value);
        }

        public double Value
        {
            [CompilerGenerated]
            get
            {
                return this.x2ce4340e980ebb2e;
            }
            [CompilerGenerated]
            set
            {
                this.x2ce4340e980ebb2e = value;
            }
        }
    }
}

