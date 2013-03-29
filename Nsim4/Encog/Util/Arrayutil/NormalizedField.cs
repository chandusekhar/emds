namespace Encog.Util.Arrayutil
{
    using Encog.App.Analyst.CSV.Basic;
    using Encog.App.Quant;
    using Encog.MathUtil;
    using Encog.Util;
    using Encog.Util.CSV;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class NormalizedField
    {
        private double _x136bfff0efb12047;
        private double _x4a1b740f8a477de7;
        private double _x891507b50bbab0f9;
        private Equilateral _x8959a01885d5f522;
        private readonly IList<ClassItem> _x8affa5274961ba3a;
        private double _x945de103a2446d98;
        private NormalizationAction _xab8fe3cd8c5556fb;
        private readonly IDictionary<string, int> _xba38fdafb6633fdf;
        private string _xc15bd84e01929885;

        public NormalizedField() : this((double) 1.0, (double) -1.0)
        {
        }

        public NormalizedField(NormalizationAction theAction, string theName) : this(theAction, theName, 0.0, 0.0, 0.0, 0.0)
        {
        }

        public NormalizedField(double theNormalizedHigh, double theNormalizedLow)
        {
            this._x8affa5274961ba3a = new List<ClassItem>();
            while (true)
            {
                this._xba38fdafb6633fdf = new Dictionary<string, int>();
                this._x891507b50bbab0f9 = theNormalizedHigh;
                this._x136bfff0efb12047 = theNormalizedLow;
                if ((((uint) theNormalizedLow) + ((uint) theNormalizedHigh)) >= 0)
                {
                    this._x945de103a2446d98 = double.MinValue;
                    this._x4a1b740f8a477de7 = double.MaxValue;
                    this._xab8fe3cd8c5556fb = NormalizationAction.Normalize;
                    return;
                }
            }
        }

        public NormalizedField(string theName, NormalizationAction theAction, double high, double low)
        {
            this._x8affa5274961ba3a = new List<ClassItem>();
            if (1 != 0)
            {
                this._xba38fdafb6633fdf = new Dictionary<string, int>();
                this._xc15bd84e01929885 = theName;
            }
            this._xab8fe3cd8c5556fb = theAction;
            this._x891507b50bbab0f9 = high;
            this._x136bfff0efb12047 = low;
        }

        public NormalizedField(NormalizationAction theAction, string theName, double ahigh, double alow, double nhigh, double nlow)
        {
            if ((((uint) ahigh) | 2) != 0)
            {
                this._x8affa5274961ba3a = new List<ClassItem>();
                this._xba38fdafb6633fdf = new Dictionary<string, int>();
                if (0 == 0)
                {
                }
                this._xab8fe3cd8c5556fb = theAction;
                this._x945de103a2446d98 = ahigh;
                this._x4a1b740f8a477de7 = alow;
                this._x891507b50bbab0f9 = nhigh;
                this._x136bfff0efb12047 = nlow;
            }
            this._xc15bd84e01929885 = theName;
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
            int num;
            switch (this._xab8fe3cd8c5556fb)
            {
                case NormalizationAction.OneOf:
                    num = EngineArray.IndexOfLargest(data);
                    break;

                case NormalizationAction.Equilateral:
                    num = this._x8959a01885d5f522.Decode(data);
                    break;

                case NormalizationAction.SingleField:
                    num = (int) data[0];
                    break;

                default:
                    throw new QuantError("Unknown action: " + this._xab8fe3cd8c5556fb);
            }
            return this._x8affa5274961ba3a[num];
        }

        public string EncodeHeaders()
        {
            int num;
            int num2;
            StringBuilder line = new StringBuilder();
            if ((((uint) num2) + ((uint) num2)) <= uint.MaxValue)
            {
                switch (this._xab8fe3cd8c5556fb)
                {
                    case NormalizationAction.OneOf:
                        goto Label_008A;

                    case NormalizationAction.Equilateral:
                        num = 0;
                        goto Label_00B3;

                    case NormalizationAction.SingleField:
                        BasicFile.AppendSeparator(line, CSVFormat.EgFormat);
                        line.Append('"');
                        line.Append(this._xc15bd84e01929885);
                        line.Append('"');
                        goto Label_0167;
                }
                return null;
            }
            goto Label_0070;
        Label_0029:
            if (num2 < this._x8affa5274961ba3a.Count)
            {
                BasicFile.AppendSeparator(line, CSVFormat.EgFormat);
            }
            else
            {
                goto Label_0167;
            }
        Label_0070:
            line.Append('"');
            line.Append(this._xc15bd84e01929885);
            line.Append('-');
            if (((uint) num) >= 0)
            {
                line.Append(num2);
                line.Append('"');
                num2++;
                if (0 != 0)
                {
                    goto Label_00AF;
                }
                goto Label_0029;
            }
            goto Label_0070;
        Label_008A:
            num2 = 0;
            goto Label_0029;
        Label_00AF:
            num++;
        Label_00B3:
            if (num >= (this._x8affa5274961ba3a.Count - 1))
            {
                if (0 != 0)
                {
                    goto Label_00F1;
                }
                goto Label_0167;
            }
            BasicFile.AppendSeparator(line, CSVFormat.EgFormat);
            if (((uint) num2) < 0)
            {
                goto Label_008A;
            }
            line.Append('"');
        Label_00F1:
            line.Append(this._xc15bd84e01929885);
            line.Append('-');
            line.Append(num);
            line.Append('"');
            goto Label_00AF;
        Label_0167:
            return line.ToString();
        }

        public string EncodeSingleField(int classNumber)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(classNumber);
            return builder.ToString();
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
            if (this._xab8fe3cd8c5556fb == NormalizationAction.Equilateral)
            {
                if (this._x8affa5274961ba3a.Count < 3)
                {
                    throw new QuantError("There must be at least three classes to make use of equilateral normalization.");
                }
                this._x8959a01885d5f522 = new Equilateral(this._x8affa5274961ba3a.Count, this._x891507b50bbab0f9, this._x136bfff0efb12047);
            }
            foreach (ClassItem item in this._x8affa5274961ba3a)
            {
                this._xba38fdafb6633fdf[item.Name] = item.Index;
            }
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
            if (theAction == NormalizationAction.Equilateral)
            {
                goto Label_00CA;
            }
        Label_00B7:
            if ((theAction != NormalizationAction.OneOf) && (theAction != NormalizationAction.SingleField))
            {
                throw new QuantError("Unsupported normalization type");
            }
        Label_00CA:
            this._xab8fe3cd8c5556fb = theAction;
            if ((((uint) num) - ((uint) high)) <= uint.MaxValue)
            {
                if ((((uint) high) - ((uint) high)) <= uint.MaxValue)
                {
                    this._x8affa5274961ba3a.Clear();
                    this._x891507b50bbab0f9 = high;
                }
                this._x136bfff0efb12047 = low;
                while (true)
                {
                    this._x945de103a2446d98 = 0.0;
                    this._x4a1b740f8a477de7 = 0.0;
                    num = 0;
                    while (num < cls.Length)
                    {
                        this._x8affa5274961ba3a.Insert(num, new ClassItem(cls[num], num));
                        num++;
                        if (0 != 0)
                        {
                            return;
                        }
                    }
                    if ((((uint) high) & 0) == 0)
                    {
                        return;
                    }
                }
            }
            goto Label_00B7;
        }

        public void MakeClass(NormalizationAction theAction, int classFrom, int classTo, int high, int low)
        {
            int num;
            int num2;
            if ((theAction == NormalizationAction.Equilateral) || ((theAction == NormalizationAction.OneOf) && ((((uint) num2) | 3) != 0)))
            {
                goto Label_0114;
            }
            goto Label_0110;
        Label_003E:
            this._x8affa5274961ba3a.Add(new ClassItem(num2, num++));
            if ((((uint) num2) | 3) == 0)
            {
                goto Label_003E;
            }
            if ((((uint) high) | 8) == 0)
            {
                goto Label_0110;
            }
            num2++;
        Label_0095:
            if (num2 < classTo)
            {
                goto Label_003E;
            }
            if (0 == 0)
            {
                if (((uint) num) > uint.MaxValue)
                {
                    goto Label_00AB;
                }
                if ((((uint) classFrom) | 4) != 0)
                {
                    return;
                }
            }
        Label_00A2:
            this._x891507b50bbab0f9 = high;
        Label_00AB:
            this._x136bfff0efb12047 = low;
            this._x945de103a2446d98 = 0.0;
            this._x4a1b740f8a477de7 = 0.0;
            num = 0;
            if ((((uint) high) - ((uint) classTo)) >= 0)
            {
                num2 = classFrom;
                goto Label_0095;
            }
            goto Label_003E;
        Label_0110:
            if (theAction != NormalizationAction.SingleField)
            {
                throw new QuantError("Unsupported normalization type");
            }
        Label_0114:
            this._xab8fe3cd8c5556fb = theAction;
            this._x8affa5274961ba3a.Clear();
            goto Label_00A2;
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
                builder.Append(" name=");
                if (4 == 0)
                {
                    goto Label_0027;
                }
                builder.Append(this._xc15bd84e01929885);
                builder.Append(", actualHigh=");
                builder.Append(this._x945de103a2446d98);
            }
            builder.Append(", actualLow=");
            builder.Append(this._x4a1b740f8a477de7);
        Label_0027:
            builder.Append("]");
            return builder.ToString();
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
                if (this._xab8fe3cd8c5556fb != NormalizationAction.Equilateral)
                {
                    while (this._xab8fe3cd8c5556fb != NormalizationAction.OneOf)
                    {
                        return (this._xab8fe3cd8c5556fb == NormalizationAction.SingleField);
                    }
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
    }
}

