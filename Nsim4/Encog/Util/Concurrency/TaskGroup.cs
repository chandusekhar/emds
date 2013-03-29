namespace Encog.Util.Concurrency
{
    using System;
    using System.Threading;

    public class TaskGroup
    {
        private int _x4890c2c6159c6b79;
        private int _x5cd5268c7a8f6ac5;
        private readonly ManualResetEvent _x794886ba51950b59 = new ManualResetEvent(false);
        private readonly int _xeaf1b27180c0557b;

        public TaskGroup(int id)
        {
            this._xeaf1b27180c0557b = id;
            this._x5cd5268c7a8f6ac5 = 0;
        }

        public void TaskStarting()
        {
            lock (this)
            {
                this._x5cd5268c7a8f6ac5++;
            }
        }

        public void TaskStopping()
        {
            lock (this)
            {
                this._x4890c2c6159c6b79++;
                this._x794886ba51950b59.Set();
            }
        }

        public void WaitForComplete()
        {
            while (!this.NoTasks)
            {
                this._x794886ba51950b59.WaitOne();
                this._x794886ba51950b59.Reset();
            }
        }

        public int ID
        {
            get
            {
                return this._xeaf1b27180c0557b;
            }
        }

        public bool NoTasks
        {
            get
            {
                lock (this)
                {
                    return (this._x5cd5268c7a8f6ac5 == this._x4890c2c6159c6b79);
                }
            }
        }
    }
}

