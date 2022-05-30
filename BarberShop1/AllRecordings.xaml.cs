using BarberShop1.EF;
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
    /// Логика взаимодействия для AllRecordings.xaml
    /// </summary>
    public partial class AllRecordings : Window
    {

        List<EF.Recording> ListRec = new List<EF.Recording>();

        List<string> ListForCBSearch = new List<string>()
        {
            "По умолчанию",
            "По клиенту",
            "По услуге",
            "По работнику"
        };

        public AllRecordings()
        {
            InitializeComponent();
            AllRecorging.ItemsSource = ClassHelper.Class1.context.Recording.ToList();
            SearchCB.ItemsSource = ListForCBSearch;
            SearchCB.SelectedIndex = 0;
            Filter();
        }

        private void Filter()
        {
            ListRec = ClassHelper.Class1.context.Recording.ToList();
            ListRec = ListRec.
            Where(i => i.CLIENT.Contains(SearchTB.Text)
            || i.SERVICE.Contains(SearchTB.Text)
            || i.WORKER.Contains(SearchTB.Text)).ToList();

            switch (SearchCB.SelectedIndex)
            {
                case 0:
                    ListRec = ListRec.OrderBy(i => i.IdClient).ToList();
                    break;

                case 1:
                    ListRec = ListRec.OrderBy(i => i.CLIENT).ToList();
                    break;

                case 2:
                    ListRec = ListRec.OrderBy(i => i.SERVICE).ToList();
                    break;

                case 3:
                    ListRec = ListRec.OrderBy(i => i.WORKER).ToList();
                    break;

                default:
                    ListRec = ListRec.OrderBy(i => i.IdClient).ToList();
                    break;
            }

            if (ListRec.Count == 0)
            {
                MessageBox.Show("Записи не найдены");
            }

            AllRecorging.ItemsSource = ListRec;
        }

        private void AddBtnSer_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            ServicecAdd servicecAdd = new ServicecAdd();
            servicecAdd.ShowDialog();
            this.Close();
        }

        private void BackSer_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Services services = new Services();
            services.ShowDialog();
            this.Close();
        }

        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void SearchCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }
    }
}
