namespace Nsim
{
    using System;
    using System.Xml.Linq;

    public interface ITrainerDecoratorDescriptor
    {
        ITrainerDecorator GetDecorator();
        ITrainerDecorator GetDecorator(XElement config);

        Type DecoratedType { get; }

        string Title { get; }
    }
}

