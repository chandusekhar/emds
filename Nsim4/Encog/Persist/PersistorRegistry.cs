namespace Encog.Persist
{
    using Encog.ML.SVM;
    using Encog.Neural.ART;
    using Encog.Neural.BAM;
    using Encog.Neural.CPN;
    using Encog.Neural.Neat;
    using Encog.Neural.NEAT;
    using Encog.Neural.Networks;
    using Encog.Neural.Networks.Training.Propagation;
    using Encog.Neural.Pnn;
    using Encog.Neural.Rbf;
    using Encog.Neural.SOM;
    using Encog.Neural.Thermal;
    using System;
    using System.Collections.Generic;

    public class PersistorRegistry
    {
        private readonly IDictionary<string, IEncogPersistor> _x12fedb3de1c57ea7;
        private static PersistorRegistry _x6ed4ed9ed59eb694;
        private readonly IDictionary<Type, IEncogPersistor> _x785cd8b1f9494d74;

        private PersistorRegistry()
        {
            if (1 != 0)
            {
                this._x12fedb3de1c57ea7 = new Dictionary<string, IEncogPersistor>();
                this._x785cd8b1f9494d74 = new Dictionary<Type, IEncogPersistor>();
                this.Add(new PersistSVM());
                this.Add(new PersistHopfield());
                this.Add(new PersistBoltzmann());
                this.Add(new PersistART1());
                this.Add(new PersistBAM());
                this.Add(new PersistBasicNetwork());
                this.Add(new PersistRBFNetwork());
                this.Add(new PersistSOM());
                if (0x7fffffff == 0)
                {
                    return;
                }
            }
            do
            {
                this.Add(new PersistNEATPopulation());
                do
                {
                    this.Add(new PersistNEATNetwork());
                    this.Add(new PersistBasicPNN());
                    this.Add(new PersistCPN());
                }
                while ((0 != 0) || (0 != 0));
                this.Add(new PersistTrainingContinuation());
            }
            while (0 != 0);
        }

        public void Add(IEncogPersistor persistor)
        {
            this._x12fedb3de1c57ea7[persistor.PersistClassString] = persistor;
            this._x785cd8b1f9494d74[persistor.NativeType] = persistor;
        }

        public IEncogPersistor GetPersistor(string name)
        {
            if (!this._x12fedb3de1c57ea7.ContainsKey(name))
            {
                return null;
            }
            return this._x12fedb3de1c57ea7[name];
        }

        public IEncogPersistor GetPersistor(Type clazz)
        {
            return this._x785cd8b1f9494d74[clazz];
        }

        public static PersistorRegistry Instance
        {
            get
            {
                return (_x6ed4ed9ed59eb694 ?? (_x6ed4ed9ed59eb694 = new PersistorRegistry()));
            }
        }
    }
}

