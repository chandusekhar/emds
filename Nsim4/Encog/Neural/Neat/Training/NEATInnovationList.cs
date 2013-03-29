namespace Encog.Neural.NEAT.Training
{
    using Encog.ML.Genetic.Genes;
    using Encog.ML.Genetic.Genome;
    using Encog.ML.Genetic.Innovation;
    using Encog.ML.Genetic.Population;
    using Encog.Neural.NEAT;
    using Encog.Neural.Neat.Training;
    using Encog.Neural.Networks.Training;
    using System;
    using System.Collections.Generic;

    [Serializable]
    public class NEATInnovationList : BasicInnovationList
    {
        private long nextNeuronID;
        private IPopulation population;

        public NEATInnovationList()
        {
            this.nextNeuronID = 0L;
        }

        public NEATInnovationList(IPopulation population_0, Chromosome links, Chromosome neurons)
        {
            this.nextNeuronID = 0L;
            this.population = population_0;
            foreach (IGene gene in neurons.Genes)
            {
                NEATNeuronGene neuronGene = (NEATNeuronGene) gene;
                NEATInnovation innovation = new NEATInnovation(neuronGene, population_0.AssignInnovationID(), this.AssignNeuronID());
                if (15 == 0)
                {
                    break;
                }
                base.Add(innovation);
            }
            foreach (IGene gene3 in links.Genes)
            {
                NEATLinkGene gene4 = (NEATLinkGene) gene3;
                NEATInnovation innovation2 = new NEATInnovation((long) gene4.FromNeuronID, (long) gene4.ToNeuronID, NEATInnovationType.NewLink, this.population.AssignInnovationID());
                base.Add(innovation2);
            }
        }

        private long AssignNeuronID()
        {
            long num;
            this.nextNeuronID = (num = this.nextNeuronID) + 1L;
            return num;
        }

        public NEATInnovation CheckInnovation(long ins0, long xout, NEATInnovationType type)
        {
            using (IEnumerator<IInnovation> enumerator = base.Innovations.GetEnumerator())
            {
                IInnovation innovation;
                NEATInnovation innovation2;
                goto Label_0020;
            Label_000E:
                if ((innovation2.FromNeuronID == ins0) && (innovation2.ToNeuronID == xout))
                {
                    goto Label_002E;
                }
            Label_0020:
                if (enumerator.MoveNext())
                {
                    goto Label_0053;
                }
                goto Label_0084;
            Label_002E:
                if (innovation2.InnovationType != type)
                {
                    goto Label_0020;
                }
                return innovation2;
            Label_0053:
                innovation = enumerator.Current;
                innovation2 = (NEATInnovation) innovation;
                if (((uint) xout) > uint.MaxValue)
                {
                    goto Label_0020;
                }
                goto Label_000E;
            }
        Label_0084:
            return null;
        }

        public NEATNeuronGene CreateNeuronFromID(long neuronID)
        {
            NEATNeuronGene gene = new NEATNeuronGene(NEATNeuronType.Hidden, 0L, 0.0, 0.0);
            using (IEnumerator<IInnovation> enumerator = base.Innovations.GetEnumerator())
            {
                IInnovation innovation;
                NEATInnovation innovation2;
                NEATNeuronGene gene2;
                goto Label_0054;
            Label_002A:
                gene2 = gene;
                if ((((uint) neuronID) - ((uint) neuronID)) > uint.MaxValue)
                {
                    goto Label_0088;
                }
                return gene2;
            Label_004B:
                if (innovation2.NeuronID == neuronID)
                {
                    goto Label_00B1;
                }
            Label_0054:
                if (enumerator.MoveNext())
                {
                    goto Label_0088;
                }
                goto Label_0085;
            Label_005F:
                gene.Id = innovation2.NeuronID;
                gene.SplitY = innovation2.SplitY;
                gene.SplitX = innovation2.SplitX;
                goto Label_002A;
            Label_0085:
                if (0 == 0)
                {
                    goto Label_00CE;
                }
            Label_0088:
                innovation = enumerator.Current;
                if ((((uint) neuronID) + ((uint) neuronID)) >= 0)
                {
                    innovation2 = (NEATInnovation) innovation;
                    goto Label_004B;
                }
            Label_00B1:
                gene.NeuronType = innovation2.NeuronType;
                if (0 == 0)
                {
                    goto Label_005F;
                }
            }
        Label_00CE:
            throw new TrainingError("Failed to find innovation for neuron: " + neuronID);
        }

        public void CreateNewInnovation(long ins0, long xout, NEATInnovationType type)
        {
            NEATInnovation innovation = new NEATInnovation(ins0, xout, type, this.population.AssignInnovationID());
            while (type == NEATInnovationType.NewNeuron)
            {
                innovation.NeuronID = this.AssignNeuronID();
                break;
            }
            base.Add(innovation);
        }

        public long CreateNewInnovation(long from, long to, NEATInnovationType innovationType, NEATNeuronType neuronType, double x, double y)
        {
            NEATInnovation innovation = new NEATInnovation(from, to, innovationType, this.population.AssignInnovationID(), neuronType, x, y);
            if (0 == 0)
            {
            }
            while (innovationType == NEATInnovationType.NewNeuron)
            {
                innovation.NeuronID = this.AssignNeuronID();
                break;
            }
            base.Add(innovation);
            return (this.nextNeuronID - 1L);
        }

        public NEATPopulation Population
        {
            set
            {
                this.population = value;
            }
        }
    }
}

