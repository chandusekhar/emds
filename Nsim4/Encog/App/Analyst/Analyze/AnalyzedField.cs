namespace Encog.App.Analyst.Analyze
{
    using Encog.App.Analyst.Script;
    using Encog.Util.CSV;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;

    public class AnalyzedField : DataField
    {
        private int _x0eba5dc834af0bac;
        private double _x1f828c67e123dec2;
        private readonly AnalystScript _x594135906c55045c;
        private readonly IDictionary<string, AnalystClassItem> _x785cd8b1f9494d74;
        private double _xb1c30745a1525188;

        public AnalyzedField(AnalystScript theScript, string name) : base(name)
        {
            this._x785cd8b1f9494d74 = new Dictionary<string, AnalystClassItem>();
            this._x0eba5dc834af0bac = 0;
            this._x594135906c55045c = theScript;
        }

        public void Analyze1(string v)
        {
            string str;
            double num;
            int num2;
            int propertyInt;
            bool flag = false;
            goto Label_033F;
        Label_0007:
            if (base.Class)
            {
                if (!this._x785cd8b1f9494d74.ContainsKey(str))
                {
                    AnalystClassItem item = new AnalystClassItem(str, str, 1);
                    this._x785cd8b1f9494d74[str] = item;
                    propertyInt = this._x594135906c55045c.Properties.GetPropertyInt("SETUP:CONFIG_maxClassCount");
                    if (this._x785cd8b1f9494d74.Count > propertyInt)
                    {
                        base.Class = false;
                        return;
                    }
                    if ((((uint) num2) + ((uint) propertyInt)) <= uint.MaxValue)
                    {
                        return;
                    }
                    goto Label_033F;
                }
            }
            else
            {
                return;
            }
            this._x785cd8b1f9494d74[str].IncreaseCount();
            return;
        Label_00BD:
            if (base.Integer)
            {
                goto Label_00CF;
            }
            goto Label_0007;
        Label_00CC:
            if (0 == 0)
            {
                goto Label_00BD;
            }
        Label_00CF:
            try
            {
                num2 = int.Parse(str);
                goto Label_00F0;
            Label_00DA:
                this._xb1c30745a1525188 += num2;
                goto Label_0007;
            Label_00EB:
                if (!flag)
                {
                    goto Label_00DA;
                }
                goto Label_0007;
            Label_00F0:
                base.Max = Math.Max((double) num2, base.Max);
                base.Min = Math.Min((double) num2, base.Min);
                goto Label_00EB;
            }
            catch (FormatException)
            {
                goto Label_014F;
            Label_0120:
                base.Min = 0.0;
                base.StandardDeviation = 0.0;
                goto Label_0007;
            Label_0140:
                if (!base.Real)
                {
                    goto Label_015C;
                }
                if (2 != 0)
                {
                    goto Label_0007;
                }
            Label_014F:
                base.Integer = false;
                if (0 == 0)
                {
                    goto Label_0140;
                }
                if (0 != 0)
                {
                    goto Label_0007;
                }
            Label_015C:
                base.Max = 0.0;
                if (((uint) flag) <= uint.MaxValue)
                {
                    goto Label_0120;
                }
            }
            goto Label_0007;
            if ((((uint) num) - ((uint) propertyInt)) >= 0)
            {
                goto Label_00CC;
            }
            if (0 == 0)
            {
                goto Label_01CB;
            }
            if (((uint) num2) <= uint.MaxValue)
            {
                if (((uint) flag) > uint.MaxValue)
                {
                    goto Label_00BD;
                }
                goto Label_031B;
            }
        Label_01B8:
            if (base.Real)
            {
                goto Label_021C;
            }
            goto Label_00CC;
        Label_01CB:
            if (str.Equals("?"))
            {
                goto Label_031B;
            }
            if ((((uint) num2) - ((uint) num2)) < 0)
            {
                goto Label_0346;
            }
            this._x0eba5dc834af0bac++;
            if ((((uint) flag) | uint.MaxValue) != 0)
            {
                goto Label_01B8;
            }
        Label_021C:
            try
            {
                num = CSVFormat.EgFormat.Parse(str);
                base.Max = Math.Max(num, base.Max);
                base.Min = Math.Min(num, base.Min);
                this._xb1c30745a1525188 += num;
                flag = true;
            }
            catch (FormatException)
            {
                if ((((uint) flag) | 2) != 0)
                {
                    goto Label_02AB;
                }
            Label_027A:
                base.StandardDeviation = 0.0;
            Label_0289:
                if ((((uint) num2) | 2) != 0)
                {
                    goto Label_00BD;
                }
            Label_02A1:
                if (!base.Integer)
                {
                    goto Label_02B4;
                }
                goto Label_00BD;
            Label_02AB:
                base.Real = false;
                goto Label_02A1;
            Label_02B4:
                base.Max = 0.0;
                base.Min = 0.0;
                if (((uint) num) > uint.MaxValue)
                {
                    goto Label_0289;
                }
                if ((((uint) flag) - ((uint) propertyInt)) >= 0)
                {
                    goto Label_027A;
                }
            }
            goto Label_00BD;
        Label_031B:
            base.Complete = false;
            return;
        Label_033F:
            str = v.Trim();
        Label_0346:
            if (str.Trim().Length == 0)
            {
                goto Label_031B;
            }
            goto Label_01CB;
        }

        public void Analyze2(string str)
        {
            double num;
            if (str.Trim().Length != 0)
            {
                if (!base.Real)
                {
                    goto Label_0054;
                }
                goto Label_0080;
            }
            if ((((uint) num) | 0x80000000) != 0)
            {
                return;
            }
            if (0 == 0)
            {
                return;
            }
        Label_0054:
            if (!base.Integer && ((((uint) num) & 0) == 0))
            {
                return;
            }
        Label_0080:
            if (!str.Equals(""))
            {
                if (!str.Equals("?"))
                {
                    num = CSVFormat.EgFormat.Parse(str);
                    this._x1f828c67e123dec2 += Math.Pow(num - base.Mean, 2.0);
                    if (0x7fffffff != 0)
                    {
                        if (0xff == 0)
                        {
                        }
                        return;
                    }
                    return;
                }
                if (((uint) num) >= 0)
                {
                    return;
                }
                goto Label_0054;
            }
            if ((-2147483648 != 0) && (0 != 0))
            {
            }
        }

        public void CompletePass1()
        {
            this._x1f828c67e123dec2 = 0.0;
            if (0xff != 0)
            {
                while (this._x0eba5dc834af0bac == 0)
                {
                    base.Mean = 0.0;
                    return;
                }
                if (-1 == 0)
                {
                    return;
                }
            }
            base.Mean = this._xb1c30745a1525188 / ((double) this._x0eba5dc834af0bac);
        }

        public void CompletePass2()
        {
            base.StandardDeviation = Math.Sqrt(this._x1f828c67e123dec2 / ((double) this._x0eba5dc834af0bac));
        }

        public DataField FinalizeField()
        {
            DataField field;
            IList<AnalystClassItem> analyzedClassMembers;
            DataField field2 = new DataField(base.Name) {
                Name = base.Name,
                Min = base.Min,
                Max = base.Max,
                Mean = base.Mean,
                StandardDeviation = base.StandardDeviation,
                Integer = base.Integer
            };
            if (0 == 0)
            {
                goto Label_0094;
            }
            goto Label_0068;
            if (0 != 0)
            {
                goto Label_0094;
            }
            if (0 == 0)
            {
                return field;
            }
        Label_0068:
            field2.Class = base.Class;
            field2.Complete = base.Complete;
            field = field2;
            field.ClassMembers.Clear();
            if (2 != 0)
            {
                if (!field.Class)
                {
                    return field;
                }
                analyzedClassMembers = this.AnalyzedClassMembers;
            }
            foreach (AnalystClassItem item in analyzedClassMembers)
            {
                field.ClassMembers.Add(item);
            }
            return field;
        Label_0094:
            field2.Real = base.Real;
            goto Label_0068;
        }

        public sealed override string ToString()
        {
            StringBuilder builder = new StringBuilder("[");
            while (true)
            {
                builder.Append(base.GetType().Name);
                builder.Append(" total=");
                do
                {
                    builder.Append(this._xb1c30745a1525188);
                }
                while (0 != 0);
                builder.Append(", instances=");
                builder.Append(this._x0eba5dc834af0bac);
                builder.Append("]");
                if (0 == 0)
                {
                    return builder.ToString();
                }
            }
        }

        [CompilerGenerated]
        private AnalystClassItem x2584ca35ae806c72(string xf6987a1745781d6f)
        {
            return this._x785cd8b1f9494d74[xf6987a1745781d6f];
        }

        public IList<AnalystClassItem> AnalyzedClassMembers
        {
            get
            {
                List<string> source = this._x785cd8b1f9494d74.Keys.ToList<string>();
                source.Sort();
                return source.Select<string, AnalystClassItem>(new Func<string, AnalystClassItem>(this.x2584ca35ae806c72)).ToList<AnalystClassItem>();
            }
        }
    }
}

