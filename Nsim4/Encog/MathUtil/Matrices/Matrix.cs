namespace Encog.MathUtil.Matrices
{
    using Encog.MathUtil;
    using Encog.MathUtil.Matrices.Decomposition;
    using Encog.MathUtil.Randomize;
    using System;
    using System.Reflection;

    [Serializable]
    public class Matrix
    {
        private readonly double[][] matrix;

        public Matrix(bool[][] sourceMatrix)
        {
            int num2;
            this.matrix = new double[sourceMatrix.Length][];
            int index = 0;
            goto Label_001B;
        Label_000E:
            if (num2 < this.Cols)
            {
                if (sourceMatrix[index][num2])
                {
                    this.matrix[index][num2] = 1.0;
                    if ((((uint) num2) - ((uint) index)) > uint.MaxValue)
                    {
                        return;
                    }
                    goto Label_005D;
                }
                goto Label_004A;
            }
            index++;
        Label_001B:
            if (index < this.Rows)
            {
                this.matrix[index] = new double[sourceMatrix[index].Length];
                num2 = 0;
                goto Label_000E;
            }
            if ((((uint) num2) + ((uint) index)) >= 0)
            {
                return;
            }
            goto Label_005D;
        Label_004A:
            this.matrix[index][num2] = -1.0;
        Label_005D:
            num2++;
            if (0 != 0)
            {
                goto Label_004A;
            }
            goto Label_000E;
        }

        public Matrix(double[][] sourceMatrix)
        {
            int num;
            int num2;
            this.matrix = new double[sourceMatrix.Length][];
            if (((uint) num2) <= uint.MaxValue)
            {
                goto Label_0073;
            }
        Label_0020:
            while (num2 < this.Cols)
            {
                this.matrix[num][num2] = sourceMatrix[num][num2];
                num2++;
            }
            num++;
        Label_002D:
            if (num < this.Rows)
            {
                this.matrix[num] = new double[sourceMatrix[num].Length];
                if (1 == 0)
                {
                    goto Label_0073;
                }
            }
            else
            {
                if ((((uint) num) + ((uint) num2)) >= 0)
                {
                    return;
                }
                goto Label_0073;
            }
            num2 = 0;
            goto Label_0020;
        Label_0073:
            num = 0;
            if ((((uint) num) + ((uint) num)) > uint.MaxValue)
            {
                return;
            }
            goto Label_002D;
        }

        public Matrix(int rows, int cols)
        {
            int num;
            if ((((uint) cols) <= uint.MaxValue) && (((uint) cols) >= 0))
            {
                this.matrix = new double[rows][];
                num = 0;
                if (0 != 0)
                {
                    return;
                }
            }
            while (num < rows)
            {
                this.matrix[num] = new double[cols];
                num++;
            }
        }

        public void Add(Matrix matrix)
        {
            int num2;
            int row = 0;
            if (0 != 0)
            {
            }
            do
            {
                if (row < this.Rows)
                {
                    num2 = 0;
                    if (((uint) num2) <= uint.MaxValue)
                    {
                        while (num2 < this.Cols)
                        {
                            this.Add(row, num2, matrix[row, num2]);
                            num2++;
                        }
                        row++;
                    }
                }
                else
                {
                    return;
                }
            }
            while (((uint) num2) <= uint.MaxValue);
        }

        public void Add(int row, int col, double value_ren)
        {
            this.Validate(row, col);
            double num = this.matrix[row][col] + value_ren;
            this.matrix[row][col] = num;
        }

        public void Clear()
        {
            int index = 0;
            while (true)
            {
                if (index < this.Rows)
                {
                    for (int i = 0; i < this.Cols; i++)
                    {
                        this.matrix[index][i] = 0.0;
                    }
                }
                else
                {
                    return;
                }
                index++;
            }
        }

        public object Clone()
        {
            return new Matrix(this.matrix);
        }

        public static Matrix CreateColumnMatrix(double[] input)
        {
            int num;
            double[][] sourceMatrix = new double[input.Length][];
        Label_0018:
            num = 0;
        Label_000F:
            if (num < sourceMatrix.Length)
            {
                do
                {
                    sourceMatrix[num] = new double[1];
                }
                while ((((uint) num) - ((uint) num)) < 0);
                sourceMatrix[num][0] = input[num];
                if (4 != 0)
                {
                    num++;
                    goto Label_000F;
                }
            }
            else if (0 != 0)
            {
                goto Label_0018;
            }
            return new Matrix(sourceMatrix);
        }

        public static Matrix CreateRowMatrix(double[] input)
        {
            int num;
            double[][] sourceMatrix = new double[1][];
            if ((((uint) num) - ((uint) num)) <= uint.MaxValue)
            {
                sourceMatrix[0] = new double[input.Length];
                num = 0;
            }
            while (num < input.Length)
            {
                do
                {
                    sourceMatrix[0][num] = input[num];
                }
                while (((uint) num) < 0);
                num++;
            }
            return new Matrix(sourceMatrix);
        }

        public bool equals(Matrix matrix, int precision)
        {
            double num;
            double[][] data;
            int num2;
            int num3;
            if (precision >= 0)
            {
                num = Math.Pow(10.0, (double) precision);
                if (((uint) num2) >= 0)
                {
                    if (double.IsInfinity(num))
                    {
                        goto Label_0125;
                    }
                    if ((((uint) num3) + ((uint) num3)) < 0)
                    {
                        goto Label_002A;
                    }
                }
                goto Label_0082;
            }
            goto Label_015E;
        Label_000C:
            num3++;
        Label_0010:
            if (num3 < this.Cols)
            {
                goto Label_002A;
            }
            num2++;
        Label_001D:
            if (num2 < this.Rows)
            {
                num3 = 0;
                goto Label_00E1;
            }
            goto Label_00F6;
        Label_002A:
            if (((long) (this.matrix[num2][num3] * precision)) == ((long) (data[num2][num3] * precision)))
            {
                goto Label_000C;
            }
            if ((((uint) precision) + ((uint) num3)) <= uint.MaxValue)
            {
                return false;
            }
        Label_0062:
            num2 = 0;
            goto Label_001D;
        Label_0082:
            if (num > 9.2233720368547758E+18)
            {
                goto Label_0125;
            }
        Label_0091:
            precision = (int) Math.Pow(10.0, (double) precision);
            if ((((uint) num) - ((uint) num3)) < 0)
            {
                goto Label_000C;
            }
            data = matrix.Data;
            if ((((uint) precision) - ((uint) precision)) >= 0)
            {
                goto Label_0062;
            }
        Label_00E1:
            if (((uint) num2) <= uint.MaxValue)
            {
                goto Label_0010;
            }
        Label_00F6:
            if (((uint) precision) >= 0)
            {
                return true;
            }
            if ((((uint) num2) + ((uint) num2)) >= 0)
            {
                goto Label_015E;
            }
            goto Label_0082;
        Label_0125:
            throw new MatrixError("Precision of " + precision + " decimal places is not supported.");
            if (0 == 0)
            {
                goto Label_0091;
            }
            goto Label_0082;
        Label_015E:
            throw new MatrixError("Precision can't be a negative number.");
        }

        public override bool Equals(object other)
        {
            return ((other is Matrix) && this.equals((Matrix) other, 10));
        }

        public int FromPackedArray(double[] array, int index)
        {
            int num2;
            int num = 0;
            if ((((uint) num2) + ((uint) num2)) <= uint.MaxValue)
            {
                goto Label_005A;
            }
            if ((((uint) num2) + ((uint) num)) >= 0)
            {
                goto Label_007B;
            }
        Label_004D:
            while (num2 < this.Cols)
            {
                this.matrix[num][num2] = array[index++];
                num2++;
            }
            num++;
        Label_005A:
            while ((num >= this.Rows) && ((((uint) index) - ((uint) num2)) <= uint.MaxValue))
            {
                if ((((uint) num2) - ((uint) index)) <= uint.MaxValue)
                {
                    return index;
                }
            }
        Label_007B:
            num2 = 0;
            if (((uint) num2) <= uint.MaxValue)
            {
            }
            goto Label_004D;
        }

        public double[][] GetArrayCopy()
        {
            int num2;
            double[][] numArray = new double[this.Rows][];
            if ((((uint) num2) - ((uint) num2)) < 0)
            {
                goto Label_003E;
            }
            int index = 0;
            goto Label_001F;
        Label_0012:
            if (num2 < this.Cols)
            {
                goto Label_003E;
            }
            index++;
        Label_001F:
            if (index >= this.Rows)
            {
                return numArray;
            }
            numArray[index] = new double[this.Cols];
            num2 = 0;
            goto Label_0012;
        Label_003E:
            numArray[index][num2] = this.matrix[index][num2];
            num2++;
            goto Label_0012;
        }

        public Matrix GetCol(int col)
        {
            double[][] numArray;
            int num;
            if (col > this.Cols)
            {
                throw new MatrixError("Can't get column #" + col + " because it does not exist.");
            }
            do
            {
                numArray = new double[this.Rows][];
            }
            while ((((uint) num) | 15) == 0);
            for (num = 0; num < this.Rows; num++)
            {
                numArray[num] = new double[] { this.matrix[num][col] };
            }
            return new Matrix(numArray);
        }

        public override int GetHashCode()
        {
            return (this.Rows + this.Cols);
        }

        public Matrix GetMatrix(int[] r, int[] c)
        {
            Matrix matrix = new Matrix(r.Length, c.Length);
            double[][] data = matrix.Data;
            try
            {
                int num2;
                int index = 0;
                goto Label_0025;
            Label_0017:
                num2++;
            Label_001B:
                if (num2 < c.Length)
                {
                    goto Label_0033;
                }
                index++;
            Label_0025:
                if (index >= r.Length)
                {
                    return matrix;
                }
                num2 = 0;
                goto Label_001B;
            Label_0033:
                data[index][num2] = this.matrix[r[index]][c[num2]];
                goto Label_0017;
            }
            catch (IndexOutOfRangeException)
            {
                throw new MatrixError("Submatrix indices");
            }
            return matrix;
        }

        public Matrix GetMatrix(int i0, int i1, int[] c)
        {
            Matrix matrix = new Matrix((i1 - i0) + 1, c.Length);
            double[][] data = matrix.Data;
            try
            {
                int num2;
                int index = i0;
                if ((((uint) num2) | uint.MaxValue) != 0)
                {
                    goto Label_0039;
                }
            Label_002F:
                if (num2 < c.Length)
                {
                    goto Label_0055;
                }
                index++;
            Label_0039:
                while (index > i1)
                {
                    if (((uint) index) <= uint.MaxValue)
                    {
                        return matrix;
                    }
                }
                num2 = 0;
                goto Label_002F;
            Label_0055:
                data[index - i0][num2] = this.matrix[index][c[num2]];
                num2++;
                if (0 == 0)
                {
                }
                goto Label_002F;
            }
            catch (IndexOutOfRangeException)
            {
                throw new MatrixError("Submatrix indices");
            }
            return matrix;
        }

        public Matrix GetMatrix(int[] r, int j0, int j1)
        {
            Matrix matrix = new Matrix(r.Length, (j1 - j0) + 1);
            double[][] data = matrix.Data;
            try
            {
                int num2;
                int index = 0;
                goto Label_0037;
            Label_0019:
                num2++;
            Label_001D:
                if (num2 <= j1)
                {
                    goto Label_005B;
                }
                if (((uint) index) > uint.MaxValue)
                {
                    goto Label_001D;
                }
                index++;
            Label_0037:
                while (index >= r.Length)
                {
                    if ((((uint) num2) - ((uint) num2)) <= uint.MaxValue)
                    {
                        return matrix;
                    }
                }
                num2 = j0;
                goto Label_001D;
            Label_005B:
                data[index][num2 - j0] = this.matrix[r[index]][num2];
                if (0 == 0)
                {
                    goto Label_0019;
                }
            }
            catch (IndexOutOfRangeException)
            {
                throw new MatrixError("Submatrix indices");
            }
            return matrix;
        }

        public Matrix GetMatrix(int i0, int i1, int j0, int j1)
        {
            Matrix matrix = new Matrix((i1 - i0) + 1, (j1 - j0) + 1);
            double[][] data = matrix.Data;
            try
            {
                int num2;
                int index = i0;
                if (0 != 0)
                {
                }
            Label_001D:
                if (index <= i1)
                {
                    goto Label_0046;
                }
                return matrix;
            Label_0023:
                if (((uint) i1) < 0)
                {
                    goto Label_003E;
                }
                num2++;
            Label_0039:
                if (num2 <= j1)
                {
                    goto Label_004A;
                }
            Label_003E:
                index++;
                goto Label_001D;
            Label_0046:
                num2 = j0;
                goto Label_0039;
            Label_004A:
                data[index - i0][num2 - j0] = this.matrix[index][num2];
                if (((uint) index) <= uint.MaxValue)
                {
                    goto Label_0023;
                }
                goto Label_001D;
            }
            catch (IndexOutOfRangeException)
            {
                throw new MatrixError("Submatrix indices");
            }
            return matrix;
        }

        public Matrix GetRow(int row)
        {
            double[][] numArray;
            int num;
            if (row > this.Rows)
            {
                throw new MatrixError("Can't get row #" + row + " because it does not exist.");
            }
            do
            {
                numArray = new double[][] { new double[this.Cols] };
            }
            while ((((uint) num) + ((uint) row)) > uint.MaxValue);
            num = 0;
            while (true)
            {
                if (num < this.Cols)
                {
                    numArray[0][num] = this.matrix[row][num];
                }
                else
                {
                    return new Matrix(numArray);
                }
                num++;
            }
        }

        public Matrix Inverse()
        {
            return this.Solve(MatrixMath.Identity(this.Rows));
        }

        public bool IsVector()
        {
            return ((this.Rows == 1) || (this.Cols == 1));
        }

        public bool IsZero()
        {
            int index = 0;
            while (true)
            {
                if (index < this.Rows)
                {
                    int num2 = 0;
                    if (0 == 0)
                    {
                        while (num2 < this.Cols)
                        {
                            if (this.matrix[index][num2] != 0.0)
                            {
                                return false;
                            }
                            num2++;
                        }
                        index++;
                    }
                }
                else if (((uint) index) >= 0)
                {
                    return true;
                }
            }
        }

        public void Multiply(double[] vector, double[] result)
        {
            int num2;
            int index = 0;
        Label_0055:
            if (((uint) num2) <= uint.MaxValue)
            {
            }
        Label_0038:
            if (index < this.Rows)
            {
                result[index] = 0.0;
                num2 = 0;
                if ((((uint) num2) + ((uint) index)) <= uint.MaxValue)
                {
                    while (num2 < this.Cols)
                    {
                        result[index] += this.matrix[index][num2] * vector[num2];
                        num2++;
                    }
                    index++;
                    goto Label_0038;
                }
            }
            else if ((((uint) index) & 0) != 0)
            {
                goto Label_0055;
            }
        }

        public void Ramdomize(double min, double max)
        {
            int index = 0;
        Label_002C:
            if (index < this.Rows)
            {
                int num2 = 0;
                if ((((uint) index) <= uint.MaxValue) && ((((uint) index) - ((uint) num2)) >= 0))
                {
                    while (num2 < this.Cols)
                    {
                        this.matrix[index][num2] = (ThreadSafeRandom.NextDouble() * (max - min)) + min;
                        num2++;
                    }
                    index++;
                    goto Label_002C;
                }
            }
        }

        public void Randomize(double min, double max)
        {
            int num2;
            int index = 0;
        Label_000B:
            while (index >= this.Rows)
            {
                if ((((uint) min) - ((uint) num2)) >= 0)
                {
                    return;
                }
            }
            num2 = 0;
            if (((uint) min) <= uint.MaxValue)
            {
                goto Label_0059;
            }
        Label_0044:
            this.matrix[index][num2] = RangeRandomizer.Randomize(min, max);
            num2++;
        Label_0059:
            if (num2 < this.Cols)
            {
                goto Label_0044;
            }
            if ((((uint) max) + ((uint) index)) <= uint.MaxValue)
            {
                index++;
            }
            goto Label_000B;
        }

        public void Set(Matrix other)
        {
            double[][] numArray2;
            double[][] data = this.Data;
        Label_003A:
            numArray2 = other.Data;
            int index = 0;
        Label_0016:
            if (index >= this.Rows)
            {
                if (0 == 0)
                {
                    return;
                }
            }
            else
            {
                for (int i = 0; i < this.Cols; i++)
                {
                    data[index][i] = numArray2[index][i];
                }
                index++;
                goto Label_0016;
            }
            goto Label_003A;
        }

        public void Set(double value_ren)
        {
            for (int i = 0; i < this.Rows; i++)
            {
                int index = 0;
                if (1 != 0)
                {
                }
                while (index < this.Cols)
                {
                    this.matrix[i][index] = value_ren;
                    if ((((uint) i) - ((uint) value_ren)) < 0)
                    {
                        return;
                    }
                    index++;
                }
            }
        }

        public void SetMatrix(int[] r, int[] c, Matrix x)
        {
            try
            {
                int num2;
                int index = 0;
            Label_0004:
                if (index < r.Length)
                {
                    goto Label_002C;
                }
                if (((uint) num2) > uint.MaxValue)
                {
                    goto Label_0046;
                }
                return;
            Label_001E:
                if (num2 < c.Length)
                {
                    goto Label_0030;
                }
                index++;
                goto Label_004C;
            Label_002C:
                num2 = 0;
                goto Label_001E;
            Label_0030:
                this.matrix[r[index]][c[num2]] = x[index, num2];
            Label_0046:
                num2++;
                goto Label_001E;
            Label_004C:
                if (0 == 0)
                {
                    goto Label_0004;
                }
            }
            catch (IndexOutOfRangeException)
            {
                throw new MatrixError("Submatrix indices");
            }
        }

        public void SetMatrix(int i0, int i1, int[] c, Matrix x)
        {
            try
            {
                int num2;
                int index = i0;
                goto Label_0029;
            Label_0004:
                this.matrix[index][c[num2]] = x[index - i0, num2];
                num2++;
            Label_001F:
                if (num2 < c.Length)
                {
                    goto Label_0004;
                }
                index++;
            Label_0029:
                if (index <= i1)
                {
                    num2 = 0;
                    goto Label_001F;
                }
            }
            catch (IndexOutOfRangeException)
            {
                throw new MatrixError("Submatrix indices");
            }
        }

        public void SetMatrix(int[] r, int j0, int j1, Matrix x)
        {
            try
            {
                int num2;
                int index = 0;
            Label_0004:
                if (index < r.Length)
                {
                    goto Label_0049;
                }
                return;
            Label_000E:
                this.matrix[r[index]][num2] = x[index, num2 - j0];
                num2++;
            Label_0029:
                if (num2 <= j1)
                {
                    goto Label_000E;
                }
                index++;
                if ((((uint) j1) & 0) != 0)
                {
                    goto Label_000E;
                }
                goto Label_004D;
            Label_0049:
                num2 = j0;
                goto Label_0029;
            Label_004D:
                if ((((uint) j1) - ((uint) j1)) <= uint.MaxValue)
                {
                    goto Label_0004;
                }
            }
            catch (IndexOutOfRangeException)
            {
                throw new MatrixError("Submatrix indices");
            }
        }

        public void SetMatrix(int i0, int i1, int j0, int j1, Matrix x)
        {
            try
            {
                int num2;
                int index = i0;
                if ((((uint) index) + ((uint) num2)) >= 0)
                {
                    goto Label_0023;
                }
            Label_001A:
                if (num2 <= j1)
                {
                    goto Label_002F;
                }
                index++;
            Label_0023:
                if (index > i1)
                {
                    return;
                }
                num2 = j0;
                goto Label_001A;
            Label_002F:
                this.matrix[index][num2] = x[index - i0, num2 - j0];
                num2++;
                goto Label_001A;
            }
            catch (IndexOutOfRangeException)
            {
                throw new MatrixError("Submatrix indices");
            }
        }

        public Matrix Solve(Matrix b)
        {
            if (this.Rows == this.Cols)
            {
                return new LUDecomposition(this).Solve(b);
            }
            return new QRDecomposition(this).Solve(b);
        }

        public double Sum()
        {
            int num2;
            int num3;
            double num = 0.0;
            goto Label_0050;
        Label_000C:
            if (num2 < this.Rows)
            {
                num3 = 0;
            }
            else
            {
                if (((uint) num2) >= 0)
                {
                    return num;
                }
                goto Label_0050;
            }
        Label_0029:
            if (num3 < this.Cols)
            {
                goto Label_0058;
            }
            num2++;
            if ((((uint) num3) + ((uint) num3)) > uint.MaxValue)
            {
                goto Label_0058;
            }
            if ((((uint) num2) + ((uint) num3)) >= 0)
            {
                goto Label_000C;
            }
            return num;
        Label_0050:
            num2 = 0;
            goto Label_000C;
        Label_0058:
            num += this.matrix[num2][num3];
            num3++;
            goto Label_0029;
        }

        public double[] ToPackedArray()
        {
            double[] numArray = new double[this.Rows * this.Cols];
            int num = 0;
            int index = 0;
            while (index < this.Rows)
            {
                int num3 = 0;
                if ((((uint) index) - ((uint) num)) >= 0)
                {
                    while (num3 < this.Cols)
                    {
                        numArray[num++] = this.matrix[index][num3];
                        num3++;
                    }
                    index++;
                }
            }
            return numArray;
        }

        private void Validate(int row, int col)
        {
            object[] objArray;
            if (row >= this.Rows)
            {
                goto Label_00CC;
            }
            if ((((uint) col) & 0) == 0)
            {
                goto Label_00A7;
            }
        Label_005D:
            if ((col < this.Cols) && (col >= 0))
            {
                return;
            }
            object[] objArray2 = new object[] { "The col:", col, " is out of range:", this.Cols };
            throw new MatrixError(string.Concat(objArray2));
            if (0x7fffffff != 0)
            {
                return;
            }
        Label_00A7:
            if (row >= 0)
            {
                goto Label_005D;
            }
        Label_00CC:
            objArray = new object[4];
            if ((((uint) col) + ((uint) row)) >= 0)
            {
                objArray[0] = "The row:";
                objArray[1] = row;
                if ((((uint) col) & 0) == 0)
                {
                    objArray[2] = " is out of range:";
                    objArray[3] = this.Rows;
                    if (0x7fffffff == 0)
                    {
                        goto Label_00A7;
                    }
                }
            }
            throw new MatrixError(string.Concat(objArray));
        }

        public int Cols
        {
            get
            {
                return this.matrix[0].Length;
            }
        }

        public double[][] Data
        {
            get
            {
                return this.matrix;
            }
        }

        public double this[int row, int col]
        {
            get
            {
                this.Validate(row, col);
                return this.matrix[row][col];
            }
            set
            {
                this.Validate(row, col);
                if (double.IsInfinity(value) || ((((uint) col) - ((uint) value)) < 0))
                {
                    goto Label_005B;
                }
            Label_000C:
                if (!double.IsNaN(value))
                {
                    this.matrix[row][col] = value;
                    return;
                }
            Label_005B:
                throw new MatrixError("Trying to assign invalud number to matrix: " + value);
                if ((((uint) value) & 0) != 0)
                {
                    return;
                }
                goto Label_000C;
            }
        }

        public int Rows
        {
            get
            {
                return (this.matrix.GetUpperBound(0) + 1);
            }
        }

        public int Size
        {
            get
            {
                return (this.Rows * this.Cols);
            }
        }
    }
}

