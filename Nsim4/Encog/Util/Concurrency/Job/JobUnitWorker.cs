namespace Encog.Util.Concurrency.Job
{
    using Encog.Util.Concurrency;
    using System;

    public class JobUnitWorker : IEngineTask
    {
        private readonly JobUnitContext _x0f7b23d1c393aed9;

        public JobUnitWorker(JobUnitContext context)
        {
            this._x0f7b23d1c393aed9 = context;
        }

        public void Run()
        {
            this._x0f7b23d1c393aed9.Owner.PerformJobUnit(this._x0f7b23d1c393aed9);
        }
    }
}

