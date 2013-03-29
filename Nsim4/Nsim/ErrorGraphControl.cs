namespace Nsim
{
    using Microsoft.Research.DynamicDataDisplay;
    using Microsoft.Research.DynamicDataDisplay.DataSources;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Markup;
    using System.Xml.Linq;

    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    public class ErrorGraphControl : UserControl, IConfigurable, System.Windows.Markup.IComponentConnector, x9d88849cdb32703c
    {
        private readonly Dictionary<ErrorDescriptor, ObservableDataSource<Point>> _x57768d690e5bd0fc = new Dictionary<ErrorDescriptor, ObservableDataSource<Point>>();
        private bool _x7dc3d9d322900926;
        internal ChartPlotter plotter;
        [CompilerGenerated]
        private static Func<Point, Point> x52e0eb7265061ab4;
        [CompilerGenerated]
        private static Func<XElement, Point> xcb5110745db8648f;

        public ErrorGraphControl()
        {
            this.InitializeComponent();
            App.Services.RegisterService<x9d88849cdb32703c>(this);
            this.plotter.set_LegendVisibility(Visibility.Collapsed);
            this.plotter.set_NewLegendVisible(false);
        }

        public void Clear()
        {
            this._x57768d690e5bd0fc.Clear();
            this.plotter.get_Children().RemoveAll<IPlotterElement>(typeof(LineGraph));
            GC.Collect();
        }

        [DebuggerNonUserCode]
        public void InitializeComponent()
        {
            if (!this._x7dc3d9d322900926)
            {
                Uri uri;
                do
                {
                    this._x7dc3d9d322900926 = true;
                    uri = new Uri("/Nsim4;component/components/train/errorgraph/errorgraphcontrol.xaml", UriKind.Relative);
                }
                while (0 != 0);
                Application.LoadComponent(this, uri);
            }
        }

        private void x04abae94658fc85d(object xe0292b9ed559da7d, RoutedEventArgs xfbf34718e704c6bc)
        {
            int num;
            StringBuilder builder = new StringBuilder();
            List<Point> list = null;
            bool flag = this._x57768d690e5bd0fc[ErrorDescriptor.TestError] == null;
            if (((uint) num) <= uint.MaxValue)
            {
                double x;
                do
                {
                    if (!flag)
                    {
                        list = this._x57768d690e5bd0fc[ErrorDescriptor.TestError].GetPoints().ToList<Point>();
                    }
                    do
                    {
                        num = 0;
                        IEnumerator<Point> enumerator = this._x57768d690e5bd0fc[ErrorDescriptor.TrainError].GetPoints().GetEnumerator();
                        try
                        {
                            Point point;
                            string str;
                            Point point2;
                        Label_0037:
                            flag = enumerator.MoveNext();
                            if (flag)
                            {
                                goto Label_008E;
                            }
                            break;
                        Label_0046:
                            if (!flag)
                            {
                                goto Label_0057;
                            }
                        Label_004A:
                            builder.AppendLine(str);
                            goto Label_0037;
                        Label_0057:
                            point2 = list[num++];
                            str = str + "\t" + point2.Y;
                            goto Label_004A;
                        Label_0082:
                            flag = list == null;
                            goto Label_0046;
                        Label_008E:
                            point = enumerator.Current;
                            x = point.X;
                            x = point.Y;
                            str = x.ToString() + "\t" + x.ToString();
                            goto Label_0082;
                        }
                        finally
                        {
                            flag = enumerator == null;
                            goto Label_015D;
                        Label_00D3:
                            if ((((uint) x) + ((uint) x)) > uint.MaxValue)
                            {
                                goto Label_0108;
                            }
                            goto Label_017D;
                        Label_00F0:
                            if ((((uint) num) | 0x80000000) != 0)
                            {
                                goto Label_00D3;
                            }
                        Label_0108:
                            if ((((uint) num) - ((uint) num)) < 0)
                            {
                                goto Label_015D;
                            }
                            if (1 != 0)
                            {
                                goto Label_017D;
                            }
                            goto Label_00D3;
                        Label_012B:
                            enumerator.Dispose();
                            if (((uint) num) >= 0)
                            {
                                goto Label_0108;
                            }
                            if ((((uint) x) + ((uint) x)) < 0)
                            {
                                goto Label_012B;
                            }
                        Label_015D:
                            if (!flag)
                            {
                                goto Label_012B;
                            }
                            if ((((uint) x) & 0) == 0)
                            {
                                goto Label_00F0;
                            }
                            goto Label_00D3;
                        Label_017D:;
                        }
                    }
                    while (0 != 0);
                    Clipboard.SetText(builder.ToString());
                }
                while ((((uint) x) + ((uint) num)) > uint.MaxValue);
            }
        }

        public void x2800617c7cbf536c(ErrorDescriptor x434d17a92dcc4de8, IEnumerable<Point> x0788cd5a9865fc16)
        {
            bool flag = x0788cd5a9865fc16 != null;
            goto Label_00AC;
        Label_000E:
            while ((((uint) flag) + ((uint) flag)) < 0)
            {
            }
            if (3 != 0)
            {
                goto Label_00A5;
            }
            goto Label_006C;
        Label_0033:
            this.x628399c54373f8c5(x434d17a92dcc4de8);
            if ((((uint) flag) - ((uint) flag)) < 0)
            {
                goto Label_000E;
            }
        Label_0058:
            this._x57768d690e5bd0fc[x434d17a92dcc4de8].AppendMany(x0788cd5a9865fc16);
            goto Label_009F;
        Label_006C:
            flag = this._x57768d690e5bd0fc.ContainsKey(x434d17a92dcc4de8);
            if (((uint) flag) >= 0)
            {
                if (!flag)
                {
                    goto Label_0033;
                }
                goto Label_0058;
            }
            if ((((uint) flag) & 0) == 0)
            {
                goto Label_0033;
            }
        Label_009F:
            if (0 == 0)
            {
                goto Label_000E;
            }
        Label_00A5:
            if (-2 != 0)
            {
                return;
            }
        Label_00AC:
            if (((2 != 0) && flag) && ((((uint) flag) + ((uint) flag)) >= 0))
            {
                goto Label_006C;
            }
        }

        private void x628399c54373f8c5(ErrorDescriptor x0474811406941040)
        {
            ObservableDataSource<Point> pointSource = new ObservableDataSource<Point>();
            if (x52e0eb7265061ab4 == null)
            {
                x52e0eb7265061ab4 = new Func<Point, Point>(null, (IntPtr) x774200d4f81f4b4c);
            }
            pointSource.SetXYMapping(x52e0eb7265061ab4);
            this.plotter.AddLineGraph(pointSource, x0474811406941040.Color, 2.0, x0474811406941040.Title);
            this._x57768d690e5bd0fc.Add(x0474811406941040, pointSource);
            this.plotter.InvalidateVisual();
        }

        [DebuggerNonUserCode, EditorBrowsable(EditorBrowsableState.Never)]
        private void x628e6c716ec340be(int xf3efd21c486a5cce, object x11d58b056c032b03)
        {
            int num = xf3efd21c486a5cce;
        Label_0052:
            switch (num)
            {
                case 1:
                    this.plotter = (ChartPlotter) x11d58b056c032b03;
                    break;

                case 2:
                    ((Button) x11d58b056c032b03).Click += new RoutedEventHandler(this.x04abae94658fc85d);
                    break;

                default:
                    this._x7dc3d9d322900926 = true;
                    if ((((uint) num) + ((uint) num)) >= 0)
                    {
                        break;
                    }
                    goto Label_0052;
            }
        }

        public void x684ac10cd014df82()
        {
            this.plotter.FitToView();
        }

        [CompilerGenerated]
        private static Point x774200d4f81f4b4c(Point x9c79b5ad7b769b12)
        {
            return x9c79b5ad7b769b12;
        }

        [CompilerGenerated]
        private static Point xdeb098800b3ee141(XElement x08db3aeabb253cb1)
        {
            return new Point(x08db3aeabb253cb1.Attribute("X").AsDouble(0.0), x08db3aeabb253cb1.Attribute("Y").AsDouble(0.0));
        }

        public XElement Xml
        {
            get
            {
                XElement element = new XElement("ErrorGraphData");
                using (Dictionary<ErrorDescriptor, ObservableDataSource<Point>>.Enumerator enumerator = this._x57768d690e5bd0fc.GetEnumerator())
                {
                    KeyValuePair<ErrorDescriptor, ObservableDataSource<Point>> pair;
                    XElement element2;
                    bool flag;
                    goto Label_0135;
                Label_0024:
                    if (flag)
                    {
                        goto Label_0140;
                    }
                    return element;
                Label_0030:
                    element2 = new XElement("DataSeries", new XAttribute("Id", pair.Key.Id));
                    using (IEnumerator<Point> enumerator2 = pair.Value.Collection.GetEnumerator())
                    {
                        Point point;
                        goto Label_00F3;
                    Label_0075:
                        point = enumerator2.Current;
                        element2.Add(new XElement("Point", new object[] { new XAttribute("X", point.X), new XAttribute("Y", point.Y) }));
                        if ((((uint) flag) - ((uint) flag)) <= uint.MaxValue)
                        {
                        }
                    Label_00F3:
                        flag = enumerator2.MoveNext();
                        if (flag)
                        {
                            goto Label_0075;
                        }
                    }
                    do
                    {
                        element.Add(element2);
                    }
                    while (((uint) flag) > uint.MaxValue);
                Label_0135:
                    flag = enumerator.MoveNext();
                    goto Label_0024;
                Label_0140:
                    pair = enumerator.Current;
                    if ((((uint) flag) & 0) == 0)
                    {
                        goto Label_0030;
                    }
                    goto Label_0024;
                }
            }
            set
            {
                this.Clear();
                bool flag = value != null;
                if (flag && ((((uint) flag) - ((uint) flag)) >= 0))
                {
                    IEnumerator<XElement> enumerator = value.Elements("DataSeries").GetEnumerator();
                    try
                    {
                        <>c__DisplayClass4 class2;
                        Func<ErrorDescriptor, bool> func = null;
                        goto Label_003D;
                    Label_002A:
                        if (enumerator.MoveNext())
                        {
                            goto Label_0045;
                        }
                        if (0 != 0)
                        {
                            goto Label_0078;
                        }
                        return;
                    Label_003D:
                        class2 = new <>c__DisplayClass4();
                        goto Label_002A;
                    Label_0045:
                        class2.element = enumerator.Current;
                        if (func == null)
                        {
                            func = new Func<ErrorDescriptor, bool>(class2, (IntPtr) this.<set_Xml>b__0);
                        }
                        ErrorDescriptor descriptor = Enumerable.FirstOrDefault<ErrorDescriptor>(ErrorDescriptor.All, func);
                        this.x628399c54373f8c5(descriptor);
                    Label_0078:
                        if (xcb5110745db8648f == null)
                        {
                            xcb5110745db8648f = new Func<XElement, Point>(null, (IntPtr) xdeb098800b3ee141);
                        }
                        this.x2800617c7cbf536c(descriptor, Enumerable.Select<XElement, Point>(class2.element.Elements("Point"), xcb5110745db8648f));
                        goto Label_002A;
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
            }
        }
    }
}

