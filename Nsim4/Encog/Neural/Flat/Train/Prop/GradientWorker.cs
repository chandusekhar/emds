namespace Encog.Neural.Flat.Train.Prop
{
    using Encog.Engine.Network.Activation;
    using Encog.MathUtil.Error;
    using Encog.ML.Data;
    using Encog.ML.Data.Basic;
    using Encog.Neural.Error;
    using Encog.Neural.Flat;
    using Encog.Util;
    using Encog.Util.Concurrency;
    using System;

    public class GradientWorker : IEngineTask
    {
        private readonly TrainFlatNetworkProp _x071bde1041617fce;
        private readonly double[] _x0ba854627e1326f9;
        private readonly IErrorFunction _x2cb049236d33bbda;
        private readonly double[] _x2f33d779e5a20b28;
        private readonly double[] _x58c3d5da5c5c72db;
        private readonly double[] _x59e01312f2f4aa96;
        private readonly double[] _x5e72e5e601f79c78;
        private readonly IMLDataPair _x61830ac74d65acc3;
        private readonly int _x628ea9b89457a2a9;
        private readonly int[] _x7d5bf19d36074a85;
        private readonly IMLDataSet _x823a2b9c8bf459c5;
        private readonly ErrorCalculation _x84e81691256999b2;
        private readonly FlatNetwork _x87a7fc6a72741c2e;
        private readonly int[] _xb25095f37f20a1c1;
        private readonly int[] _xc99b49dd213196ca;
        private readonly int _xd12d1dba8a023d95;
        private readonly double[] _xd505507cf33ae543;
        private readonly double[] _xe05127febf8b7904;
        private readonly int[] _xe05f7b8f952f0ba4;

        public GradientWorker(FlatNetwork theNetwork, TrainFlatNetworkProp theOwner, IMLDataSet theTraining, int theLow, int theHigh, double[] theFlatSpots, IErrorFunction ef)
        {
            goto Label_0155;
        Label_0114:
            this._x071bde1041617fce = theOwner;
            this._x0ba854627e1326f9 = theFlatSpots;
            this._x58c3d5da5c5c72db = new double[this._x87a7fc6a72741c2e.LayerOutput.Length];
            this._xe05127febf8b7904 = new double[this._x87a7fc6a72741c2e.Weights.Length];
            this._xd505507cf33ae543 = new double[this._x87a7fc6a72741c2e.OutputCount];
            if (0 == 0)
            {
                this._x2f33d779e5a20b28 = this._x87a7fc6a72741c2e.Weights;
                if ((((uint) theHigh) + ((uint) theLow)) <= uint.MaxValue)
                {
                    this._xb25095f37f20a1c1 = this._x87a7fc6a72741c2e.LayerIndex;
                    if (((uint) theLow) <= uint.MaxValue)
                    {
                        this._xe05f7b8f952f0ba4 = this._x87a7fc6a72741c2e.LayerCounts;
                        this._x7d5bf19d36074a85 = this._x87a7fc6a72741c2e.WeightIndex;
                        this._x5e72e5e601f79c78 = this._x87a7fc6a72741c2e.LayerOutput;
                        this._x59e01312f2f4aa96 = this._x87a7fc6a72741c2e.LayerSums;
                        this._xc99b49dd213196ca = this._x87a7fc6a72741c2e.LayerFeedCounts;
                        this._x2cb049236d33bbda = ef;
                    }
                }
            }
            this._x61830ac74d65acc3 = BasicMLDataPair.CreatePair(this._x87a7fc6a72741c2e.InputCount, this._x87a7fc6a72741c2e.OutputCount);
            if (0 == 0)
            {
                return;
            }
        Label_0155:
            this._x84e81691256999b2 = new ErrorCalculation();
            this._x87a7fc6a72741c2e = theNetwork;
            this._x823a2b9c8bf459c5 = theTraining;
            if (0xff == 0)
            {
                return;
            }
            do
            {
                if ((((uint) theHigh) + ((uint) theLow)) > uint.MaxValue)
                {
                    goto Label_0114;
                }
                this._xd12d1dba8a023d95 = theLow;
            }
            while (0 != 0);
            this._x628ea9b89457a2a9 = theHigh;
            goto Label_0114;
        }

        public void Run()
        {
            try
            {
                int num;
                double num2;
                this._x84e81691256999b2.Reset();
                goto Label_006B;
            Label_000D:
                num2 = this._x84e81691256999b2.Calculate();
                this._x071bde1041617fce.Report(this._xe05127febf8b7904, num2, null);
                EngineArray.Fill(this._xe05127febf8b7904, 0);
                if (((uint) num2) >= 0)
                {
                    return;
                }
                goto Label_006B;
            Label_004C:
                num++;
            Label_0050:
                if (num <= this._x628ea9b89457a2a9)
                {
                    goto Label_0074;
                }
                if (((uint) num2) <= uint.MaxValue)
                {
                    goto Label_000D;
                }
            Label_006B:
                num = this._xd12d1dba8a023d95;
                goto Label_0050;
            Label_0074:
                this._x823a2b9c8bf459c5.GetRecord((long) num, this._x61830ac74d65acc3);
                this.x5d3a1f6283012a22(this._x61830ac74d65acc3.InputArray, this._x61830ac74d65acc3.IdealArray, this._x61830ac74d65acc3.Significance);
                goto Label_004C;
            }
            catch (Exception exception)
            {
                this._x071bde1041617fce.Report(null, 0.0, exception);
            }
        }

        private void x5d3a1f6283012a22(double[] xcdaeea7afaf570ff, double[] xf40f2d506fd08ad7, double xe4115acdf4fbfccc)
        {
            int beginTraining;
            this._x87a7fc6a72741c2e.Compute(xcdaeea7afaf570ff, this._xd505507cf33ae543);
            this._x84e81691256999b2.UpdateError(this._xd505507cf33ae543, xf40f2d506fd08ad7, xe4115acdf4fbfccc);
            goto Label_00F8;
        Label_0017:
            this.xdc972101a59889e3(beginTraining);
            beginTraining++;
        Label_0022:
            if (beginTraining < this._x87a7fc6a72741c2e.EndTraining)
            {
                goto Label_0017;
            }
            if ((((uint) beginTraining) + ((uint) beginTraining)) >= 0)
            {
                return;
            }
        Label_00F8:
            this._x2cb049236d33bbda.CalculateError(xf40f2d506fd08ad7, this._xd505507cf33ae543, this._x58c3d5da5c5c72db);
            int index = 0;
            do
            {
                if (index >= this._xd505507cf33ae543.Length)
                {
                    beginTraining = this._x87a7fc6a72741c2e.BeginTraining;
                    goto Label_0022;
                }
                this._x58c3d5da5c5c72db[index] = ((this._x87a7fc6a72741c2e.ActivationFunctions[0].DerivativeFunction(this._x59e01312f2f4aa96[index], this._x5e72e5e601f79c78[index]) + this._x0ba854627e1326f9[0]) * this._x58c3d5da5c5c72db[index]) * xe4115acdf4fbfccc;
                if ((((uint) index) + ((uint) xe4115acdf4fbfccc)) < 0)
                {
                    goto Label_0022;
                }
                index++;
                if ((((uint) xe4115acdf4fbfccc) - ((uint) beginTraining)) > uint.MaxValue)
                {
                    goto Label_0022;
                }
            }
            while (((uint) index) >= 0);
            if (0 != 0)
            {
                return;
            }
            goto Label_0017;
        }

        private void xdc972101a59889e3(int x6b468d6a6158972e)
        {
            int num2;
            int num3;
            int num4;
            int num5;
            IActivationFunction function;
            double num6;
            int num7;
            int num8;
            double num9;
            double num10;
            int num11;
            int num12;
            int num13;
            int num = this._xb25095f37f20a1c1[x6b468d6a6158972e + 1];
            goto Label_0177;
        Label_0010:
            if (num13 < num4)
            {
                this._xe05127febf8b7904[num12] += num9 * this._x58c3d5da5c5c72db[num11];
                if ((((uint) num9) + ((uint) num7)) < 0)
                {
                    goto Label_0010;
                }
                num10 += this._x2f33d779e5a20b28[num12] * this._x58c3d5da5c5c72db[num11];
                num12 += num3;
                goto Label_00CF;
            }
            this._x58c3d5da5c5c72db[num7] = num10 * (function.DerivativeFunction(this._x59e01312f2f4aa96[num7], this._x5e72e5e601f79c78[num7]) + num6);
            num7++;
            num8++;
            if ((((uint) num) & 0) != 0)
            {
                goto Label_00CF;
            }
        Label_005D:
            if (num8 < num3)
            {
                goto Label_0104;
            }
            return;
        Label_00CF:
            num11++;
            num13++;
            goto Label_0010;
        Label_00E1:
            num12 = num5 + num8;
            num13 = 0;
            if ((((uint) num2) & 0) == 0)
            {
                goto Label_0010;
            }
            goto Label_0177;
        Label_0104:
            num9 = this._x5e72e5e601f79c78[num7];
            num10 = 0.0;
            num11 = num2;
            goto Label_00E1;
        Label_0177:
            if (((uint) num6) < 0)
            {
                goto Label_005D;
            }
            num2 = this._xb25095f37f20a1c1[x6b468d6a6158972e];
        Label_0192:
            num3 = this._xe05f7b8f952f0ba4[x6b468d6a6158972e + 1];
            if (((uint) num9) >= 0)
            {
                num4 = this._xc99b49dd213196ca[x6b468d6a6158972e];
                num5 = this._x7d5bf19d36074a85[x6b468d6a6158972e];
                function = this._x87a7fc6a72741c2e.ActivationFunctions[x6b468d6a6158972e + 1];
                num6 = this._x0ba854627e1326f9[x6b468d6a6158972e + 1];
                num7 = num;
                if ((((uint) num8) + ((uint) num2)) < 0)
                {
                    goto Label_0192;
                }
                num8 = 0;
                goto Label_005D;
            }
            if (((uint) num2) <= uint.MaxValue)
            {
                goto Label_0104;
            }
            goto Label_00E1;
        }

        public FlatNetwork Network
        {
            get
            {
                return this._x87a7fc6a72741c2e;
            }
        }

        public double[] Weights
        {
            get
            {
                return this._x2f33d779e5a20b28;
            }
        }
    }
}

