namespace Encog.ML.Kmeans
{
    using Encog.ML;
    using Encog.ML.Data;
    using Encog.ML.Data.Basic;
    using System;
    using System.Collections.Generic;

    public class KMeansCluster : IMLCluster
    {
        private readonly IList<IMLData> _x4a3f0a05c02f235f = new List<IMLData>();
        private Encog.ML.Kmeans.Centroid _xad9f177d88950f3b;
        private double _xb2e4fcf9e5a15378;

        public void Add(IMLData pair)
        {
            this._x4a3f0a05c02f235f.Add(pair);
            this.CalcSumOfSquares();
        }

        public void CalcSumOfSquares()
        {
            double num2;
            int num3;
            int count = this._x4a3f0a05c02f235f.Count;
            if ((((uint) num3) - ((uint) count)) >= 0)
            {
                if ((((uint) num3) - ((uint) num2)) < 0)
                {
                    return;
                }
                num2 = 0.0;
                num3 = 0;
                goto Label_002E;
            }
        Label_002A:
            num3++;
        Label_002E:
            if (num3 < count)
            {
                num2 += KMeansClustering.CalculateEuclideanDistance(this._xad9f177d88950f3b, this._x4a3f0a05c02f235f[num3]);
                goto Label_002A;
            }
            this._xb2e4fcf9e5a15378 = num2;
        }

        public IMLDataSet CreateDataSet()
        {
            IMLDataSet set = new BasicMLDataSet();
            foreach (IMLData data in this._x4a3f0a05c02f235f)
            {
                set.Add(data);
            }
            return set;
        }

        public IMLData Get(int pos)
        {
            return this._x4a3f0a05c02f235f[pos];
        }

        public void Remove(IMLData pair)
        {
            this._x4a3f0a05c02f235f.Remove(pair);
            this.CalcSumOfSquares();
        }

        public int Size()
        {
            return this._x4a3f0a05c02f235f.Count;
        }

        public Encog.ML.Kmeans.Centroid Centroid
        {
            get
            {
                return this._xad9f177d88950f3b;
            }
            set
            {
                this._xad9f177d88950f3b = value;
            }
        }

        public IList<IMLData> Data
        {
            get
            {
                return this._x4a3f0a05c02f235f;
            }
        }

        public double SumSqr
        {
            get
            {
                return this._xb2e4fcf9e5a15378;
            }
        }
    }
}

