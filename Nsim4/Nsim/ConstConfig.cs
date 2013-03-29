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
    public class ConstConfig : UserControl, System.Windows.Markup.IComponentConnector
    {
        private bool _x7dc3d9d322900926;
        [CompilerGenerated]
        private ConstRandomizerDecorator xfb0c580f9b6a60bd;

        public ConstConfig(ConstRandomizerDecorator config)
        {
            this.Target = config;
            this.InitializeComponent();
        }

        [DebuggerNonUserCode]
        public void InitializeComponent()
        {
            bool flag = !this._x7dc3d9d322900926;
            while (true)
            {
                if (flag)
                {
                    this._x7dc3d9d322900926 = true;
                    do
                    {
                        Uri resourceLocator = new Uri("/Nsim4;component/components/train/random/constconfig.xaml", UriKind.Relative);
                        Application.LoadComponent(this, resourceLocator);
                    }
                    while ((((uint) flag) | 3) == 0);
                }
                break;
            }
        }

        [DebuggerNonUserCode, EditorBrowsable(EditorBrowsableState.Never)]
        private void x628e6c716ec340be(int xf3efd21c486a5cce, object x11d58b056c032b03)
        {
            this._x7dc3d9d322900926 = true;
        }

        public ConstRandomizerDecorator Target
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

