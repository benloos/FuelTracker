using System;
using System.Globalization;
using Xamarin.Forms;

namespace FuelTracker.Models
{
    class FuelPercentageTester : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (99 * (int)value / 100).ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new NotImplementedException();
        }

        double GetParameter(object parameter)
        {
            if (parameter is double)
                return (double)parameter;

            else if (parameter is int)
                return (int)parameter;

            else if (parameter is string)
                return double.Parse((string)parameter);

            return 1;
        }
    }
}
