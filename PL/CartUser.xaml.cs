using BO;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace PL
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class CartUser : Window
    {

        private static IEnumerable<ProductForList?>? ItmesSource;

        BlApi.IBl? bl = BlApi.Factory.Get();

        Cart cartuser = new Cart();
        public CartUser()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            cartuser.CustomerName = customername.Text;
            cartuser.CustomerAddress = customeradress.Text;
            cartuser.CustomerEmail = customeremail.Text;

        }
    }
}
