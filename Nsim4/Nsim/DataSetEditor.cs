namespace Nsim
{
    using Encog.ML.Data;
    using Encog.ML.Data.Basic;
    using Microsoft.Win32;
    using mscorlib;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Input;
    using System.Windows.Markup;
    using System.Xml.Linq;

    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    public class DataSetEditor : UserControl, IConfigurable, System.Windows.Markup.IComponentConnector, ITrainData, x03e29c1ee96cbf80, ITestData, ICheckData, ICalcData
    {
        private ICommand _x0f2556536d1d7bca;
        private ICommand _x15dca715f4511af0;
        private ICommand _x1fe53a4cf8c5fa54;
        private ICommand _x219ea743faaa7304;
        private ICommand _x2cf8a93deca9cfc0;
        private ICommand _x36a24525a42af546;
        private ICommand _x560c3d25400916e8;
        private ICommand _x5ab4c337882aac5d;
        private ICommand _x62bd22ab6ec15733;
        private ICommand _x7d6c7fae6d409afc;
        private bool _x7dc3d9d322900926;
        private ICommand _xbbad0d07d0ce58ca;
        private ICommand _xbffe93d292afae56;
        private ICommand _xebe17e484e5d383f;
        internal DataGrid dataGrid;
        public static readonly DependencyProperty EditModeProperty = DependencyProperty.Register("EditMode", typeof(DataSetEditMode), typeof(DataSetEditor), new UIPropertyMetadata(DataSetEditMode.TrainData, new PropertyChangedCallback(DataSetEditor.x383108da65379cdd)));
        internal DataGrid errorsGrid;
        [CompilerGenerated]
        private static Predicate<object> x21f584f1b098fa5d;
        [CompilerGenerated]
        private static Predicate<object> x66406001675ff321;
        [CompilerGenerated]
        private static Predicate<object> x8377bd2542c6d7e2;
        [CompilerGenerated]
        private static Predicate<object> x93a4527b4dd43ade;
        [CompilerGenerated]
        private static Predicate<object> x9c7da71503635ea2;
        [CompilerGenerated]
        private static Predicate<object> xcb5110745db8648f;
        [CompilerGenerated]
        private static Predicate<object> xcd3a29c3cfb3776e;
        [CompilerGenerated]
        private static Action<object> xce2dfaf8dd33dc9c;
        [CompilerGenerated]
        private static Predicate<object> xd8ab807655986ce6;
        [CompilerGenerated]
        private static Predicate<object> xec790bb6d0304faa;

        public DataSetEditor()
        {
            this.InitializeComponent();
            this.DataCollection = new ObservableCollection<IMLDataPair>();
            App.Services.SubscribeEvent<xa443afcc736e1f3e>(new Action<xa443afcc736e1f3e>(this.x2c196582986b2b4d));
            this.x2c196582986b2b4d(null);
        }

        [DebuggerNonUserCode]
        public void InitializeComponent()
        {
            bool flag = !this._x7dc3d9d322900926;
            if ((0 == 0) && flag)
            {
                this._x7dc3d9d322900926 = true;
                do
                {
                    Uri resourceLocator = new Uri("/Nsim4;component/components/train/dataseteditor/dataseteditor.xaml", UriKind.Relative);
                    Application.LoadComponent(this, resourceLocator);
                }
                while (3 == 0);
            }
        }

        protected void RebuildGrid(IEnumerable<IMLDataPair> oldData)
        {
            int num;
            DataGridTextColumn column3;
            DataGridTextColumn column4;
            bool flag;
            this.dataGrid.get_Columns().Clear();
            if ((((uint) flag) & 0) == 0)
            {
                goto Label_06D7;
            }
            goto Label_042A;
        Label_02DA:
            flag = num < this.ErrorSize;
            if ((((uint) num) - ((uint) flag)) <= uint.MaxValue)
            {
                if (flag)
                {
                    flag = this.EditMode == DataSetEditMode.CheckData;
                    if (((((uint) num) + ((uint) flag)) >= 0) && flag)
                    {
                        if (((uint) flag) <= uint.MaxValue)
                        {
                            goto Label_0311;
                        }
                        goto Label_03FD;
                    }
                    goto Label_0387;
                }
                this.DataCollection = new ObservableCollection<IMLDataPair>();
                if ((((uint) num) - ((uint) flag)) >= 0)
                {
                    if (oldData == null)
                    {
                        return;
                    }
                    IEnumerator<IMLDataPair> enumerator = oldData.GetEnumerator();
                    try
                    {
                        IMLDataPair pair;
                        BasicMLData data;
                        BasicMLData data2;
                        BasicMLData data3;
                        BasicMLData data4;
                    Label_004D:
                        flag = enumerator.MoveNext();
                        if (flag)
                        {
                            goto Label_0272;
                        }
                        goto Label_04E3;
                    Label_0062:
                        if (flag)
                        {
                            goto Label_0099;
                        }
                        goto Label_006F;
                    Label_0068:
                        if (!flag)
                        {
                            goto Label_00E3;
                        }
                    Label_006F:
                        this.DataCollection.Add(new BasicMLDataPair(data, data2, data3, data4));
                        if (((uint) num) >= 0)
                        {
                            goto Label_004D;
                        }
                    Label_0099:
                        data4[num] = pair.ErrorArray[num];
                        num++;
                    Label_00B1:
                        flag = num < Math.Min(this.CalcedSize, pair.ErrorArray.Length);
                        if (-1 == 0)
                        {
                            goto Label_0099;
                        }
                        goto Label_0062;
                    Label_00E3:
                        num = 0;
                        goto Label_00B1;
                    Label_00E9:
                        flag = num < Math.Min(this.CalcedSize, pair.CalcedArray.Length);
                    Label_0102:
                        if (flag)
                        {
                            goto Label_013F;
                        }
                        goto Label_010C;
                    Label_0108:
                        if (!flag)
                        {
                            goto Label_013B;
                        }
                    Label_010C:
                        data4 = new BasicMLData(this.CalcedSize);
                        flag = pair.ErrorArray == null;
                        if (0 == 0)
                        {
                            goto Label_0068;
                        }
                        goto Label_04E3;
                    Label_012D:
                        flag = pair.CalcedArray == null;
                        goto Label_0108;
                    Label_013B:
                        num = 0;
                        goto Label_00E9;
                    Label_013F:
                        data3[num] = pair.CalcedArray[num];
                        num++;
                        goto Label_00E9;
                    Label_015C:
                        if (flag)
                        {
                            goto Label_01B6;
                        }
                        if ((((uint) flag) + ((uint) flag)) > uint.MaxValue)
                        {
                            goto Label_010C;
                        }
                        data3 = new BasicMLData(this.CalcedSize);
                        goto Label_012D;
                    Label_018D:
                        flag = num < Math.Min(this.IdealSize, pair.IdealArray.Length);
                        goto Label_015C;
                    Label_01A8:
                        num = 0;
                        if (8 == 0)
                        {
                            goto Label_0102;
                        }
                        goto Label_018D;
                    Label_01B6:
                        data2[num] = pair.IdealArray[num];
                        num++;
                    Label_01CE:
                        if (0xff == 0)
                        {
                            goto Label_01E2;
                        }
                        goto Label_018D;
                    Label_01DC:
                        num++;
                    Label_01E2:
                        flag = num < Math.Min(this.InputSize, pair.InputArray.Length);
                        if (flag)
                        {
                            goto Label_0239;
                        }
                        data2 = new BasicMLData(this.IdealSize);
                        if ((((uint) num) - ((uint) num)) <= uint.MaxValue)
                        {
                            goto Label_01A8;
                        }
                        goto Label_0272;
                    Label_0229:
                        if (15 == 0)
                        {
                            goto Label_0068;
                        }
                        goto Label_0292;
                    Label_0235:
                        num = 0;
                        goto Label_01E2;
                    Label_0239:
                        data[num] = pair.InputArray[num];
                        if (-2147483648 == 0)
                        {
                            goto Label_01CE;
                        }
                        if ((((uint) num) | 8) == 0)
                        {
                            goto Label_018D;
                        }
                        goto Label_028B;
                    Label_0272:
                        pair = enumerator.Current;
                        data = new BasicMLData(this.InputSize);
                        goto Label_0235;
                    Label_028B:
                        if (3 != 0)
                        {
                            goto Label_0229;
                        }
                    Label_0292:
                        if (1 != 0)
                        {
                            goto Label_01DC;
                        }
                        goto Label_01A8;
                    }
                    finally
                    {
                        flag = enumerator == null;
                        while (!flag)
                        {
                            enumerator.Dispose();
                            break;
                        }
                    }
                }
                goto Label_04E3;
            }
        Label_0311:
            column4 = new DataGridTextColumn();
            column4.set_Header("E" + (num + 1));
            column4.set_Width(new DataGridLength(60.0));
            column4.set_Binding(new Binding("Error[" + num + "]"));
            column4.set_IsReadOnly(true);
            this.dataGrid.get_Columns().Add(column4);
        Label_0387:
            num++;
            if (2 == 0)
            {
                goto Label_06C9;
            }
            goto Label_02DA;
        Label_03FD:
            flag = num < this.CalcedSize;
        Label_0408:
            if (flag)
            {
                flag = this.EditMode != DataSetEditMode.TrainData;
                goto Label_0465;
            }
            if ((((uint) num) & 0) == 0)
            {
                num = 0;
                goto Label_02DA;
            }
            goto Label_0311;
        Label_042A:
            num++;
            if ((((uint) flag) | uint.MaxValue) == 0)
            {
                goto Label_0408;
            }
            if ((((uint) num) | 0xff) != 0)
            {
                goto Label_03FD;
            }
            goto Label_0311;
        Label_0465:
            if (!flag)
            {
                goto Label_042A;
            }
        Label_0469:
            column3 = new DataGridTextColumn();
            column3.set_Header("Y" + (num + 1));
            column3.set_Width(new DataGridLength(60.0));
            column3.set_Binding(new Binding("Calced[" + num + "]"));
            column3.set_IsReadOnly(true);
            this.dataGrid.get_Columns().Add(column3);
            goto Label_042A;
        Label_04E3:
            if ((((uint) num) + ((uint) flag)) >= 0)
            {
                return;
            }
            goto Label_06D7;
        Label_0540:
            flag = num < this.IdealSize;
            if ((((uint) flag) + ((uint) flag)) > uint.MaxValue)
            {
                goto Label_0469;
            }
            if (flag)
            {
                flag = this.EditMode != DataSetEditMode.CalcData;
            }
            else
            {
                num = 0;
                goto Label_03FD;
            }
            if (flag)
            {
                DataGridTextColumn item = new DataGridTextColumn();
                item.set_Header("D" + (num + 1));
                item.set_Width(new DataGridLength(60.0));
                item.set_Binding(new Binding("Ideal[" + num + "]"));
                item.set_IsReadOnly(false);
                this.dataGrid.get_Columns().Add(item);
            }
            num++;
            goto Label_0540;
        Label_06BE:
            flag = num < this.InputSize;
        Label_06C9:
            if (flag)
            {
                DataGridTextColumn column = new DataGridTextColumn();
                column.set_Header("X" + (num + 1));
                column.set_Width(new DataGridLength(60.0));
                column.set_Binding(new Binding("Input[" + num + "]"));
                column.set_IsReadOnly(false);
                this.dataGrid.get_Columns().Add(column);
                num++;
                goto Label_06BE;
            }
            if (8 != 0)
            {
                if (0 != 0)
                {
                    goto Label_0540;
                }
                if (0 == 0)
                {
                    if ((((uint) num) - ((uint) flag)) <= uint.MaxValue)
                    {
                        if ((((uint) num) + ((uint) num)) < 0)
                        {
                            goto Label_02DA;
                        }
                        if ((((uint) num) - ((uint) flag)) <= uint.MaxValue)
                        {
                            num = 0;
                        }
                    }
                    goto Label_0540;
                }
            }
        Label_06D7:
            num = 0;
            if ((((uint) num) | 4) == 0)
            {
                goto Label_0465;
            }
            goto Label_06BE;
        }

        [CompilerGenerated]
        private void x16d2d9af716f4e4c(object x08db3aeabb253cb1)
        {
            this.x35c4ec3ae031eb9d();
        }

        private void x24dcbf47940a9def()
        {
            ExcelDataExport.ExportToExcel(this.Data, this.EditMode);
        }

        private void x260f84eca0a6e365()
        {
            this.DataCollection.Add(new BasicMLDataPair(new BasicMLData(this.InputSize), new BasicMLData(this.IdealSize), new BasicMLData(this.CalcedSize), new BasicMLData(this.ErrorSize)));
        }

        [CompilerGenerated]
        private void x29383b707852ea6d(object x08db3aeabb253cb1)
        {
            this.x9421b72207ddef01();
        }

        private void x2977a400fde1078f()
        {
            IDataProcessor processor;
            ErrorRec[] recArray;
            int num;
            double[] numArray;
            double[] numArray2;
            double num2;
            bool flag;
            xf8efd7615008d32e service = App.Services.GetService<xf8efd7615008d32e>();
            if (((uint) num) <= uint.MaxValue)
            {
                processor = App.Services.GetService<IDataProcessor>();
                recArray = new ErrorRec[this.ErrorSize];
                num = 0;
                goto Label_0546;
            }
            goto Label_0598;
        Label_0028:
            if (!flag)
            {
                goto Label_0253;
            }
        Label_002F:
            this.RebuildGrid(this.DataCollection);
            if ((((uint) num) + ((uint) num)) <= uint.MaxValue)
            {
                if ((((uint) flag) - ((uint) flag)) >= 0)
                {
                    return;
                }
                goto Label_0598;
            }
            if ((((uint) num2) - ((uint) num)) >= 0)
            {
                goto Label_023F;
            }
        Label_0147:
            this.errorsGrid.get_Columns().Clear();
            if (((uint) num2) < 0)
            {
                goto Label_0546;
            }
            DataGridTextColumn item = new DataGridTextColumn();
            item.set_Header("Выход");
            item.set_Width(new DataGridLength(60.0));
            item.set_Binding(new Binding("Title"));
            item.set_IsReadOnly(true);
            this.errorsGrid.get_Columns().Add(item);
            if ((((uint) num) + ((uint) flag)) < 0)
            {
                goto Label_0028;
            }
            DataGridTextColumn column2 = new DataGridTextColumn();
            column2.set_Header("Средн. кв. отн. (%)");
            column2.set_Width(new DataGridLength(150.0));
            column2.set_Binding(new Binding("RME"));
            column2.set_IsReadOnly(true);
            this.errorsGrid.get_Columns().Add(column2);
            DataGridTextColumn column3 = new DataGridTextColumn();
            column3.set_Header("Отн. погрешность (%)");
            column3.set_Width(new DataGridLength(150.0));
            column3.set_Binding(new Binding("AvgErr"));
            column3.set_IsReadOnly(true);
            this.errorsGrid.get_Columns().Add(column3);
            DataGridTextColumn column4 = new DataGridTextColumn();
            column4.set_Header("Средн. кв. (норм.)");
            column4.set_Width(new DataGridLength(150.0));
            column4.set_Binding(new Binding("RMEN"));
            column4.set_IsReadOnly(true);
            this.errorsGrid.get_Columns().Add(column4);
            this.errorsGrid.ItemsSource = recArray;
            this.errorsGrid.Visibility = Visibility.Visible;
            goto Label_002F;
        Label_023F:
            flag = this.EditMode != DataSetEditMode.CheckData;
            if (0 == 0)
            {
                goto Label_0028;
            }
        Label_0253:
            this.errorsGrid.set_CanUserAddRows(false);
            goto Label_0147;
        Label_0509:
            num = 0;
        Label_02AE:
            flag = num < this.ErrorSize;
            if (flag)
            {
                recArray[num].RME = Math.Round(numArray2[num], 4);
                recArray[num].AvgErr = Math.Round(numArray[num], 4);
            }
            else if (((uint) num) >= 0)
            {
                goto Label_023F;
            }
            recArray[num].MaxErr = Math.Round(recArray[num].MaxErr, 4);
            if ((((uint) num2) + ((uint) flag)) >= 0)
            {
                num++;
                goto Label_02AE;
            }
            goto Label_0598;
        Label_0546:
            flag = num < this.ErrorSize;
            if (flag)
            {
                recArray[num] = new ErrorRec { Title = "Y" + (num + 1) };
                if ((((uint) num2) | uint.MaxValue) == 0)
                {
                    return;
                }
            }
            else
            {
                if ((((uint) num2) - ((uint) num2)) >= 0)
                {
                }
                numArray = this.Data.x8e46c20a382f5c57();
                if (0 != 0)
                {
                    goto Label_0546;
                }
                if ((((uint) flag) + ((uint) num2)) <= uint.MaxValue)
                {
                    numArray2 = this.Data.xde3e9f8cc0169fde();
                    IEnumerator<IMLDataPair> enumerator = this.DataCollection.GetEnumerator();
                    try
                    {
                        ErrorRec rec1;
                        IMLDataPair pair;
                        IMLData data;
                        IMLData data2;
                        IMLData data4;
                        IMLData data6;
                        goto Label_0316;
                    Label_030A:
                        if (flag)
                        {
                            goto Label_04DF;
                        }
                        goto Label_0449;
                    Label_0316:
                        flag = enumerator.MoveNext();
                        goto Label_030A;
                    Label_0324:
                        if (!flag)
                        {
                            goto Label_03EA;
                        }
                    Label_032B:
                        num++;
                        if (((uint) num) > uint.MaxValue)
                        {
                            goto Label_0324;
                        }
                    Label_0342:
                        flag = num < data6.Count;
                        if (flag)
                        {
                            goto Label_047E;
                        }
                        goto Label_039F;
                    Label_0358:
                        rec1 = recArray[num];
                        rec1.RME += num2 * num2;
                        recArray[num].MaxErr = Math.Max(recArray[num].MaxErr, Math.Abs(num2));
                        pair.ErrorArray[num] = Math.Round(num2, 4);
                        goto Label_032B;
                    Label_039F:
                        if (0 == 0)
                        {
                            goto Label_0316;
                        }
                        goto Label_030A;
                    Label_03AF:
                        flag = this.EditMode != DataSetEditMode.CheckData;
                        if (((uint) num2) < 0)
                        {
                            goto Label_03AF;
                        }
                        if ((((uint) num2) - ((uint) flag)) >= 0)
                        {
                            goto Label_0324;
                        }
                    Label_03EA:
                        num2 = pair.CalcedArray[num] - pair.IdealArray[num];
                        ErrorRec rec2 = recArray[num];
                        rec2.AvgErr += Math.Abs(num2);
                        if ((((uint) num2) | 4) == 0)
                        {
                            goto Label_04A7;
                        }
                        if ((((uint) flag) + ((uint) num)) <= uint.MaxValue)
                        {
                            goto Label_0358;
                        }
                    Label_0449:
                        if (3 != 0)
                        {
                            goto Label_0509;
                        }
                        goto Label_04DF;
                    Label_0458:
                        if (((uint) num) > uint.MaxValue)
                        {
                            goto Label_0509;
                        }
                        data6 = processor.RestoreIdealVector(data4);
                        num = 0;
                        goto Label_0342;
                    Label_047E:
                        pair.CalcedArray[num] = Math.Round(data6[num], 4);
                        goto Label_03AF;
                    Label_0498:
                        data = new BasicMLData(pair.InputArray);
                    Label_04A7:
                        data2 = processor.ProcessInputVector(data);
                        data4 = service.x5b0926ce641e48a7.Compute(data2);
                        IMLData data5 = processor.ProcessIdealVector(new BasicMLData(pair.IdealArray));
                        goto Label_0458;
                    Label_04DF:
                        pair = enumerator.Current;
                        goto Label_0498;
                    }
                    finally
                    {
                        flag = enumerator == null;
                        while (!flag)
                        {
                            enumerator.Dispose();
                            break;
                        }
                    }
                    goto Label_0509;
                }
            }
        Label_0598:
            recArray[num].RMEN = Math.Round(service.x5b0926ce641e48a7.CalculateError(processor.ProcessDataSet(this.Data)), 4);
            num++;
            goto Label_0546;
        }

        private void x2c196582986b2b4d(xa443afcc736e1f3e x0f2e289ed0560f6a)
        {
            this.RebuildGrid(this.DataCollection);
        }

        [CompilerGenerated]
        private static bool x2fdd156b5df88156(object x08db3aeabb253cb1)
        {
            return true;
        }

        private void x35c4ec3ae031eb9d()
        {
            x97d09efa0c4ea9c0.CalcData(this.Data);
        }

        private static void x383108da65379cdd(DependencyObject x73f821c71fe1e676, DependencyPropertyChangedEventArgs xfbf34718e704c6bc)
        {
            DataSetEditor editor = x73f821c71fe1e676 as DataSetEditor;
            Debug.Assert(editor != null, "o != null");
            editor.RebuildGrid(editor.DataCollection);
        }

        [CompilerGenerated]
        private void x3dae52cfd2174195(object x08db3aeabb253cb1)
        {
            this.x24dcbf47940a9def();
        }

        [CompilerGenerated]
        private void x40008dd57226f845(object x08db3aeabb253cb1)
        {
            this.x63f05b2556ac6889();
        }

        public void x443525895ac957ee(BasicMLDataSet x4a3f0a05c02f235f)
        {
            this.RebuildGrid(x4a3f0a05c02f235f);
        }

        private void x45ade0f9653c8a21()
        {
            this.DataCollection.Clear();
        }

        [CompilerGenerated]
        private void x5497871ee780721c(object x08db3aeabb253cb1)
        {
            this.x45ade0f9653c8a21();
        }

        [CompilerGenerated]
        private static bool x5e805ee32623ca41(object x08db3aeabb253cb1)
        {
            return true;
        }

        private static void x5fa0b53058746ce4()
        {
            ITrainData data;
            ITestData data2;
            IDataProcessor service = App.Services.GetService<IDataProcessor>();
            if (0 == 0)
            {
                data = App.Services.GetService<ITrainData>();
                data2 = App.Services.GetService<ITestData>();
            }
            BasicMLDataSet set = data.xd378208b5267f7e2();
            do
            {
                service.ConfigureProcessor(set);
                BasicMLDataSet set2 = service.ProcessDataSet(data.xd378208b5267f7e2());
                data2.x443525895ac957ee(set2);
            }
            while (0 != 0);
        }

        [CompilerGenerated]
        private bool x6219e10c5954e86b(object x08db3aeabb253cb1)
        {
            return (this.dataGrid.Items.Count > 0);
        }

        [DebuggerNonUserCode, EditorBrowsable(EditorBrowsableState.Never)]
        private void x628e6c716ec340be(int xf3efd21c486a5cce, object x11d58b056c032b03)
        {
            switch (xf3efd21c486a5cce)
            {
                case 1:
                    this.dataGrid = (DataGrid) x11d58b056c032b03;
                    break;

                case 2:
                    this.errorsGrid = (DataGrid) x11d58b056c032b03;
                    break;

                default:
                    this._x7dc3d9d322900926 = true;
                    break;
            }
        }

        private void x63f05b2556ac6889()
        {
            BasicMLDataSet set;
            int num;
            int num2;
            double num3;
            int num4;
            double num5;
            bool flag;
            System.Boolean ReflectorVariable0;
            this.dataGrid.SelectedItems.Clear();
            goto Label_02D3;
        Label_0016:
            if (num2 < set.Count)
            {
                num3 = 0.0;
                if ((((uint) num) + ((uint) num4)) < 0)
                {
                    goto Label_0178;
                }
                goto Label_0278;
            }
            num++;
        Label_002E:
            flag = num < set.Count;
            if (flag)
            {
                num2 = num + 1;
                goto Label_0016;
            }
            if (0 != 0)
            {
                goto Label_017D;
            }
            if (((uint) num2) <= uint.MaxValue)
            {
                goto Label_0282;
            }
        Label_0059:
            if (!flag)
            {
                goto Label_009D;
            }
            if ((((uint) flag) + ((uint) num3)) < 0)
            {
                goto Label_0278;
            }
        Label_0078:
            num2++;
            if ((((uint) num4) | 3) != 0)
            {
                goto Label_0016;
            }
            goto Label_0282;
        Label_009D:
            this.dataGrid.SelectedItems.Add(this.dataGrid.Items[num]);
            this.dataGrid.SelectedItems.Add(this.dataGrid.Items[num2]);
            goto Label_0078;
        Label_00F8:
            flag = ReflectorVariable0 ? (num5 <= 1.0) : true;
            if (1 != 0)
            {
                goto Label_0059;
            }
            if ((((uint) num2) - ((uint) num3)) <= uint.MaxValue)
            {
                goto Label_009D;
            }
            goto Label_0278;
        Label_0109:
            if ((((uint) flag) - ((uint) num4)) > uint.MaxValue)
            {
                goto Label_0216;
            }
            if ((((uint) num5) - ((uint) num5)) <= uint.MaxValue)
            {
                ReflectorVariable0 = true;
                goto Label_00F8;
            }
            goto Label_01DF;
        Label_0178:
            num4 = 0;
            goto Label_01B6;
        Label_017D:
            num5 += Math.Abs((double) (set.Data[num].IdealArray[num4] - set.Data[num2].IdealArray[num4]));
            num4++;
        Label_01B6:
            flag = num4 < set.IdealSize;
            if (flag)
            {
                goto Label_017D;
            }
            num5 /= (double) set.IdealSize;
            if (num3 >= 0.3)
            {
                ReflectorVariable0 = false;
                goto Label_00F8;
            }
            if ((((uint) num3) - ((uint) flag)) >= 0)
            {
                if ((((uint) num4) - ((uint) num5)) >= 0)
                {
                    goto Label_0109;
                }
            }
            else
            {
                goto Label_0178;
            }
        Label_01DF:
            num3 += Math.Abs((double) (set.Data[num].InputArray[num4] - set.Data[num2].InputArray[num4]));
            num4++;
        Label_0216:
            flag = num4 < set.InputSize;
            if (flag)
            {
                goto Label_01DF;
            }
            num3 /= (double) set.InputSize;
            num5 = 0.0;
            if ((((uint) num) + ((uint) num)) <= uint.MaxValue)
            {
                goto Label_0178;
            }
            goto Label_0109;
        Label_0278:
            num4 = 0;
            goto Label_0216;
        Label_0282:
            if (((uint) num) <= uint.MaxValue)
            {
                return;
            }
        Label_02D3:
            set = this.Data;
            if (((uint) flag) > uint.MaxValue)
            {
                goto Label_0078;
            }
            num = 0;
            goto Label_002E;
        }

        [CompilerGenerated]
        private void x6a79730e8feb8449(object x08db3aeabb253cb1)
        {
            this.xb9e224dc3deb4590();
        }

        private void x6f75cf9e3e261f46(object x0d173b5435b4d6ad)
        {
            this.x443525895ac957ee(((x03e29c1ee96cbf80) x0d173b5435b4d6ad).xd378208b5267f7e2());
        }

        [CompilerGenerated]
        private bool x72fba2c521568a89(object x08db3aeabb253cb1)
        {
            return (this.dataGrid.SelectedItems.Count > 0);
        }

        [CompilerGenerated]
        private bool x75b3ed0206e18762(object x08db3aeabb253cb1)
        {
            return ((this.DataCollection.Count > 0) && (this.EditMode != DataSetEditMode.TrainData));
        }

        [CompilerGenerated]
        private static void x7efa4e5559b296a8(object x08db3aeabb253cb1)
        {
            x5fa0b53058746ce4();
        }

        [CompilerGenerated]
        private static bool x82cc36077d6dc905(object x08db3aeabb253cb1)
        {
            return true;
        }

        private void x9421b72207ddef01()
        {
            // This item is obfuscated and can not be translated.
            OpenFileDialog dialog = new OpenFileDialog {
                Filter = "Файлы Excel|*.xls;*.xlsx"
            };
            bool flag = dialog.ShowDialog(Application.Current.MainWindow) != false;
            if (((((uint) flag) + ((uint) flag)) <= uint.MaxValue) && ((0 == 0) && flag))
            {
                BasicMLDataSet set = null;
                if (this.EditMode == DataSetEditMode.CalcData)
                {
                }
                set = xe8f63ddfa545c93b.xba08e03b3c6894f3(dialog.FileName);
                if (set != null)
                {
                    this.Data = set;
                }
            }
        }

        [CompilerGenerated]
        private static bool xa715e88b18293df4(object x08db3aeabb253cb1)
        {
            return true;
        }

        [CompilerGenerated]
        private void xa7814e797b93d963(object x08db3aeabb253cb1)
        {
            this.x2977a400fde1078f();
        }

        [CompilerGenerated]
        private bool xb4b2aacd379b5426(object x08db3aeabb253cb1)
        {
            return (this.DataCollection.Count > 0);
        }

        private void xb9e224dc3deb4590()
        {
            // This item is obfuscated and can not be translated.
        }

        [CompilerGenerated]
        private static bool xbda67ddd00586667(object x08db3aeabb253cb1)
        {
            return true;
        }

        [CompilerGenerated]
        private void xc1b6e207a2b2ff30(object x08db3aeabb253cb1)
        {
            this.xd6b9f476eb4e7c7e();
        }

        private void xc7fab1a2c53016c3(object x0d173b5435b4d6ad)
        {
            this.x443525895ac957ee(((x03e29c1ee96cbf80) x0d173b5435b4d6ad).xd378208b5267f7e2());
        }

        private void xd2726b43b7407df0(object x0d173b5435b4d6ad)
        {
            DataSetEditor editor = x0d173b5435b4d6ad as DataSetEditor;
            bool flag = editor != null;
            if (flag)
            {
                List<IMLDataPair> list = editor.dataGrid.SelectedItems.OfType<IMLDataPair>().ToList<IMLDataPair>();
                do
                {
                    using (List<IMLDataPair>.Enumerator enumerator = list.GetEnumerator())
                    {
                        IMLDataPair current;
                        goto Label_0052;
                    Label_0036:
                        this.DataCollection.Add(current);
                        editor.DataCollection.Remove(current);
                    Label_0052:
                        flag = enumerator.MoveNext();
                        if (flag)
                        {
                            do
                            {
                                current = enumerator.Current;
                            }
                            while (0 != 0);
                            if (-1 != 0)
                            {
                                goto Label_0036;
                            }
                        }
                    }
                }
                while ((((uint) flag) - ((uint) flag)) > uint.MaxValue);
            }
        }

        public BasicMLDataSet xd378208b5267f7e2()
        {
            return new BasicMLDataSet(this.DataCollection);
        }

        private void xd6b9f476eb4e7c7e()
        {
            foreach (BasicMLDataPair pair in this.dataGrid.SelectedItems.OfType<BasicMLDataPair>().ToList<BasicMLDataPair>())
            {
                bool flag;
                this.DataCollection.Remove(pair);
                if ((((uint) flag) + ((uint) flag)) >= 0)
                {
                }
            }
        }

        [CompilerGenerated]
        private static bool xd8d13527c95844b9(object x08db3aeabb253cb1)
        {
            return true;
        }

        [CompilerGenerated]
        private void xda696b000c6b2eb1(object x08db3aeabb253cb1)
        {
            this.x260f84eca0a6e365();
        }

        [CompilerGenerated]
        private static bool xe327757dd6fbad56(object x08db3aeabb253cb1)
        {
            return true;
        }

        [CompilerGenerated]
        private static bool xfbfe3d8604786a5c(object x08db3aeabb253cb1)
        {
            return true;
        }

        [CompilerGenerated]
        private static bool xfcaf281897a61939(object x08db3aeabb253cb1)
        {
            return true;
        }

        public ICommand AddDataRow
        {
            get
            {
                // This item is obfuscated and can not be translated.
            }
        }

        public ICommand Calc
        {
            get
            {
                return (this._xbffe93d292afae56 ?? (this._xbffe93d292afae56 = new RelayCommand(new Action<object>(this.xa7814e797b93d963), new Predicate<object>(this.x75b3ed0206e18762))));
            }
        }

        public int CalcedSize
        {
            get
            {
                return this.IdealSize;
            }
        }

        public ICommand CalcSignificance
        {
            get
            {
                // This item is obfuscated and can not be translated.
            }
        }

        public ICommand ClearData
        {
            get
            {
                return (this._x219ea743faaa7304 ?? (this._x219ea743faaa7304 = new RelayCommand(new Action<object>(this.x5497871ee780721c), new Predicate<object>(this.x6219e10c5954e86b))));
            }
        }

        public ICommand CopyFrom
        {
            get
            {
                // This item is obfuscated and can not be translated.
            }
        }

        public ICommand CopyFromTest
        {
            get
            {
                // This item is obfuscated and can not be translated.
            }
        }

        public ICommand CopyProcessed
        {
            get
            {
                // This item is obfuscated and can not be translated.
            }
        }

        public BasicMLDataSet Data
        {
            get
            {
                return this.xd378208b5267f7e2();
            }
            set
            {
                this.RebuildGrid(value);
            }
        }

        protected ObservableCollection<IMLDataPair> DataCollection
        {
            get
            {
                return (this.dataGrid.ItemsSource as ObservableCollection<IMLDataPair>);
            }
            set
            {
                this.dataGrid.ItemsSource = value;
            }
        }

        public DataSetEditMode EditMode
        {
            get
            {
                return (DataSetEditMode) base.GetValue(EditModeProperty);
            }
            set
            {
                base.SetValue(EditModeProperty, value);
            }
        }

        public int ErrorSize
        {
            get
            {
                return this.IdealSize;
            }
        }

        public ICommand ExportToExcel
        {
            get
            {
                return (this._x36a24525a42af546 ?? (this._x36a24525a42af546 = new RelayCommand(new Action<object>(this.x3dae52cfd2174195), new Predicate<object>(this.xb4b2aacd379b5426))));
            }
        }

        public ICommand FindMavericks
        {
            get
            {
                // This item is obfuscated and can not be translated.
            }
        }

        public int IdealSize
        {
            get
            {
                return App.Services.GetService<INetStruct>().OutputLayer.Size;
            }
        }

        public ICommand ImportFromExcel
        {
            get
            {
                // This item is obfuscated and can not be translated.
            }
        }

        public int InputSize
        {
            get
            {
                return App.Services.GetService<INetStruct>().InputLayer.Size;
            }
        }

        public ICommand MarkConflictSamples
        {
            get
            {
                // This item is obfuscated and can not be translated.
            }
        }

        public ICommand MoveFrom
        {
            get
            {
                // This item is obfuscated and can not be translated.
            }
        }

        public ICommand RemoveDataRow
        {
            get
            {
                return (this._x15dca715f4511af0 ?? (this._x15dca715f4511af0 = new RelayCommand(new Action<object>(this.xc1b6e207a2b2ff30), new Predicate<object>(this.x72fba2c521568a89))));
            }
        }

        public XElement Xml
        {
            get
            {
                bool flag;
                XElement element = new XElement("DataSet");
                IEnumerator<IMLDataPair> enumerator = this.DataCollection.GetEnumerator();
                try
                {
                    IMLDataPair pair;
                    XElement element2;
                    goto Label_0026;
                Label_0021:
                    if (0 != 0)
                    {
                        goto Label_0055;
                    }
                Label_0026:
                    flag = enumerator.MoveNext();
                Label_002F:
                    if (flag)
                    {
                        goto Label_0173;
                    }
                    goto Label_0086;
                Label_0038:
                    if (((uint) flag) >= 0)
                    {
                        goto Label_0055;
                    }
                    if (0x7fffffff == 0)
                    {
                        goto Label_0026;
                    }
                Label_0051:
                    if (!flag)
                    {
                        goto Label_005E;
                    }
                Label_0055:
                    element.Add(element2);
                    goto Label_0021;
                Label_005E:
                    element2.Add(pair.ErrorArray.ToXElement().AddContent("Error".ToNameAttribute()));
                    if (0 != 0)
                    {
                        goto Label_002F;
                    }
                    goto Label_0038;
                Label_0086:
                    if (0xff != 0)
                    {
                        goto Label_0101;
                    }
                    goto Label_00CF;
                Label_0092:
                    flag = pair.ErrorArray == null;
                    goto Label_0051;
                Label_009F:
                    if (0xff != 0)
                    {
                        goto Label_00C9;
                    }
                Label_00A6:
                    element2.Add(pair.CalcedArray.ToXElement().AddContent("Calced".ToNameAttribute()));
                    goto Label_0092;
                Label_00C9:
                    if (!flag)
                    {
                        goto Label_00A6;
                    }
                    goto Label_0092;
                Label_00CF:
                    if (!flag)
                    {
                        element2.Add(pair.IdealArray.ToXElement().AddContent("Ideal".ToNameAttribute()));
                    }
                    flag = pair.CalcedArray == null;
                    goto Label_009F;
                Label_0101:
                    if ((((uint) flag) & 0) == 0)
                    {
                        return element;
                    }
                    goto Label_0173;
                Label_0118:
                    flag = pair.IdealArray == null;
                    goto Label_00CF;
                Label_0125:
                    element2 = new XElement("DataRow");
                    if (1 == 0)
                    {
                        goto Label_0092;
                    }
                    if (pair.InputArray != null)
                    {
                        element2.Add(pair.InputArray.ToXElement().AddContent("Input".ToNameAttribute()));
                    }
                    goto Label_0118;
                Label_0173:
                    pair = enumerator.Current;
                    goto Label_0125;
                }
                finally
                {
                    flag = enumerator == null;
                    if ((((uint) flag) & 0) == 0)
                    {
                        while (!flag)
                        {
                            enumerator.Dispose();
                            break;
                        }
                    }
                }
                return element;
            }
            set
            {
                bool flag;
                XElement element = value;
                BasicMLDataSet set = new BasicMLDataSet();
                IEnumerator<XElement> enumerator = element.Elements("DataRow").GetEnumerator();
                try
                {
                    XElement element2;
                    goto Label_00B4;
                Label_0025:
                    element2 = enumerator.Current;
                    set.Add(new BasicMLDataPair(new BasicMLData(element2.Elements().ByName("Input").AsArray()), new BasicMLData(element2.Elements().ByName("Ideal").AsArray()), new BasicMLData(element2.Elements().ByName("Calced").AsArray()), new BasicMLData(element2.Elements().ByName("Error").AsArray())));
                    while (((uint) flag) < 0)
                    {
                    }
                Label_00B4:
                    flag = enumerator.MoveNext();
                    if (flag)
                    {
                        goto Label_0025;
                    }
                }
                finally
                {
                    flag = enumerator == null;
                    if (2 != 0)
                    {
                        goto Label_00F3;
                    }
                    if ((((uint) flag) + ((uint) flag)) > uint.MaxValue)
                    {
                        goto Label_00F7;
                    }
                Label_00EA:
                    enumerator.Dispose();
                    goto Label_00F7;
                Label_00F3:
                    if (!flag)
                    {
                        goto Label_00EA;
                    }
                Label_00F7:;
                }
                this.x443525895ac957ee(set);
            }
        }

        public class ErrorRec
        {
            [CompilerGenerated]
            private double x08b9feeb8158bb8f;
            [CompilerGenerated]
            private double x39f0b6bd665e996a;
            [CompilerGenerated]
            private string x84ae50e55afbb83e;
            [CompilerGenerated]
            private double x9d154d400e4ec4bb;
            [CompilerGenerated]
            private double xdda59041d192844c;

            public double AvgErr
            {
                [CompilerGenerated]
                get
                {
                    return this.x08b9feeb8158bb8f;
                }
                [CompilerGenerated]
                set
                {
                    this.x08b9feeb8158bb8f = value;
                }
            }

            public double MaxErr
            {
                [CompilerGenerated]
                get
                {
                    return this.x39f0b6bd665e996a;
                }
                [CompilerGenerated]
                set
                {
                    this.x39f0b6bd665e996a = value;
                }
            }

            public double RME
            {
                [CompilerGenerated]
                get
                {
                    return this.xdda59041d192844c;
                }
                [CompilerGenerated]
                set
                {
                    this.xdda59041d192844c = value;
                }
            }

            public double RMEN
            {
                [CompilerGenerated]
                get
                {
                    return this.x9d154d400e4ec4bb;
                }
                [CompilerGenerated]
                set
                {
                    this.x9d154d400e4ec4bb = value;
                }
            }

            public string Title
            {
                [CompilerGenerated]
                get
                {
                    return this.x84ae50e55afbb83e;
                }
                [CompilerGenerated]
                set
                {
                    this.x84ae50e55afbb83e = value;
                }
            }
        }
    }
}

