using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;

namespace Convert
{
    /*class VisibilityUpdateDroneConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //DroneStatuses statuses = (DroneStatuses)value;

            if (statuses == DroneStatuses.Available)
                return Visibility.Visible;
            else
                return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    //         <local:VisibilityUpdateDroneConverter x:Key="VisibilityUpdateConverter"/>

    // Visibility="{Binding Path="click1" Converter={StaticResource VisibilityUpdateConverter}}
    */

    class VisibilityOrderForListConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //DroneStatuses statuses = (DroneStatuses)value;

            bool boolValue = (bool)value; if (boolValue)
            {
                return Visibility.Collapsed;
            }
            else
            {
                return Visibility.Visible;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
