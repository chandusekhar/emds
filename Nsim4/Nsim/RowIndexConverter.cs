namespace Nsim
{
    using System;
    using System.Diagnostics;
    using System.Globalization;
    using System.Windows.Controls;
    using System.Windows.Data;

    public class RowIndexConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ListBox box;
            ListBoxItem container = value as ListBoxItem;
            do
            {
                box = ItemsControl.ItemsControlFromItemContainer(container) as ListBox;
                Debug.Assert(box != null, "view != null");
            }
            while (0 != 0);
            Debug.Assert(container != null, "item != null");
            int num = box.ItemContainerGenerator.IndexFromContainer(container) + 1;
            return num.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

