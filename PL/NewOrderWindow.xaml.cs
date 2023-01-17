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
    public partial class NewOrderWindow : Window
    {

        private static IEnumerable<ProductForList?>? ItmesSource;

        BlApi.IBl? bl = BlApi.Factory.Get();
        Cart cartuser = new Cart();
        public NewOrderWindow(Cart cart)
        {
            InitializeComponent();
            ProductItemView.ItemsSource = bl?.Product?.GetProductList(null);
            CatagorySelector.ItemsSource = Enum.GetValues(typeof(BO.Enums.Category));
            cartuser = cart;
        }
        public DO.Enums.Category Category { get; set; }
        //public BO.Product p;

        public bool fonctioncombox(DO.Product? p = null)
        {
            if (p?.MyCategory == Category)
                return true;
            if (Category == 0)
                return true;

            else return false;
        }

        private void CatagorySelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            Category = (DO.Enums.Category)CatagorySelector.SelectedItem;

            ProductItemView.ItemsSource = bl?.Product.GetProductList(fonctioncombox);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bl?.Cart?.AddProduct(cartuser, int.Parse(idofadd.Text));

            MessageBox.Show("The product was add whith success");

            this.Close();
        }
        
    }
}
