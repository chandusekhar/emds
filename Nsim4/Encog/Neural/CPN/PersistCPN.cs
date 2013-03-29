namespace Encog.Neural.CPN
{
    using Encog.MathUtil.Matrices;
    using Encog.Persist;
    using Encog.Util;
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class PersistCPN : IEncogPersistor
    {
        internal const string x69d88fba1aea1ede = "instarToInput";
        internal const string x91c2b6b2993ed29f = "inputToInstar";
        internal const string xd037c9e843ebc288 = "winnerCount";

        public object Read(Stream mask0)
        {
            IDictionary<string, string> source = null;
            EncogFileSection section;
            IDictionary<string, string> dictionary2;
            EncogReadHelper helper = new EncogReadHelper(mask0);
            int theInputCount = 0;
            int theInstarCount = 0;
            int theOutstarCount = 0;
            int theWinnerCount = 0;
            Matrix other = null;
            Matrix matrix2 = null;
            goto Label_0097;
        Label_0075:
            if (3 == 0)
            {
                goto Label_00D0;
            }
            if ((((uint) theInstarCount) + ((uint) theOutstarCount)) > uint.MaxValue)
            {
                goto Label_019A;
            }
        Label_0097:
            if ((section = helper.ReadNextSection()) != null)
            {
                if (!section.SectionName.Equals("CPN"))
                {
                    goto Label_00D0;
                }
                goto Label_019A;
            }
            CPNNetwork network = new CPNNetwork(theInputCount, theInstarCount, theOutstarCount, theWinnerCount);
            EngineArray.PutAll<string, string>(source, network.Properties);
            if ((((uint) theInputCount) & 0) != 0)
            {
                goto Label_0176;
            }
            network.WeightsInputToInstar.Set(other);
            network.WeightsInstarToOutstar.Set(matrix2);
            if (((uint) theInstarCount) <= uint.MaxValue)
            {
                return network;
            }
            goto Label_00E4;
        Label_00D0:
            if (!section.SectionName.Equals("CPN"))
            {
                goto Label_0097;
            }
            if (((uint) theInstarCount) >= 0)
            {
                if (section.SubSectionName.Equals("NETWORK"))
                {
                    dictionary2 = section.ParseParams();
                    theInputCount = EncogFileSection.ParseInt(dictionary2, "inputCount");
                    goto Label_0176;
                }
                if (((uint) theInstarCount) >= 0)
                {
                    goto Label_0097;
                }
                goto Label_0075;
            }
            return network;
        Label_00E4:
            theWinnerCount = EncogFileSection.ParseInt(dictionary2, "winnerCount");
            other = EncogFileSection.ParseMatrix(dictionary2, "inputToInstar");
            matrix2 = EncogFileSection.ParseMatrix(dictionary2, "instarToInput");
            if (2 != 0)
            {
                goto Label_0075;
            }
            goto Label_00D0;
        Label_0176:
            theInstarCount = EncogFileSection.ParseInt(dictionary2, "instar");
            if (((uint) theWinnerCount) >= 0)
            {
                theOutstarCount = EncogFileSection.ParseInt(dictionary2, "outputCount");
                if ((((uint) theInputCount) + ((uint) theInstarCount)) < 0)
                {
                    goto Label_019A;
                }
            }
            goto Label_00E4;
        Label_019A:
            if (section.SubSectionName.Equals("PARAMS"))
            {
                source = section.ParseParams();
            }
            goto Label_00D0;
        }

        public void Save(Stream os, object obj)
        {
            CPNNetwork network;
            EncogWriteHelper helper = new EncogWriteHelper(os);
            if (0 == 0)
            {
                network = (CPNNetwork) obj;
                goto Label_00A8;
            }
        Label_000D:
            helper.WriteProperty("inputToInstar", network.WeightsInputToInstar);
            helper.WriteProperty("instarToInput", network.WeightsInstarToOutstar);
            helper.WriteProperty("winnerCount", network.WinnerCount);
            if (-1 != 0)
            {
                helper.Flush();
                return;
            }
        Label_0052:
            helper.AddProperties(network.Properties);
            if (0 == 0)
            {
                helper.AddSubSection("NETWORK");
                helper.WriteProperty("inputCount", network.InputCount);
                helper.WriteProperty("instar", network.InstarCount);
                helper.WriteProperty("outputCount", network.OutputCount);
                goto Label_00C5;
            }
        Label_00A8:
            helper.AddSection("CPN");
            helper.AddSubSection("PARAMS");
            if (15 != 0)
            {
                goto Label_0052;
            }
        Label_00C5:
            if (0 == 0)
            {
                goto Label_000D;
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
                return typeof(CPNNetwork);
            }
        }

        public string PersistClassString
        {
            get
            {
                return "CPN";
            }
        }
    }
}

