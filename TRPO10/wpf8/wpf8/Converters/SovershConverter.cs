using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace wpf8.Converters
{
    public class SovershConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
        CultureInfo culture)
        {
            if (value == null)
                return String.Empty;

            if (value is bool b)
                return b ? "Совершеннолетний" : "Несовершеннолетний";
            return String.Empty;
        }
        public object ConvertBack(object value, Type targetType, object parameter,
        CultureInfo culture)
        {

            return Binding.DoNothing;
        }
    }
}
