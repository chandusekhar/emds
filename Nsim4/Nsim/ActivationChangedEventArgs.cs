namespace Nsim
{
    using System;
    using System.Runtime.CompilerServices;

    public class ActivationChangedEventArgs : EventArgs
    {
        [CompilerGenerated]
        private IActivationStruct x66c2e884def499b8;

        public ActivationChangedEventArgs(IActivationStruct activation)
        {
            this.ActivationFunction = activation;
        }

        public IActivationStruct ActivationFunction
        {
            [CompilerGenerated]
            get
            {
                return this.x66c2e884def499b8;
            }
            [CompilerGenerated]
            private set
            {
                this.x66c2e884def499b8 = value;
            }
        }
    }
}

