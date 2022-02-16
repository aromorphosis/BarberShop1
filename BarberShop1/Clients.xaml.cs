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
    /// Логика взаимодействия для Clients.xaml
    /// </summary>
    public partial class Clients : Window
    {

        List<EF.Client> ListClient = new List<EF.Client>();

        List<string> ListForCBCL = new List<string>()
        {
            "По умолчанию",
            "По почте",
            "По имени",
            "По телефону",
        };

        public Clients()
        {
            InitializeComponent();
            AllPersonal.ItemsSource = ClassHelper.Class1.context.Client.ToList();
            SearchCBCL.ItemsSource = ListForCBCL;
            SearchCBCL.SelectedIndex = 0;
            Filter();
        }

        private void Filter()
        {
            ListClient = ClassHelper.Class1.context.Client.ToList();
            ListClient = ListClient.
            Where(i => i.Email.Contains(SearchTBCL.Text)
            || i.FName.Contains(SearchTBCL.Text)
            || i.NumPhone.Contains(SearchTBCL.Text)).ToList();

            switch (SearchCBCL.SelectedIndex)
            {
                case 0:
                    ListClient = ListClient.OrderBy(i => i.IdClient).ToList();
                    break;

                case 1:
                    ListClient = ListClient.OrderBy(i => i.FName).ToList();
                    break;

                case 2:
                    ListClient = ListClient.OrderBy(i => i.NumPhone).ToList();
                    break;

                case 3:
                    ListClient = ListClient.OrderBy(i => i.Email).ToList();
                    break;

                default:
                    ListClient = ListClient.OrderBy(i => i.IdClient).ToList();
                    break;
            }

            if (ListClient.Count == 0)
            {
                MessageBox.Show("Записи не найдены");
            }

            AllPersonal.ItemsSource = ListClient;

        }

        private void BackCL_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Window1 window1 = new Window1();
            window1.ShowDialog();
            this.Close();
        }

        private void SearchCBCL_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();

        }

        private void AddBtnCL_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AddClients addClients = new AddClients();
            addClients.ShowDialog();
            this.Close();
            Filter();
        }

        private void SearchTBCL_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void AllPersonal_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete || e.Key == Key.Back)
            {
                var resClick = MessageBox.Show($"Удалить пользователя {(AllPersonal.SelectedItem as EF.Client).FName}", "Подтвержение", MessageBoxButton.YesNo, MessageBoxImage.Information);


                if (resClick == MessageBoxResult.Yes)
                {
                    EF.Client client = new EF.Client();
                    if (!(AllPersonal.SelectedItem is EF.Client))
                    {
                        MessageBox.Show("Запись не выбраны");
                        return;
                    }
                    client = AllPersonal.SelectedItem as EF.Client;

                    ClassHelper.Class1.context.Client.Remove(client);
                    ClassHelper.Class1.context.SaveChanges();
                }
            }
            Filter();
        }
    }
}
