using BO;
using System;
using System.Collections.Generic;
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
            detailcardbutton.Visibility = Visibility.Collapsed;
            comfirmationcardbutton.Visibility = Visibility.Collapsed;
            addproductcartbutton.Visibility = Visibility.Collapsed;
            price.Visibility = Visibility.Collapsed;
            itemamount.Visibility= Visibility.Collapsed;
            Amountitem.Visibility= Visibility.Collapsed;
            priceT.Visibility= Visibility.Collapsed;


        }

        private void Button_Valid(object sender, RoutedEventArgs e)
        {

            cartuser.CustomerName = customername.Text;
            cartuser.CustomerAddress = customeradress.Text;
            cartuser.CustomerEmail = customeremail.Text;
            clickValid.Visibility = Visibility.Collapsed;
            Imformation.Visibility = Visibility.Collapsed;
            Label.Visibility = Visibility.Collapsed;
            Titre.Content = "Chose an Action";
            detailcardbutton.Visibility = Visibility.Visible;
            comfirmationcardbutton.Visibility = Visibility.Visible;
            addproductcartbutton.Visibility = Visibility.Visible;
        }

        private void detailcardbutton_Click(object sender, RoutedEventArgs e)
        {

            affichelist.Visibility = Visibility.Visible;

            

            //but1.Visibility = Visibility.Collapsed;
           // but2.Visibility = Visibility.Collapsed;
           //but3.Visibility = Visibility.Collapsed;
            Titre.Content = "Details of your cart";

            price.Visibility = Visibility.Visible;
            itemamount.Visibility = Visibility.Visible;
            Amountitem.Visibility = Visibility.Visible;
            priceT.Visibility = Visibility.Visible;

            //customername.Text = cartuser.CustomerName;
            //customeradress.Text = cartuser.CustomerAddress;
           // customeremail.Text = cartuser.CustomerEmail;
            price.Text = cartuser.TotalPrice.ToString();
            // itemamount.Text = cartuser.Items.ToString();

            Label.Visibility = Visibility.Visible;
            Imformation.Visibility = Visibility.Visible;
            
           
            price.IsReadOnly = true;
            customername.IsReadOnly = true;
            customeradress.IsReadOnly = true;
            customeremail.IsReadOnly = true;
            itemamount.IsReadOnly = true;

            listorderitem.ItemsSource = null;
            listorderitem.ItemsSource = cartuser.Items;

        }

        private void addproductcartbutton_Click(object sender, RoutedEventArgs e) => new NewOrderWindow(cartuser).Show();

        private void comfirmationcardbutton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl?.Cart?.ConfirmationCard(cartuser);         
            }

        
            catch(BO.ErrorDontExist ex) { MessageBox.Show(ex.Message);  }

            this.Close();
        }
    }

}
