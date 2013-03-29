namespace Encog.ML.Data.Basic
{
    using Encog.ML.Data;
    using Encog.Util;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    [Serializable]
    public class BasicMLDataSet : IMLDataSet, IEnumerable<IMLDataPair>, IEnumerable
    {
        private IList<IMLDataPair> _data;

        public BasicMLDataSet()
        {
            this._data = new List<IMLDataPair>();
        }

        public BasicMLDataSet(IMLDataSet set)
        {
            int calcedSize;
            this._data = new List<IMLDataPair>();
            this._data = new List<IMLDataPair>();
            int inputSize = set.InputSize;
            if ((((uint) calcedSize) + ((uint) inputSize)) >= 0)
            {
                int idealSize = set.IdealSize;
                do
                {
                    calcedSize = set.CalcedSize;
                }
                while ((((uint) inputSize) - ((uint) inputSize)) < 0);
                int errorSize = set.ErrorSize;
                using (IEnumerator<IMLDataPair> enumerator = set.GetEnumerator())
                {
                    IMLDataPair pair;
                    BasicMLData data;
                    BasicMLData data2;
                    BasicMLData data3;
                    BasicMLData data4;
                    goto Label_007F;
                Label_004D:
                    if (errorSize > 0)
                    {
                        data4 = new BasicMLData(errorSize);
                        EngineArray.ArrayCopy(pair.ErrorArray, data4.Data);
                    }
                    this.Add(new BasicMLDataPair(data, data2, data3, data4));
                Label_007F:
                    if (enumerator.MoveNext())
                    {
                        goto Label_018D;
                    }
                    return;
                Label_0092:
                    data3 = new BasicMLData(calcedSize);
                    EngineArray.ArrayCopy(pair.CalcedArray, data3.Data);
                    goto Label_004D;
                Label_00AF:
                    if (calcedSize > 0)
                    {
                        goto Label_0092;
                    }
                    if ((((uint) calcedSize) | 1) == 0)
                    {
                        goto Label_00EB;
                    }
                    goto Label_004D;
                Label_00D0:
                    EngineArray.ArrayCopy(pair.IdealArray, data2.Data);
                    goto Label_00AF;
                Label_00E5:
                    if (idealSize > 0)
                    {
                        goto Label_0130;
                    }
                    goto Label_00AF;
                Label_00EB:
                    if ((((uint) idealSize) + ((uint) inputSize)) > uint.MaxValue)
                    {
                        goto Label_004D;
                    }
                    if (((uint) errorSize) < 0)
                    {
                        goto Label_00EB;
                    }
                    if ((((uint) idealSize) - ((uint) calcedSize)) >= 0)
                    {
                        goto Label_00E5;
                    }
                Label_0130:
                    data2 = new BasicMLData(idealSize);
                    goto Label_00D0;
                Label_0141:
                    if (inputSize <= 0)
                    {
                        goto Label_00E5;
                    }
                    data = new BasicMLData(inputSize);
                    if ((((uint) calcedSize) - ((uint) idealSize)) > uint.MaxValue)
                    {
                        goto Label_00D0;
                    }
                    EngineArray.ArrayCopy(pair.InputArray, data.Data);
                    goto Label_00EB;
                Label_017D:
                    data = null;
                    data2 = null;
                    data3 = null;
                    data4 = null;
                    goto Label_0141;
                Label_018D:
                    pair = enumerator.Current;
                    goto Label_017D;
                }
            }
        }

        public BasicMLDataSet(IList<IMLDataPair> data)
        {
            this._data = new List<IMLDataPair>();
            this._data = data;
        }

        public BasicMLDataSet(double[][] input, double[][] ideal)
        {
            int num;
            double[] numArray;
            double[] numArray2;
            int num2;
            BasicMLData data;
            int num3;
            BasicMLData data2;
            this._data = new List<IMLDataPair>();
            goto Label_0169;
        Label_0046:
            if (num < input.Length)
            {
                numArray = new double[input[0].Length];
                num2 = 0;
                goto Label_010B;
            }
            return;
        Label_0054:
            if (ideal != null)
            {
                numArray2 = new double[ideal[0].Length];
                num3 = 0;
                goto Label_006A;
            }
        Label_005A:
            data2 = new BasicMLData(numArray);
            if ((((uint) num3) | 0xff) != 0)
            {
                this.Add(data2, data);
                if ((((uint) num2) + ((uint) num)) < 0)
                {
                    goto Label_010B;
                }
                num++;
                if (3 == 0)
                {
                    goto Label_005A;
                }
                goto Label_0046;
            }
            goto Label_00CB;
        Label_006A:
            if (num3 >= numArray2.Length)
            {
                data = new BasicMLData(numArray2);
                do
                {
                    if ((((uint) num2) | 2) != 0)
                    {
                        goto Label_005A;
                    }
                }
                while ((((uint) num2) + ((uint) num2)) < 0);
                goto Label_0054;
            }
        Label_00CB:
            numArray2[num3] = ideal[num][num3];
            if ((((uint) num) | 1) != 0)
            {
                goto Label_0151;
            }
        Label_0107:
            num2++;
        Label_010B:
            if (num2 >= numArray.Length)
            {
                data = null;
                if (0 == 0)
                {
                    goto Label_0054;
                }
                if ((((uint) num3) | 15) != 0)
                {
                    goto Label_00CB;
                }
            }
            else
            {
                numArray[num2] = input[num][num2];
                if ((((uint) num3) - ((uint) num2)) <= uint.MaxValue)
                {
                    goto Label_0107;
                }
            }
        Label_0151:
            if ((((uint) num3) + ((uint) num2)) >= 0)
            {
                num3++;
                goto Label_006A;
            }
        Label_0169:
            num = 0;
            goto Label_0046;
        }

        public virtual void Add(IMLData data1)
        {
            IMLDataPair item = new BasicMLDataPair(data1, null);
            this._data.Add(item);
        }

        public virtual void Add(IMLDataPair inputData)
        {
            this._data.Add(inputData);
        }

        public virtual void Add(IMLData inputData, IMLData idealData)
        {
            IMLDataPair item = new BasicMLDataPair(inputData, idealData);
            this._data.Add(item);
        }

        public virtual void Add(IMLData inputData, IMLData idealData, IMLData calcedData)
        {
            IMLDataPair item = new BasicMLDataPair(inputData, idealData, calcedData);
            this._data.Add(item);
        }

        public virtual void Add(IMLData inputData, IMLData idealData, IMLData calcedData, IMLData errorData)
        {
            IMLDataPair item = new BasicMLDataPair(inputData, idealData, calcedData, errorData);
            this._data.Add(item);
        }

        public object Clone()
        {
            BasicMLDataSet set = new BasicMLDataSet();
            foreach (IMLDataPair pair in this.Data)
            {
                set.Add((IMLDataPair) pair.Clone());
            }
            return set;
        }

        public void Close()
        {
        }

        public IEnumerator<IMLDataPair> GetEnumerator()
        {
            return new BasicNeuralEnumerator(this);
        }

        public void GetRecord(long index, IMLDataPair pair)
        {
            IMLDataPair pair2 = this._data[(int) index];
            pair.InputArray = pair2.Input.Data;
            if (pair.IdealArray != null)
            {
                pair.IdealArray = pair2.Ideal.Data;
            }
        }

        public IMLDataSet OpenAdditional()
        {
            return new BasicMLDataSet(this.Data);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new BasicNeuralEnumerator(this);
        }

        public virtual int CalcedSize
        {
            get
            {
                if ((this._data != null) && (this._data.Count != 0))
                {
                    IMLDataPair pair = this._data[0];
                    if (pair.CalcedArray == null)
                    {
                        return 0;
                    }
                    return pair.Calced.Count;
                }
                return 0;
            }
        }

        public long Count
        {
            get
            {
                return (long) this._data.Count;
            }
        }

        public IList<IMLDataPair> Data
        {
            get
            {
                return this._data;
            }
            set
            {
                this._data = value;
            }
        }

        public virtual int ErrorSize
        {
            get
            {
                IMLDataPair pair;
                if (this._data != null)
                {
                    if (this._data.Count != 0)
                    {
                        pair = this._data[0];
                        if ((3 == 0) || (pair.ErrorArray == null))
                        {
                            return 0;
                        }
                        goto Label_003C;
                    }
                    if (0 != 0)
                    {
                        goto Label_003C;
                    }
                }
                return 0;
            Label_003C:
                return pair.Error.Count;
            }
        }

        public virtual int IdealSize
        {
            get
            {
                if (this._data != null)
                {
                Label_0035:
                    if (this._data.Count != 0)
                    {
                        IMLDataPair pair = this._data[0];
                        if (-1 != 0)
                        {
                            while (pair.IdealArray == null)
                            {
                                return 0;
                            }
                            if (3 != 0)
                            {
                                return pair.Ideal.Count;
                            }
                            goto Label_0035;
                        }
                    }
                }
                return 0;
            }
        }

        public virtual int InputSize
        {
            get
            {
                if ((this._data != null) && (this._data.Count != 0))
                {
                    if (0 == 0)
                    {
                    }
                    IMLDataPair pair = this._data[0];
                    return pair.Input.Count;
                }
                return 0;
            }
        }

        public bool IsSupervised
        {
            get
            {
                if (this._data.Count == 0)
                {
                    return false;
                }
                return this._data[0].Supervised;
            }
        }

        public bool Supervised
        {
            get
            {
                if (this._data.Count == 0)
                {
                    return false;
                }
                return this._data[0].Supervised;
            }
        }

        [Serializable]
        public class BasicNeuralEnumerator : IEnumerator<IMLDataPair>, IEnumerator, IDisposable
        {
            private int _current = -1;
            private readonly BasicMLDataSet _owner;

            public BasicNeuralEnumerator(BasicMLDataSet owner)
            {
                this._owner = owner;
            }

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                this._current++;
                while (this._current >= this._owner._data.Count)
                {
                    return false;
                }
                return true;
            }

            public void Reset()
            {
                this._current = -1;
            }

            public IMLDataPair Current
            {
                get
                {
                    return this._owner._data[this._current];
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    if (this._current < 0)
                    {
                        throw new InvalidOperationException("Must call MoveNext before reading Current.");
                    }
                    return this._owner._data[this._current];
                }
            }
        }
    }
}

