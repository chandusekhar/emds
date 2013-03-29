namespace Encog.ML.Data.Buffer
{
    using Encog.ML.Data;
    using Encog.ML.Data.Basic;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;

    public class BufferedNeuralDataSetEnumerator : IEnumerator<IMLDataPair>, IEnumerator, IDisposable
    {
        private IMLDataPair _x27621a3c307a4a9a;
        private int _x3bd62873fafa6252;
        private readonly BufferedMLDataSet _x4a3f0a05c02f235f;

        public BufferedNeuralDataSetEnumerator(BufferedMLDataSet owner)
        {
            this._x4a3f0a05c02f235f = owner;
            this._x3bd62873fafa6252 = 0;
        }

        public void Close()
        {
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            try
            {
                if (this._x3bd62873fafa6252 >= this._x4a3f0a05c02f235f.Count)
                {
                    int num;
                    bool flag = false;
                    if (((uint) num) <= uint.MaxValue)
                    {
                        return flag;
                    }
                }
                else
                {
                    this._x27621a3c307a4a9a = BasicMLDataPair.CreatePair(this._x4a3f0a05c02f235f.InputSize, this._x4a3f0a05c02f235f.IdealSize);
                }
                this._x4a3f0a05c02f235f.GetRecord((long) this._x3bd62873fafa6252++, this._x27621a3c307a4a9a);
                return true;
            }
            catch (EndOfStreamException)
            {
                return false;
            }
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public IMLDataPair Current
        {
            get
            {
                return this._x27621a3c307a4a9a;
            }
        }

        object IEnumerator.Current
        {
            get
            {
                if (this._x27621a3c307a4a9a == null)
                {
                    throw new IMLDataError("Can't read current record until MoveNext is called once.");
                }
                return this._x27621a3c307a4a9a;
            }
        }

        object xb9ac0e46915f1b64
        {
            get
            {
                if (this._x27621a3c307a4a9a == null)
                {
                    throw new IMLDataError("Can't read current record until MoveNext is called once.");
                }
                return this._x27621a3c307a4a9a;
            }
        }
    }
}

