namespace Encog.Neural.SOM.Training.Neighborhood
{
    using System;

    public class NeighborhoodSingle : INeighborhoodFunction
    {
        public virtual double Function(int currentNeuron, int bestNeuron)
        {
            if (currentNeuron == bestNeuron)
            {
                return 1.0;
            }
            return 0.0;
        }

        public virtual double Radius
        {
            get
            {
                return 1.0;
            }
            set
            {
            }
        }
    }
}

