namespace Encog.ML.SVM.Training
{
    using Encog.MathUtil.Error;
    using Encog.MathUtil.LIBSVM;
    using Encog.ML;
    using Encog.ML.Data;
    using Encog.ML.SVM;
    using Encog.ML.Train;
    using Encog.Neural.Networks.Training.Propagation;
    using System;

    public class SVMTrain : BasicTraining
    {
        private double _x3c4da2980d043c95;
        private readonly svm_problem _x77eae494203cfff5;
        private readonly SupportVectorMachine _x87a7fc6a72741c2e;
        private int _x9425fdc2df7bcafc;
        private bool _xab248fa87e95a7df;
        private double _xc7c4e9c099884228;
        public const double DefaultConstBegin = -5.0;
        public const double DefaultConstEnd = 15.0;
        public const double DefaultConstStep = 2.0;
        public const double DefaultGammaBegin = -10.0;
        public const double DefaultGammaEnd = 10.0;
        public const double DefaultGammaStep = 1.0;

        public SVMTrain(SupportVectorMachine method, IMLDataSet dataSet) : base(TrainingImplementationType.OnePass)
        {
            this._x9425fdc2df7bcafc = 0;
            this._x87a7fc6a72741c2e = method;
            this.Training = dataSet;
            this._xab248fa87e95a7df = false;
            this._x77eae494203cfff5 = EncodeSVMProblem.Encode(dataSet, 0);
            this._xc7c4e9c099884228 = 1.0 / ((double) this._x87a7fc6a72741c2e.InputCount);
            this._x3c4da2980d043c95 = 1.0;
            if (0 == 0)
            {
            }
        }

        public sealed override void Iteration()
        {
            this._x87a7fc6a72741c2e.Params.C = this._x3c4da2980d043c95;
            if (0 == 0)
            {
                this._x87a7fc6a72741c2e.Params.gamma = this._xc7c4e9c099884228;
                if (this._x9425fdc2df7bcafc > 1)
                {
                    double[] target = new double[this._x77eae494203cfff5.l];
                    svm.svm_cross_validation(this._x77eae494203cfff5, this._x87a7fc6a72741c2e.Params, this._x9425fdc2df7bcafc, target);
                    this._x87a7fc6a72741c2e.Model = null;
                    if (-2147483648 != 0)
                    {
                        this.Error = x308cb2f3483de2a6(this._x87a7fc6a72741c2e.Params, this._x77eae494203cfff5, target);
                        goto Label_0050;
                    }
                    if (-1 == 0)
                    {
                        return;
                    }
                }
                this._x87a7fc6a72741c2e.Model = svm.svm_train(this._x77eae494203cfff5, this._x87a7fc6a72741c2e.Params);
            }
            this.Error = this._x87a7fc6a72741c2e.CalculateError(this.Training);
        Label_0050:
            this._xab248fa87e95a7df = true;
        }

        public sealed override TrainingContinuation Pause()
        {
            return null;
        }

        public override void Resume(TrainingContinuation state)
        {
        }

        private static double x308cb2f3483de2a6(svm_parameter x0d173b5435b4d6ad, svm_problem xdee3898b83df48b4, double[] x11d58b056c032b03)
        {
            ErrorCalculation calculation;
            int num2;
            double num3;
            int num5;
            int num = 0;
            if (0 == 0)
            {
                if ((((uint) num3) & 0) != 0)
                {
                    goto Label_0134;
                }
                goto Label_0108;
            }
            goto Label_008C;
        Label_0055:
            if (num2 >= xdee3898b83df48b4.l)
            {
                return calculation.Calculate();
            }
        Label_008C:
            num3 = xdee3898b83df48b4.y[num2];
            double actual = x11d58b056c032b03[num2];
            if (((uint) num3) < 0)
            {
                goto Label_0108;
            }
            calculation.UpdateError(actual, num3);
            num2++;
            if ((((uint) num3) - ((uint) num3)) >= 0)
            {
                goto Label_0055;
            }
        Label_00D4:
            if ((((uint) num5) & 0) == 0)
            {
                while (num5 < xdee3898b83df48b4.l)
                {
                    while (x11d58b056c032b03[num5] == xdee3898b83df48b4.y[num5])
                    {
                        num++;
                        if ((((uint) actual) + ((uint) actual)) <= uint.MaxValue)
                        {
                            break;
                        }
                    }
                    num5++;
                }
            }
            goto Label_0134;
        Label_0108:
            calculation = new ErrorCalculation();
            if (((x0d173b5435b4d6ad.svm_type != 3) && ((((uint) num5) | 3) != 0)) && (x0d173b5435b4d6ad.svm_type != 4))
            {
                num5 = 0;
                if ((((uint) num3) + ((uint) actual)) <= uint.MaxValue)
                {
                    goto Label_00D4;
                }
                goto Label_008C;
            }
            num2 = 0;
            goto Label_0055;
        Label_0134:
            return ((100.0 * num) / ((double) xdee3898b83df48b4.l));
        }

        public double C
        {
            get
            {
                return this._x3c4da2980d043c95;
            }
            set
            {
                this._x3c4da2980d043c95 = value;
            }
        }

        public sealed override bool CanContinue
        {
            get
            {
                return false;
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

        public double Gamma
        {
            get
            {
                return this._xc7c4e9c099884228;
            }
            set
            {
                this._xc7c4e9c099884228 = value;
            }
        }

        public override IMLMethod Method
        {
            get
            {
                return this._x87a7fc6a72741c2e;
            }
        }

        public svm_problem Problem
        {
            get
            {
                return this._x77eae494203cfff5;
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

