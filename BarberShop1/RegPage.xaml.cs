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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BarberShop1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            var userAuth = ClassHelper.Class1.context.Worker.ToList().
                Where(p => p.Login == this.txtLogin.Text && p.Password == this.txtPassword.Text).
                FirstOrDefault();

            if (userAuth != null)
            {
                this.Hide();
                Window1 window1 = new Window1();
                window1.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Проверьте правильность введенных данных");
            }

        }

        private void Close1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void txtLogin_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                    (
                         textBox.Text.Where(ch => (ch >= 'A' && ch <= 'Z') || (ch >= 'a' && ch <= 'z') || (ch >= '0' && ch <= '9')).ToArray()
                    );
            }
        }

        private void txtPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                    (
                         textBox.Text.Where(ch => (ch >= 'A' && ch <= 'Z') || (ch >= 'a' && ch <= 'z') || (ch >= '0' && ch <= '9')).ToArray()
                    );
            }
        }
    }
}
