namespace Encog.Util.Normalize.Input
{
    using System;

    [Serializable]
    public class InputFieldArray2D : BasicInputField, IHasFixedLength
    {
        private readonly double[][] _array;
        private readonly int _index2;

        public InputFieldArray2D(bool usedForNetworkInput, double[][] array, int index2)
        {
            this._array = array;
            this._index2 = index2;
            base.UsedForNetworkInput = usedForNetworkInput;
        }

        public override double GetValue(int i)
        {
            return this._array[i][this._index2];
        }

        public int Length
        {
            get
            {
                return this._array.Length;
            }
        }
    }
}

