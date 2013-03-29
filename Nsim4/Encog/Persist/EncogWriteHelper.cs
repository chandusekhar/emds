namespace Encog.Persist
{
    using Encog.Engine.Network.Activation;
    using Encog.MathUtil.Matrices;
    using Encog.Util.CSV;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class EncogWriteHelper
    {
        public const char COMMA = ',';
        public const char QUOTE = '"';
        private string x28e62b99939820e7;
        private readonly StringBuilder x311e7a92306d7199 = new StringBuilder();
        private readonly StreamWriter xa58d1d9c6fa55c59;

        public EncogWriteHelper(Stream stream)
        {
            this.xa58d1d9c6fa55c59 = new StreamWriter(stream);
        }

        public void AddColumn(bool b)
        {
            if (this.x311e7a92306d7199.Length > 0)
            {
                this.x311e7a92306d7199.Append(',');
            }
            this.x311e7a92306d7199.Append(b ? 1 : 0);
        }

        public void AddColumn(double d)
        {
            if (this.x311e7a92306d7199.Length > 0)
            {
                this.x311e7a92306d7199.Append(',');
            }
            this.x311e7a92306d7199.Append(CSVFormat.English.Format(d, 10));
        }

        public void AddColumn(int i)
        {
            if (this.x311e7a92306d7199.Length > 0)
            {
                this.x311e7a92306d7199.Append(',');
            }
            this.x311e7a92306d7199.Append(i);
        }

        public void AddColumn(long v)
        {
            if (this.x311e7a92306d7199.Length > 0)
            {
                this.x311e7a92306d7199.Append(',');
            }
            this.x311e7a92306d7199.Append(v);
        }

        public void AddColumn(string str)
        {
            if (this.x311e7a92306d7199.Length > 0)
            {
                this.x311e7a92306d7199.Append(',');
            }
            this.x311e7a92306d7199.Append('"');
            this.x311e7a92306d7199.Append(str);
            this.x311e7a92306d7199.Append('"');
        }

        public void AddColumns(IList<string> cols)
        {
            foreach (string str in cols)
            {
                this.AddColumn(str);
            }
        }

        public void AddLine(string l)
        {
            if (this.x311e7a92306d7199.Length > 0)
            {
                this.WriteLine();
            }
            this.xa58d1d9c6fa55c59.WriteLine(l);
        }

        public void AddProperties(IDictionary<string, string> properties)
        {
            foreach (string str in properties.Keys)
            {
                string str2 = properties[str];
                this.WriteProperty(str, str2);
            }
        }

        public void AddSection(string str)
        {
            this.x28e62b99939820e7 = str;
            this.xa58d1d9c6fa55c59.WriteLine("[" + str + "]");
        }

        public void AddSubSection(string str)
        {
            this.xa58d1d9c6fa55c59.WriteLine("[" + this.x28e62b99939820e7 + ":" + str + "]");
        }

        public void Flush()
        {
            this.xa58d1d9c6fa55c59.Flush();
        }

        public void Write(string str)
        {
            this.xa58d1d9c6fa55c59.Write(str);
        }

        public void WriteLine()
        {
            this.xa58d1d9c6fa55c59.WriteLine(this.x311e7a92306d7199.ToString());
            this.x311e7a92306d7199.Length = 0;
        }

        public void WriteProperty(string name, IActivationFunction act)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(act.GetType().Name);
            int index = 0;
            goto Label_0030;
        Label_0011:
            builder.Append(CSVFormat.EgFormat.Format(act.Params[index], 10));
            index++;
        Label_0030:
            if (index < act.Params.Length)
            {
                builder.Append('|');
                goto Label_0011;
            }
            if ((((uint) index) | 3) == 0)
            {
                goto Label_0011;
            }
            this.WriteProperty(name, builder.ToString());
        }

        public void WriteProperty(string name, Matrix matrix)
        {
            int num2;
            StringBuilder builder = new StringBuilder();
            builder.Append(matrix.Rows);
        Label_00A1:
            builder.Append(',');
            builder.Append(matrix.Cols);
            int num = 0;
        Label_001C:
            if (num < matrix.Rows)
            {
                num2 = 0;
                if ((((uint) num) + ((uint) num)) > uint.MaxValue)
                {
                    goto Label_00A1;
                }
            }
            else
            {
                this.WriteProperty(name, builder.ToString());
                if (0 == 0)
                {
                    return;
                }
            }
            while (num2 < matrix.Cols)
            {
                builder.Append(',');
                builder.Append(CSVFormat.EgFormat.Format(matrix[num, num2], 10));
                if ((((uint) num) + ((uint) num)) < 0)
                {
                    goto Label_001C;
                }
                num2++;
            }
            num++;
            goto Label_001C;
        }

        public void WriteProperty(string name, CSVFormat csvFormat)
        {
            string str;
            if (((csvFormat != CSVFormat.English) && ((0 != 0) || (csvFormat != CSVFormat.English))) && (csvFormat != CSVFormat.DecimalPoint))
            {
                if (csvFormat == CSVFormat.DecimalComma)
                {
                    str = "deccomma";
                }
                else
                {
                    str = "decpnt";
                }
            }
            else
            {
                goto Label_0040;
            }
        Label_0010:
            this.xa58d1d9c6fa55c59.WriteLine(name + "=" + str);
            if (0 == 0)
            {
                return;
            }
        Label_0040:
            str = "decpnt";
            goto Label_0010;
        }

        public void WriteProperty(string name, bool value_ren)
        {
            this.xa58d1d9c6fa55c59.WriteLine(name + "=" + (value_ren ? 't' : 'f'));
        }

        public void WriteProperty(string name, double value_ren)
        {
            this.xa58d1d9c6fa55c59.WriteLine(name + "=" + CSVFormat.EgFormat.Format(value_ren, 10));
        }

        public void WriteProperty(string name, double[] d)
        {
            StringBuilder result = new StringBuilder();
            NumberList.ToList(CSVFormat.EgFormat, result, d);
            this.WriteProperty(name, result.ToString());
        }

        public void WriteProperty(string name, int value_ren)
        {
            this.xa58d1d9c6fa55c59.WriteLine(name + "=" + value_ren);
        }

        public void WriteProperty(string name, int[] array)
        {
            StringBuilder result = new StringBuilder();
            NumberList.ToListInt(CSVFormat.EgFormat, result, array);
            this.WriteProperty(name, result.ToString());
        }

        public void WriteProperty(string name, long v)
        {
            this.xa58d1d9c6fa55c59.WriteLine(name + "=" + v);
        }

        public void WriteProperty(string name, string value_ren)
        {
            this.xa58d1d9c6fa55c59.WriteLine(name + "=" + value_ren);
        }

        public string CurrentSection
        {
            get
            {
                return this.x28e62b99939820e7;
            }
        }
    }
}

