namespace Encog.Util.Normalize.Target
{
    using System;

    public interface INormalizationStorage
    {
        void Close();
        void Open();
        void Write(double[] data, int inputCount);
    }
}

