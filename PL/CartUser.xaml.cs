using BO;
using System.Collections.Generic;
using System.Linq;
using System.Windows;


namespace PL
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class CartUser : Window
    {

        private static IEnumerable<ProductForList?>? ItmesSource;

        BlApi.IBl? bl = BlApi.Factory.Get();

        Cart cartUser = new Cart();

        public CartUser()
        {
            InitializeComponent();

            AddProductButton.Visibility = Visibility.Collapsed;
            DetailsCartButton.Visibility = Visibility.Collapsed;
            ConfirmationCartButton.Visibility = Visibility.Collapsed;

            LabelAmountOfItem.Visibility = Visibility.Collapsed;
            LabelTotalPrice.Visibility= Visibility.Collapsed;

            AmountOfItem.Visibility= Visibility.Collapsed;
            TotalPrice.Visibility= Visibility.Collapsed;

            CartInformations.DataContext = cartUser;
        }

        //when you validate your information before choosing your products
        private void Button_Valid(object sender, RoutedEventArgs e)
        {
            Titre.Content = "Choose an action:";
            AddProductButton.Visibility = Visibility.Visible;
            DetailsCartButton.Visibility = Visibility.Visible;
            ConfirmationCartButton.Visibility = Visibility.Visible;

            CartInformations.Visibility = Visibility.Collapsed;
            LabelForCartInformations.Visibility = Visibility.Collapsed;
            ClickValid.Visibility = Visibility.Collapsed;
        }

        private void detailcardbutton_Click(object sender, RoutedEventArgs e)
        {

            affichelist.Visibility = Visibility.Visible;
            if(cartUser.Items != null) AmountOfItem.Text = cartUser.Items.Count().ToString();

            Titre.Content = "Details of your cart:";
            LabelForCartInformations.Visibility = Visibility.Visible;
            LabelAmountOfItem.Visibility = Visibility.Visible;
            LabelTotalPrice.Visibility = Visibility.Visible;

            CartInformations.Visibility = Visibility.Visible;
            AmountOfItem.Visibility = Visibility.Visible;
            TotalPrice.Visibility = Visibility.Visible;

            TotalPrice.Text = cartUser.TotalPrice.ToString();

            CustomerName.IsReadOnly = true;
            CustomerEmail.IsReadOnly = true;
            CustomerAdress.IsReadOnly = true;
            AmountOfItem.IsReadOnly = true;
            TotalPrice.IsReadOnly = true;

            listorderitem.ItemsSource = null;
            listorderitem.ItemsSource = cartUser.Items;
        }

        private void addproductcartbutton_Click(object sender, RoutedEventArgs e) => new NewOrderWindow(cartUser).Show();

        private void comfirmationcardbutton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int? Orderid = bl?.Cart?.ConfirmationCard(cartUser);
                MessageBox.Show($"Your order has been made, thank you for using our services {cartUser.CustomerName}");
                MessageBox.Show($"Your order number is {Orderid} don't forget it for tracking");
            }

            catch(BO.ErrorDontExist ex) { MessageBox.Show(ex.Message);  }

            this.Close();
        }
    }

}
