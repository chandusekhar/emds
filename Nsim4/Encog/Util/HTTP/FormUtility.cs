namespace Encog.Util.HTTP
{
    using Encog.MathUtil;
    using System;
    using System.IO;

    public class FormUtility
    {
        private readonly Stream _x109f7b16542c1f2e;
        private readonly string _x362993ef901691f7;
        private bool _x62584df2cb5d40dd;
        private readonly TextWriter _xbdfb620b7167944b;

        public FormUtility(Stream os, string boundary)
        {
            this._x109f7b16542c1f2e = os;
            this._xbdfb620b7167944b = new StreamWriter(os);
            this._x362993ef901691f7 = boundary;
            this._x62584df2cb5d40dd = true;
        }

        public void Add(string name, string v)
        {
            if (this._x362993ef901691f7 == null)
            {
                if (!this._x62584df2cb5d40dd)
                {
                    this.x6210059f049f0d48("&");
                }
            }
            else
            {
                if (0 == 0)
                {
                }
                this.x6da665da603c8be6();
                this.xa44748aef6205930(name);
                this.xcd19cf011e804591();
                this.xcd19cf011e804591();
                this.Writeln(v);
                goto Label_0030;
            }
        Label_000D:
            this.x6210059f049f0d48(Encode(name));
            this.x6210059f049f0d48("=");
            this.x6210059f049f0d48(Encode(v));
        Label_0030:
            this._x62584df2cb5d40dd = false;
            if (0 == 0)
            {
                return;
            }
            goto Label_000D;
        }

        public void AddFile(string name, string file)
        {
            this.AddFile(name, file, "application/octet-stream");
        }

        public void AddFile(string name, string file, string type)
        {
            byte[] buffer;
            int num;
            Stream stream;
            if (this._x362993ef901691f7 == null)
            {
                return;
            }
            if ((((uint) num) + ((uint) num)) <= uint.MaxValue)
            {
                goto Label_010B;
            }
        Label_0026:
            this._x109f7b16542c1f2e.Write(buffer, 0, num);
        Label_0034:
            if ((num = stream.Read(buffer, 0, buffer.Length)) > 0)
            {
                goto Label_0026;
            }
            this._x109f7b16542c1f2e.Flush();
            this.xcd19cf011e804591();
            if ((((uint) num) - ((uint) num)) < 0)
            {
                goto Label_0098;
            }
            if (0xff != 0)
            {
                return;
            }
            if (0 == 0)
            {
                goto Label_010B;
            }
        Label_007D:
            stream = new FileStream(file, FileMode.Open);
            goto Label_0034;
        Label_0098:
            buffer = new byte[0x2000];
            this._xbdfb620b7167944b.Flush();
            this._x109f7b16542c1f2e.Flush();
            if ((0 == 0) && (0 == 0))
            {
                goto Label_007D;
            }
        Label_010B:
            this.x6da665da603c8be6();
            this.xa44748aef6205930(name);
            if (0 != 0)
            {
                goto Label_0034;
            }
            this.x6210059f049f0d48("; filename=\"");
            this.x6210059f049f0d48(file);
            this.x6210059f049f0d48("\"");
            this.xcd19cf011e804591();
            this.x6210059f049f0d48("Content-Type: ");
            this.Writeln(type);
            this.xcd19cf011e804591();
            goto Label_0098;
        }

        public void Complete()
        {
            if (this._x362993ef901691f7 != null)
            {
                this.x6da665da603c8be6();
                this.Writeln("--");
                this._x109f7b16542c1f2e.Flush();
            }
        }

        public static string Encode(string str)
        {
            return str;
        }

        public static string GetBoundary()
        {
            return ("---------------------------" + RandomString() + RandomString() + RandomString());
        }

        protected static string RandomString()
        {
            return (ThreadSafeRandom.NextDouble());
        }

        protected void Writeln(string str)
        {
            this.x6210059f049f0d48(str);
            this.xcd19cf011e804591();
        }

        private void x6210059f049f0d48(string xf6987a1745781d6f)
        {
            this._xbdfb620b7167944b.Write(xf6987a1745781d6f);
            this._xbdfb620b7167944b.Flush();
        }

        private void x6da665da603c8be6()
        {
            this.x6210059f049f0d48("--");
            this.x6210059f049f0d48(this._x362993ef901691f7);
        }

        private void xa44748aef6205930(string xc15bd84e01929885)
        {
            this.xcd19cf011e804591();
            this.x6210059f049f0d48("Content-Disposition: form-data; name=\"");
            this.x6210059f049f0d48(xc15bd84e01929885);
            this.x6210059f049f0d48("\"");
        }

        private void xcd19cf011e804591()
        {
            this.x6210059f049f0d48("\r\n");
        }
    }
}

