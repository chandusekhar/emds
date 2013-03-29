namespace Encog.ML.Genetic.Genes
{
    using System;
    using System.Runtime.CompilerServices;

    public class IntegerGene : BasicGene
    {
        [CompilerGenerated]
        private int x2ce4340e980ebb2e;

        public sealed override void Copy(IGene gene)
        {
            this.Value = ((IntegerGene) gene).Value;
        }

        public sealed override bool Equals(object obj)
        {
            return ((obj is IntegerGene) && (((IntegerGene) obj).Value == this.Value));
        }

        public sealed override int GetHashCode()
        {
            return this.Value;
        }

        public sealed override string ToString()
        {
            return (this.Value);
        }

        public int Value
        {
            [CompilerGenerated]
            get
            {
                return this.x2ce4340e980ebb2e;
            }
            [CompilerGenerated]
            set
            {
                this.x2ce4340e980ebb2e = value;
            }
        }
    }
}

