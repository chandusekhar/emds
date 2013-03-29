namespace Encog.App.Analyst.Script.Normalize
{
    using Encog.App.Analyst;
    using Encog.App.Analyst.CSV.Basic;
    using Encog.App.Analyst.Script;
    using Encog.App.Analyst.Util;
    using Encog.App.Quant;
    using Encog.MathUtil;
    using Encog.Util;
    using Encog.Util.Arrayutil;
    using Encog.Util.CSV;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class AnalystField
    {
        private double _x136bfff0efb12047;
        private double _x4a1b740f8a477de7;
        private double _x891507b50bbab0f9;
        private Equilateral _x8959a01885d5f522;
        private readonly IList<ClassItem> _x8affa5274961ba3a;
        private double _x945de103a2446d98;
        private bool _x9c13656d94fc62d0;
        private NormalizationAction _xab8fe3cd8c5556fb;
        private int _xb28caf42bc38fd60;
        private readonly IDictionary<string, int> _xba38fdafb6633fdf;
        private string _xc15bd84e01929885;
        public const int MinEqClasses = 3;

        public AnalystField() : this((double) 1.0, (double) -1.0)
        {
        }

        public AnalystField(AnalystField field)
        {
            if (8 != 0)
            {
                if (0 == 0)
                {
                    this._x8affa5274961ba3a = new List<ClassItem>();
                    this._xba38fdafb6633fdf = new Dictionary<string, int>();
                    this._x945de103a2446d98 = field._x945de103a2446d98;
                    this._x4a1b740f8a477de7 = field._x4a1b740f8a477de7;
                }
                else
                {
                    goto Label_0093;
                }
            }
            this._x891507b50bbab0f9 = field._x891507b50bbab0f9;
            this._x136bfff0efb12047 = field._x136bfff0efb12047;
            this._xab8fe3cd8c5556fb = field._xab8fe3cd8c5556fb;
        Label_0093:
            if (0xff != 0)
            {
                this._xc15bd84e01929885 = field._xc15bd84e01929885;
                this._x9c13656d94fc62d0 = field._x9c13656d94fc62d0;
                this._xb28caf42bc38fd60 = field._xb28caf42bc38fd60;
            }
        }

        public AnalystField(NormalizationAction theAction, string theName) : this(theAction, theName, 0.0, 0.0, 0.0, 0.0)
        {
        }

        public AnalystField(double theNormalizedHigh, double theNormalizedLow)
        {
            this._x8affa5274961ba3a = new List<ClassItem>();
            this._xba38fdafb6633fdf = new Dictionary<string, int>();
            this._x891507b50bbab0f9 = theNormalizedHigh;
            this._x136bfff0efb12047 = theNormalizedLow;
            if ((((uint) theNormalizedLow) & 0) == 0)
            {
            }
            this._x945de103a2446d98 = double.MinValue;
            this._x4a1b740f8a477de7 = double.MaxValue;
            this._xab8fe3cd8c5556fb = NormalizationAction.Normalize;
        }

        public AnalystField(string theName, NormalizationAction theAction, double high, double low)
        {
            if (0 == 0)
            {
                this._x8affa5274961ba3a = new List<ClassItem>();
                this._xba38fdafb6633fdf = new Dictionary<string, int>();
                if ((((uint) high) - ((uint) low)) < 0)
                {
                    goto Label_0010;
                }
            }
            this._xc15bd84e01929885 = theName;
        Label_0010:
            this._xab8fe3cd8c5556fb = theAction;
            this._x891507b50bbab0f9 = high;
            this._x136bfff0efb12047 = low;
        }

        public AnalystField(NormalizationAction theAction, string theName, double ahigh, double alow, double nhigh, double nlow)
        {
            while (true)
            {
                this._x8affa5274961ba3a = new List<ClassItem>();
                this._xba38fdafb6633fdf = new Dictionary<string, int>();
                this._xab8fe3cd8c5556fb = theAction;
                this._x945de103a2446d98 = ahigh;
                this._x4a1b740f8a477de7 = alow;
                this._x891507b50bbab0f9 = nhigh;
                if ((((uint) nlow) + ((uint) ahigh)) <= uint.MaxValue)
                {
                    this._x136bfff0efb12047 = nlow;
                    this._xc15bd84e01929885 = theName;
                    if (((uint) nhigh) <= uint.MaxValue)
                    {
                        return;
                    }
                }
            }
        }

        public void AddRawHeadings(StringBuilder line, string prefix, CSVFormat format)
        {
            int num2;
            string str;
            int columnsNeeded = this.ColumnsNeeded;
            if ((((uint) num2) & 0) != 0)
            {
                goto Label_002B;
            }
            num2 = 0;
        Label_000C:
            if (num2 < columnsNeeded)
            {
                str = CSVHeaders.TagColumn(this._xc15bd84e01929885, num2, this._xb28caf42bc38fd60, columnsNeeded > 1);
                BasicFile.AppendSeparator(line, format);
                line.Append('"');
                goto Label_002B;
            }
            return;
        Label_0012:
            line.Append(str);
            line.Append('"');
            num2++;
            goto Label_000C;
        Label_002B:
            if (prefix != null)
            {
                line.Append(prefix);
            }
            else
            {
                goto Label_0012;
            }
            if (0 != 0)
            {
                goto Label_002B;
            }
            if ((((uint) num2) & 0) == 0)
            {
                goto Label_0012;
            }
            goto Label_000C;
        }

        public void Analyze(double d)
        {
            this._x945de103a2446d98 = Math.Max(this._x945de103a2446d98, d);
            this._x4a1b740f8a477de7 = Math.Min(this._x4a1b740f8a477de7, d);
        }

        public double DeNormalize(double v)
        {
            return (((((this._x4a1b740f8a477de7 - this._x945de103a2446d98) * v) - (this._x891507b50bbab0f9 * this._x4a1b740f8a477de7)) + (this._x945de103a2446d98 * this._x136bfff0efb12047)) / (this._x136bfff0efb12047 - this._x891507b50bbab0f9));
        }

        public ClassItem DetermineClass(double[] data)
        {
            int num = 0;
            if (0 == 0)
            {
                switch (this._xab8fe3cd8c5556fb)
                {
                    case NormalizationAction.OneOf:
                        break;

                    case NormalizationAction.Equilateral:
                        num = this._x8959a01885d5f522.Decode(data);
                        goto Label_0062;

                    case NormalizationAction.SingleField:
                        num = (int) data[0];
                        goto Label_0062;

                    default:
                        throw new AnalystError("Unknown action: " + this._xab8fe3cd8c5556fb);
                }
            }
            num = EngineArray.IndexOfLargest(data);
        Label_0062:
            return this._x8affa5274961ba3a[num];
        }

        public ClassItem DetermineClass(int pos, double[] data)
        {
            double[] numArray;
            int num = 0;
        Label_0068:
            numArray = new double[this.ColumnsNeeded];
            EngineArray.ArrayCopy(data, pos, numArray, 0, numArray.Length);
            switch (this._xab8fe3cd8c5556fb)
            {
                case NormalizationAction.OneOf:
                    num = EngineArray.IndexOfLargest(numArray);
                    if ((((uint) num) - ((uint) num)) <= uint.MaxValue)
                    {
                        goto Label_0028;
                    }
                    goto Label_0068;

                case NormalizationAction.Equilateral:
                    num = this._x8959a01885d5f522.Decode(numArray);
                    goto Label_001F;

                case NormalizationAction.SingleField:
                    num = (int) numArray[0];
                    goto Label_001F;

                default:
                    if (4 != 0)
                    {
                        break;
                    }
                    goto Label_0028;
            }
        Label_0004:
            throw new AnalystError("Invalid action: " + this._xab8fe3cd8c5556fb);
        Label_001F:
            if (num >= 0)
            {
                return this._x8affa5274961ba3a[num];
            }
            return null;
        Label_0028:
            if (-2 == 0)
            {
                goto Label_0004;
            }
            goto Label_001F;
        }

        public int DetermineMode(EncogAnalyst analyst)
        {
            if (!this.Classify)
            {
                throw new AnalystError("Can only calculate the mode for a class.");
            }
            DataField field = analyst.Script.FindDataField(this.Name);
            AnalystClassItem item = null;
            int num = 0;
            int num2 = 0;
            using (IEnumerator<AnalystClassItem> enumerator = field.ClassMembers.GetEnumerator())
            {
                AnalystClassItem current;
                goto Label_004C;
            Label_0039:
                if (item.Count < current.Count)
                {
                    goto Label_0075;
                }
            Label_0048:
                num2++;
            Label_004C:
                if (!enumerator.MoveNext() && (((uint) num2) >= 0))
                {
                    return num;
                }
                current = enumerator.Current;
                if (item != null)
                {
                    goto Label_0039;
                }
            Label_0075:
                item = current;
                if ((((uint) num) - ((uint) num2)) < 0)
                {
                    goto Label_0039;
                }
                num = num2;
                goto Label_0048;
            }
        }

        public double[] Encode(int classNumber)
        {
            switch (this._xab8fe3cd8c5556fb)
            {
                case NormalizationAction.OneOf:
                    return this.xd8118cff55f2b045(classNumber);

                case NormalizationAction.Equilateral:
                    return this.EncodeEquilateral(classNumber);

                case NormalizationAction.SingleField:
                    return this.xc349230af2175aed(classNumber);
            }
            return null;
        }

        public double[] Encode(string str)
        {
            int classNumber = this.Lookup(str);
            while (classNumber == -1)
            {
                try
                {
                    classNumber = int.Parse(str);
                }
                catch (FormatException)
                {
                    throw new QuantError("Can't determine class for: " + str);
                }
                break;
            }
            return this.Encode(classNumber);
        }

        public double[] EncodeEquilateral(int classNumber)
        {
            return this._x8959a01885d5f522.Encode(classNumber);
        }

        public void FixSingleValue()
        {
            if ((this._xab8fe3cd8c5556fb == NormalizationAction.Normalize) && (Math.Abs((double) (this._x945de103a2446d98 - this._x4a1b740f8a477de7)) < 1E-07))
            {
                this._x945de103a2446d98++;
                this._x4a1b740f8a477de7--;
            }
        }

        public void Init()
        {
            int num;
            if (this._xab8fe3cd8c5556fb == NormalizationAction.Equilateral)
            {
                goto Label_0063;
            }
        Label_000E:
            num = 0;
            while (num < this._x8affa5274961ba3a.Count)
            {
                this._xba38fdafb6633fdf[this._x8affa5274961ba3a[num].Name] = this._x8affa5274961ba3a[num].Index;
                num++;
            }
            if (((uint) num) >= 0)
            {
                return;
            }
        Label_0063:
            if (this._x8affa5274961ba3a.Count < 3)
            {
                throw new QuantError("There must be at least three classes to make use of equilateral normalization.");
            }
            do
            {
                this._x8959a01885d5f522 = new Equilateral(this._x8affa5274961ba3a.Count, this._x891507b50bbab0f9, this._x136bfff0efb12047);
            }
            while (0 != 0);
            goto Label_000E;
        }

        public int Lookup(string str)
        {
            if (!this._xba38fdafb6633fdf.ContainsKey(str))
            {
                return -1;
            }
            return this._xba38fdafb6633fdf[str];
        }

        public void MakeClass(NormalizationAction theAction, string[] cls, double high, double low)
        {
            int num;
            if (this._xab8fe3cd8c5556fb == NormalizationAction.Equilateral)
            {
                goto Label_00A7;
            }
            if (this._xab8fe3cd8c5556fb != NormalizationAction.OneOf)
            {
                if (this._xab8fe3cd8c5556fb != NormalizationAction.SingleField)
                {
                    throw new QuantError("Unsupported normalization type");
                }
                goto Label_00A7;
            }
            if (((uint) high) <= uint.MaxValue)
            {
                goto Label_00A7;
            }
        Label_003C:
            while (num < cls.Length)
            {
                this._x8affa5274961ba3a.Add(new ClassItem(cls[num], num));
                num++;
            }
            return;
        Label_00A7:
            this._xab8fe3cd8c5556fb = theAction;
            this._x8affa5274961ba3a.Clear();
            if ((((uint) low) | 0xff) == 0)
            {
                goto Label_00A7;
            }
            this._x891507b50bbab0f9 = high;
            this._x136bfff0efb12047 = low;
            this._x945de103a2446d98 = 0.0;
            this._x4a1b740f8a477de7 = 0.0;
            num = 0;
            goto Label_003C;
        }

        public void MakeClass(NormalizationAction theAction, int classFrom, int classTo, int high, int low)
        {
            if (this._xab8fe3cd8c5556fb != NormalizationAction.Equilateral)
            {
                goto Label_00FB;
            }
        Label_006C:
            this._xab8fe3cd8c5556fb = theAction;
            this._x8affa5274961ba3a.Clear();
            this._x891507b50bbab0f9 = high;
            this._x136bfff0efb12047 = low;
        Label_0090:
            this._x945de103a2446d98 = 0.0;
            this._x4a1b740f8a477de7 = 0.0;
            int num = 0;
            int num2 = classFrom;
            while (true)
            {
                if (num2 < classTo)
                {
                    this._x8affa5274961ba3a.Add(new ClassItem(num2, num++));
                }
                else
                {
                    if ((((uint) num2) & 0) == 0)
                    {
                        return;
                    }
                    break;
                }
                if ((((uint) high) - ((uint) classTo)) >= 0)
                {
                }
                num2++;
                if ((((uint) low) & 0) != 0)
                {
                    goto Label_0090;
                }
            }
        Label_00FB:
            if ((this._xab8fe3cd8c5556fb == NormalizationAction.OneOf) && ((((uint) num) + ((uint) classFrom)) >= 0))
            {
                goto Label_006C;
            }
            if (this._xab8fe3cd8c5556fb != NormalizationAction.SingleField)
            {
                throw new QuantError("Unsupported normalization type");
            }
            if (((uint) high) <= uint.MaxValue)
            {
                if ((((uint) classTo) + ((uint) classFrom)) <= uint.MaxValue)
                {
                    goto Label_006C;
                }
            }
            else
            {
                goto Label_00FB;
            }
        }

        public void MakePassThrough()
        {
            this._x891507b50bbab0f9 = 0.0;
            this._x136bfff0efb12047 = 0.0;
            this._x945de103a2446d98 = 0.0;
            this._x4a1b740f8a477de7 = 0.0;
            this._xab8fe3cd8c5556fb = NormalizationAction.PassThrough;
        }

        public double Normalize(double v)
        {
            return ((((v - this._x4a1b740f8a477de7) / (this._x945de103a2446d98 - this._x4a1b740f8a477de7)) * (this._x891507b50bbab0f9 - this._x136bfff0efb12047)) + this._x136bfff0efb12047);
        }

        public sealed override string ToString()
        {
            StringBuilder builder = new StringBuilder("[");
            if (0 == 0)
            {
                builder.Append(base.GetType().Name);
                if (0 != 0)
                {
                    goto Label_0042;
                }
                builder.Append(" name=");
                if (0 == 0)
                {
                    builder.Append(this._xc15bd84e01929885);
                    builder.Append(", actualHigh=");
                    builder.Append(this._x945de103a2446d98);
                    goto Label_0042;
                }
            }
        Label_000E:
            builder.Append("]");
            return builder.ToString();
        Label_0042:
            builder.Append(", actualLow=");
            builder.Append(this._x4a1b740f8a477de7);
            goto Label_000E;
        }

        private double[] xc349230af2175aed(int xc918b42ddeb8ab4f)
        {
            return new double[] { ((double) xc918b42ddeb8ab4f) };
        }

        private double[] xd8118cff55f2b045(int xc918b42ddeb8ab4f)
        {
            int num;
            double[] numArray = new double[this.ColumnsNeeded];
            if ((((uint) num) - ((uint) xc918b42ddeb8ab4f)) <= uint.MaxValue)
            {
                goto Label_0087;
            }
            if ((((uint) xc918b42ddeb8ab4f) + ((uint) num)) >= 0)
            {
                goto Label_0071;
            }
        Label_003C:
            numArray[num] = this._x136bfff0efb12047;
        Label_0045:
            num++;
        Label_0049:
            if (num >= this._x8affa5274961ba3a.Count)
            {
                if ((((uint) num) + ((uint) num)) > uint.MaxValue)
                {
                    goto Label_0049;
                }
                if (-2 != 0)
                {
                    return numArray;
                }
                goto Label_0087;
            }
        Label_0071:
            if (num != xc918b42ddeb8ab4f)
            {
                goto Label_003C;
            }
            numArray[num] = this._x891507b50bbab0f9;
            goto Label_0045;
        Label_0087:
            num = 0;
            goto Label_0049;
        }

        public NormalizationAction Action
        {
            get
            {
                return this._xab8fe3cd8c5556fb;
            }
            set
            {
                this._xab8fe3cd8c5556fb = value;
            }
        }

        public double ActualHigh
        {
            get
            {
                return this._x945de103a2446d98;
            }
            set
            {
                this._x945de103a2446d98 = value;
            }
        }

        public double ActualLow
        {
            get
            {
                return this._x4a1b740f8a477de7;
            }
            set
            {
                this._x4a1b740f8a477de7 = value;
            }
        }

        public IList<ClassItem> Classes
        {
            get
            {
                return this._x8affa5274961ba3a;
            }
        }

        public bool Classify
        {
            get
            {
                if ((this._xab8fe3cd8c5556fb != NormalizationAction.Equilateral) && (this._xab8fe3cd8c5556fb != NormalizationAction.OneOf))
                {
                    return (this._xab8fe3cd8c5556fb == NormalizationAction.SingleField);
                }
                return true;
            }
        }

        public int ColumnsNeeded
        {
            get
            {
                switch (this._xab8fe3cd8c5556fb)
                {
                    case NormalizationAction.Ignore:
                        return 0;

                    case NormalizationAction.OneOf:
                        return this._x8affa5274961ba3a.Count;

                    case NormalizationAction.Equilateral:
                        return (this._x8affa5274961ba3a.Count - 1);
                }
                if (2 != 0)
                {
                }
                return 1;
            }
        }

        public Equilateral Eq
        {
            get
            {
                return this._x8959a01885d5f522;
            }
        }

        public bool Ignored
        {
            get
            {
                return (this._xab8fe3cd8c5556fb == NormalizationAction.Ignore);
            }
        }

        public bool Input
        {
            get
            {
                return !this._x9c13656d94fc62d0;
            }
        }

        public string Name
        {
            get
            {
                return this._xc15bd84e01929885;
            }
            set
            {
                this._xc15bd84e01929885 = value;
            }
        }

        public double NormalizedHigh
        {
            get
            {
                return this._x891507b50bbab0f9;
            }
            set
            {
                this._x891507b50bbab0f9 = value;
            }
        }

        public double NormalizedLow
        {
            get
            {
                return this._x136bfff0efb12047;
            }
            set
            {
                this._x136bfff0efb12047 = value;
            }
        }

        public bool Output
        {
            get
            {
                return this._x9c13656d94fc62d0;
            }
            set
            {
                this._x9c13656d94fc62d0 = value;
            }
        }

        public int TimeSlice
        {
            get
            {
                return this._xb28caf42bc38fd60;
            }
            set
            {
                this._xb28caf42bc38fd60 = value;
            }
        }
    }
}

