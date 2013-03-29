namespace Encog.ML.Genetic.Innovation
{
    using System;
    using System.Collections.Generic;

    [Serializable]
    public class BasicInnovationList : IInnovationList
    {
        private readonly IList<IInnovation> _list = new List<IInnovation>();

        public void Add(IInnovation innovation)
        {
            this._list.Add(innovation);
        }

        public IInnovation Get(int id)
        {
            return this._list[id];
        }

        public IList<IInnovation> Innovations
        {
            get
            {
                return this._list;
            }
        }
    }
}

