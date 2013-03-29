namespace Encog.MathUtil
{
    using System;

    public static class Convert
    {
        public static double String2Double(string str)
        {
            double num = 0.0;
            try
            {
                if (str != null)
                {
                    num = double.Parse(str);
                }
            }
            catch (Exception)
            {
                num = 0.0;
            }
            return num;
        }

        public static int String2Int(string str)
        {
            int num = 0;
            try
            {
                if (str != null)
                {
                    num = int.Parse(str);
                }
            }
            catch (Exception)
            {
                num = 0;
            }
            return num;
        }
    }
}

