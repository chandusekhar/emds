namespace Encog.Parse
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Runtime.CompilerServices;

    public class PeekableInputStream : Stream
    {
        private int _x31859a38ae0c6358;
        private byte[] _x9376edd3277f388d;
        private readonly Stream _xcf18e5243f8d5fd3;

        public PeekableInputStream(Stream stream)
        {
            this._xcf18e5243f8d5fd3 = stream;
            this._x9376edd3277f388d = new byte[10];
            this._x31859a38ae0c6358 = 0;
        }

        public override void Flush()
        {
        }

        public int Peek()
        {
            return this.Peek(0);
        }

        public int Peek(int depth)
        {
            byte[] buffer;
            int num;
            int num2;
            int num4;
            if (this._x9376edd3277f388d.Length > depth)
            {
                goto Label_0030;
            }
            goto Label_00AF;
        Label_0017:
            this._x31859a38ae0c6358 = depth + 1;
            goto Label_00EA;
        Label_0029:
            this._x9376edd3277f388d = buffer;
        Label_0030:
            if (depth >= this._x31859a38ae0c6358)
            {
                num2 = this._x31859a38ae0c6358;
                int count = (depth - this._x31859a38ae0c6358) + 1;
                num4 = this._xcf18e5243f8d5fd3.Read(this._x9376edd3277f388d, num2, count);
                if (15 != 0)
                {
                    if (num4 < 1)
                    {
                        return -1;
                    }
                    goto Label_0017;
                }
                if (0 == 0)
                {
                    goto Label_0017;
                }
            }
            goto Label_00EA;
        Label_007D:
            buffer[num] = this._x9376edd3277f388d[num];
            num++;
        Label_008C:
            if (num < this._x9376edd3277f388d.Length)
            {
                goto Label_007D;
            }
            if ((((uint) depth) - ((uint) num2)) <= uint.MaxValue)
            {
                goto Label_0029;
            }
        Label_00AF:
            if ((((uint) num4) - ((uint) num)) > uint.MaxValue)
            {
                goto Label_007D;
            }
            if ((((uint) num2) - ((uint) num4)) <= uint.MaxValue)
            {
                buffer = new byte[depth + 10];
                num = 0;
                goto Label_008C;
            }
            goto Label_0029;
        Label_00EA:
            return this._x9376edd3277f388d[depth];
        }

        public bool Peek(string str)
        {
            return !str.Where<char>(new Func<char, int, bool>(this.x1f82ede48dbb799d)).Any<char>();
        }

        public int Read()
        {
            int num;
            byte[] buffer = new byte[1];
            if (((uint) num) <= uint.MaxValue)
            {
                num = this.Read(buffer, 0, 1);
            }
            if (num < 1)
            {
                return -1;
            }
            return buffer[0];
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            int num;
            if (this._x31859a38ae0c6358 != 0)
            {
                num = 0;
                goto Label_0030;
            }
            if (2 != 0)
            {
                return this._xcf18e5243f8d5fd3.Read(buffer, offset, count);
            }
            if (((uint) offset) < 0)
            {
                goto Label_0030;
            }
        Label_0021:
            buffer[offset + num] = this.x47c79a4d207183de();
            num++;
        Label_0030:
            if (num < count)
            {
                goto Label_0021;
            }
            return count;
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotSupportedException();
        }

        public override void SetLength(long v)
        {
            throw new NotSupportedException();
        }

        public long Skip(long count)
        {
            for (long i = count; i > 0L; i -= 1L)
            {
                this.Read();
            }
            return count;
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new NotSupportedException();
        }

        [CompilerGenerated]
        private bool x1f82ede48dbb799d(char x3201d6d15a947682, int x7b28e8a789372508)
        {
            return (this.Peek(x7b28e8a789372508) != x3201d6d15a947682);
        }

        private byte x47c79a4d207183de()
        {
            int num2;
            byte num = this._x9376edd3277f388d[0];
            if ((((uint) num2) - num) < 0)
            {
                goto Label_0052;
            }
            this._x31859a38ae0c6358--;
            num2 = 0;
        Label_000B:
            if (num2 < this._x31859a38ae0c6358)
            {
                this._x9376edd3277f388d[num2] = this._x9376edd3277f388d[num2 + 1];
            }
            else
            {
                return num;
            }
        Label_0052:
            num2++;
            goto Label_000B;
        }

        public override bool CanRead
        {
            get
            {
                return true;
            }
        }

        public override bool CanSeek
        {
            get
            {
                return false;
            }
        }

        public override bool CanWrite
        {
            get
            {
                return false;
            }
        }

        public override long Length
        {
            get
            {
                throw new NotSupportedException();
            }
        }

        public override long Position
        {
            get
            {
                throw new NotSupportedException();
            }
            set
            {
                throw new NotSupportedException();
            }
        }
    }
}

