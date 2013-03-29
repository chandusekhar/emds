namespace Encog.Neural.Networks.Training.Propagation
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    [Serializable]
    public class TrainingContinuation
    {
        private readonly IDictionary<string, object> _contents = new Dictionary<string, object>();

        public object Get(string name)
        {
            return this._contents[name];
        }

        public void Put(string key, double[] list)
        {
            this._contents[key] = list;
        }

        public void Set(string name, object v)
        {
            this._contents[name] = v;
        }

        public IDictionary<string, object> Contents
        {
            get
            {
                return this._contents;
            }
        }

        public string TrainingType { get; set; }
    }
}

