namespace Encog.Neural.Thermal
{
    using Encog.MathUtil.Matrices;
    using Encog.ML.Data;
    using Encog.ML.Data.Specific;
    using Encog.Neural;
    using Encog.Util;
    using System;

    [Serializable]
    public class HopfieldNetwork : ThermalNetwork
    {
        public HopfieldNetwork()
        {
        }

        public HopfieldNetwork(int neuronCount) : base(neuronCount)
        {
        }

        public void AddPattern(IMLData pattern)
        {
            object[] objArray;
            if (pattern.Count != base.NeuronCount)
            {
                objArray = new object[4];
                if (0 == 0)
                {
                    objArray[0] = "Network with ";
                    do
                    {
                        if (0 != 0)
                        {
                            return;
                        }
                    }
                    while (0 != 0);
                    objArray[1] = base.NeuronCount;
                    objArray[2] = " neurons, cannot learn a pattern of size ";
                    objArray[3] = pattern.Count;
                }
            }
            else
            {
                Matrix b = Matrix.CreateRowMatrix(pattern.Data);
                Matrix a = MatrixMath.Multiply(MatrixMath.Transpose(b), b);
                Matrix matrix4 = MatrixMath.Identity(a.Rows);
                Matrix delta = MatrixMath.Subtract(a, matrix4);
                this.ConvertHopfieldMatrix(delta);
                if (0 == 0)
                {
                    return;
                }
            }
            throw new NeuralNetworkError(string.Concat(objArray));
        }

        public sealed override IMLData Compute(IMLData input)
        {
            int num;
            BiPolarMLData data = new BiPolarMLData(input.Count);
            if (0 == 0)
            {
                if (((uint) num) <= uint.MaxValue)
                {
                    if (3 == 0)
                    {
                        return data;
                    }
                    goto Label_0053;
                }
            }
            else
            {
                goto Label_0053;
            }
        Label_003B:
            EngineArray.ArrayCopy(base.CurrentState.Data, data.Data);
            return data;
        Label_0053:
            EngineArray.ArrayCopy(input.Data, base.CurrentState.Data);
            this.Run();
            for (num = 0; num < base.CurrentState.Count; num++)
            {
                data.SetBoolean(num, BiPolarUtil.Double2bipolar(base.CurrentState[num]));
            }
            goto Label_003B;
        }

        private void ConvertHopfieldMatrix(Matrix delta)
        {
            for (int i = 0; i < delta.Rows; i++)
            {
                for (int j = 0; j < delta.Rows; j++)
                {
                    base.AddWeight(i, j, delta[i, j]);
                }
            }
        }

        public void Run()
        {
            int toNeuron = 0;
        Label_0008:
            if (toNeuron < base.NeuronCount)
            {
                double num2 = 0.0;
                for (int i = 0; i < base.NeuronCount; i++)
                {
                    num2 += base.CurrentState[i] * base.GetWeight(i, toNeuron);
                }
                base.CurrentState[toNeuron] = num2;
                if (0 != 0)
                {
                    goto Label_0008;
                }
            }
            else
            {
                return;
            }
            toNeuron++;
            goto Label_0008;
        }

        public int RunUntilStable(int max)
        {
            string str;
            int num;
            string str2;
            bool flag = false;
            if ((((uint) max) + ((uint) max)) <= uint.MaxValue)
            {
                str = base.CurrentState.ToString();
                num = 0;
                goto Label_0089;
            }
        Label_001A:
            str = str2;
            if (!flag)
            {
                goto Label_0089;
            }
            return num;
        Label_0024:
            if (str.Equals(str2))
            {
                flag = true;
                goto Label_001A;
            }
        Label_0046:
            if (num > max)
            {
                flag = true;
                if ((((uint) flag) | 0x7fffffff) == 0)
                {
                    goto Label_0072;
                }
            }
            goto Label_001A;
        Label_0072:
            if ((-2 != 0) || (((uint) max) < 0))
            {
                goto Label_0024;
            }
            goto Label_0046;
        Label_0089:
            this.Run();
            num++;
            if (((uint) flag) >= 0)
            {
                str2 = base.CurrentState.ToString();
                goto Label_0072;
            }
            goto Label_0024;
        }

        public override void UpdateProperties()
        {
        }

        public override int InputCount
        {
            get
            {
                return base.NeuronCount;
            }
        }

        public override int OutputCount
        {
            get
            {
                return base.NeuronCount;
            }
        }
    }
}

