namespace Encog.Util.Validate
{
    using Encog;
    using Encog.ML;
    using Encog.ML.Data;
    using System;

    public class ValidateNetwork
    {
        public static void ValidateMethodToData(IMLMethod method, IMLDataSet training)
        {
            int inputSize;
            int idealSize;
            int inputCount;
            int num4;
            object[] objArray2;
            if (method is IMLInput)
            {
                if (method is IMLOutput)
                {
                    inputSize = training.InputSize;
                    if ((((uint) inputSize) & 0) != 0)
                    {
                        goto Label_001F;
                    }
                    idealSize = training.IdealSize;
                    if ((((uint) inputCount) | 1) == 0)
                    {
                        goto Label_00B4;
                    }
                    inputCount = 0;
                    if (((uint) num4) <= uint.MaxValue)
                    {
                        if (((uint) num4) < 0)
                        {
                            goto Label_0150;
                        }
                        num4 = 0;
                        if (!(method is IMLInput))
                        {
                            goto Label_0150;
                        }
                        inputCount = ((IMLInput) method).InputCount;
                    }
                }
                else if (2 != 0)
                {
                    goto Label_018C;
                }
                if (((uint) num4) <= uint.MaxValue)
                {
                    goto Label_0150;
                }
                goto Label_013F;
            }
            goto Label_018C;
        Label_001F:
            objArray2[3] = idealSize;
            objArray2[4] = ". They must be the same.";
            throw new EncogError(string.Concat(objArray2));
        Label_00B4:
            if (inputCount != inputSize)
            {
                object[] objArray = new object[5];
                objArray[0] = "The machine learning method has an input length of ";
                objArray[1] = inputCount;
                if ((((uint) inputSize) & 0) == 0)
                {
                    objArray[2] = ", but the training data has ";
                    objArray[3] = inputSize;
                    if ((((uint) inputCount) + ((uint) num4)) >= 0)
                    {
                    }
                    objArray[4] = ". They must be the same.";
                    throw new EncogError(string.Concat(objArray));
                }
                return;
            }
            if ((idealSize > 0) && (num4 != idealSize))
            {
                objArray2 = new object[5];
                objArray2[0] = "The machine learning method has an output length of ";
                objArray2[1] = num4;
                objArray2[2] = ", but the training data has ";
                goto Label_001F;
            }
            return;
        Label_013F:
            num4 = ((IMLOutput) method).OutputCount;
            goto Label_00B4;
        Label_0150:
            if (method is IMLOutput)
            {
                goto Label_013F;
            }
            goto Label_00B4;
        Label_018C:
            throw new EncogError("This machine learning method is not compatible with the provided data.");
        }
    }
}

