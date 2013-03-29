namespace Encog.Neural.NEAT.Training
{
    using Encog.MathUtil;
    using Encog.MathUtil.Randomize;
    using Encog.ML.Genetic.Genes;
    using Encog.ML.Genetic.Genome;
    using Encog.Neural;
    using Encog.Neural.NEAT;
    using Encog.Neural.Neat.Training;
    using System;
    using System.Collections.Generic;

    [Serializable]
    public class NEATGenome : BasicGenome, ICloneable
    {
        private int inputCount;
        private Chromosome linksChromosome;
        private int networkDepth;
        private Chromosome neuronsChromosome;
        private int outputCount;
        public const string PROPERTY_LINKS = "links";
        public const string PROPERTY_NEURONS = "neurons";
        private long speciesID;
        public const double TWEAK_DISJOINT = 1.0;
        public const double TWEAK_EXCESS = 1.0;
        public const double TWEAK_MATCHED = 0.4;

        public NEATGenome()
        {
        }

        public NEATGenome(NEATGenome other)
        {
            goto Label_0182;
        Label_0017:
            this.inputCount = other.inputCount;
            this.outputCount = other.outputCount;
        Label_002F:
            this.speciesID = other.speciesID;
            foreach (IGene gene in other.Neurons.Genes)
            {
                NEATNeuronGene gene2 = (NEATNeuronGene) gene;
                if (0xff != 0)
                {
                    NEATNeuronGene gene3 = new NEATNeuronGene(gene2.NeuronType, gene2.Id, gene2.SplitY, gene2.SplitX, gene2.Recurrent, gene2.ActivationResponse);
                    this.Neurons.Add(gene3);
                }
            }
            foreach (IGene gene4 in other.Links.Genes)
            {
                NEATLinkGene gene5 = (NEATLinkGene) gene4;
                NEATLinkGene gene6 = new NEATLinkGene((long) gene5.FromNeuronID, (long) gene5.ToNeuronID, gene5.Enabled, gene5.InnovationId, gene5.Weight, gene5.Recurrent);
                this.Links.Add(gene6);
            }
            return;
        Label_0182:
            this.neuronsChromosome = new Chromosome();
            this.linksChromosome = new Chromosome();
            base.GA = other.GA;
            base.Chromosomes.Add(this.neuronsChromosome);
            if (0 != 0)
            {
                goto Label_002F;
            }
            base.Chromosomes.Add(this.linksChromosome);
            base.GenomeID = other.GenomeID;
            this.networkDepth = other.networkDepth;
            base.Population = other.Population;
            base.Score = other.Score;
            if (0x7fffffff == 0)
            {
                goto Label_0017;
            }
            base.AdjustedScore = other.AdjustedScore;
            if (0 == 0)
            {
                base.AmountToSpawn = other.AmountToSpawn;
                goto Label_0017;
            }
            goto Label_0182;
        }

        public NEATGenome(long id, int inputCount_0, int outputCount_1)
        {
            double num3;
            int num4;
            int num5;
            int num6;
            base.GenomeID = id;
            base.AdjustedScore = 0.0;
            if (((uint) num5) < 0)
            {
                goto Label_00A7;
            }
            this.inputCount = inputCount_0;
            if ((((uint) num4) & 0) != 0)
            {
                goto Label_00AC;
            }
            this.outputCount = outputCount_1;
            base.AmountToSpawn = 0.0;
            this.speciesID = 0L;
            double num = 0.8 / ((double) inputCount_0);
            this.neuronsChromosome = new Chromosome();
            this.linksChromosome = new Chromosome();
            if (2 != 0)
            {
                base.Chromosomes.Add(this.neuronsChromosome);
                base.Chromosomes.Add(this.linksChromosome);
                for (int i = 0; i < inputCount_0; i++)
                {
                    this.neuronsChromosome.Add(new NEATNeuronGene(NEATNeuronType.Input, (long) i, 0.0, 0.1 + (i * num)));
                }
                this.neuronsChromosome.Add(new NEATNeuronGene(NEATNeuronType.Bias, (long) inputCount_0, 0.0, 0.9));
                num3 = 1.0 / ((double) (outputCount_1 + 1));
                num4 = 0;
                goto Label_00C8;
            }
            return;
        Label_0079:
            while (num6 < outputCount_1)
            {
                this.linksChromosome.Add(new NEATLinkGene(((NEATNeuronGene) this.neuronsChromosome.Get(num5)).Id, ((NEATNeuronGene) this.Neurons.Get((inputCount_0 + num6) + 1)).Id, true, (long) (((inputCount_0 + outputCount_1) + 1) + this.NumGenes), RangeRandomizer.Randomize(-1.0, 1.0), false));
                num6++;
            }
            num5++;
        Label_0084:
            if (num5 >= (inputCount_0 + 1))
            {
                if (((uint) outputCount_1) >= 0)
                {
                    return;
                }
                goto Label_0079;
            }
        Label_00A7:
            num6 = 0;
            goto Label_0079;
        Label_00AC:
            num4++;
            if ((((uint) id) + ((uint) num5)) < 0)
            {
                goto Label_00A7;
            }
        Label_00C8:
            if (num4 < outputCount_1)
            {
                this.neuronsChromosome.Add(new NEATNeuronGene(NEATNeuronType.Output, (long) ((num4 + inputCount_0) + 1), 1.0, (num4 + 1) * num3));
                goto Label_00AC;
            }
            if (((uint) inputCount_0) >= 0)
            {
                num5 = 0;
            }
            goto Label_0084;
        }

        public NEATGenome(long genomeID, Chromosome neurons, Chromosome links, int inputCount_0, int outputCount_1)
        {
            base.GenomeID = genomeID;
            while (true)
            {
                this.linksChromosome = links;
                this.neuronsChromosome = neurons;
                base.AmountToSpawn = 0.0;
                base.AdjustedScore = 0.0;
                this.inputCount = inputCount_0;
                this.outputCount = outputCount_1;
                base.Chromosomes.Add(this.neuronsChromosome);
                if (0 == 0)
                {
                    base.Chromosomes.Add(this.linksChromosome);
                    return;
                }
            }
        }

        internal void AddLink(double mutationRate, double chanceOfLooped, int numTrysToFindLoop, int numTrysToAddLink)
        {
            int num;
            int num2;
            long id;
            long num4;
            bool flag;
            NEATNeuronGene gene;
            NEATNeuronGene gene2;
            NEATNeuronGene gene3;
            NEATInnovation innovation;
            NEATNeuronGene gene4;
            long num5;
            NEATLinkGene gene5;
            if (ThreadSafeRandom.NextDouble() <= mutationRate)
            {
                num = numTrysToFindLoop;
                if ((((uint) num5) - ((uint) chanceOfLooped)) > uint.MaxValue)
                {
                    if ((((uint) num4) + ((uint) num2)) < 0)
                    {
                        goto Label_01D4;
                    }
                    if ((((uint) numTrysToAddLink) - ((uint) num2)) < 0)
                    {
                        goto Label_0327;
                    }
                    goto Label_01BA;
                }
                num2 = numTrysToFindLoop;
                id = -1L;
                num4 = -1L;
                flag = false;
                goto Label_01EE;
            }
            return;
        Label_0057:
            if (innovation == null)
            {
                ((NEATTraining) base.GA).Innovations.CreateNewInnovation(id, num4, NEATInnovationType.NewLink);
                num5 = base.GA.Population.AssignInnovationID();
                if (15 != 0)
                {
                    gene5 = new NEATLinkGene(id, num4, true, num5, RangeRandomizer.Randomize(-1.0, 1.0), flag);
                    if ((((uint) num) + ((uint) num5)) > uint.MaxValue)
                    {
                        goto Label_00B2;
                    }
                }
            }
            else
            {
                NEATLinkGene gene6 = new NEATLinkGene(id, num4, true, innovation.InnovationID, RangeRandomizer.Randomize(-1.0, 1.0), flag);
                this.linksChromosome.Add(gene6);
                if (3 != 0)
                {
                    return;
                }
                goto Label_0123;
            }
        Label_0063:
            this.linksChromosome.Add(gene5);
            return;
        Label_00B2:
            gene4 = (NEATNeuronGene) this.neuronsChromosome.Get(this.GetElementPos(id));
            if (gene4.SplitY > gene4.SplitY)
            {
                flag = true;
            }
            goto Label_0057;
        Label_011E:
            if (id < 0L)
            {
                return;
            }
        Label_0123:
            if (num4 >= 0L)
            {
                innovation = ((NEATTraining) base.GA).Innovations.CheckInnovation(id, id, NEATInnovationType.NewLink);
                if ((((uint) numTrysToAddLink) + ((uint) flag)) <= uint.MaxValue)
                {
                    goto Label_00B2;
                }
                goto Label_0063;
            }
            return;
        Label_0198:
            if (num2-- > 0)
            {
                gene2 = this.ChooseRandomNeuron(true);
                gene3 = this.ChooseRandomNeuron(false);
                goto Label_01CA;
            }
            if ((((uint) mutationRate) + ((uint) chanceOfLooped)) < 0)
            {
                if ((((uint) id) | 4) == 0)
                {
                    goto Label_0057;
                }
                goto Label_01EE;
            }
            goto Label_011E;
        Label_01BA:
            if (gene3.NeuronType != NEATNeuronType.Bias)
            {
                id = gene2.Id;
                if ((((uint) mutationRate) + ((uint) numTrysToAddLink)) > uint.MaxValue)
                {
                    goto Label_01CA;
                }
                num4 = gene3.Id;
                if ((((uint) num5) + ((uint) num4)) > uint.MaxValue)
                {
                    goto Label_0311;
                }
                if ((((uint) num) - ((uint) id)) < 0)
                {
                    return;
                }
                if (0 == 0)
                {
                    goto Label_011E;
                }
                goto Label_02DF;
            }
            goto Label_0198;
        Label_01CA:
            if (this.IsDuplicateLink(id, num4))
            {
                goto Label_0198;
            }
        Label_01D4:
            if (((((uint) num5) - ((uint) chanceOfLooped)) <= uint.MaxValue) && (gene2.Id != gene3.Id))
            {
                goto Label_01BA;
            }
            goto Label_0198;
        Label_01EE:
            if (ThreadSafeRandom.NextDouble() >= chanceOfLooped)
            {
                goto Label_0198;
            }
        Label_02DF:
            if (num-- > 0)
            {
                gene = this.ChooseRandomNeuron(false);
            }
            else
            {
                goto Label_011E;
            }
        Label_0311:
            if ((!gene.Recurrent && (gene.NeuronType != NEATNeuronType.Bias)) && (gene.NeuronType != NEATNeuronType.Input))
            {
                if (-1 == 0)
                {
                    goto Label_032F;
                }
                id = gene.Id;
            }
            else
            {
                goto Label_02DF;
            }
        Label_0327:
            num4 = gene.Id;
        Label_032F:
            gene.Recurrent = true;
            flag = true;
            num = 0;
            goto Label_02DF;
        }

        internal void AddNeuron(double mutationRate, int numTrysToFindOldLink)
        {
            int num;
            NEATLinkGene gene;
            int num2;
            int num3;
            int num4;
            NEATLinkGene gene2;
            long num5;
            double weight;
            long fromNeuronID;
            long toNeuronID;
            NEATNeuronGene gene3;
            NEATNeuronGene gene4;
            double num9;
            double num10;
            NEATInnovation innovation;
            long num11;
            long num12;
            long num13;
            long num14;
            long neuronID;
            NEATInnovation innovation2;
            NEATInnovation innovation3;
            NEATLinkGene gene7;
            NEATLinkGene gene8;
            NEATNeuronGene gene9;
            if (ThreadSafeRandom.NextDouble() <= mutationRate)
            {
                goto Label_05EE;
            }
            return;
        Label_0043:
            this.linksChromosome.Add(gene7);
            this.linksChromosome.Add(gene8);
        Label_005D:
            gene9 = new NEATNeuronGene(NEATNeuronType.Hidden, neuronID, num9, num10);
            this.neuronsChromosome.Add(gene9);
            if ((((uint) num2) & 0) == 0)
            {
                if ((((uint) num14) + ((uint) num14)) <= uint.MaxValue)
                {
                    return;
                }
                if ((((uint) num10) - ((uint) num12)) >= 0)
                {
                    goto Label_0131;
                }
                goto Label_00EC;
            }
        Label_008C:
            if ((((uint) num11) & 0) != 0)
            {
                goto Label_0043;
            }
        Label_00A9:
            throw new NeuralNetworkError("NEAT Error");
        Label_00EC:
            innovation3 = ((NEATTraining) base.GA).Innovations.CheckInnovation(neuronID, toNeuronID, NEATInnovationType.NewLink);
            if ((((uint) numTrysToFindOldLink) - ((uint) num4)) < 0)
            {
                goto Label_0332;
            }
            if (innovation2 != null)
            {
                if (innovation3 == null)
                {
                    if ((((uint) num) & 0) != 0)
                    {
                        return;
                    }
                    goto Label_008C;
                }
                gene7 = new NEATLinkGene(fromNeuronID, neuronID, true, innovation2.InnovationID, 1.0, false);
                gene8 = new NEATLinkGene(neuronID, toNeuronID, true, innovation3.InnovationID, weight, false);
                goto Label_0043;
            }
            goto Label_00A9;
        Label_0131:
            if (innovation != null)
            {
                neuronID = innovation.NeuronID;
                innovation2 = ((NEATTraining) base.GA).Innovations.CheckInnovation(fromNeuronID, neuronID, NEATInnovationType.NewLink);
                goto Label_00EC;
            }
            do
            {
                num12 = ((NEATTraining) base.GA).Innovations.CreateNewInnovation(fromNeuronID, toNeuronID, NEATInnovationType.NewNeuron, NEATNeuronType.Hidden, num10, num9);
                this.neuronsChromosome.Add(new NEATNeuronGene(NEATNeuronType.Hidden, num12, num9, num10));
                num13 = base.GA.Population.AssignInnovationID();
                if ((((uint) fromNeuronID) | 15) == 0)
                {
                    goto Label_0534;
                }
                ((NEATTraining) base.GA).Innovations.CreateNewInnovation(fromNeuronID, num12, NEATInnovationType.NewLink);
                NEATLinkGene gene5 = new NEATLinkGene(fromNeuronID, num12, true, num13, 1.0, false);
                this.linksChromosome.Add(gene5);
                if (((uint) num4) <= uint.MaxValue)
                {
                    num14 = base.GA.Population.AssignInnovationID();
                    ((NEATTraining) base.GA).Innovations.CreateNewInnovation(num12, toNeuronID, NEATInnovationType.NewLink);
                    NEATLinkGene gene6 = new NEATLinkGene(num12, toNeuronID, true, num14, weight, false);
                    this.linksChromosome.Add(gene6);
                    return;
                }
            }
            while ((((uint) num14) + ((uint) num10)) > uint.MaxValue);
        Label_029B:
            if (((uint) num) > uint.MaxValue)
            {
                goto Label_05EE;
            }
            goto Label_0131;
        Label_0332:
            num10 = (gene3.SplitX + gene4.SplitX) / 2.0;
            innovation = ((NEATTraining) base.GA).Innovations.CheckInnovation(fromNeuronID, toNeuronID, NEATInnovationType.NewNeuron);
            if ((((uint) num9) <= uint.MaxValue) && (innovation == null))
            {
                if (((uint) num5) > uint.MaxValue)
                {
                    goto Label_00EC;
                }
                if ((((uint) weight) & 0) != 0)
                {
                    goto Label_005D;
                }
                if (((uint) num) >= 0)
                {
                    if ((((uint) num) + ((uint) mutationRate)) <= uint.MaxValue)
                    {
                        if ((((uint) num9) - ((uint) weight)) < 0)
                        {
                            return;
                        }
                        goto Label_029B;
                    }
                    goto Label_04BE;
                }
            }
            else
            {
                num11 = innovation.NeuronID;
                if (this.AlreadyHaveThisNeuronID(num11))
                {
                    innovation = null;
                }
                goto Label_0131;
            }
        Label_03A3:
            if ((((uint) neuronID) - ((uint) num10)) > uint.MaxValue)
            {
                if (((uint) num5) >= 0)
                {
                    goto Label_04BE;
                }
                if ((((uint) num5) & 0) == 0)
                {
                    goto Label_04DC;
                }
                goto Label_0534;
            }
            gene4 = (NEATNeuronGene) this.Neurons.Get(this.GetElementPos(toNeuronID));
            num9 = (gene3.SplitY + gene4.SplitY) / 2.0;
            goto Label_0332;
        Label_03FD:
            gene3 = (NEATNeuronGene) this.Neurons.Get(this.GetElementPos(fromNeuronID));
            if ((((uint) num10) - ((uint) num9)) >= 0)
            {
                goto Label_03A3;
            }
            if (((uint) num5) <= uint.MaxValue)
            {
                return;
            }
        Label_0441:
            gene.Enabled = false;
            weight = gene.Weight;
            fromNeuronID = gene.FromNeuronID;
            toNeuronID = gene.ToNeuronID;
            if (((uint) num13) >= 0)
            {
                goto Label_03FD;
            }
            return;
        Label_0475:
            if (gene == null)
            {
                return;
            }
            if ((((uint) num9) - ((uint) weight)) >= 0)
            {
                goto Label_0441;
            }
            goto Label_03FD;
        Label_0497:
            if (num-- > 0)
            {
                goto Label_0534;
            }
            if ((((uint) num10) | 3) != 0)
            {
                goto Label_0475;
            }
            return;
        Label_04BE:
            if (((uint) num12) <= uint.MaxValue)
            {
                goto Label_0497;
            }
        Label_04DC:
            if (((NEATNeuronGene) this.Neurons.Get(this.GetElementPos(num5))).NeuronType == NEATNeuronType.Bias)
            {
                goto Label_0497;
            }
            gene = gene2;
            goto Label_0475;
        Label_0534:
            num4 = RangeRandomizer.RandomInt(0, num3);
            gene2 = (NEATLinkGene) this.linksChromosome.Get(num4);
            num5 = gene2.FromNeuronID;
            if (!gene2.Enabled || gene2.Recurrent)
            {
                goto Label_0497;
            }
            goto Label_04DC;
        Label_0575:
            num3 = this.NumGenes - 1;
            goto Label_0497;
        Label_05EE:
            num = numTrysToFindOldLink;
            if ((((uint) num9) + ((uint) num13)) > uint.MaxValue)
            {
                if ((((uint) num4) - ((uint) num3)) > uint.MaxValue)
                {
                    goto Label_00A9;
                }
                goto Label_0575;
            }
            gene = null;
            num2 = (this.inputCount + this.outputCount) + 10;
            if ((((uint) toNeuronID) & 0) != 0)
            {
                goto Label_04DC;
            }
            if (this.linksChromosome.Size() >= num2)
            {
                goto Label_0575;
            }
            num3 = (this.NumGenes - 1) - ((int) Math.Sqrt((double) this.NumGenes));
            goto Label_0497;
        }

        public bool AlreadyHaveThisNeuronID(long id)
        {
            using (List<IGene>.Enumerator enumerator = this.neuronsChromosome.Genes.GetEnumerator())
            {
                NEATNeuronGene gene2;
                goto Label_003A;
            Label_0031:
                if (gene2.Id == id)
                {
                    return true;
                }
            Label_003A:
                if (enumerator.MoveNext())
                {
                    IGene current = enumerator.Current;
                    gene2 = (NEATNeuronGene) current;
                    goto Label_0031;
                }
            }
            return false;
        }

        private NEATNeuronGene ChooseRandomNeuron(bool includeInput)
        {
            int num;
            if (includeInput)
            {
                num = 0;
            }
            else
            {
                num = this.inputCount + 1;
            }
            int i = RangeRandomizer.RandomInt(num, this.Neurons.Size() - 1);
            return (NEATNeuronGene) this.neuronsChromosome.Get(i);
        }

        public object Clone()
        {
            throw new NotImplementedException();
        }

        public override void Decode()
        {
            int elementPos;
            NEATNetwork network;
            NEATPopulation population = (NEATPopulation) base.Population;
            IList<NEATNeuron> neurons = new List<NEATNeuron>();
            if ((((uint) elementPos) & 0) == 0)
            {
                foreach (IGene gene in this.Neurons.Genes)
                {
                    NEATNeuronGene gene2 = (NEATNeuronGene) gene;
                    NEATNeuron item = new NEATNeuron(gene2.NeuronType, gene2.Id, gene2.SplitY, gene2.SplitX, gene2.ActivationResponse);
                    do
                    {
                        neurons.Add(item);
                    }
                    while (((uint) elementPos) < 0);
                }
            }
            using (List<IGene>.Enumerator enumerator2 = this.Links.Genes.GetEnumerator())
            {
                IGene gene3;
                NEATLinkGene gene4;
                NEATNeuron neuron2;
                NEATNeuron neuron3;
                NEATLink link;
                goto Label_00D5;
            Label_00A0:
                link = new NEATLink(gene4.Weight, neuron2, neuron3, gene4.Recurrent);
                neuron2.OutputboundLinks.Add(link);
                neuron3.InboundLinks.Add(link);
            Label_00D5:
                if (enumerator2.MoveNext())
                {
                    goto Label_0159;
                }
                goto Label_01CA;
            Label_00E3:
                Console.Out.WriteLine("test");
                goto Label_0111;
            Label_00F4:
                if (elementPos == -1)
                {
                    goto Label_00E3;
                }
                if ((((uint) elementPos) | 15) == 0)
                {
                    goto Label_0147;
                }
            Label_0111:
                neuron3 = neurons[elementPos];
                if ((((uint) elementPos) - ((uint) elementPos)) > uint.MaxValue)
                {
                    goto Label_00F4;
                }
                goto Label_00A0;
            Label_013D:
                neuron2 = neurons[elementPos];
            Label_0147:
                elementPos = this.GetElementPos((long) gene4.ToNeuronID);
                goto Label_00F4;
            Label_0159:
                gene3 = enumerator2.Current;
                gene4 = (NEATLinkGene) gene3;
                if (!gene4.Enabled)
                {
                    goto Label_00D5;
                }
                elementPos = this.GetElementPos((long) gene4.FromNeuronID);
                if ((((uint) elementPos) - ((uint) elementPos)) <= uint.MaxValue)
                {
                    goto Label_013D;
                }
                if ((((uint) elementPos) - ((uint) elementPos)) >= 0)
                {
                    goto Label_00E3;
                }
            }
        Label_01CA:
            network = new NEATNetwork(this.inputCount, this.outputCount, neurons, population.NeatActivationFunction, population.OutputActivationFunction, 0);
            network.Snapshot = population.Snapshot;
            base.Organism = network;
        }

        public override void Encode()
        {
        }

        public double GetCompatibilityScore(NEATGenome genome)
        {
            double num2;
            double num3;
            double num4;
            int num5;
            int num6;
            long num7;
            long innovationId;
            int numGenes;
            double num10;
            double num = 0.0;
            goto Label_02B8;
        Label_001B:
            return ((((1.0 * num2) / ((double) numGenes)) + ((1.0 * num) / ((double) numGenes))) + ((0.4 * num4) / num3));
        Label_005C:
            if (num7 > innovationId)
            {
                num++;
                goto Label_00BD;
            }
        Label_0062:
            if ((num5 < (this.linksChromosome.Size() - 1)) || (num6 < (this.linksChromosome.Size() - 1)))
            {
                goto Label_0257;
            }
            numGenes = genome.NumGenes;
            if ((((uint) num5) + ((uint) numGenes)) <= uint.MaxValue)
            {
                if (this.NumGenes > numGenes)
                {
                    numGenes = this.NumGenes;
                }
                goto Label_001B;
            }
        Label_00BD:
            num6++;
            goto Label_0062;
        Label_00C5:
            num5++;
            if ((((uint) num10) + ((uint) num7)) < 0)
            {
                goto Label_01D0;
            }
            goto Label_005C;
        Label_00EB:
            if (num7 < innovationId)
            {
                num++;
                goto Label_00C5;
            }
            goto Label_005C;
        Label_01D0:
            num7 = ((NEATLinkGene) this.linksChromosome.Get(num5)).InnovationId;
            innovationId = ((NEATLinkGene) genome.Links.Get(num6)).InnovationId;
            if (num7 != innovationId)
            {
                goto Label_00EB;
            }
            if ((((uint) num4) - ((uint) num2)) <= uint.MaxValue)
            {
                if ((((uint) num6) | 2) != 0)
                {
                    num5++;
                    if ((((uint) num10) + ((uint) innovationId)) > uint.MaxValue)
                    {
                        return num10;
                    }
                    if ((((uint) num2) | 15) != 0)
                    {
                        num6++;
                        if (0 != 0)
                        {
                            goto Label_001B;
                        }
                        num3++;
                        if ((((uint) num6) - ((uint) num)) <= uint.MaxValue)
                        {
                            num4 += Math.Abs((double) (((NEATLinkGene) this.linksChromosome.Get(num5)).Weight - ((NEATLinkGene) genome.Links.Get(num6)).Weight));
                            goto Label_00EB;
                        }
                        goto Label_00C5;
                    }
                }
                else
                {
                    goto Label_02B8;
                }
            }
        Label_0257:
            while (num5 == (this.linksChromosome.Size() - 1))
            {
                num6++;
                num2++;
                goto Label_0062;
            }
            if (num6 == (genome.Links.Size() - 1))
            {
                num5++;
                num2++;
                goto Label_0062;
            }
            goto Label_01D0;
        Label_02B8:
            num2 = 0.0;
            num3 = 0.0;
            num4 = 0.0;
            num5 = 0;
            num6 = 0;
            if ((((uint) innovationId) - ((uint) num3)) > uint.MaxValue)
            {
                goto Label_01D0;
            }
            goto Label_0062;
        }

        private int GetElementPos(long neuronID)
        {
            for (int i = 0; i < this.Neurons.Size(); i++)
            {
                NEATNeuronGene gene;
                do
                {
                    gene = (NEATNeuronGene) this.neuronsChromosome.GetGene(i);
                }
                while (3 == 0);
                if (gene.Id == neuronID)
                {
                    return i;
                }
            }
            return -1;
        }

        public double GetSplitY(int nd)
        {
            return ((NEATNeuronGene) this.neuronsChromosome.Get(nd)).SplitY;
        }

        public bool IsDuplicateLink(long fromNeuronID, long toNeuronID)
        {
            using (List<IGene>.Enumerator enumerator = this.Links.Genes.GetEnumerator())
            {
                IGene gene;
                NEATLinkGene gene2;
                bool flag;
            Label_0013:
                if (enumerator.MoveNext())
                {
                    goto Label_008F;
                }
                goto Label_00B8;
            Label_0024:
                if (gene2.FromNeuronID != fromNeuronID)
                {
                    goto Label_0013;
                }
                do
                {
                    if (gene2.ToNeuronID == toNeuronID)
                    {
                        return true;
                    }
                    if ((((uint) fromNeuronID) - ((uint) fromNeuronID)) <= uint.MaxValue)
                    {
                        goto Label_0013;
                    }
                }
                while (4 == 0);
                do
                {
                    if (((uint) fromNeuronID) < 0)
                    {
                        break;
                    }
                    goto Label_0013;
                }
                while (((uint) flag) >= 0);
                goto Label_0024;
            Label_008F:
                gene = enumerator.Current;
                gene2 = (NEATLinkGene) gene;
                goto Label_0024;
            }
        Label_00B8:
            return false;
        }

        public void MutateActivationResponse(double mutateRate, double maxPertubation)
        {
            using (List<IGene>.Enumerator enumerator = this.neuronsChromosome.Genes.GetEnumerator())
            {
                IGene gene;
                NEATNeuronGene gene2;
                goto Label_0051;
            Label_0013:
                if (-2147483648 == 0)
                {
                    goto Label_0072;
                }
            Label_001A:
                gene2 = (NEATNeuronGene) gene;
                gene2.ActivationResponse += RangeRandomizer.Randomize(-1.0, 1.0) * maxPertubation;
                goto Label_0051;
            Label_0049:
                if (ThreadSafeRandom.NextDouble() < mutateRate)
                {
                    goto Label_001A;
                }
            Label_0051:
                if (!enumerator.MoveNext() && ((((uint) maxPertubation) | 0x7fffffff) != 0))
                {
                    return;
                }
            Label_0072:
                gene = enumerator.Current;
                if ((((uint) maxPertubation) - ((uint) mutateRate)) >= 0)
                {
                    goto Label_0049;
                }
                if (((uint) maxPertubation) >= 0)
                {
                    goto Label_0013;
                }
            }
        }

        public void MutateWeights(double mutateRate, double probNewMutate, double maxPertubation)
        {
            using (List<IGene>.Enumerator enumerator = this.linksChromosome.Genes.GetEnumerator())
            {
                IGene gene;
                NEATLinkGene gene2;
                goto Label_0043;
            Label_0013:
                gene2.Weight += RangeRandomizer.Randomize(-1.0, 1.0) * maxPertubation;
                goto Label_0043;
            Label_003B:
                if (ThreadSafeRandom.NextDouble() < mutateRate)
                {
                    goto Label_006D;
                }
            Label_0043:
                if (enumerator.MoveNext())
                {
                    goto Label_0098;
                }
                goto Label_0095;
            Label_004E:
                gene2.Weight = RangeRandomizer.Randomize(-1.0, 1.0);
                goto Label_0043;
            Label_006D:
                if (ThreadSafeRandom.NextDouble() < probNewMutate)
                {
                    goto Label_004E;
                }
                if ((((uint) probNewMutate) | 1) == 0)
                {
                    goto Label_0098;
                }
                if (0 != 0)
                {
                    goto Label_004E;
                }
                goto Label_0013;
            Label_0095:
                if (0 == 0)
                {
                    return;
                }
            Label_0098:
                gene = enumerator.Current;
                gene2 = (NEATLinkGene) gene;
                goto Label_003B;
            }
        }

        public void SortGenes()
        {
            this.linksChromosome.Genes.Sort();
        }

        public int InputCount
        {
            get
            {
                return this.inputCount;
            }
            set
            {
                this.inputCount = value;
            }
        }

        public Chromosome Links
        {
            get
            {
                return this.linksChromosome;
            }
        }

        public Chromosome LinksChromosome
        {
            get
            {
                return this.linksChromosome;
            }
            set
            {
                this.linksChromosome = value;
            }
        }

        public int NetworkDepth
        {
            get
            {
                return this.networkDepth;
            }
            set
            {
                this.networkDepth = value;
            }
        }

        public Chromosome Neurons
        {
            get
            {
                return this.neuronsChromosome;
            }
        }

        public Chromosome NeuronsChromosome
        {
            get
            {
                return this.neuronsChromosome;
            }
            set
            {
                this.neuronsChromosome = value;
            }
        }

        public int NumGenes
        {
            get
            {
                return this.linksChromosome.Size();
            }
        }

        public int OutputCount
        {
            get
            {
                return this.outputCount;
            }
            set
            {
                this.outputCount = value;
            }
        }

        public long SpeciesID
        {
            get
            {
                return this.speciesID;
            }
            set
            {
                this.speciesID = value;
            }
        }
    }
}

