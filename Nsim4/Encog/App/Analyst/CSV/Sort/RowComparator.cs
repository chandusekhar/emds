namespace Encog.App.Analyst.CSV.Sort
{
    using Encog.App.Analyst.CSV.Basic;
    using Encog.App.Quant;
    using System;
    using System.Collections.Generic;

    public class RowComparator : IComparer<LoadedRow>
    {
        private readonly SortCSV _x52c5c1ffeeee6e58;

        public RowComparator(SortCSV owner)
        {
            this._x52c5c1ffeeee6e58 = owner;
        }

        public int Compare(LoadedRow x, LoadedRow y)
        {
            using (IEnumerator<SortedField> enumerator = this._x52c5c1ffeeee6e58.SortOrder.GetEnumerator())
            {
                SortedField field;
                string str;
                string str2;
                int num4;
                int num5;
                int num7;
                int num8;
                int num9;
                SortType sortType;
                goto Label_001D;
            Label_0016:
                if (num4 != 0)
                {
                    return num4;
                }
            Label_001D:
                if (enumerator.MoveNext())
                {
                    goto Label_0131;
                }
                if ((((uint) num9) & 0) != 0)
                {
                    goto Label_004F;
                }
                goto Label_016D;
            Label_0042:
                if (num8 == 0)
                {
                    goto Label_001D;
                }
                return num8;
            Label_004F:
                throw new QuantError("Unknown sort method: " + field.SortType);
            Label_006C:
                if (num7 == 0)
                {
                    goto Label_001D;
                }
                return num7;
            Label_008B:
                num8 = string.CompareOrdinal(str, str2);
                goto Label_0042;
            Label_00A4:
                num5 = int.Parse(str);
                int num6 = int.Parse(str2);
                num7 = num5 - num6;
                goto Label_006C;
            Label_00C9:
                switch (sortType)
                {
                    case SortType.SortInteger:
                        goto Label_00A4;

                    case SortType.SortString:
                        goto Label_008B;

                    case SortType.SortDecimal:
                    {
                        double num3;
                        double num2 = this._x52c5c1ffeeee6e58.InputFormat.Parse(str);
                        if ((((uint) num5) + ((uint) num6)) >= 0)
                        {
                            num3 = this._x52c5c1ffeeee6e58.InputFormat.Parse(str2);
                        }
                        num4 = num2.CompareTo(num3);
                        goto Label_0016;
                    }
                    default:
                        goto Label_004F;
                }
            Label_0131:
                field = enumerator.Current;
                int index = field.Index;
                str = x.Data[index];
                str2 = y.Data[index];
                sortType = field.SortType;
                goto Label_00C9;
            }
        Label_016D:
            return 0;
        }
    }
}

