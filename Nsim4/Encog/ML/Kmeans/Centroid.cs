namespace Encog.ML.Kmeans
{
    using System;

    public class Centroid
    {
        private readonly double[] _x1faa5fd54eb26a4c;
        private KMeansCluster _xde6af23db24d224c;

        public Centroid(double[] theCenters)
        {
            this._x1faa5fd54eb26a4c = theCenters;
        }

        public void CalcCentroid()
        {
            double[] numArray;
            int num2;
            int num3;
            int num4;
            int num = this._xde6af23db24d224c.Size();
            goto Label_010B;
        Label_0011:
            if (num4 < numArray.Length)
            {
                this._x1faa5fd54eb26a4c[num4] = numArray[num4] / ((double) num);
                num4++;
                if ((((uint) num) & 0) == 0)
                {
                    goto Label_0011;
                }
                if ((((uint) num) & 0) == 0)
                {
                    goto Label_00E0;
                }
                goto Label_008D;
            }
            this._xde6af23db24d224c.CalcSumOfSquares();
            if ((((uint) num4) + ((uint) num2)) <= uint.MaxValue)
            {
                return;
            }
            goto Label_00E0;
        Label_0043:
            if (num2 < num)
            {
                num3 = 0;
            }
            else
            {
                num4 = 0;
                goto Label_0011;
            }
        Label_008D:
            while (num3 < numArray.Length)
            {
                numArray[num3] += this._xde6af23db24d224c.Get(num2)[num3];
                num3++;
            }
            num2++;
            if ((((uint) num2) - ((uint) num4)) > uint.MaxValue)
            {
                goto Label_010B;
            }
            if ((((uint) num3) + ((uint) num3)) >= 0)
            {
                goto Label_0043;
            }
            goto Label_0011;
        Label_00E0:
            num2 = 0;
            goto Label_0043;
        Label_010B:
            numArray = new double[this._x1faa5fd54eb26a4c.Length];
            goto Label_00E0;
        }

        public double[] Centers
        {
            get
            {
                return this._x1faa5fd54eb26a4c;
            }
        }

        public KMeansCluster Cluster
        {
            get
            {
                return this._xde6af23db24d224c;
            }
            set
            {
                this._xde6af23db24d224c = value;
            }
        }
    }
}

