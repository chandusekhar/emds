namespace Encog.Neural.SOM.Training.Neighborhood
{
    using System;

    public class NeighborhoodBubble : INeighborhoodFunction
    {
        private double _xd6ed827fa7f40115;

        public NeighborhoodBubble(int radius)
        {
            this._xd6ed827fa7f40115 = radius;
        }

        public double Function(int currentNeuron, int bestNeuron)
        {
            int num = Math.Abs((int) (bestNeuron - currentNeuron));
            if ((((uint) currentNeuron) & 0) != 0)
            {
                if ((((uint) bestNeuron) + ((uint) bestNeuron)) < 0)
                {
                    goto Label_0017;
                }
                goto Label_0067;
            }
            if ((((uint) num) & 0) == 0)
            {
                goto Label_0017;
            }
        Label_000B:
            return 1.0;
        Label_0017:
            if (num <= this._xd6ed827fa7f40115)
            {
                goto Label_000B;
            }
        Label_0067:
            return 0.0;
        }

        public virtual double Radius
        {
            get
            {
                return this._xd6ed827fa7f40115;
            }
            set
            {
                this._xd6ed827fa7f40115 = value;
            }
        }
    }
}

