namespace Encog.ML.Data.Buffer
{
    using Encog.ML.Data;
    using Encog.ML.Data.Basic;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class BufferedMLDataSet : IMLDataSet
    {
        [NonSerialized]
        private BufferedMLDataSet _x071bde1041617fce;
        public const string ERROR_ADD = "Add can only be used after calling beginLoad.";
        [NonSerialized]
        private bool x9d1ad065519fbd8f;
        [NonSerialized]
        private readonly IList<BufferedMLDataSet> xaa0d3e5126463e13 = new List<BufferedMLDataSet>();
        private readonly string xb44380e048627945;
        [NonSerialized]
        private EncogEGBFile xb77060c140f92cfd;

        public BufferedMLDataSet(string binaryFile)
        {
            if (0 == 0)
            {
                if (0 != 0)
                {
                    return;
                }
                this.xb44380e048627945 = binaryFile;
            }
            this.xb77060c140f92cfd = new EncogEGBFile(binaryFile);
            if ((15 == 0) || File.Exists(this.xb44380e048627945))
            {
                this.xb77060c140f92cfd.Open();
            }
        }

        public void Add(IMLData data1)
        {
            if (!this.x9d1ad065519fbd8f)
            {
                throw new IMLDataError("Add can only be used after calling beginLoad.");
            }
            this.xb77060c140f92cfd.Write(data1.Data);
            this.xb77060c140f92cfd.Write((double) 1.0);
        }

        public void Add(IMLDataPair pair)
        {
            if (!this.x9d1ad065519fbd8f)
            {
                throw new IMLDataError("Add can only be used after calling beginLoad.");
            }
            this.xb77060c140f92cfd.Write(pair.Input.Data);
            this.xb77060c140f92cfd.Write(pair.Ideal.Data);
            this.xb77060c140f92cfd.Write(pair.Significance);
        }

        public void Add(IMLData inputData, IMLData idealData)
        {
            if (!this.x9d1ad065519fbd8f)
            {
                throw new IMLDataError("Add can only be used after calling beginLoad.");
            }
            this.xb77060c140f92cfd.Write(inputData.Data);
            this.xb77060c140f92cfd.Write(idealData.Data);
            this.xb77060c140f92cfd.Write((double) 1.0);
        }

        public void BeginLoad(int inputSize, int idealSize)
        {
            this.xb77060c140f92cfd.Create(inputSize, idealSize);
            this.x9d1ad065519fbd8f = true;
        }

        public void Close()
        {
            object[] source = this.xaa0d3e5126463e13.ToArray<BufferedMLDataSet>();
        Label_0040:
            foreach (BufferedMLDataSet set in source.Cast<BufferedMLDataSet>())
            {
                set.Close();
            }
            this.xaa0d3e5126463e13.Clear();
        Label_002C:
            if (this._x071bde1041617fce != null)
            {
                this._x071bde1041617fce.RemoveAdditional(this);
                if (-2147483648 == 0)
                {
                    goto Label_002C;
                }
                if (0 == 0)
                {
                    if (-2147483648 == 0)
                    {
                        return;
                    }
                }
                else
                {
                    goto Label_0040;
                }
            }
            this.xb77060c140f92cfd.Close();
            this.xb77060c140f92cfd = null;
            if (1 != 0)
            {
                return;
            }
            goto Label_0040;
        }

        public void EndLoad()
        {
            if (!this.x9d1ad065519fbd8f)
            {
                throw new BufferedDataError("Must call beginLoad, before endLoad.");
            }
            this.xb77060c140f92cfd.Close();
            this.x9d1ad065519fbd8f = false;
            this.Open();
        }

        public IEnumerator<IMLDataPair> GetEnumerator()
        {
            if (this.x9d1ad065519fbd8f)
            {
                throw new IMLDataError("Can't create enumerator while loading, call EndLoad first.");
            }
            return new BufferedNeuralDataSetEnumerator(this);
        }

        public void GetRecord(long index, IMLDataPair pair)
        {
            double[] inputArray = pair.InputArray;
            double[] idealArray = pair.IdealArray;
            this.xb77060c140f92cfd.SetLocation((int) index);
            this.xb77060c140f92cfd.Read(inputArray);
            do
            {
                this.xb77060c140f92cfd.Read(idealArray);
                pair.Significance = this.xb77060c140f92cfd.Read();
            }
            while (0xff == 0);
        }

        public void Load(IMLDataSet training)
        {
            this.BeginLoad(training.InputSize, training.IdealSize);
            foreach (IMLDataPair pair in training)
            {
                this.Add(pair);
            }
            this.EndLoad();
        }

        public IMLDataSet LoadToMemory()
        {
            BasicMLDataSet set = new BasicMLDataSet();
            foreach (IMLDataPair pair in this)
            {
                set.Add(pair);
            }
            return set;
        }

        public void Open()
        {
            this.xb77060c140f92cfd.Open();
        }

        public IMLDataSet OpenAdditional()
        {
            BufferedMLDataSet item = new BufferedMLDataSet(this.xb44380e048627945) {
                _x071bde1041617fce = this
            };
            this.xaa0d3e5126463e13.Add(item);
            return item;
        }

        public void RemoveAdditional(BufferedMLDataSet child)
        {
            lock (this)
            {
                this.xaa0d3e5126463e13.Remove(child);
            }
        }

        public string BinaryFile
        {
            get
            {
                return this.xb44380e048627945;
            }
        }

        public int CalcedSize
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public long Count
        {
            get
            {
                return ((this.xb77060c140f92cfd == null) ? ((long) 0) : ((long) this.xb77060c140f92cfd.NumberOfRecords));
            }
        }

        public EncogEGBFile EGB
        {
            get
            {
                return this.xb77060c140f92cfd;
            }
        }

        public int ErrorSize
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int IdealSize
        {
            get
            {
                if (this.xb77060c140f92cfd != null)
                {
                    return this.xb77060c140f92cfd.IdealCount;
                }
                return 0;
            }
        }

        public int InputSize
        {
            get
            {
                if (this.xb77060c140f92cfd != null)
                {
                    return this.xb77060c140f92cfd.InputCount;
                }
                return 0;
            }
        }

        public BufferedMLDataSet Owner
        {
            get
            {
                return this._x071bde1041617fce;
            }
            set
            {
                this._x071bde1041617fce = value;
            }
        }

        public bool Supervised
        {
            get
            {
                if (this.xb77060c140f92cfd == null)
                {
                    return false;
                }
                return (this.xb77060c140f92cfd.IdealCount > 0);
            }
        }
    }
}

