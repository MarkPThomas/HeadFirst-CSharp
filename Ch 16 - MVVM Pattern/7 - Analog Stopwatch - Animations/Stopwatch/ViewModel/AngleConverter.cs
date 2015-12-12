using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Stopwatch.ViewModel
{
    class AngleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double parsedValue;
            if ((value != null)
                && double.TryParse(value.ToString(), out parsedValue)
                && (parameter != null))
            {
                switch (parameter.ToString())
                {
                    case "Hours":
                        return parsedValue * 30;
                    // Example of a multi-or-case statement
                    case "Minutes":
                    case "Seconds":
                        return parsedValue * 6;
                }
            }
            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
