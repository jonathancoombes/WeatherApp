using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace WeatherApp.ViewModel.ValueConverters
{
    

   class BoolToRainConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isRaining;
            string result = string.Empty;

            if (value != null)
            {
                isRaining = (bool)value;
                result = isRaining ? "Currently Raining.." : "Not Raining..";
            }

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {

            if (value != null)
            {
               string isRaining = (string)value;

                if(isRaining == "Currently Raining..")
                    return true;
            }

            return false;
        }
    }
}
