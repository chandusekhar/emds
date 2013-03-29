namespace Encog.Util.Normalize.Input
{
    using System;

    [Serializable]
    public class InputFieldCSV : BasicInputField
    {
        private readonly string _file;
        private readonly int _offset;

        public InputFieldCSV()
        {
        }

        public InputFieldCSV(bool usedForNetworkInput, string file, int offset)
        {
            this._file = file;
            this._offset = offset;
            base.UsedForNetworkInput = usedForNetworkInput;
        }

        public string File
        {
            get
            {
                return this._file;
            }
        }

        public int Offset
        {
            get
            {
                return this._offset;
            }
        }
    }
}

