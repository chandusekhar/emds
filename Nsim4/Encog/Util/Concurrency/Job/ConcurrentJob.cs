namespace Encog.Util.Concurrency.Job
{
    using Encog;
    using Encog.Util.Concurrency;
    using System;
    using System.Runtime.CompilerServices;

    public abstract class ConcurrentJob : IMultiThreadable
    {
        private int _x5cd5268c7a8f6ac5;
        private readonly IStatusReportable _x64343a0786fb9a3f;
        [CompilerGenerated]
        private bool x3e4c40a0b458b605;
        [CompilerGenerated]
        private int xd52bb976708dc8fe;

        protected ConcurrentJob(IStatusReportable report)
        {
            this._x64343a0786fb9a3f = report;
        }

        public abstract int LoadWorkload();
        public abstract void PerformJobUnit(JobUnitContext context);
        public virtual void Process()
        {
            object obj2;
            TaskGroup group;
            int num;
            JobUnitContext context;
            JobUnitContext context2;
            EngineConcurrency.Instance.ThreadCount = this.ThreadCount;
            if (0 == 0)
            {
                group = EngineConcurrency.Instance.CreateTaskGroup();
                this._x5cd5268c7a8f6ac5 = this.LoadWorkload();
                num = 0;
            }
        Label_0015:
            while ((obj2 = this.RequestNextTask()) != null)
            {
                num++;
                context2 = new JobUnitContext {
                    JobUnit = obj2,
                    Owner = this
                };
                if ((((uint) num) - ((uint) num)) > uint.MaxValue)
                {
                    goto Label_0032;
                }
                if (0x7fffffff != 0)
                {
                    context2.TaskNumber = num;
                    goto Label_0032;
                }
            }
            group.WaitForComplete();
            return;
        Label_0032:
            context = context2;
            JobUnitWorker task = new JobUnitWorker(context);
            EngineConcurrency.Instance.ProcessTask(task, group);
            goto Label_0015;
        }

        public void ReportStatus(JobUnitContext context, string status)
        {
            this._x64343a0786fb9a3f.Report(this._x5cd5268c7a8f6ac5, context.TaskNumber, status);
        }

        public abstract object RequestNextTask();

        public bool ShouldStop
        {
            [CompilerGenerated]
            get
            {
                return this.x3e4c40a0b458b605;
            }
            [CompilerGenerated]
            set
            {
                this.x3e4c40a0b458b605 = value;
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

