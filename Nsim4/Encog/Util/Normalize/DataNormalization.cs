namespace Encog.Util.Normalize
{
    using Encog;
    using Encog.ML.Data;
    using Encog.Neural.Data.Basic;
    using Encog.Util.CSV;
    using Encog.Util.Normalize.Input;
    using Encog.Util.Normalize.Output;
    using Encog.Util.Normalize.Segregate;
    using Encog.Util.Normalize.Target;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [Serializable]
    public class DataNormalization
    {
        private CSVFormat _csvFormat = CSVFormat.English;
        [NonSerialized]
        private IDictionary<IInputField, ReadCSV> _csvMap;
        private int _currentIndex;
        [NonSerialized]
        private IDictionary<IInputField, MLDataFieldHolder> _dataSetFieldMap;
        [NonSerialized]
        private IDictionary<IEnumerator<IMLDataPair>, MLDataFieldHolder> _dataSetIteratorMap;
        private readonly IList<IOutputFieldGroup> _groups = new List<IOutputFieldGroup>();
        private readonly IList<IInputField> _inputFields = new List<IInputField>();
        private int _lastReport;
        private readonly IList<IOutputField> _outputFields = new List<IOutputField>();
        [NonSerialized]
        private ICollection<ReadCSV> _readCSV;
        [NonSerialized]
        private ICollection<IEnumerator<IMLDataPair>> _readDataSet;
        private int _recordCount;
        [NonSerialized]
        private IStatusReportable _report = new NullStatusReportable();
        private readonly IList<ISegregator> _segregators = new List<ISegregator>();
        private INormalizationStorage _storage;

        public void AddInputField(IInputField f)
        {
            this._inputFields.Add(f);
        }

        public void AddOutputField(IOutputField outputField)
        {
            this.AddOutputField(outputField, false);
        }

        public void AddOutputField(IOutputField outputField, bool ideal)
        {
            this._outputFields.Add(outputField);
            outputField.Ideal = ideal;
            if (outputField is OutputFieldGrouped)
            {
                OutputFieldGrouped grouped = (OutputFieldGrouped) outputField;
                this._groups.Add(grouped.Group);
            }
        }

        public void AddSegregator(ISegregator segregator)
        {
            this._segregators.Add(segregator);
            segregator.Init(this);
        }

        private void ApplyMinMax()
        {
            foreach (IInputField field in this._inputFields)
            {
                double currentValue = field.CurrentValue;
                field.ApplyMinMax(currentValue);
            }
        }

        public IMLData BuildForNetworkInput(double[] data)
        {
            int num2;
            int num5;
            int num = 0;
            goto Label_0148;
        Label_00A8:
            this.InitForOutput();
            IMLData data2 = new BasicNeuralData(num2);
            int num4 = 0;
            using (IEnumerator<IOutputField> enumerator3 = this._outputFields.GetEnumerator())
            {
                IOutputField field3;
                goto Label_00F6;
            Label_00C8:
                num5 = 0;
                while (num5 < field3.SubfieldCount)
                {
                    data2.Data[num4++] = field3.Calculate(num5);
                    num5++;
                }
            Label_00F6:
                if (enumerator3.MoveNext())
                {
                    goto Label_0119;
                }
                return data2;
            Label_0101:
                if ((((uint) num) & 0) != 0)
                {
                    goto Label_0122;
                }
                goto Label_00C8;
            Label_0119:
                field3 = enumerator3.Current;
            Label_0122:
                if (field3.Ideal)
                {
                    goto Label_00F6;
                }
                goto Label_0101;
            }
            if (2 != 0)
            {
                return data2;
            }
        Label_0148:
            using (IEnumerator<IInputField> enumerator = this._inputFields.GetEnumerator())
            {
                IInputField field;
            Label_0157:
                if (enumerator.MoveNext())
                {
                    goto Label_01D2;
                }
                goto Label_01EF;
            Label_0168:
                if (!field.UsedForNetworkInput)
                {
                    goto Label_0157;
                    if (((uint) num) >= 0)
                    {
                        goto Label_01A2;
                    }
                }
                if (num >= data.Length)
                {
                    throw new NormalizationError("Can't build data, input fields used for neural input, must match provided data(" + data.Length + ").");
                }
                if ((((uint) num4) - ((uint) num2)) < 0)
                {
                    goto Label_0157;
                }
            Label_01A2:
                field.CurrentValue = data[num++];
                goto Label_0157;
            Label_01D2:
                field = enumerator.Current;
                goto Label_0168;
            }
        Label_01EF:
            num2 = 0;
            if ((((uint) num5) - ((uint) num)) <= uint.MaxValue)
            {
                using (IEnumerator<IOutputField> enumerator2 = this._outputFields.GetEnumerator())
                {
                    IOutputField field2;
                Label_0031:
                    if (enumerator2.MoveNext())
                    {
                        goto Label_0077;
                    }
                    goto Label_00A8;
                Label_003E:
                    while (field2.Ideal)
                    {
                        if (((uint) num2) <= uint.MaxValue)
                        {
                            goto Label_0031;
                        }
                    }
                    int num3 = 0;
                    while (num3 < field2.SubfieldCount)
                    {
                        num2++;
                        num3++;
                    }
                    goto Label_0031;
                Label_0077:
                    field2 = enumerator2.Current;
                    if ((((uint) num3) & 0) == 0)
                    {
                    }
                    goto Label_003E;
                }
            }
            goto Label_00A8;
        }

        private void DetermineInputFieldValue(IInputField field, int index)
        {
            double num;
            InputFieldCSV dcsv;
            if (field is InputFieldCSV)
            {
                goto Label_00F5;
            }
            if (field is InputFieldMLDataSet)
            {
                InputFieldMLDataSet set = (InputFieldMLDataSet) field;
                MLDataFieldHolder holder = this._dataSetFieldMap[field];
                IMLDataPair pair = holder.Pair;
                int offset = set.Offset;
                if ((((uint) index) >= 0) && (offset >= pair.Input.Count))
                {
                    offset -= pair.Input.Count;
                    num = pair.Ideal[offset];
                    if ((((uint) index) + ((uint) num)) > uint.MaxValue)
                    {
                        return;
                    }
                    if (((uint) offset) >= 0)
                    {
                        if (0 != 0)
                        {
                            return;
                        }
                        goto Label_0022;
                    }
                    goto Label_00F5;
                }
                num = pair.Input[offset];
            }
            else
            {
                num = field.GetValue(index);
            }
        Label_0022:
            field.CurrentValue = num;
            return;
        Label_00F5:
            dcsv = (InputFieldCSV) field;
            num = this._csvMap[field].GetDouble(dcsv.Offset);
            goto Label_0022;
        }

        private void DetermineInputFieldValues(int index)
        {
            foreach (IInputField field in this._inputFields)
            {
                this.DetermineInputFieldValue(field, index);
            }
        }

        public IInputField FindInputField(Type clazz, int count)
        {
            int num = 0;
            using (IEnumerator<IInputField> enumerator = this._inputFields.GetEnumerator())
            {
                IInputField current;
                goto Label_001F;
            Label_0014:
                if (num == count)
                {
                    return current;
                }
                num++;
                if (0 != 0)
                {
                    goto Label_0014;
                }
            Label_001F:
                if (enumerator.MoveNext())
                {
                    current = enumerator.Current;
                    if (!current.GetType().IsInstanceOfType(clazz))
                    {
                        goto Label_001F;
                    }
                    goto Label_0014;
                }
            }
            return null;
        }

        public IOutputField FindOutputField(Type clazz, int count)
        {
            int num = 0;
            using (IEnumerator<IOutputField> enumerator = this._outputFields.GetEnumerator())
            {
                IOutputField current;
                goto Label_001F;
            Label_0017:
                if (num == count)
                {
                    return current;
                }
                num++;
            Label_001F:
                if (enumerator.MoveNext())
                {
                    current = enumerator.Current;
                    while (!current.GetType().IsInstanceOfType(clazz) || ((((uint) num) + ((uint) count)) < 0))
                    {
                        if (current.GetType() != clazz)
                        {
                            goto Label_001F;
                        }
                        break;
                    }
                    goto Label_0017;
                }
            }
            return null;
        }

        private void FirstPass()
        {
            int num;
            this.OpenCSV();
            if (0 == 0)
            {
                goto Label_00FB;
            }
            goto Label_004C;
        Label_0029:
            if (3 == 0)
            {
                goto Label_009B;
            }
            if ((((uint) num) + ((uint) num)) > uint.MaxValue)
            {
                goto Label_0029;
            }
        Label_0048:
            num++;
        Label_004C:
            if (this.Next())
            {
                this.DetermineInputFieldValues(num);
            }
            else
            {
                if ((((uint) num) + ((uint) num)) <= uint.MaxValue)
                {
                    if ((((uint) num) & 0) == 0)
                    {
                        return;
                    }
                    goto Label_00FB;
                }
                goto Label_004C;
            }
        Label_009B:
            if (this.ShouldInclude())
            {
                this.ApplyMinMax();
                this._recordCount++;
                this.ReportResult("First pass, analyzing file", 0, this._recordCount);
            }
            else if ((((uint) num) + ((uint) num)) <= uint.MaxValue)
            {
                goto Label_0048;
            }
            goto Label_0029;
        Label_00FB:
            this.OpenDataSet();
        Label_0101:
            if ((((uint) num) & 0) != 0)
            {
                goto Label_0029;
            }
            this._currentIndex = -1;
            this._recordCount = 0;
            if (this._report != null)
            {
                this._report.Report(0, 0, "Analyzing file");
                if (0 != 0)
                {
                    goto Label_0101;
                }
            }
            this._lastReport = 0;
            num = 0;
            this.InitForPass();
            goto Label_004C;
        }

        public int GetNetworkInputLayerSize()
        {
            return (from field in this._outputFields
                where !field.Ideal
                select field).Sum<IOutputField>(field => field.SubfieldCount);
        }

        public int GetNetworkOutputLayerSize()
        {
            return (from field in this._outputFields
                where field.Ideal
                select field).Sum<IOutputField>(field => field.SubfieldCount);
        }

        public int GetOutputFieldCount()
        {
            return this._outputFields.Sum<IOutputField>(field => field.SubfieldCount);
        }

        private void Init()
        {
            this._csvMap = new Dictionary<IInputField, ReadCSV>();
            this._dataSetFieldMap = new Dictionary<IInputField, MLDataFieldHolder>();
            this._dataSetIteratorMap = new Dictionary<IEnumerator<IMLDataPair>, MLDataFieldHolder>();
            this._readCSV = new List<ReadCSV>();
            this._readDataSet = new List<IEnumerator<IMLDataPair>>();
        }

        public void InitForOutput()
        {
            foreach (IOutputFieldGroup group in this._groups)
            {
                group.RowInit();
            }
            foreach (IOutputField field in this._outputFields)
            {
                field.RowInit();
            }
        }

        public void InitForPass()
        {
            foreach (ISegregator segregator in this._segregators)
            {
                segregator.PassInit();
            }
        }

        private bool Next()
        {
            if (!this._readCSV.Any<ReadCSV>(csv => !csv.Next()))
            {
                bool flag;
                using (IEnumerator<IEnumerator<IMLDataPair>> enumerator2 = this._readDataSet.GetEnumerator())
                {
                    IEnumerator<IMLDataPair> enumerator;
                    MLDataFieldHolder holder;
                    IMLDataPair current;
                    goto Label_0075;
                Label_006E:
                    holder.Pair = current;
                Label_0075:
                    if (enumerator2.MoveNext())
                    {
                        goto Label_009B;
                    }
                    goto Label_002C;
                Label_0085:
                    holder = this._dataSetIteratorMap[enumerator];
                    current = enumerator.Current;
                    goto Label_00C1;
                Label_009B:
                    enumerator = enumerator2.Current;
                    if (enumerator.MoveNext())
                    {
                        goto Label_0085;
                    }
                    if (((uint) flag) <= uint.MaxValue)
                    {
                    }
                    return false;
                Label_00C1:
                    if ((((uint) flag) + ((uint) flag)) <= uint.MaxValue)
                    {
                        goto Label_006E;
                    }
                    goto Label_002C;
                }
                if ((((uint) flag) | 0x7fffffff) != 0)
                {
                    goto Label_002C;
                }
                if (2 == 0)
                {
                    goto Label_004D;
                }
                goto Label_010F;
            }
            return false;
        Label_002C:
            if (this._inputFields.OfType<IHasFixedLength>().Any<IHasFixedLength>(fl => (this._currentIndex + 1) >= fl.Length))
            {
                goto Label_010F;
            }
        Label_004D:
            this._currentIndex++;
            return true;
        Label_010F:
            return false;
        }

        private void OpenCSV()
        {
            this._csvMap.Clear();
            this._readCSV.Clear();
            IDictionary<string, ReadCSV> dictionary = new Dictionary<string, ReadCSV>();
            using (IEnumerator<IInputField> enumerator = this._inputFields.GetEnumerator())
            {
                IInputField field;
                InputFieldCSV dcsv;
                string str;
                ReadCSV dcsv2;
                goto Label_0034;
            Label_002D:
                if (0x7fffffff == 0)
                {
                    goto Label_0062;
                }
            Label_0034:
                if (enumerator.MoveNext())
                {
                    goto Label_00AC;
                }
                return;
            Label_0044:
                if (!dictionary.ContainsKey(str))
                {
                    goto Label_0098;
                }
            Label_004D:
                this._csvMap[dcsv] = dictionary[str];
                goto Label_002D;
            Label_0062:
                if (field is InputFieldCSV)
                {
                    goto Label_00B6;
                }
                goto Label_008C;
            Label_006C:
                dictionary[str] = dcsv2;
                if (-1 == 0)
                {
                    goto Label_00BD;
                }
                this._readCSV.Add(dcsv2);
                if (0 == 0)
                {
                    goto Label_004D;
                }
            Label_008C:
                if (4 != 0)
                {
                    goto Label_0034;
                }
                return;
            Label_0098:
                dcsv2 = new ReadCSV(str, false, this._csvFormat);
                if (0 == 0)
                {
                    goto Label_006C;
                }
                return;
            Label_00AC:
                field = enumerator.Current;
                goto Label_0062;
            Label_00B6:
                dcsv = (InputFieldCSV) field;
            Label_00BD:
                str = dcsv.File;
                goto Label_0044;
            }
        }

        private void OpenDataSet()
        {
            this._readDataSet.Clear();
            this._dataSetFieldMap.Clear();
            this._dataSetIteratorMap.Clear();
            IDictionary<IMLDataSet, MLDataFieldHolder> dictionary = new Dictionary<IMLDataSet, MLDataFieldHolder>();
            using (IEnumerator<IInputField> enumerator2 = this._inputFields.GetEnumerator())
            {
                IInputField field;
                InputFieldMLDataSet set;
                IMLDataSet neuralDataSet;
                IEnumerator<IMLDataPair> enumerator;
                MLDataFieldHolder holder;
                MLDataFieldHolder holder2;
                goto Label_006B;
            Label_0036:
                holder2 = dictionary[neuralDataSet];
                this._dataSetFieldMap[set] = holder2;
                this._dataSetIteratorMap[holder2.GetEnumerator()] = holder2;
                goto Label_006B;
            Label_0063:
                if (field is InputFieldMLDataSet)
                {
                    goto Label_00B5;
                }
            Label_006B:
                if (!enumerator2.MoveNext() && (0 == 0))
                {
                    return;
                }
                goto Label_00CB;
            Label_007C:
                holder = new MLDataFieldHolder(enumerator, set);
                dictionary[neuralDataSet] = holder;
            Label_008F:
                this._readDataSet.Add(enumerator);
                goto Label_0036;
            Label_009E:
                if (dictionary.ContainsKey(neuralDataSet))
                {
                    goto Label_0036;
                }
                enumerator = neuralDataSet.GetEnumerator();
                goto Label_00D5;
            Label_00B5:
                set = (InputFieldMLDataSet) field;
                if (0 == 0)
                {
                    neuralDataSet = set.NeuralDataSet;
                    if (0 != 0)
                    {
                        goto Label_008F;
                    }
                }
                goto Label_009E;
            Label_00CB:
                field = enumerator2.Current;
                goto Label_0063;
            Label_00D5:
                if (0 == 0)
                {
                    goto Label_007C;
                }
                goto Label_0036;
            }
        }

        public void Process()
        {
            this.Init();
            if ((0 != 0) || this.TwoPassesNeeded())
            {
                this.FirstPass();
            }
            this.SecondPass();
        }

        private void ReportResult(string message, int total, int current)
        {
            this._lastReport++;
            while (this._lastReport >= 0x2710)
            {
                this._report.Report(total, current, message);
                this._lastReport = 0;
                break;
            }
        }

        private void SecondPass()
        {
            int outputFieldCount;
            bool flag = this.TwoPassesNeeded();
            this.OpenCSV();
            do
            {
                this.OpenDataSet();
                this.InitForPass();
                this._currentIndex = -1;
                outputFieldCount = this.GetOutputFieldCount();
            }
            while (((uint) outputFieldCount) < 0);
            double[] data = new double[outputFieldCount];
            this._storage.Open();
            this._lastReport = 0;
            int index = 0;
            int num3 = 0;
        Label_000C:
            if (this.Next())
            {
                foreach (IInputField field in this._inputFields)
                {
                    this.DetermineInputFieldValue(field, index);
                }
            }
            else
            {
                if (((uint) index) > uint.MaxValue)
                {
                    goto Label_000C;
                }
                this._storage.Close();
                return;
            }
        Label_0066:
            if (this.ShouldInclude())
            {
                int num5;
                this.InitForOutput();
                int num4 = 0;
                if (((uint) num5) < 0)
                {
                    return;
                }
                using (IEnumerator<IOutputField> enumerator2 = this._outputFields.GetEnumerator())
                {
                    IOutputField current;
                    goto Label_0096;
                Label_008B:
                    if (num5 < current.SubfieldCount)
                    {
                        goto Label_00B6;
                    }
                Label_0096:
                    if (!enumerator2.MoveNext())
                    {
                        this.ReportResult(flag ? "Second pass, normalizing data" : "Processing data (single pass)", this._recordCount, ++num3);
                        this._storage.Write(data, 0);
                        if (((((uint) flag) + ((uint) num3)) >= 0) || ((((uint) num4) - ((uint) num5)) < 0))
                        {
                            goto Label_0071;
                        }
                        goto Label_0066;
                    }
                    do
                    {
                        current = enumerator2.Current;
                        num5 = 0;
                    }
                    while (0x7fffffff == 0);
                    goto Label_008B;
                Label_00B6:
                    data[num4++] = current.Calculate(num5);
                    num5++;
                    goto Label_008B;
                }
            }
        Label_0071:
            index++;
            goto Label_000C;
        }

        private bool ShouldInclude()
        {
            return this._segregators.All<ISegregator>(segregator => segregator.ShouldInclude());
        }

        public bool TwoPassesNeeded()
        {
            return this._outputFields.OfType<IRequireTwoPass>().Any<IRequireTwoPass>();
        }

        public CSVFormat CSVFormatUsed
        {
            get
            {
                return this._csvFormat;
            }
            set
            {
                this._csvFormat = value;
            }
        }

        public IList<IOutputFieldGroup> Groups
        {
            get
            {
                return this._groups;
            }
        }

        public IList<IInputField> InputFields
        {
            get
            {
                return this._inputFields;
            }
        }

        public IList<IOutputField> OutputFields
        {
            get
            {
                return this._outputFields;
            }
        }

        public int RecordCount
        {
            get
            {
                return this._recordCount;
            }
        }

        public IStatusReportable Report
        {
            get
            {
                return this._report;
            }
            set
            {
                this._report = value;
            }
        }

        public IList<ISegregator> Segregators
        {
            get
            {
                return this._segregators;
            }
        }

        public INormalizationStorage Storage
        {
            get
            {
                return this._storage;
            }
            set
            {
                this._storage = value;
            }
        }
    }
}

