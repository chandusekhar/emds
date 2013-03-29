namespace Encog.ML.Anneal
{
    using System;
    using System.Runtime.CompilerServices;

    public abstract class SimulatedAnnealing<TUnitType>
    {
        private int _x31fc5c65f8944f8b;
        private bool _x4959c38ab17aa08d;
        private double _x745edd755505b88b;
        [CompilerGenerated]
        private double x15ad1ba0d0258359;
        [CompilerGenerated]
        private double x1fbe8f11faac8bb5;
        [CompilerGenerated]
        private double x3cade66267819c38;

        protected SimulatedAnnealing()
        {
            this._x4959c38ab17aa08d = true;
        }

        public void Iteration()
        {
            TUnitType[] arrayCopy;
            int num;
            double num2;
            double num3;
            this.Score = this.PerformCalculateScore();
            if ((((uint) num3) - ((uint) num3)) >= 0)
            {
                if (0x7fffffff == 0)
                {
                    return;
                }
                arrayCopy = this.ArrayCopy;
                this._x745edd755505b88b = this.StartTemperature;
                num = 0;
            }
            else
            {
                goto Label_00C3;
            }
        Label_0060:
            if (num < this._x31fc5c65f8944f8b)
            {
                this.Randomize();
                goto Label_010B;
            }
            if ((((uint) num3) & 0) == 0)
            {
                return;
            }
            goto Label_00C3;
        Label_009A:
            this.PutArray(arrayCopy);
            num3 = Math.Exp(Math.Log(this.StopTemperature / this.StartTemperature) / ((double) (this.Cycles - 1)));
            this._x745edd755505b88b *= num3;
            num++;
            goto Label_0060;
        Label_00A3:
            if (num2 > this.Score)
            {
                arrayCopy = this.ArrayCopy;
                if ((((uint) num) - ((uint) num2)) >= 0)
                {
                    if ((((uint) num2) | 8) == 0)
                    {
                        return;
                    }
                    goto Label_00C3;
                }
                goto Label_010B;
            }
            goto Label_009A;
        Label_00C3:
            this.Score = num2;
            goto Label_009A;
        Label_010B:
            num2 = this.PerformCalculateScore();
            if (!this._x4959c38ab17aa08d)
            {
                goto Label_00A3;
            }
            if (num2 < this.Score)
            {
                arrayCopy = this.ArrayCopy;
                this.Score = num2;
            }
            else if ((((uint) num3) - ((uint) num2)) > uint.MaxValue)
            {
                goto Label_00A3;
            }
            goto Label_009A;
        }

        public abstract double PerformCalculateScore();
        public abstract void PutArray(TUnitType[] array);
        public abstract void Randomize();

        public abstract TUnitType[] Array { get; }

        public abstract TUnitType[] ArrayCopy { get; }

        public int Cycles
        {
            get
            {
                return this._x31fc5c65f8944f8b;
            }
            set
            {
                this._x31fc5c65f8944f8b = value;
            }
        }

        public double Score
        {
            [CompilerGenerated]
            get
            {
                return this.x1fbe8f11faac8bb5;
            }
            [CompilerGenerated]
            set
            {
                this.x1fbe8f11faac8bb5 = value;
            }
        }

        public bool ShouldMinimize
        {
            get
            {
                return this._x4959c38ab17aa08d;
            }
            set
            {
                this._x4959c38ab17aa08d = value;
            }
        }

        public double StartTemperature
        {
            [CompilerGenerated]
            get
            {
                return this.x15ad1ba0d0258359;
            }
            [CompilerGenerated]
            set
            {
                this.x15ad1ba0d0258359 = value;
            }
        }

        public double StopTemperature
        {
            [CompilerGenerated]
            get
            {
                return this.x3cade66267819c38;
            }
            [CompilerGenerated]
            set
            {
                this.x3cade66267819c38 = value;
            }
        }

        public double Temperature
        {
            get
            {
                return this._x745edd755505b88b;
            }
            set
            {
                this._x745edd755505b88b = value;
            }
        }
    }
}

