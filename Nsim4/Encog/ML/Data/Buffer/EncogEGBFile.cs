namespace Encog.ML.Data.Buffer
{
    using System;
    using System.IO;

    public class EncogEGBFile
    {
        private int _x43f451310e815b76;
        private BinaryReader _x4c7b3ec871749b3b;
        private int _x7d0efe641fcf5d57;
        private int _x88770833a11cfa1a;
        private BinaryWriter _xb0c1b6e952349c8a;
        private readonly string _xb44380e048627945;
        private int _xb52d4a98fad404da;
        private FileStream _xcf18e5243f8d5fd3;
        private int _xd272a54e91b953fc;
        public const int DoubleSize = 8;
        public const int HeaderSize = 0x18;

        public EncogEGBFile(string file)
        {
            this._xb44380e048627945 = file;
        }

        public void Close()
        {
            try
            {
                if (this._xb0c1b6e952349c8a == null)
                {
                    goto Label_001A;
                }
                goto Label_004A;
            Label_000A:
                if (0 == 0)
                {
                    return;
                }
            Label_0010:
                if (this._xcf18e5243f8d5fd3 != null)
                {
                    goto Label_0024;
                }
                goto Label_0043;
            Label_001A:
                if (this._x4c7b3ec871749b3b != null)
                {
                    goto Label_005F;
                }
                goto Label_0010;
            Label_0024:
                this._xcf18e5243f8d5fd3.Close();
                if (0xff == 0)
                {
                    goto Label_0010;
                }
                this._xcf18e5243f8d5fd3 = null;
                goto Label_000A;
            Label_0043:
                if (0xff != 0)
                {
                    return;
                }
            Label_004A:
                this._xb0c1b6e952349c8a.Close();
                this._xb0c1b6e952349c8a = null;
                if (0 == 0)
                {
                    goto Label_001A;
                }
            Label_005F:
                this._x4c7b3ec871749b3b.Close();
                this._x4c7b3ec871749b3b = null;
                if (0 != 0)
                {
                    goto Label_004A;
                }
                goto Label_0010;
            }
            catch (IOException exception)
            {
                throw new BufferedDataError(exception);
            }
        }

        public void Create(int inputCount, int idealCount)
        {
            try
            {
                double[] numArray;
                double[] numArray2;
                this._x43f451310e815b76 = inputCount;
                goto Label_016A;
            Label_000C:
                this._xb0c1b6e952349c8a.Write((double) numArray.Length);
                this._xb0c1b6e952349c8a.Write((double) numArray2.Length);
                this._x7d0efe641fcf5d57 = 0;
                this._x88770833a11cfa1a = (this._x43f451310e815b76 + this._xb52d4a98fad404da) + 1;
                this._xd272a54e91b953fc = this._x88770833a11cfa1a * 8;
                goto Label_00AA;
            Label_0056:
                this._xb0c1b6e952349c8a.Write((byte) 0x2d);
                this._xb0c1b6e952349c8a.Write((byte) 0x30);
                if ((((uint) inputCount) - ((uint) inputCount)) < 0)
                {
                    goto Label_00CD;
                }
                this._xb0c1b6e952349c8a.Write((byte) 0x30);
                if (((uint) inputCount) <= uint.MaxValue)
                {
                    goto Label_000C;
                }
            Label_00AA:
                if (0 == 0)
                {
                    return;
                }
                goto Label_016A;
            Label_00B5:
                if ((((uint) idealCount) - ((uint) inputCount)) > uint.MaxValue)
                {
                    goto Label_013C;
                }
            Label_00CD:
                this._xb0c1b6e952349c8a.Write((byte) 0x4f);
                this._xb0c1b6e952349c8a.Write((byte) 0x47);
                goto Label_01B6;
            Label_00EC:
                this._xb0c1b6e952349c8a.Write((byte) 0x43);
                goto Label_00B5;
            Label_00FE:
                this._xb0c1b6e952349c8a.Write((byte) 0x4e);
                if (1 != 0)
                {
                    goto Label_00EC;
                }
                goto Label_016A;
            Label_0117:
                this._xb0c1b6e952349c8a.Write((byte) 0x45);
                goto Label_00FE;
            Label_0129:
                this._xcf18e5243f8d5fd3 = new FileStream(this._xb44380e048627945, FileMode.Create, FileAccess.ReadWrite);
            Label_013C:
                this._xb0c1b6e952349c8a = new BinaryWriter(this._xcf18e5243f8d5fd3);
                this._x4c7b3ec871749b3b = null;
                goto Label_0117;
            Label_0156:
                this._xcf18e5243f8d5fd3.Close();
                this._xcf18e5243f8d5fd3 = null;
                goto Label_0129;
            Label_016A:
                this._xb52d4a98fad404da = idealCount;
                numArray = new double[inputCount];
                do
                {
                    numArray2 = new double[idealCount];
                    if (this._xcf18e5243f8d5fd3 == null)
                    {
                        goto Label_0129;
                    }
                }
                while ((((uint) inputCount) & 0) != 0);
                goto Label_0156;
            Label_01B6:
                if ((((uint) inputCount) + ((uint) idealCount)) >= 0)
                {
                    goto Label_0056;
                }
            }
            catch (IOException exception)
            {
                throw new BufferedDataError(exception);
            }
        }

        public void Open()
        {
            // This item is obfuscated and can not be translated.
        }

        public double Read()
        {
            double num;
            try
            {
                num = this._x4c7b3ec871749b3b.ReadDouble();
            }
            catch (IOException exception)
            {
                throw new BufferedDataError(exception);
            }
            return num;
        }

        public void Read(double[] d)
        {
            try
            {
                for (int i = 0; i < d.Length; i++)
                {
                    d[i] = this._x4c7b3ec871749b3b.ReadDouble();
                }
            }
            catch (IOException exception)
            {
                throw new BufferedDataError(exception);
            }
        }

        public double Read(int row, int col)
        {
            double num;
            try
            {
                this._xcf18e5243f8d5fd3.Position = this.x7806fdb0315c23c4(row, col);
                num = this._x4c7b3ec871749b3b.ReadDouble();
            }
            catch (IOException exception)
            {
                throw new BufferedDataError(exception);
            }
            return num;
        }

        public void Read(int row, double[] d)
        {
            try
            {
                this._xcf18e5243f8d5fd3.Position = this.x7806fdb0315c23c4(row, 0);
                int index = 0;
                goto Label_0042;
            Label_0018:
                d[index] = this._x4c7b3ec871749b3b.ReadDouble();
                index++;
                if ((((uint) index) + ((uint) index)) < 0)
                {
                    goto Label_0018;
                }
            Label_0042:
                if (index < this._x88770833a11cfa1a)
                {
                    goto Label_0018;
                }
            }
            catch (IOException exception)
            {
                throw new BufferedDataError(exception);
            }
        }

        public void SetLocation(int row)
        {
            try
            {
                this._xcf18e5243f8d5fd3.Position = this.x7806fdb0315c23c4((long) row);
            }
            catch (IOException exception)
            {
                throw new BufferedDataError(exception);
            }
        }

        public void Write(double[] v)
        {
            try
            {
                double num;
                int num2;
                double[] numArray = v;
                goto Label_0028;
            Label_0004:
                num = numArray[num2];
                if (0x7fffffff != 0)
                {
                }
                this._xb0c1b6e952349c8a.Write(num);
                num2++;
            Label_0020:
                if (num2 < numArray.Length)
                {
                    goto Label_0004;
                }
                return;
            Label_0028:
                num2 = 0;
                goto Label_0020;
            }
            catch (IOException exception)
            {
                throw new BufferedDataError(exception);
            }
        }

        public void Write(byte b)
        {
            try
            {
                this._xb0c1b6e952349c8a.Write(b);
            }
            catch (IOException exception)
            {
                throw new BufferedDataError(exception);
            }
        }

        public void Write(double d)
        {
            try
            {
                this._xb0c1b6e952349c8a.Write(d);
            }
            catch (IOException exception)
            {
                throw new BufferedDataError(exception);
            }
        }

        public void Write(int row, double[] v)
        {
            try
            {
                double[] numArray;
                int num2;
                this._xcf18e5243f8d5fd3.Position = this.x7806fdb0315c23c4(row, 0);
                if (-2147483648 != 0)
                {
                    goto Label_003C;
                }
            Label_001B:
                num2 = 0;
                while (num2 < numArray.Length)
                {
                    double num = numArray[num2];
                    this._xb0c1b6e952349c8a.Write(num);
                    num2++;
                }
                return;
            Label_003C:
                if (((uint) num2) <= uint.MaxValue)
                {
                    numArray = v;
                }
                goto Label_001B;
            }
            catch (IOException exception)
            {
                throw new BufferedDataError(exception);
            }
        }

        public void Write(int row, int col, double v)
        {
            try
            {
                this._xcf18e5243f8d5fd3.Position = this.x7806fdb0315c23c4(row, col);
                this._xb0c1b6e952349c8a.Write(v);
            }
            catch (IOException exception)
            {
                throw new BufferedDataError(exception);
            }
        }

        private long x7806fdb0315c23c4(long xa806b754814b9ae0)
        {
            return (0x18L + (xa806b754814b9ae0 * this._xd272a54e91b953fc));
        }

        private int x7806fdb0315c23c4(int xa806b754814b9ae0, int xf0476e906b9d9af4)
        {
            return ((0x18 + (xa806b754814b9ae0 * this._xd272a54e91b953fc)) + (xf0476e906b9d9af4 * 8));
        }

        public int IdealCount
        {
            get
            {
                return this._xb52d4a98fad404da;
            }
        }

        public int InputCount
        {
            get
            {
                return this._x43f451310e815b76;
            }
        }

        public int NumberOfRecords
        {
            get
            {
                return this._x7d0efe641fcf5d57;
            }
        }

        public int RecordCount
        {
            get
            {
                return this._x88770833a11cfa1a;
            }
        }

        public int RecordSize
        {
            get
            {
                return this._xd272a54e91b953fc;
            }
        }

        public FileStream Stream
        {
            get
            {
                return this._xcf18e5243f8d5fd3;
            }
        }
    }
}

