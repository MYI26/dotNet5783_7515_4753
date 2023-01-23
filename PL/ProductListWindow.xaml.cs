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
        CatagorySelectorOrder.ItemsSource = Enum.GetValues(typeof(BO.Enums.OrderStatus));
        OrderListView.ItemsSource = bl?.Order?.GetOrders(null); 
    }


    public DO.Enums.Category Category { get; set; }
    public BO.Enums.OrderStatus status { get; set; }

    //public BO.Product p;

    public bool fonctioncombox1(DO.Product? p = null)
    {
        if (p?.MyCategory == Category)
            return true;
        if (Category == 0)
            return true;

        else return false;
    }

    public bool fonctioncombox2(BO.Enums.OrderStatus p )
    {

        if (p == status)
            return true;
        if (status == 0)
            return true;

        else return false;
    }


    private void CatagorySelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
       
        Category = (DO.Enums.Category)CatagorySelector.SelectedItem;
        
        ProductListView.ItemsSource = bl?.Product.GetProductList(fonctioncombox1);
    }

    private void CatagorySelector_SelectionChangedOreder(object sender, SelectionChangedEventArgs e)
    {

        status = (BO.Enums.OrderStatus)CatagorySelectorOrder.SelectedItem;

        OrderListView.ItemsSource = bl?.Order?.GetOrders(fonctioncombox2);
    }

    private void Button_Click(object sender, RoutedEventArgs e) { new ProductWindow().Show(); this.Close(); }

    private void DoubleClickProduct(object sender, RoutedEventArgs e) { new ProductWindow((BO.ProductForList)ProductListView.SelectedItem).Show(); this.Close(); }

    private void DoubleClickOrder(object sender, RoutedEventArgs e){ new ProductWindow((BO.OrderForList)OrderListView.SelectedItem).Show(); }


}
