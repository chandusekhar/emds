namespace Nsim
{
    using System;
    using System.Globalization;
    using System.Windows.Data;
    using System.Windows.Media;

    internal class ColumnDataPointColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // This item is obfuscated and can not be translated.
            bool flag = value != null;
            while (flag)
            {
                Tuple<double, bool> tuple = (Tuple<double, bool>) value;
            Label_003B:
                if (!tuple.get_Item2())
                {
                    goto Label_002A;
                }
                if (-2147483648 == 0)
                {
                    break;
                }
                if (4 == 0)
                {
                    object obj2;
                    return obj2;
                }
                if (0 == 0)
                {
                    if ((0 != 0) && (((uint) flag) < 0))
                    {
                        goto Label_003B;
                    }
                    goto Label_002A;
                }
            }
            return null;
        Label_002A:
            return new SolidColorBrush(Colors.Tomato);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

