namespace Nsim
{
    using System;
    using System.Windows;

    internal class ServiceImplement
    {
        public static readonly DependencyProperty x5efa13c98e8a6947 = DependencyProperty.RegisterAttached("ServiceImplement", typeof(Type), typeof(ServiceImplement), new FrameworkPropertyMetadata(null, new PropertyChangedCallback(ServiceImplement.x020eb58af361e7c0)));

        private static void x020eb58af361e7c0(DependencyObject x73f821c71fe1e676, DependencyPropertyChangedEventArgs xfbf34718e704c6bc)
        {
            App.Services.RegisterService(x73f821c71fe1e676, xfbf34718e704c6bc.NewValue as Type);
        }

        public static void x97216c945354f856(DependencyObject xa59bff7708de3a18, Type xbcea506a33cf9111)
        {
            xa59bff7708de3a18.SetValue(x5efa13c98e8a6947, xbcea506a33cf9111);
        }

        public static Type xbc35d3a179a2b265(DependencyObject xa59bff7708de3a18)
        {
            return (Type) xa59bff7708de3a18.GetValue(x5efa13c98e8a6947);
        }
    }
}

