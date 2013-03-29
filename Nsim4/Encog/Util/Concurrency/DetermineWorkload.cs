namespace Encog.Util.Concurrency
{
    using Encog.MathUtil;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    public class DetermineWorkload
    {
        private readonly int _x0eaa9747fccf7ecc;
        private readonly int _xc0f709e5bcd6afff;
        public const int MinWorthwhile = 100;

        public DetermineWorkload(int threads, int workloadSize)
        {
            int num;
            long num2;
            goto Label_0094;
        Label_0059:
            num2 = this._x0eaa9747fccf7ecc;
            long num3 = num2 / ((long) num);
            if (num3 < 100L)
            {
                num = Math.Max(1, (int) (num2 / 100L));
                if (((uint) threads) > uint.MaxValue)
                {
                    return;
                }
            }
            this._xc0f709e5bcd6afff = num;
            return;
        Label_0094:
            this._x0eaa9747fccf7ecc = workloadSize;
            if (threads == 0)
            {
                num = (int) Math.Log((double) (((int) Process.GetCurrentProcess().ProcessorAffinity) + 1), 2.0);
                if (num == 1)
                {
                    goto Label_0059;
                }
                num++;
                if (((uint) num) <= uint.MaxValue)
                {
                    goto Label_0059;
                }
            }
            else if ((((uint) num2) + ((uint) workloadSize)) < 0)
            {
                return;
            }
            this._xc0f709e5bcd6afff = Math.Min(threads, workloadSize);
            if ((((uint) workloadSize) + ((uint) num)) <= uint.MaxValue)
            {
                return;
            }
            goto Label_0094;
        }

        public IList<IntRange> CalculateWorkers()
        {
            int num;
            int num2;
            int num3;
            int num4;
            IList<IntRange> list = new List<IntRange>();
            goto Label_00E8;
        Label_000B:
            list.Add(new IntRange(num4, num3));
            num2++;
            if (((uint) num3) > uint.MaxValue)
            {
                goto Label_00E8;
            }
        Label_0032:
            if (num2 < this._xc0f709e5bcd6afff)
            {
                num3 = num2 * num;
                if ((((uint) num4) - ((uint) num4)) < 0)
                {
                    goto Label_000B;
                }
                goto Label_00B5;
            }
            return list;
        Label_0043:
            num4 = ((num2 + 1) * num) - 1;
            if ((((uint) num3) - ((uint) num2)) <= uint.MaxValue)
            {
                goto Label_000B;
            }
            return list;
        Label_0053:
            if ((((uint) num3) + ((uint) num2)) >= 0)
            {
                goto Label_0043;
            }
        Label_008C:
            if ((((uint) num) + ((uint) num4)) < 0)
            {
                if ((((uint) num) - ((uint) num4)) < 0)
                {
                    goto Label_00B5;
                }
                goto Label_0053;
            }
            goto Label_0043;
        Label_00B5:
            if (num2 == (this._xc0f709e5bcd6afff - 1))
            {
                num4 = this._x0eaa9747fccf7ecc - 1;
                goto Label_000B;
            }
            if ((((uint) num2) - ((uint) num2)) > uint.MaxValue)
            {
                goto Label_0053;
            }
            if (0 == 0)
            {
                goto Label_008C;
            }
            goto Label_0043;
        Label_00E8:
            num = this._x0eaa9747fccf7ecc / this._xc0f709e5bcd6afff;
            num2 = 0;
            goto Label_0032;
        }

        public int ThreadCount
        {
            get
            {
                return this._xc0f709e5bcd6afff;
            }
        }
    }
}

