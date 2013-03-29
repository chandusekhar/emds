namespace Nsim
{
    using System;
    using System.CodeDom.Compiler;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Controls.DataVisualization.Charting;
    using System.Windows.Markup;

    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    public class ChartWindow : Window, System.Windows.Markup.IComponentConnector
    {
        private bool _x7dc3d9d322900926;
        internal ColumnSeries barSeries;
        internal Chart chart;

        public ChartWindow()
        {
            this.InitializeComponent();
        }

        [DebuggerNonUserCode]
        public void InitializeComponent()
        {
            if (!this._x7dc3d9d322900926)
            {
                this._x7dc3d9d322900926 = true;
                Uri resourceLocator = new Uri("/Nsim4;component/components/train/dataanalisys/chartwindow.xaml", UriKind.Relative);
                Application.LoadComponent(this, resourceLocator);
            }
        }

        private void x04abae94658fc85d(object xe0292b9ed559da7d, RoutedEventArgs xfbf34718e704c6bc)
        {
            base.DialogResult = true;
        }

        [EditorBrowsable(EditorBrowsableState.Never), DebuggerNonUserCode]
        private void x628e6c716ec340be(int xf3efd21c486a5cce, object x11d58b056c032b03)
        {
            int num = xf3efd21c486a5cce;
            switch (num)
            {
                case 1:
                    this.chart = (Chart) x11d58b056c032b03;
                    break;

                case 2:
                    this.barSeries = (ColumnSeries) x11d58b056c032b03;
                    break;

                case 3:
                    ((Button) x11d58b056c032b03).Click += new RoutedEventHandler(this.x04abae94658fc85d);
                    break;

                default:
                    this._x7dc3d9d322900926 = true;
                    if ((((uint) xf3efd21c486a5cce) - ((uint) num)) <= uint.MaxValue)
                    {
                    }
                    break;
            }
        }
    }
}

