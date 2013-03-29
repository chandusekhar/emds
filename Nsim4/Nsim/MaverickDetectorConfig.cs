namespace Nsim
{
    using Microsoft.Windows.Controls;
    using System;
    using System.CodeDom.Compiler;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Markup;

    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    public class MaverickDetectorConfig : Window, System.Windows.Markup.IComponentConnector
    {
        private bool _x7dc3d9d322900926;
        internal RadioButton cbDelete;
        internal RadioButton cbNsim2;
        internal RadioButton cbNsim4;
        internal RadioButton cbSelect;
        internal RadioButton cbSendToExcel;
        internal IntegerUpDown seFindCount;

        public MaverickDetectorConfig()
        {
            this.InitializeComponent();
        }

        [DebuggerNonUserCode]
        public void InitializeComponent()
        {
            bool flag = !this._x7dc3d9d322900926;
            while (flag)
            {
                if ((((uint) flag) + ((uint) flag)) <= uint.MaxValue)
                {
                }
                this._x7dc3d9d322900926 = true;
                Uri resourceLocator = new Uri("/Nsim4;component/components/train/dataanalisys/maverickdetectorconfig.xaml", UriKind.Relative);
                Application.LoadComponent(this, resourceLocator);
                if ((((uint) flag) + ((uint) flag)) >= 0)
                {
                    break;
                }
            }
        }

        private void x06e0310f82c2e3d9(object xe0292b9ed559da7d, RoutedEventArgs xfbf34718e704c6bc)
        {
            // This item is obfuscated and can not be translated.
        }

        [EditorBrowsable(EditorBrowsableState.Never), DebuggerNonUserCode]
        private void x628e6c716ec340be(int xf3efd21c486a5cce, object x11d58b056c032b03)
        {
            int num = xf3efd21c486a5cce;
            switch (num)
            {
                case 1:
                    this.cbNsim2 = (RadioButton) x11d58b056c032b03;
                    return;

                case 2:
                    this.cbNsim4 = (RadioButton) x11d58b056c032b03;
                    return;

                case 3:
                    ((Button) x11d58b056c032b03).Click += new RoutedEventHandler(this.x06e0310f82c2e3d9);
                    if (((uint) num) <= uint.MaxValue)
                    {
                        if ((((uint) xf3efd21c486a5cce) - ((uint) xf3efd21c486a5cce)) <= uint.MaxValue)
                        {
                        }
                        return;
                    }
                    break;

                case 4:
                    this.seFindCount = (IntegerUpDown) x11d58b056c032b03;
                    return;

                case 5:
                    this.cbSelect = (RadioButton) x11d58b056c032b03;
                    return;

                case 6:
                    this.cbDelete = (RadioButton) x11d58b056c032b03;
                    return;

                case 7:
                    this.cbSendToExcel = (RadioButton) x11d58b056c032b03;
                    return;

                case 8:
                    ((Button) x11d58b056c032b03).Click += new RoutedEventHandler(this.xd3b044bc7a476aeb);
                    return;

                case 9:
                    ((Button) x11d58b056c032b03).Click += new RoutedEventHandler(this.xd68518a4013c2043);
                    return;
            }
            this._x7dc3d9d322900926 = true;
            if ((((uint) xf3efd21c486a5cce) + ((uint) xf3efd21c486a5cce)) < 0)
            {
            }
        }

        private void xd3b044bc7a476aeb(object xe0292b9ed559da7d, RoutedEventArgs xfbf34718e704c6bc)
        {
            base.DialogResult = true;
        }

        private void xd68518a4013c2043(object xe0292b9ed559da7d, RoutedEventArgs xfbf34718e704c6bc)
        {
            base.DialogResult = false;
        }
    }
}

