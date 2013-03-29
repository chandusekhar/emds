namespace Encog.Neural.Networks.Structure
{
    using Encog.ML;
    using Encog.Neural;
    using Encog.Neural.Networks;
    using System;

    public static class NetworkCODEC
    {
        private const string xdc1af3a17717bf0a = "This machine learning method cannot be encoded:";

        public static void ArrayToNetwork(double[] array, IMLMethod network)
        {
            if (!(network is IMLEncodable))
            {
                throw new NeuralNetworkError("This machine learning method cannot be encoded:" + network.GetType().FullName);
            }
            ((IMLEncodable) network).DecodeFromArray(array);
        }

        public static bool Equals(BasicNetwork network1, BasicNetwork network2)
        {
            return Equals(network1, network2, 10);
        }

        public static bool Equals(BasicNetwork network1, BasicNetwork network2, int precision)
        {
            double num;
            int num2;
            long num3;
            double[] numArray = NetworkToArray(network1);
            double[] numArray2 = NetworkToArray(network2);
            if (numArray.Length == numArray2.Length)
            {
                num = Math.Pow(10.0, (double) precision);
                if (double.IsInfinity(num) || (num > 9.2233720368547758E+18))
                {
                    throw new NeuralNetworkError("Precision of " + precision + " decimal places is not supported.");
                }
            Label_0052:
                num2 = 0;
                goto Label_001A;
                if ((((uint) num2) + ((uint) num)) < 0)
                {
                    goto Label_0100;
                }
                if ((((uint) precision) - ((uint) num3)) >= 0)
                {
                    if (((uint) num) >= 0)
                    {
                        goto Label_0052;
                    }
                    goto Label_0025;
                }
            }
            return false;
        Label_001A:
            if (num2 >= numArray.Length)
            {
                goto Label_0100;
            }
        Label_0025:
            num3 = (long) (numArray[num2] * num);
            long num4 = (long) (numArray2[num2] * num);
            if (num3 != num4)
            {
                return false;
            }
            num2++;
            goto Label_001A;
        Label_0100:
            return true;
        }

        public static int NetworkSize(IMLMethod network)
        {
            if (!(network is IMLEncodable))
            {
                throw new NeuralNetworkError("This machine learning method cannot be encoded:" + network.GetType().FullName);
            }
            return ((IMLEncodable) network).EncodedArrayLength();
        }

        public static double[] NetworkToArray(IMLMethod network)
        {
            int num = NetworkSize(network);
            if (!(network is IMLEncodable))
            {
                throw new NeuralNetworkError("This machine learning method cannot be encoded:" + network.GetType().FullName);
            }
            double[] encoded = new double[num];
            ((IMLEncodable) network).EncodeToArray(encoded);
            return encoded;
        }
    }
}

