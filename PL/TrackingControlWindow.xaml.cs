using BO;
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

namespace PL
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class TrackingControlWindow : Window
    {
        BlApi.IBl? bl = BlApi.Factory.Get();

        OrderTracking orderT = new OrderTracking();
        


        public TrackingControlWindow()
        {
            InitializeComponent();
            orderT = bl?.Order.Tracking(int.Parse(ForTheOrderId.Text))!;
            d.DataContext = orderT;
          // DisplayAfterValidation.Visibility = Visibility.Collapsed;
          // DisplayBeforeValidation.Visibility = Visibility.Visible;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            
            try
            {
                //appel de la fct Tracking pour initialiser orderT
                orderT = bl?.Order.Tracking(int.Parse(ForTheOrderId.Text))!;
               
                //vérifier les informations entrées avant validation
                if (ForTheName.Text != bl?.Order?.Get(orderT.OrderID)!.CustomerName || ForTheAddress.Text != bl?.Order?.Get(orderT.OrderID)!.CustomerEmail)
                    throw new Exception();
                
                DisplayAfterValidation.DataContext = orderT;
                    //passer à l'écran d'apres la validation
               // DisplayBeforeValidation.Visibility = Visibility.Collapsed;
               // DisplayAfterValidation.Visibility = Visibility.Visible;

                //afficher le le tracking de l'order
               // ForOrderIdDisplay.Text = orderT.OrderID.ToString();
               //orStatutDisplay.Text = orderT.Status.ToString();
               // ListOrderItemForClient.ItemsSource = orderT.Items;
            }
            catch { MessageBox.Show("Jonas ne rentre pas"); }
        }
    }
}
