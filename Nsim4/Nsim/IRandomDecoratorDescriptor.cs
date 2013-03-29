namespace Nsim
{
    using System;
    using System.Xml.Linq;

    public interface IRandomDecoratorDescriptor
    {
        IRandomDecorator GetDecorator();
        IRandomDecorator GetDecorator(XElement config);

        Type DecoratedType { get; }

        string Title { get; }
    }
}

