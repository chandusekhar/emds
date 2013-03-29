namespace Nsim
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;

    public class ImageButton
    {
        public static readonly DependencyProperty ImageProperty = DependencyProperty.RegisterAttached("Image", typeof(ImageSource), typeof(ImageButton), new FrameworkPropertyMetadata(null, new PropertyChangedCallback(ImageButton.xf264e4e18e7f74ec)));
        public static readonly DependencyProperty ImageSizeProperty = DependencyProperty.RegisterAttached("ImageSize", typeof(int), typeof(ImageButton), new FrameworkPropertyMetadata(0x20));

        public static ImageSource GetImage(DependencyObject obj)
        {
            return (ImageSource) obj.GetValue(ImageProperty);
        }

        public static int GetImageSize(DependencyObject obj)
        {
            return (int) obj.GetValue(ImageSizeProperty);
        }

        public static void SetImage(DependencyObject obj, ImageSource value)
        {
            obj.SetValue(ImageProperty, value);
        }

        public static void SetImageSize(DependencyObject obj, int value)
        {
            obj.SetValue(ImageSizeProperty, value);
        }

        private static void xf264e4e18e7f74ec(DependencyObject x73f821c71fe1e676, DependencyPropertyChangedEventArgs xfbf34718e704c6bc)
        {
            bool flag;
            Button button = x73f821c71fe1e676 as Button;
            if ((((uint) flag) + ((uint) flag)) >= 0)
            {
                goto Label_005D;
            }
            if (0 == 0)
            {
                goto Label_0049;
            }
        Label_0023:
            if (flag)
            {
                return;
            }
            button.Style = Application.Current.FindResource("ImageButton") as Style;
            if (0 == 0)
            {
                return;
            }
        Label_0049:
            flag = button.Style != null;
            if (0 == 0)
            {
                goto Label_0023;
            }
        Label_005D:
            flag = button != null;
            if (((((uint) flag) - ((uint) flag)) > uint.MaxValue) || !flag)
            {
                return;
            }
            goto Label_0049;
        }
    }
}

