namespace Encog.MathUtil.Matrices
{
    using System;

    public class BiPolarUtil
    {
        public static double Bipolar2double(bool b)
        {
            if (b)
            {
                return 1.0;
            }
            return -1.0;
        }

        public static double[] Bipolar2double(bool[] b)
        {
            double[] numArray = new double[b.Length];
            for (int i = 0; i < b.Length; i++)
            {
                numArray[i] = Bipolar2double(b[i]);
            }
            return numArray;
        }

        public static double[][] Bipolar2double(bool[][] b)
        {
            int num;
            double[][] numArray = new double[b.Length][];
            goto Label_0065;
        Label_001B:
            if (num >= b.Length)
            {
                goto Label_005E;
            }
            numArray[num] = new double[b[num].Length];
            int index = 0;
        Label_000F:
            if (index < b[num].Length)
            {
                numArray[num][index] = Bipolar2double(b[num][index]);
                if (((((uint) index) + ((uint) index)) < 0) || (0 == 0))
                {
                    index++;
                    goto Label_000F;
                }
            }
            else
            {
                num++;
                goto Label_001B;
            }
        Label_005E:
            if (-2147483648 != 0)
            {
                return numArray;
            }
        Label_0065:
            num = 0;
            goto Label_001B;
        }

        public static bool Double2bipolar(double d)
        {
            return (d > 0.0);
        }

        public static bool[] Double2bipolar(double[] d)
        {
            bool[] flagArray = new bool[d.Length];
            for (int i = 0; i < d.Length; i++)
            {
                flagArray[i] = Double2bipolar(d[i]);
            }
            return flagArray;
        }

        public static bool[][] Double2bipolar(double[][] d)
        {
            bool[][] flagArray = new bool[d.Length][];
            int index = 0;
            while (index < d.Length)
            {
                flagArray[index] = new bool[d[index].Length];
                int num2 = 0;
                while (num2 < d[index].Length)
                {
                    flagArray[index][num2] = Double2bipolar(d[index][num2]);
                    num2++;
                }
                index++;
                if ((((uint) num2) + ((uint) num2)) >= 0)
                {
                }
            }
            return flagArray;
        }

        public static double NormalizeBinary(double d)
        {
            if (d > 0.0)
            {
                return 1.0;
            }
            return 0.0;
        }

        public static double ToBinary(double d)
        {
            return ((d + 1.0) / 2.0);
        }

        public static double ToBiPolar(double d)
        {
            return ((2.0 * NormalizeBinary(d)) - 1.0);
        }

        public static double ToNormalizedBinary(double d)
        {
            return NormalizeBinary(ToBinary(d));
        }
    }
}

