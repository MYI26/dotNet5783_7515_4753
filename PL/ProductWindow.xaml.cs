using BlImplementation;
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
using static BO.Enums;
using BO;

namespace PL;

/// <summary>
/// Logique d'interaction pour Window2.xaml
/// </summary>
/// 

public partial class ProductWindow : Window
{
    
    BlApi.IBl bl = new BlImplementation.Bl();
    public ProductWindow()
    {
        InitializeComponent();
        SelectProductWindow.ItemsSource = Enum.GetValues(typeof(BO.Enums.Category));
        TextBoxId.SelectedText = "0";
        TextBoxName.SelectedText = "";
        TextBoxPrice.SelectedText = "₪";
        TextBoxInStock.SelectedText = "0";

    }

    private void Button_ClickAddProduct(object sender, RoutedEventArgs e)
    {
        Product p1 = new Product();
        p1.ProductID = int.Parse(TextBoxId.Text);
        p1.Name = TextBoxName.Text;
       // p1.MyCategory = Category.Parse(SelectProductWindow.SelectedValue);
        p1.Price = double.Parse(TextBoxPrice.Text);
        p1.InStock = int.Parse(TextBoxInStock.Text);

        bl.Product.Add(p1);

    }
}
