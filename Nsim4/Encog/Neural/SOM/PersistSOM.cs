namespace Encog.Neural.SOM
{
    using Encog.Persist;
    using Encog.Util;
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class PersistSOM : IEncogPersistor
    {
        public object Read(Stream mask0)
        {
            EncogReadHelper helper;
            EncogFileSection section;
            SOMNetwork network = new SOMNetwork();
            goto Label_00FC;
        Label_000B:
            if (section.SubSectionName.Equals("NETWORK"))
            {
                IDictionary<string, string> paras = section.ParseParams();
                network.Weights = EncogFileSection.ParseMatrix(paras, "weights");
                network.OutputCount = EncogFileSection.ParseInt(paras, "outputCount");
                network.InputCount = EncogFileSection.ParseInt(paras, "inputCount");
                if (0 != 0)
                {
                    if (0 == 0)
                    {
                        goto Label_0055;
                    }
                    goto Label_0039;
                }
            }
        Label_001D:
            if ((section = helper.ReadNextSection()) != null)
            {
                if (!section.SectionName.Equals("SOM"))
                {
                    goto Label_003E;
                }
                goto Label_00A0;
            }
            if (15 != 0)
            {
                return network;
            }
            goto Label_00FC;
        Label_0039:
            if (0 == 0)
            {
                goto Label_001D;
            }
            goto Label_000B;
        Label_003E:
            if (!section.SectionName.Equals("SOM"))
            {
                goto Label_0039;
            }
            if (1 != 0)
            {
                goto Label_000B;
            }
            return network;
        Label_0055:
            if (0 != 0)
            {
                if (0 != 0)
                {
                    goto Label_001D;
                }
            }
            else
            {
                goto Label_003E;
            }
        Label_00A0:
            if (section.SubSectionName.Equals("PARAMS"))
            {
                EngineArray.PutAll<string, string>(section.ParseParams(), network.Properties);
            }
            goto Label_003E;
        Label_00FC:
            if (4 == 0)
            {
                goto Label_0055;
            }
            helper = new EncogReadHelper(mask0);
            goto Label_001D;
        }

        public void Save(Stream os, object obj)
        {
            EncogWriteHelper helper = new EncogWriteHelper(os);
            while (true)
            {
                SOMNetwork network = (SOMNetwork) obj;
                helper.AddSection("SOM");
                helper.AddSubSection("PARAMS");
                helper.AddProperties(network.Properties);
                helper.AddSubSection("NETWORK");
                helper.WriteProperty("weights", network.Weights);
                helper.WriteProperty("inputCount", network.InputCount);
                if (0 == 0)
                {
                    helper.WriteProperty("outputCount", network.OutputCount);
                    helper.Flush();
                }
                if ((0 != 0) || (0 == 0))
                {
                    return;
                }
            }
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
                return typeof(SOMNetwork);
            }
        }

        public virtual string PersistClassString
        {
            get
            {
                return "SOM";
            }
        }
    }
}

