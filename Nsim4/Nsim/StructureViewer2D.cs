namespace Nsim
{
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Markup;
    using System.Windows.Media;
    using System.Windows.Shapes;

    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    public class StructureViewer2D : UserControl, System.Windows.Markup.IComponentConnector
    {
        private bool _x7dc3d9d322900926;
        private readonly List<UIElement> _x929312ef8641a34b = new List<UIElement>();
        internal Canvas canvas;
        [CompilerGenerated]
        private static Func<ILayerStruct, int> x52e0eb7265061ab4;
        private static readonly Brush x96cd9c275173e5db = Brushes.DarkBlue;
        private const double xc46af5788022f70e = 20.0;

        public StructureViewer2D()
        {
            this.InitializeComponent();
            App.Services.SubscribeEvent<xa443afcc736e1f3e>(new Action<xa443afcc736e1f3e>(this.x2c196582986b2b4d));
            this.RebuldView();
        }

        [DebuggerNonUserCode]
        public void InitializeComponent()
        {
            bool flag = !this._x7dc3d9d322900926;
            if ((((uint) flag) + ((uint) flag)) >= 0)
            {
                goto Label_0062;
            }
        Label_0023:
            if (((((uint) flag) + ((uint) flag)) < 0) || (0 == 0))
            {
                return;
            }
        Label_0062:
            while (flag)
            {
                this._x7dc3d9d322900926 = true;
                Uri resourceLocator = new Uri("/Nsim4;component/components/structure/viewer/structureviewer2d.xaml", UriKind.Relative);
                Application.LoadComponent(this, resourceLocator);
                goto Label_0023;
            }
        }

        public void RebuldView()
        {
            List<Point> list;
            double num3;
            double num4;
            int num5;
            Ellipse ellipse;
            Line current;
            Ellipse ellipse4;
            <>c__DisplayClassa classa;
            bool flag;
            IEnumerator<Line> enumerator3;
            INetStruct service = App.Services.GetService<INetStruct>();
            int num = service.HiddenLayers.Layers.Count<ILayerStruct>() + 2;
            int size = service.InputLayer.Size;
            if (((uint) num3) >= 0)
            {
                flag = service.OutputLayer.Size <= size;
                while (!flag)
                {
                    size = service.OutputLayer.Size;
                    break;
                }
            }
            if (x52e0eb7265061ab4 == null)
            {
                x52e0eb7265061ab4 = new Func<ILayerStruct, int>(null, (IntPtr) x2b9ae66d393d74b1);
            }
            size = Enumerable.Select<ILayerStruct, int>(service.HiddenLayers.Layers, x52e0eb7265061ab4).Concat<int>(new int[] { size }).Max();
            if ((((uint) num3) + ((uint) num5)) < 0)
            {
                goto Label_012A;
            }
            this.canvas.Width = (num * 20.0) * 2.0;
            this.canvas.Height = (size * 20.0) * 2.0;
            this.canvas.UpdateLayout();
            if ((((uint) num4) + ((uint) num5)) >= 0)
            {
                using (List<UIElement>.Enumerator enumerator = this._x929312ef8641a34b.GetEnumerator())
                {
                    UIElement element;
                    goto Label_0749;
                Label_0715:
                    element = enumerator.Current;
                    this.canvas.Children.Remove(element);
                    if ((((uint) num5) | 0xfffffffe) == 0)
                    {
                        goto Label_0752;
                    }
                Label_0749:
                    flag = enumerator.MoveNext();
                Label_0752:
                    if (flag)
                    {
                        goto Label_0715;
                    }
                    goto Label_06CB;
                }
                if ((((uint) num) + ((uint) flag)) >= 0)
                {
                    if ((((uint) size) - ((uint) num4)) < 0)
                    {
                        goto Label_0038;
                    }
                    goto Label_06CB;
                }
            }
            goto Label_052F;
        Label_0038:
            flag = num5 < service.OutputLayer.Size;
            if ((((uint) flag) + ((uint) num)) < 0)
            {
                goto Label_0604;
            }
            if (((uint) num3) <= uint.MaxValue)
            {
                if (!flag)
                {
                    return;
                }
                Point point;
                ellipse4 = new Ellipse {
                    Fill = Brushes.Orange,
                    Width = 20.0
                };
                goto Label_01A4;
            }
            return;
        Label_0069:
            point = new Point(num3, num4 + (num5 * 40.0));
            using (enumerator3 = Enumerable.Select<Point, Line>(list, new Func<Point, Line>(classa, (IntPtr) this.<RebuldView>b__6)).GetEnumerator())
            {
                while (enumerator3.MoveNext())
                {
                    current = enumerator3.Current;
                    do
                    {
                        this._x929312ef8641a34b.Add(current);
                    }
                    while (3 == 0);
                    this.canvas.Children.Add(current);
                }
            }
            this._x929312ef8641a34b.Add(ellipse);
            this.canvas.Children.Add(ellipse);
            num5++;
            goto Label_0038;
        Label_011D:
            ellipse4.Stroke = x96cd9c275173e5db;
        Label_012A:
            ellipse = ellipse4;
            Canvas.SetLeft(ellipse, num3);
            if (((uint) num3) < 0)
            {
                goto Label_011D;
            }
            if ((((uint) size) | 8) == 0)
            {
                goto Label_04D0;
            }
        Label_0165:
            Canvas.SetTop(ellipse, num4 + (num5 * 40.0));
            goto Label_0069;
        Label_01A4:
            ellipse4.Height = 20.0;
            goto Label_011D;
        Label_04C1:
            num3 += 40.0;
        Label_04D0:
            num4 = ((this.canvas.ActualHeight / 2.0) - ((((double) service.OutputLayer.Size) / 2.0) * 40.0)) + 10.0;
            if ((((uint) size) - ((uint) num5)) <= uint.MaxValue)
            {
                num5 = 0;
                goto Label_0038;
            }
            goto Label_0069;
        Label_052F:
            if (num5 < service.InputLayer.Size)
            {
                ellipse = new Ellipse {
                    Fill = Brushes.DeepPink,
                    Width = 20.0,
                    Height = 20.0,
                    Stroke = x96cd9c275173e5db
                };
                Canvas.SetLeft(ellipse, num3);
                Canvas.SetTop(ellipse, num4 + (num5 * 40.0));
            }
            else
            {
                if (((uint) num) > uint.MaxValue)
                {
                    goto Label_0165;
                }
                IEnumerator<ILayerStruct> enumerator2 = service.HiddenLayers.Layers.GetEnumerator();
                try
                {
                    ILayerStruct struct3;
                    List<Point> list2;
                    Ellipse ellipse3;
                    <>c__DisplayClass8 class2;
                    goto Label_020A;
                Label_01E7:
                    if (flag)
                    {
                        goto Label_03BF;
                    }
                    if ((((uint) num4) - ((uint) num5)) > uint.MaxValue)
                    {
                        goto Label_03C6;
                    }
                Label_020A:
                    flag = enumerator2.MoveNext();
                    if (flag)
                    {
                        goto Label_043D;
                    }
                    if ((((uint) num) + ((uint) flag)) >= 0)
                    {
                        goto Label_033B;
                    }
                    goto Label_0281;
                Label_0237:
                    list.Add(class2.point);
                Label_0246:
                    this._x929312ef8641a34b.Add(ellipse);
                    this.canvas.Children.Add(ellipse);
                    num5++;
                Label_026F:
                    flag = num5 < struct3.Size;
                    goto Label_01E7;
                Label_0281:
                    class2.point = new Point(num3, num4 + (num5 * 40.0));
                    using (enumerator3 = Enumerable.Select<Point, Line>(list2, new Func<Point, Line>(class2, (IntPtr) this.<RebuldView>b__5)).GetEnumerator())
                    {
                        goto Label_02FE;
                    Label_02C3:
                        if ((((uint) num) + ((uint) size)) <= uint.MaxValue)
                        {
                            this._x929312ef8641a34b.Add(current);
                        }
                        this.canvas.Children.Add(current);
                    Label_02FE:
                        if (enumerator3.MoveNext())
                        {
                            current = enumerator3.Current;
                            goto Label_02C3;
                        }
                    }
                    goto Label_0237;
                Label_033B:
                    if (((uint) num) >= 0)
                    {
                        goto Label_04C1;
                    }
                    goto Label_03BF;
                Label_0352:
                    ellipse3.Stroke = x96cd9c275173e5db;
                    ellipse3.Width = 20.0;
                    ellipse3.Height = 20.0;
                    ellipse = ellipse3;
                    Canvas.SetLeft(ellipse, num3);
                    Canvas.SetTop(ellipse, num4 + (num5 * 40.0));
                    if ((((uint) num4) + ((uint) num4)) >= 0)
                    {
                        goto Label_0401;
                    }
                Label_03BF:
                    class2 = new <>c__DisplayClass8();
                Label_03C6:
                    ellipse3 = new Ellipse();
                    if ((((uint) num4) + ((uint) size)) < 0)
                    {
                        goto Label_0434;
                    }
                    if (-1 == 0)
                    {
                        goto Label_0246;
                    }
                    ellipse3.Fill = Brushes.Gold;
                    goto Label_0352;
                Label_0401:
                    if ((((uint) num) | uint.MaxValue) != 0)
                    {
                        goto Label_0281;
                    }
                    goto Label_04C1;
                Label_041E:
                    if (0 != 0)
                    {
                        goto Label_0246;
                    }
                    list2 = list.ToList<Point>();
                    list.Clear();
                Label_0434:
                    num5 = 0;
                    goto Label_026F;
                Label_043D:
                    struct3 = enumerator2.Current;
                    num3 += 40.0;
                    num4 = ((this.canvas.ActualHeight / 2.0) - ((((double) struct3.Size) / 2.0) * 40.0)) + 10.0;
                    goto Label_041E;
                }
                finally
                {
                    flag = enumerator2 == null;
                    if (((uint) num) <= uint.MaxValue)
                    {
                        while (!flag)
                        {
                            enumerator2.Dispose();
                            break;
                        }
                    }
                }
                goto Label_04C1;
            }
        Label_0604:
            list.Add(new Point(num3, num4 + (num5 * 40.0)));
            if (((uint) num3) > uint.MaxValue)
            {
                goto Label_01A4;
            }
            this._x929312ef8641a34b.Add(ellipse);
            this.canvas.Children.Add(ellipse);
            num5++;
            goto Label_052F;
        Label_06CB:
            this._x929312ef8641a34b.Clear();
            list = new List<Point>();
            if ((((uint) size) - ((uint) num4)) > uint.MaxValue)
            {
                return;
            }
            num3 = 10.0;
            num4 = ((this.canvas.ActualHeight / 2.0) - ((((double) service.InputLayer.Size) / 2.0) * 40.0)) + 10.0;
            num5 = 0;
            goto Label_052F;
        }

        [CompilerGenerated]
        private static int x2b9ae66d393d74b1(ILayerStruct x98da6ccbcd45ba73)
        {
            return x98da6ccbcd45ba73.Size;
        }

        private void x2c196582986b2b4d(xa443afcc736e1f3e x0f2e289ed0560f6a)
        {
            this.RebuldView();
        }

        [EditorBrowsable(EditorBrowsableState.Never), DebuggerNonUserCode]
        private void x628e6c716ec340be(int xf3efd21c486a5cce, object x11d58b056c032b03)
        {
            int num = xf3efd21c486a5cce;
            while ((((uint) num) - ((uint) num)) >= 0)
            {
                if (num == 1)
                {
                    this.canvas = (Canvas) x11d58b056c032b03;
                    return;
                }
            Label_0017:
                this._x7dc3d9d322900926 = true;
                return;
            }
            if (((uint) num) >= 0)
            {
            }
            goto Label_0017;
        }

        private static Line xa27fac46e21ed5f4(Point x54acfcf5460fb360, Point x08eef91ccd7eb033)
        {
            Line line2 = new Line {
                X1 = x54acfcf5460fb360.X + 10.0,
                Y1 = x54acfcf5460fb360.Y + 10.0,
                X2 = x08eef91ccd7eb033.X + 10.0,
                Y2 = x08eef91ccd7eb033.Y + 10.0
            };
            if (-2147483648 == 0)
            {
                Line line3;
                return line3;
            }
            line2.Fill = x96cd9c275173e5db;
            line2.Stroke = x96cd9c275173e5db;
            Line element = line2;
            Panel.SetZIndex(element, -1);
            return element;
        }
    }
}

