namespace Encog.Util.Normalize.Target
{
    using Encog.Util.CSV;
    using System;
    using System.IO;
    using System.Text;

    [Serializable]
    public class NormalizationStorageCSV : INormalizationStorage
    {
        private readonly CSVFormat _format;
        private StreamWriter _output;
        private readonly string _outputFile;

        public NormalizationStorageCSV(string file)
        {
            this._format = CSVFormat.English;
            this._outputFile = file;
        }

        public NormalizationStorageCSV(CSVFormat format, string file)
        {
            this._format = format;
            this._outputFile = file;
        }

        public void Close()
        {
            this._output.Close();
        }

        public void Open()
        {
            this._output = new StreamWriter(this._outputFile);
        }

        public void Write(double[] data, int inputCount)
        {
            StringBuilder result = new StringBuilder();
            NumberList.ToList(this._format, result, data);
            this._output.WriteLine(result.ToString());
        }
    }
}

