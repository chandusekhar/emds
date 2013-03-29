namespace Encog.ML.Data.Folded
{
    using Encog.ML.Data;
    using Encog.ML.Data.Basic;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class FoldedEnumerator : IEnumerator<IMLDataPair>, IEnumerator, IDisposable
    {
        private readonly FoldedDataSet _x071bde1041617fce;
        private IMLDataPair _x9629f750dbbc1f15;
        private int _xa34e3dea0ab81193;

        public FoldedEnumerator(FoldedDataSet owner)
        {
            this._x071bde1041617fce = owner;
            this._xa34e3dea0ab81193 = -1;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool HasNext()
        {
            return (this._xa34e3dea0ab81193 < this._x071bde1041617fce.CurrentFoldSize);
        }

        public bool MoveNext()
        {
            if (this.HasNext())
            {
                int num;
                if ((((uint) num) & 0) == 0)
                {
                    IMLDataPair pair = BasicMLDataPair.CreatePair(this._x071bde1041617fce.InputSize, this._x071bde1041617fce.IdealSize);
                    this._x071bde1041617fce.GetRecord((long) this._xa34e3dea0ab81193++, pair);
                    this._x9629f750dbbc1f15 = pair;
                    return true;
                }
            }
            else
            {
                this._x9629f750dbbc1f15 = null;
            }
            return false;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public IMLDataPair Current
        {
            get
            {
                if (this._xa34e3dea0ab81193 < 0)
                {
                    throw new InvalidOperationException("Must call MoveNext before reading Current.");
                }
                return this._x9629f750dbbc1f15;
            }
        }

        object IEnumerator.Current
        {
            get
            {
                if (this._xa34e3dea0ab81193 < 0)
                {
                    throw new InvalidOperationException("Must call MoveNext before reading Current.");
                }
                return this._x9629f750dbbc1f15;
            }
        }

        object xb9ac0e46915f1b64
        {
            get
            {
                if (this._xa34e3dea0ab81193 < 0)
                {
                    throw new InvalidOperationException("Must call MoveNext before reading Current.");
                }
                return this._x9629f750dbbc1f15;
            }
        }
    }
}

