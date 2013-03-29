namespace Nsim
{
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Markup;

    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    public class ImportExcelFileDialog : Window, System.Windows.Markup.IComponentConnector
    {
        private bool _x7dc3d9d322900926;
        internal Button btnCancel;
        internal Button btnOk;
        internal ComboBox cbDataSets;

        public ImportExcelFileDialog(IEnumerable<string> names)
        {
            bool flag;
            this.InitializeComponent();
            using (IEnumerator<string> enumerator = names.GetEnumerator())
            {
                string str;
                goto Label_0055;
            Label_0037:
                str = enumerator.Current;
                this.cbDataSets.Items.Add(str);
                if (0 != 0)
                {
                    goto Label_0037;
                }
            Label_0055:
                if (enumerator.MoveNext())
                {
                    goto Label_0037;
                }
                goto Label_0086;
            }
            if (((uint) flag) <= uint.MaxValue)
            {
                goto Label_0086;
            }
        Label_000A:
            this.cbDataSets.SelectedIndex = 0;
            return;
        Label_0086:
            if (names.Count<string>() > 0)
            {
                goto Label_000A;
            }
        }

        [DebuggerNonUserCode]
        internal Delegate _x11287467a5422d1c(Type x127370c996b87499, string xa1b13fd4a6c07a01)
        {
            return Delegate.CreateDelegate(x127370c996b87499, this, xa1b13fd4a6c07a01);
        }

        [DebuggerNonUserCode]
        public void InitializeComponent()
        {
            bool flag = !this._x7dc3d9d322900926;
            if (((uint) flag) < 0)
            {
                if (((uint) flag) >= 0)
                {
                }
            }
            else
            {
                do
                {
                    if (!flag)
                    {
                        return;
                    }
                    this._x7dc3d9d322900926 = true;
                    Uri resourceLocator = new Uri("/Nsim4;component/components/train/dataseteditor/importexcelfiledialog.xaml", UriKind.Relative);
                    Application.LoadComponent(this, resourceLocator);
                }
                while (0 != 0);
            }
        }

        private void x20040ca0b86164b6(object xe0292b9ed559da7d, SelectionChangedEventArgs xfbf34718e704c6bc)
        {
            this.btnOk.IsEnabled = this.cbDataSets.SelectedItem != null;
        }

        [EditorBrowsable(EditorBrowsableState.Never), DebuggerNonUserCode]
        private void x628e6c716ec340be(int xf3efd21c486a5cce, object x11d58b056c032b03)
        {
            int num = xf3efd21c486a5cce;
        Label_00B2:
            switch (num)
            {
                case 1:
                    goto Label_0068;

                case 2:
                    this.btnOk = (Button) x11d58b056c032b03;
                    if ((((uint) num) - ((uint) xf3efd21c486a5cce)) >= 0)
                    {
                        if (1 != 0)
                        {
                            this.btnOk.Click += new RoutedEventHandler(this.xcd80a3ba12753aad);
                            return;
                        }
                        if (0xff != 0)
                        {
                            break;
                        }
                        goto Label_0068;
                    }
                    goto Label_00B2;

                case 3:
                    break;

                default:
                    this._x7dc3d9d322900926 = true;
                    return;
            }
            this.btnCancel = (Button) x11d58b056c032b03;
            this.btnCancel.Click += new RoutedEventHandler(this.x9aadf2c36dea1282);
            if ((((uint) xf3efd21c486a5cce) - ((uint) num)) > uint.MaxValue)
            {
            }
            return;
        Label_0068:
            this.cbDataSets = (ComboBox) x11d58b056c032b03;
            this.cbDataSets.SelectionChanged += new SelectionChangedEventHandler(this.x20040ca0b86164b6);
        }

        private void x9aadf2c36dea1282(object xe0292b9ed559da7d, RoutedEventArgs xfbf34718e704c6bc)
        {
            base.DialogResult = false;
        }

        private void xcd80a3ba12753aad(object xe0292b9ed559da7d, RoutedEventArgs xfbf34718e704c6bc)
        {
            base.DialogResult = true;
        }
    }
}

