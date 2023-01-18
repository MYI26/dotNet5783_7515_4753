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
        ProductListView.ItemsSource = bl?.Product.GetProductList(fonctioncombox);// filter list
                                                                                 //  var temp = Category == Category.None ?
                                                                                 // bl.Product.GetProductList(null) : bl.Product.GetProductList(null).Where(item => item.Category == Category);
                                                                                 //  Products = temp == null ? new() : new(temp);
    }

    private void Button_Click(object sender, RoutedEventArgs e) => new ProductWindow().Show();

    private void DoubleClickProduct(object sender, RoutedEventArgs e) { new ProductWindow((BO.ProductForList)ProductListView.SelectedItem).Show(); }
    private void DoubleClickOrder(object sender, RoutedEventArgs e) => new ProductWindow((BO.OrderForList)OrderListView.SelectedItem).Show();  



//    <Grid.RowDefinitions>
//    <RowDefinition Height = "40*" />
//    < RowDefinition Height="500*"/>
//    <RowDefinition Height = "Auto" />
//</ Grid.RowDefinitions >
//< Grid Name="UpGrid" HorizontalAlignment="Stretch" Height="auto" Grid.Row="0" VerticalAlignment="Stretch" Width="auto">
//    <Grid.ColumnDefinitions>
//        <ColumnDefinition Width = "*" />
//        < ColumnDefinition Width="*"/>
//    </Grid.ColumnDefinitions >
//    <ComboBox Name = "CatagorySelector" Grid.Column="1" HorizontalAlignment="Stretch"  VerticalAlignment="Stretch" SelectionChanged="CatagorySelector_SelectionChanged" FontSize="20" ItemsSource="{Binding Category}" IsEditable="True" />
//    <Label Grid.Column="0" Content= "Category:" Height= "46" RenderTransformOrigin= "0.5,0.5" VerticalContentAlignment= "Center" HorizontalContentAlignment= "Center" Background= "#FFC1C1C1" FontSize= "20" >
//        < Label.RenderTransform >
//            < TransformGroup >
//                < ScaleTransform />
//                < SkewTransform />
//                < RotateTransform Angle= "0" />
//                < TranslateTransform />
//            </ TransformGroup >
//        </ Label.RenderTransform >
//    </ Label >
//</ Grid >
//< ListView Grid.Row= "1" x:Name= "ProductListView" d:ItemsSource= "{Binding ProductForList}" MouseDoubleClick= "DoubleClickUpdate" >
//    < ListView.View >
//        < GridView >
//            < GridViewColumn Header= "ID" Width= "100" DisplayMemberBinding= "{Binding ProductID}" />
//            < GridViewColumn Header= "Name" Width= "130" DisplayMemberBinding= "{Binding Name}" />
//            < GridViewColumn Header= "Category" Width= "120" DisplayMemberBinding= "{Binding Category}" />
//            < GridViewColumn Header= "Price" Width= "100" DisplayMemberBinding= "{Binding Price}" />
//        </ GridView >
//    </ ListView.View >
//</ ListView >

    //< Button x:Name= "ButtonAddProduct" Content= "Add new product" Grid.Row= "2" HorizontalAlignment= "Right" Margin= "5" Padding= "5" Click= "Button_Click" />



    //public void Show()
    // {
    //     Console.WriteLine("me voila");

    // }

}
