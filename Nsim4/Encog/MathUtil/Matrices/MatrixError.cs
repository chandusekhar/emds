namespace Encog.MathUtil.Matrices
{
    using Encog;
    using System;

    public class MatrixError : EncogError
    {
        public MatrixError(Exception e) : base(e)
        {
        }

        public MatrixError(string str) : base(str)
        {
        }
    }
}

