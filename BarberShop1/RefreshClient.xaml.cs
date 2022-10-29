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
using BarberShop1.EF;
using static BarberShop1.ClassHelper.Class1;

namespace BarberShop1
{
    /// <summary>
    /// Логика взаимодействия для RefreshClient.xaml
    /// </summary>
    public partial class RefreshClient : Window
    {
        public RefreshClient()
        {
            InitializeComponent();
        }

        public RefreshClient(Client client)
        {
            InitializeComponent();
            tbCLFName.Text = client.FName;
            tbEmail.Text = client.Email;
            tbCLPhone.Text = client.NumPhone;
            tbLCLogin.Text = client.Login;
            tbCLPassword1.Text = client.Password;
        }

        private void tbCLFName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void tbEmail_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void tbCLPhone_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void tbLCLogin_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void tbCLPassword1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void tbCLRePassword_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnCLAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCLBack_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Client client = new Client();

            client.FName = tbCLFName.Text;
            client.Email = tbEmail.Text;
            client.NumPhone = tbCLPhone.Text;
            client.Login = tbLCLogin.Text;
            client.Password = tbCLPassword1.Text;

            ClassHelper.Class1.context.SaveChanges();
            MessageBox.Show("Успех");
            this.Close();
        }
    }
}
