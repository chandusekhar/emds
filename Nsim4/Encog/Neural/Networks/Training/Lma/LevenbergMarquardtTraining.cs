namespace Encog.Neural.Networks.Training.Lma
{
    using Encog.MathUtil.Matrices;
    using Encog.MathUtil.Matrices.Decomposition;
    using Encog.ML;
    using Encog.ML.Data;
    using Encog.ML.Data.Basic;
    using Encog.ML.Train;
    using Encog.Neural.Networks;
    using Encog.Neural.Networks.Structure;
    using Encog.Neural.Networks.Training;
    using Encog.Neural.Networks.Training.Propagation;
    using Encog.Util.Validate;
    using System;

    public class LevenbergMarquardtTraining : BasicTraining
    {
        private readonly Matrix _x05fb16197e552de6;
        private double[] _x2f33d779e5a20b28;
        private double _x3271cefb1a159639;
        private readonly double[] _x3cb63876dda4b74a;
        private readonly IMLDataPair _x61830ac74d65acc3;
        private double _x6ad505c7ef981b0e;
        private bool _x6c57e14b737e51f6;
        private readonly int _x8557b7ee760663f3;
        private readonly double[] _x878c4eb3cef19a5a;
        private readonly BasicNetwork _x87a7fc6a72741c2e;
        private readonly IMLDataSet _xb12276308f0fa6d9;
        private readonly double[][] _xc410e3804222557a;
        private double _xc7c4e9c099884228;
        private double _xd7d571ecee49d1e4;
        private double[] _xdadd8f92d75a3aba;
        private readonly int _xe2982b936ae423cd;
        public const double LambdaMax = 1E+25;
        public const double ScaleLambda = 10.0;

        public LevenbergMarquardtTraining(BasicNetwork network, IMLDataSet training) : base(TrainingImplementationType.Iterative)
        {
            if (2 != 0)
            {
                ValidateNetwork.ValidateMethodToData(network, training);
                if (network.OutputCount != 1)
                {
                    throw new TrainingError("Levenberg Marquardt requires an output layer with a single neuron.");
                }
                this.Training = training;
                goto Label_0134;
            }
        Label_00A8:
            this._xdadd8f92d75a3aba = new double[this._xe2982b936ae423cd];
            this._x878c4eb3cef19a5a = new double[this._xe2982b936ae423cd];
            this._x3cb63876dda4b74a = new double[this._xe2982b936ae423cd];
            if (0xff == 0)
            {
                return;
            }
            BasicMLData input = new BasicMLData(this._xb12276308f0fa6d9.InputSize);
            BasicMLData ideal = new BasicMLData(this._xb12276308f0fa6d9.IdealSize);
            this._x61830ac74d65acc3 = new BasicMLDataPair(input, ideal);
            if (-1 != 0)
            {
                return;
            }
        Label_0134:
            this._xb12276308f0fa6d9 = this.Training;
            this._x87a7fc6a72741c2e = network;
            this._x8557b7ee760663f3 = (int) this._xb12276308f0fa6d9.Count;
            this._xe2982b936ae423cd = this._x87a7fc6a72741c2e.Structure.CalculateSize();
            this._x05fb16197e552de6 = new Matrix(this._xe2982b936ae423cd, this._xe2982b936ae423cd);
            this._xc410e3804222557a = this._x05fb16197e552de6.Data;
            this._x6ad505c7ef981b0e = 0.0;
            this._xd7d571ecee49d1e4 = 1.0;
            this._x3271cefb1a159639 = 0.1;
            goto Label_00A8;
        }

        public void CalculateHessian(double[][] jacobian, double[] errors)
        {
            double num2;
            int num3;
            int num4;
            double num5;
            int num7;
            int index = 0;
            if (((uint) num5) >= 0)
            {
                goto Label_0079;
            }
            if ((((uint) index) + ((uint) num4)) >= 0)
            {
                goto Label_0072;
            }
        Label_002F:
            num7 = 0;
            if ((((uint) num7) & 0) != 0)
            {
                goto Label_014E;
            }
            while (num7 < this._xe2982b936ae423cd)
            {
                this._x3cb63876dda4b74a[num7] = this._xc410e3804222557a[num7][num7];
                num7++;
            }
            return;
        Label_0072:
            if (8 != 0)
            {
            }
        Label_0079:
            if (index < this._xe2982b936ae423cd)
            {
                num2 = 0.0;
                goto Label_014E;
            }
            goto Label_002F;
        Label_00AD:
            if (num4 >= this._xe2982b936ae423cd)
            {
                index++;
                goto Label_0072;
            }
        Label_00F0:
            num5 = 0.0;
            int num6 = 0;
        Label_008C:
            if (num6 < this._x8557b7ee760663f3)
            {
                num5 += jacobian[num6][index] * jacobian[num6][num4];
                num6++;
                if ((((uint) num7) - ((uint) index)) <= uint.MaxValue)
                {
                    goto Label_008C;
                }
                goto Label_0072;
            }
            this._xc410e3804222557a[index][num4] = this._xd7d571ecee49d1e4 * num5;
            num4++;
            goto Label_00AD;
        Label_014E:
            num3 = 0;
            while (true)
            {
                if (num3 >= this._x8557b7ee760663f3)
                {
                    this._x878c4eb3cef19a5a[index] = num2;
                    num4 = 0;
                    goto Label_00AD;
                }
                num2 += jacobian[num3][index] * errors[num3];
                if (((uint) num6) < 0)
                {
                    goto Label_00F0;
                }
                num3++;
            }
        }

        public override void Iteration()
        {
            LUDecomposition decomposition = null;
            double num;
            double num2;
            double num3;
            double num4;
            int num5;
            int num6;
            IMLData data;
            double num7;
            double num8;
            if ((((uint) num4) | 15) != 0)
            {
                goto Label_0399;
            }
            goto Label_01C7;
        Label_0022:
            base.PostIteration();
            if ((((uint) num5) & 0) == 0)
            {
                return;
            }
            goto Label_01C7;
        Label_0044:
            this._xd7d571ecee49d1e4 = Math.Abs((double) ((this._x8557b7ee760663f3 - this._xc7c4e9c099884228) / (2.0 * num)));
        Label_0073:
            this.Error = num;
            goto Label_0022;
        Label_00F1:
            if ((num4 >= num3) && (this._x3271cefb1a159639 < 1E+25))
            {
                this._x3271cefb1a159639 *= 10.0;
                num5 = 0;
            Label_01EF:
                if (num5 < this._xe2982b936ae423cd)
                {
                    this._xc410e3804222557a[num5][num5] = this._x3cb63876dda4b74a[num5] + (this._x3271cefb1a159639 + this._x6ad505c7ef981b0e);
                    num5++;
                    if ((((uint) num7) + ((uint) num3)) >= 0)
                    {
                        goto Label_01EF;
                    }
                }
                else
                {
                    if ((((uint) num7) + ((uint) num8)) > uint.MaxValue)
                    {
                        return;
                    }
                    decomposition = new LUDecomposition(this._x05fb16197e552de6);
                    if (!decomposition.IsNonsingular)
                    {
                        goto Label_00F1;
                    }
                    this._xdadd8f92d75a3aba = decomposition.Solve(this._x878c4eb3cef19a5a);
                }
                if (((uint) num6) >= 0)
                {
                    if (0 != 0)
                    {
                        goto Label_0340;
                    }
                    goto Label_01C7;
                }
                goto Label_029A;
            }
            this._x3271cefb1a159639 /= 10.0;
            if (this._x6c57e14b737e51f6 && (decomposition != null))
            {
                num8 = Trace(decomposition.Inverse());
                this._xc7c4e9c099884228 = this._xe2982b936ae423cd - (this._x6ad505c7ef981b0e * num8);
                if (((uint) num7) < 0)
                {
                    goto Label_0044;
                }
                this._x6ad505c7ef981b0e = ((double) this._xe2982b936ae423cd) / ((2.0 * num2) + num8);
                if ((((uint) num4) | 0xfffffffe) != 0)
                {
                    goto Label_0044;
                }
                goto Label_0022;
            }
            goto Label_0073;
        Label_0137:
            num7 = this._x61830ac74d65acc3.Ideal[0] - data[0];
            num += num7 * num7;
            num6++;
        Label_0161:
            if (num6 < this._x8557b7ee760663f3)
            {
                this._xb12276308f0fa6d9.GetRecord((long) num6, this._x61830ac74d65acc3);
                data = this._x87a7fc6a72741c2e.Compute(this._x61830ac74d65acc3.Input);
                goto Label_0137;
            }
            num /= 2.0;
            num4 = (this._xd7d571ecee49d1e4 * num) + (this._x6ad505c7ef981b0e * num2);
            goto Label_00F1;
        Label_01C7:
            num2 = this.UpdateWeights();
            num = 0.0;
            num6 = 0;
            goto Label_0161;
        Label_029A:
            if ((((uint) num7) | 0xff) == 0)
            {
                goto Label_0137;
            }
            this._x3271cefb1a159639 /= 10.0;
            goto Label_00F1;
        Label_0340:
            num4 = num3 + 1.0;
            if ((((uint) num4) - ((uint) num6)) >= 0)
            {
                goto Label_029A;
            }
        Label_0399:
            base.PreIteration();
            this._x2f33d779e5a20b28 = NetworkCODEC.NetworkToArray(this._x87a7fc6a72741c2e);
            if ((((uint) num8) | 4) == 0)
            {
                goto Label_0022;
            }
            IComputeJacobian jacobian = new JacobianChainRule(this._x87a7fc6a72741c2e, this._xb12276308f0fa6d9);
            num = jacobian.Calculate(this._x2f33d779e5a20b28);
            num2 = this.x01818299df58497e();
            this.CalculateHessian(jacobian.Jacobian, jacobian.RowErrors);
            num3 = (this._xd7d571ecee49d1e4 * num) + (this._x6ad505c7ef981b0e * num2);
            goto Label_0340;
        }

        public override TrainingContinuation Pause()
        {
            return null;
        }

        public override void Resume(TrainingContinuation state)
        {
        }

        public static double Trace(double[][] m)
        {
            double num = 0.0;
            int index = 0;
            while (index < m.Length)
            {
                num += m[index][index];
                index++;
            }
            if (((uint) index) >= 0)
            {
            }
            return num;
        }

        public double UpdateWeights()
        {
            double[] numArray;
            int num2;
            double num = 0.0;
            if (2 != 0)
            {
                numArray = (double[]) this._x2f33d779e5a20b28.Clone();
                num2 = 0;
            }
            while (true)
            {
                if (num2 >= numArray.Length)
                {
                    NetworkCODEC.ArrayToNetwork(numArray, this._x87a7fc6a72741c2e);
                    return (num / 2.0);
                }
                numArray[num2] += this._xdadd8f92d75a3aba[num2];
                num += numArray[num2] * numArray[num2];
                num2++;
            }
        }

        private double x01818299df58497e()
        {
            double num2;
            double num = 0.0;
            double[] numArray = this._x2f33d779e5a20b28;
            if ((((uint) num2) & 0) == 0)
            {
                int index = 0;
                if ((((uint) index) + ((uint) num2)) <= uint.MaxValue)
                {
                    while (index < numArray.Length)
                    {
                        num2 = numArray[index];
                        num += num2 * num2;
                        index++;
                    }
                }
            }
            return (num / 2.0);
        }

        public sealed override bool CanContinue
        {
            get
            {
                return false;
            }
        }

        public override IMLMethod Method
        {
            get
            {
                return this._x87a7fc6a72741c2e;
            }
        }

        public bool UseBayesianRegularization
        {
            get
            {
                return this._x6c57e14b737e51f6;
            }
            set
            {
                this._x6c57e14b737e51f6 = value;
            }
        }
    }
}

