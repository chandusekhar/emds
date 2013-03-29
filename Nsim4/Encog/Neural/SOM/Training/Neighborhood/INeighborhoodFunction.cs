namespace Encog.Neural.SOM.Training.Neighborhood
{
    using System;

    public interface INeighborhoodFunction
    {
        double Function(int currentNeuron, int bestNeuron);

        double Radius { get; set; }
    }
}

