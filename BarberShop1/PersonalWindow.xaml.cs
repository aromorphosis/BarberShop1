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
    /// Логика взаимодействия для PersonalWindow.xaml
    /// </summary>
    public partial class PersonalWindow : Window
    {

        List<EF.Worker> ListWorker = new List<EF.Worker>();

        List<string> ListForCB = new List<string>()
        {
            "По умолчанию",
            "По фамилии",
            "По имени",
            "По телефону",
        };

        public PersonalWindow()
        {
            InitializeComponent();
            AllPersonalTwo.ItemsSource = context.Worker.ToList();
            SearchCB.ItemsSource = ListForCB;
            SearchCB.SelectedIndex = 0;
            Filter();
        }

        private void Filter()
        {
            ListWorker = ClassHelper.Class1.context.Worker.ToList();
            ListWorker = ListWorker.
            Where(i => i.LName.Contains(SearchTB.Text) 
            || i.FName.Contains(SearchTB.Text)
            || i.Phone.Contains(SearchTB.Text)).ToList();

            switch (SearchCB.SelectedIndex)
            {
                case 0:
                    ListWorker = ListWorker.OrderBy(i => i.IdWorker).ToList();
                    break;

                case 1:
                    ListWorker = ListWorker.OrderBy(i => i.LName).ToList();
                    break;

                case 2:
                    ListWorker = ListWorker.OrderBy(i => i.FName).ToList();
                    break;

                case 3:
                    ListWorker = ListWorker.OrderBy(i => i.Phone).ToList();
                    break;

                default:
                    ListWorker = ListWorker.OrderBy(i => i.IdWorker).ToList();
                    break;
            }

            if (ListWorker.Count == 0)
            {
                MessageBox.Show("Записи не найдены");
            }

            AllPersonalTwo.ItemsSource = ListWorker;

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Window1 window1 = new Window1();
            window1.ShowDialog();
            this.Close();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Adding adding = new Adding();
            adding.ShowDialog();
            Filter();
        }


        private void SearchTB_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void SearchCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();

        }

        private void AllPersonal_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete || e.Key == Key.Back)
            {
                var resClick = MessageBox.Show($"Удалить работника {(AllPersonalTwo.SelectedItem as EF.Worker).FName}", "Подтвержение", MessageBoxButton.YesNo, MessageBoxImage.Information);


                if (resClick == MessageBoxResult.Yes)
                {
                    EF.Worker worker = new EF.Worker();
                    if (!(AllPersonalTwo.SelectedItem is EF.Worker)) 
                    {
                        MessageBox.Show("Запись не выбрана");
                        return;
                    }
                    worker = AllPersonalTwo.SelectedItem as EF.Worker;

                    ClassHelper.Class1.context.Worker.Remove(worker);
                    ClassHelper.Class1.context.SaveChanges();
                }
            }
            Filter();
        }
    }
}