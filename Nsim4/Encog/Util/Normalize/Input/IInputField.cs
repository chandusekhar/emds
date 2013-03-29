namespace Encog.Util.Normalize.Input
{
    using System;

    public interface IInputField
    {
        void ApplyMinMax(double d);
        double GetValue(int i);

        double CurrentValue { get; set; }

        double Max { get; set; }

        double Min { get; set; }

        bool UsedForNetworkInput { get; }
    }
}

