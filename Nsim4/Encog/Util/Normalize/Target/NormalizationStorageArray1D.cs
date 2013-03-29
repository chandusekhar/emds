namespace Encog.Util.Normalize.Target
{
    using System;

    [Serializable]
    public class NormalizationStorageArray1D : INormalizationStorage
    {
        private readonly double[] _array;
        private int _currentIndex;

        public NormalizationStorageArray1D(double[] array)
        {
            this._array = array;
            this._currentIndex = 0;
        }

        public void Close()
        {
        }

        public double[] GetArray()
        {
            return this._array;
        }

        public void Open()
        {
        }

        public void Write(double[] data, int inputCount)
        {
            this._array[this._currentIndex++] = data[0];
        }
    }
}

