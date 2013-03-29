namespace Encog.Neural.SOM.Training.Neighborhood
{
    using Encog.MathUtil.RBF;
    using Encog.Neural;
    using System;

    public class NeighborhoodRBF1D : INeighborhoodFunction
    {
        private readonly IRadialBasisFunction _x69265a675586f26d;

        public NeighborhoodRBF1D(IRadialBasisFunction radial)
        {
            this._x69265a675586f26d = radial;
        }

        public NeighborhoodRBF1D(RBFEnum type)
        {
            switch (type)
            {
                case RBFEnum.Gaussian:
                    this._x69265a675586f26d = new GaussianFunction(1);
                    break;

                case RBFEnum.Multiquadric:
                    this._x69265a675586f26d = new MultiquadricFunction(1);
                    break;

                case RBFEnum.InverseMultiquadric:
                    this._x69265a675586f26d = new InverseMultiquadricFunction(1);
                    if (1 == 0)
                    {
                        goto Label_0032;
                    }
                    break;

                case RBFEnum.MexicanHat:
                    this._x69265a675586f26d = new MexicanHatFunction(1);
                    break;

                default:
                    throw new NeuralNetworkError("Unknown RBF type: " + type);
            }
        Label_001E:
            this._x69265a675586f26d.Width = 1.0;
        Label_0032:
            if (-1 == 0)
            {
                goto Label_001E;
            }
        }

        public virtual double Function(int currentNeuron, int bestNeuron)
        {
            double[] x = new double[] { (double) (currentNeuron - bestNeuron) };
            return this._x69265a675586f26d.Calculate(x);
        }

        public virtual double Radius
        {
            get
            {
                return this._x69265a675586f26d.Width;
            }
            set
            {
                this._x69265a675586f26d.Width = value;
            }
        }
    }
}

