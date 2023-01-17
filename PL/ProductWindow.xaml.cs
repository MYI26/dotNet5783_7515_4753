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


namespace PL;

/// <summary>
/// Logique d'interaction pour Window2.xaml
/// </summary>
/// 

public partial class ProductWindow : Window
{
    public DO.Enums.Category Category { get; set; }
    BlApi.IBl? bl = BlApi.Factory.Get();
    // ProductListWindow 
    public ProductWindow()
    {
        InitializeComponent();
        SelectProductWindow.ItemsSource = Enum.GetValues(typeof(BO.Enums.Category));
        TextBoxId.SelectedText = "0";
        TextBoxName.SelectedText = "";
        TextBoxPrice.SelectedText = "₪";
        TextBoxInStock.SelectedText = "0";
        ButtonAdd.Content = "Add";
    }

    public ProductWindow(BO.ProductForList pfl)
    {     
        InitializeComponent();
        SelectProductWindow.ItemsSource = Enum.GetValues(typeof(BO.Enums.Category));
        TextBoxId.SelectedText = (pfl.ProductID).ToString();
        TextBoxId.IsReadOnly = true ;
        TextBoxName.SelectedText = pfl.Name;
        TextBoxPrice.SelectedText = (pfl.Price).ToString();
        TextBoxInStock.SelectedText = (bl.Product.Get(pfl.ProductID).InStock).ToString();
        ButtonAdd.Content = "Update";
        SelectProductWindow.SelectedItem = (Category?)pfl.Category;
    }

    public ProductWindow(BO.OrderForList ofl)
    {
        InitializeComponent();
        AffichageId.Content = "Order ID:";
        AffichageName.Content = "Customer Name:";
        AffichageEmail.Content = "Customer Email:";
        AffichageAdress.Content = "Customer Address:";
        AffichageStatus.Content = "Status:";

        SelectProductWindow.ItemsSource = Enum.GetValues(typeof(BO.Enums.Category));
       // TextBoxId.SelectedText = (ofl.ProductID).ToString();
        TextBoxId.IsReadOnly = true;
        TextBoxName.SelectedText = ofl?.CustomerName;
        TextBoxPrice.SelectedText = (ofl?.TotalPrice).ToString();
       // TextBoxInStock.SelectedText = (bl.Product.Get(ofl.Amount).InStock).ToString();
        ButtonAdd.Visibility= Visibility.Collapsed;
        
    }

    private void Button_ClickAddProduct(object sender, RoutedEventArgs e)
    {

       
            Category = (DO.Enums.Category)SelectProductWindow.SelectedItem;
            BO.Product p1 = new Product();
            p1.ProductID = int.Parse(TextBoxId.Text);
            p1.Name = TextBoxName.Text;
            p1.MyCategory = (Category?)Category;
            p1.Price = double.Parse(TextBoxPrice.Text);
            p1.InStock = int.Parse(TextBoxInStock.Text);

        if (ButtonAdd.Content == "Add")
        {
            bl.Product.Add(p1);
        }       

        else bl.Product.Update(p1);    
            //  ProductListView.ItemsSource = bl?.Product?.GetProductList(null);
           new ProductListWindow().Show(); this.Close();

    }
}
