namespace Encog.Util.Banchmark
{
    using Encog.MathUtil;
    using Encog.ML.Data;
    using Encog.ML.Data.Basic;
    using System;

    public class RandomTrainingFactory
    {
        private RandomTrainingFactory()
        {
        }

        public static void Generate(IMLDataSet training, long seed, int count, double min, double max)
        {
            int num;
            int idealSize;
            int num3;
            IMLData data;
            int num4;
            IMLData data2;
            int num5;
            LinearCongruentialGenerator generator = new LinearCongruentialGenerator(seed);
            goto Label_0111;
        Label_0023:
            if (num3 < count)
            {
                data = new BasicMLData(num);
                num4 = 0;
                while (true)
                {
                    if (num4 < num)
                    {
                        data[num4] = generator.Range(min, max);
                    }
                    else
                    {
                        data2 = new BasicMLData(idealSize);
                        num5 = 0;
                        goto Label_004D;
                    }
                    num4++;
                }
            }
            if ((((uint) num) - ((uint) num)) >= 0)
            {
                if ((((uint) num4) - ((uint) num3)) >= 0)
                {
                    if ((((uint) seed) + ((uint) seed)) >= 0)
                    {
                        return;
                    }
                    goto Label_0111;
                }
                goto Label_00F5;
            }
        Label_0047:
            num5++;
        Label_004D:
            if (num5 >= idealSize)
            {
                if ((((uint) max) + ((uint) num3)) <= uint.MaxValue)
                {
                    BasicMLDataPair inputData = new BasicMLDataPair(data, data2);
                    training.Add(inputData);
                    num3++;
                }
            }
            else
            {
                data2[num5] = generator.Range(min, max);
                if (((uint) num5) >= 0)
                {
                    goto Label_0047;
                }
            }
            goto Label_0023;
        Label_00F5:
            num3 = 0;
            goto Label_0023;
        Label_0111:
            num = training.InputSize;
            idealSize = training.IdealSize;
            goto Label_00F5;
        }

        public static BasicMLDataSet Generate(long seed, int count, int inputCount, int idealCount, double min, double max)
        {
            IMLData data;
            int num2;
            IMLData data2;
            BasicMLDataPair pair;
            LinearCongruentialGenerator generator = new LinearCongruentialGenerator(seed);
            BasicMLDataSet set = new BasicMLDataSet();
            int num = 0;
            goto Label_0018;
        Label_000C:
            set.Add(pair);
        Label_0014:
            num++;
        Label_0018:
            if (num < count)
            {
                data = new BasicMLData(inputCount);
                num2 = 0;
                while (num2 < inputCount)
                {
                    data.Data[num2] = generator.Range(min, max);
                    num2++;
                }
                data2 = new BasicMLData(idealCount);
                if (((uint) count) < 0)
                {
                    goto Label_000C;
                }
                if ((((uint) idealCount) & 0) != 0)
                {
                    goto Label_0014;
                }
                int num3 = 0;
            Label_002D:
                if (num3 < idealCount)
                {
                    data2[num3] = generator.Range(min, max);
                    if ((((uint) idealCount) - ((uint) max)) <= uint.MaxValue)
                    {
                        num3++;
                        goto Label_002D;
                    }
                }
                else
                {
                    goto Label_0032;
                }
                goto Label_00C6;
            }
            if (0 == 0)
            {
                return set;
            }
        Label_0032:
            pair = new BasicMLDataPair(data, data2);
        Label_00C6:
            if ((((uint) num2) & 0) == 0)
            {
                goto Label_000C;
            }
            goto Label_0018;
        }
    }
}

