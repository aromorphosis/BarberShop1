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
    /// Логика взаимодействия для ServicecAdd.xaml
    /// </summary>
    public partial class ServicecAdd : Window
    {

        public ServicecAdd()
        {
            InitializeComponent();
        }

        private void btnAddServ_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnBackServ_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Window1 window1 = new Window1();
            window1.ShowDialog();
            this.Close();
        }

        private void tbDateServ_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void tbTimeServ_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void cbServicec_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnAllRecording_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AllRecording allRecording = new AllRecording();
            allRecording.ShowDialog();
            this.Close();
        }
    }
}
