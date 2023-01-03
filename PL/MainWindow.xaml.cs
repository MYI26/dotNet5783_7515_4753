using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BlApi;
using BlImplementation;

namespace PL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        BlApi.IBl bl = new BlImplementation.Bl();
        //private static IBL bl;
        public MainWindow()
        {
            InitializeComponent();

        }

        private void ___ShowProductListViewButton_Click__Click(object sender, RoutedEventArgs e) => new ProductListWindow().Show();
       
         
    }
}
