namespace Encog.Util.Normalize.Target
{
    using Encog.ML.Data;
    using Encog.ML.Data.Basic;
    using System;

    [Serializable]
    public class NormalizationStorageMLDataSet : INormalizationStorage
    {
        [NonSerialized]
        private readonly IMLDataSet _dataset;
        private readonly int _idealCount;
        private readonly int _inputCount;

        public NormalizationStorageMLDataSet(IMLDataSet dataset)
        {
            this._dataset = dataset;
            this._inputCount = this._dataset.InputSize;
            this._idealCount = this._dataset.IdealSize;
        }

        public NormalizationStorageMLDataSet(int inputCount, int idealCount)
        {
            this._inputCount = inputCount;
            this._idealCount = idealCount;
            this._dataset = new BasicMLDataSet();
        }

        public void Close()
        {
        }

        public void Open()
        {
        }

        public void Write(double[] data, int inputCount)
        {
            BasicMLData data2;
            BasicMLData data3;
            BasicMLData data4;
            int num;
            int num3;
            if (this._idealCount != 0)
            {
                data3 = new BasicMLData(this._inputCount);
                data4 = new BasicMLData(this._idealCount);
                goto Label_00E3;
            }
            goto Label_00B7;
        Label_001A:
            num3++;
        Label_0020:
            while (num3 >= this._idealCount)
            {
                this._dataset.Add(data3, data4);
                if (0 != 0)
                {
                    goto Label_001A;
                }
                if (0x7fffffff != 0)
                {
                    if (0 == 0)
                    {
                        return;
                    }
                    goto Label_00B7;
                }
            }
            data4[num3] = data[num++];
            if (3 == 0)
            {
                return;
            }
            goto Label_001A;
        Label_00B7:
            data2 = new BasicMLData(data);
            this._dataset.Add(data2);
            return;
        Label_00E3:
            num = 0;
            int num2 = 0;
        Label_0074:
            if (num2 < this._inputCount)
            {
                data3[num2] = data[num++];
                if ((((uint) num2) + ((uint) num)) <= uint.MaxValue)
                {
                    if ((((uint) num3) - ((uint) num3)) < 0)
                    {
                        return;
                    }
                    num2++;
                    if ((((uint) num3) + ((uint) num)) <= uint.MaxValue)
                    {
                        goto Label_0074;
                    }
                    goto Label_00E3;
                }
                goto Label_00B7;
            }
            num3 = 0;
            goto Label_0020;
        }

        public IMLDataSet DataSet
        {
            get
            {
                return this._dataset;
            }
        }
    }
}

