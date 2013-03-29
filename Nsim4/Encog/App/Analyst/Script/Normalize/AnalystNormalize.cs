namespace Encog.App.Analyst.Script.Normalize
{
    using Encog.App.Analyst;
    using Encog.App.Analyst.Missing;
    using Encog.App.Analyst.Script;
    using Encog.Util.Arrayutil;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;

    public class AnalystNormalize
    {
        private readonly AnalystScript _x594135906c55045c;
        private readonly IList<AnalystField> _xcb632f1b59a7f901 = new List<AnalystField>();
        [CompilerGenerated]
        private static Func<AnalystField, int> x1ecac4c96d3f3733;
        [CompilerGenerated]
        private static Func<AnalystField, int> x52e0eb7265061ab4;
        [CompilerGenerated]
        private static Func<AnalystField, bool> xca5ad8524f73e51f;
        [CompilerGenerated]
        private static Func<AnalystField, bool> xcb5110745db8648f;

        public AnalystNormalize(AnalystScript script)
        {
            this._x594135906c55045c = script;
        }

        public int CalculateInputColumns()
        {
            if (xcb5110745db8648f == null)
            {
                xcb5110745db8648f = new Func<AnalystField, bool>(AnalystNormalize.x3e64998256ab1982);
            }
            if (x1ecac4c96d3f3733 == null)
            {
                x1ecac4c96d3f3733 = new Func<AnalystField, int>(AnalystNormalize.x6336b641dc5ba406);
            }
            return this._xcb632f1b59a7f901.Where<AnalystField>(xcb5110745db8648f).Sum<AnalystField>(x1ecac4c96d3f3733);
        }

        public int CalculateOutputColumns()
        {
            if (xca5ad8524f73e51f == null)
            {
                xca5ad8524f73e51f = new Func<AnalystField, bool>(AnalystNormalize.x8b977eb5800872ff);
            }
            if (x52e0eb7265061ab4 == null)
            {
                x52e0eb7265061ab4 = new Func<AnalystField, int>(AnalystNormalize.x4a01373bb5d8ba23);
            }
            return this._xcb632f1b59a7f901.Where<AnalystField>(xca5ad8524f73e51f).Sum<AnalystField>(x52e0eb7265061ab4);
        }

        public int CountActiveFields()
        {
            int num = 0;
            using (IEnumerator<AnalystField> enumerator = this._xcb632f1b59a7f901.GetEnumerator())
            {
                AnalystField current;
                goto Label_0019;
            Label_0010:
                if (current.Action != NormalizationAction.Ignore)
                {
                    goto Label_002D;
                }
            Label_0019:
                if (!enumerator.MoveNext())
                {
                    return num;
                }
                current = enumerator.Current;
                if (0 == 0)
                {
                    goto Label_0010;
                }
            Label_002D:
                num++;
                goto Label_0019;
            }
        }

        public void Init(AnalystScript script)
        {
            if (this._xcb632f1b59a7f901 != null)
            {
                using (IEnumerator<AnalystField> enumerator = this._xcb632f1b59a7f901.GetEnumerator())
                {
                    AnalystField field;
                    DataField field2;
                    int num;
                Label_0018:
                    if (enumerator.MoveNext())
                    {
                        goto Label_0177;
                    }
                    goto Label_00BE;
                Label_0029:
                    if (((uint) num) > uint.MaxValue)
                    {
                        goto Label_009D;
                    }
                Label_003B:
                    num = 0;
                    foreach (AnalystClassItem item in field2.ClassMembers)
                    {
                        field.Classes.Add(new ClassItem(item.Name, num++));
                    }
                    goto Label_0018;
                Label_008B:
                    if (field.Action == NormalizationAction.SingleField)
                    {
                        goto Label_0029;
                    }
                    if (3 == 0)
                    {
                        goto Label_003B;
                    }
                    goto Label_0018;
                Label_009D:
                    if (field.Action == NormalizationAction.Equilateral)
                    {
                        goto Label_003B;
                    }
                Label_00AB:
                    if (field.Action != NormalizationAction.OneOf)
                    {
                        goto Label_008B;
                    }
                    goto Label_003B;
                Label_00BE:
                    if (((uint) num) <= uint.MaxValue)
                    {
                        return;
                    }
                    if ((((uint) num) | 2) != 0)
                    {
                        goto Label_0171;
                    }
                    if (0 == 0)
                    {
                        goto Label_012F;
                    }
                    goto Label_008B;
                Label_00F3:
                    if (0 != 0)
                    {
                        goto Label_0018;
                    }
                    goto Label_0029;
                Label_00FE:
                    field.ActualHigh = field2.Max;
                    field.ActualLow = field2.Min;
                    goto Label_009D;
                Label_011B:
                    if (field.Action == NormalizationAction.Normalize)
                    {
                        goto Label_00FE;
                    }
                    if (0 == 0)
                    {
                        goto Label_009D;
                    }
                    goto Label_00AB;
                Label_012F:
                    if (0 == 0)
                    {
                        goto Label_011B;
                    }
                    if (2 != 0)
                    {
                        goto Label_00FE;
                    }
                    if (0 == 0)
                    {
                        goto Label_008B;
                    }
                    goto Label_019C;
                Label_013E:
                    field2 = script.FindDataField(field.Name);
                    if (-1 == 0)
                    {
                        goto Label_00F3;
                    }
                    while (field2 == null)
                    {
                        throw new AnalystError("Normalize specifies unknown field: " + field.Name);
                    }
                    goto Label_0181;
                Label_0171:
                    if (0 != 0)
                    {
                        goto Label_0029;
                    }
                Label_0177:
                    field = enumerator.Current;
                    goto Label_013E;
                Label_0181:
                    if ((((uint) num) + ((uint) num)) <= uint.MaxValue)
                    {
                        goto Label_012F;
                    }
                Label_019C:
                    if ((((uint) num) + ((uint) num)) >= 0)
                    {
                        goto Label_009D;
                    }
                }
            }
        }

        public sealed override string ToString()
        {
            StringBuilder builder = new StringBuilder("[");
            builder.Append(base.GetType().Name);
            builder.Append(": ");
            if ((this._xcb632f1b59a7f901 != null) || (0x7fffffff == 0))
            {
                builder.Append(this._xcb632f1b59a7f901.ToString());
            }
            builder.Append("]");
            return builder.ToString();
        }

        [CompilerGenerated]
        private static bool x3e64998256ab1982(AnalystField xe01ae93d9fe5a880)
        {
            return xe01ae93d9fe5a880.Input;
        }

        [CompilerGenerated]
        private static int x4a01373bb5d8ba23(AnalystField xe01ae93d9fe5a880)
        {
            return xe01ae93d9fe5a880.ColumnsNeeded;
        }

        [CompilerGenerated]
        private static int x6336b641dc5ba406(AnalystField xe01ae93d9fe5a880)
        {
            return xe01ae93d9fe5a880.ColumnsNeeded;
        }

        [CompilerGenerated]
        private static bool x8b977eb5800872ff(AnalystField xe01ae93d9fe5a880)
        {
            return xe01ae93d9fe5a880.Output;
        }

        public IHandleMissingValues MissingValues
        {
            get
            {
                string propertyString = this._x594135906c55045c.Properties.GetPropertyString("NORMALIZE:CONFIG_missingValues");
                if (!propertyString.Equals("DiscardMissing"))
                {
                    if (propertyString.Equals("MeanAndModeMissing"))
                    {
                        return new MeanAndModeMissing();
                    }
                }
                else
                {
                    return new DiscardMissing();
                }
                if ((0 == 0) && !propertyString.Equals("NegateMissing"))
                {
                    return new DiscardMissing();
                }
                return new NegateMissing();
            }
            set
            {
                this._x594135906c55045c.Properties.SetProperty("NORMALIZE:CONFIG_missingValues", value.GetType().Name);
            }
        }

        public IList<AnalystField> NormalizedFields
        {
            get
            {
                return this._xcb632f1b59a7f901;
            }
        }
    }
}

