namespace Encog.Neural.NEAT
{
    using Encog.Neural.Neat;
    using Encog.Persist;
    using Encog.Util.CSV;
    using System;
    using System.Collections.Generic;
    using System.IO;

    [Serializable]
    public class PersistNEATNetwork : IEncogPersistor
    {
        public virtual object Read(Stream mask0)
        {
            EncogReadHelper helper;
            EncogFileSection section;
            IDictionary<int, NEATNeuron> dictionary;
            IDictionary<string, string> dictionary2;
            double num2;
            double num3;
            int num5;
            int num6;
            bool flag;
            double num7;
            NEATNetwork network = new NEATNetwork();
            if ((((uint) flag) + ((uint) num3)) <= uint.MaxValue)
            {
                if ((((uint) num6) + ((uint) num6)) < 0)
                {
                    goto Label_03FB;
                }
                if ((((uint) flag) + ((uint) num3)) <= uint.MaxValue)
                {
                    helper = new EncogReadHelper(mask0);
                    if ((((uint) flag) & 0) == 0)
                    {
                        dictionary = new Dictionary<int, NEATNeuron>();
                        goto Label_0023;
                    }
                }
                goto Label_03AA;
            }
            goto Label_0035;
        Label_0023:
            if ((section = helper.ReadNextSection()) != null)
            {
                goto Label_045C;
            }
            return network;
        Label_0035:
            if (section.SectionName.Equals("NEAT"))
            {
                while (section.SubSectionName.Equals("LINKS"))
                {
                    using (IEnumerator<string> enumerator3 = section.Lines.GetEnumerator())
                    {
                        string str3;
                        IList<string> list2;
                        NEATNeuron neuron3;
                        NEATLink link;
                        goto Label_007D;
                    Label_005B:
                        if ((((uint) num6) & 0) != 0)
                        {
                            goto Label_00D5;
                        }
                        neuron3.InboundLinks.Add(link);
                    Label_007D:
                        if (enumerator3.MoveNext())
                        {
                            goto Label_00FA;
                        }
                        if ((((uint) num2) + ((uint) num3)) >= 0)
                        {
                            goto Label_0023;
                        }
                    Label_009E:
                        num7 = CSVFormat.EgFormat.Parse(list2[3]);
                        NEATNeuron fromNeuron = dictionary[num5];
                        neuron3 = dictionary[num6];
                        link = new NEATLink(num7, fromNeuron, neuron3, flag);
                    Label_00D5:
                        fromNeuron.OutputboundLinks.Add(link);
                        if (((uint) num3) >= 0)
                        {
                            goto Label_005B;
                        }
                        goto Label_0023;
                    Label_00FA:
                        str3 = enumerator3.Current;
                        list2 = EncogFileSection.SplitColumns(str3);
                        num5 = int.Parse(list2[0]);
                        if (-2 != 0)
                        {
                        }
                        num6 = int.Parse(list2[1]);
                        flag = int.Parse(list2[2]) > 0;
                        goto Label_009E;
                    }
                }
                if (((uint) num7) >= 0)
                {
                }
            }
            goto Label_0023;
        Label_03AA:
            if (!section.SectionName.Equals("NEAT") || !section.SubSectionName.Equals("NETWORK"))
            {
                if (section.SectionName.Equals("NEAT") && section.SubSectionName.Equals("NEURONS"))
                {
                    using (IEnumerator<string> enumerator2 = section.Lines.GetEnumerator())
                    {
                        string str2;
                        IList<string> list;
                        long num;
                        NEATNeuronType type;
                        NEATNeuron neuron;
                    Label_01BD:
                        if (enumerator2.MoveNext())
                        {
                            goto Label_0257;
                        }
                        goto Label_0023;
                    Label_01CE:
                        if ((((uint) num) + ((uint) num5)) > uint.MaxValue)
                        {
                            goto Label_02A0;
                        }
                        network.Neurons.Add(neuron);
                        dictionary[(int) num] = neuron;
                        goto Label_02D0;
                    Label_0206:
                        num3 = CSVFormat.EgFormat.Parse(list[3]);
                        double num4 = CSVFormat.EgFormat.Parse(list[4]);
                        neuron = new NEATNeuron(type, num, num3, num4, num2);
                        if ((((uint) num7) - ((uint) num)) <= uint.MaxValue)
                        {
                            goto Label_02B9;
                        }
                    Label_0257:
                        str2 = enumerator2.Current;
                        do
                        {
                            list = EncogFileSection.SplitColumns(str2);
                            num = int.Parse(list[0]);
                            type = PersistNEATPopulation.StringToNeuronType(list[1]);
                        }
                        while ((((uint) num) + ((uint) num5)) < 0);
                    Label_02A0:
                        num2 = CSVFormat.EgFormat.Parse(list[2]);
                        goto Label_0206;
                    Label_02B9:
                        if ((((uint) num3) & 0) == 0)
                        {
                            goto Label_01CE;
                        }
                    Label_02D0:
                        if ((((uint) num6) - ((uint) num4)) >= 0)
                        {
                            goto Label_01BD;
                        }
                        goto Label_0023;
                    }
                }
                goto Label_0035;
            }
            IDictionary<string, string> paras = section.ParseParams();
            network.InputCount = EncogFileSection.ParseInt(paras, "inputCount");
            network.OutputCount = EncogFileSection.ParseInt(paras, "outputCount");
            network.ActivationFunction = EncogFileSection.ParseActivationFunction(paras, "activationFunction");
            if (((uint) num7) <= uint.MaxValue)
            {
                network.OutputActivationFunction = EncogFileSection.ParseActivationFunction(paras, "outAct");
                if (((uint) num3) >= 0)
                {
                    network.NetworkDepth = EncogFileSection.ParseInt(paras, "depth");
                    network.Snapshot = EncogFileSection.ParseBoolean(paras, "snapshot");
                    goto Label_0023;
                }
                goto Label_0035;
            }
        Label_03F3:
            dictionary2 = section.ParseParams();
        Label_03FB:
            foreach (string str in dictionary2.Keys)
            {
                network.Properties.Add(str, dictionary2[str]);
            }
            goto Label_03AA;
            if (((((uint) flag) + ((uint) num2)) <= uint.MaxValue) && (((uint) flag) >= 0))
            {
                goto Label_03AA;
            }
        Label_045C:
            if (section.SectionName.Equals("NEAT") && section.SubSectionName.Equals("PARAMS"))
            {
                goto Label_03F3;
            }
            goto Label_03AA;
        }

        public virtual void Save(Stream os, object obj)
        {
            EncogWriteHelper xout = new EncogWriteHelper(os);
            NEATNetwork network = (NEATNetwork) obj;
            xout.AddSection("NEAT");
            xout.AddSubSection("PARAMS");
            xout.AddProperties(network.Properties);
            xout.AddSubSection("NETWORK");
            if (8 != 0)
            {
            }
            xout.WriteProperty("inputCount", network.InputCount);
            xout.WriteProperty("outputCount", network.OutputCount);
            xout.WriteProperty("activationFunction", network.ActivationFunction);
            xout.WriteProperty("outAct", network.OutputActivationFunction);
            xout.WriteProperty("depth", network.NetworkDepth);
        Label_0087:
            xout.WriteProperty("snapshot", network.Snapshot);
            xout.AddSubSection("NEURONS");
            using (IEnumerator<NEATNeuron> enumerator = network.Neurons.GetEnumerator())
            {
                NEATNeuron current;
                goto Label_00E3;
            Label_00B2:
                if (8 == 0)
                {
                    goto Label_00F6;
                }
                xout.AddColumn(current.ActivationResponse);
                xout.AddColumn(current.SplitX);
                xout.AddColumn(current.SplitY);
                xout.WriteLine();
            Label_00E3:
                if (!enumerator.MoveNext())
                {
                    goto Label_0124;
                }
                current = enumerator.Current;
            Label_00F6:
                xout.AddColumn((int) current.NeuronID);
                xout.AddColumn(PersistNEATPopulation.NeuronTypeToString(current.NeuronType));
                goto Label_00B2;
            }
        Label_0124:
            xout.AddSubSection("LINKS");
            foreach (NEATNeuron neuron2 in network.Neurons)
            {
                foreach (NEATLink link in neuron2.OutputboundLinks)
                {
                    WriteLink(xout, link);
                }
            }
            xout.Flush();
            if (-1 != 0)
            {
                return;
            }
            goto Label_0087;
        }

        private static void WriteLink(EncogWriteHelper xout, NEATLink link)
        {
            xout.AddColumn((int) link.FromNeuron.NeuronID);
            xout.AddColumn((int) link.ToNeuron.NeuronID);
            xout.AddColumn(link.Recurrent);
            xout.AddColumn(link.Weight);
            xout.WriteLine();
        }

        public virtual int FileVersion
        {
            get
            {
                return 1;
            }
        }

        public Type NativeType
        {
            get
            {
                return typeof(NEATNetwork);
            }
        }

        public virtual string PersistClassString
        {
            get
            {
                return "NEATNetwork";
            }
        }
    }
}

