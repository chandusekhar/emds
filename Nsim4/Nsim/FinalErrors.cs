namespace Nsim
{
    using Encog.ML.Data.Basic;
    using System;
    using System.CodeDom.Compiler;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Markup;

    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    public class FinalErrors : UserControl, System.Windows.Markup.IComponentConnector, x0b1787b8abd727e8
    {
        private bool _x7dc3d9d322900926;
        internal DataGrid errorsGrid;

        public FinalErrors()
        {
            this.InitializeComponent();
            App.Services.RegisterService<FinalErrors>(this);
        }

        [DebuggerNonUserCode]
        public void InitializeComponent()
        {
            bool flag = !this._x7dc3d9d322900926;
            if (flag)
            {
                Uri uri;
                this._x7dc3d9d322900926 = true;
                do
                {
                    uri = new Uri("/Nsim4;component/components/train/errorgraph/finalerrors.xaml", UriKind.Relative);
                }
                while ((((uint) flag) - ((uint) flag)) > uint.MaxValue);
                Application.LoadComponent(this, uri);
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never), DebuggerNonUserCode]
        private void x628e6c716ec340be(int xf3efd21c486a5cce, object x11d58b056c032b03)
        {
            int num = xf3efd21c486a5cce;
            if (num != 1)
            {
                this._x7dc3d9d322900926 = true;
                if ((((uint) num) + ((uint) xf3efd21c486a5cce)) >= 0)
                {
                    return;
                }
            }
            this.errorsGrid = (DataGrid) x11d58b056c032b03;
        }

        public void xf4e7b53eedfb7d89()
        {
            BasicMLDataSet set2;
            bool flag;
            double[] numArray;
            double[] numArray2;
            double[] numArray3;
            double[] numArray4;
            DataSetEditor.ErrorRec[] recArray;
            int num;
            DataSetEditor.ErrorRec rec;
            DataGridTextColumn column2;
            DataGridTextColumn column5;
            bool flag2;
            BasicMLDataSet set = App.Services.GetService<ITrainData>().xd378208b5267f7e2();
            goto Label_042B;
        Label_001D:
            this.errorsGrid.ItemsSource = recArray;
            if ((((uint) flag) & 0) != 0)
            {
                goto Label_03DF;
            }
            return;
        Label_0108:
            column5 = new DataGridTextColumn();
            column5.set_Header("Отн. погр.(%)");
            column5.set_Width(new DataGridLength(100.0));
            column5.set_Binding(new Binding("AvgErr"));
            column5.set_IsReadOnly(true);
            this.errorsGrid.get_Columns().Add(column5);
        Label_0160:
            flag2 = !flag;
            if (!flag2)
            {
                DataGridTextColumn item = new DataGridTextColumn();
                item.set_Header("Ср.кв.отн.(Т)(%)");
                item.set_Width(new DataGridLength(100.0));
                item.set_Binding(new Binding("RMEN"));
                item.set_IsReadOnly(true);
                this.errorsGrid.get_Columns().Add(item);
            }
            else
            {
                goto Label_001D;
            }
        Label_01C4:
            column2 = new DataGridTextColumn();
            column2.set_Header("Отн. погр.(Т)(%)");
            column2.set_Width(new DataGridLength(100.0));
            column2.set_Binding(new Binding("MaxErr"));
            column2.set_IsReadOnly(true);
            this.errorsGrid.get_Columns().Add(column2);
            if ((((uint) flag2) | 1) == 0)
            {
                goto Label_03D0;
            }
            do
            {
                if ((((uint) flag) & 0) != 0)
                {
                    goto Label_01C4;
                }
            }
            while ((((uint) flag2) + ((uint) flag2)) < 0);
            if ((((uint) flag) & 0) != 0)
            {
                goto Label_0160;
            }
            goto Label_001D;
        Label_0227:
            flag2 = num < set.IdealSize;
            if (!flag2)
            {
                DataGridTextColumn column3 = new DataGridTextColumn();
                column3.set_Header("Выход");
                column3.set_Width(new DataGridLength(50.0));
                column3.set_Binding(new Binding("Title"));
                column3.set_IsReadOnly(true);
                this.errorsGrid.get_Columns().Add(column3);
                DataGridTextColumn column4 = new DataGridTextColumn();
                column4.set_Header("Ср.кв.отн.(%)");
                column4.set_Width(new DataGridLength(100.0));
                column4.set_Binding(new Binding("RME"));
                column4.set_IsReadOnly(true);
                this.errorsGrid.get_Columns().Add(column4);
                goto Label_0108;
            }
        Label_0300:
            rec = new DataSetEditor.ErrorRec();
            rec.Title = "Y" + (num + 1);
            rec.RME = Math.Round(numArray[num], 4);
            rec.AvgErr = Math.Round(numArray2[num], 4);
            recArray[num] = rec;
            goto Label_03B9;
        Label_037F:
            this.errorsGrid.set_CanUserAddRows(false);
            this.errorsGrid.get_Columns().Clear();
            base.Height = 0x19 + (0x19 * set.IdealSize);
            recArray = new DataSetEditor.ErrorRec[set.IdealSize];
            if ((((uint) flag2) | 0xff) != 0)
            {
                num = 0;
                goto Label_0227;
            }
        Label_03B9:
            if (((uint) flag) <= uint.MaxValue)
            {
                if ((((uint) flag2) + ((uint) flag2)) <= uint.MaxValue)
                {
                    flag2 = flag;
                }
                if (flag2 && (((uint) flag2) >= 0))
                {
                    recArray[num].RMEN = Math.Round(numArray3[num], 4);
                    recArray[num].MaxErr = Math.Round(numArray4[num], 4);
                }
                num++;
                goto Label_0227;
            }
            goto Label_042B;
        Label_03D0:
            numArray4 = set2.x8e46c20a382f5c57();
            if (2 != 0)
            {
                goto Label_037F;
            }
        Label_03DF:
            numArray2 = set.x8e46c20a382f5c57();
            numArray3 = null;
            numArray4 = null;
            flag2 = !flag;
            if ((((uint) flag) < 0) || !flag2)
            {
                numArray3 = set2.xde3e9f8cc0169fde();
                if ((((uint) num) - ((uint) flag)) <= uint.MaxValue)
                {
                    goto Label_03D0;
                }
            }
            goto Label_037F;
        Label_042B:
            set2 = App.Services.GetService<ITestData>().xd378208b5267f7e2();
            flag = set2.Count > 0L;
            if (((uint) flag2) < 0)
            {
                goto Label_0108;
            }
            if ((((uint) flag) - ((uint) flag)) > uint.MaxValue)
            {
                goto Label_0300;
            }
            numArray = set.xde3e9f8cc0169fde();
            if (0 == 0)
            {
                goto Label_03DF;
            }
            goto Label_037F;
        }
    }
}

