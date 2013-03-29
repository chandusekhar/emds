namespace Encog.Neural.ART
{
    using Encog.Persist;
    using Encog.Util;
    using System;
    using System.Collections.Generic;
    using System.IO;

    [Serializable]
    public class PersistART1 : IEncogPersistor
    {
        public object Read(Stream mask0)
        {
            EncogReadHelper helper;
            EncogFileSection section;
            ART1 art = new ART1();
            goto Label_01A7;
        Label_0014:
            if (0 != 0)
            {
                goto Label_005C;
            }
        Label_0020:
            if ((section = helper.ReadNextSection()) != null)
            {
                if (section.SectionName.Equals("ART1") && (section.SubSectionName.Equals("PARAMS") || (0 != 0)))
                {
                    EngineArray.PutAll<string, string>(section.ParseParams(), art.Properties);
                }
                goto Label_0048;
            }
            return art;
        Label_0041:
            if ((-2 != 0) && (15 != 0))
            {
                if (0xff == 0)
                {
                    goto Label_0014;
                }
                goto Label_0020;
            }
        Label_0048:
            if (!section.SectionName.Equals("ART1"))
            {
                goto Label_0014;
            }
        Label_005C:
            if (section.SubSectionName.Equals("NETWORK"))
            {
                IDictionary<string, string> dictionary2;
            Label_0166:
                dictionary2 = section.ParseParams();
                if (0 == 0)
                {
                    art.A1 = EncogFileSection.ParseDouble(dictionary2, "A1");
                    art.B1 = EncogFileSection.ParseDouble(dictionary2, "B1");
                    art.C1 = EncogFileSection.ParseDouble(dictionary2, "C1");
                    if (0 == 0)
                    {
                        art.D1 = EncogFileSection.ParseDouble(dictionary2, "D1");
                        art.F1Count = EncogFileSection.ParseInt(dictionary2, "f1Count");
                        if (4 != 0)
                        {
                            if (0 != 0)
                            {
                                goto Label_0041;
                            }
                            if (0 != 0)
                            {
                                goto Label_0166;
                            }
                            art.F2Count = EncogFileSection.ParseInt(dictionary2, "f2Count");
                            art.NoWinner = EncogFileSection.ParseInt(dictionary2, "noWinner");
                        }
                        art.L = EncogFileSection.ParseDouble(dictionary2, "L");
                        art.Vigilance = EncogFileSection.ParseDouble(dictionary2, "VIGILANCE");
                    }
                    art.WeightsF1ToF2 = EncogFileSection.ParseMatrix(dictionary2, "weightsF1F2");
                    art.WeightsF2ToF1 = EncogFileSection.ParseMatrix(dictionary2, "weightsF2F1");
                    goto Label_0041;
                }
            }
            else
            {
                goto Label_0020;
            }
        Label_01A7:
            helper = new EncogReadHelper(mask0);
            goto Label_0020;
        }

        public void Save(Stream os, object obj)
        {
            ART1 art;
            EncogWriteHelper helper = new EncogWriteHelper(os);
            goto Label_010B;
        Label_000C:
            helper.Flush();
            if (2 != 0)
            {
                return;
            }
        Label_0019:
            helper.WriteProperty("noWinner", art.NoWinner);
            do
            {
                helper.WriteProperty("L", art.L);
            }
            while (0 != 0);
            helper.WriteProperty("VIGILANCE", art.Vigilance);
            helper.WriteProperty("weightsF1F2", art.WeightsF1ToF2);
            helper.WriteProperty("weightsF2F1", art.WeightsF2ToF1);
            goto Label_000C;
        Label_010B:
            art = (ART1) obj;
            if (0 == 0)
            {
                helper.AddSection("ART1");
                helper.AddSubSection("PARAMS");
                if (0 == 0)
                {
                    helper.AddProperties(art.Properties);
                    helper.AddSubSection("NETWORK");
                    helper.WriteProperty("A1", art.A1);
                }
                helper.WriteProperty("B1", art.B1);
                helper.WriteProperty("C1", art.C1);
                if (0 != 0)
                {
                    goto Label_000C;
                }
                helper.WriteProperty("D1", art.D1);
                helper.WriteProperty("f1Count", art.F1Count);
            }
            helper.WriteProperty("f2Count", art.F2Count);
            if (3 != 0)
            {
                if (0 != 0)
                {
                    return;
                }
                goto Label_0019;
            }
            goto Label_010B;
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
                return typeof(ART1);
            }
        }

        public string PersistClassString
        {
            get
            {
                return "ART1";
            }
        }
    }
}

