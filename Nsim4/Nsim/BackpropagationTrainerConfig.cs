namespace Nsim
{
    using System;
    using System.CodeDom.Compiler;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Markup;

    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    public class BackpropagationTrainerConfig : UserControl, System.Windows.Markup.IComponentConnector
    {
        private bool _x7dc3d9d322900926;
        [CompilerGenerated]
        private BackpropagationTrainerDecorator x746ac44d4b86c41a;

        public BackpropagationTrainerConfig()
        {
            this.InitializeComponent();
        }

        public BackpropagationTrainerConfig(BackpropagationTrainerDecorator trainer) : this()
        {
            this.Trainer = trainer;
        }

        [DebuggerNonUserCode]
        public void InitializeComponent()
        {
            bool flag = !this._x7dc3d9d322900926;
            while (flag)
            {
                this._x7dc3d9d322900926 = true;
                Uri resourceLocator = new Uri("/Nsim4;component/components/train/trainers/backpropagationtrainerconfig.xaml", UriKind.Relative);
                Application.LoadComponent(this, resourceLocator);
                if ((((uint) flag) < 0) || ((((uint) flag) - ((uint) flag)) <= uint.MaxValue))
                {
                    return;
                }
            }
        }

        [DebuggerNonUserCode, EditorBrowsable(EditorBrowsableState.Never)]
        private void x628e6c716ec340be(int xf3efd21c486a5cce, object x11d58b056c032b03)
        {
            this._x7dc3d9d322900926 = true;
        }

        public BackpropagationTrainerDecorator Trainer
        {
            [CompilerGenerated]
            get
            {
                return this.x746ac44d4b86c41a;
            }
            [CompilerGenerated]
            set
            {
                this.x746ac44d4b86c41a = value;
            }
        }
    }
}

