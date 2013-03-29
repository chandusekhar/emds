namespace Encog.Util.CSV
{
    using Encog.Persist;
    using System;
    using System.Text;

    public class NumberList
    {
        private NumberList()
        {
        }

        public static double[] FromList(CSVFormat format, string str)
        {
            if (str.Trim().Length != 0)
            {
                string[] strArray = str.Split(new char[] { format.Separator });
                int length = strArray.Length;
                double[] numArray = new double[length];
                for (int i = 0; i < strArray.Length; i++)
                {
                    try
                    {
                        string str2 = strArray[i];
                        numArray[i] = format.Parse(str2);
                    }
                    catch (Exception exception)
                    {
                        throw new PersistError(exception);
                    }
                }
                return numArray;
            }
            return new double[0];
        }

        public static int[] FromListInt(CSVFormat format, string str)
        {
            if (str.Trim().Length != 0)
            {
                string[] strArray = str.Split(new char[] { format.Separator });
                int length = strArray.Length;
                while (true)
                {
                    int num3;
                    int[] numArray = new int[length];
                    if ((((uint) num3) + ((uint) num3)) > uint.MaxValue)
                    {
                        return numArray;
                    }
                    int index = 0;
                    if (2 != 0)
                    {
                        while (index < strArray.Length)
                        {
                            try
                            {
                                string s = strArray[index];
                                numArray[index] = int.Parse(s);
                            }
                            catch (Exception exception)
                            {
                                throw new PersistError(exception);
                            }
                            index++;
                        }
                        return numArray;
                    }
                }
            }
            return new int[0];
        }

        public static void ToList(CSVFormat format, StringBuilder result, double[] data)
        {
            ToList(format, 20, result, data);
        }

        public static void ToList(CSVFormat format, int precision, StringBuilder result, double[] data)
        {
            int num;
            result.Length = 0;
            if ((((uint) precision) + ((uint) num)) <= uint.MaxValue)
            {
                goto Label_007B;
            }
            if (0 == 0)
            {
                goto Label_0064;
            }
        Label_0022:
            if ((((uint) num) & 0) != 0)
            {
                goto Label_0064;
            }
        Label_0036:
            result.Append(format.Format(data[num], precision));
            num++;
        Label_004B:
            if (num < data.Length)
            {
                goto Label_0064;
            }
            if (((uint) num) >= 0)
            {
                return;
            }
            goto Label_007B;
        Label_0055:
            result.Append(format.Separator);
            goto Label_0022;
        Label_0064:
            if (num != 0)
            {
                goto Label_0055;
            }
            goto Label_0036;
        Label_007B:
            num = 0;
            if (0 != 0)
            {
                goto Label_0055;
            }
            goto Label_004B;
        }

        public static void ToListInt(CSVFormat format, StringBuilder result, int[] data)
        {
            result.Length = 0;
            for (int i = 0; i < data.Length; i++)
            {
                if (i != 0)
                {
                    result.Append(format.Separator);
                }
                result.Append(data[i]);
            }
        }
    }
}

