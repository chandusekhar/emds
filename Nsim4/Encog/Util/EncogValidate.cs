namespace Encog.Util
{
    using Encog.ML.Data;
    using Encog.Neural;
    using Encog.Neural.Networks;
    using System;

    public sealed class EncogValidate
    {
        private EncogValidate()
        {
        }

        public static void ValidateNetworkForTraining(IContainsFlat network, IMLDataSet training)
        {
            int num2;
            object[] objArray;
            object[] objArray2;
            int inputCount = network.Flat.InputCount;
            if (((uint) num2) <= uint.MaxValue)
            {
            Label_01D4:
                num2 = network.Flat.OutputCount;
                if (inputCount != training.InputSize)
                {
                    objArray = new object[5];
                    objArray[0] = "The input layer size of ";
                    if (15 != 0)
                    {
                        objArray[1] = inputCount;
                        goto Label_0187;
                    }
                    goto Label_01D4;
                }
                if ((((uint) num2) - ((uint) inputCount)) >= 0)
                {
                    goto Label_008F;
                }
                goto Label_0098;
            }
            goto Label_0187;
        Label_0088:
            if (-2 != 0)
            {
                goto Label_0098;
            }
        Label_008F:
            if (training.IdealSize <= 0)
            {
                if ((((uint) inputCount) + ((uint) inputCount)) <= uint.MaxValue)
                {
                    return;
                }
                goto Label_0088;
            }
        Label_0098:
            if (num2 != training.IdealSize)
            {
                objArray2 = new object[5];
                objArray2[0] = "The output layer size of ";
            }
            else
            {
                return;
                if ((((uint) num2) + ((uint) inputCount)) <= uint.MaxValue)
                {
                    goto Label_0088;
                }
                goto Label_008F;
            }
        Label_00ED:
            objArray2[1] = num2;
            objArray2[2] = " must match the training input size of ";
            objArray2[3] = training.IdealSize;
            objArray2[4] = ".";
            throw new NeuralNetworkError(string.Concat(objArray2));
            if ((((uint) num2) | uint.MaxValue) != 0)
            {
                return;
            }
            if ((((uint) inputCount) & 0) == 0)
            {
                goto Label_0187;
            }
        Label_013A:
            objArray[3] = training.InputSize;
            objArray[4] = ".";
            throw new NeuralNetworkError(string.Concat(objArray));
        Label_0187:
            if ((((uint) inputCount) + ((uint) num2)) > uint.MaxValue)
            {
                goto Label_00ED;
            }
            objArray[2] = " must match the training input size of ";
            goto Label_013A;
        }
    }
}

