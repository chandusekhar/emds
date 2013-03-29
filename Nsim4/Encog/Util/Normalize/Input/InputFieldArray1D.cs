namespace Encog.Util.Normalize.Input
{
    using System;

    [Serializable]
    public class InputFieldArray1D : BasicInputField, IHasFixedLength
    {
        private readonly double[] _array;

        public InputFieldArray1D(bool usedForNetworkInput, double[] array)
        {
            this._array = array;
            base.UsedForNetworkInput = usedForNetworkInput;
        }

        public override double GetValue(int i)
        {
            return this._array[i];
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

