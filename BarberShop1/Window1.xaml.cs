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



namespace BarberShop1
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Personal_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            PersonalWindow personalWindow = new PersonalWindow();
            personalWindow.ShowDialog();
            this.Close();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow regPage = new MainWindow();
            regPage.ShowDialog();
            this.Close();
        }

        private void Clients_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Clients clients = new Clients();
            clients.ShowDialog();
            this.Close();
        }

        private void Services_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Services services = new Services();
            services.ShowDialog();
            this.Close();
        }

        private void Record_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            ServicecAdd servicesAdd = new ServicecAdd();
            servicesAdd.ShowDialog();
            this.Close();
        }
    }
}
