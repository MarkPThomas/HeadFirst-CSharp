using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Stopwatch.ViewModel
{
    class TimeNumberFormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is decimal)
            {
                return ((decimal)value).ToString("00.00");
            }
            else if (value is int)
            {
                if (parameter == null)
                {
                    return ((int)value).ToString("d1");
                }
                else
                {
                    return ((int)value).ToString(parameter.ToString());
                }
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
