namespace Encog.ML.Genetic.Genes
{
    using System;

    public class CharGene : BasicGene
    {
        private char _xbcea506a33cf9111;

        public sealed override void Copy(IGene gene)
        {
            this._xbcea506a33cf9111 = ((CharGene) gene).Value;
        }

        public sealed override string ToString()
        {
            return (this._xbcea506a33cf9111);
        }

        public char Value
        {
            get
            {
                return this._xbcea506a33cf9111;
            }
            set
            {
                this._xbcea506a33cf9111 = value;
            }
        }
    }
}

