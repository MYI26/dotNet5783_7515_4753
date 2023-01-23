using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using DalApi;
using static BO.Enums;
using BO;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Windows.Media.Animation;
using System.Windows.Media.Media3D;

namespace PL;

/// <summary>
/// Logique d'interaction pour Window1.xaml
/// </summary>
public partial class ProductListWindow : Window
{

    private static IEnumerable<ProductForList?>? ItmesSource;

    BlApi.IBl? bl = BlApi.Factory.Get();
    public ProductListWindow()
    {
        InitializeComponent();
        ProductListView.ItemsSource = bl?.Product?.GetProductList(null); // sans filtrebl.Product.GetProductList(null)
        CatagorySelector.ItemsSource = Enum.GetValues(typeof(BO.Enums.Category));
        OrderListView.ItemsSource = bl?.Order?.GetOrders();
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
        
        ProductListView.ItemsSource = bl?.Product.GetProductList(fonctioncombox);
    }

    private void Button_Click(object sender, RoutedEventArgs e) { new ProductWindow().Show(); this.Close(); }

    private void DoubleClickProduct(object sender, RoutedEventArgs e) { new ProductWindow((BO.ProductForList)ProductListView.SelectedItem).Show(); this.Close(); }
    private void DoubleClickOrder(object sender, RoutedEventArgs e){ new ProductWindow((BO.OrderForList)OrderListView.SelectedItem).Show();  /*this.Close();*/ }


}
