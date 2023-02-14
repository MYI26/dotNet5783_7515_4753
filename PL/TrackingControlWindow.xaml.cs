using BO;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;


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
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {           
            try
            {
                //appel de la fct Tracking pour initialiser orderT
                orderT = bl?.Order.Tracking(int.Parse(ForTheOrderId.Text))!;
                DisplayAfterValidation.DataContext = orderT;
                //vérifier les informations entrées avant validation
                if (ForTheName.Text != bl?.Order?.Get(orderT.OrderID)!.CustomerName || ForTheAddress.Text != bl?.Order?.Get(orderT.OrderID)!.CustomerEmail)
                {
                    throw new Exception();
                }
                //passer à l'écran d'apres la validation
                DisplayBeforeValidation.Visibility = Visibility.Collapsed;
                DisplayAfterValidation.Visibility = Visibility.Visible;

                //afficher le le tracking de l'order
                ForOrderIdDisplay.Text = orderT.OrderID.ToString();
                ForStatutDisplay.Text = orderT.Status.ToString();
                ListOrderItemForClient.ItemsSource = orderT.Items;
            }
            catch { MessageBox.Show($"{ForTheName.Text} does not exist in the database"); }
        }
    }
}
