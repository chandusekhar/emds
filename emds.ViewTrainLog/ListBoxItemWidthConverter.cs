using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace emds.ViewTrainLog
{
    public class ListBoxItemWidthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            double tmp = (double)value;
            return tmp - 5;
            // Do the conversion from bool to visibility
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            double tmp = (double)value;
            return tmp + 5;
            // Do the conversion from visibility to bool
        }
    }
}
