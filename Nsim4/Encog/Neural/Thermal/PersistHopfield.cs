namespace Encog.Neural.Thermal
{
    using Encog.Persist;
    using Encog.Util;
    using Encog.Util.CSV;
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class PersistHopfield : IEncogPersistor
    {
        public object Read(Stream mask0)
        {
            EncogReadHelper helper;
            EncogFileSection section;
            IDictionary<string, string> dictionary2;
            HopfieldNetwork network = new HopfieldNetwork();
            goto Label_00F0;
        Label_000D:
            if (section.SectionName.Equals("HOPFIELD") || (0 != 0))
            {
                goto Label_0031;
            }
        Label_0022:
            if ((section = helper.ReadNextSection()) != null)
            {
                if (section.SectionName.Equals("HOPFIELD"))
                {
                    if (0 != 0)
                    {
                        goto Label_0031;
                    }
                    if (3 != 0)
                    {
                        if (0xff == 0)
                        {
                            goto Label_0022;
                        }
                        if (section.SubSectionName.Equals("PARAMS"))
                        {
                            IDictionary<string, string> source = section.ParseParams();
                            if (0 == 0)
                            {
                                EngineArray.PutAll<string, string>(source, network.Properties);
                            }
                        }
                    }
                }
                goto Label_000D;
            }
            return network;
        Label_0031:
            if (section.SubSectionName.Equals("NETWORK"))
            {
                dictionary2 = section.ParseParams();
            }
            else
            {
                goto Label_0022;
            }
            network.Weights = NumberList.FromList(CSVFormat.EgFormat, dictionary2["weights"]);
            if (0 == 0)
            {
                network.SetCurrentState(NumberList.FromList(CSVFormat.EgFormat, dictionary2["output"]));
                network.NeuronCount = EncogFileSection.ParseInt(dictionary2, "neurons");
                goto Label_0022;
            }
            if (3 != 0)
            {
                goto Label_000D;
            }
        Label_00F0:
            helper = new EncogReadHelper(mask0);
            goto Label_0022;
        }

        public void Save(Stream os, object obj)
        {
            HopfieldNetwork network;
            EncogWriteHelper helper = new EncogWriteHelper(os);
            goto Label_00A2;
        Label_0028:
            helper.WriteProperty("neurons", network.NeuronCount);
            helper.Flush();
            if (4 != 0)
            {
                return;
            }
            if (4 != 0)
            {
                goto Label_00A2;
            }
            goto Label_0064;
        Label_004C:
            helper.WriteProperty("output", network.CurrentState.Data);
            goto Label_0028;
        Label_0064:
            helper.AddSection("HOPFIELD");
            helper.AddSubSection("PARAMS");
            if (2 == 0)
            {
                goto Label_004C;
            }
            helper.AddProperties(network.Properties);
            helper.AddSubSection("NETWORK");
            if (0 == 0)
            {
                helper.WriteProperty("weights", network.Weights);
                goto Label_004C;
            }
            goto Label_0028;
        Label_00A2:
            network = (HopfieldNetwork) obj;
            goto Label_0064;
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
                return typeof(HopfieldNetwork);
            }
        }

        public virtual string PersistClassString
        {
            get
            {
                return typeof(HopfieldNetwork).Name;
            }
        }
    }
}

