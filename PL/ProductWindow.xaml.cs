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
using static PL.ProductListWindow;
using static BO.Enums;
using BO;
using System.Windows.Controls.Primitives;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Diagnostics.Metrics;


namespace PL
{

    /// <summary>
    /// Logique d'interaction pour Window2.xaml
    /// </summary>
    /// 

    public partial class ProductWindow : Window
    {
        public DO.Enums.Category Category { get; set; }
        BlApi.IBl? bl = BlApi.Factory.Get();

       // public Order? order1 = new Order();
        // ProductListWindow 



        public ProductWindow()
        {
            InitializeComponent();
            SelectProductWindow.ItemsSource = Enum.GetValues(typeof(BO.Enums.Category));
            //TextBoxId.SelectedText = "0";
           // TextBoxName.SelectedText = "";
           // TextBoxPrice.SelectedText = "₪";
           // TextBoxInStock.SelectedText = "0";
           ButtonAdd.Content = "Add";
            grid1.Visibility = Visibility.Collapsed;
            deletebutton.Visibility = Visibility.Collapsed;
        }

        public ProductWindow(BO.ProductForList pfl)
        {

            //BO.ProductForList pfh = pfl;
            InitializeComponent();
            Enter.DataContext = pfl;

            SelectProductWindow.ItemsSource = Enum.GetValues(typeof(BO.Enums.Category));            
            TextBoxId.IsReadOnly = true;           
            TextBoxInStock.SelectedText = (bl.Product.Get(pfl.ProductID).InStock).ToString();
            ButtonAdd.Content = "Update";
            SelectProductWindow.SelectedItem = (Category?)pfl.Category;

            deletebutton.Visibility = Visibility.Visible;
            grid1.Visibility = Visibility.Collapsed;

        }

        public ProductWindow(BO.OrderForList ofl)
        {
            InitializeComponent();
            Order? order = bl?.Order?.Get(ofl.OrderID)!;

            InfoOrder.DataContext= order;
            //order1 = order;

            Details.Visibility = Visibility.Visible;
            deletebutton.Visibility = Visibility.Collapsed;
            TextBoxInStock.Visibility = Visibility.Collapsed;
            TextBoxPrice.Visibility = Visibility.Collapsed;
            TextBoxName.Visibility = Visibility.Collapsed;
            TextBoxId.Visibility = Visibility.Collapsed;
            SelectProductWindow.Visibility = Visibility.Collapsed;

            listorderitem.ItemsSource = order.Items;
 
        }

        private void Button_ClickAddProduct(object sender, RoutedEventArgs e)
        { 
            
            BO.Product p1 = new Product();
            //Enter.DataContext = p1;

            Category = (DO.Enums.Category)SelectProductWindow.SelectedItem;

            p1.ProductID = int.Parse(TextBoxId.Text);
            p1.Name = TextBoxName.Text;
            p1.MyCategory = (Category?)Category;
            p1.Price = double.Parse(TextBoxPrice.Text);
            p1.InStock = int.Parse(TextBoxInStock.Text);

            if (ButtonAdd.Content == "Add")
            {
                bl.Product.Add(p1);
                MessageBox.Show("the product has been successfully add");
            }

            else { bl.Product.Update(p1); MessageBox.Show("the product has been successfully update"); }
            //  ProductListView.ItemsSource = bl?.Product?.GetProductList(null);
           
            this.Close();
            new ProductListWindow().Show();
        }


        private void deletebutton_Click(object sender, RoutedEventArgs e)
        {
            bl?.Product?.Delete(int.Parse(TextBoxId.Text));
            MessageBox.Show("the product has been successfully deleted");
            new ProductListWindow().Show(); this.Close();
        }


        private void Button_Click(object sender, RoutedEventArgs e) => this.Close();



        private void shippingupdate_Click(object sender, RoutedEventArgs e)
        {
            bl.Order.update(int.Parse(id.Text));

            ship.Text = bl?.Order?.Get(int.Parse(id.Text)).ShipDate.ToString();
        }



        private void deliveryupdate_Click(object sender, RoutedEventArgs e)
        {
            bl.Order.updateDelivrery(int.Parse(id.Text));

            delivery.Text = bl?.Order?.Get(int.Parse(id.Text)).DeliveryDate.ToString();
        }
    }
}