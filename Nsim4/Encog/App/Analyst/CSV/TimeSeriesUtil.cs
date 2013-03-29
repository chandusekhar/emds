namespace Encog.App.Analyst.CSV
{
    using Encog.App.Analyst;
    using Encog.App.Analyst.Script.Normalize;
    using Encog.Util;
    using System;
    using System.Collections.Generic;

    public class TimeSeriesUtil
    {
        private readonly int _x1a429c90ca24e96e;
        private readonly IDictionary<string, int> _x3f320d9b568c80aa = new Dictionary<string, int>();
        private readonly EncogAnalyst _x554f16462d8d4675;
        private readonly IList<double[]> _x5cafa8d49ea71ea1 = new List<double[]>();
        private readonly int _x60382b076ae7366a;
        private readonly int _x7ab03f26e84400e9;
        private readonly int _x7e648b416c264559;
        private readonly int _xdb45501d49a9da70;

        public TimeSeriesUtil(EncogAnalyst theAnalyst, bool includeOutput, IEnumerable<string> headings)
        {
            this._x554f16462d8d4675 = theAnalyst;
            this._x60382b076ae7366a = this._x554f16462d8d4675.LagDepth;
            if (-1 != 0)
            {
            }
            this._xdb45501d49a9da70 = this._x554f16462d8d4675.LeadDepth;
            this._x7ab03f26e84400e9 = (this._x60382b076ae7366a + this._xdb45501d49a9da70) + 1;
            this._x7e648b416c264559 = includeOutput ? this._x554f16462d8d4675.DetermineTotalColumns() : this._x554f16462d8d4675.DetermineTotalInputFieldCount();
            this._x1a429c90ca24e96e = this._x554f16462d8d4675.DetermineInputCount() + this._x554f16462d8d4675.DetermineOutputCount();
            int num = 0;
            foreach (string str in headings)
            {
                this._x3f320d9b568c80aa[str.ToUpper()] = num++;
            }
        }

        public double[] Process(double[] input)
        {
            double[] numArray;
            int num;
            int num2;
            int num3;
            double num4;
            object[] objArray;
            if (input.Length == this._x7e648b416c264559)
            {
                goto Label_0187;
            }
            goto Label_0222;
        Label_002E:
            if (this._x5cafa8d49ea71ea1.Count <= this._x7ab03f26e84400e9)
            {
                if ((((uint) num2) + ((uint) num)) >= 0)
                {
                    return numArray;
                }
                goto Label_0222;
            }
        Label_0061:
            this._x5cafa8d49ea71ea1.RemoveAt(this._x5cafa8d49ea71ea1.Count - 1);
            if ((((uint) num2) - ((uint) num4)) < 0)
            {
                goto Label_019D;
            }
            goto Label_002E;
        Label_007E:
            using (IEnumerator<AnalystField> enumerator = this._x554f16462d8d4675.Script.Normalize.NormalizedFields.GetEnumerator())
            {
                AnalystField field;
                double[] numArray2;
                goto Label_00A6;
            Label_009E:
                if (!field.Ignored)
                {
                    goto Label_00F4;
                }
            Label_00A6:
                if (enumerator.MoveNext())
                {
                    goto Label_014B;
                }
                goto Label_002E;
            Label_00B4:
                numArray2 = this._x5cafa8d49ea71ea1[num3];
                if (0 != 0)
                {
                    goto Label_009E;
                }
                num4 = numArray2[num2];
                numArray[num++] = num4;
                goto Label_00A6;
            Label_00F4:
                if (!this._x3f320d9b568c80aa.ContainsKey(field.Name.ToUpper()))
                {
                    throw new AnalystError("Undefined field: " + field.Name);
                }
                num2 = this._x3f320d9b568c80aa[field.Name.ToUpper()];
                if ((((uint) num2) + ((uint) num3)) >= 0)
                {
                }
                num3 = this.x3133e3a0f3555e0a(field.TimeSlice);
                goto Label_0158;
            Label_014B:
                field = enumerator.Current;
                goto Label_009E;
            Label_0158:
                if (((uint) num2) >= 0)
                {
                    goto Label_00B4;
                }
                goto Label_002E;
            }
            goto Label_0061;
        Label_0183:
            num = 0;
            if ((((uint) num) - ((uint) num2)) >= 0)
            {
                goto Label_007E;
            }
            goto Label_01D6;
        Label_0187:
            this._x5cafa8d49ea71ea1.Insert(0, EngineArray.ArrayCopy(input));
        Label_019D:
            while (this._x5cafa8d49ea71ea1.Count < this._x7ab03f26e84400e9)
            {
                return null;
            }
            numArray = new double[this._x1a429c90ca24e96e];
            goto Label_0183;
        Label_01D6:
            objArray[2] = ", should be ";
            objArray[3] = this._x7e648b416c264559;
            throw new AnalystError(string.Concat(objArray));
            if ((((uint) num3) | 3) != 0)
            {
                goto Label_0187;
            }
            goto Label_007E;
        Label_0222:
            objArray = new object[4];
            objArray[0] = "Invalid input size: ";
            if (((uint) num2) < 0)
            {
                goto Label_0183;
            }
            objArray[1] = input.Length;
            goto Label_01D6;
        }

        private int x3133e3a0f3555e0a(int xc0c4c459c6ccbd00)
        {
            return Math.Abs((int) (xc0c4c459c6ccbd00 - this._xdb45501d49a9da70));
        }

        public EncogAnalyst Analyst
        {
            get
            {
                return this._x554f16462d8d4675;
            }
        }

        public IList<double[]> Buffer
        {
            get
            {
                return this._x5cafa8d49ea71ea1;
            }
        }

        public IDictionary<string, int> HeadingMap
        {
            get
            {
                return this._x3f320d9b568c80aa;
            }
        }

        public int InputSize
        {
            get
            {
                return this._x7e648b416c264559;
            }
        }

        public int LagDepth
        {
            get
            {
                return this._x60382b076ae7366a;
            }
        }

        public int LeadDepth
        {
            get
            {
                return this._xdb45501d49a9da70;
            }
        }

        public int OutputSize
        {
            get
            {
                return this._x1a429c90ca24e96e;
            }
        }

        public int TotalDepth
        {
            get
            {
                return this._x7ab03f26e84400e9;
            }
        }
    }
}

