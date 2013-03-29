namespace Encog.ML.Kmeans
{
    using Encog.ML;
    using Encog.ML.Data;
    using Encog.ML.Data.Basic;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;

    public class KMeansClustering : IMLMethod, IMLClustering
    {
        private readonly KMeansCluster[] _x0068961b43401a6f;
        private double _x318b65691c8e62e4;
        private readonly IMLDataSet _xa1ca3186bd369811;
        [CompilerGenerated]
        private static Func<double, KMeansCluster, double> x3ea1037ccf291a94;

        public KMeansClustering(int k, IMLDataSet theSet)
        {
            int num2;
            int num3;
            this._x0068961b43401a6f = new KMeansCluster[k];
            int index = 0;
            if (0 == 0)
            {
                do
                {
                    while (index < k)
                    {
                        this._x0068961b43401a6f[index] = new KMeansCluster();
                        index++;
                    }
                    this._xa1ca3186bd369811 = theSet;
                }
                while ((((uint) num2) - ((uint) num3)) < 0);
                this.x318cf87d7d6afed3();
            }
        Label_011B:
            num2 = 0;
            using (IEnumerator<IMLDataPair> enumerator = this._xa1ca3186bd369811.GetEnumerator())
            {
            Label_0071:
                if (enumerator.MoveNext())
                {
                    IMLDataPair current = enumerator.Current;
                    this._x0068961b43401a6f[num2].Add(current.Input);
                    do
                    {
                        num2++;
                        if (num2 < this._x0068961b43401a6f.Length)
                        {
                            goto Label_0071;
                        }
                    }
                    while ((((uint) k) & 0) != 0);
                    num2 = 0;
                    if ((((uint) index) + ((uint) num3)) <= uint.MaxValue)
                    {
                        goto Label_0071;
                    }
                }
            }
            this.x83dcd323e7277afc();
            KMeansCluster[] clusterArray = this._x0068961b43401a6f;
            num3 = 0;
        Label_001D:
            if (num3 < clusterArray.Length)
            {
                KMeansCluster cluster = clusterArray[num3];
                cluster.Centroid.CalcCentroid();
                if ((((uint) num2) + ((uint) index)) <= uint.MaxValue)
                {
                    num3++;
                    goto Label_001D;
                }
            }
            else
            {
                this.x83dcd323e7277afc();
            }
            if (1 != 0)
            {
                return;
            }
            goto Label_011B;
        }

        public static double CalculateEuclideanDistance(Centroid c, IMLData data)
        {
            double[] d = data.Data;
            return Math.Sqrt(c.Centers.Select<double, double>((t, i) => Math.Pow(d[i] - t, 2.0)).Sum());
        }

        public void Iteration()
        {
            KMeansCluster cluster;
            int num;
            double num2;
            KMeansCluster cluster2;
            bool flag;
            KMeansCluster cluster3;
            double num3;
            KMeansCluster cluster4;
            int num4;
            KMeansCluster[] clusterArray2;
            int num5;
            KMeansCluster[] clusterArray3;
            int num6;
            KMeansCluster[] clusterArray = this._x0068961b43401a6f;
            if ((((uint) num3) - ((uint) num3)) >= 0)
            {
                num4 = 0;
                goto Label_0067;
            }
            if ((((uint) num3) - ((uint) num3)) >= 0)
            {
                goto Label_00D2;
            }
            goto Label_0088;
        Label_0040:
            if (num < cluster.Size())
            {
                IMLData data = cluster.Get(num);
                num2 = CalculateEuclideanDistance(cluster.Centroid, data);
                cluster2 = null;
                if (((uint) num) >= 0)
                {
                    flag = false;
                    clusterArray2 = this._x0068961b43401a6f;
                    num5 = 0;
                }
                goto Label_011D;
            }
            num4++;
            if (((uint) num2) > uint.MaxValue)
            {
                goto Label_00FA;
            }
        Label_0067:
            if (num4 < clusterArray.Length)
            {
                cluster = clusterArray[num4];
                num = 0;
                goto Label_0040;
            }
            goto Label_00AE;
        Label_0080:
            num++;
            goto Label_0040;
        Label_0088:
            num6++;
        Label_008E:
            if (num6 < clusterArray3.Length)
            {
                goto Label_00FA;
            }
            if ((((uint) num6) + ((uint) num6)) <= uint.MaxValue)
            {
                this.x83dcd323e7277afc();
                goto Label_0080;
            }
        Label_00AE:
            if ((((uint) num5) & 0) == 0)
            {
                return;
            }
        Label_00D2:
            cluster2.Add(cluster.Get(num));
            cluster.Remove(cluster.Get(num));
        Label_00ED:
            clusterArray3 = this._x0068961b43401a6f;
            num6 = 0;
            goto Label_008E;
        Label_00FA:
            cluster4 = clusterArray3[num6];
            cluster4.Centroid.CalcCentroid();
            goto Label_0088;
        Label_0117:
            num5++;
        Label_011D:
            if (num5 < clusterArray2.Length)
            {
                cluster3 = clusterArray2[num5];
                if ((((uint) flag) & 0) != 0)
                {
                    goto Label_00ED;
                }
                num3 = CalculateEuclideanDistance(cluster3.Centroid, cluster.Get(num));
                if (num2 <= num3)
                {
                    goto Label_0117;
                }
            }
            else
            {
                if (flag)
                {
                    goto Label_00D2;
                }
                goto Label_0080;
            }
            num2 = num3;
            cluster2 = cluster3;
            flag = true;
            goto Label_0117;
        }

        public void Iteration(int count)
        {
            for (int i = 0; i < count; i++)
            {
                this.Iteration();
            }
        }

        public int NumClusters()
        {
            return this._x0068961b43401a6f.Length;
        }

        private double x2cf6175701bf1768(int xc0c4c459c6ccbd00)
        {
            long num2;
            IMLDataPair pair;
            int num3;
            double maxValue = double.MaxValue;
            if (((uint) num2) <= uint.MaxValue)
            {
                goto Label_006C;
            }
        Label_001C:
            this._xa1ca3186bd369811.GetRecord((long) xc0c4c459c6ccbd00, pair);
            maxValue = Math.Min(maxValue, pair.InputArray[xc0c4c459c6ccbd00]);
            if (((uint) num3) > uint.MaxValue)
            {
                goto Label_0078;
            }
            num3++;
        Label_004F:
            if (num3 < num2)
            {
                goto Label_001C;
            }
            if ((((uint) xc0c4c459c6ccbd00) - ((uint) xc0c4c459c6ccbd00)) <= uint.MaxValue)
            {
                return maxValue;
            }
        Label_006C:
            num2 = this._xa1ca3186bd369811.Count;
        Label_0078:
            pair = BasicMLDataPair.CreatePair(this._xa1ca3186bd369811.InputSize, this._xa1ca3186bd369811.IdealSize);
            num3 = 0;
            goto Label_004F;
        }

        private void x318cf87d7d6afed3()
        {
            double[] numArray;
            int num2;
            int num = 1;
        Label_0039:
            if (num <= this._x0068961b43401a6f.Length)
            {
                numArray = new double[this._xa1ca3186bd369811.InputSize];
                num2 = 0;
                goto Label_008D;
            }
            return;
        Label_0060:
            numArray[num2] = (((this.xe6459878eee52706(num2) - this.x2cf6175701bf1768(num2)) / ((double) (this._x0068961b43401a6f.Length + 1))) * num) + this.x2cf6175701bf1768(num2);
            num2++;
        Label_008D:
            if (num2 < numArray.Length)
            {
                goto Label_0060;
            }
            Centroid centroid = new Centroid(numArray);
            this._x0068961b43401a6f[num - 1].Centroid = centroid;
            if (8 == 0)
            {
                if ((((uint) num) + ((uint) num)) > uint.MaxValue)
                {
                    goto Label_0039;
                }
                goto Label_0060;
            }
            centroid.Cluster = this._x0068961b43401a6f[num - 1];
            num++;
            goto Label_0039;
        }

        private void x83dcd323e7277afc()
        {
            if (x3ea1037ccf291a94 == null)
            {
                x3ea1037ccf291a94 = new Func<double, KMeansCluster, double>(KMeansClustering.x92c8f50710486fbe);
            }
            double num = this._x0068961b43401a6f.Aggregate<KMeansCluster, double>(0.0, x3ea1037ccf291a94);
            this._x318b65691c8e62e4 = num;
        }

        [CompilerGenerated]
        private static double x92c8f50710486fbe(double x3bd62873fafa6252, KMeansCluster x4bbc2c453c470189)
        {
            return (x3bd62873fafa6252 + x4bbc2c453c470189.SumSqr);
        }

        private double xe6459878eee52706(int xc0c4c459c6ccbd00)
        {
            long num2;
            int num3;
            double minValue = double.MinValue;
        Label_0083:
            num2 = this._xa1ca3186bd369811.Count;
        Label_008F:
            num3 = 0;
            if ((((uint) minValue) + ((uint) num2)) <= uint.MaxValue)
            {
                if ((((uint) num3) + ((uint) minValue)) < 0)
                {
                    goto Label_008F;
                }
                while (true)
                {
                    if (num3 < num2)
                    {
                        IMLDataPair pair = BasicMLDataPair.CreatePair(this._xa1ca3186bd369811.InputSize, this._xa1ca3186bd369811.IdealSize);
                        this._xa1ca3186bd369811.GetRecord((long) xc0c4c459c6ccbd00, pair);
                        minValue = Math.Max(minValue, pair.InputArray[xc0c4c459c6ccbd00]);
                    }
                    else
                    {
                        if ((((uint) minValue) & 0) == 0)
                        {
                            return minValue;
                        }
                        goto Label_0083;
                    }
                    num3++;
                }
            }
            return minValue;
        }

        public IMLCluster[] Clusters
        {
            get
            {
                return this._x0068961b43401a6f;
            }
        }

        public double WCSS
        {
            get
            {
                return this._x318b65691c8e62e4;
            }
        }
    }
}

