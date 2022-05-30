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
    /// Логика взаимодействия для Services.xaml
    /// </summary>
    public partial class Services : Window
    {
        List<EF.Service> ListService = new List<EF.Service>();

        List<string> ListForCBSer = new List<string>()
        {
            "По умолчанию",
            "По названию услуги",
            "По цене",
        };

        public Services()
        {
            InitializeComponent();
            AllPersonal.ItemsSource = ClassHelper.Class1.context.Service.ToList();
            SearchCBSer.ItemsSource = ListForCBSer;
            SearchCBSer.SelectedIndex = 0;
            Filter();
        }

        private void Filter()
        {
            ListService = ClassHelper.Class1.context.Service.ToList();
            ListService = ListService.Where(i => i.NameService.Contains(SearchTBSer.Text)
            || i.Cost == Convert.ToDecimal(SearchTBSer.Text)).ToList();

            switch (SearchCBSer.SelectedIndex)
            {
                case 0:
                    ListService = ListService.OrderBy(i => i.IdService).ToList();
                    break;

                case 1:
                    ListService = ListService.OrderBy(i => i.NameService).ToList();
                    break;

                case 2:
                    ListService = ListService.OrderBy(i => i.Cost).ToList();
                    break;

                default:
                    ListService = ListService.OrderBy(i => i.IdService).ToList();
                    break;
            }

            if (ListService.Count == 0)
            {
                MessageBox.Show("Записи не найдены");
            }

            AllPersonal.ItemsSource = ListService;

        }

        private void BackSer_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Window1 window1 = new Window1();
            window1.ShowDialog();
            this.Close();
        }

        private void SearchTBSer_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void SearchCBSer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void AddBtnSer_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AllRecordings allRecordings = new AllRecordings();
            allRecordings.ShowDialog();
            this.Close();
        }
    }
}
