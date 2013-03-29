namespace Encog.Util.Logging
{
    using Encog.MathUtil.Matrices;
    using System;
    using System.Text;

    public class DumpMatrix
    {
        public const int MaxPrecis = 3;

        private DumpMatrix()
        {
        }

        public static string DumpArray(double[] d)
        {
            int num;
            StringBuilder builder = new StringBuilder();
            if ((((uint) num) | 2) != 0)
            {
                if (-2147483648 != 0)
                {
                    builder.Append("[");
                    num = 0;
                }
                goto Label_0032;
            }
            if (0 == 0)
            {
                goto Label_0032;
            }
        Label_0021:
            if (num != 0)
            {
                builder.Append(",");
                if ((((uint) num) | uint.MaxValue) == 0)
                {
                    goto Label_0021;
                }
            }
            builder.Append(d[num]);
            num++;
        Label_0032:
            if (num < d.Length)
            {
                goto Label_0021;
            }
            builder.Append("]");
            return builder.ToString();
        }

        public static string DumpMatrixString(Matrix matrix)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("==");
        Label_0076:
            builder.Append(matrix.ToString());
            builder.Append("==\n");
            int num = 0;
        Label_001E:
            if (num < matrix.Rows)
            {
                builder.Append("  [");
                for (int i = 0; i < matrix.Cols; i++)
                {
                    if (i != 0)
                    {
                        builder.Append(",");
                    }
                    builder.Append(matrix[num, i]);
                }
            }
            else
            {
                return builder.ToString();
            }
            if (0 == 0)
            {
                builder.Append("]\n");
                num++;
                goto Label_001E;
            }
            goto Label_0076;
        }
    }
}

