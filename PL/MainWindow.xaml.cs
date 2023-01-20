using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace PL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        BlApi.IBl? bl = BlApi.Factory.Get();
        //private static IBL bl;
        public MainWindow()
        {
            InitializeComponent();

        }



        private void ___ShowProductListViewButton_Click__Click(object sender, RoutedEventArgs e) { password.Visibility = Visibility.Visible; }

        private void ___ShowNewOrderButton_Click__Click(object sender, RoutedEventArgs e) => new CartUser().Show();

        private void ___ShowTRackingControlButton_Click__Click(object sender, RoutedEventArgs e) => new TrackingControlWindow().Show();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string pass = "eliaou";
            if (PasswordBox.Password == pass) {

               // password.Visibility = Visibility.Collapsed; jais punaise de reussi!!!!!!!!! binding ola ola
                PasswordBox.Password = "";
                new ProductListWindow().Show(); 
            }
            else MessageBox.Show("the password not valid");
        }

    }

   

}