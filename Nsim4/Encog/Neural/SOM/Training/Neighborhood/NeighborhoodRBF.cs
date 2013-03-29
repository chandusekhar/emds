namespace Encog.Neural.SOM.Training.Neighborhood
{
    using Encog.MathUtil.RBF;
    using Encog.Util;
    using System;

    public class NeighborhoodRBF : INeighborhoodFunction
    {
        private readonly int[] _x0ceec69a97f73617;
        private int[] _x3e04455c49638bd9;
        private readonly IRadialBasisFunction _x542ac40d5d0f20b7;

        public NeighborhoodRBF(int[] size, RBFEnum type)
        {
            if (-1 != 0)
            {
                RBFEnum enum2 = type;
                if (-2147483648 != 0)
                {
                    switch (enum2)
                    {
                        case RBFEnum.Gaussian:
                            this._x542ac40d5d0f20b7 = new GaussianFunction(2);
                            break;

                        case RBFEnum.Multiquadric:
                            this._x542ac40d5d0f20b7 = new MultiquadricFunction(2);
                            break;

                        case RBFEnum.InverseMultiquadric:
                            this._x542ac40d5d0f20b7 = new InverseMultiquadricFunction(2);
                            break;

                        case RBFEnum.MexicanHat:
                            this._x542ac40d5d0f20b7 = new MexicanHatFunction(2);
                            break;
                    }
                }
            }
            this._x0ceec69a97f73617 = size;
            this.x2d3eee42a645354a();
        }

        public NeighborhoodRBF(RBFEnum type, int x, int y)
        {
            int[] numArray;
            double[] numArray2;
            goto Label_0152;
        Label_000B:
            EngineArray.ArrayCopy(numArray2, this._x542ac40d5d0f20b7.Centers);
            this._x0ceec69a97f73617 = numArray;
            if (((uint) y) > uint.MaxValue)
            {
                goto Label_0122;
            }
            this.x2d3eee42a645354a();
            if ((((uint) y) + ((uint) y)) > uint.MaxValue)
            {
                goto Label_00EB;
            }
            if (-2 != 0)
            {
                return;
            }
            goto Label_0152;
        Label_0068:
            this._x542ac40d5d0f20b7.Width = 1.0;
        Label_00E4:
            if (8 != 0)
            {
                if (0 == 0)
                {
                    goto Label_000B;
                }
                goto Label_0129;
            }
        Label_00EB:
            numArray2[0] = 0.0;
            numArray2[1] = 0.0;
            double[] numArray3 = new double[] { 1.0, 1.0 };
        Label_0122:
            switch (type)
            {
                case RBFEnum.Gaussian:
                    this._x542ac40d5d0f20b7 = new GaussianFunction(2);
                    goto Label_0068;

                case RBFEnum.Multiquadric:
                    this._x542ac40d5d0f20b7 = new MultiquadricFunction(2);
                    goto Label_0068;

                case RBFEnum.InverseMultiquadric:
                    this._x542ac40d5d0f20b7 = new InverseMultiquadricFunction(2);
                    goto Label_0068;

                case RBFEnum.MexicanHat:
                    this._x542ac40d5d0f20b7 = new MexicanHatFunction(2);
                    if (((0 == 0) && (-1 != 0)) && (0 != 0))
                    {
                        goto Label_00E4;
                    }
                    goto Label_0068;

                default:
                    goto Label_0068;
            }
        Label_0129:
            numArray[0] = x;
            numArray[1] = y;
            numArray2 = new double[2];
            if ((((uint) y) - ((uint) y)) <= uint.MaxValue)
            {
                goto Label_00EB;
            }
            goto Label_000B;
        Label_0152:
            if ((((uint) x) - ((uint) x)) < 0)
            {
                goto Label_0068;
            }
            numArray = new int[2];
            goto Label_0129;
        }

        public virtual double Function(int currentNeuron, int bestNeuron)
        {
            int[] numArray3;
            int num;
            double[] x = new double[this._x3e04455c49638bd9.Length];
            int[] numArray2 = this.x631ed1e9c1e5a0df(currentNeuron);
            if ((((uint) num) + ((uint) num)) >= 0)
            {
                numArray3 = this.x631ed1e9c1e5a0df(bestNeuron);
                num = 0;
                goto Label_0014;
            }
        Label_0010:
            num++;
        Label_0014:
            if (num < numArray2.Length)
            {
                x[num] = numArray2[num] - numArray3[num];
                if ((((uint) currentNeuron) - ((uint) currentNeuron)) <= uint.MaxValue)
                {
                    goto Label_0010;
                }
            }
            return this._x542ac40d5d0f20b7.Calculate(x);
        }

        private void x2d3eee42a645354a()
        {
            int num2;
            this._x3e04455c49638bd9 = new int[this._x0ceec69a97f73617.Length];
            int index = 0;
        Label_0023:
            if (index < this._x0ceec69a97f73617.Length)
            {
                if (index != 0)
                {
                    if (index == 1)
                    {
                        num2 = this._x0ceec69a97f73617[0];
                    }
                    else
                    {
                        num2 = this._x3e04455c49638bd9[index - 1] * this._x0ceec69a97f73617[index - 1];
                    }
                    goto Label_0062;
                }
            }
            else if ((((uint) num2) - ((uint) num2)) <= uint.MaxValue)
            {
                return;
            }
            num2 = 0;
        Label_0062:
            this._x3e04455c49638bd9[index] = num2;
            if (8 == 0)
            {
                goto Label_0062;
            }
            index++;
            goto Label_0023;
        }

        private int[] x631ed1e9c1e5a0df(int xc0c4c459c6ccbd00)
        {
            int num;
            int num2;
            int num3;
            int[] numArray = new int[this._x3e04455c49638bd9.Length];
            if (0 == 0)
            {
                num = xc0c4c459c6ccbd00;
                num2 = this._x3e04455c49638bd9.Length - 1;
                goto Label_0040;
            }
        Label_0011:
            if ((((uint) xc0c4c459c6ccbd00) + ((uint) num3)) < 0)
            {
                goto Label_0046;
            }
            num3 = num;
        Label_002B:
            num -= this._x3e04455c49638bd9[num2] * num3;
            numArray[num2] = num3;
            num2--;
        Label_0040:
            if (num2 >= 0)
            {
                if (this._x3e04455c49638bd9[num2] <= 0)
                {
                    if ((((uint) num3) - ((uint) num)) < 0)
                    {
                        return numArray;
                    }
                    goto Label_0011;
                }
            }
            else
            {
                return numArray;
            }
        Label_0046:
            num3 = num / this._x3e04455c49638bd9[num2];
            goto Label_002B;
        }

        public virtual double Radius
        {
            get
            {
                return this._x542ac40d5d0f20b7.Width;
            }
            set
            {
                this._x542ac40d5d0f20b7.Width = value;
            }
        }

        public IRadialBasisFunction RBF
        {
            get
            {
                return this._x542ac40d5d0f20b7;
            }
        }
    }
}

