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
    /// Логика взаимодействия для ServicecAdd.xaml
    /// </summary>
    public partial class ServicecAdd : Window
    {

        public ServicecAdd()
        {
            InitializeComponent();
            cbClients.ItemsSource = context.Client.ToList();
            cbClients.DisplayMemberPath = "FName";
            cbClients.SelectedIndex = 0;

            cbWorker.ItemsSource = context.Worker.ToList();
            cbWorker.DisplayMemberPath = "FName";
            cbWorker.SelectedIndex = 0;

            cbServices.ItemsSource = context.Service.ToList();
            cbServices.DisplayMemberPath = "NameService";
            cbServices.SelectedIndex = 0;

        }

        private void btnBackServ_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Window1 window1 = new Window1();
            window1.ShowDialog();
            this.Close();
        }

        private void btnAddServ_Click(object sender, RoutedEventArgs e)
        {
            var resClick = MessageBox.Show("Добавить запись на услугу?", "Подтверждение.", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (resClick == MessageBoxResult.Yes)
            {
                EF.Recording addRecording = new EF.Recording();
                addRecording.IdClient  = cbClients.SelectedIndex + 1;
                addRecording.IdWorker = cbWorker.SelectedIndex + 1;
                addRecording.IdService = cbServices.SelectedIndex + 1;

                ClassHelper.Class1.context.Recording.Add(addRecording);
                ClassHelper.Class1.context.SaveChanges();

                MessageBox.Show("Запись успешно добавлен.", "Выполнено!", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Hide();
                ServicecAdd servicecAdd = new ServicecAdd();
                servicecAdd.ShowDialog();
                this.Close();
            }
        }
    }
}
