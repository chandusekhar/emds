namespace Encog.Util.Error
{
    using Encog.MathUtil.Error;
    using Encog.ML;
    using Encog.ML.Data;
    using System;

    public class CalculateRegressionError
    {
        public static double CalculateError(IMLRegression method, IMLDataSet data)
        {
            ErrorCalculation calculation = new ErrorCalculation();
            while (method is IMLContext)
            {
                ((IMLContext) method).ClearContext();
                break;
            }
            foreach (IMLDataPair pair in data)
            {
                IMLData data2 = method.Compute(pair.Input);
                calculation.UpdateError(data2.Data, pair.Ideal.Data, pair.Significance);
            }
            return calculation.Calculate();
        }
    }
}

