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
    public class GaussianRandomizerConfig : UserControl, System.Windows.Markup.IComponentConnector
    {
        private bool _x7dc3d9d322900926;
        [CompilerGenerated]
        private GaussianRandomizerDecorator xfb0c580f9b6a60bd;

        public GaussianRandomizerConfig(GaussianRandomizerDecorator target)
        {
            this.Target = target;
            this.InitializeComponent();
        }

        [DebuggerNonUserCode]
        public void InitializeComponent()
        {
            bool flag = !this._x7dc3d9d322900926;
            if (flag)
            {
                do
                {
                    this._x7dc3d9d322900926 = true;
                    Uri resourceLocator = new Uri("/Nsim4;component/components/train/random/gaussianrandomizerconfig.xaml", UriKind.Relative);
                    Application.LoadComponent(this, resourceLocator);
                }
                while ((((uint) flag) - ((uint) flag)) > uint.MaxValue);
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never), DebuggerNonUserCode]
        private void x628e6c716ec340be(int xf3efd21c486a5cce, object x11d58b056c032b03)
        {
            this._x7dc3d9d322900926 = true;
        }

        public GaussianRandomizerDecorator Target
        {
            [CompilerGenerated]
            get
            {
                return this.xfb0c580f9b6a60bd;
            }
            [CompilerGenerated]
            private set
            {
                this.xfb0c580f9b6a60bd = value;
            }
        }
    }
}

