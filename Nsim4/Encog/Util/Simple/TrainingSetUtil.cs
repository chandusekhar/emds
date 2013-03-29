namespace Encog.Util.Simple
{
    using Encog.ML.Data;
    using Encog.ML.Data.Basic;
    using Encog.Util;
    using Encog.Util.CSV;
    using System;

    public class TrainingSetUtil
    {
        public static IMLDataSet LoadCSVTOMemory(CSVFormat format, string filename, bool headers, int inputSize, int idealSize)
        {
            ReadCSV dcsv;
            IMLData data;
            int num;
            IMLData data2;
            int num4;
            IMLDataSet set = new BasicMLDataSet();
            goto Label_00FF;
        Label_000B:
            if (idealSize > 0)
            {
                data = new BasicMLData(idealSize);
                num4 = 0;
                while (num4 < idealSize)
                {
                    double num5 = dcsv.GetDouble(num++);
                    data[num4] = num5;
                    num4++;
                }
            }
            IMLDataPair inputData = new BasicMLDataPair(data2, data);
            set.Add(inputData);
        Label_0022:
            if (!dcsv.Next())
            {
                return set;
            }
        Label_00C4:
            data = null;
            num = 0;
            if (((uint) num4) < 0)
            {
                goto Label_0108;
            }
            data2 = new BasicMLData(inputSize);
            int num2 = 0;
        Label_006A:
            if (num2 < inputSize)
            {
                double num3 = dcsv.GetDouble(num++);
                if (-2147483648 != 0)
                {
                    data2[num2] = num3;
                    if ((((uint) idealSize) + ((uint) num)) >= 0)
                    {
                        num2++;
                    }
                    if ((((uint) num) - ((uint) idealSize)) >= 0)
                    {
                        goto Label_006A;
                    }
                    goto Label_0125;
                }
            }
            else
            {
                if (0 == 0)
                {
                    goto Label_000B;
                }
                if (0 == 0)
                {
                    goto Label_0125;
                }
            }
            goto Label_00C4;
        Label_00FF:
            dcsv = new ReadCSV(filename, headers, format);
        Label_0108:
            if ((((uint) num) + ((uint) num2)) < 0)
            {
                goto Label_00FF;
            }
            goto Label_0022;
        Label_0125:
            if (((uint) num4) >= 0)
            {
                goto Label_000B;
            }
            return set;
        }

        public static ObjectPair<double[][], double[][]> TrainingToArray(IMLDataSet training)
        {
            int count = (int) training.Count;
            double[][] a = EngineArray.AllocateDouble2D(count, training.InputSize);
            double[][] b = EngineArray.AllocateDouble2D(count, training.IdealSize);
            int index = 0;
            foreach (IMLDataPair pair in training)
            {
            Label_0037:
                EngineArray.ArrayCopy(pair.InputArray, a[index]);
                EngineArray.ArrayCopy(pair.IdealArray, b[index]);
                index++;
            }
            if (((uint) count) < 0)
            {
                goto Label_0037;
            }
            return new ObjectPair<double[][], double[][]>(a, b);
        }
    }
}

