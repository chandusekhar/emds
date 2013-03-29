namespace Nsim
{
    using System;
    using System.Runtime.CompilerServices;

    public class TrainerChangedEventArgs : EventArgs
    {
        [CompilerGenerated]
        private ITrainerStruct x746ac44d4b86c41a;

        public TrainerChangedEventArgs(ITrainerStruct trainer)
        {
            this.Trainer = trainer;
        }

        public ITrainerStruct Trainer
        {
            [CompilerGenerated]
            get
            {
                return this.x746ac44d4b86c41a;
            }
            [CompilerGenerated]
            private set
            {
                this.x746ac44d4b86c41a = value;
            }
        }
    }
}

