namespace Encog.Util.Arrayutil
{
    using Encog.ML.Data;
    using Encog.ML.Data.Basic;
    using System;
    using System.Linq;
    using System.Runtime.CompilerServices;

    public class TemporalWindowArray
    {
        private int _x819dc6aed7346fc6;
        private TemporalWindowField[] _xa942970cc8a85fd4;
        private int _xdf118c3be13cc35d;
        [CompilerGenerated]
        private static Func<TemporalWindowField, bool> x1ecac4c96d3f3733;
        [CompilerGenerated]
        private static Func<TemporalWindowField, bool> xec790bb6d0304faa;

        public TemporalWindowArray(int theInputWindow, int thePredictWindow)
        {
            this._xdf118c3be13cc35d = theInputWindow;
            this._x819dc6aed7346fc6 = thePredictWindow;
        }

        public void Analyze(double[] array)
        {
            this._xa942970cc8a85fd4 = new TemporalWindowField[1];
            TemporalWindowField field = new TemporalWindowField("0") {
                Action = TemporalType.InputAndPredict
            };
            this._xa942970cc8a85fd4[0] = field;
        }

        public void Analyze(double[][] array)
        {
            int num2;
            TemporalWindowField field;
            int length = array[0].Length;
            if ((((uint) length) & 0) == 0)
            {
                this._xa942970cc8a85fd4 = new TemporalWindowField[length];
                goto Label_0069;
            }
            if ((((uint) num2) + ((uint) length)) > uint.MaxValue)
            {
                goto Label_0069;
            }
        Label_0032:
            field = new TemporalWindowField(num2);
            field.Action = TemporalType.InputAndPredict;
            this._xa942970cc8a85fd4[num2] = field;
            num2++;
        Label_0057:
            if (num2 < length)
            {
                goto Label_0032;
            }
            return;
        Label_0069:
            num2 = 0;
            goto Label_0057;
        }

        public int CountInputFields()
        {
            if (x1ecac4c96d3f3733 == null)
            {
                x1ecac4c96d3f3733 = new Func<TemporalWindowField, bool>(TemporalWindowArray.x14209e42cc223217);
            }
            return this._xa942970cc8a85fd4.Count<TemporalWindowField>(x1ecac4c96d3f3733);
        }

        public int CountPredictFields()
        {
            if (xec790bb6d0304faa == null)
            {
                xec790bb6d0304faa = new Func<TemporalWindowField, bool>(TemporalWindowArray.xe31791d60f78a8cb);
            }
            return this._xa942970cc8a85fd4.Count<TemporalWindowField>(xec790bb6d0304faa);
        }

        public IMLDataSet Process(double[] data)
        {
            int num;
            int num2;
            int num3;
            IMLData data2;
            IMLData data3;
            int num4;
            int num6;
            IMLDataSet set = new BasicMLDataSet();
            goto Label_00F0;
        Label_0017:
            if (num3 < num2)
            {
                int num5;
                data2 = new BasicMLData(this._xdf118c3be13cc35d);
                do
                {
                    data3 = new BasicMLData(this._x819dc6aed7346fc6);
                    if ((((uint) num3) | 3) == 0)
                    {
                        goto Label_004D;
                    }
                    num4 = num3;
                }
                while ((((uint) num3) - ((uint) num5)) < 0);
                num5 = 0;
                if ((((uint) num5) | 0xff) != 0)
                {
                Label_007A:
                    if (num5 < this._xdf118c3be13cc35d)
                    {
                        data2[num5] = data[num4++];
                        if ((((uint) num3) + ((uint) num5)) <= uint.MaxValue)
                        {
                            num5++;
                            goto Label_007A;
                        }
                    }
                    num6 = 0;
                    goto Label_0053;
                }
                goto Label_00F0;
            }
            return set;
        Label_004D:
            num6++;
        Label_0053:
            if (num6 < this._x819dc6aed7346fc6)
            {
                data3[num6] = data[num4++];
                if ((((uint) num6) | 15) == 0)
                {
                    return set;
                }
                goto Label_004D;
            }
            IMLDataPair inputData = new BasicMLDataPair(data2, data3);
            set.Add(inputData);
            num3++;
            goto Label_0017;
        Label_00F0:
            num = this._xdf118c3be13cc35d + this._x819dc6aed7346fc6;
            num2 = data.Length - num;
            num3 = 0;
            goto Label_0017;
        }

        [CompilerGenerated]
        private static bool x14209e42cc223217(TemporalWindowField xe01ae93d9fe5a880)
        {
            return xe01ae93d9fe5a880.Input;
        }

        [CompilerGenerated]
        private static bool xe31791d60f78a8cb(TemporalWindowField xe01ae93d9fe5a880)
        {
            return xe01ae93d9fe5a880.Predict;
        }

        public TemporalWindowField[] Fields
        {
            get
            {
                return this._xa942970cc8a85fd4;
            }
        }

        public int InputWindow
        {
            get
            {
                return this._xdf118c3be13cc35d;
            }
            set
            {
                this._xdf118c3be13cc35d = value;
            }
        }

        public int PredictWindow
        {
            get
            {
                return this._x819dc6aed7346fc6;
            }
            set
            {
                this._x819dc6aed7346fc6 = value;
            }
        }
    }
}

