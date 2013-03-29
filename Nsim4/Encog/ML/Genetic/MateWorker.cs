namespace Encog.ML.Genetic
{
    using Encog.ML.Genetic.Genome;
    using Encog.Util.Concurrency;
    using System;

    public class MateWorker : IEngineTask
    {
        private readonly IGenome _x405fa6c967740d37;
        private readonly IGenome _x76ad8378bdb66d70;
        private readonly IGenome _xa7eb051c3211c54a;
        private readonly IGenome _xdb6cbc417cc4e418;

        public MateWorker(IGenome theMother, IGenome theFather, IGenome theChild1, IGenome theChild2)
        {
            this._x405fa6c967740d37 = theMother;
            this._xdb6cbc417cc4e418 = theFather;
            this._xa7eb051c3211c54a = theChild1;
            this._x76ad8378bdb66d70 = theChild2;
        }

        public void Run()
        {
            this._x405fa6c967740d37.Mate(this._xdb6cbc417cc4e418, this._xa7eb051c3211c54a, this._x76ad8378bdb66d70);
        }
    }
}

