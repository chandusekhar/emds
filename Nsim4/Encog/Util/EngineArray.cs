namespace Encog.Util
{
    using System;
    using System.Collections.Generic;

    public class EngineArray
    {
        public static bool[][] AllocateBool2D(int rows, int cols)
        {
            bool[][] flagArray = new bool[rows][];
            for (int i = 0; (i < rows) || (15 == 0); i++)
            {
                flagArray[i] = new bool[cols];
            }
            return flagArray;
        }

        public static double[][] AllocateDouble2D(int rows, int cols)
        {
            double[][] numArray = new double[rows][];
            int index = 0;
            while (index < rows)
            {
                numArray[index] = new double[cols];
                index++;
                if (((uint) cols) < 0)
                {
                    return numArray;
                }
            }
            return numArray;
        }

        public static int[] ArrayCopy(int[] input)
        {
            int[] dst = new int[input.Length];
            ArrayCopy(input, dst);
            return dst;
        }

        public static double[][] ArrayCopy(double[][] source)
        {
            double[][] numArray = AllocateDouble2D(source.Length, source[0].Length);
            for (int i = 0; i < source.Length; i++)
            {
                int index = 0;
                do
                {
                    while (index < source[0].Length)
                    {
                        numArray[i][index] = source[i][index];
                        index++;
                    }
                }
                while (((uint) i) < 0);
            }
            return numArray;
        }

        public static double[] ArrayCopy(double[] input)
        {
            double[] dst = new double[input.Length];
            ArrayCopy(input, dst);
            return dst;
        }

        public static void ArrayCopy(double[] src, double[] dst)
        {
            Array.Copy(src, dst, src.Length);
        }

        public static void ArrayCopy(double[] source, float[] target)
        {
            for (int i = 0; i < source.Length; i++)
            {
                target[i] = (float) source[i];
            }
        }

        public static void ArrayCopy(int[] src, int[] dst)
        {
            Array.Copy(src, dst, src.Length);
        }

        public static void ArrayCopy(float[] source, double[] target)
        {
            for (int i = 0; i < source.Length; i++)
            {
                target[i] = source[i];
            }
        }

        public static void ArrayCopy(double[] source, int sourceIndex, double[] output, int targetIndex, int size)
        {
            Array.Copy(source, sourceIndex, output, targetIndex, size);
        }

        public static bool Contains(int[] array, int target)
        {
            int index = 0;
            if (((uint) target) < 0)
            {
                goto Label_001E;
            }
            while (index < array.Length)
            {
                if (array[index] == target)
                {
                    return true;
                }
            Label_001E:
                index++;
            }
            return false;
        }

        internal static void Fill(double[] p, double v)
        {
            for (int i = 0; i < p.Length; i++)
            {
                p[i] = v;
            }
        }

        public static void Fill(double[] target, int v)
        {
            for (int i = 0; i < target.Length; i++)
            {
                target[i] = v;
            }
        }

        public static void Fill(float[] target, int v)
        {
            for (int i = 0; i < target.Length; i++)
            {
                target[i] = v;
            }
        }

        public static int FindStringInArray(string[] search, string searchFor)
        {
            int index = 0;
            while (true)
            {
                while (index >= search.Length)
                {
                    if (0 == 0)
                    {
                        return -1;
                    }
                }
                do
                {
                    if (search[index].Equals(searchFor))
                    {
                        return index;
                    }
                }
                while (0 != 0);
                index++;
            }
        }

        public static int IndexOfLargest(double[] data)
        {
            int index = -1;
            int num2 = 0;
            goto Label_003A;
        Label_0022:
            num2++;
            if ((((uint) index) & 0) == 0)
            {
            }
        Label_003A:
            if (num2 < data.Length)
            {
                while (index != -1)
                {
                    if (data[num2] <= data[index])
                    {
                        goto Label_0022;
                    }
                    if ((((uint) index) + ((uint) num2)) >= 0)
                    {
                        break;
                    }
                }
                index = num2;
                goto Label_0022;
            }
            return index;
        }

        public static double[] ListToDouble(IList<double> list)
        {
            double[] numArray = new double[list.Count];
            int num = 0;
            foreach (double num2 in list)
            {
                numArray[num++] = num2;
            }
            return numArray;
        }

        public static double Max(double[] weights)
        {
            double minValue = double.MinValue;
            int index = 0;
            if (0 == 0)
            {
            }
            while (index < weights.Length)
            {
                minValue = Math.Max(minValue, weights[index]);
                index++;
            }
            return minValue;
        }

        public static int MaxIndex(double[] data)
        {
            int num2;
            int index = -1;
            if ((((uint) index) - ((uint) num2)) <= uint.MaxValue)
            {
                goto Label_0084;
            }
            if ((((uint) index) & 0) == 0)
            {
                goto Label_003F;
            }
        Label_0031:
            index = num2;
        Label_0033:
            num2++;
        Label_0037:
            if (num2 < data.Length)
            {
                if (index != -1)
                {
                    goto Label_003F;
                }
                if ((((uint) num2) - ((uint) index)) >= 0)
                {
                    goto Label_0031;
                }
            }
            if ((((uint) num2) + ((uint) index)) <= uint.MaxValue)
            {
                return index;
            }
            goto Label_0084;
        Label_003F:
            if (data[num2] <= data[index])
            {
                goto Label_0033;
            }
            if (8 == 0)
            {
                goto Label_003F;
            }
            goto Label_0031;
        Label_0084:
            num2 = 0;
            goto Label_0037;
        }

        public static int MaxIndex(int[] data)
        {
            int num2;
            int index = -1;
            if ((((uint) num2) + ((uint) index)) <= uint.MaxValue)
            {
                goto Label_0067;
            }
            if (0 == 0)
            {
                goto Label_0021;
            }
        Label_001D:
            num2++;
        Label_0021:
            if (num2 < data.Length)
            {
                if (index != -1)
                {
                    if ((((uint) index) & 0) != 0)
                    {
                        return index;
                    }
                    if (data[num2] <= data[index])
                    {
                        goto Label_001D;
                    }
                }
                index = num2;
                goto Label_001D;
            }
            if ((((uint) index) + ((uint) index)) <= uint.MaxValue)
            {
                return index;
            }
        Label_0067:
            num2 = 0;
            goto Label_0021;
        }

        public static double Min(double[] weights)
        {
            double maxValue = double.MaxValue;
            for (int i = 0; i < weights.Length; i++)
            {
                maxValue = Math.Min(maxValue, weights[i]);
            }
            return maxValue;
        }

        public static void PutAll<TK, TV>(IDictionary<TK, TV> source, IDictionary<TK, TV> target)
        {
            foreach (KeyValuePair<TK, TV> pair in source)
            {
                target.Add(pair);
            }
        }

        public static double VectorProduct(double[] a, double[] b)
        {
            int length = a.Length;
            double num2 = 0.0;
            int index = 0;
            while (index < length)
            {
                num2 += a[index] * b[index];
                index++;
                if ((((uint) length) + ((uint) length)) >= 0)
                {
                }
            }
            return num2;
        }
    }
}

