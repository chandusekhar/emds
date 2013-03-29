namespace Encog.Neural.Prune
{
    using Encog.MathUtil.Randomize;
    using Encog.Neural;
    using Encog.Neural.Flat;
    using Encog.Neural.Networks;
    using Encog.Util;
    using System;

    public class PruneSelective
    {
        private readonly BasicNetwork _x87a7fc6a72741c2e;

        public PruneSelective(BasicNetwork network)
        {
            this._x87a7fc6a72741c2e = network;
        }

        public void ChangeNeuronCount(int layer, int neuronCount)
        {
            int layerNeuronCount;
            if (neuronCount != 0)
            {
                layerNeuronCount = this._x87a7fc6a72741c2e.GetLayerNeuronCount(layer);
                if (neuronCount == layerNeuronCount)
                {
                    return;
                }
            }
            else
            {
                if ((((uint) layer) + ((uint) layerNeuronCount)) >= 0)
                {
                    throw new NeuralNetworkError("Can't decrease to zero neurons.");
                }
                goto Label_0021;
            }
        Label_001D:
            if (neuronCount > layerNeuronCount)
            {
                this.xfb5fe5d1c31436ed(layer, neuronCount);
                return;
            }
        Label_0021:
            this.xec18684cda4bf0d9(layer, neuronCount);
            if ((((uint) layerNeuronCount) - ((uint) layerNeuronCount)) <= uint.MaxValue)
            {
                return;
            }
            goto Label_001D;
        }

        public double DetermineNeuronSignificance(int layer, int neuron)
        {
            double num;
            int num3;
            int num5;
            int layerNeuronCount;
            int num7;
            this._x87a7fc6a72741c2e.ValidateNeuron(layer, neuron);
            if ((((uint) layerNeuronCount) & 0) == 0)
            {
                num = 0.0;
                if (layer <= 0)
                {
                    goto Label_008A;
                }
            }
            int l = layer - 1;
            if ((((uint) neuron) - ((uint) neuron)) <= uint.MaxValue)
            {
                goto Label_010D;
            }
            goto Label_014F;
        Label_006F:
            while (num7 < layerNeuronCount)
            {
                num += this._x87a7fc6a72741c2e.GetWeight(layer, neuron, num7);
                num7++;
                if (((uint) layerNeuronCount) > uint.MaxValue)
                {
                    goto Label_010D;
                }
            }
            if (((uint) num) >= 0)
            {
                goto Label_014F;
            }
        Label_008A:
            if (layer < (this._x87a7fc6a72741c2e.LayerCount - 1))
            {
                num5 = layer + 1;
                layerNeuronCount = this._x87a7fc6a72741c2e.GetLayerNeuronCount(num5);
            }
            else if ((((uint) num5) & 0) == 0)
            {
                if ((((uint) layerNeuronCount) & 0) == 0)
                {
                    goto Label_014F;
                }
                goto Label_010D;
            }
            num7 = 0;
            goto Label_006F;
        Label_010D:
            num3 = this._x87a7fc6a72741c2e.GetLayerTotalNeuronCount(l);
            int fromNeuron = 0;
            while (fromNeuron < num3)
            {
                num += this._x87a7fc6a72741c2e.GetWeight(l, fromNeuron, neuron);
                fromNeuron++;
                if ((((uint) num5) | 0xff) == 0)
                {
                    goto Label_006F;
                }
            }
            goto Label_008A;
        Label_014F:
            return Math.Abs(num);
        }

        public void Prune(int targetLayer, int neuron)
        {
            FlatNetwork flat;
            int length;
            int layerTotalNeuronCount;
            int num3;
            double[] numArray2;
            int num4;
            int num5;
            int num6;
            int layerNeuronCount;
            int num8;
            int num9;
            int num10;
            bool flag;
            int num11;
            this._x87a7fc6a72741c2e.ValidateNeuron(targetLayer, neuron);
            if ((((uint) num8) + ((uint) targetLayer)) >= 0)
            {
                goto Label_037B;
            }
            goto Label_019F;
        Label_0069:
            num5--;
        Label_006F:
            if (num5 >= 0)
            {
                num6 = this._x87a7fc6a72741c2e.GetLayerTotalNeuronCount(num5);
                if (0x7fffffff != 0)
                {
                    layerNeuronCount = this._x87a7fc6a72741c2e.GetLayerNeuronCount(num5 + 1);
                    goto Label_01DC;
                }
                goto Label_037B;
            }
            flat.Weights = numArray2;
        Label_007F:
            num11 = (this._x87a7fc6a72741c2e.LayerCount - targetLayer) - 1;
            if ((((uint) layerTotalNeuronCount) - ((uint) num3)) > uint.MaxValue)
            {
                goto Label_02E2;
            }
            if ((((uint) num8) + ((uint) num3)) <= uint.MaxValue)
            {
                flat.LayerCounts[num11]--;
                flat.LayerFeedCounts[num11]--;
                this.x04adb4fc58e5003d();
                return;
            }
            return;
        Label_010B:
            if (num9 < layerNeuronCount)
            {
                num10 = 0;
                goto Label_0152;
            }
            goto Label_0069;
        Label_0116:
            if ((((uint) num6) | 0xff) == 0)
            {
                goto Label_01DC;
            }
        Label_0131:
            numArray2[num4++] = this._x87a7fc6a72741c2e.GetWeight(num5, num10, num9);
        Label_014C:
            num10++;
        Label_0152:
            if (num10 < num6)
            {
                flag = false;
                if ((((uint) num8) - ((uint) num5)) > uint.MaxValue)
                {
                    if (0x7fffffff == 0)
                    {
                        return;
                    }
                    goto Label_019F;
                }
                goto Label_01CE;
            }
            if ((((uint) num10) - ((uint) num9)) >= 0)
            {
                if ((((uint) num5) | 8) == 0)
                {
                    goto Label_029E;
                }
                num9++;
                if (((uint) num5) < 0)
                {
                    goto Label_02BA;
                }
                if (-2147483648 == 0)
                {
                    goto Label_01CE;
                }
                goto Label_010B;
            }
            goto Label_0069;
        Label_017D:
            if (flag)
            {
                goto Label_014C;
            }
            goto Label_0116;
        Label_019F:
            if (num9 == neuron)
            {
                goto Label_01D7;
            }
        Label_01A4:
            if (num5 != targetLayer)
            {
                goto Label_017D;
            }
            if (num10 == neuron)
            {
                flag = true;
                goto Label_017D;
            }
            if (((uint) layerNeuronCount) < 0)
            {
                goto Label_007F;
            }
            if (((uint) num10) >= 0)
            {
                goto Label_017D;
            }
            goto Label_0116;
        Label_01CE:
            if (num8 == targetLayer)
            {
                goto Label_019F;
            }
            goto Label_01A4;
        Label_01D7:
            flag = true;
            goto Label_017D;
        Label_01DC:
            num8 = num5 + 1;
            num9 = 0;
            goto Label_010B;
        Label_0227:
            if ((((uint) num5) + ((uint) flag)) > uint.MaxValue)
            {
                goto Label_01D7;
            }
            goto Label_006F;
        Label_0297:
            length -= num3;
            goto Label_02AE;
        Label_029E:
            if (targetLayer < (this._x87a7fc6a72741c2e.LayerCount - 1))
            {
                goto Label_02D2;
            }
        Label_02AE:
            numArray2 = new double[length];
            num4 = 0;
            num5 = flat.LayerCounts.Length - 2;
            if ((((uint) num10) - ((uint) num6)) < 0)
            {
                goto Label_029E;
            }
            if ((((uint) flag) + ((uint) num4)) <= uint.MaxValue)
            {
                goto Label_0227;
            }
            goto Label_0297;
        Label_02BA:
            if ((((uint) num3) - ((uint) num6)) >= 0)
            {
                goto Label_029E;
            }
        Label_02D2:
            num3 = this._x87a7fc6a72741c2e.GetLayerNeuronCount(targetLayer + 1);
        Label_02E2:
            if ((((uint) num5) + ((uint) flag)) < 0)
            {
                goto Label_0131;
            }
            if ((((uint) neuron) + ((uint) num4)) <= uint.MaxValue)
            {
                goto Label_0297;
            }
            goto Label_0227;
        Label_037B:
            if (this._x87a7fc6a72741c2e.GetLayerNeuronCount(targetLayer) <= 1)
            {
                throw new NeuralNetworkError("A layer must have at least a single neuron.  If you want to remove the entire layer you must create a new network.");
            }
            flat = this._x87a7fc6a72741c2e.Structure.Flat;
            length = flat.Weights.Length;
            if (((((uint) num3) + ((uint) num6)) >= 0) && (targetLayer <= 0))
            {
                goto Label_02BA;
            }
            layerTotalNeuronCount = this._x87a7fc6a72741c2e.GetLayerTotalNeuronCount(targetLayer - 1);
            length -= layerTotalNeuronCount;
            goto Label_029E;
        }

        public void RandomizeNeuron(int targetLayer, int neuron)
        {
            FlatNetwork flat = this._x87a7fc6a72741c2e.Structure.Flat;
            double num = EngineArray.Min(flat.Weights);
            double num2 = EngineArray.Max(flat.Weights);
            this.x107a35a18a760853(targetLayer, neuron, true, num, num2, false, 0.0);
        }

        public void RandomizeNeuron(double low, double high, int targetLayer, int neuron)
        {
            this.x107a35a18a760853(targetLayer, neuron, true, low, high, false, 0.0);
        }

        public void StimulateNeuron(double percent, int targetLayer, int neuron)
        {
            this.x107a35a18a760853(targetLayer, neuron, false, 0.0, 0.0, true, percent);
        }

        public void StimulateWeakNeurons(int layer, int count, double percent)
        {
            int[] numArray = this.x86539420fafc72af(layer, count);
            foreach (int num in numArray)
            {
                this.StimulateNeuron(percent, layer, num);
            }
        }

        private void x04adb4fc58e5003d()
        {
            int num2;
            int num3;
            int num4;
            FlatNetwork flat = this._x87a7fc6a72741c2e.Structure.Flat;
            int num = 0;
            goto Label_00F3;
        Label_0044:
            if (num3 < flat.LayerCounts.Length)
            {
                if (num3 > 0)
                {
                    int num5;
                    num4 = flat.LayerFeedCounts[num3 - 1];
                    if ((((uint) num5) & 0) != 0)
                    {
                        goto Label_00F3;
                    }
                    num5 = flat.LayerCounts[num3];
                    if ((((uint) num3) & 0) != 0)
                    {
                        goto Label_005B;
                    }
                    num2 += num4 * num5;
                    goto Label_0077;
                }
                if (((uint) num3) <= uint.MaxValue)
                {
                    goto Label_0077;
                }
                goto Label_010F;
            }
            flat.LayerOutput = new double[num];
        Label_005B:
            flat.ClearContext();
            if ((((uint) num) & 0) == 0)
            {
                goto Label_010F;
            }
        Label_0077:
            flat.LayerIndex[num3] = num;
            flat.WeightIndex[num3] = num2;
            num += flat.LayerCounts[num3];
            num3++;
            goto Label_0044;
        Label_00F3:
            num2 = 0;
            num3 = 0;
            goto Label_0044;
        Label_010F:
            if ((((uint) num4) - ((uint) num)) <= uint.MaxValue)
            {
                flat.InputCount = flat.LayerFeedCounts[flat.LayerCounts.Length - 1];
                flat.OutputCount = flat.LayerFeedCounts[0];
            }
        }

        private void x107a35a18a760853(int xf8a5a30e3fab4279, int xad55484e91d7ad5a, bool xdef033fa0cd8af9a, double xd12d1dba8a023d95, double x628ea9b89457a2a9, bool x1fe041039f050e2f, double x4afa7e85b5b4d006)
        {
            IRandomizer randomizer;
            FlatNetwork flat;
            double[] numArray;
            int num;
            int num2;
            int layerTotalNeuronCount;
            int layerNeuronCount;
            int num5;
            int num6;
            int num7;
            bool flag;
            double num8;
            if (!xdef033fa0cd8af9a)
            {
                randomizer = new Distort(x4afa7e85b5b4d006);
                goto Label_0232;
            }
            goto Label_02A0;
        Label_000B:
            if (num6 < layerNeuronCount)
            {
                num7 = 0;
                if ((((uint) num2) - ((uint) num5)) >= 0)
                {
                    goto Label_0041;
                }
                if ((((uint) num2) + ((uint) num)) <= uint.MaxValue)
                {
                    goto Label_0232;
                }
                goto Label_0220;
            }
            num2--;
        Label_001A:
            if (num2 >= 0)
            {
                layerTotalNeuronCount = this._x87a7fc6a72741c2e.GetLayerTotalNeuronCount(num2);
                layerNeuronCount = this._x87a7fc6a72741c2e.GetLayerNeuronCount(num2 + 1);
                if ((((uint) layerTotalNeuronCount) - ((uint) x1fe041039f050e2f)) > uint.MaxValue)
                {
                    goto Label_000B;
                }
                goto Label_0283;
            }
            flat.Weights = numArray;
            return;
        Label_002E:
            if (flag)
            {
                goto Label_0052;
            }
        Label_0032:
            numArray[num++] = num8;
            num7++;
        Label_0041:
            if (num7 < layerTotalNeuronCount)
            {
                flag = false;
                if ((((uint) xad55484e91d7ad5a) - ((uint) layerNeuronCount)) >= 0)
                {
                    if (num5 == xf8a5a30e3fab4279)
                    {
                        goto Label_010F;
                    }
                    if ((((uint) num5) | 0xfffffffe) != 0)
                    {
                        goto Label_00AF;
                    }
                    goto Label_02DE;
                }
                if (((uint) layerTotalNeuronCount) >= 0)
                {
                    goto Label_02A0;
                }
                if (((uint) x1fe041039f050e2f) >= 0)
                {
                    goto Label_0232;
                }
                goto Label_0175;
            }
        Label_004A:
            num6++;
            goto Label_000B;
        Label_0052:
            num8 = randomizer.Randomize(num8);
            goto Label_0032;
        Label_0063:
            if (num7 == xad55484e91d7ad5a)
            {
                goto Label_00DB;
            }
        Label_006B:
            num8 = this._x87a7fc6a72741c2e.GetWeight(num2, num7, num6);
            goto Label_002E;
        Label_00AF:
            if (num2 != xf8a5a30e3fab4279)
            {
                goto Label_006B;
            }
            if (0 != 0)
            {
                goto Label_002E;
            }
            if (((uint) x4afa7e85b5b4d006) <= uint.MaxValue)
            {
                goto Label_0063;
            }
            if (((uint) num8) < 0)
            {
                goto Label_006B;
            }
        Label_00DB:
            flag = true;
            if (((uint) layerTotalNeuronCount) >= 0)
            {
                if ((((uint) xdef033fa0cd8af9a) | uint.MaxValue) != 0)
                {
                    goto Label_006B;
                }
                if (((uint) layerTotalNeuronCount) <= uint.MaxValue)
                {
                    goto Label_0063;
                }
                if (((uint) layerTotalNeuronCount) >= 0)
                {
                    goto Label_02DE;
                }
                goto Label_02A0;
            }
        Label_010F:
            if (num6 != xad55484e91d7ad5a)
            {
                goto Label_00AF;
            }
            flag = true;
            goto Label_006B;
        Label_0175:
            num5 = num2 + 1;
            if (((uint) x4afa7e85b5b4d006) < 0)
            {
                goto Label_0041;
            }
            num6 = 0;
            goto Label_000B;
        Label_0220:
            numArray = new double[flat.Weights.Length];
            num = 0;
            num2 = flat.LayerCounts.Length - 2;
            goto Label_001A;
        Label_0232:
            if ((((uint) num5) + ((uint) xd12d1dba8a023d95)) > uint.MaxValue)
            {
                goto Label_004A;
            }
        Label_024D:
            this._x87a7fc6a72741c2e.ValidateNeuron(xf8a5a30e3fab4279, xad55484e91d7ad5a);
            flat = this._x87a7fc6a72741c2e.Structure.Flat;
            if ((((uint) layerNeuronCount) - ((uint) xf8a5a30e3fab4279)) >= 0)
            {
                goto Label_0220;
            }
        Label_0283:
            if ((((uint) layerTotalNeuronCount) - ((uint) num8)) <= uint.MaxValue)
            {
                goto Label_0175;
            }
            goto Label_0041;
        Label_02A0:
            randomizer = new RangeRandomizer(xd12d1dba8a023d95, x628ea9b89457a2a9);
            goto Label_024D;
        Label_02DE:
            if (0 == 0)
            {
                goto Label_0052;
            }
            goto Label_000B;
        }

        private int[] x86539420fafc72af(int x98da6ccbcd45ba73, int x10f4d88af727adbc)
        {
            int num;
            int num2;
            double num3;
            int num4;
            double[] numArray = new double[x10f4d88af727adbc];
            int[] numArray2 = new int[x10f4d88af727adbc];
            goto Label_00C3;
        Label_000C:
            if (num2 < this._x87a7fc6a72741c2e.GetLayerNeuronCount(x98da6ccbcd45ba73))
            {
                num3 = this.DetermineNeuronSignificance(x98da6ccbcd45ba73, num2);
                num4 = 0;
                goto Label_002D;
            }
            if ((((uint) num4) - ((uint) num4)) <= uint.MaxValue)
            {
                return numArray2;
            }
            goto Label_005F;
        Label_0027:
            num4++;
        Label_002D:
            if (num4 < x10f4d88af727adbc)
            {
                if (numArray[num4] > num3)
                {
                    numArray2[num4] = num2;
                    numArray[num4] = num3;
                }
                else
                {
                    goto Label_0027;
                }
            }
        Label_0032:
            num2++;
            goto Label_000C;
        Label_005F:
            num2 = x10f4d88af727adbc;
            goto Label_000C;
        Label_00C3:
            num = 0;
            if ((((uint) x98da6ccbcd45ba73) + ((uint) num4)) > uint.MaxValue)
            {
                goto Label_0032;
            }
            while (num < x10f4d88af727adbc)
            {
                numArray2[num] = num;
                numArray[num] = this.DetermineNeuronSignificance(x98da6ccbcd45ba73, num);
                num++;
            }
            if ((((uint) num2) - ((uint) num2)) < 0)
            {
                goto Label_0027;
            }
            if ((((uint) x10f4d88af727adbc) - ((uint) num)) >= 0)
            {
                goto Label_005F;
            }
            goto Label_00C3;
        }

        private void xec18684cda4bf0d9(int x98da6ccbcd45ba73, int x42fdac5966b8d383)
        {
            int num = this._x87a7fc6a72741c2e.GetLayerNeuronCount(x98da6ccbcd45ba73) - x42fdac5966b8d383;
            int[] numArray = this.x86539420fafc72af(x98da6ccbcd45ba73, num);
            for (int i = 0; (i < num) || ((((uint) i) - ((uint) x98da6ccbcd45ba73)) < 0); i++)
            {
                this.Prune(x98da6ccbcd45ba73, numArray[i] - i);
            }
        }

        private void xfb5fe5d1c31436ed(int xf8a5a30e3fab4279, int x42fdac5966b8d383)
        {
            int layerNeuronCount;
            int num2;
            FlatNetwork flat;
            int length;
            int layerTotalNeuronCount;
            int num5;
            int num6;
            double[] numArray2;
            int num7;
            int num8;
            int num9;
            int num10;
            int num11;
            int num12;
            int num13;
            if (xf8a5a30e3fab4279 <= this._x87a7fc6a72741c2e.LayerCount)
            {
                goto Label_03BC;
            }
            goto Label_03EA;
        Label_0037:
            if (num8 >= 0)
            {
                goto Label_01D9;
            }
            flat.Weights = numArray2;
            if ((((uint) num2) - ((uint) num9)) < 0)
            {
                goto Label_0037;
            }
            this.x04adb4fc58e5003d();
            if ((((uint) num11) + ((uint) length)) <= uint.MaxValue)
            {
                return;
            }
        Label_007D:
            if (num13 < num9)
            {
                goto Label_017F;
            }
            num12++;
        Label_008C:
            if ((((uint) num13) - ((uint) num9)) < 0)
            {
                goto Label_03A4;
            }
        Label_00A7:
            if (num12 < num10)
            {
                num13 = 0;
                goto Label_007D;
            }
            if ((((uint) num12) - ((uint) num7)) < 0)
            {
                goto Label_03BC;
            }
            num8--;
            goto Label_0037;
        Label_00BA:
            numArray2[num7++] = this._x87a7fc6a72741c2e.GetWeight(num8, num13, num12);
        Label_00D5:
            num13++;
            if ((((uint) num7) - ((uint) x42fdac5966b8d383)) >= 0)
            {
                if ((((uint) num7) & 0) == 0)
                {
                    goto Label_007D;
                }
                goto Label_0149;
            }
            if ((((uint) layerTotalNeuronCount) + ((uint) num8)) > uint.MaxValue)
            {
                goto Label_0149;
            }
            goto Label_00BA;
        Label_010D:
            if ((num8 == xf8a5a30e3fab4279) && (num13 > layerNeuronCount))
            {
                numArray2[num7++] = 0.0;
                goto Label_00D5;
            }
            goto Label_00BA;
        Label_0149:
            if ((((uint) num10) >= 0) || ((((uint) x42fdac5966b8d383) + ((uint) num12)) <= uint.MaxValue))
            {
                goto Label_010D;
            }
        Label_017F:
            if (num11 != xf8a5a30e3fab4279)
            {
                goto Label_010D;
            }
            if (num12 < layerNeuronCount)
            {
                goto Label_0149;
            }
            numArray2[num7++] = 0.0;
            goto Label_00D5;
        Label_01D9:
            num9 = this._x87a7fc6a72741c2e.GetLayerTotalNeuronCount(num8);
        Label_01E8:
            num10 = this._x87a7fc6a72741c2e.GetLayerNeuronCount(num8 + 1);
            num11 = num8 + 1;
            num12 = 0;
            goto Label_00A7;
        Label_026A:
            if (xf8a5a30e3fab4279 < (this._x87a7fc6a72741c2e.LayerCount - 1))
            {
                goto Label_02C8;
            }
        Label_027F:
            num6 = (this._x87a7fc6a72741c2e.LayerCount - xf8a5a30e3fab4279) - 1;
            if (((((uint) num8) | 0xfffffffe) == 0) || ((((uint) layerNeuronCount) & 0) != 0))
            {
                goto Label_01E8;
            }
            flat.LayerCounts[num6] += num2;
            if ((((uint) num8) & 0) != 0)
            {
                goto Label_02C8;
            }
            if (((uint) num6) >= 0)
            {
                flat.LayerFeedCounts[num6] += num2;
                numArray2 = new double[length];
                num7 = 0;
                num8 = flat.LayerCounts.Length - 2;
                goto Label_0037;
            }
        Label_02C2:
            if (xf8a5a30e3fab4279 > 0)
            {
                layerTotalNeuronCount = this._x87a7fc6a72741c2e.GetLayerTotalNeuronCount(xf8a5a30e3fab4279 - 1);
                length += layerTotalNeuronCount * num2;
            }
            goto Label_026A;
        Label_02C8:
            num5 = this._x87a7fc6a72741c2e.GetLayerNeuronCount(xf8a5a30e3fab4279 + 1);
            length += num5 * num2;
            if (0 != 0)
            {
                goto Label_026A;
            }
            goto Label_027F;
        Label_03A4:
            throw new NeuralNetworkError("Invalid neuron count " + x42fdac5966b8d383);
        Label_03BC:
            if (x42fdac5966b8d383 <= 0)
            {
                goto Label_03A4;
            }
            if ((((uint) num11) + ((uint) num8)) > uint.MaxValue)
            {
                goto Label_01D9;
            }
            layerNeuronCount = this._x87a7fc6a72741c2e.GetLayerNeuronCount(xf8a5a30e3fab4279);
            num2 = x42fdac5966b8d383 - layerNeuronCount;
            if (num2 <= 0)
            {
                throw new NeuralNetworkError("New neuron count is either a decrease or no change: " + x42fdac5966b8d383);
            }
            do
            {
                flat = this._x87a7fc6a72741c2e.Structure.Flat;
                double[] weights = flat.Weights;
                if ((((uint) num8) + ((uint) num7)) > uint.MaxValue)
                {
                    goto Label_008C;
                }
                length = weights.Length;
                goto Label_02C2;
            }
            while ((((uint) num2) + ((uint) num13)) <= uint.MaxValue);
            if (((uint) xf8a5a30e3fab4279) >= 0)
            {
                goto Label_02C2;
            }
        Label_03EA:
            throw new NeuralNetworkError("Invalid layer " + xf8a5a30e3fab4279);
        }

        public BasicNetwork Network
        {
            get
            {
                return this._x87a7fc6a72741c2e;
            }
        }
    }
}

