using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace FuelTracker.Models
{
    class CurrencyFormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (App.GlobalUnitCurrency)
            {
                case "€":
                    return string.Format("{0:n}\u2009", (int)value) + App.GlobalUnitCurrency;
                case "$":
                    return App.GlobalUnitCurrency + string.Format("\u2009{0:n}", (int)value);
                case "£":
                    return App.GlobalUnitCurrency + string.Format("\u2009{0:n}", (int)value);
            }

            throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
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
