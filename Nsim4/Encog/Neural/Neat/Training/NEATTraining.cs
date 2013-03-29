namespace Encog.Neural.NEAT.Training
{
    using Encog.MathUtil;
    using Encog.MathUtil.Randomize;
    using Encog.ML;
    using Encog.ML.Data;
    using Encog.ML.Genetic;
    using Encog.ML.Genetic.Genome;
    using Encog.ML.Genetic.Population;
    using Encog.ML.Genetic.Species;
    using Encog.ML.Train;
    using Encog.ML.Train.Strategy;
    using Encog.Neural.NEAT;
    using Encog.Neural.Networks.Training;
    using Encog.Neural.Networks.Training.Genetic;
    using Encog.Neural.Networks.Training.Propagation;
    using System;
    using System.Collections.Generic;

    public class NEATTraining : GeneticAlgorithm, IMLTrain
    {
        private double x214332e2bd2e8ae1;
        private int x340c2bbd00cd3fa4;
        private double x411ff254761a2325;
        private readonly int x43f451310e815b76;
        private int x47b4ed2c32cb276e;
        private int x64ee8c19c861fa58;
        private double x67e8029e782709f0;
        private double x68e0847485ce0c21;
        private bool x6901bf75a54f58c6;
        private double x7a6edccccc229234;
        private double x8a503d42183ff26d;
        private readonly int x98cf41c6b0eaf6ab;
        private double xa4a074c49c97739c;
        private double xaceecf9c91c04e3f;
        private double xc0e107052d52ecd1;
        private NEATNetwork xc98330799092ad50;
        private double xd3f94467320a5684;
        private int xd7944ba63721a56b;
        private double xd9d3bb742c7a307b;
        private int xe44426390f1f3741;
        private double xe5ff50155887c0e7;
        private double xe6c7b0462e12d2ff;
        private double xf52a69d338e65c0f;
        private int xfca9d4aed1b3cd4b;

        public NEATTraining(ICalculateScore calculateScore, IPopulation population)
        {
            NEATGenome genome;
            this.xd9d3bb742c7a307b = 0.1;
            this.x67e8029e782709f0 = 0.07;
            this.xe6c7b0462e12d2ff = 0.04;
            this.xd3f94467320a5684 = 0.05;
            this.x8a503d42183ff26d = 0.26;
            this.xa4a074c49c97739c = 0.7;
            this.xf52a69d338e65c0f = 0.1;
            this.x214332e2bd2e8ae1 = 100.0;
            this.x7a6edccccc229234 = 0.5;
            this.x68e0847485ce0c21 = 0.2;
            this.xd7944ba63721a56b = 5;
            this.xfca9d4aed1b3cd4b = 15;
            this.xe44426390f1f3741 = 5;
            this.x340c2bbd00cd3fa4 = 5;
            this.xe5ff50155887c0e7 = 0.1;
            goto Label_0102;
            if (0 == 0)
            {
                goto Label_010B;
            }
        Label_0102:
            if (population.Size() < 1)
            {
                throw new TrainingError("Population can not be empty.");
            }
        Label_010B:
            genome = (NEATGenome) population.Genomes[0];
            base.CalculateScore = new GeneticScoreAdapter(calculateScore);
            base.Comparator = new GenomeComparator(base.CalculateScore);
            base.Population = population;
            this.x43f451310e815b76 = genome.InputCount;
            this.x98cf41c6b0eaf6ab = genome.OutputCount;
            this.xd586e0c16bdae7fc();
        }

        public NEATTraining(ICalculateScore calculateScore, int inputCount, int outputCount, int populationSize)
        {
            this.xd9d3bb742c7a307b = 0.1;
            this.x67e8029e782709f0 = 0.07;
            this.xe6c7b0462e12d2ff = 0.04;
            this.xd3f94467320a5684 = 0.05;
            this.x8a503d42183ff26d = 0.26;
            this.xa4a074c49c97739c = 0.7;
            this.xf52a69d338e65c0f = 0.1;
            this.x214332e2bd2e8ae1 = 100.0;
            this.x7a6edccccc229234 = 0.5;
            this.x68e0847485ce0c21 = 0.2;
            this.xd7944ba63721a56b = 5;
            this.xfca9d4aed1b3cd4b = 15;
            this.xe44426390f1f3741 = 5;
            this.x340c2bbd00cd3fa4 = 5;
            this.xe5ff50155887c0e7 = 0.1;
            this.x43f451310e815b76 = inputCount;
            this.x98cf41c6b0eaf6ab = outputCount;
            base.CalculateScore = new GeneticScoreAdapter(calculateScore);
            base.Comparator = new GenomeComparator(base.CalculateScore);
            if ((((uint) inputCount) & 0) == 0)
            {
                do
                {
                    base.Population = new NEATPopulation(inputCount, outputCount, populationSize);
                    this.xd586e0c16bdae7fc();
                }
                while (((uint) inputCount) > uint.MaxValue);
            }
        }

        public void AddNeuronID(long nodeID, IList<long> vec)
        {
            int num = 0;
        Label_0004:
            if (num < vec.Count)
            {
                if (vec[num] == nodeID)
                {
                    return;
                }
            }
            else if ((((uint) nodeID) - ((uint) num)) >= 0)
            {
                vec.Add(nodeID);
                if ((((uint) num) - ((uint) num)) <= uint.MaxValue)
                {
                    return;
                }
                goto Label_0004;
            }
            num++;
            if (0 != 0)
            {
            }
            goto Label_0004;
        }

        public void AddStrategy(IStrategy strategy)
        {
            throw new TrainingError("Strategies are not supported by this training method.");
        }

        public void AdjustCompatibilityThreshold()
        {
            if (this.x64ee8c19c861fa58 >= 1)
            {
                double num = 0.01;
                if (base.Population.Species.Count <= this.x64ee8c19c861fa58)
                {
                    if (base.Population.Species.Count < 2)
                    {
                        this.x8a503d42183ff26d -= num;
                    }
                }
                else
                {
                    this.x8a503d42183ff26d += num;
                }
            }
        }

        public void AdjustSpeciesScore()
        {
            foreach (ISpecies species in base.Population.Species)
            {
                using (IEnumerator<IGenome> enumerator2 = species.Members.GetEnumerator())
                {
                    IGenome genome;
                    double score;
                    double num2;
                    goto Label_0035;
                Label_002E:
                    genome.AdjustedScore = num2;
                Label_0035:
                    if (enumerator2.MoveNext())
                    {
                        goto Label_00D6;
                    }
                    if ((((uint) num2) - ((uint) score)) <= uint.MaxValue)
                    {
                        continue;
                    }
                    if ((((uint) num2) - ((uint) num2)) <= uint.MaxValue)
                    {
                        goto Label_00D6;
                    }
                Label_0090:
                    while (species.Age > base.Population.OldAgeThreshold)
                    {
                        score = base.Comparator.ApplyPenalty(score, base.Population.OldAgePenalty);
                        break;
                    }
                    num2 = score / ((double) species.Members.Count);
                Label_00B2:
                    if (0x7fffffff == 0)
                    {
                        continue;
                    }
                    goto Label_013D;
                Label_00C1:
                    if (species.Age < base.Population.YoungBonusAgeThreshold)
                    {
                        goto Label_0100;
                    }
                    goto Label_0090;
                Label_00D6:
                    genome = enumerator2.Current;
                    score = genome.Score;
                    if (0 == 0)
                    {
                        goto Label_00C1;
                    }
                    if ((((uint) score) - ((uint) num2)) > uint.MaxValue)
                    {
                        goto Label_00B2;
                    }
                Label_0100:
                    score = base.Comparator.ApplyBonus(score, base.Population.YoungScoreBonus);
                    if ((((uint) num2) - ((uint) num2)) <= uint.MaxValue)
                    {
                        goto Label_0090;
                    }
                    goto Label_00C1;
                Label_013D:
                    if ((((uint) num2) - ((uint) score)) >= 0)
                    {
                        goto Label_002E;
                    }
                }
            }
        }

        public NEATGenome Crossover(NEATGenome mom, NEATGenome dad)
        {
            x47361738465134f2 xf;
            Chromosome chromosome;
            Chromosome chromosome2;
            List<long> list;
            int num;
            int num2;
            NEATLinkGene gene;
            NEATLinkGene gene2;
            NEATLinkGene gene3;
            int num3;
            NEATGenome genome;
            if (mom.Score != dad.Score)
            {
                while (base.Comparator.IsBetterThan(mom.Score, dad.Score))
                {
                    xf = x47361738465134f2.x431cb293a9d996e8;
                    if (((uint) num3) >= 0)
                    {
                        if ((((uint) num3) & 0) == 0)
                        {
                            goto Label_03BA;
                        }
                        goto Label_0399;
                    }
                    if ((((uint) num) & 0) == 0)
                    {
                        goto Label_0478;
                    }
                }
                xf = x47361738465134f2.x86f3d3d96a9a0f93;
                goto Label_03BA;
            }
            goto Label_0478;
        Label_002E:
            genome = new NEATGenome(base.Population.AssignGenomeID(), chromosome, chromosome2, mom.InputCount, mom.OutputCount);
            genome.GA = this;
            if (15 != 0)
            {
                if (0 != 0)
                {
                    goto Label_031C;
                }
                genome.Population = base.Population;
                if ((((uint) num3) & 0) == 0)
                {
                    return genome;
                }
                goto Label_02C3;
            }
            goto Label_00B2;
        Label_0071:
            num3++;
        Label_0077:
            if (num3 < list.Count)
            {
                chromosome.Add(this.Innovations.CreateNeuronFromID(list[num3]));
                goto Label_0071;
            }
            goto Label_002E;
        Label_00B2:
            this.AddNeuronID((long) gene3.FromNeuronID, list);
            this.AddNeuronID((long) gene3.ToNeuronID, list);
        Label_00D0:
            if ((num < mom.NumGenes) || (num2 < dad.NumGenes))
            {
                if (num >= mom.NumGenes)
                {
                    gene = null;
                }
                else
                {
                    gene = (NEATLinkGene) mom.Links.Get(num);
                }
                goto Label_034F;
            }
            list.Sort();
            num3 = 0;
            if ((((uint) num2) + ((uint) num)) > uint.MaxValue)
            {
                goto Label_0071;
            }
            if (0 != 0)
            {
                goto Label_034F;
            }
            goto Label_0077;
        Label_0160:
            chromosome2.Add(gene3);
            goto Label_00B2;
        Label_016D:
            if (chromosome2.Size() == 0)
            {
                goto Label_0160;
            }
            if ((0 != 0) || (((NEATLinkGene) chromosome2.Get(chromosome2.Size() - 1)).InnovationId != gene3.InnovationId))
            {
                chromosome2.Add(gene3);
            }
            goto Label_00B2;
        Label_01C8:
            num++;
            if (((uint) num) <= uint.MaxValue)
            {
                if (((uint) num3) > uint.MaxValue)
                {
                    goto Label_002E;
                }
                if ((((uint) num2) | 4) == 0)
                {
                    goto Label_025D;
                }
                num2++;
                goto Label_016D;
            }
        Label_01E0:
            if ((((uint) num2) | 2) != 0)
            {
                if ((((uint) num3) + ((uint) num3)) <= uint.MaxValue)
                {
                    goto Label_016D;
                }
                goto Label_0160;
            }
            if (-2147483648 != 0)
            {
                goto Label_0234;
            }
            if ((((uint) num) + ((uint) num3)) < 0)
            {
                goto Label_024D;
            }
        Label_0222:
            while (ThreadSafeRandom.NextDouble() < 0.5)
            {
                gene3 = gene;
                goto Label_01C8;
            }
            gene3 = gene2;
            goto Label_01C8;
        Label_0234:
            gene3 = gene2;
        Label_0238:
            num2++;
            goto Label_016D;
        Label_024D:
            if (gene.InnovationId < gene2.InnovationId)
            {
                if (xf == x47361738465134f2.x431cb293a9d996e8)
                {
                    gene3 = gene;
                }
                num++;
                goto Label_016D;
            }
        Label_025D:
            if (gene2.InnovationId >= gene.InnovationId)
            {
                if (gene2.InnovationId == gene.InnovationId)
                {
                    goto Label_0222;
                }
                goto Label_01E0;
            }
            if ((((uint) num2) + ((uint) num)) > uint.MaxValue)
            {
                goto Label_024D;
            }
            if (xf != x47361738465134f2.x86f3d3d96a9a0f93)
            {
                goto Label_0238;
            }
            goto Label_0234;
        Label_02C3:
            if (gene2 == null)
            {
                if (gene != null)
                {
                    if (xf == x47361738465134f2.x431cb293a9d996e8)
                    {
                        gene3 = gene;
                        if ((((uint) num2) + ((uint) num)) > uint.MaxValue)
                        {
                            goto Label_03BA;
                        }
                    }
                    num++;
                    goto Label_016D;
                }
                if ((((uint) num3) | 0xfffffffe) != 0)
                {
                }
            }
            goto Label_024D;
        Label_031C:
            if (gene2 == null)
            {
                goto Label_02C3;
            }
            if (xf == x47361738465134f2.x86f3d3d96a9a0f93)
            {
                if (1 == 0)
                {
                    goto Label_01C8;
                }
                gene3 = gene2;
            }
            num2++;
            goto Label_016D;
        Label_034F:
            if (num2 < dad.NumGenes)
            {
                gene2 = (NEATLinkGene) dad.Links.Get(num2);
            }
            else
            {
                gene2 = null;
            }
            if (gene != null)
            {
                goto Label_02C3;
            }
            goto Label_031C;
        Label_0399:
            if ((((uint) num) & 0) != 0)
            {
                goto Label_00B2;
            }
            gene3 = null;
            goto Label_00D0;
        Label_03BA:
            chromosome = new Chromosome();
            chromosome2 = new Chromosome();
            list = new List<long>();
            num = 0;
            num2 = 0;
            if (0 == 0)
            {
                goto Label_0399;
            }
        Label_0478:
            if (mom.NumGenes != dad.NumGenes)
            {
                if (mom.NumGenes < dad.NumGenes)
                {
                    xf = x47361738465134f2.x431cb293a9d996e8;
                }
                else
                {
                    xf = x47361738465134f2.x86f3d3d96a9a0f93;
                }
            }
            else if (((((uint) num) - ((uint) num3)) >= 0) && (ThreadSafeRandom.NextDouble() <= 0.0))
            {
                if ((((uint) num3) + ((uint) num2)) <= uint.MaxValue)
                {
                    xf = x47361738465134f2.x86f3d3d96a9a0f93;
                }
            }
            else
            {
                xf = x47361738465134f2.x431cb293a9d996e8;
            }
            goto Label_03BA;
        }

        public void FinishTraining()
        {
        }

        public override void Iteration()
        {
            IList<NEATGenome> list;
            int num;
            int num2;
            bool flag;
            int num3;
            this.x47b4ed2c32cb276e++;
            goto Label_00D0;
        Label_0024:
            if (list.Count < base.Population.Size())
            {
                goto Label_04AD;
            }
            if ((((uint) num2) | 1) != 0)
            {
                base.Population.Clear();
            }
            foreach (NEATGenome genome4 in list)
            {
                base.Population.Add(genome4);
            }
            this.ResetAndKill();
            if ((((uint) num) - ((uint) flag)) <= uint.MaxValue)
            {
                this.SortAndRecord();
                this.SpeciateAndCalculateSpawnLevels();
            }
            if ((((uint) num2) - ((uint) num3)) >= 0)
            {
                return;
            }
        Label_00D0:
            list = new List<NEATGenome>();
            num = 0;
            using (IEnumerator<ISpecies> enumerator = base.Population.Species.GetEnumerator())
            {
                ISpecies species;
                NEATGenome genome;
                NEATGenome genome2;
                NEATGenome genome3;
                goto Label_00FD;
            Label_00EC:
                if (num < base.Population.Size())
                {
                    goto Label_0485;
                }
            Label_00FD:
                if (enumerator.MoveNext())
                {
                    goto Label_0468;
                }
                goto Label_040A;
            Label_010D:
                if (num == base.Population.Size())
                {
                    goto Label_0144;
                }
            Label_011B:
                if (num2-- > 0)
                {
                    goto Label_0441;
                }
                goto Label_00FD;
            Label_012C:
                if (genome != null)
                {
                    goto Label_0182;
                }
                if (((uint) num) >= 0)
                {
                    goto Label_011B;
                }
                goto Label_040A;
            Label_0144:
                num2 = 0;
                goto Label_011B;
            Label_014D:
                if (0 == 0)
                {
                    goto Label_010D;
                }
                goto Label_01FA;
            Label_0152:
                if (0x7fffffff == 0)
                {
                    goto Label_03D9;
                }
                if ((((uint) num2) & 0) != 0)
                {
                    goto Label_0266;
                }
                num++;
                goto Label_014D;
            Label_0179:
                if (genome != null)
                {
                    goto Label_0246;
                }
                goto Label_012C;
            Label_0182:
                genome.SortGenes();
                list.Add(genome);
                goto Label_0152;
            Label_0197:
                genome.AddNeuron(this.xe6c7b0462e12d2ff, this.x340c2bbd00cd3fa4);
            Label_01AA:
                genome.AddLink(this.x67e8029e782709f0, this.xd3f94467320a5684, this.xe44426390f1f3741, this.xd7944ba63721a56b);
                genome.MutateWeights(this.x68e0847485ce0c21, this.xe5ff50155887c0e7, this.x7a6edccccc229234);
                genome.MutateActivationResponse(this.xd9d3bb742c7a307b, this.xf52a69d338e65c0f);
                goto Label_012C;
            Label_01FA:
                if ((((uint) num3) - ((uint) num2)) >= 0)
                {
                    goto Label_0144;
                }
            Label_0212:
                if (genome.Neurons.Size() >= this.x214332e2bd2e8ae1)
                {
                    goto Label_01AA;
                }
                goto Label_0197;
            Label_0231:
                if (genome2.GenomeID != genome3.GenomeID)
                {
                    goto Label_0266;
                }
                goto Label_0179;
            Label_0246:
                genome.GenomeID = base.Population.AssignGenomeID();
                goto Label_0212;
            Label_0266:
                genome = this.Crossover(genome2, genome3);
                goto Label_0179;
            Label_0277:
                genome = new NEATGenome(genome2);
                goto Label_0179;
            Label_0285:
                if ((((uint) flag) + ((uint) num)) < 0)
                {
                    goto Label_0492;
                }
            Label_02A0:
                if (genome2.GenomeID == genome3.GenomeID)
                {
                    goto Label_0334;
                }
                if (((uint) num) >= 0)
                {
                    goto Label_0231;
                }
                if ((((uint) num) + ((uint) num)) > uint.MaxValue)
                {
                    goto Label_0197;
                }
                if ((((uint) num3) | 0xfffffffe) == 0)
                {
                    goto Label_02A0;
                }
            Label_02FE:
                if ((((uint) flag) & 0) != 0)
                {
                    goto Label_02A0;
                }
                if ((((uint) flag) + ((uint) flag)) >= 0)
                {
                    goto Label_0231;
                }
                goto Label_03F5;
            Label_0334:
                if (num3-- <= 0)
                {
                    goto Label_02FE;
                }
                genome3 = (NEATGenome) species.ChooseParent();
                if ((((uint) num) - ((uint) num2)) >= 0)
                {
                    goto Label_03AA;
                }
            Label_036A:
                if (species.Members.Count == 1)
                {
                    goto Label_03D9;
                }
                genome2 = (NEATGenome) species.ChooseParent();
                if (ThreadSafeRandom.NextDouble() >= this.xa4a074c49c97739c)
                {
                    goto Label_0277;
                }
                genome3 = (NEATGenome) species.ChooseParent();
                num3 = 5;
                goto Label_02A0;
            Label_03AA:
                if ((((uint) num) - ((uint) flag)) >= 0)
                {
                    goto Label_02A0;
                }
            Label_03C4:
                genome = (NEATGenome) species.Leader;
                flag = true;
                goto Label_012C;
            Label_03D9:
                genome = new NEATGenome((NEATGenome) species.ChooseParent());
                goto Label_0179;
            Label_03F5:
                if (((uint) num) >= 0)
                {
                    goto Label_0231;
                }
            Label_040A:
                if (((uint) num) >= 0)
                {
                    goto Label_0024;
                }
                goto Label_044D;
            Label_0421:
                if ((((uint) num) - ((uint) flag)) > uint.MaxValue)
                {
                    goto Label_0144;
                }
                goto Label_011B;
            Label_0441:
                genome = null;
                if (flag)
                {
                    goto Label_036A;
                }
                goto Label_03C4;
            Label_044D:
                if ((((uint) num3) - ((uint) flag)) > uint.MaxValue)
                {
                    goto Label_0285;
                }
            Label_0468:
                species = enumerator.Current;
                if (((uint) num2) >= 0)
                {
                    goto Label_00EC;
                }
            Label_0485:
                num2 = (int) Math.Round(species.NumToSpawn);
            Label_0492:
                flag = false;
                goto Label_0421;
            }
        Label_04AD:
            list.Add(this.TournamentSelection(base.Population.Size() / 5));
            goto Label_0024;
        }

        public void Iteration(int count)
        {
            for (int i = 0; i < count; i++)
            {
                this.Iteration();
            }
        }

        public TrainingContinuation Pause()
        {
            return null;
        }

        public void ResetAndKill()
        {
            ISpecies[] speciesArray;
            int num;
            ISpecies species;
            ISpecies[] speciesArray2;
            int num2;
            this.xc0e107052d52ecd1 = 0.0;
            goto Label_0158;
        Label_0016:
            if ((species.GensNoImprovement > this.xfca9d4aed1b3cd4b) && base.Comparator.IsBetterThan(this.x411ff254761a2325, species.BestScore))
            {
                base.Population.Species.Remove(species);
                if (((uint) num) < 0)
                {
                    goto Label_00BE;
                }
            }
            num2++;
        Label_002A:
            if (num2 < speciesArray2.Length)
            {
                object obj2 = speciesArray2[num2];
                if ((((uint) num) & 0) != 0)
                {
                    goto Label_00DA;
                }
                if ((((uint) num2) - ((uint) num2)) >= 0)
                {
                    ((ISpecies) obj2).Purge();
                    if (0 == 0)
                    {
                        goto Label_0016;
                    }
                }
            }
            else if (0xff == 0)
            {
                goto Label_0016;
            }
        Label_00BE:
            if ((((uint) num2) & 0) == 0)
            {
                return;
            }
            goto Label_0158;
        Label_00DA:
            if (num < base.Population.Species.Count)
            {
                do
                {
                    speciesArray[num] = base.Population.Species[num];
                }
                while ((((uint) num) - ((uint) num)) < 0);
            }
            else
            {
                speciesArray2 = speciesArray;
                num2 = 0;
                goto Label_002A;
            }
        Label_0138:
            num++;
            goto Label_00DA;
        Label_0158:
            this.xaceecf9c91c04e3f = 0.0;
            speciesArray = new ISpecies[base.Population.Species.Count];
            num = 0;
            if (((uint) num2) > uint.MaxValue)
            {
                goto Label_0138;
            }
            goto Label_00DA;
        }

        public void Resume(TrainingContinuation state)
        {
        }

        public void SortAndRecord()
        {
            foreach (IGenome genome in base.Population.Genomes)
            {
                genome.Decode();
                base.PerformCalculateScore(genome);
            }
            while (true)
            {
                base.Population.Sort();
                do
                {
                    IGenome best = base.Population.Best;
                    double score = best.Score;
                    if (base.Comparator.IsBetterThan(score, this.x411ff254761a2325))
                    {
                        this.x411ff254761a2325 = score;
                        this.xc98330799092ad50 = (NEATNetwork) best.Organism;
                    }
                    this.x411ff254761a2325 = base.Comparator.BestScore(this.Error, this.x411ff254761a2325);
                }
                while (0x7fffffff == 0);
                if (0 == 0)
                {
                    return;
                }
            }
        }

        public void SpeciateAndCalculateSpawnLevels()
        {
            bool flag;
            this.AdjustCompatibilityThreshold();
            using (IEnumerator<IGenome> enumerator = base.Population.Genomes.GetEnumerator())
            {
                NEATGenome genome2;
                goto Label_013F;
            Label_0101:
                base.Population.Species.Add(new BasicSpecies(base.Population, genome2, base.Population.AssignSpeciesID()));
                goto Label_013F;
            Label_012A:
                if (!flag)
                {
                    goto Label_0101;
                }
                if (((uint) flag) <= uint.MaxValue)
                {
                }
            Label_013F:
                if (enumerator.MoveNext())
                {
                    IGenome current = enumerator.Current;
                    genome2 = (NEATGenome) current;
                    flag = false;
                    using (IEnumerator<ISpecies> enumerator2 = base.Population.Species.GetEnumerator())
                    {
                        ISpecies species;
                        double compatibilityScore;
                    Label_0172:
                        if (enumerator2.MoveNext())
                        {
                            goto Label_019F;
                        }
                        goto Label_012A;
                    Label_017D:
                        if (compatibilityScore > this.x8a503d42183ff26d)
                        {
                            goto Label_0172;
                        }
                        base.AddSpeciesMember(species, genome2);
                        genome2.SpeciesID = species.SpeciesID;
                        flag = true;
                        goto Label_012A;
                    Label_019F:
                        species = enumerator2.Current;
                        compatibilityScore = genome2.GetCompatibilityScore((NEATGenome) species.Leader);
                        goto Label_017D;
                    }
                }
            }
            this.AdjustSpeciesScore();
            foreach (IGenome genome3 in base.Population.Genomes)
            {
                NEATGenome genome4 = (NEATGenome) genome3;
                this.xc0e107052d52ecd1 += genome4.AdjustedScore;
            }
            this.xaceecf9c91c04e3f = this.xc0e107052d52ecd1 / ((double) base.Population.Size());
            foreach (IGenome genome5 in base.Population.Genomes)
            {
                NEATGenome genome6;
                double num2;
                do
                {
                    genome6 = (NEATGenome) genome5;
                }
                while ((((uint) num2) - ((uint) flag)) > uint.MaxValue);
                num2 = genome6.AdjustedScore / this.xaceecf9c91c04e3f;
                genome6.AmountToSpawn = num2;
            }
            foreach (ISpecies species2 in base.Population.Species)
            {
                species2.CalculateSpawnAmount();
            }
        }

        public NEATGenome TournamentSelection(int numComparisons)
        {
            int num2;
            int num3;
            int num4;
            double num = 0.0;
            if (0 == 0)
            {
                goto Label_0051;
            }
        Label_000D:
            num = base.Population.Get(num4).Score;
        Label_001F:
            num3++;
        Label_0023:
            if ((num3 < numComparisons) || (((uint) numComparisons) < 0))
            {
                num4 = (int) RangeRandomizer.Randomize(0.0, (double) (base.Population.Size() - 1));
                if (base.Population.Get(num4).Score <= num)
                {
                    goto Label_001F;
                }
                num2 = num4;
                goto Label_000D;
            }
            if ((((uint) numComparisons) | 1) != 0)
            {
                return (NEATGenome) base.Population.Get(num2);
            }
        Label_0051:
            num2 = 0;
            num3 = 0;
            goto Label_0023;
        }

        private void xd586e0c16bdae7fc()
        {
            if (base.CalculateScore.ShouldMinimize)
            {
                if (0 == 0)
                {
                    this.x411ff254761a2325 = double.MaxValue;
                    goto Label_0035;
                }
                if (0 == 0)
                {
                    goto Label_0035;
                }
            }
            this.x411ff254761a2325 = double.MinValue;
        Label_0035:
            using (IEnumerator<IGenome> enumerator = base.Population.Genomes.GetEnumerator())
            {
                IGenome genome;
                NEATGenome genome2;
                goto Label_004B;
            Label_0048:
                if (0 != 0)
                {
                    goto Label_006E;
                }
            Label_004B:
                if (enumerator.MoveNext())
                {
                    goto Label_00CF;
                }
                if (0 == 0)
                {
                    goto Label_00C8;
                }
                if (8 != 0)
                {
                    goto Label_00B9;
                }
                goto Label_006E;
            Label_0065:
                genome2.GA = this;
                goto Label_0048;
            Label_006E:
                if (2 == 0)
                {
                    goto Label_00B9;
                }
            Label_0075:
                genome2 = (NEATGenome) genome;
                if (genome2.InputCount != this.x43f451310e815b76)
                {
                    goto Label_0098;
                }
            Label_008A:
                if (genome2.OutputCount == this.x98cf41c6b0eaf6ab)
                {
                    goto Label_0065;
                }
            Label_0098:
                throw new TrainingError("All NEATGenome's must have the same input and output sizes as the base network.");
                if (0 != 0)
                {
                    goto Label_008A;
                }
                goto Label_0065;
            Label_00B9:
                if (!(genome is NEATGenome))
                {
                    throw new TrainingError("Population can only contain objects of NEATGenome.");
                }
                goto Label_0075;
            Label_00C8:
                if (1 != 0)
                {
                    goto Label_00E9;
                }
            Label_00CF:
                genome = enumerator.Current;
                if (-2147483648 != 0)
                {
                    goto Label_00B9;
                }
            }
        Label_00E9:
            base.Population.Claim(this);
            this.ResetAndKill();
            this.SortAndRecord();
            if ((-1 == 0) || (-1 != 0))
            {
                this.SpeciateAndCalculateSpawnLevels();
            }
        }

        public bool CanContinue
        {
            get
            {
                return false;
            }
        }

        public double Error
        {
            get
            {
                return this.x411ff254761a2325;
            }
            set
            {
                this.x411ff254761a2325 = value;
            }
        }

        public TrainingImplementationType ImplementationType
        {
            get
            {
                return TrainingImplementationType.Iterative;
            }
        }

        public NEATInnovationList Innovations
        {
            get
            {
                return (NEATInnovationList) base.Population.Innovations;
            }
        }

        public int InputCount
        {
            get
            {
                return this.x43f451310e815b76;
            }
        }

        public int IterationNumber
        {
            get
            {
                return this.x47b4ed2c32cb276e;
            }
            set
            {
                this.x47b4ed2c32cb276e = value;
            }
        }

        public IMLMethod Method
        {
            get
            {
                return this.xc98330799092ad50;
            }
        }

        public int OutputCount
        {
            get
            {
                return this.x98cf41c6b0eaf6ab;
            }
        }

        public double ParamActivationMutationRate
        {
            get
            {
                return this.xd9d3bb742c7a307b;
            }
            set
            {
                this.xd9d3bb742c7a307b = value;
            }
        }

        public double ParamChanceAddLink
        {
            get
            {
                return this.x67e8029e782709f0;
            }
            set
            {
                this.x67e8029e782709f0 = value;
            }
        }

        public double ParamChanceAddNode
        {
            get
            {
                return this.xe6c7b0462e12d2ff;
            }
            set
            {
                this.xe6c7b0462e12d2ff = value;
            }
        }

        public double ParamChanceAddRecurrentLink
        {
            get
            {
                return this.xd3f94467320a5684;
            }
            set
            {
                this.xd3f94467320a5684 = value;
            }
        }

        public double ParamCompatibilityThreshold
        {
            get
            {
                return this.x8a503d42183ff26d;
            }
            set
            {
                this.x8a503d42183ff26d = value;
            }
        }

        public double ParamCrossoverRate
        {
            get
            {
                return this.xa4a074c49c97739c;
            }
            set
            {
                this.xa4a074c49c97739c = value;
            }
        }

        public double ParamMaxActivationPerturbation
        {
            get
            {
                return this.xf52a69d338e65c0f;
            }
            set
            {
                this.xf52a69d338e65c0f = value;
            }
        }

        public int ParamMaxNumberOfSpecies
        {
            get
            {
                return this.x64ee8c19c861fa58;
            }
            set
            {
                this.x64ee8c19c861fa58 = value;
            }
        }

        public double ParamMaxPermittedNeurons
        {
            get
            {
                return this.x214332e2bd2e8ae1;
            }
            set
            {
                this.x214332e2bd2e8ae1 = value;
            }
        }

        public double ParamMaxWeightPerturbation
        {
            get
            {
                return this.x7a6edccccc229234;
            }
            set
            {
                this.x7a6edccccc229234 = value;
            }
        }

        public double ParamMutationRate
        {
            get
            {
                return this.x68e0847485ce0c21;
            }
            set
            {
                this.x68e0847485ce0c21 = value;
            }
        }

        public int ParamNumAddLinkAttempts
        {
            get
            {
                return this.xd7944ba63721a56b;
            }
            set
            {
                this.xd7944ba63721a56b = value;
            }
        }

        public int ParamNumGensAllowedNoImprovement
        {
            get
            {
                return this.xfca9d4aed1b3cd4b;
            }
            set
            {
                this.xfca9d4aed1b3cd4b = value;
            }
        }

        public int ParamNumTrysToFindLoopedLink
        {
            get
            {
                return this.xe44426390f1f3741;
            }
            set
            {
                this.xe44426390f1f3741 = value;
            }
        }

        public int ParamNumTrysToFindOldLink
        {
            get
            {
                return this.x340c2bbd00cd3fa4;
            }
            set
            {
                this.x340c2bbd00cd3fa4 = value;
            }
        }

        public double ParamProbabilityWeightReplaced
        {
            get
            {
                return this.xe5ff50155887c0e7;
            }
            set
            {
                this.xe5ff50155887c0e7 = value;
            }
        }

        public bool Snapshot
        {
            get
            {
                return this.x6901bf75a54f58c6;
            }
            set
            {
                this.x6901bf75a54f58c6 = value;
            }
        }

        public IList<IStrategy> Strategies
        {
            get
            {
                return new List<IStrategy>();
            }
        }

        public IMLDataSet Training
        {
            get
            {
                return null;
            }
        }

        public bool TrainingDone
        {
            get
            {
                return false;
            }
        }
    }
}

