using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace wpf8.Converters
{
    public class AgeConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
        CultureInfo culture)
        {
            if (value == null)
                return String.Empty;

            if (value is DateTime d)
            return DateTime.Now.Year - d.Year ;
                
            
                
            return String.Empty;
        }
        public object ConvertBack(object value, Type targetType, object parameter,
        CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
