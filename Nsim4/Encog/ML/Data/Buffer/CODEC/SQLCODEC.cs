namespace Encog.ML.Data.Buffer.CODEC
{
    using System;
    using System.Data.Common;
    using System.Data.OleDb;

    public class SQLCODEC : IDataSetCODEC
    {
        private readonly int _x08b9e0820ab2b457;
        private readonly DbConnection _x7316af229433e69e;
        private readonly int _x7e648b416c264559;
        private readonly DbCommand _xd1d7cdb50796b29b;
        private DbDataReader _xd559aa34776631a5;

        public SQLCODEC(string sql, int inputSize, int idealSize, string connectString)
        {
            while (true)
            {
                this._x7e648b416c264559 = inputSize;
                this._x08b9e0820ab2b457 = idealSize;
                do
                {
                    this._x7316af229433e69e = new OleDbConnection(connectString);
                    this._x7316af229433e69e.Open();
                    this._xd1d7cdb50796b29b = this._x7316af229433e69e.CreateCommand();
                    if ((((uint) inputSize) - ((uint) inputSize)) <= uint.MaxValue)
                    {
                        this._xd1d7cdb50796b29b.CommandText = sql;
                        this._xd1d7cdb50796b29b.Prepare();
                    }
                    this._xd1d7cdb50796b29b.Connection = this._x7316af229433e69e;
                    if ((((uint) idealSize) - ((uint) idealSize)) >= 0)
                    {
                        return;
                    }
                }
                while ((((uint) idealSize) + ((uint) inputSize)) > uint.MaxValue);
            }
        }

        public void Close()
        {
            if (this._x7316af229433e69e != null)
            {
                this._x7316af229433e69e.Close();
            }
            while (this._xd559aa34776631a5 != null)
            {
                this._xd559aa34776631a5.Close();
                break;
            }
        }

        public void PrepareRead()
        {
            this._xd559aa34776631a5 = this._xd1d7cdb50796b29b.ExecuteReader();
        }

        public void PrepareWrite(int recordCount, int inputSize, int idealSize)
        {
            throw new NotImplementedException();
        }

        public bool Read(double[] input, double[] ideal, ref double significance)
        {
            int num;
            int num2;
            if (this._xd559aa34776631a5.NextResult())
            {
                num = 1;
                goto Label_0092;
            }
            goto Label_00C5;
        Label_0015:
            if (num2 > this._x08b9e0820ab2b457)
            {
                goto Label_00E2;
            }
        Label_005C:
            ideal[num2 - 1] = this._xd559aa34776631a5.GetDouble(num2 + this._x7e648b416c264559);
            num2++;
            goto Label_0015;
        Label_007A:
            if ((((uint) num2) | 0xff) == 0)
            {
                goto Label_009B;
            }
        Label_0092:
            if (num <= this._x7e648b416c264559)
            {
                input[num - 1] = this._xd559aa34776631a5.GetDouble(num);
                num++;
                goto Label_007A;
            }
        Label_009B:
            if ((0 == 0) && (this._x08b9e0820ab2b457 <= 0))
            {
                if (((uint) num) > uint.MaxValue)
                {
                    goto Label_00E2;
                }
                if ((((uint) num) - ((uint) num2)) >= 0)
                {
                    if ((((uint) num2) - ((uint) num2)) >= 0)
                    {
                        goto Label_00E2;
                    }
                    goto Label_00C5;
                }
                if (0 == 0)
                {
                    goto Label_007A;
                }
                goto Label_005C;
            }
            num2 = 1;
            goto Label_0015;
        Label_00C5:
            return false;
        Label_00E2:
            return true;
        }

        public void Write(double[] input, double[] ideal, double significance)
        {
            throw new NotImplementedException();
        }

        public int IdealSize
        {
            get
            {
                return this._x08b9e0820ab2b457;
            }
        }

        public int InputSize
        {
            get
            {
                return this._x7e648b416c264559;
            }
        }
    }
}

