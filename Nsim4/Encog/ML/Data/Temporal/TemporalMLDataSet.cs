namespace Encog.ML.Data.Temporal
{
    using Encog.ML.Data;
    using Encog.ML.Data.Basic;
    using Encog.Neural.Data.Basic;
    using Encog.Util.Time;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TemporalMLDataSet : BasicMLDataSet
    {
        private int _x0c37ff3adde9bc44;
        private int _x57202a8751db8895;
        private readonly IList<TemporalDataDescription> _x6849a3dfb0329317 = new List<TemporalDataDescription>();
        private readonly List<TemporalPoint> _x6fa2570084b2ad39 = new List<TemporalPoint>();
        private int _x7293ed6d89c57cf3;
        private TimeUnit _xa9e977193de61cf0;
        private int _xc278386c02fd6e51;
        private int _xc4bd189fc1348058;
        private int _xcfe8f2ba20a6a8e4;
        private int _xd5b5c9323338bee2;
        private DateTime _xdfd26d6ad22d5e81 = DateTime.MinValue;
        public const string AddNotSupported = "Direct adds to the temporal dataset are not supported.  Add TemporalPoint objects and call generate.";

        public TemporalMLDataSet(int inputWindowSize, int predictWindowSize)
        {
            if ((((uint) inputWindowSize) | 4) != 0)
            {
                this._xc278386c02fd6e51 = inputWindowSize;
                this._xcfe8f2ba20a6a8e4 = predictWindowSize;
            }
            this._xd5b5c9323338bee2 = -2147483648;
            do
            {
                this._xc4bd189fc1348058 = 0x7fffffff;
                this._x7293ed6d89c57cf3 = 0x7fffffff;
                this._xdfd26d6ad22d5e81 = DateTime.MinValue;
            }
            while (0 != 0);
            this._xa9e977193de61cf0 = TimeUnit.Days;
        }

        public override void Add(IMLData data)
        {
            throw new TemporalError("Direct adds to the temporal dataset are not supported.  Add TemporalPoint objects and call generate.");
        }

        public override void Add(IMLDataPair inputData)
        {
            throw new TemporalError("Direct adds to the temporal dataset are not supported.  Add TemporalPoint objects and call generate.");
        }

        public override void Add(IMLData inputData, IMLData idealData)
        {
            throw new TemporalError("Direct adds to the temporal dataset are not supported.  Add TemporalPoint objects and call generate.");
        }

        public virtual void AddDescription(TemporalDataDescription desc)
        {
            if (this._x6fa2570084b2ad39.Count <= 0)
            {
                int count = this._x6849a3dfb0329317.Count;
                if (((uint) count) <= uint.MaxValue)
                {
                    desc.Index = count;
                    this._x6849a3dfb0329317.Add(desc);
                    this.CalculateNeuronCounts();
                    return;
                }
            }
            throw new TemporalError("Can't add anymore descriptions, there are already temporal points defined.");
        }

        public virtual int CalculateActualSetSize()
        {
            int num = this.CalculatePointsInRange();
            return Math.Min(this._x7293ed6d89c57cf3, num);
        }

        public virtual void CalculateNeuronCounts()
        {
            this._x57202a8751db8895 = 0;
            this._x0c37ff3adde9bc44 = 0;
            using (IEnumerator<TemporalDataDescription> enumerator = this._x6849a3dfb0329317.GetEnumerator())
            {
                TemporalDataDescription current;
                goto Label_003B;
            Label_001E:
                this._x0c37ff3adde9bc44 += this._xcfe8f2ba20a6a8e4;
                goto Label_003B;
            Label_0033:
                if (current.IsPredict)
                {
                    goto Label_001E;
                }
            Label_003B:
                if (enumerator.MoveNext())
                {
                    current = enumerator.Current;
                    if (current.IsInput)
                    {
                        this._x57202a8751db8895 += this._xc278386c02fd6e51;
                        if (3 == 0)
                        {
                            goto Label_003B;
                        }
                    }
                    goto Label_0033;
                }
            }
        }

        public virtual int CalculatePointsInRange()
        {
            return this._x6fa2570084b2ad39.Count<TemporalPoint>(new Func<TemporalPoint, bool>(this.IsPointInRange));
        }

        public virtual int CalculateStartIndex()
        {
            int num = 0;
            if (((uint) num) <= uint.MaxValue)
            {
                goto Label_0018;
            }
        Label_0014:
            num++;
        Label_0018:
            if (num >= this._x6fa2570084b2ad39.Count)
            {
                return -1;
            }
            TemporalPoint point = this._x6fa2570084b2ad39[num];
            while (this.IsPointInRange(point))
            {
                return num;
            }
            goto Label_0014;
        }

        public virtual void Clear()
        {
            this._x6849a3dfb0329317.Clear();
            this._x6fa2570084b2ad39.Clear();
            base.Data.Clear();
        }

        public virtual TemporalPoint CreatePoint(DateTime when)
        {
            int sequenceFromDate = this.GetSequenceFromDate(when);
            TemporalPoint item = new TemporalPoint(this._x6849a3dfb0329317.Count) {
                Sequence = sequenceFromDate
            };
            this._x6fa2570084b2ad39.Add(item);
            return item;
        }

        public virtual TemporalPoint CreatePoint(int sequence)
        {
            TemporalPoint item = new TemporalPoint(this._x6849a3dfb0329317.Count) {
                Sequence = sequence
            };
            this._x6fa2570084b2ad39.Add(item);
            return item;
        }

        public virtual void Generate()
        {
            int num;
            int num2;
            int num3;
            int num4;
            BasicNeuralData data;
            BasicNeuralData data2;
            this.SortPoints();
            if ((((uint) num) - ((uint) num2)) <= uint.MaxValue)
            {
                goto Label_00C0;
            }
            if ((((uint) num) | 3) != 0)
            {
                goto Label_0083;
            }
            if ((((uint) num3) + ((uint) num)) <= uint.MaxValue)
            {
                goto Label_0089;
            }
        Label_0051:
            if ((((uint) num) - ((uint) num2)) < 0)
            {
                goto Label_00E8;
            }
            BasicNeuralDataPair inputData = new BasicNeuralDataPair(data, data2);
            base.Add(inputData);
            num4++;
        Label_0083:
            if (num4 >= num3)
            {
                if ((((uint) num) + ((uint) num2)) <= uint.MaxValue)
                {
                    return;
                }
                goto Label_00C0;
            }
        Label_0089:
            data = this.GenerateInputNeuralData(num4);
            data2 = this.GenerateOutputNeuralData(num4 + this._xc278386c02fd6e51);
            goto Label_0051;
        Label_00C0:
            if ((((uint) num2) + ((uint) num4)) >= 0)
            {
                num = this.CalculateStartIndex() + 1;
                num2 = this.CalculateActualSetSize();
            }
        Label_00E8:
            num3 = num + ((num2 - this._xcfe8f2ba20a6a8e4) - this._xc278386c02fd6e51);
            num4 = num;
            goto Label_0083;
        }

        public virtual BasicNeuralData GenerateInputNeuralData(int index)
        {
            BasicNeuralData data;
            int num;
            int num2;
            if ((index + this._xc278386c02fd6e51) <= this._x6fa2570084b2ad39.Count)
            {
                data = new BasicNeuralData(this._x57202a8751db8895);
                num = 0;
                num2 = 0;
                goto Label_007B;
            }
            if ((((uint) index) & 0) == 0)
            {
                if ((((uint) num) & 0) == 0)
                {
                    throw new TemporalError("Can't generate input temporal data beyond the end of provided data.");
                }
                goto Label_0077;
            }
        Label_002C:
            foreach (TemporalDataDescription description in this._x6849a3dfb0329317)
            {
                if (description.IsInput)
                {
                    data[num++] = this.x8c7fc30b887213d1(description, index + num2);
                }
            }
        Label_0077:
            num2++;
        Label_007B:
            if (num2 < this._xc278386c02fd6e51)
            {
                goto Label_002C;
            }
            return data;
        }

        public virtual BasicNeuralData GenerateOutputNeuralData(int index)
        {
            if ((index + this._xcfe8f2ba20a6a8e4) <= this._x6fa2570084b2ad39.Count)
            {
                BasicNeuralData data = new BasicNeuralData(this._x0c37ff3adde9bc44);
                int num = 0;
                int num2 = 0;
                while (num2 < this._xcfe8f2ba20a6a8e4)
                {
                    using (IEnumerator<TemporalDataDescription> enumerator = this._x6849a3dfb0329317.GetEnumerator())
                    {
                        TemporalDataDescription current;
                        goto Label_005F;
                    Label_002C:
                        data[num++] = this.x8c7fc30b887213d1(current, index + num2);
                        if ((((uint) num) & 0) == 0)
                        {
                        }
                        goto Label_005F;
                    Label_0057:
                        if (current.IsPredict)
                        {
                            goto Label_002C;
                        }
                    Label_005F:
                        if (enumerator.MoveNext())
                        {
                            current = enumerator.Current;
                            goto Label_0057;
                        }
                    }
                    num2++;
                }
                if ((((uint) num) - ((uint) num2)) >= 0)
                {
                    return data;
                }
            }
            throw new TemporalError("Can't generate prediction temporal data beyond the end of provided data.");
        }

        public virtual int GetSequenceFromDate(DateTime when)
        {
            if (this._xdfd26d6ad22d5e81 != DateTime.MinValue)
            {
                if (0 == 0)
                {
                }
                xfa6e3ed04cba2b4d xfaeedcbabd = new xfa6e3ed04cba2b4d(this._xdfd26d6ad22d5e81, when);
                return (int) xfaeedcbabd.xeeb06d6ba66e71e9(this._xa9e977193de61cf0);
            }
            this._xdfd26d6ad22d5e81 = when;
            return 0;
        }

        public virtual bool IsPointInRange(TemporalPoint point)
        {
            return ((point.Sequence >= this.LowSequence) && (point.Sequence <= this.HighSequence));
        }

        public virtual void SortPoints()
        {
            this._x6fa2570084b2ad39.Sort();
        }

        private double x0f80f6735d6ae7a3(TemporalDataDescription x3253f43e16d3c2a3, int xc0c4c459c6ccbd00)
        {
            TemporalPoint point = this._x6fa2570084b2ad39[xc0c4c459c6ccbd00 - 1];
            return point[x3253f43e16d3c2a3.Index];
        }

        private double x8c7fc30b887213d1(TemporalDataDescription x3253f43e16d3c2a3, int xc0c4c459c6ccbd00)
        {
            double[] d = new double[1];
            switch (x3253f43e16d3c2a3.DescriptionType)
            {
                case TemporalDataDescription.Type.Raw:
                    d[0] = this.x0f80f6735d6ae7a3(x3253f43e16d3c2a3, xc0c4c459c6ccbd00);
                    break;

                case TemporalDataDescription.Type.PercentChange:
                    d[0] = this.xea9b27496fd731f6(x3253f43e16d3c2a3, xc0c4c459c6ccbd00);
                    if (0 == 0)
                    {
                        break;
                    }
                    goto Label_009C;

                case TemporalDataDescription.Type.DeltaChange:
                    d[0] = this.xb45e1635c92024eb(x3253f43e16d3c2a3, xc0c4c459c6ccbd00);
                    break;

                default:
                    goto Label_009C;
            }
        Label_001C:
            if (x3253f43e16d3c2a3.ActivationFunction != null)
            {
                x3253f43e16d3c2a3.ActivationFunction.ActivationFunction(d, 0, 1);
                if (((uint) xc0c4c459c6ccbd00) < 0)
                {
                    goto Label_001C;
                }
            }
        Label_009C:
            return d[0];
        }

        private double xb45e1635c92024eb(TemporalDataDescription x3253f43e16d3c2a3, int xc0c4c459c6ccbd00)
        {
            if (xc0c4c459c6ccbd00 == 0)
            {
                return 0.0;
            }
            TemporalPoint point = this._x6fa2570084b2ad39[xc0c4c459c6ccbd00];
            TemporalPoint point2 = this._x6fa2570084b2ad39[xc0c4c459c6ccbd00 - 1];
            return (point[x3253f43e16d3c2a3.Index] - point2[x3253f43e16d3c2a3.Index]);
        }

        private double xea9b27496fd731f6(TemporalDataDescription x3253f43e16d3c2a3, int xc0c4c459c6ccbd00)
        {
            double num;
            double num2;
            if (xc0c4c459c6ccbd00 == 0)
            {
                return 0.0;
            }
            TemporalPoint point = this._x6fa2570084b2ad39[xc0c4c459c6ccbd00];
            TemporalPoint point2 = this._x6fa2570084b2ad39[xc0c4c459c6ccbd00 - 1];
            do
            {
                num = point[x3253f43e16d3c2a3.Index];
                num2 = point2[x3253f43e16d3c2a3.Index];
            }
            while ((((uint) num) | 3) == 0);
            return ((num - num2) / num2);
        }

        public virtual IList<TemporalDataDescription> Descriptions
        {
            get
            {
                return this._x6849a3dfb0329317;
            }
        }

        public virtual int DesiredSetSize
        {
            get
            {
                return this._x7293ed6d89c57cf3;
            }
            set
            {
                this._x7293ed6d89c57cf3 = value;
            }
        }

        public virtual int HighSequence
        {
            get
            {
                return this._xc4bd189fc1348058;
            }
            set
            {
                this._xc4bd189fc1348058 = value;
            }
        }

        public virtual int InputNeuronCount
        {
            get
            {
                return this._x57202a8751db8895;
            }
            set
            {
                this._x57202a8751db8895 = value;
            }
        }

        public virtual int InputWindowSize
        {
            get
            {
                return this._xc278386c02fd6e51;
            }
            set
            {
                this._xc278386c02fd6e51 = value;
            }
        }

        public virtual int LowSequence
        {
            get
            {
                return this._xd5b5c9323338bee2;
            }
            set
            {
                this._xd5b5c9323338bee2 = value;
            }
        }

        public virtual int OutputNeuronCount
        {
            get
            {
                return this._x0c37ff3adde9bc44;
            }
            set
            {
                this._x0c37ff3adde9bc44 = value;
            }
        }

        public virtual IList<TemporalPoint> Points
        {
            get
            {
                return this._x6fa2570084b2ad39;
            }
        }

        public virtual int PredictWindowSize
        {
            get
            {
                return this._xcfe8f2ba20a6a8e4;
            }
            set
            {
                this._xcfe8f2ba20a6a8e4 = value;
            }
        }

        public virtual TimeUnit SequenceGrandularity
        {
            get
            {
                return this._xa9e977193de61cf0;
            }
            set
            {
                this._xa9e977193de61cf0 = value;
            }
        }

        public virtual DateTime StartingPoint
        {
            get
            {
                return this._xdfd26d6ad22d5e81;
            }
            set
            {
                this._xdfd26d6ad22d5e81 = value;
            }
        }
    }
}

