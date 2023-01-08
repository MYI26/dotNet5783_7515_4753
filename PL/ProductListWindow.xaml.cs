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
using BlApi;
using BlImplementation;
using DalApi;
using static BO.Enums;
using BO;

namespace PL;

/// <summary>
/// Logique d'interaction pour Window1.xaml
/// </summary>
public partial class ProductListWindow : Window
{

    private static IEnumerable<ProductForList?>? ItmesSource;
    BlApi.IBl bl = new BlImplementation.Bl();
    public ProductListWindow()
    {
        InitializeComponent();
        ProductListView.ItemsSource = bl?.Product?.GetProductList(null); // sans filtre
        CatagorySelector.ItemsSource = Enum.GetValues(typeof(BO.Enums.Category));

    }


    public DO.Enums.Category Category { get; set; }
    //public BO.Product p;

    public bool fonctioncombox(DO.Product? p = null )
    {
        if (p?.MyCategory == Category)
            return true;
        if ( Category == 0)
            return true;

        else return false;
    }

    //private void CategorySelector_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
   // {
    //    var temp = Category == BO.Enums.Category.piano;
     //       bl?.Product?.GetProductList(null) : bl?.Product?.GetProductList(null).Where(item => item.Category == Category);
    //    Products = temp == null ? new() : new(temp);
   // }
    private void CatagorySelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        //Category = (DO.Enums.Category)sender;
        Category = (DO.Enums.Category)CatagorySelector.SelectedItem;
        // Category = e.;
        //  if (Category == BO.Enums.Category.piano)
        //  var temp = Category.;
        // ProductListView.ItemsSource = bl?.Product?.GetProductList(null).Where(item => item?.Category == Category);
        // Products = temp == null ? new() : new(temp);
        ProductListView.ItemsSource = bl.Product.GetProductList(fonctioncombox);// filter list
      //  var temp = Category == Category.None ?
      // bl.Product.GetProductList(null) : bl.Product.GetProductList(null).Where(item => item.Category == Category);
      //  Products = temp == null ? new() : new(temp);
    }

    private void Button_Click(object sender, RoutedEventArgs e) => new ProductWindow().Show();

    private void DoubleClickUpdate(object sender, RoutedEventArgs e) => new ProductWindow(ProductListView.SelectedItem).Show();









    //public void Show()
    // {
    //     Console.WriteLine("me voila");

    // }

}
