namespace Encog.Util.Normalize.Target
{
    using System;

    [Serializable]
    public class NormalizationStorageArray2D : INormalizationStorage
    {
        private readonly double[][] _array;
        private int _currentIndex;

        public NormalizationStorageArray2D(double[][] array)
        {
            this._array = array;
            this._currentIndex = 0;
        }

        public void Close()
        {
        }

        public double[][] GetArray()
        {
            return this._array;
        }

        public void Open()
        {
        }

        public void Write(double[] data, int inputCount)
        {
            int index = 0;
            while (index < data.Length)
            {
                this._array[this._currentIndex][index] = data[index];
                index++;
                if (((uint) index) <= uint.MaxValue)
                {
                }
            }
            this._currentIndex++;
        }
    }
}

