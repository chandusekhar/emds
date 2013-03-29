namespace Nsim
{
    using System;
    using System.Xml.Linq;

    public interface IConfigurable
    {
        XElement Xml { get; set; }
    }
}

