namespace Nsim
{
    using System;
    using System.Globalization;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using System.Windows.Data;

    [ValueConversion(typeof(bool), typeof(Visibility))]
    public class BoolToVisibilityConverter : IValueConverter
    {
        [CompilerGenerated]
        private bool xa8d9daa3dc55d6da;
        [CompilerGenerated]
        private bool xf7e4e7300eba6787;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (this.Inverted ? this.xc8718766fc887983(value) : this.xbed0305adddfdcf6(value));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (this.Inverted ? this.xbed0305adddfdcf6(value) : this.xc8718766fc887983(value));
        }

        private object xbed0305adddfdcf6(object xbcea506a33cf9111)
        {
            if (!(xbcea506a33cf9111 is Visibility) && (-2147483648 != 0))
            {
                return DependencyProperty.UnsetValue;
            }
            return ((((Visibility) xbcea506a33cf9111) == Visibility.Visible) ^ this.Not);
        }

        private object xc8718766fc887983(object xbcea506a33cf9111)
        {
            bool flag = xbcea506a33cf9111 is bool;
            while (true)
            {
                if (((bool) xbcea506a33cf9111) ^ this.Not)
                {
                }
                return (((((uint) flag) & 0) == 0) ? Visibility.Visible : Visibility.Collapsed);
                while (!flag)
                {
                    return DependencyProperty.UnsetValue;
                }
            }
        }

        public bool Inverted
        {
            [CompilerGenerated]
            get
            {
                return this.xa8d9daa3dc55d6da;
            }
            [CompilerGenerated]
            set
            {
                this.xa8d9daa3dc55d6da = value;
            }
        }

        public bool Not
        {
            [CompilerGenerated]
            get
            {
                return this.xf7e4e7300eba6787;
            }
            [CompilerGenerated]
            set
            {
                this.xf7e4e7300eba6787 = value;
            }
        }
    }
}

