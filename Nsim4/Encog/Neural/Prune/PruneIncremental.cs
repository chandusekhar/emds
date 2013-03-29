namespace Encog.Neural.Prune
{
    using Encog;
    using Encog.ML.Data;
    using Encog.ML.Data.Buffer;
    using Encog.ML.Train.Strategy;
    using Encog.Neural.Networks;
    using Encog.Neural.Networks.Training.Propagation;
    using Encog.Neural.Networks.Training.Propagation.Resilient;
    using Encog.Neural.Pattern;
    using Encog.Util;
    using Encog.Util.Concurrency.Job;
    using Encog.Util.Logging;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Text;

    public class PruneIncremental : ConcurrentJob
    {
        private bool _x0b03741e8f17a9f7;
        private readonly INeuralNetworkPattern _x49d5b7c4ad0e0bdd;
        private int _x5426aa354995e9e0;
        private BasicNetwork _x61bb83c40eed7f47;
        private double _x628ea9b89457a2a9;
        private readonly IStatusReportable _x64343a0786fb9a3f;
        private int[] _x6b2fa1a7ab6e70d2;
        private readonly double[] _x7890c8b3a33b26e2;
        private int _x7ca40c9a68f86359;
        private readonly IMLDataSet _x823a2b9c8bf459c5;
        private readonly IList<HiddenLayerParams> _xab3ddaff42dd298a;
        private readonly BasicNetwork[] _xc5f756e0b4a83af0;
        private double _xd12d1dba8a023d95;
        private double[][] _xd559aa34776631a5;
        private readonly int _xdbf51c857aeb8093;
        private readonly int _xe009ad1bd0a8245a;
        private int _xe4e6a25eae13e4b3;

        public PruneIncremental(IMLDataSet training, INeuralNetworkPattern pattern, int iterations, int weightTries, int numTopResults, IStatusReportable report) : base(report)
        {
            goto Label_008E;
        Label_0031:
            this._x7890c8b3a33b26e2 = new double[numTopResults];
            return;
        Label_008E:
            this._x0b03741e8f17a9f7 = false;
            this._xab3ddaff42dd298a = new List<HiddenLayerParams>();
            this._x823a2b9c8bf459c5 = training;
            if ((((uint) numTopResults) - ((uint) weightTries)) < 0)
            {
                goto Label_0031;
            }
            this._x49d5b7c4ad0e0bdd = pattern;
            if ((((uint) iterations) - ((uint) iterations)) <= uint.MaxValue)
            {
                this._xdbf51c857aeb8093 = iterations;
                this._x64343a0786fb9a3f = report;
                this._xe009ad1bd0a8245a = weightTries;
                this._xc5f756e0b4a83af0 = new BasicNetwork[numTopResults];
                goto Label_0031;
            }
            goto Label_008E;
        }

        public void AddHiddenLayer(int min, int max)
        {
            HiddenLayerParams item = new HiddenLayerParams(min, max);
            this._xab3ddaff42dd298a.Add(item);
        }

        public void Init()
        {
            if (this._xab3ddaff42dd298a.Count != 1)
            {
                do
                {
                    if (this._xab3ddaff42dd298a.Count == 2)
                    {
                        this._xe4e6a25eae13e4b3 = (this._xab3ddaff42dd298a[0].Max - this._xab3ddaff42dd298a[0].Min) + 1;
                        this._x5426aa354995e9e0 = (this._xab3ddaff42dd298a[1].Max - this._xab3ddaff42dd298a[1].Min) + 1;
                    }
                    else
                    {
                        goto Label_0013;
                    }
                }
                while (-1 == 0);
                this._xd559aa34776631a5 = EngineArray.AllocateDouble2D(this._xe4e6a25eae13e4b3, this._x5426aa354995e9e0);
                goto Label_0028;
            }
            this._xe4e6a25eae13e4b3 = (this._xab3ddaff42dd298a[0].Max - this._xab3ddaff42dd298a[0].Min) + 1;
            this._x5426aa354995e9e0 = 0;
            if (0 == 0)
            {
                if (0 == 0)
                {
                    this._xd559aa34776631a5 = EngineArray.AllocateDouble2D(this._xe4e6a25eae13e4b3, 1);
                }
                goto Label_0028;
            }
        Label_0013:
            this._xe4e6a25eae13e4b3 = 0;
            this._x5426aa354995e9e0 = 0;
            this._xd559aa34776631a5 = null;
        Label_0028:
            this._x628ea9b89457a2a9 = double.NegativeInfinity;
            this._xd12d1dba8a023d95 = double.PositiveInfinity;
            if (2 != 0)
            {
                return;
            }
            goto Label_0013;
        }

        public sealed override int LoadWorkload()
        {
            int num = 1;
            foreach (HiddenLayerParams @params in this._xab3ddaff42dd298a)
            {
                num *= (@params.Max - @params.Min) + 1;
            }
            this.Init();
            return num;
        }

        public static string NetworkToString(BasicNetwork network)
        {
            if (network == null)
            {
                return "N/A";
            }
            StringBuilder builder = new StringBuilder();
            int num = 1;
            if (0 != 0)
            {
                goto Label_0039;
            }
            int l = 1;
            if ((((uint) l) - ((uint) l)) > uint.MaxValue)
            {
                goto Label_0021;
            }
        Label_000C:
            if (l < (network.LayerCount - 1))
            {
                if (builder.Length > 0)
                {
                    builder.Append(",");
                }
            }
            else
            {
                if (0 != 0)
                {
                    goto Label_000C;
                }
                return builder.ToString();
            }
        Label_0021:
            builder.Append("H");
            builder.Append(num++);
        Label_0039:
            builder.Append("=");
            builder.Append(network.GetLayerNeuronCount(l));
            l++;
            goto Label_000C;
        }

        public sealed override void PerformJobUnit(JobUnitContext context)
        {
            double num;
            int num2;
            int num3;
            int num4;
            int layerNeuronCount;
            int num6;
            int num7;
            BasicNetwork jobUnit = (BasicNetwork) context.JobUnit;
            BufferedMLDataSet set = null;
            IMLDataSet training = this._x823a2b9c8bf459c5;
            if (this._x823a2b9c8bf459c5 is BufferedMLDataSet)
            {
                set = (BufferedMLDataSet) this._x823a2b9c8bf459c5;
                if ((((uint) num) + ((uint) num2)) > uint.MaxValue)
                {
                    goto Label_02BB;
                }
            }
            else
            {
                if (((uint) num4) > uint.MaxValue)
                {
                    goto Label_0302;
                }
                goto Label_02BB;
            }
            training = set.OpenAdditional();
            goto Label_0302;
        Label_0011:
            this._x7ca40c9a68f86359++;
            this.x6aa420caefd31103(jobUnit, num);
            base.ReportStatus(context, "Current: " + NetworkToString(jobUnit) + "; Best: " + NetworkToString(this._x61bb83c40eed7f47));
            if (((uint) num) >= 0)
            {
                return;
            }
            if (((uint) layerNeuronCount) <= uint.MaxValue)
            {
                goto Label_0104;
            }
            if ((((uint) layerNeuronCount) | 3) == 0)
            {
            }
        Label_0090:
            if (num6 >= 0)
            {
                if (num7 >= 0)
                {
                    goto Label_00A7;
                }
            }
            else if (0 != 0)
            {
                goto Label_00B9;
            }
            Console.Out.WriteLine("STOP");
        Label_00A7:
            this._xd559aa34776631a5[num6][num7] = num;
            goto Label_0011;
        Label_00B9:
            if (this._xe4e6a25eae13e4b3 > 0)
            {
                goto Label_0188;
            }
            if (0 == 0)
            {
                if ((((uint) num3) & 0) != 0)
                {
                    return;
                }
                goto Label_0011;
            }
        Label_0104:
            num7 = 0;
            goto Label_0090;
        Label_0125:
            num4 = jobUnit.GetLayerNeuronCount(1);
        Label_012E:
            if (this._x5426aa354995e9e0 != 0)
            {
                num6 = num4 - this._xab3ddaff42dd298a[0].Min;
                num7 = layerNeuronCount - this._xab3ddaff42dd298a[1].Min;
                goto Label_0090;
            }
            num6 = num4 - this._xab3ddaff42dd298a[0].Min;
            if ((((uint) num3) | 0xfffffffe) != 0)
            {
                goto Label_0104;
            }
            return;
        Label_0188:
            if (jobUnit.LayerCount <= 3)
            {
                layerNeuronCount = 0;
                goto Label_0125;
            }
            layerNeuronCount = jobUnit.GetLayerNeuronCount(2);
            num4 = jobUnit.GetLayerNeuronCount(1);
            goto Label_012E;
        Label_0195:
            if (base.ShouldStop)
            {
                return;
            }
            this._x628ea9b89457a2a9 = Math.Max(this._x628ea9b89457a2a9, num);
            this._xd12d1dba8a023d95 = Math.Min(this._xd12d1dba8a023d95, num);
            if ((((uint) num2) + ((uint) num6)) <= uint.MaxValue)
            {
                goto Label_00B9;
            }
            goto Label_0188;
        Label_02BB:
            num = double.PositiveInfinity;
            num2 = 0;
        Label_0217:
            if (num2 < this._xe009ad1bd0a8245a)
            {
                StopTrainingStrategy strategy;
                jobUnit.Reset();
                Encog.Neural.Networks.Training.Propagation.Propagation propagation = new ResilientPropagation(jobUnit, training);
                if ((((uint) num) - ((uint) num3)) >= 0)
                {
                    strategy = new StopTrainingStrategy(0.001, 5);
                }
                propagation.AddStrategy(strategy);
                propagation.ThreadCount = 1;
                num3 = 0;
                while (true)
                {
                    if ((num3 < this._xdbf51c857aeb8093) && (!base.ShouldStop && !strategy.ShouldStop()))
                    {
                        propagation.Iteration();
                    }
                    else
                    {
                        num = Math.Min(num, propagation.Error);
                        if (4 != 0)
                        {
                            num2++;
                            goto Label_0217;
                        }
                        goto Label_0195;
                    }
                    num3++;
                }
            }
            while (set != null)
            {
                set.Close();
                if (((uint) num4) <= uint.MaxValue)
                {
                    break;
                }
            }
            goto Label_0195;
        Label_0302:
            if ((((uint) num4) - ((uint) layerNeuronCount)) < 0)
            {
                goto Label_0125;
            }
            goto Label_02BB;
        }

        public sealed override void Process()
        {
            int num;
            if (this._xab3ddaff42dd298a.Count != 0)
            {
                goto Label_0040;
            }
            goto Label_00A9;
        Label_001D:
            base.Process();
            if ((((uint) num) | 3) != 0)
            {
                return;
            }
            goto Label_00A9;
        Label_0040:
            this._x6b2fa1a7ab6e70d2 = new int[this._xab3ddaff42dd298a.Count];
            this._x61bb83c40eed7f47 = null;
            num = 0;
            foreach (HiddenLayerParams @params in this._xab3ddaff42dd298a)
            {
                this._x6b2fa1a7ab6e70d2[num++] = @params.Min;
            }
            if (this._x6b2fa1a7ab6e70d2[0] != 0)
            {
                goto Label_001D;
            }
            throw new EncogError("To calculate the optimal hidden size, at least one neuron must be the minimum for the first hidden layer.");
        Label_00A9:
            throw new EncogError("To calculate the optimal hidden size, at least one hidden layer must be defined.");
            if (-2 == 0)
            {
                goto Label_001D;
            }
            if (0 != 0)
            {
                return;
            }
            goto Label_0040;
        }

        public sealed override object RequestNextTask()
        {
            if (!this._x0b03741e8f17a9f7)
            {
                BasicNetwork network;
                if (-2 != 0)
                {
                Label_0020:
                    if (!base.ShouldStop)
                    {
                        if (((3 == 0) && (0 == 0)) && (-2147483648 == 0))
                        {
                            goto Label_0020;
                        }
                        network = this.x2f456b293ba8d8fa();
                    }
                    else
                    {
                        goto Label_0044;
                    }
                }
                if (!this.x3d557552d5425977())
                {
                    this._x0b03741e8f17a9f7 = true;
                }
                return network;
            }
        Label_0044:
            return null;
        }

        private BasicNetwork x2f456b293ba8d8fa()
        {
            int num;
            this._x49d5b7c4ad0e0bdd.Clear();
            int[] numArray = this._x6b2fa1a7ab6e70d2;
            int index = 0;
            goto Label_0035;
        Label_000D:
            this._x49d5b7c4ad0e0bdd.AddHiddenLayer(num);
        Label_0019:
            index++;
            if ((((uint) index) | 3) == 0)
            {
                goto Label_000D;
            }
        Label_0035:
            if (index < numArray.Length)
            {
                num = numArray[index];
                if (num <= 0)
                {
                    goto Label_0019;
                }
                if (8 != 0)
                {
                    goto Label_000D;
                }
            }
            return (BasicNetwork) this._x49d5b7c4ad0e0bdd.Generate();
        }

        private bool x3d557552d5425977()
        {
            HiddenLayerParams @params;
            int index = 0;
        Label_0072:
            @params = this._xab3ddaff42dd298a[index];
            if ((((uint) index) & 0) == 0)
            {
                this._x6b2fa1a7ab6e70d2[index]++;
            Label_0009:
                if (this._x6b2fa1a7ab6e70d2[index] > @params.Max)
                {
                    this._x6b2fa1a7ab6e70d2[index] = @params.Min;
                    index++;
                    if (index < this._x6b2fa1a7ab6e70d2.Length)
                    {
                        goto Label_0072;
                    }
                    if ((((uint) index) & 0) == 0)
                    {
                        goto Label_0093;
                    }
                    if (8 == 0)
                    {
                        goto Label_0009;
                    }
                }
                return true;
            }
        Label_0093:
            return false;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        private void x6aa420caefd31103(BasicNetwork x87a7fc6a72741c2e, double xc685eed2987781a2)
        {
            int num;
            int num2;
            BasicNetwork network;
            BasicNetwork network2;
            BasicNetwork[] networkArray;
            int num3;
            this._x628ea9b89457a2a9 = Math.Max(this._x628ea9b89457a2a9, xc685eed2987781a2);
            this._xd12d1dba8a023d95 = Math.Min(this._xd12d1dba8a023d95, xc685eed2987781a2);
            goto Label_02C5;
        Label_0017:
            if (network != this._x61bb83c40eed7f47)
            {
                this._x61bb83c40eed7f47 = network;
            }
            else
            {
                return;
            }
        Label_0028:;
            EncogLogging.Log(0, string.Concat(new object[] { "Prune found new best network: error=", xc685eed2987781a2, ", network=", network }));
            if ((0 == 0) && ((((uint) num) + ((uint) num)) >= 0))
            {
                return;
            }
            goto Label_0017;
        Label_0096:
            num3++;
        Label_009C:
            if (num3 < networkArray.Length)
            {
                goto Label_0101;
            }
            goto Label_0017;
        Label_00C0:
            if (network == null)
            {
                network = network2;
                goto Label_0096;
            }
            if (network2.Structure.CalculateSize() < network.Structure.CalculateSize())
            {
                network = network2;
                if ((((uint) num2) - ((uint) num)) <= uint.MaxValue)
                {
                    if ((((uint) num) & 0) != 0)
                    {
                        return;
                    }
                    goto Label_0096;
                }
            }
            else
            {
                goto Label_0096;
            }
        Label_00DF:
            if (network2 == null)
            {
                goto Label_0096;
            }
            goto Label_00C0;
        Label_0101:
            network2 = networkArray[num3];
            goto Label_00DF;
        Label_0149:
            if (num != -1)
            {
                this._x7890c8b3a33b26e2[num] = xc685eed2987781a2;
                this._xc5f756e0b4a83af0[num] = x87a7fc6a72741c2e;
                if (((uint) num2) > uint.MaxValue)
                {
                    goto Label_019E;
                }
            }
            network = null;
            networkArray = this._xc5f756e0b4a83af0;
            num3 = 0;
            if ((((uint) xc685eed2987781a2) + ((uint) num)) <= uint.MaxValue)
            {
                goto Label_009C;
            }
            if (((uint) num) >= 0)
            {
                goto Label_0101;
            }
            goto Label_00DF;
        Label_014F:
            if (num2 < this._xc5f756e0b4a83af0.Length)
            {
                goto Label_027C;
            }
            goto Label_0149;
        Label_017E:
            num2++;
            goto Label_014F;
        Label_019E:
            if (this._x7890c8b3a33b26e2[num] >= this._x7890c8b3a33b26e2[num2])
            {
                if ((((uint) num2) + ((uint) num2)) > uint.MaxValue)
                {
                    goto Label_0028;
                }
                goto Label_017E;
            }
        Label_023F:
            num = num2;
            if (((((uint) num) | 3) != 0) && ((((uint) num3) | 15) != 0))
            {
                if ((((uint) xc685eed2987781a2) + ((uint) xc685eed2987781a2)) < 0)
                {
                    if ((((uint) num3) & 0) == 0)
                    {
                        goto Label_02C5;
                    }
                    if ((((uint) num2) - ((uint) num)) < 0)
                    {
                        goto Label_00C0;
                    }
                    if ((((uint) num3) + ((uint) num)) >= 0)
                    {
                        goto Label_019E;
                    }
                }
                goto Label_017E;
            }
        Label_025C:
            if (this._x7890c8b3a33b26e2[num2] <= xc685eed2987781a2)
            {
                goto Label_017E;
            }
            if (num != -1)
            {
                goto Label_019E;
            }
            if ((((uint) xc685eed2987781a2) - ((uint) num)) <= uint.MaxValue)
            {
                goto Label_023F;
            }
            if ((((uint) num) - ((uint) xc685eed2987781a2)) >= 0)
            {
                goto Label_02C5;
            }
        Label_027C:
            if (this._xc5f756e0b4a83af0[num2] == null)
            {
                num = num2;
                if ((((uint) num3) & 0) == 0)
                {
                    goto Label_0149;
                }
                goto Label_023F;
            }
            goto Label_025C;
        Label_02C5:
            num = -1;
            num2 = 0;
            goto Label_014F;
        }

        public BasicNetwork BestNetwork
        {
            get
            {
                return this._x61bb83c40eed7f47;
            }
        }

        public IList<HiddenLayerParams> Hidden
        {
            get
            {
                return this._xab3ddaff42dd298a;
            }
        }

        public int Hidden1Size
        {
            get
            {
                return this._xe4e6a25eae13e4b3;
            }
        }

        public int Hidden2Size
        {
            get
            {
                return this._x5426aa354995e9e0;
            }
        }

        public double High
        {
            get
            {
                return this._x628ea9b89457a2a9;
            }
        }

        public int Iterations
        {
            get
            {
                return this._xdbf51c857aeb8093;
            }
        }

        public double Low
        {
            get
            {
                return this._xd12d1dba8a023d95;
            }
        }

        public INeuralNetworkPattern Pattern
        {
            get
            {
                return this._x49d5b7c4ad0e0bdd;
            }
        }

        public double[][] Results
        {
            get
            {
                return this._xd559aa34776631a5;
            }
        }

        public double[] TopErrors
        {
            get
            {
                return this._x7890c8b3a33b26e2;
            }
        }

        public BasicNetwork[] TopNetworks
        {
            get
            {
                return this._xc5f756e0b4a83af0;
            }
        }

        public IMLDataSet Training
        {
            get
            {
                return this._x823a2b9c8bf459c5;
            }
        }
    }
}

