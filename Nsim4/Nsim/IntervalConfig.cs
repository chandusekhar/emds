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
    public class IntervalConfig : UserControl, System.Windows.Markup.IComponentConnector
    {
        private bool _x7dc3d9d322900926;
        [CompilerGenerated]
        private IIntervalProvider xfb0c580f9b6a60bd;

        public IntervalConfig(IIntervalProvider target)
        {
            this.Target = target;
            this.InitializeComponent();
        }

        [DebuggerNonUserCode]
        public void InitializeComponent()
        {
            Uri uri;
            bool flag = !this._x7dc3d9d322900926;
            if (((uint) flag) <= uint.MaxValue)
            {
                if (!flag)
                {
                    return;
                }
                this._x7dc3d9d322900926 = true;
                uri = new Uri("/Nsim4;component/components/train/random/intervalconfig.xaml", UriKind.Relative);
            }
            if (0 == 0)
            {
                Application.LoadComponent(this, uri);
            }
        }

        [DebuggerNonUserCode, EditorBrowsable(EditorBrowsableState.Never)]
        private void x628e6c716ec340be(int xf3efd21c486a5cce, object x11d58b056c032b03)
        {
            this._x7dc3d9d322900926 = true;
        }

        public IIntervalProvider Target
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

