namespace Nsim
{
    using Encog.MathUtil.Randomize;
    using System;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using System.Xml.Linq;

    internal class xea522cb7be4b23be : RandomDecorator<ConsistentRandomizer>, IIntervalProvider
    {
        [CompilerGenerated]
        private double x308fc176e59edb6d;
        [CompilerGenerated]
        private int x47bfa89900345bd6;
        [CompilerGenerated]
        private double xb7e69cb86af43f02;

        public xea522cb7be4b23be()
        {
            this.Min = -1.0;
            this.Max = 1.0;
        }

        public override FrameworkElement GetConfigControl()
        {
            return new IntervalConfig(this);
        }

        public override IRandomizer GetRandom()
        {
            return new ConsistentRandomizer(this.Min, this.Max, this.x3a6458ee5430aeeb);
        }

        protected override XElement GetXml()
        {
            XElement element2;
            XElement xml = base.GetXml();
            do
            {
                xml.Add(new XAttribute("Min", this.Min));
                xml.Add(new XAttribute("Max", this.Max));
                xml.Add(new XAttribute("Seed", this.x3a6458ee5430aeeb));
                element2 = xml;
            }
            while (15 == 0);
            return element2;
        }

        protected override void SetXml(XElement xml)
        {
            base.SetXml(xml);
            this.Min = xml.DoubleAttribute("Min", this.Min);
            this.Max = xml.DoubleAttribute("Max", this.Max);
            this.x3a6458ee5430aeeb = xml.IntAttribute("Seed", this.x3a6458ee5430aeeb);
        }

        public double Max
        {
            [CompilerGenerated]
            get
            {
                return this.x308fc176e59edb6d;
            }
            [CompilerGenerated]
            set
            {
                this.x308fc176e59edb6d = value;
            }
        }

        public double Min
        {
            [CompilerGenerated]
            get
            {
                return this.xb7e69cb86af43f02;
            }
            [CompilerGenerated]
            set
            {
                this.xb7e69cb86af43f02 = value;
            }
        }

        public int x3a6458ee5430aeeb
        {
            [CompilerGenerated]
            get
            {
                return this.x47bfa89900345bd6;
            }
            [CompilerGenerated]
            set
            {
                this.x47bfa89900345bd6 = value;
            }
        }
    }
}

