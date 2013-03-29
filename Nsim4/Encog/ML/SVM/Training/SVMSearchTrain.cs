namespace Encog.ML.SVM.Training
{
    using Encog.ML;
    using Encog.ML.Data;
    using Encog.ML.SVM;
    using Encog.ML.Train;
    using Encog.Neural.Networks.Training.Propagation;
    using System;

    public class SVMSearchTrain : BasicTraining
    {
        private readonly SVMTrain _x1e074b5762f8595b;
        private double _x2350dfd8c7639ed6;
        private double _x38c942a9bdfcbac4;
        private double _x441f2c3a7d69c688;
        private readonly SupportVectorMachine _x87a7fc6a72741c2e;
        private double _x8bfd70ace96b5df9;
        private double _x8e930440b5961c22;
        private int _x9425fdc2df7bcafc;
        private bool _x9eeb587621db687c;
        private bool _xab248fa87e95a7df;
        private double _xb4d759691bf907d6;
        private double _xc664bec96749a134;
        private double _xd440b5acbb3f42f7;
        private double _xd522fee165affb59;
        private double _xdee5cbd981b6d49e;
        private double _xec9380575da42aee;
        public const double DefaultConstBegin = -5.0;
        public const double DefaultConstEnd = 15.0;
        public const double DefaultConstStep = 2.0;
        public const double DefaultGammaBegin = -10.0;
        public const double DefaultGammaEnd = 10.0;
        public const double DefaultGammaStep = 1.0;

        public SVMSearchTrain(SupportVectorMachine method, IMLDataSet training) : base(TrainingImplementationType.Iterative)
        {
            this._x9425fdc2df7bcafc = 0;
            this._x2350dfd8c7639ed6 = -5.0;
            this._x38c942a9bdfcbac4 = 2.0;
            while (true)
            {
                if (3 != 0)
                {
                    this._xdee5cbd981b6d49e = 15.0;
                    if (0 == 0)
                    {
                        this._xec9380575da42aee = -10.0;
                    }
                }
                this._xd522fee165affb59 = 10.0;
                this._x441f2c3a7d69c688 = 1.0;
                this._x87a7fc6a72741c2e = method;
                this.Training = training;
                this._x9eeb587621db687c = false;
                if (0 == 0)
                {
                    if (0 == 0)
                    {
                        this._xab248fa87e95a7df = false;
                        this._x1e074b5762f8595b = new SVMTrain(this._x87a7fc6a72741c2e, training);
                        return;
                    }
                    return;
                }
            }
        }

        public sealed override void FinishTraining()
        {
            this._x1e074b5762f8595b.Gamma = this._xb4d759691bf907d6;
            this._x1e074b5762f8595b.C = this._xc664bec96749a134;
            this._x1e074b5762f8595b.Iteration();
        }

        public sealed override void Iteration()
        {
            double error;
            if (this._xab248fa87e95a7df)
            {
                return;
            }
            if (((uint) error) >= 0)
            {
                goto Label_019E;
            }
            goto Label_00E6;
        Label_0058:
            base.PostIteration();
            if (8 != 0)
            {
                goto Label_0122;
            }
            goto Label_00E6;
        Label_009D:
            this.Error = this._x8bfd70ace96b5df9;
            goto Label_0058;
        Label_00B7:
            if ((0 == 0) && (this._x8e930440b5961c22 <= this._xd522fee165affb59))
            {
                goto Label_009D;
            }
            this._xab248fa87e95a7df = true;
            if (0 == 0)
            {
                if (0 != 0)
                {
                    goto Label_00E6;
                }
                goto Label_009D;
            }
            goto Label_0122;
        Label_00E6:
            this._xc664bec96749a134 = this._xd440b5acbb3f42f7;
            this._xb4d759691bf907d6 = this._x8e930440b5961c22;
            this._x8bfd70ace96b5df9 = error;
        Label_0105:
            this._xd440b5acbb3f42f7 += this._x38c942a9bdfcbac4;
            if (this._xd440b5acbb3f42f7 > this._xdee5cbd981b6d49e)
            {
                this._xd440b5acbb3f42f7 = this._x2350dfd8c7639ed6;
                this._x8e930440b5961c22 += this._x441f2c3a7d69c688;
                goto Label_00B7;
            }
            goto Label_009D;
        Label_0122:
            if (1 != 0)
            {
                return;
            }
        Label_019E:
            if (!this._x9eeb587621db687c)
            {
                this.x85a347d911c2e4a4();
            }
            base.PreIteration();
            this._x1e074b5762f8595b.Fold = this._x9425fdc2df7bcafc;
            if (0 == 0)
            {
            }
            if (this._x87a7fc6a72741c2e.KernelType == KernelType.RadialBasisFunction)
            {
                this._x1e074b5762f8595b.Gamma = this._x8e930440b5961c22;
                this._x1e074b5762f8595b.C = this._xd440b5acbb3f42f7;
                this._x1e074b5762f8595b.Iteration();
                error = this._x1e074b5762f8595b.Error;
                if (double.IsNaN(error) || (error >= this._x8bfd70ace96b5df9))
                {
                    goto Label_0105;
                }
                if ((((uint) error) > uint.MaxValue) || (0 == 0))
                {
                    goto Label_00E6;
                }
                goto Label_019E;
            }
            this._x1e074b5762f8595b.Gamma = this._x8e930440b5961c22;
            if (0 != 0)
            {
                goto Label_00B7;
            }
            this._x1e074b5762f8595b.C = this._xd440b5acbb3f42f7;
            this._x1e074b5762f8595b.Iteration();
            goto Label_0058;
        }

        public sealed override TrainingContinuation Pause()
        {
            return null;
        }

        public override void Resume(TrainingContinuation state)
        {
        }

        private void x85a347d911c2e4a4()
        {
            this._xd440b5acbb3f42f7 = this._x2350dfd8c7639ed6;
            this._x8e930440b5961c22 = this._xec9380575da42aee;
            this._x8bfd70ace96b5df9 = double.PositiveInfinity;
            this._x9eeb587621db687c = true;
        }

        public sealed override bool CanContinue
        {
            get
            {
                return false;
            }
        }

        public double ConstBegin
        {
            get
            {
                return this._x2350dfd8c7639ed6;
            }
            set
            {
                this._x2350dfd8c7639ed6 = value;
            }
        }

        public double ConstEnd
        {
            get
            {
                return this._xdee5cbd981b6d49e;
            }
            set
            {
                this._xdee5cbd981b6d49e = value;
            }
        }

        public double ConstStep
        {
            get
            {
                return this._x38c942a9bdfcbac4;
            }
            set
            {
                this._x38c942a9bdfcbac4 = value;
            }
        }

        public int Fold
        {
            get
            {
                return this._x9425fdc2df7bcafc;
            }
            set
            {
                this._x9425fdc2df7bcafc = value;
            }
        }

        public double GammaBegin
        {
            get
            {
                return this._xec9380575da42aee;
            }
            set
            {
                this._xec9380575da42aee = value;
            }
        }

        public double GammaEnd
        {
            get
            {
                return this._xd522fee165affb59;
            }
            set
            {
                this._xd522fee165affb59 = value;
            }
        }

        public double GammaStep
        {
            get
            {
                return this._x441f2c3a7d69c688;
            }
            set
            {
                this._x441f2c3a7d69c688 = value;
            }
        }

        public override IMLMethod Method
        {
            get
            {
                return this._x87a7fc6a72741c2e;
            }
        }

        public override bool TrainingDone
        {
            get
            {
                return this._xab248fa87e95a7df;
            }
        }
    }
}

