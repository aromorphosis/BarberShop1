﻿using System;
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
    /// Логика взаимодействия для AllRecording.xaml
    /// </summary>
    public partial class AllRecording : Window
    {
        List<EF.Recording> ListRecording = new List<EF.Recording>();
        List<EF.TypeService> ListRecording1 = new List<EF.TypeService>();
        List<EF.Service> ListRecording2 = new List<EF.Service>();



        List<string> ListForCBAllRec = new List<string>()
        {
            "По умолчанию",
            "По дате",
            "По времени",
            "По названию услуги",
            "По типу услуги",
        };

        public AllRecording()
        {
            InitializeComponent();
            AllPersonal.ItemsSource = ClassHelper.Class1.context.Recording.ToList();
            AllPersonal.ItemsSource = ClassHelper.Class1.context.Service.ToList();
            AllPersonal.ItemsSource = ClassHelper.Class1.context.TypeService.ToList();
            SearchCBRec.ItemsSource = ListForCBAllRec;
            SearchCBRec.SelectedIndex = 0;
            Filter();
        }

        private void Filter()
        {
            ListRecording = ClassHelper.Class1.context.Recording.ToList();
            ListRecording = ListRecording.
            Where(i => i.DateRecording.Contains(SearchTBRec.Text)
            || i.TimeRecording.Contains(SearchTBRec.Text)).ToList();

            switch (SearchCBRec.SelectedIndex)
            {
                case 0:
                    ListRecording = ListRecording.OrderBy(i => i.IdRecording).ToList();
                    break;

                case 1:
                    ListRecording = ListRecording.OrderBy(i => i.DateRecording).ToList();
                    break;

                case 2:
                    ListRecording = ListRecording.OrderBy(i => i.TimeRecording).ToList();
                    break;

                case 3:
                    ListRecording = ListRecording.OrderBy(i => i.IdService).ToList();
                    break;

                default:
                    ListRecording = ListRecording.OrderBy(i => i.IdRecording).ToList();
                    break;
            }

            if (ListRecording.Count == 0)
            {
                MessageBox.Show("Записи не найдены");
            }

            AllPersonal.ItemsSource = ListRecording;

        }
        private void BackAllRec_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            ServicecAdd servicesAdd = new ServicecAdd();
            servicesAdd.ShowDialog();
            this.Close();
        }

        private void SearchTBRec_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void SearchCBRec_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

    }
}