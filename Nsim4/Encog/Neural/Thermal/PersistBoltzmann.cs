namespace Encog.Neural.Thermal
{
    using Encog.Persist;
    using Encog.Util;
    using Encog.Util.CSV;
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class PersistBoltzmann : IEncogPersistor
    {
        public object Read(Stream mask0)
        {
            EncogFileSection section;
            IDictionary<string, string> dictionary2;
            BoltzmannMachine machine = new BoltzmannMachine();
            EncogReadHelper helper = new EncogReadHelper(mask0);
        Label_0034:
            if ((section = helper.ReadNextSection()) != null)
            {
                goto Label_012B;
            }
            return machine;
        Label_00A3:
            machine.Threshold = NumberList.FromList(CSVFormat.EgFormat, dictionary2["thresholds"]);
            machine.AnnealCycles = EncogFileSection.ParseInt(dictionary2, "annealCycles");
            machine.RunCycles = EncogFileSection.ParseInt(dictionary2, "runCycles");
            if (0 == 0)
            {
                machine.Temperature = EncogFileSection.ParseDouble(dictionary2, "temperature");
                goto Label_0034;
            }
            goto Label_0142;
        Label_00C4:
            if (section.SectionName.Equals("BOLTZMANN") && section.SubSectionName.Equals("NETWORK"))
            {
                dictionary2 = section.ParseParams();
                machine.Weights = NumberList.FromList(CSVFormat.EgFormat, dictionary2["weights"]);
            }
            else
            {
                goto Label_0034;
            }
            machine.SetCurrentState(NumberList.FromList(CSVFormat.EgFormat, dictionary2["output"]));
            machine.NeuronCount = EncogFileSection.ParseInt(dictionary2, "neurons");
            goto Label_00A3;
        Label_012B:
            if (!section.SectionName.Equals("BOLTZMANN"))
            {
                goto Label_00C4;
            }
        Label_0142:
            if (section.SubSectionName.Equals("PARAMS"))
            {
                EngineArray.PutAll<string, string>(section.ParseParams(), machine.Properties);
                if (0 == 0)
                {
                    goto Label_00C4;
                }
                goto Label_012B;
            }
            if (0 != 0)
            {
                goto Label_0142;
            }
            if (2 == 0)
            {
                if (-1 == 0)
                {
                    goto Label_00A3;
                }
                if (8 != 0)
                {
                    goto Label_012B;
                }
                goto Label_0142;
            }
            goto Label_00C4;
        }

        public void Save(Stream os, object obj)
        {
            EncogWriteHelper helper = new EncogWriteHelper(os);
            BoltzmannMachine machine = (BoltzmannMachine) obj;
            helper.AddSection("BOLTZMANN");
        Label_00C6:
            helper.AddSubSection("PARAMS");
        Label_00D1:
            helper.AddProperties(machine.Properties);
            if (0 != 0)
            {
                return;
            }
        Label_0094:
            helper.AddSubSection("NETWORK");
            helper.WriteProperty("weights", machine.Weights);
            helper.WriteProperty("output", machine.CurrentState.Data);
            if (0 == 0)
            {
                helper.WriteProperty("neurons", machine.NeuronCount);
                helper.WriteProperty("thresholds", machine.Threshold);
                helper.WriteProperty("annealCycles", machine.AnnealCycles);
                helper.WriteProperty("runCycles", machine.RunCycles);
                helper.WriteProperty("temperature", machine.Temperature);
                helper.Flush();
                if (0 != 0)
                {
                    goto Label_00D1;
                }
                if (0 == 0)
                {
                    return;
                }
                goto Label_0094;
            }
            goto Label_00C6;
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
                return typeof(BoltzmannMachine);
            }
        }

        public virtual string PersistClassString
        {
            get
            {
                return "BoltzmannMachine";
            }
        }
    }
}

