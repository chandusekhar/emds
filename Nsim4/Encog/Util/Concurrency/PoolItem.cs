namespace Encog.Util.Concurrency
{
    using System;

    public class PoolItem
    {
        private readonly EngineConcurrency _x071bde1041617fce;
        private readonly IEngineTask _x801bd3a7d5412d70;
        private readonly TaskGroup _xe2c9497bf778cd2b;

        public PoolItem(EngineConcurrency owner, IEngineTask task, TaskGroup group)
        {
            this._x071bde1041617fce = owner;
            this._x801bd3a7d5412d70 = task;
            this._xe2c9497bf778cd2b = group;
        }

        public void ThreadPoolCallback(object threadContext)
        {
            try
            {
                this._x801bd3a7d5412d70.Run();
                this._x071bde1041617fce.x88dff5165154bb1d(this);
            }
            finally
            {
                if (this._xe2c9497bf778cd2b != null)
                {
                    this._xe2c9497bf778cd2b.TaskStopping();
                }
            }
        }
    }
}

