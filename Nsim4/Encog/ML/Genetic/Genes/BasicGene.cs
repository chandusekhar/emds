namespace Encog.ML.Genetic.Genes
{
    using System;

    [Serializable]
    public abstract class BasicGene : IGene, IComparable<IGene>
    {
        private bool _enabled = true;
        private long _id = -1L;
        private long _innovationId = -1L;

        protected BasicGene()
        {
        }

        public int CompareTo(IGene o)
        {
            return (int) (this.InnovationId - o.InnovationId);
        }

        public abstract void Copy(IGene gene);

        public bool Enabled
        {
            get
            {
                return this._enabled;
            }
            set
            {
                this._enabled = value;
            }
        }

        public long Id
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }

        public long InnovationId
        {
            get
            {
                return this._innovationId;
            }
            set
            {
                this._innovationId = value;
            }
        }
    }
}

