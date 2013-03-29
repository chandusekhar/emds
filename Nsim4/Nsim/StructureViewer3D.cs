namespace Nsim
{
    using _3DTools;
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
    using System.Windows.Media.Media3D;

    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    public class StructureViewer3D : UserControl, System.Windows.Markup.IComponentConnector
    {
        private bool _x7dc3d9d322900926;
        private readonly List<Visual3D> _x929312ef8641a34b = new List<Visual3D>();
        internal PerspectiveCamera cam1;
        internal Viewport3D port;
        [CompilerGenerated]
        private static Func<ILayerStruct, int> x52e0eb7265061ab4;

        public StructureViewer3D()
        {
            this.InitializeComponent();
            App.Services.SubscribeEvent<xa443afcc736e1f3e>(new Action<xa443afcc736e1f3e>(this.x2c196582986b2b4d));
            this.RebuldView();
        }

        [DebuggerNonUserCode]
        public void InitializeComponent()
        {
            bool flag = !this._x7dc3d9d322900926;
            while (flag)
            {
                this._x7dc3d9d322900926 = true;
                Uri resourceLocator = new Uri("/Nsim4;component/components/structure/viewer/structureviewer3d.xaml", UriKind.Relative);
                Application.LoadComponent(this, resourceLocator);
                if ((15 == 0) || ((((uint) flag) & 0) == 0))
                {
                    break;
                }
            }
        }

        public void RebuldView()
        {
            int num;
            int size;
            List<Point3D> list;
            double num3;
            double num4;
            int num5;
            Sphere sphere;
            Sphere sphere2;
            ScreenSpaceLines3D current;
            <>c__DisplayClassa classa;
            bool flag;
            IEnumerator<ScreenSpaceLines3D> enumerator3;
            INetStruct service = App.Services.GetService<INetStruct>();
            goto Label_08C1;
        Label_0048:
            using (enumerator3 = Enumerable.Select<Point3D, ScreenSpaceLines3D>(list, new Func<Point3D, ScreenSpaceLines3D>(classa, (IntPtr) this.<RebuldView>b__6)).GetEnumerator())
            {
                do
                {
                    flag = enumerator3.MoveNext();
                    if (1 != 0)
                    {
                        if (!flag)
                        {
                            goto Label_00D0;
                        }
                        current = enumerator3.Current;
                        this._x929312ef8641a34b.Add(current);
                    }
                    this.port.Children.Add(current);
                }
                while (((uint) num5) >= 0);
            }
        Label_00D0:
            this._x929312ef8641a34b.Add(sphere);
        Label_00DE:
            this.port.Children.Add(sphere);
            num5++;
            if (((uint) num4) > uint.MaxValue)
            {
                goto Label_0282;
            }
        Label_010E:
            flag = num5 < service.OutputLayer.Size;
            if (!flag)
            {
                if (((uint) num4) < 0)
                {
                    goto Label_05F5;
                }
                if ((((uint) flag) | 0xfffffffe) != 0)
                {
                    if (-1 != 0)
                    {
                        return;
                    }
                    goto Label_08C1;
                }
                goto Label_0048;
            }
        Label_01AB:
            classa = new <>c__DisplayClassa();
            Sphere sphere4 = new Sphere();
            if (((uint) num5) <= uint.MaxValue)
            {
                if ((((uint) num) + ((uint) num4)) >= 0)
                {
                    if (((uint) num) >= 0)
                    {
                        do
                        {
                            sphere4.Radius = 0.2;
                            sphere4.Color = Colors.Orange;
                        }
                        while ((((uint) num) & 0) != 0);
                        sphere4.Transform = new TranslateTransform3D(num3, num4 + num5, 0.0);
                        sphere = sphere4;
                        classa.point = new Point3D(num3, num4 + num5, 0.0);
                        goto Label_0048;
                    }
                    goto Label_085E;
                }
                goto Label_0786;
            }
            goto Label_0700;
        Label_01E8:
            num5 = 0;
            if ((((uint) num4) + ((uint) num3)) >= 0)
            {
                if (((uint) num4) >= 0)
                {
                    goto Label_010E;
                }
                if ((((uint) num4) - ((uint) num5)) >= 0)
                {
                    goto Label_0700;
                }
                if ((((uint) num3) & 0) == 0)
                {
                    goto Label_05F5;
                }
                goto Label_05A7;
            }
            if (((uint) size) <= uint.MaxValue)
            {
                goto Label_026A;
            }
        Label_0218:
            num3++;
            if ((((uint) num4) & 0) != 0)
            {
                goto Label_0048;
            }
            num4 = (service.OutputLayer.Size / 2) * -1;
            flag = (service.OutputLayer.Size % 2) != 0;
            if (!flag)
            {
                num4 += 0.5;
            }
            goto Label_01E8;
        Label_026A:
            flag = num5 < service.InputLayer.Size;
            if (flag)
            {
                sphere2 = new Sphere();
                goto Label_06E8;
            }
        Label_0282:
            using (IEnumerator<ILayerStruct> enumerator2 = service.HiddenLayers.Layers.GetEnumerator())
            {
                ILayerStruct struct3;
                List<Point3D> list2;
                Sphere sphere3;
                <>c__DisplayClass8 class2;
                goto Label_02B0;
            Label_0297:
                if ((((uint) num5) - ((uint) num)) < 0)
                {
                    goto Label_02B9;
                }
            Label_02B0:
                flag = enumerator2.MoveNext();
            Label_02B9:
                if (flag)
                {
                    goto Label_052B;
                }
                goto Label_0313;
            Label_02C2:
                list.Add(class2.point);
                this._x929312ef8641a34b.Add(sphere);
                this.port.Children.Add(sphere);
            Label_02F2:
                num5++;
            Label_02FA:
                flag = num5 < struct3.Size;
                if (flag)
                {
                    goto Label_04A8;
                }
                goto Label_0297;
            Label_0313:
                if ((((uint) size) + ((uint) num3)) >= 0)
                {
                    goto Label_0440;
                }
            Label_032E:
                sphere3.Transform = new TranslateTransform3D(num3, num4 + num5, 0.0);
                sphere = sphere3;
                if ((((uint) num4) - ((uint) num4)) < 0)
                {
                    goto Label_02F2;
                }
                class2.point = new Point3D(num3, num4 + num5, 0.0);
                enumerator3 = Enumerable.Select<Point3D, ScreenSpaceLines3D>(list2, new Func<Point3D, ScreenSpaceLines3D>(class2, (IntPtr) this.<RebuldView>b__5)).GetEnumerator();
                try
                {
                Label_03A9:
                    flag = enumerator3.MoveNext();
                    if (flag || (((uint) flag) < 0))
                    {
                        current = enumerator3.Current;
                        if ((((uint) size) | 0xff) != 0)
                        {
                            this._x929312ef8641a34b.Add(current);
                            this.port.Children.Add(current);
                            goto Label_03A9;
                        }
                    }
                    goto Label_02C2;
                }
                finally
                {
                    flag = enumerator3 == null;
                    while (!flag)
                    {
                        enumerator3.Dispose();
                        break;
                    }
                }
                if (((uint) size) <= uint.MaxValue)
                {
                    goto Label_02C2;
                }
            Label_0440:
                if (0 == 0)
                {
                    goto Label_0218;
                }
                goto Label_04D1;
            Label_044B:
                if (((uint) flag) < 0)
                {
                    goto Label_0297;
                }
                sphere3.Radius = 0.2;
                sphere3.Color = Colors.Yellow;
                goto Label_032E;
            Label_0482:
                sphere3 = new Sphere();
                goto Label_044B;
            Label_048C:
                if (0 != 0)
                {
                    goto Label_04B3;
                }
            Label_048F:
                list2 = list.ToList<Point3D>();
                list.Clear();
                num5 = 0;
                goto Label_02FA;
            Label_04A8:
                class2 = new <>c__DisplayClass8();
                goto Label_0482;
            Label_04B3:
                if (flag)
                {
                    if (((uint) flag) >= 0)
                    {
                        goto Label_048F;
                    }
                    goto Label_048C;
                }
            Label_04D1:
                num4 += 0.5;
                goto Label_048C;
            Label_04ED:
                num4 = (struct3.Size / 2) * -1;
                if ((((uint) num5) - ((uint) num)) >= 0)
                {
                    flag = (struct3.Size % 2) != 0;
                    goto Label_04B3;
                }
            Label_052B:
                struct3 = enumerator2.Current;
                num3++;
                goto Label_04ED;
            }
            goto Label_0218;
        Label_05A7:
            if (0 != 0)
            {
                goto Label_0745;
            }
            list.Add(new Point3D(num3, num4 + num5, 0.0));
            this._x929312ef8641a34b.Add(sphere);
            this.port.Children.Add(sphere);
            num5++;
            goto Label_0650;
        Label_05F5:
            sphere2.Radius = 0.2;
            sphere2.Color = Colors.DeepPink;
            sphere2.Transform = new TranslateTransform3D(num3, num4 + num5, 0.0);
            sphere = sphere2;
            if ((((uint) num3) | 1) != 0)
            {
                goto Label_05A7;
            }
        Label_0650:
            if ((((uint) size) + ((uint) num)) >= 0)
            {
                goto Label_026A;
            }
            goto Label_0700;
        Label_0670:
            num4 += 0.5;
        Label_0684:
            num5 = 0;
            goto Label_026A;
        Label_06E8:
            if ((((uint) num) + ((uint) size)) >= 0)
            {
                goto Label_05F5;
            }
        Label_0700:
            list = new List<Point3D>();
            num3 = ((((double) num) / 2.0) * -1.0) + 0.5;
            if ((((uint) flag) + ((uint) num4)) > uint.MaxValue)
            {
                goto Label_01AB;
            }
        Label_0745:
            num4 = (service.InputLayer.Size / 2) * -1;
            flag = (service.InputLayer.Size % 2) != 0;
            if (8 == 0)
            {
                goto Label_01E8;
            }
            if ((((uint) num5) | 2) != 0)
            {
                if (!flag)
                {
                    goto Label_0670;
                }
                goto Label_0684;
            }
            if ((((uint) num5) + ((uint) num3)) <= uint.MaxValue)
            {
                goto Label_0670;
            }
            goto Label_06E8;
        Label_0786:
            if (!flag)
            {
                size = num;
            }
            this.cam1.Position = new Point3D(0.0, 0.0, size * 1.5);
            using (List<Visual3D>.Enumerator enumerator = this._x929312ef8641a34b.GetEnumerator())
            {
                Visual3D visuald;
                goto Label_07F9;
            Label_07CB:
                visuald = enumerator.Current;
                this.port.Children.Remove(visuald);
                if (((uint) num) < 0)
                {
                    goto Label_0802;
                }
            Label_07F9:
                flag = enumerator.MoveNext();
            Label_0802:
                if (flag)
                {
                    goto Label_07CB;
                }
            }
            this._x929312ef8641a34b.Clear();
            if ((((uint) num3) | 0xfffffffe) == 0)
            {
                goto Label_00DE;
            }
            goto Label_0700;
        Label_085E:
            if (x52e0eb7265061ab4 == null)
            {
                x52e0eb7265061ab4 = new Func<ILayerStruct, int>(null, (IntPtr) x2b9ae66d393d74b1);
            }
            size = Enumerable.Select<ILayerStruct, int>(service.HiddenLayers.Layers, x52e0eb7265061ab4).Concat<int>(new int[] { size }).Max();
            flag = num <= size;
            goto Label_0786;
        Label_08C1:
            num = service.HiddenLayers.Layers.Count<ILayerStruct>() + 2;
            size = service.InputLayer.Size;
            flag = service.OutputLayer.Size <= size;
            if (!flag)
            {
                size = service.OutputLayer.Size;
            }
            goto Label_085E;
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

        [DebuggerNonUserCode, EditorBrowsable(EditorBrowsableState.Never)]
        private void x628e6c716ec340be(int xf3efd21c486a5cce, object x11d58b056c032b03)
        {
            switch (xf3efd21c486a5cce)
            {
                case 1:
                    this.port = (Viewport3D) x11d58b056c032b03;
                    break;

                case 2:
                    this.cam1 = (PerspectiveCamera) x11d58b056c032b03;
                    break;

                default:
                    this._x7dc3d9d322900926 = true;
                    break;
            }
        }

        private static ScreenSpaceLines3D xa27fac46e21ed5f4(Point3D x54acfcf5460fb360, Point3D x08eef91ccd7eb033)
        {
            ScreenSpaceLines3D linesd;
            ScreenSpaceLines3D linesd2 = new ScreenSpaceLines3D {
                Thickness = 3.0
            };
            if (0 == 0)
            {
                linesd = linesd2;
                linesd.Points.Add(x54acfcf5460fb360);
            }
            linesd.Points.Add(x08eef91ccd7eb033);
            linesd.Color = Colors.BlueViolet;
            return linesd;
        }
    }
}

