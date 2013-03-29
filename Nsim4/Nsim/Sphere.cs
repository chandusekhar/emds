namespace Nsim
{
    using System;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Media3D;

    public class Sphere : UIElement3D
    {
        public static readonly DependencyProperty ColorProperty = DependencyProperty.Register("Color", typeof(System.Windows.Media.Color), typeof(Sphere), new UIPropertyMetadata(Colors.Black, new PropertyChangedCallback(Sphere.xdb87b614e4dcfe35)));
        public static readonly DependencyProperty PhiDivProperty = DependencyProperty.Register("PhiDiv", typeof(int), typeof(Sphere), new PropertyMetadata(15, new PropertyChangedCallback(Sphere.x19114a31e1d14ac2)));
        public static readonly DependencyProperty RadiusProperty = DependencyProperty.Register("Radius", typeof(double), typeof(Sphere), new PropertyMetadata(1.0, new PropertyChangedCallback(Sphere.xa9eafb89133a4711)));
        public static readonly DependencyProperty ThetaDivProperty = DependencyProperty.Register("ThetaDiv", typeof(int), typeof(Sphere), new PropertyMetadata(15, new PropertyChangedCallback(Sphere.x037c4d5b14a1fff4)));
        private static readonly DependencyProperty x081d15351433a1a5 = DependencyProperty.Register("Model", typeof(Model3D), typeof(Sphere), new PropertyMetadata(new PropertyChangedCallback(Sphere.x313de789978eb58d)));

        protected override void OnUpdateModel()
        {
            GeometryModel3D modeld = new GeometryModel3D {
                Geometry = x83ae6ab9dbae58e2(this.ThetaDiv, this.PhiDiv, this.Radius),
                Material = new DiffuseMaterial(new SolidColorBrush(this.Color))
            };
            this.xfd195ba400a3473c = modeld;
        }

        private static void x037c4d5b14a1fff4(DependencyObject x73f821c71fe1e676, DependencyPropertyChangedEventArgs xfbf34718e704c6bc)
        {
            ((Sphere) x73f821c71fe1e676).InvalidateModel();
        }

        private static void x19114a31e1d14ac2(DependencyObject x73f821c71fe1e676, DependencyPropertyChangedEventArgs xfbf34718e704c6bc)
        {
            ((Sphere) x73f821c71fe1e676).InvalidateModel();
        }

        private static void x313de789978eb58d(DependencyObject x73f821c71fe1e676, DependencyPropertyChangedEventArgs xfbf34718e704c6bc)
        {
            Sphere sphere = (Sphere) x73f821c71fe1e676;
            sphere.Visual3DModel = sphere.xfd195ba400a3473c;
        }

        private static Vector3D x701c8a2bca16cf73(double x17338e069de9c29c, double xa5e685957c5189d5)
        {
            return (Vector3D) xed8a0d4499d6f292(x17338e069de9c29c, xa5e685957c5189d5, 1.0);
        }

        internal static MeshGeometry3D x83ae6ab9dbae58e2(int x017e7115236ae0a5, int x1ee636813633b90b, double xd6ed827fa7f40115)
        {
            double num2;
            MeshGeometry3D geometryd;
            int num3;
            double num4;
            int num5;
            double num6;
            int num7;
            int num8;
            int num9;
            int num10;
            MeshGeometry3D geometryd2;
            bool flag;
            double num = xeeb1463834404693(360.0) / ((double) x017e7115236ae0a5);
            if ((((uint) x017e7115236ae0a5) - ((uint) num5)) >= 0)
            {
                goto Label_029B;
            }
            return geometryd2;
        Label_0081:
            flag = num5 < x017e7115236ae0a5;
            if (flag)
            {
                num7 = num5;
                if ((((uint) num2) - ((uint) num8)) > uint.MaxValue)
                {
                    goto Label_01EB;
                }
                if (-2 != 0)
                {
                    num8 = num5 + 1;
                    num9 = num3 * (x017e7115236ae0a5 + 1);
                    num10 = (num3 + 1) * (x017e7115236ae0a5 + 1);
                    geometryd.TriangleIndices.Add(num7 + num9);
                    if ((((uint) num9) + ((uint) num9)) <= uint.MaxValue)
                    {
                        if (((uint) x017e7115236ae0a5) <= uint.MaxValue)
                        {
                            geometryd.TriangleIndices.Add(num7 + num10);
                            geometryd.TriangleIndices.Add(num8 + num9);
                            geometryd.TriangleIndices.Add(num8 + num9);
                            goto Label_00E1;
                        }
                        goto Label_02CC;
                    }
                    goto Label_029B;
                }
                goto Label_0164;
            }
            num3++;
        Label_0094:
            if (num3 < x1ee636813633b90b)
            {
                num5 = 0;
            }
            else
            {
                geometryd.Freeze();
                geometryd2 = geometryd;
                if ((((uint) xd6ed827fa7f40115) - ((uint) num10)) > uint.MaxValue)
                {
                    goto Label_0227;
                }
                if ((((uint) num7) & 0) != 0)
                {
                    goto Label_0094;
                }
                if ((((uint) x1ee636813633b90b) | uint.MaxValue) != 0)
                {
                    return geometryd2;
                }
            }
            goto Label_0081;
        Label_00E1:
            geometryd.TriangleIndices.Add(num7 + num10);
            geometryd.TriangleIndices.Add(num8 + num10);
            num5++;
            goto Label_02CC;
        Label_0164:
            if (flag)
            {
                num4 = num3 * num2;
                num5 = 0;
                goto Label_01D5;
            }
            num3 = 0;
            goto Label_0094;
        Label_017A:
            flag = num3 <= x1ee636813633b90b;
            goto Label_0164;
        Label_01D5:
            flag = num5 <= x017e7115236ae0a5;
            if (((uint) flag) >= 0)
            {
                if ((((uint) num9) - ((uint) num)) < 0)
                {
                    goto Label_00E1;
                }
                if (flag)
                {
                    num6 = num5 * num;
                    goto Label_01EB;
                }
                num3++;
                if (((uint) num3) < 0)
                {
                    goto Label_0240;
                }
            }
            goto Label_017A;
        Label_01EB:
            geometryd.Positions.Add(xed8a0d4499d6f292(num6, num4, xd6ed827fa7f40115));
            if (((uint) num3) < 0)
            {
                goto Label_01D5;
            }
            geometryd.Normals.Add(x701c8a2bca16cf73(num6, num4));
        Label_0227:
            geometryd.TextureCoordinates.Add(xc6b8c1d09a811ba1(num6, num4));
            num5++;
            goto Label_01D5;
        Label_0240:
            if (((uint) x017e7115236ae0a5) < 0)
            {
                goto Label_0081;
            }
            goto Label_017A;
        Label_029B:
            num2 = xeeb1463834404693(180.0) / ((double) x1ee636813633b90b);
            geometryd = new MeshGeometry3D();
            num3 = 0;
            goto Label_0240;
        Label_02CC:
            if ((((uint) num) | 0xfffffffe) != 0)
            {
                goto Label_0081;
            }
            return geometryd2;
        }

        private static void xa9eafb89133a4711(DependencyObject x73f821c71fe1e676, DependencyPropertyChangedEventArgs xfbf34718e704c6bc)
        {
            ((Sphere) x73f821c71fe1e676).InvalidateModel();
        }

        private static Point xc6b8c1d09a811ba1(double x17338e069de9c29c, double xa5e685957c5189d5)
        {
            return new Point(x17338e069de9c29c / 6.2831853071795862, xa5e685957c5189d5 / 3.1415926535897931);
        }

        private static void xdb87b614e4dcfe35(DependencyObject x73f821c71fe1e676, DependencyPropertyChangedEventArgs xfbf34718e704c6bc)
        {
        }

        private static Point3D xed8a0d4499d6f292(double x17338e069de9c29c, double xa5e685957c5189d5, double xd6ed827fa7f40115)
        {
            double x = (xd6ed827fa7f40115 * Math.Sin(x17338e069de9c29c)) * Math.Sin(xa5e685957c5189d5);
            double y = xd6ed827fa7f40115 * Math.Cos(xa5e685957c5189d5);
            return new Point3D(x, y, (xd6ed827fa7f40115 * Math.Cos(x17338e069de9c29c)) * Math.Sin(xa5e685957c5189d5));
        }

        private static double xeeb1463834404693(double x08d0a6023d4ad136)
        {
            return ((x08d0a6023d4ad136 / 180.0) * 3.1415926535897931);
        }

        public System.Windows.Media.Color Color
        {
            get
            {
                return (System.Windows.Media.Color) base.GetValue(ColorProperty);
            }
            set
            {
                base.SetValue(ColorProperty, value);
            }
        }

        public int PhiDiv
        {
            get
            {
                return (int) base.GetValue(PhiDivProperty);
            }
            set
            {
                base.SetValue(PhiDivProperty, value);
            }
        }

        public double Radius
        {
            get
            {
                return (double) base.GetValue(RadiusProperty);
            }
            set
            {
                base.SetValue(RadiusProperty, value);
            }
        }

        public int ThetaDiv
        {
            get
            {
                return (int) base.GetValue(ThetaDivProperty);
            }
            set
            {
                base.SetValue(ThetaDivProperty, value);
            }
        }

        private Model3D xfd195ba400a3473c
        {
            get
            {
                return (Model3D) base.GetValue(x081d15351433a1a5);
            }
            set
            {
                base.SetValue(x081d15351433a1a5, value);
            }
        }
    }
}

