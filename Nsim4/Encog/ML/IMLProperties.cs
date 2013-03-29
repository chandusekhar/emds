namespace Encog.ML
{
    using System;
    using System.Collections.Generic;

    public interface IMLProperties : IMLMethod
    {
        double GetPropertyDouble(string name);
        long GetPropertyLong(string name);
        string GetPropertyString(string name);
        void SetProperty(string name, double d);
        void SetProperty(string name, long l);
        void SetProperty(string name, string v);
        void UpdateProperties();

        IDictionary<string, string> Properties { get; }
    }
}

