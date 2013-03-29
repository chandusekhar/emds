namespace Encog.MathUtil.Matrices.Decomposition
{
    using Encog.MathUtil.Matrices;
    using System;

    public class SingularValueDecomposition
    {
        private readonly double[][] x4ee0ab3c3a018360;
        private readonly int x57e9faf3ffdc07cc;
        private readonly int x6088325dec1baa2a;
        private readonly double[][] x6ab88896ef0701c9;
        private readonly double[] xe4115acdf4fbfccc;

        public SingularValueDecomposition(Matrix Arg)
        {
            // This item is obfuscated and can not be translated.
        }

        public double Cond()
        {
            return (this.xe4115acdf4fbfccc[0] / this.xe4115acdf4fbfccc[Math.Min(this.x6088325dec1baa2a, this.x57e9faf3ffdc07cc) - 1]);
        }

        public double Norm2()
        {
            return this.xe4115acdf4fbfccc[0];
        }

        public int Rank()
        {
            double num2;
            int num4;
            double num = Math.Pow(2.0, -52.0);
            if (((uint) num4) >= 0)
            {
                num2 = (Math.Max(this.x6088325dec1baa2a, this.x57e9faf3ffdc07cc) * this.xe4115acdf4fbfccc[0]) * num;
            }
            int num3 = 0;
        Label_0064:
            num4 = 0;
            while (num4 < this.xe4115acdf4fbfccc.Length)
            {
                if (this.xe4115acdf4fbfccc[num4] > num2)
                {
                    num3++;
                }
                num4++;
                if ((((uint) num2) & 0) != 0)
                {
                    goto Label_0064;
                }
            }
            return num3;
        }

        public Matrix S
        {
            get
            {
                double[][] data;
                int num;
                int num2;
                Matrix matrix = new Matrix(this.x57e9faf3ffdc07cc, this.x57e9faf3ffdc07cc);
                if (((uint) num) >= 0)
                {
                    data = matrix.Data;
                    num = 0;
                    goto Label_0047;
                }
            Label_0026:
                while (num2 < this.x57e9faf3ffdc07cc)
                {
                    data[num][num2] = 0.0;
                    num2++;
                }
                if (-1 == 0)
                {
                    goto Label_0026;
                }
                data[num][num] = this.xe4115acdf4fbfccc[num];
                num++;
            Label_0047:
                if (num < this.x57e9faf3ffdc07cc)
                {
                    num2 = 0;
                    if ((((uint) num) & 0) != 0)
                    {
                        return matrix;
                    }
                }
                else if ((((uint) num) | 2) != 0)
                {
                    return matrix;
                }
                goto Label_0026;
            }
        }

        public double[] SingularValues
        {
            get
            {
                return this.xe4115acdf4fbfccc;
            }
        }

        public Matrix U
        {
            get
            {
                return new Matrix(this.x4ee0ab3c3a018360);
            }
        }

        public Matrix V
        {
            get
            {
                return new Matrix(this.x6ab88896ef0701c9);
            }
        }
    }
}

