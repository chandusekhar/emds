namespace Encog.Persist
{
    using System;
    using System.IO;

    public interface IEncogPersistor
    {
        object Read(Stream mask0);
        void Save(Stream os, object obj);

        int FileVersion { get; }

        Type NativeType { get; }

        string PersistClassString { get; }
    }
}

