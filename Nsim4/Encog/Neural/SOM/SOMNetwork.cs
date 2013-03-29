namespace Encog.Neural.SOM
{
    using Encog.MathUtil.Matrices;
    using Encog.ML;
    using Encog.ML.Data;
    using Encog.ML.Data.Basic;
    using Encog.Neural.SOM.Training.Neighborhood;
    using Encog.Util;
    using System;
    using System.Runtime.CompilerServices;

    [Serializable]
    public class SOMNetwork : BasicML, IMLMethod, IMLInputOutput, IMLInput, IMLOutput, IMLResettable, IMLClassification, IMLError
    {
        private Matrix _weights;
        public const double Verysmall = 1E-30;

        public SOMNetwork()
        {
        }

        public SOMNetwork(int inputCount, int outputCount)
        {
            this.InputCount = inputCount;
            this.OutputCount = outputCount;
            this._weights = new Matrix(inputCount, outputCount);
        }

        public double CalculateError(IMLDataSet data)
        {
            BestMatchingUnit unit = new BestMatchingUnit(this);
            unit.Reset();
            foreach (IMLDataPair pair in data)
            {
                IMLData input = pair.Input;
                unit.CalculateBMU(input);
            }
            return (unit.WorstDistance / 100.0);
        }

        public int Classify(IMLData input)
        {
            return EngineArray.MaxIndex(this.Compute(input).Data);
        }

        public IMLData Compute(IMLData input)
        {
            int num;
            Matrix col;
            Matrix matrix2;
            IMLData data = new BasicMLData(this.OutputCount);
            if (0 == 0)
            {
                goto Label_003F;
            }
        Label_000F:
            matrix2 = Matrix.CreateRowMatrix(input.Data);
            if (3 == 0)
            {
                goto Label_003F;
            }
            data[num] = MatrixMath.DotProduct(matrix2, col);
            num++;
        Label_0034:
            if (num < this.OutputCount)
            {
                col = this._weights.GetCol(num);
                goto Label_000F;
            }
            return data;
        Label_003F:
            num = 0;
            goto Label_0034;
        }

        public void Reset()
        {
            this._weights.Randomize(-1.0, 1.0);
        }

        public void Reset(int seed)
        {
            this.Reset();
        }

        public sealed override void UpdateProperties()
        {
        }

        public int Winner(IMLData input)
        {
            return EngineArray.IndexOfLargest(this.Compute(input).Data);
        }

        public virtual int InputCount { get; set; }

        public virtual int OutputCount { get; set; }

        public Matrix Weights
        {
            get
            {
                return this._weights;
            }
            set
            {
                this._weights = value;
            }
        }
    }
}

