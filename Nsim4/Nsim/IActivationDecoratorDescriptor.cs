namespace Nsim
{
    using System;
    using System.Xml.Linq;

    public interface IActivationDecoratorDescriptor
    {
        IActivationDecorator GetDecorator();
        IActivationDecorator GetDecorator(XElement config);

        Type DecoratedType { get; }

        string Title { get; }
    }
}

