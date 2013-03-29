namespace Encog.Util.Concurrency.Job
{
    using System;
    using System.Runtime.CompilerServices;

    public class JobUnitContext
    {
        [CompilerGenerated]
        private ConcurrentJob x32a86c18b13137ce;
        [CompilerGenerated]
        private object x568804c5a20a5ea3;
        [CompilerGenerated]
        private int xc5d34931c54c1b39;

        public object JobUnit
        {
            [CompilerGenerated]
            get
            {
                return this.x568804c5a20a5ea3;
            }
            [CompilerGenerated]
            set
            {
                this.x568804c5a20a5ea3 = value;
            }
        }

        public ConcurrentJob Owner
        {
            [CompilerGenerated]
            get
            {
                return this.x32a86c18b13137ce;
            }
            [CompilerGenerated]
            set
            {
                this.x32a86c18b13137ce = value;
            }
        }

        public int TaskNumber
        {
            [CompilerGenerated]
            get
            {
                return this.xc5d34931c54c1b39;
            }
            [CompilerGenerated]
            set
            {
                this.xc5d34931c54c1b39 = value;
            }
        }
    }
}

