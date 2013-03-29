namespace Nsim
{
    using Encog.MathUtil.Randomize;
    using System;
    using System.Linq;
    using System.Windows;
    using System.Xml.Linq;

    internal class xb417a5fb2bc37c95 : IConfigurable, IConfigControlProvider, IRandomDecorator, IRandomStruct
    {
        public FrameworkElement GetConfigControl()
        {
            return null;
        }

        public IRandomizer GetRandom()
        {
            return ((App.Services.GetService<INetStruct>().HiddenLayers.Layers.Count<ILayerStruct>() < 1) ? new RangeRandomizer(-1.0, 1.0) : new NguyenWidrowRandomizer(-1.0, 1.0));
        }

        public XElement Xml
        {
            get
            {
                return new XElement("RandomConfig", new XAttribute("Type", typeof(xb417a5fb2bc37c95).Name));
            }
            set
            {
            }
        }
    }
}

