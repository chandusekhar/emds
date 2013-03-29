namespace Nsim
{
    using System;
    using System.Runtime.CompilerServices;

    public class RandomChangedEventArgs : EventArgs
    {
        [CompilerGenerated]
        private IRandomStruct xc7d9ae772aceb47e;

        public RandomChangedEventArgs(IRandomStruct randomizer)
        {
            this.Random = randomizer;
        }

        public IRandomStruct Random
        {
            [CompilerGenerated]
            get
            {
                return this.xc7d9ae772aceb47e;
            }
            [CompilerGenerated]
            private set
            {
                this.xc7d9ae772aceb47e = value;
            }
        }
    }
}

