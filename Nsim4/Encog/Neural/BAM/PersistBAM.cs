namespace Encog.Neural.BAM
{
    using Encog.Persist;
    using Encog.Util;
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class PersistBAM : IEncogPersistor
    {
        public object Read(Stream mask0)
        {
            EncogFileSection section;
            BAMNetwork network = new BAMNetwork();
            EncogReadHelper helper = new EncogReadHelper(mask0);
            goto Label_002F;
        Label_000B:
            if (!section.SectionName.Equals("BAM"))
            {
                goto Label_002F;
            }
        Label_001D:
            if (section.SubSectionName.Equals("NETWORK"))
            {
                IDictionary<string, string> paras = section.ParseParams();
                network.F1Count = EncogFileSection.ParseInt(paras, "f1Count");
                network.F2Count = EncogFileSection.ParseInt(paras, "f2Count");
                if (0 != 0)
                {
                    goto Label_000B;
                }
                network.WeightsF1ToF2 = EncogFileSection.ParseMatrix(paras, "weightsF1F2");
                if (0 != 0)
                {
                    goto Label_00C2;
                }
                network.WeightsF2ToF1 = EncogFileSection.ParseMatrix(paras, "weightsF2F1");
            }
        Label_002F:
            if ((section = helper.ReadNextSection()) != null)
            {
                if (!section.SectionName.Equals("BAM"))
                {
                    goto Label_000B;
                }
            }
            else
            {
                return network;
            }
        Label_00AB:
            if (section.SubSectionName.Equals("PARAMS"))
            {
                EngineArray.PutAll<string, string>(section.ParseParams(), network.Properties);
            }
            else
            {
                goto Label_000B;
            }
        Label_00C2:
            if (0 != 0)
            {
                goto Label_00AB;
            }
            if (15 != 0)
            {
                goto Label_000B;
            }
            goto Label_001D;
        }

        public void Save(Stream os, object obj)
        {
            EncogWriteHelper helper = new EncogWriteHelper(os);
            BAMNetwork network = (BAMNetwork) obj;
            helper.AddSection("BAM");
            if (0 == 0)
            {
                helper.AddSubSection("PARAMS");
                helper.AddProperties(network.Properties);
                if (0 == 0)
                {
                    helper.AddSubSection("NETWORK");
                    helper.WriteProperty("f1Count", network.F1Count);
                    helper.WriteProperty("f2Count", network.F2Count);
                    helper.WriteProperty("weightsF1F2", network.WeightsF1ToF2);
                    helper.WriteProperty("weightsF2F1", network.WeightsF2ToF1);
                    helper.Flush();
                }
            }
        }

        public int FileVersion
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
                return typeof(BAMNetwork);
            }
        }

        public string PersistClassString
        {
            get
            {
                return "BAM";
            }
        }
    }
}

