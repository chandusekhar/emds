namespace Encog.Neural.Neat
{
    using Encog;
    using Encog.ML.Genetic.Genes;
    using Encog.ML.Genetic.Genome;
    using Encog.ML.Genetic.Innovation;
    using Encog.ML.Genetic.Species;
    using Encog.Neural.NEAT;
    using Encog.Neural.Neat.Training;
    using Encog.Neural.NEAT.Training;
    using Encog.Persist;
    using Encog.Util.CSV;
    using System;
    using System.Collections.Generic;
    using System.IO;

    [Serializable]
    public class PersistNEATPopulation : IEncogPersistor
    {
        public static string InnovationTypeToString(NEATInnovationType t)
        {
            switch (t)
            {
                case NEATInnovationType.NewLink:
                    return "l";

                case NEATInnovationType.NewNeuron:
                    return "n";
            }
            return null;
        }

        public static string NeuronTypeToString(NEATNeuronType t)
        {
            NEATNeuronType type = t;
            if (0 == 0)
            {
                switch (type)
                {
                    case NEATNeuronType.Bias:
                        return "b";

                    case NEATNeuronType.Hidden:
                        return "h";

                    case NEATNeuronType.Input:
                        goto Label_0005;

                    case NEATNeuronType.None:
                        return "n";

                    case NEATNeuronType.Output:
                        return "o";
                }
                return null;
            }
        Label_0005:
            return "i";
        }

        public virtual object Read(Stream mask0)
        {
            IDictionary<ISpecies, int> dictionary2;
            IDictionary<int, IGenome> dictionary3;
            EncogFileSection section;
            IDictionary<string, string> dictionary4;
            int num;
            int num2;
            NEATPopulation population = new NEATPopulation();
            NEATInnovationList list = new NEATInnovationList {
                Population = population
            };
            population.Innovations = list;
            EncogReadHelper helper = new EncogReadHelper(mask0);
            IDictionary<int, ISpecies> dictionary = new Dictionary<int, ISpecies>();
            goto Label_0BD6;
        Label_0023:
            if ((section = helper.ReadNextSection()) != null)
            {
                if (!section.SectionName.Equals("NEAT-POPULATION"))
                {
                    goto Label_085C;
                }
                if (section.SubSectionName.Equals("INNOVATIONS"))
                {
                    using (IEnumerator<string> enumerator = section.Lines.GetEnumerator())
                    {
                        string str;
                        IList<string> list2;
                        NEATInnovation innovation;
                        NEATInnovation innovation2;
                        goto Label_0A6C;
                    Label_0A43:
                        innovation = innovation2;
                        if ((((uint) num2) - ((uint) num)) <= uint.MaxValue)
                        {
                        }
                        population.Innovations.Add(innovation);
                    Label_0A6C:
                        if (enumerator.MoveNext())
                        {
                            goto Label_0B54;
                        }
                        goto Label_0AD7;
                    Label_0A7A:
                        innovation2.SplitY = CSVFormat.EgFormat.Parse(list2[4]);
                        innovation2.NeuronID = int.Parse(list2[5]);
                        innovation2.FromNeuronID = int.Parse(list2[6]);
                        innovation2.ToNeuronID = int.Parse(list2[7]);
                        goto Label_0A43;
                    Label_0AD7:
                        if ((((uint) num2) - ((uint) num)) >= 0)
                        {
                            goto Label_0023;
                        }
                    Label_0AEF:
                        innovation2 = new NEATInnovation();
                        innovation2.InnovationID = int.Parse(list2[0]);
                        innovation2.InnovationType = StringToInnovationType(list2[1]);
                        innovation2.NeuronType = StringToNeuronType(list2[2]);
                        innovation2.SplitX = CSVFormat.EgFormat.Parse(list2[3]);
                        if (0 == 0)
                        {
                            goto Label_0A7A;
                        }
                        goto Label_0023;
                    Label_0B54:
                        str = enumerator.Current;
                        do
                        {
                            list2 = EncogFileSection.SplitColumns(str);
                        }
                        while (0 != 0);
                        goto Label_0AEF;
                    }
                }
                if (((uint) num) <= uint.MaxValue)
                {
                    goto Label_085C;
                }
                goto Label_030B;
            }
            using (IEnumerator<IGenome> enumerator4 = population.Genomes.GetEnumerator())
            {
                IGenome genome3;
                NEATGenome genome4;
                ISpecies species3;
            Label_0040:
                if (enumerator4.MoveNext())
                {
                    goto Label_00D6;
                }
                goto Label_0102;
            Label_0051:
                genome4.OutputCount = population.OutputCount;
                if ((((uint) num) - ((uint) num2)) >= 0)
                {
                    goto Label_0040;
                }
            Label_007D:
                if (dictionary.ContainsKey(num))
                {
                    goto Label_00BA;
                }
            Label_0087:
                genome4.InputCount = population.InputCount;
                goto Label_0051;
            Label_0096:
                num = (int) genome4.SpeciesID;
                if ((((uint) num2) + ((uint) num2)) <= uint.MaxValue)
                {
                }
                goto Label_007D;
            Label_00BA:
                species3 = dictionary[num];
                species3.Members.Add(genome4);
                goto Label_0087;
            Label_00D6:
                genome3 = enumerator4.Current;
                genome4 = (NEATGenome) genome3;
                goto Label_0096;
            }
        Label_0102:
            using (IEnumerator<ISpecies> enumerator5 = dictionary2.Keys.GetEnumerator())
            {
                ISpecies current;
                goto Label_011F;
            Label_0112:
                ((BasicSpecies) current).Population = population;
            Label_011F:
                if (enumerator5.MoveNext())
                {
                    current = enumerator5.Current;
                    num2 = dictionary2[current];
                    do
                    {
                        IGenome genome5 = dictionary3[num2];
                        current.Leader = genome5;
                    }
                    while (-1 == 0);
                    goto Label_0112;
                }
                return population;
            }
        Label_016E:
            population.YoungScoreBonus = EncogFileSection.ParseDouble(dictionary4, "youngAgeBonus");
            population.GenomeIDGenerate.CurrentID = EncogFileSection.ParseInt(dictionary4, "nextGenomeID");
            population.InnovationIDGenerate.CurrentID = EncogFileSection.ParseInt(dictionary4, "nextInnovationID");
            population.GeneIDGenerate.CurrentID = EncogFileSection.ParseInt(dictionary4, "nextGeneID");
            population.SpeciesIDGenerate.CurrentID = EncogFileSection.ParseInt(dictionary4, "nextSpeciesID");
            goto Label_0023;
        Label_0201:
            population.SurvivalRate = EncogFileSection.ParseDouble(dictionary4, "survivalRate");
            if (0 != 0)
            {
                goto Label_03AA;
            }
            goto Label_02E9;
        Label_0242:
            population.OldAgePenalty = EncogFileSection.ParseDouble(dictionary4, "oldAgePenalty");
            population.OldAgeThreshold = EncogFileSection.ParseInt(dictionary4, "oldAgeThreshold");
        Label_0266:
            population.PopulationSize = EncogFileSection.ParseInt(dictionary4, "populationSize");
            if (((uint) num2) <= uint.MaxValue)
            {
                if ((((uint) num2) - ((uint) num2)) >= 0)
                {
                    if ((((uint) num) + ((uint) num2)) > uint.MaxValue)
                    {
                        goto Label_0242;
                    }
                    goto Label_0201;
                }
                goto Label_02E9;
            }
        Label_028A:
            population.OutputActivationFunction = EncogFileSection.ParseActivationFunction(dictionary4, "outAct");
            if ((((uint) num2) + ((uint) num2)) < 0)
            {
                goto Label_0BD6;
            }
            population.Snapshot = EncogFileSection.ParseBoolean(dictionary4, "snapshot");
            population.InputCount = EncogFileSection.ParseInt(dictionary4, "inputCount");
            population.OutputCount = EncogFileSection.ParseInt(dictionary4, "outputCount");
            goto Label_0242;
        Label_02E9:
            if ((((uint) num2) - ((uint) num)) >= 0)
            {
                population.YoungBonusAgeThreshhold = EncogFileSection.ParseInt(dictionary4, "youngAgeThreshold");
            }
            if (0xff != 0)
            {
                goto Label_016E;
            }
        Label_030B:
            population.NeatActivationFunction = EncogFileSection.ParseActivationFunction(dictionary4, "neatAct");
            goto Label_028A;
        Label_03AA:
            if (!section.SectionName.Equals("NEAT-POPULATION") || !section.SubSectionName.Equals("CONFIG"))
            {
                goto Label_0023;
            }
            if ((((uint) num2) + ((uint) num2)) <= uint.MaxValue)
            {
                if ((((uint) num2) + ((uint) num2)) <= uint.MaxValue)
                {
                    dictionary4 = section.ParseParams();
                }
                goto Label_030B;
            }
        Label_0821:
            if (section.SectionName.Equals("NEAT-POPULATION"))
            {
                if (section.SubSectionName.Equals("GENOMES"))
                {
                    NEATGenome genome = null;
                    using (IEnumerator<string> enumerator3 = section.Lines.GetEnumerator())
                    {
                        string str3;
                        IList<string> list3;
                        NEATGenome genome2;
                        NEATNeuronGene gene;
                        NEATNeuronGene gene2;
                        NEATLinkGene gene3;
                        goto Label_0402;
                    Label_03DA:
                        genome.Links.Add(gene3);
                        goto Label_0402;
                    Label_03EA:
                        if (list3[0].Equals("l", StringComparison.InvariantCultureIgnoreCase))
                        {
                            goto Label_04EA;
                        }
                    Label_0402:
                        if (enumerator3.MoveNext())
                        {
                            goto Label_0770;
                        }
                        if ((((uint) num2) | 0x80000000) != 0)
                        {
                            goto Label_0023;
                        }
                    Label_0429:
                        gene3.Enabled = int.Parse(list3[2]) > 0;
                    Label_0440:
                        gene3.Recurrent = int.Parse(list3[3]) > 0;
                        gene3.FromNeuronID = int.Parse(list3[4]);
                        gene3.ToNeuronID = int.Parse(list3[5]);
                        gene3.Weight = CSVFormat.EgFormat.Parse(list3[6]);
                        gene3.InnovationId = int.Parse(list3[7]);
                        goto Label_03DA;
                    Label_04B4:
                        if ((((uint) num) & 0) != 0)
                        {
                            goto Label_03DA;
                        }
                        gene3.Id = int.Parse(list3[1]);
                        goto Label_0429;
                    Label_04EA:
                        gene3 = new NEATLinkGene();
                        goto Label_04B4;
                    Label_04F6:
                        gene2.SplitY = CSVFormat.EgFormat.Parse(list3[7]);
                    Label_050F:
                        gene = gene2;
                        genome.Neurons.Add(gene);
                        if ((((uint) num2) & 0) != 0)
                        {
                            goto Label_0782;
                        }
                        goto Label_0402;
                    Label_053D:
                        gene2.Enabled = int.Parse(list3[3]) > 0;
                        gene2.InnovationId = int.Parse(list3[4]);
                        if (0xff == 0)
                        {
                            goto Label_050F;
                        }
                        gene2.ActivationResponse = CSVFormat.EgFormat.Parse(list3[5]);
                        gene2.SplitX = CSVFormat.EgFormat.Parse(list3[6]);
                        goto Label_04F6;
                    Label_05A7:
                        gene2.Id = int.Parse(list3[1]);
                        gene2.NeuronType = StringToNeuronType(list3[2]);
                        goto Label_053D;
                    Label_05DA:
                        if (!list3[0].Equals("n", StringComparison.InvariantCultureIgnoreCase))
                        {
                            goto Label_03EA;
                        }
                        if (3 == 0)
                        {
                            goto Label_0440;
                        }
                        gene2 = new NEATNeuronGene();
                        goto Label_07C8;
                    Label_0608:
                        population.Add(genome);
                        dictionary3[(int) genome.GenomeID] = genome;
                        if (((uint) num) >= 0)
                        {
                            goto Label_0402;
                        }
                        goto Label_06B0;
                    Label_0638:
                        genome.AmountToSpawn = CSVFormat.EgFormat.Parse(list3[4]);
                        genome.NetworkDepth = int.Parse(list3[5]);
                        if ((((uint) num2) | 0x80000000) == 0)
                        {
                            goto Label_07AD;
                        }
                        if (((uint) num2) < 0)
                        {
                            goto Label_0023;
                        }
                        genome.Score = CSVFormat.EgFormat.Parse(list3[6]);
                        goto Label_06F8;
                    Label_06B0:
                        genome.GenomeID = int.Parse(list3[1]);
                        genome.SpeciesID = int.Parse(list3[2]);
                        genome.AdjustedScore = CSVFormat.EgFormat.Parse(list3[3]);
                        goto Label_0638;
                    Label_06F8:
                        if (3 != 0)
                        {
                            goto Label_0608;
                        }
                        goto Label_0402;
                    Label_0704:
                        genome.Chromosomes.Add(genome.LinksChromosome);
                        if ((((uint) num2) + ((uint) num2)) >= 0)
                        {
                            goto Label_06B0;
                        }
                        goto Label_0402;
                    Label_0737:
                        if (8 == 0)
                        {
                            goto Label_050F;
                        }
                        genome = genome2;
                        genome.Chromosomes.Add(genome.NeuronsChromosome);
                        if ((((uint) num) - ((uint) num2)) <= uint.MaxValue)
                        {
                            goto Label_0704;
                        }
                    Label_0770:
                        str3 = enumerator3.Current;
                        list3 = EncogFileSection.SplitColumns(str3);
                    Label_0782:
                        if (!list3[0].Equals("g", StringComparison.InvariantCultureIgnoreCase))
                        {
                            goto Label_05DA;
                        }
                        genome2 = new NEATGenome {
                            NeuronsChromosome = new Chromosome()
                        };
                    Label_07AD:
                        genome2.LinksChromosome = new Chromosome();
                        goto Label_0737;
                    Label_07C8:
                        if ((((uint) num2) - ((uint) num)) <= uint.MaxValue)
                        {
                            goto Label_05A7;
                        }
                        if (0 == 0)
                        {
                            goto Label_04EA;
                        }
                        goto Label_04B4;
                    }
                }
                if ((((uint) num2) < 0) || ((((uint) num2) - ((uint) num2)) > uint.MaxValue))
                {
                    goto Label_030B;
                }
            }
            goto Label_03AA;
        Label_085C:
            if (section.SectionName.Equals("NEAT-POPULATION"))
            {
                if ((((uint) num) | 1) == 0)
                {
                    goto Label_0266;
                }
                if (section.SubSectionName.Equals("SPECIES"))
                {
                    if ((((uint) num) | 8) == 0)
                    {
                        goto Label_0201;
                    }
                    using (IEnumerator<string> enumerator2 = section.Lines.GetEnumerator())
                    {
                        string str2;
                        string[] strArray;
                        BasicSpecies species;
                        BasicSpecies species2;
                        goto Label_0913;
                    Label_08CB:
                        species = species2;
                        species.SpawnsRequired = CSVFormat.EgFormat.Parse(strArray[5]);
                        dictionary2[species] = int.Parse(strArray[6]);
                        population.Species.Add(species);
                        dictionary[(int) species.SpeciesID] = species;
                    Label_0913:
                        if (enumerator2.MoveNext())
                        {
                            goto Label_09D6;
                        }
                        goto Label_0023;
                    Label_0924:
                        if ((((uint) num2) & 0) != 0)
                        {
                            goto Label_0969;
                        }
                        if (2 == 0)
                        {
                            goto Label_0924;
                        }
                        goto Label_09BE;
                    Label_0941:
                        species2 = new BasicSpecies();
                        species2.SpeciesID = int.Parse(strArray[0]);
                        species2.Age = int.Parse(strArray[1]);
                    Label_0969:
                        species2.BestScore = CSVFormat.EgFormat.Parse(strArray[2]);
                        species2.GensNoImprovement = int.Parse(strArray[3]);
                        species2.SpawnsRequired = CSVFormat.EgFormat.Parse(strArray[4]);
                        if ((((uint) num) + ((uint) num2)) >= 0)
                        {
                            goto Label_0924;
                        }
                    Label_09BE:
                        if ((((uint) num2) + ((uint) num)) <= uint.MaxValue)
                        {
                            goto Label_09FD;
                        }
                    Label_09D6:
                        str2 = enumerator2.Current;
                        strArray = str2.Split(new char[] { ',' });
                        goto Label_0941;
                    Label_09FD:
                        if ((((uint) num) - ((uint) num)) <= uint.MaxValue)
                        {
                            goto Label_08CB;
                        }
                        goto Label_0023;
                    }
                }
            }
            goto Label_0821;
        Label_0BD6:
            dictionary2 = new Dictionary<ISpecies, int>();
            dictionary3 = new Dictionary<int, IGenome>();
            goto Label_0023;
        }

        public virtual void Save(Stream os, object obj)
        {
            NEATPopulation population;
            EncogWriteHelper helper = new EncogWriteHelper(os);
            if (0 == 0)
            {
                population = (NEATPopulation) obj;
                if (-2147483648 != 0)
                {
                    goto Label_05B6;
                }
            }
        Label_000D:
            helper.Flush();
            return;
        Label_0018:
            using (IEnumerator<ISpecies> enumerator5 = population.Species.GetEnumerator())
            {
                ISpecies species;
                goto Label_0049;
            Label_0027:
                helper.AddColumn(species.Leader.GenomeID);
                if (-2 == 0)
                {
                    goto Label_000D;
                }
                helper.WriteLine();
            Label_0049:
                if (enumerator5.MoveNext())
                {
                    goto Label_00A2;
                }
                goto Label_000D;
            Label_0054:
                helper.AddColumn(species.BestScore);
                helper.AddColumn(species.GensNoImprovement);
                helper.AddColumn(species.NumToSpawn);
                helper.AddColumn(species.SpawnsRequired);
                goto Label_0027;
            Label_008C:
                helper.AddColumn(species.Age);
                if (0x7fffffff != 0)
                {
                    goto Label_0054;
                }
                goto Label_000D;
            Label_00A2:
                species = enumerator5.Current;
                helper.AddColumn(species.SpeciesID);
                goto Label_008C;
            }
        Label_00D2:
            if (population.Innovations != null)
            {
                goto Label_03B2;
            }
        Label_00DD:
            helper.AddSubSection("GENOMES");
            using (IEnumerator<IGenome> enumerator2 = population.Genomes.GetEnumerator())
            {
                IGenome genome;
                NEATGenome genome2;
                goto Label_01E0;
            Label_00FA:
                using (List<IGene>.Enumerator enumerator4 = genome2.Links.Genes.GetEnumerator())
                {
                    IGene gene3;
                    NEATLinkGene gene4;
                    goto Label_0129;
                Label_010F:
                    if (2 == 0)
                    {
                        goto Label_016F;
                    }
                    helper.AddColumn(gene4.InnovationId);
                    helper.WriteLine();
                Label_0129:
                    if (enumerator4.MoveNext())
                    {
                        goto Label_01C4;
                    }
                    goto Label_01E0;
                Label_013A:
                    helper.AddColumn(gene4.Weight);
                    goto Label_010F;
                Label_014C:
                    helper.AddColumn(gene4.ToNeuronID);
                    if (4 != 0)
                    {
                        goto Label_013A;
                    }
                    goto Label_018C;
                Label_0162:
                    helper.AddColumn(gene4.Enabled);
                Label_016F:
                    helper.AddColumn(gene4.Recurrent);
                    helper.AddColumn(gene4.FromNeuronID);
                    if (0 == 0)
                    {
                        goto Label_014C;
                    }
                Label_018C:
                    gene4 = (NEATLinkGene) gene3;
                    if (1 != 0)
                    {
                    }
                    helper.AddColumn("l");
                    helper.AddColumn(gene4.Id);
                    goto Label_0162;
                Label_01C4:
                    gene3 = enumerator4.Current;
                    if (0 == 0)
                    {
                        goto Label_018C;
                    }
                }
            Label_01E0:
                if (enumerator2.MoveNext())
                {
                    goto Label_030A;
                }
                goto Label_0361;
            Label_01F1:
                helper.AddColumn(genome2.AmountToSpawn);
                helper.AddColumn(genome2.NetworkDepth);
                helper.AddColumn(genome2.Score);
                helper.WriteLine();
                using (List<IGene>.Enumerator enumerator3 = genome2.Neurons.Genes.GetEnumerator())
                {
                    IGene gene;
                    NEATNeuronGene gene2;
                    goto Label_0246;
                Label_0233:
                    helper.AddColumn(gene2.SplitY);
                    helper.WriteLine();
                Label_0246:
                    if (enumerator3.MoveNext())
                    {
                        goto Label_02D6;
                    }
                    if (0 == 0)
                    {
                        goto Label_02CF;
                    }
                Label_0255:
                    helper.AddColumn(gene2.Enabled);
                    helper.AddColumn(gene2.InnovationId);
                    helper.AddColumn(gene2.ActivationResponse);
                    helper.AddColumn(gene2.SplitX);
                    goto Label_0233;
                Label_028D:
                    gene2 = (NEATNeuronGene) gene;
                    helper.AddColumn("n");
                    if (8 != 0)
                    {
                    }
                    do
                    {
                        helper.AddColumn(gene2.Id);
                    }
                    while (0 != 0);
                    helper.AddColumn(NeuronTypeToString(gene2.NeuronType));
                    goto Label_0255;
                Label_02CF:
                    if (2 != 0)
                    {
                        goto Label_00FA;
                    }
                Label_02D6:
                    gene = enumerator3.Current;
                    goto Label_028D;
                }
                goto Label_00FA;
            Label_02FB:
                helper.AddColumn(genome2.AdjustedScore);
                goto Label_0346;
            Label_030A:
                genome = enumerator2.Current;
                genome2 = (NEATGenome) genome;
                if (0 == 0)
                {
                }
                helper.AddColumn("g");
                helper.AddColumn(genome2.GenomeID);
                helper.AddColumn(genome2.SpeciesID);
                goto Label_02FB;
            Label_0346:
                if (0 == 0)
                {
                    goto Label_01F1;
                }
                if (0 != 0)
                {
                    goto Label_02FB;
                }
                goto Label_030A;
            }
        Label_0361:
            helper.AddSubSection("SPECIES");
            goto Label_0018;
        Label_03B2:
            using (IEnumerator<IInnovation> enumerator = population.Innovations.Innovations.GetEnumerator())
            {
                IInnovation innovation;
                NEATInnovation innovation2;
                goto Label_03CC;
            Label_03C6:
                helper.WriteLine();
            Label_03CC:
                if (enumerator.MoveNext())
                {
                    goto Label_0452;
                }
                goto Label_00DD;
            Label_03DA:
                helper.AddColumn(innovation2.SplitY);
                helper.AddColumn(innovation2.NeuronID);
                helper.AddColumn(innovation2.FromNeuronID);
                helper.AddColumn(innovation2.ToNeuronID);
                goto Label_03C6;
            Label_040C:
                if (0 != 0)
                {
                    goto Label_03CC;
                }
                helper.AddColumn(innovation2.InnovationID);
                helper.AddColumn(InnovationTypeToString(innovation2.InnovationType));
                helper.AddColumn(NeuronTypeToString(innovation2.NeuronType));
                helper.AddColumn(innovation2.SplitX);
                goto Label_03DA;
            Label_0452:
                innovation = enumerator.Current;
                innovation2 = (NEATInnovation) innovation;
                if (3 != 0)
                {
                    goto Label_040C;
                }
                goto Label_00DD;
            }
            if (0x7fffffff != 0)
            {
                goto Label_00D2;
            }
            goto Label_0018;
            if (-2147483648 != 0)
            {
                goto Label_000D;
            }
        Label_05B6:
            helper.AddSection("NEAT-POPULATION");
            helper.AddSubSection("CONFIG");
            helper.WriteProperty("snapshot", population.Snapshot);
            helper.WriteProperty("outAct", population.OutputActivationFunction);
            helper.WriteProperty("neatAct", population.NeatActivationFunction);
            if (0 != 0)
            {
                goto Label_00DD;
            }
            if (2 != 0)
            {
                helper.WriteProperty("inputCount", population.InputCount);
                helper.WriteProperty("outputCount", population.OutputCount);
                helper.WriteProperty("oldAgePenalty", population.OldAgePenalty);
            }
            helper.WriteProperty("oldAgeThreshold", population.OldAgeThreshold);
            helper.WriteProperty("populationSize", population.PopulationSize);
            helper.WriteProperty("survivalRate", population.SurvivalRate);
            if (0 != 0)
            {
                goto Label_0018;
            }
            helper.WriteProperty("youngAgeThreshold", population.YoungBonusAgeThreshold);
            helper.WriteProperty("youngAgeBonus", population.YoungScoreBonus);
            helper.WriteProperty("nextGenomeID", population.GenomeIDGenerate.CurrentID);
            helper.WriteProperty("nextInnovationID", population.InnovationIDGenerate.CurrentID);
            helper.WriteProperty("nextGeneID", population.GeneIDGenerate.CurrentID);
            helper.WriteProperty("nextSpeciesID", population.SpeciesIDGenerate.CurrentID);
            helper.AddSubSection("INNOVATIONS");
            if (0x7fffffff != 0)
            {
                goto Label_00D2;
            }
            goto Label_03B2;
        }

        public static NEATInnovationType StringToInnovationType(string t)
        {
            if (!t.Equals("l", StringComparison.InvariantCultureIgnoreCase) && t.Equals("n", StringComparison.InvariantCultureIgnoreCase))
            {
                return NEATInnovationType.NewNeuron;
            }
            return NEATInnovationType.NewLink;
        }

        public static NEATNeuronType StringToNeuronType(string t)
        {
            if (!t.Equals("b"))
            {
                if (t.Equals("h"))
                {
                    return NEATNeuronType.Hidden;
                }
                if (-1 != 0)
                {
                    goto Label_0027;
                }
                goto Label_004C;
            }
            if (0 == 0)
            {
                return NEATNeuronType.Bias;
            }
        Label_0027:
            if (!t.Equals("i"))
            {
                if (!t.Equals("n"))
                {
                    if (!t.Equals("o"))
                    {
                        throw new EncogError("Unknonw neuron type: " + t);
                    }
                    return NEATNeuronType.Output;
                }
                return NEATNeuronType.None;
            }
        Label_004C:
            return NEATNeuronType.Input;
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
                return typeof(NEATPopulation);
            }
        }

        public virtual string PersistClassString
        {
            get
            {
                return typeof(NEATPopulation).Name;
            }
        }
    }
}

