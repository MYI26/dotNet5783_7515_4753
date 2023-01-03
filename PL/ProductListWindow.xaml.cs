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
        ProductListView.ItemsSource = bl?.Product?.GetProductList();
        CatagorySelector.ItemsSource = Enum.GetValues(typeof(BO.Enums.Category));

    }

    private void CatagorySelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        
    }






    //public void Show()
    // {
    //     Console.WriteLine("me voila");

    // }

}
