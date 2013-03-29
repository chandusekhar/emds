namespace Encog.ML.Genetic.Genes
{
    using System;

    public class DoubleGene : BasicGene
    {
        private double _xbcea506a33cf9111;

        public sealed override void Copy(IGene gene)
        {
            this._xbcea506a33cf9111 = ((DoubleGene) gene).Value;
        }

        public sealed override string ToString()
        {
            return (this._xbcea506a33cf9111);
        }

        public double Value
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

