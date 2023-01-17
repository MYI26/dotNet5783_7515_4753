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
    public partial class PassWord : Window
    {
        public PassWord()
        {
            InitializeComponent();      
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string pass = "eliaouleboss";
            if (PasswordBox.Password == pass) { new ProductListWindow().Show(); this.Close(); }
            else MessageBox.Show("the password not valid");
        }
    }
}
