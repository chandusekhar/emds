namespace Encog.ML.Data.Folded
{
    using Encog.ML.Data;
    using Encog.Neural.Networks.Training;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public class FoldedDataSet : IMLDataSet
    {
        private int _x024053b527352a1a;
        private int _x220e9679d4260531;
        private readonly IMLDataSet _x51176d6d4e8e34fa;
        private int _x5d7d77eaaf4d31fa;
        private int _x8d03b3bb80670749;
        private int _xb900fedee8b67f51;
        private int _xf968731b10ec7b36;
        public const string AddNotSupported = "Direct adds to the folded dataset are not supported.";
        [CompilerGenerated]
        private FoldedDataSet x32a86c18b13137ce;

        public FoldedDataSet(IMLDataSet underlying)
        {
            this._x51176d6d4e8e34fa = underlying;
            this.Fold(1);
        }

        public void Add(IMLData data1)
        {
            throw new TrainingError("Direct adds to the folded dataset are not supported.");
        }

        public void Add(IMLDataPair inputData)
        {
            throw new TrainingError("Direct adds to the folded dataset are not supported.");
        }

        public void Add(IMLData inputData, IMLData idealData)
        {
            throw new TrainingError("Direct adds to the folded dataset are not supported.");
        }

        public void Close()
        {
            this._x51176d6d4e8e34fa.Close();
        }

        public void Fold(int numFolds)
        {
            this._x220e9679d4260531 = (int) Math.Min((long) numFolds, this._x51176d6d4e8e34fa.Count);
            this._x8d03b3bb80670749 = (int) (this._x51176d6d4e8e34fa.Count / ((long) this._x220e9679d4260531));
            this._xf968731b10ec7b36 = ((int) this._x51176d6d4e8e34fa.Count) - (this._x8d03b3bb80670749 * this._x220e9679d4260531);
            this.CurrentFold = 0;
        }

        public IEnumerator<IMLDataPair> GetEnumerator()
        {
            return new FoldedEnumerator(this);
        }

        public void GetRecord(long index, IMLDataPair pair)
        {
            this._x51176d6d4e8e34fa.GetRecord(this.CurrentFoldOffset + index, pair);
        }

        public IMLDataSet OpenAdditional()
        {
            return new FoldedDataSet(this._x51176d6d4e8e34fa.OpenAdditional()) { Owner = this };
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
                return (long) this.CurrentFoldSize;
            }
        }

        public int CurrentFold
        {
            get
            {
                if (this.Owner != null)
                {
                    return this.Owner.CurrentFold;
                }
                return this._xb900fedee8b67f51;
            }
            set
            {
                if (this.Owner != null)
                {
                    if (-2147483648 != 0)
                    {
                        throw new TrainingError("Can't set the fold on a non-top-level set.");
                    }
                    goto Label_0013;
                }
            Label_000A:
                if (value >= this._x220e9679d4260531)
                {
                    goto Label_0068;
                }
            Label_0013:
                this._xb900fedee8b67f51 = value;
                this._x024053b527352a1a = this._x8d03b3bb80670749 * this._xb900fedee8b67f51;
                this._x5d7d77eaaf4d31fa = (this._xb900fedee8b67f51 == (this._x220e9679d4260531 - 1)) ? this._xf968731b10ec7b36 : this._x8d03b3bb80670749;
                return;
                if (0 == 0)
                {
                    goto Label_000A;
                }
            Label_0068:
                throw new TrainingError("Can't set the current fold to be greater than the number of folds.");
            }
        }

        public int CurrentFoldOffset
        {
            get
            {
                if (this.Owner != null)
                {
                    return this.Owner.CurrentFoldOffset;
                }
                return this._x024053b527352a1a;
            }
        }

        public int CurrentFoldSize
        {
            get
            {
                if (this.Owner != null)
                {
                    return this.Owner.CurrentFoldSize;
                }
                return this._x5d7d77eaaf4d31fa;
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
                return this._x51176d6d4e8e34fa.IdealSize;
            }
        }

        public int InputSize
        {
            get
            {
                return this._x51176d6d4e8e34fa.InputSize;
            }
        }

        public int NumFolds
        {
            get
            {
                return this._x220e9679d4260531;
            }
        }

        public FoldedDataSet Owner
        {
            [CompilerGenerated]
            get
            {
                return this.x32a86c18b13137ce;
            }
            [CompilerGenerated]
            set
            {
                this.x32a86c18b13137ce = value;
            }
        }

        public bool Supervised
        {
            get
            {
                return this._x51176d6d4e8e34fa.Supervised;
            }
        }

        public IMLDataSet Underlying
        {
            get
            {
                return this._x51176d6d4e8e34fa;
            }
        }
    }
}

