namespace Encog.ML.Train.Strategy
{
    using Encog.ML.Train;
    using Encog.Util.Logging;
    using System;

    public class HybridStrategy : IStrategy
    {
        private int _x123e81b4d1593407;
        private readonly int _x2801df77d59cbd36;
        private readonly int _x671aa26bb37ef7df;
        private bool _x6c7711ed04d2ac90;
        private readonly double _x75deb38bfba59a18;
        private double _x8b06dafb536c34dc;
        private readonly IMLTrain _xa45232be281da68a;
        private double _xaf54fba65f108955;
        private IMLTrain _xec2c4bbac24fbf6b;
        public const int DefaultAlternateCycles = 5;
        public const double DefaultMinImprovement = 1E-05;
        public const int DefaultTolerateCycles = 10;

        public HybridStrategy(IMLTrain altTrain) : this(altTrain, 1E-05, 10, 5)
        {
        }

        public HybridStrategy(IMLTrain altTrain, double minImprovement, int tolerateMinImprovement, int alternateCycles)
        {
            if (((((uint) minImprovement) | 2) != 0) && (0 == 0))
            {
                this._xa45232be281da68a = altTrain;
                this._x6c7711ed04d2ac90 = false;
            }
            this._x123e81b4d1593407 = 0;
            this._x75deb38bfba59a18 = minImprovement;
            this._x671aa26bb37ef7df = tolerateMinImprovement;
            this._x2801df77d59cbd36 = alternateCycles;
        }

        public virtual void Init(IMLTrain train)
        {
            this._xec2c4bbac24fbf6b = train;
        }

        public virtual void PostIteration()
        {
            double num;
            int num2;
            if (!this._x6c7711ed04d2ac90)
            {
                this._x6c7711ed04d2ac90 = true;
                if (((uint) num) >= 0)
                {
                    goto Label_004B;
                }
            }
            else
            {
                goto Label_014F;
            }
        Label_0010:
            if (Math.Abs(this._x8b06dafb536c34dc) < this._x75deb38bfba59a18)
            {
                goto Label_0124;
            }
            return;
        Label_004B:
            if (0 != 0)
            {
                goto Label_0010;
            }
        Label_0091:
            if (0 == 0)
            {
                return;
            }
            goto Label_014F;
        Label_011E:
            num2 = 0;
            while (num2 < this._x2801df77d59cbd36)
            {
                this._xa45232be281da68a.Iteration();
                num2++;
            }
            return;
        Label_0124:
            this._x123e81b4d1593407++;
            if (((((uint) num) - ((uint) num)) <= uint.MaxValue) && (this._x123e81b4d1593407 <= this._x671aa26bb37ef7df))
            {
                if (0xff != 0)
                {
                    return;
                }
            }
            else
            {
                this._x123e81b4d1593407 = 0;
                if ((((uint) num) + ((uint) num)) > uint.MaxValue)
                {
                    goto Label_011E;
                }
            }
            EncogLogging.Log(0, "Performing hybrid cycle");
            goto Label_011E;
        Label_014F:
            num = this._xec2c4bbac24fbf6b.Error;
            this._x8b06dafb536c34dc = (num - this._xaf54fba65f108955) / this._xaf54fba65f108955;
            EncogLogging.Log(0, "Last improvement: " + this._x8b06dafb536c34dc);
            if (((uint) num2) <= uint.MaxValue)
            {
                if (this._x8b06dafb536c34dc > 0.0)
                {
                    goto Label_0124;
                }
                if (((uint) num2) < 0)
                {
                    goto Label_004B;
                }
                if ((((uint) num2) | 0xff) != 0)
                {
                    goto Label_0010;
                }
                goto Label_0091;
            }
            if ((((uint) num) & 0) == 0)
            {
                goto Label_0010;
            }
            goto Label_0124;
        }

        public virtual void PreIteration()
        {
            this._xaf54fba65f108955 = this._xec2c4bbac24fbf6b.Error;
        }
    }
}

