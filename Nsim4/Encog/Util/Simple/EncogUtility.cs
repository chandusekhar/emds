namespace Encog.Util.Simple
{
    using Encog;
    using Encog.App.Analyst.CSV.Basic;
    using Encog.Engine.Network.Activation;
    using Encog.MathUtil.Error;
    using Encog.ML;
    using Encog.ML.Data;
    using Encog.ML.Data.Basic;
    using Encog.ML.Data.Buffer;
    using Encog.ML.Data.Buffer.CODEC;
    using Encog.ML.Data.Specific;
    using Encog.ML.Train;
    using Encog.Neural.Networks;
    using Encog.Neural.Networks.Training.Propagation;
    using Encog.Neural.Networks.Training.Propagation.Resilient;
    using Encog.Neural.Pattern;
    using Encog.Util;
    using Encog.Util.CSV;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class EncogUtility
    {
        private EncogUtility()
        {
        }

        public static double CalculateClassificationError(IMLClassification method, IMLDataSet data)
        {
            int num = 0;
            int num2 = 0;
            using (IEnumerator<IMLDataPair> enumerator = data.GetEnumerator())
            {
                int num3;
                int num4;
                goto Label_001B;
            Label_000E:
                if (num4 != num3)
                {
                    goto Label_0017;
                }
            Label_0013:
                num2++;
            Label_0017:
                num++;
            Label_001B:
                if (!enumerator.MoveNext())
                {
                    if (((uint) num2) > uint.MaxValue)
                    {
                        goto Label_0013;
                    }
                }
                else
                {
                    IMLDataPair current = enumerator.Current;
                    num3 = (int) current.Ideal[0];
                    num4 = method.Classify(current.Input);
                    goto Label_000E;
                }
            }
            return (((double) (num - num2)) / ((double) num));
        }

        public static double CalculateRegressionError(IMLRegression method, IMLDataSet data)
        {
            ErrorCalculation calculation = new ErrorCalculation();
            if (method is IMLContext)
            {
                ((IMLContext) method).ClearContext();
            }
            foreach (IMLDataPair pair in data)
            {
                IMLData data2 = method.Compute(pair.Input);
                calculation.UpdateError(data2.Data, pair.Ideal.Data, pair.Significance);
            }
            return calculation.Calculate();
        }

        public static void ConvertCSV2Binary(FileInfo csvFile, CSVFormat format, FileInfo binFile, int[] input, int[] ideal, bool headers)
        {
            ReadCSV dcsv;
            BufferedMLDataSet set;
            BasicMLData data;
            BasicMLData data2;
            int num;
            int num2;
            binFile.Delete();
            goto Label_00FB;
        Label_0021:
            if (dcsv.Next() || ((((uint) num) - ((uint) num2)) > uint.MaxValue))
            {
                data = new BasicMLData(input.Length);
                if ((((uint) headers) | uint.MaxValue) != 0)
                {
                    data2 = new BasicMLData(ideal.Length);
                    if (4 != 0)
                    {
                        if (((uint) num) <= uint.MaxValue)
                        {
                            goto Label_0073;
                        }
                        goto Label_00FB;
                    }
                }
                goto Label_00C0;
            }
            set.EndLoad();
            if (0 == 0)
            {
                return;
            }
        Label_0073:
            num = 0;
            while (num < input.Length)
            {
                data[num] = dcsv.GetDouble(input[num]);
                num++;
            }
            for (num2 = 0; num2 < ideal.Length; num2++)
            {
                data2[num2] = dcsv.GetDouble(ideal[num2]);
            }
            set.Add(data, data2);
            goto Label_0021;
        Label_00C0:
            set = new BufferedMLDataSet(binFile.ToString());
            set.BeginLoad(input.Length, ideal.Length);
            goto Label_0021;
        Label_00FB:
            dcsv = new ReadCSV(csvFile.ToString(), headers, format);
            goto Label_00C0;
        }

        public static void ConvertCSV2Binary(string csvFile, CSVFormat format, string binFile, int inputCount, int outputCount, bool headers, bool expectSignificance)
        {
            new FileInfo(binFile).Delete();
            CSVMLDataSet set = new CSVMLDataSet(csvFile, inputCount, outputCount, false, format, expectSignificance);
            BufferedMLDataSet set2 = new BufferedMLDataSet(binFile);
            set2.BeginLoad(inputCount, outputCount);
            if ((((uint) inputCount) & 0) == 0)
            {
                foreach (IMLDataPair pair in set)
                {
                    set2.Add(pair);
                }
                set2.EndLoad();
            }
        }

        public static void Evaluate(IMLRegression network, IMLDataSet training)
        {
            using (IEnumerator<IMLDataPair> enumerator = training.GetEnumerator())
            {
                IMLDataPair pair;
                IMLData data;
                string[] strArray;
            Label_0009:
                if (!enumerator.MoveNext())
                {
                    if (2 == 0)
                    {
                        goto Label_005B;
                    }
                    if (0 == 0)
                    {
                        return;
                    }
                }
                goto Label_0095;
            Label_0026:
                strArray[4] = ", Ideal=";
            Label_002E:
                strArray[5] = x8d742ff2b6748ce6(pair.Ideal);
                Console.WriteLine(string.Concat(strArray));
                if (0 == 0)
                {
                    goto Label_00A3;
                }
                goto Label_0095;
            Label_004C:
                strArray = new string[6];
                strArray[0] = "Input=";
            Label_005B:
                strArray[1] = x8d742ff2b6748ce6(pair.Input);
                strArray[2] = ", Actual=";
                strArray[3] = x8d742ff2b6748ce6(data);
                goto Label_0026;
            Label_007C:
                if (0 != 0)
                {
                    goto Label_002E;
                }
                data = network.Compute(pair.Input);
                if (1 != 0)
                {
                    goto Label_004C;
                }
                goto Label_0026;
            Label_0095:
                pair = enumerator.Current;
                goto Label_007C;
            Label_00A3:
                if (0xff != 0)
                {
                    goto Label_0009;
                }
            }
        }

        public static IMLDataSet LoadCSV2Memory(string filename, int input, int ideal, bool headers, CSVFormat format, bool expectSignificance)
        {
            IDataSetCODEC codec = new CSVDataCODEC(filename, format, headers, input, ideal, expectSignificance);
            MemoryDataLoader loader = new MemoryDataLoader(codec);
            return loader.External2Memory();
        }

        public static IMLDataSet LoadEGB2Memory(FileInfo filename)
        {
            BufferedMLDataSet set = new BufferedMLDataSet(filename.ToString());
            return set.LoadToMemory();
        }

        public static void SaveCSV(FileInfo targetFile, CSVFormat format, IMLDataSet set)
        {
            try
            {
                StreamWriter writer = new StreamWriter(targetFile.ToString());
                using (IEnumerator<IMLDataPair> enumerator = set.GetEnumerator())
                {
                    IMLDataPair pair;
                    StringBuilder builder;
                    int num;
                    double num2;
                    int num3;
                    double num4;
                    goto Label_002E;
                Label_0016:
                    if ((((uint) num2) + ((uint) num2)) >= 0)
                    {
                    }
                Label_002E:
                    if (enumerator.MoveNext())
                    {
                        goto Label_00F5;
                    }
                    goto Label_012F;
                Label_003F:
                    writer.WriteLine(builder);
                    goto Label_0117;
                Label_004B:
                    BasicFile.AppendSeparator(builder, format);
                    builder.Append(format.Format(num4, 10));
                    num3++;
                Label_0069:
                    if (num3 >= pair.Ideal.Count)
                    {
                        if (3 != 0)
                        {
                            goto Label_003F;
                        }
                    }
                    else
                    {
                        num4 = pair.Ideal[num3];
                        goto Label_004B;
                    }
                Label_0094:
                    BasicFile.AppendSeparator(builder, format);
                    builder.Append(format.Format(num2, 10));
                    num++;
                Label_00B0:
                    if (num < pair.Input.Count)
                    {
                        goto Label_0107;
                    }
                    num3 = 0;
                    goto Label_0069;
                Label_00CF:
                    if (15 == 0)
                    {
                        goto Label_0069;
                    }
                    if ((((uint) num3) | 0xff) != 0)
                    {
                        goto Label_0094;
                    }
                Label_00F5:
                    pair = enumerator.Current;
                    builder = new StringBuilder();
                    num = 0;
                    goto Label_00B0;
                Label_0107:
                    num2 = pair.Input[num];
                    goto Label_00CF;
                Label_0117:
                    if (-2147483648 != 0)
                    {
                        goto Label_0016;
                    }
                }
            Label_012F:
                writer.Close();
            }
            catch (IOException exception)
            {
                throw new EncogError(exception);
            }
        }

        public static void SaveEGB(FileInfo egbFile, IMLDataSet data)
        {
            new BufferedMLDataSet(egbFile.ToString()).Load(data);
            data.Close();
        }

        public static BasicNetwork SimpleFeedForward(int input, int hidden1, int hidden2, int output, bool tanh)
        {
            FeedForwardPattern pattern;
            BasicNetwork network;
            FeedForwardPattern pattern2 = new FeedForwardPattern();
            if (((uint) output) < 0)
            {
                goto Label_002E;
            }
            pattern2.InputNeurons = input;
            goto Label_00BC;
        Label_000D:
            pattern.AddHiddenLayer(hidden2);
            goto Label_001A;
        Label_0016:
            if (hidden2 > 0)
            {
                goto Label_000D;
            }
        Label_001A:
            network = (BasicNetwork) pattern.Generate();
            network.Reset();
            return network;
        Label_002E:
            if ((((uint) tanh) | 3) != 0)
            {
                goto Label_0067;
            }
            if ((((uint) output) - ((uint) hidden2)) < 0)
            {
                goto Label_000D;
            }
        Label_005E:
            pattern.AddHiddenLayer(hidden1);
            goto Label_0016;
        Label_0067:
            if (hidden1 > 0)
            {
                goto Label_005E;
            }
            if ((((uint) input) + ((uint) hidden1)) >= 0)
            {
                goto Label_0016;
            }
            return network;
        Label_00BC:
            pattern2.OutputNeurons = output;
            pattern = pattern2;
            if (tanh)
            {
                pattern.ActivationFunction = new ActivationTANH();
                goto Label_0067;
            }
            pattern.ActivationFunction = new ActivationSigmoid();
            if ((((uint) hidden2) + ((uint) output)) >= 0)
            {
                goto Label_002E;
            }
            goto Label_00BC;
        }

        public static void TrainConsole(BasicNetwork network, IMLDataSet trainingSet, int minutes)
        {
            ResilientPropagation propagation2 = new ResilientPropagation(network, trainingSet) {
                ThreadCount = 0
            };
            Encog.Neural.Networks.Training.Propagation.Propagation train = propagation2;
            TrainConsole(train, network, trainingSet, minutes);
        }

        public static void TrainConsole(IMLTrain train, BasicNetwork network, IMLDataSet trainingSet, int minutes)
        {
            long num2;
            long num4;
            long num5;
            int i = 1;
            Console.WriteLine("Beginning training...");
            long tickCount = Environment.TickCount;
            goto Label_018E;
        Label_0025:
            train.FinishTraining();
            if ((((uint) num5) & 0) != 0)
            {
                goto Label_018E;
            }
            return;
        Label_003A:
            if (((((uint) minutes) - ((uint) tickCount)) >= 0) && (0 == 0))
            {
                goto Label_0025;
            }
        Label_0052:
            if (num2 > 0L)
            {
                if (!train.TrainingDone)
                {
                    goto Label_018E;
                }
                goto Label_003A;
            }
            goto Label_0025;
        Label_018E:
            train.Iteration();
        Label_0194:
            num4 = Environment.TickCount;
            num5 = (num4 - tickCount) / 0x3e8L;
            num2 = minutes - (num5 / 60L);
            while (true)
            {
                string[] strArray = new string[8];
                if ((((uint) num5) | 4) == 0)
                {
                    goto Label_0194;
                }
                strArray[0] = "Iteration #";
                strArray[1] = Format.FormatInteger(i);
                strArray[2] = " Error:";
                strArray[3] = Format.FormatPercent(train.Error);
                strArray[4] = " elapsed time = ";
                if ((((uint) i) + ((uint) i)) >= 0)
                {
                    if ((((uint) num4) & 0) == 0)
                    {
                        if ((((uint) minutes) + ((uint) minutes)) > uint.MaxValue)
                        {
                            goto Label_0025;
                        }
                        if (((uint) num5) > uint.MaxValue)
                        {
                            goto Label_003A;
                        }
                        strArray[5] = Format.FormatTimeSpan((int) num5);
                        strArray[6] = " time left = ";
                    }
                    strArray[7] = Format.FormatTimeSpan(((int) num2) * 60);
                    Console.WriteLine(string.Concat(strArray));
                    i++;
                    goto Label_0052;
                }
            }
        }

        public static void TrainDialog(BasicNetwork network, IMLDataSet trainingSet)
        {
            ResilientPropagation propagation2 = new ResilientPropagation(network, trainingSet) {
                ThreadCount = 0
            };
            Encog.Neural.Networks.Training.Propagation.Propagation train = propagation2;
            TrainDialog(train, network, trainingSet);
        }

        public static void TrainDialog(IMLTrain train, BasicNetwork network, IMLDataSet trainingSet)
        {
            TrainingDialog dialog2 = new TrainingDialog {
                Train = train
            };
            dialog2.ShowDialog();
        }

        public static void TrainToError(IMLTrain train, double error)
        {
            int i = 1;
            if ((((uint) i) | 8) != 0)
            {
                goto Label_0048;
            }
        Label_001A:
            if (0 == 0)
            {
                return;
            }
        Label_0048:
            Console.Out.WriteLine("Beginning training...");
        Label_0057:
            train.Iteration();
            Console.Out.WriteLine("Iteration #" + Format.FormatInteger(i) + " Error:" + Format.FormatPercent(train.Error) + " Target Error: " + Format.FormatPercent(error));
            i++;
            while (train.Error > error)
            {
                if (!train.TrainingDone)
                {
                    goto Label_0057;
                }
                break;
            }
            train.FinishTraining();
            if (1 != 0)
            {
                goto Label_001A;
            }
            goto Label_0048;
        }

        public static void TrainToError(IMLTrain train, IMLDataSet trainingSet, double error)
        {
            string[] strArray;
            int i = 1;
            if ((((uint) i) - ((uint) error)) <= uint.MaxValue)
            {
                goto Label_00AF;
            }
            goto Label_0050;
        Label_0037:
            if ((train.Error > error) && !train.TrainingDone)
            {
                goto Label_00B9;
            }
            train.FinishTraining();
            if ((((uint) i) | 3) != 0)
            {
                return;
            }
            goto Label_00AF;
        Label_0050:
            strArray[1] = Format.FormatInteger(i);
            do
            {
                if (0 != 0)
                {
                    goto Label_0037;
                }
                strArray[2] = " Error:";
            }
            while ((((uint) error) + ((uint) i)) > uint.MaxValue);
            strArray[3] = Format.FormatPercent(train.Error);
            strArray[4] = " Target Error: ";
            strArray[5] = Format.FormatPercent(error);
            Console.WriteLine(string.Concat(strArray));
            i++;
            goto Label_0037;
        Label_00AF:
            Console.WriteLine("Beginning training...");
        Label_00B9:
            train.Iteration();
            strArray = new string[6];
            strArray[0] = "Iteration #";
            goto Label_0050;
        }

        public static void TrainToError(BasicNetwork network, IMLDataSet trainingSet, double error)
        {
            ResilientPropagation propagation2 = new ResilientPropagation(network, trainingSet) {
                ThreadCount = 0
            };
            Encog.Neural.Networks.Training.Propagation.Propagation train = propagation2;
            TrainToError(train, trainingSet, error);
        }

        private static string x8d742ff2b6748ce6(IMLData x4a3f0a05c02f235f)
        {
            int num;
            StringBuilder builder = new StringBuilder();
            if (-2 != 0)
            {
                num = 0;
                if (0 != 0)
                {
                    goto Label_005C;
                }
            }
            do
            {
                if (0 == 0)
                {
                }
                while (num < x4a3f0a05c02f235f.Count)
                {
                    if (num != 0)
                    {
                        builder.Append(',');
                    }
                    builder.Append(Format.FormatDouble(x4a3f0a05c02f235f[num], 4));
                    num++;
                }
            }
            while (((uint) num) > uint.MaxValue);
        Label_005C:
            return builder.ToString();
        }
    }
}

