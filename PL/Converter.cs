using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Convert
{
    /*class VisibilityUpdateDroneConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DroneStatuses statuses = (DroneStatuses)value;

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

             <local:VisibilityUpdateDroneConverter x:Key="VisibilityUpdateConverter"/>

     Visibility="{Binding Path="click1" Converter={StaticResource VisibilityUpdateConverter}}
    */


    public class VisibilityOrderForListConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //DroneStatuses statuses = (DroneStatuses)value;

            bool IsMouseOver;
            bool.TryParse(value.ToString(), out IsMouseOver);

            //bool boolValue = (bool)value;
            //if (boolValue)
            //{
            //    return Visibility.Collapsed;
            //}
            //else
            //{
            //    return Visibility.Visible;
            //}
            if (IsMouseOver)
            {
                return Visibility.Visible;

            }

            else return Visibility.Collapsed;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //throw new NotImplementedException();
            return new object();
        }
    }


    public class VisibilityTrackingtConverter : IValueConverter
    {


        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //DroneStatuses statuses = (DroneStatuses)value;

            bool IsMouseOver;

            bool.TryParse(value.ToString(), out IsMouseOver);

            //bool boolValue = (bool)value;
            //if (boolValue)
            //{
            //    return Visibility.Collapsed;
            //}
            //else
            //{
            //    return Visibility.Visible;
            //}
            if (IsMouseOver)
            {
                return Visibility.Collapsed;


            }

            else return Visibility.Visible;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //throw new NotImplementedException();
            return new object();
        }
    }

    //[ValueConversion(typeof(bool), typeof(Visibility))]
    //public class BooleanToVisibilityConverter : IValueConverter
    //{
    //    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        return (bool)value ? Visibility.Visible : Visibility.Collapsed;
    //    }

    //    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        return (Visibility)value == Visibility.Visible;
    //    }
    //}

    //public class MyViewModel : INotifyPropertyChanged
    //{
    //    private bool _isTextBoxVisible;
    //    public bool IsTextBoxVisible
    //    {
    //        get { return _isTextBoxVisible; }
    //        set { _isTextBoxVisible = value; OnPropertyChanged(); }
    //    }

    //    public ICommand ToggleTextBoxCommand { get; set; }

    //    public MyViewModel()
    //    {
    //        ToggleTextBoxCommand = new RelayCommand(ToggleTextBoxVisibility);
    //    }

    //    private void ToggleTextBoxVisibility()
    //    {
    //        IsTextBoxVisible = !IsTextBoxVisible;
    //    }

    //    public event PropertyChangedEventHandler PropertyChanged;
    //    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    //    {
    //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    //    }
    //}
}
