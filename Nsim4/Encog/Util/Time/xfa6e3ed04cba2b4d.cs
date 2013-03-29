namespace Encog.Util.Time
{
    using System;

    internal class xfa6e3ed04cba2b4d
    {
        private DateTime _x3ed4f4f0195b98d7;
        private DateTime _x7f8a886f51b477eb;

        public xfa6e3ed04cba2b4d(DateTime from, DateTime to)
        {
            this._x7f8a886f51b477eb = from;
            this._x3ed4f4f0195b98d7 = to;
        }

        private long x0905452febc1cbdf()
        {
            return (this.x869f1c53829f68a4() / 20L);
        }

        private long x28aeb15d96190c26()
        {
            return (this.x869f1c53829f68a4() / 0x3e8L);
        }

        private long x4aff25a89461a238()
        {
            return (this.x869f1c53829f68a4() / 100L);
        }

        private long x52032ef7ed3b457a()
        {
            return this._x3ed4f4f0195b98d7.Subtract(this._x7f8a886f51b477eb).Ticks;
        }

        private long x76ccac0e5618a6e2()
        {
            return (this.x940a8f756e4742a5() / 0x18L);
        }

        private long x7a6b33543832adcd()
        {
            return (this._x3ed4f4f0195b98d7.Subtract(this._x7f8a886f51b477eb).Ticks / 0x989680L);
        }

        private long x869f1c53829f68a4()
        {
            return (this.x898ebed938f437e5() / 12L);
        }

        private long x898ebed938f437e5()
        {
            return (long) ((this._x3ed4f4f0195b98d7.Month - this._x7f8a886f51b477eb.Month) + ((this._x3ed4f4f0195b98d7.Year - this._x7f8a886f51b477eb.Year) * 12));
        }

        private long x940a8f756e4742a5()
        {
            return (this.xab974cfe9f881e8f() / 60L);
        }

        private long xab974cfe9f881e8f()
        {
            return (this.x7a6b33543832adcd() / 60L);
        }

        private long xc07d29bd1d813d76()
        {
            return (this.xed91ebbb4d1afad3() / 2L);
        }

        private long xed91ebbb4d1afad3()
        {
            return (this.x76ccac0e5618a6e2() / 7L);
        }

        public long xeeb06d6ba66e71e9(TimeUnit x1c40252c1b8530fe)
        {
            switch (x1c40252c1b8530fe)
            {
                case TimeUnit.Seconds:
                    return this.x7a6b33543832adcd();

                case TimeUnit.Minutes:
                    return this.xab974cfe9f881e8f();

                case TimeUnit.Hours:
                    return this.x940a8f756e4742a5();

                case TimeUnit.Days:
                    return this.x76ccac0e5618a6e2();

                case TimeUnit.Weeks:
                    return this.xed91ebbb4d1afad3();

                case TimeUnit.Fortnights:
                    return this.xc07d29bd1d813d76();

                case TimeUnit.Months:
                    return this.x898ebed938f437e5();

                case TimeUnit.Years:
                    return this.x869f1c53829f68a4();

                case TimeUnit.Scores:
                    return this.x0905452febc1cbdf();

                case TimeUnit.Centuries:
                    return this.x4aff25a89461a238();

                case TimeUnit.Millennia:
                    return this.x28aeb15d96190c26();

                case TimeUnit.Ticks:
                    return this.x52032ef7ed3b457a();
            }
            return 0L;
        }

        public DateTime x9ba555f37571f2fd
        {
            get
            {
                return this._x3ed4f4f0195b98d7;
            }
        }

        public DateTime xc0861382583d693c
        {
            get
            {
                return this._x7f8a886f51b477eb;
            }
        }
    }
}

