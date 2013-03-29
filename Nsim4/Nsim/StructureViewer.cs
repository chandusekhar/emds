namespace Nsim
{
    using System;
    using System.CodeDom.Compiler;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Markup;
    using System.Windows.Media;

    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    public class StructureViewer : UserControl, System.Windows.Markup.IComponentConnector
    {
        private bool _x7dc3d9d322900926;

        public StructureViewer()
        {
        Label_0033:
            this.InitializeComponent();
            bool flag = (RenderCapability.Tier >> 0x10) != 0;
            if ((((uint) flag) - ((uint) flag)) >= 0)
            {
                if (flag)
                {
                    base.Content = new StructureViewer3D();
                    if (0 == 0)
                    {
                        return;
                    }
                    goto Label_0033;
                }
            }
            else if (4 == 0)
            {
                return;
            }
            base.Content = new StructureViewer2D();
            if (0 == 0)
            {
            }
        }

        [DebuggerNonUserCode]
        public void InitializeComponent()
        {
            bool flag = !this._x7dc3d9d322900926;
            while (flag)
            {
                this._x7dc3d9d322900926 = true;
                Uri resourceLocator = new Uri("/Nsim4;component/components/structure/viewer/structureviewer.xaml", UriKind.Relative);
                Application.LoadComponent(this, resourceLocator);
                break;
            }
        }

        [DebuggerNonUserCode, EditorBrowsable(EditorBrowsableState.Never)]
        private void x628e6c716ec340be(int xf3efd21c486a5cce, object x11d58b056c032b03)
        {
            this._x7dc3d9d322900926 = true;
        }
    }
}

