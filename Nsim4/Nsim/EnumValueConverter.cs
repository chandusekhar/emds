namespace Nsim
{
    using System;
    using System.Collections;
    using System.Globalization;
    using System.Windows.Data;

    [ValueConversion(typeof(Type), typeof(IEnumerable))]
    public class EnumValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool flag = targetType != null;
            if ((((uint) flag) - ((uint) flag)) <= uint.MaxValue)
            {
                if (!flag)
                {
                    if (-1 == 0)
                    {
                        object obj2;
                        return obj2;
                    }
                    if ((((uint) flag) + ((uint) flag)) <= uint.MaxValue)
                    {
                        throw new ArgumentNullException("targetType");
                    }
                    goto Label_0047;
                }
                if (!typeof(IEnumerable).IsAssignableFrom(targetType))
                {
                    goto Label_0047;
                }
            }
            Type enumType = (value is Type) ? ((Type) value) : value.GetType();
            return Enum.GetValues(enumType);
        Label_0047:
            throw new ArgumentException(string.Format("The interface \"{0}\" does not implemented by \"{1}\".", typeof(IEnumerable), targetType), "targetType");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}

