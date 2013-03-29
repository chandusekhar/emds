namespace Encog.Util.Concurrency
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Threading;

    public class EngineConcurrency : IMultiThreadable
    {
        private int _x16f1ed41ac673568;
        private static EngineConcurrency _x6ed4ed9ed59eb694 = new EngineConcurrency();
        private int _xec46e84fb00f4a59;
        [CompilerGenerated]
        private int xd52bb976708dc8fe;

        public EngineConcurrency()
        {
            this.SetMaxThreadsToCoreCount();
            this._xec46e84fb00f4a59 = 0;
        }

        public TaskGroup CreateTaskGroup()
        {
            lock (this)
            {
                this._xec46e84fb00f4a59++;
                return new TaskGroup(this._xec46e84fb00f4a59);
            }
        }

        public void ProcessTask(IEngineTask task)
        {
            this.ProcessTask(task, null);
        }

        public void ProcessTask(IEngineTask task, TaskGroup group)
        {
            lock (this)
            {
                this._x16f1ed41ac673568++;
                if (group != null)
                {
                    group.TaskStarting();
                    if (0 != 0)
                    {
                        return;
                    }
                }
            }
            PoolItem item = new PoolItem(this, task, group);
            ThreadPool.QueueUserWorkItem(new WaitCallback(item.ThreadPoolCallback));
        }

        public void SetMaxThreadsToCoreCount()
        {
            this.MaxThreads = Environment.ProcessorCount;
        }

        internal void x88dff5165154bb1d(PoolItem x0423154fd82dd270)
        {
            lock (this)
            {
                this._x16f1ed41ac673568--;
            }
        }

        public static EngineConcurrency Instance
        {
            get
            {
                return _x6ed4ed9ed59eb694;
            }
        }

        public int MaxThreads
        {
            get
            {
                int num;
                int num2;
                ThreadPool.GetMaxThreads(out num, out num2);
                return num;
            }
            set
            {
                int workerThreads = value;
                goto Label_001A;
            Label_0004:
                workerThreads++;
                if (((uint) value) >= 0)
                {
                    goto Label_0028;
                }
            Label_001A:
                if (workerThreads == 0)
                {
                    workerThreads = Environment.ProcessorCount;
                    if (0 == 0)
                    {
                        goto Label_0024;
                    }
                    goto Label_0004;
                }
                if (1 != 0)
                {
                    goto Label_0028;
                }
            Label_0024:
                if (workerThreads > 1)
                {
                    goto Label_0004;
                }
            Label_0028:
                ThreadPool.SetMaxThreads(workerThreads, workerThreads);
            }
        }

        public int ThreadCount
        {
            [CompilerGenerated]
            get
            {
                return this.xd52bb976708dc8fe;
            }
            [CompilerGenerated]
            set
            {
                this.xd52bb976708dc8fe = value;
            }
        }
    }
}

