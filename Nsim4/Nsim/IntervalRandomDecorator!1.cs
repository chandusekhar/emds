namespace Nsim
{
    using Encog.MathUtil.Randomize;
    using System;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using System.Xml.Linq;

    public class IntervalRandomDecorator<T> : RandomDecorator<T>, IIntervalProvider where T: IRandomizer
    {
        [CompilerGenerated]
        private double x308fc176e59edb6d;
        [CompilerGenerated]
        private double xb7e69cb86af43f02;

        public IntervalRandomDecorator()
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
            return (T) typeof(T).GetConstructor(new Type[] { typeof(double), typeof(double) }).Invoke(new object[] { this.Min, this.Max });
        }

        protected override XElement GetXml()
        {
            XElement xml = base.GetXml();
            xml.Add(new XAttribute("Min", this.Min));
            xml.Add(new XAttribute("Max", this.Max));
            return xml;
        }

        protected override void SetXml(XElement xml)
        {
            base.SetXml(xml);
            this.Min = xml.DoubleAttribute("Min", this.Min);
            this.Max = xml.DoubleAttribute("Max", this.Max);
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
    }
}

