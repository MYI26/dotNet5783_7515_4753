using System;
using System.Windows;
using static BO.Enums;
using BO;

namespace PL
{
    /// <summary>
    /// Logique d'interaction pour Window2.xaml
    /// </summary>

    public partial class Product_Order_Window : Window
    {
        public DO.Enums.Category Category { get; set; }

        BlApi.IBl? bl = BlApi.Factory.Get();


        //for the admin
        //for adding a product in the database
        public Product_Order_Window()
        {
            InitializeComponent();
            SelectProductWindow.ItemsSource = Enum.GetValues(typeof(BO.Enums.Category));
            ButtonAdd.Content = "Add";
            grid1.Visibility = Visibility.Collapsed;
            deletebutton.Visibility = Visibility.Collapsed;
        }

        //for the admin
        //for updating a product in the database
        public Product_Order_Window(BO.ProductForList pfl)
        {
            InitializeComponent();
            Enter.DataContext = pfl;

            SelectProductWindow.ItemsSource = Enum.GetValues(typeof(BO.Enums.Category));            
            TextBoxId.IsReadOnly = true;           
            TextBoxInStock.SelectedText = (bl?.Product?.Get(pfl.ProductID).InStock).ToString();
            ButtonAdd.Content = "Update";
            SelectProductWindow.SelectedItem = (Category?)pfl.Category;

            deletebutton.Visibility = Visibility.Visible;
            grid1.Visibility = Visibility.Collapsed;
        }

        //for the admin
        //for looking the orders and their details in the database
        public Product_Order_Window(BO.OrderForList ofl)
        {
            InitializeComponent();
            Order? order = bl?.Order?.Get(ofl.OrderID)!;

            InfoOrder.DataContext = order;
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
                bl?.Product.Add(p1);
                MessageBox.Show("the product has been successfully add");
            }

            else { bl?.Product.Update(p1); MessageBox.Show("the product has been successfully update"); }
           
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
            //we check if the order already delivred
            if (bl?.Order?.Get(int.Parse(id.Text))!.Status != OrderStatus.delivered && bl?.Order?.Get(int.Parse(id.Text))!.Status != OrderStatus.shipped)
            {
                bl?.Order?.update(int.Parse(id.Text));
                status.Text = "shipped";
                ship.Text = bl?.Order?.Get(int.Parse(id.Text))!.ShipDate.ToString();
            }
        }
        
    

        private void deliveryupdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (bl?.Order?.Get(int.Parse(id.Text))!.Status != OrderStatus.delivered)
                {
                    bl?.Order?.updateDelivrery(int.Parse(id.Text));
                    status.Text = "delivered";
                    delivery.Text = bl?.Order?.Get(int.Parse(id.Text))!.DeliveryDate.ToString();
                }
            }
            catch { MessageBox.Show("Cannot deliver before shipping"); }
        }
    }
}