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
using static BarberShop1.ClassHelper.Class1;

namespace BarberShop1
{
    /// <summary>
    /// Логика взаимодействия для Zarplata.xaml
    /// </summary>
    public partial class Zarplata : Window
    {
        public Zarplata()
        {
            InitializeComponent();
            AllPersonalTwo.ItemsSource = context.Worker.ToList();

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Window1 window1 = new Window1();
            window1.ShowDialog();
            this.Close();
        }

        private void Raschet_Click(object sender, RoutedEventArgs e)
        {
            {
                var User = (AllPersonalTwo.SelectedItem as EF.Worker);

                var listServices = context.Recording.ToList().Where(i => i.IdWorker == User.IdWorker).Select(i => i.IdService).ToList();
                 
                double summ = 0;

                foreach (var item in listServices)
                {
                    summ = summ + Convert.ToDouble(context.Service.ToList().Where(i => i.IdService == item).FirstOrDefault().Cost);

                }

                var res = summ * 0.3 * 0.87;

                ZarpltaTB.Text = res.ToString();
            }
        }

    }
}
