namespace Encog.MathUtil.Randomize
{
    using Encog.MathUtil.Matrices;
    using Encog.ML;
    using Encog.Neural.Networks;
    using System;

    public abstract class BasicRandomizer : IRandomizer
    {
        private System.Random _x789e39dcd1bd39db = new System.Random((int) (DateTime.Now.Ticks * 100L));

        protected BasicRandomizer()
        {
        }

        public double NextDouble()
        {
            return this._x789e39dcd1bd39db.NextDouble();
        }

        public double NextDouble(double min, double max)
        {
            double num = max - min;
            return ((num * this._x789e39dcd1bd39db.NextDouble()) + min);
        }

        public virtual void Randomize(double[][] d)
        {
            int num2;
            double[][] numArray2 = d;
        Label_0037:
            num2 = 0;
        Label_0004:
            if (num2 < numArray2.Length)
            {
                double[] numArray;
            Label_003B:
                numArray = numArray2[num2];
                int index = 0;
                while (index < d[0].Length)
                {
                    numArray[index] = this.Randomize(numArray[index]);
                    index++;
                    if ((((uint) index) + ((uint) index)) < 0)
                    {
                        goto Label_003B;
                    }
                }
                num2++;
                if (0 == 0)
                {
                    goto Label_0004;
                }
                goto Label_0037;
            }
        }

        public virtual void Randomize(double[] d)
        {
            this.Randomize(d, 0, d.Length);
        }

        public virtual void Randomize(Matrix m)
        {
            int num;
            int num2;
            double[][] data = m.Data;
            if ((((uint) num2) - ((uint) num2)) <= uint.MaxValue)
            {
                goto Label_004E;
            }
        Label_001F:
            if (0 == 0)
            {
            }
            num2++;
        Label_0026:
            if (num2 < m.Cols)
            {
                data[num][num2] = this.Randomize(data[num][num2]);
                goto Label_001F;
            }
            num++;
        Label_0033:
            if (num < m.Rows)
            {
                num2 = 0;
                goto Label_0026;
            }
            if (((uint) num) >= 0)
            {
                return;
            }
        Label_004E:
            num = 0;
            goto Label_0033;
        }

        public virtual void Randomize(IMLMethod method)
        {
            BasicNetwork network;
            int num;
            IMLEncodable encodable;
            double[] numArray;
            if (!(method is BasicNetwork))
            {
                if (!(method is IMLEncodable))
                {
                    return;
                }
                encodable = (IMLEncodable) method;
                goto Label_0067;
            }
            if (((uint) num) <= uint.MaxValue)
            {
                goto Label_008D;
            }
            if ((((uint) num) + ((uint) num)) >= 0)
            {
                goto Label_004C;
            }
        Label_0035:
            encodable.EncodeToArray(numArray);
            this.Randomize(numArray);
            encodable.DecodeFromArray(numArray);
            if ((((uint) num) - ((uint) num)) >= 0)
            {
                return;
            }
            goto Label_008D;
        Label_004C:
            while (num < (network.LayerCount - 1))
            {
                this.Randomize(network, num);
                num++;
            }
            return;
        Label_0067:
            numArray = new double[encodable.EncodedArrayLength()];
            goto Label_0035;
        Label_008D:
            network = (BasicNetwork) method;
            num = 0;
            if (0 != 0)
            {
                goto Label_0067;
            }
            goto Label_004C;
        }

        public abstract double Randomize(double d);
        public virtual void Randomize(BasicNetwork network, int fromLayer)
        {
            int num4;
            double num5;
            int layerTotalNeuronCount = network.GetLayerTotalNeuronCount(fromLayer);
            int layerNeuronCount = network.GetLayerNeuronCount(fromLayer + 1);
            int fromNeuron = 0;
            goto Label_002C;
        Label_000D:
            fromNeuron++;
            if ((((uint) fromNeuron) + ((uint) fromNeuron)) > uint.MaxValue)
            {
                goto Label_004B;
            }
            if (0 != 0)
            {
                goto Label_003C;
            }
        Label_002C:
            if (fromNeuron < layerTotalNeuronCount)
            {
                goto Label_0067;
            }
            return;
        Label_003C:
            network.SetWeight(fromLayer, fromNeuron, num4, num5);
            num4++;
        Label_004B:
            if (num4 < layerNeuronCount)
            {
                num5 = network.GetWeight(fromLayer, fromNeuron, num4);
                if (((uint) num5) >= 0)
                {
                    num5 = this.Randomize(num5);
                    goto Label_003C;
                }
                goto Label_000D;
            }
            if ((((uint) fromLayer) + ((uint) fromLayer)) >= 0)
            {
                goto Label_000D;
            }
        Label_0067:
            num4 = 0;
            goto Label_004B;
        }

        public virtual void Randomize(double[] d, int begin, int size)
        {
            for (int i = 0; i < size; i++)
            {
                d[begin + i] = this.Randomize(d[begin + i]);
            }
        }

        public System.Random Random
        {
            get
            {
                return this._x789e39dcd1bd39db;
            }
            set
            {
                this._x789e39dcd1bd39db = value;
            }
        }
    }
}

