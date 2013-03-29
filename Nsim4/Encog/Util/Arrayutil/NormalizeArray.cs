namespace Encog.Util.Arrayutil
{
    using System;

    public class NormalizeArray
    {
        private double _x136bfff0efb12047 = -1.0;
        private NormalizedField _x24d1ebc88ca906aa;
        private double _x891507b50bbab0f9 = 1.0;

        public double[] Process(double[] inputArray)
        {
            double num;
            double[] numArray;
            int num2;
            int num3;
            this._x24d1ebc88ca906aa = new NormalizedField();
            goto Label_0097;
        Label_0010:
            if (num2 >= inputArray.Length)
            {
                goto Label_0085;
            }
        Label_0023:
            numArray[num2] = this._x24d1ebc88ca906aa.Normalize(inputArray[num2]);
            num2++;
            if ((((uint) num2) - ((uint) num3)) <= uint.MaxValue)
            {
                goto Label_0010;
            }
        Label_0085:
            if (((uint) num3) <= uint.MaxValue)
            {
                return numArray;
            }
        Label_0097:
            this._x24d1ebc88ca906aa.NormalizedHigh = this._x891507b50bbab0f9;
            if ((((uint) num) - ((uint) num)) > uint.MaxValue)
            {
                goto Label_0023;
            }
            this._x24d1ebc88ca906aa.NormalizedLow = this._x136bfff0efb12047;
            double[] numArray2 = inputArray;
            num3 = 0;
            while (true)
            {
                if (num3 >= numArray2.Length)
                {
                    numArray = new double[inputArray.Length];
                    num2 = 0;
                    goto Label_0010;
                }
                num = numArray2[num3];
                this._x24d1ebc88ca906aa.Analyze(num);
                num3++;
            }
        }

        public double NormalizedHigh
        {
            get
            {
                return this._x891507b50bbab0f9;
            }
            set
            {
                this._x891507b50bbab0f9 = value;
            }
        }

        public double NormalizedLow
        {
            get
            {
                return this._x136bfff0efb12047;
            }
            set
            {
                this._x136bfff0efb12047 = value;
            }
        }

        public NormalizedField Stats
        {
            get
            {
                return this._x24d1ebc88ca906aa;
            }
        }
    }
}

