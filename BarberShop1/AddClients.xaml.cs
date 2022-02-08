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
    /// Логика взаимодействия для AddClients.xaml
    /// </summary>
    public partial class AddClients : Window
    {
        public AddClients()
        {
            InitializeComponent();
        }

        private void tbCLFName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                    (
                         textBox.Text.Where(ch => (ch >= 'а' && ch <= 'я') || (ch >= 'А' && ch <= 'Я') || ch == 'ё' || ch == 'Ё' || (ch >= 'A' && ch <= 'Z') || (ch >= 'a' && ch <= 'z')).ToArray()
                    );
            }
        }

        private void tbEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                    (
                         textBox.Text.Where(ch => (ch >= 'A' && ch <= 'Z') || (ch >= 'a' && ch <= 'z') || ch >= '@' || ch >= '.').ToArray()
                    );
            }
        }

        private void tbCLPhone_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                    (
                         textBox.Text.Where(ch => ch == '+' || (ch >= '0' && ch <= '9') || ch == '(' || ch == ')').ToArray()
                    );
            }
        }

        private void tbLCLogin_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                    (
                         textBox.Text.Where(ch => (ch >= 'A' && ch <= 'Z') || (ch >= 'a' && ch <= 'z') || (ch >= '0' && ch <= '9')).ToArray()
                    );
            }
        }

        private void tbCLPassword1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                    (
                         textBox.Text.Where(ch => (ch >= 'A' && ch <= 'Z') || (ch >= 'a' && ch <= 'z') || (ch >= '0' && ch <= '9')).ToArray()
                    );
            }
        }

        private void tbCLRePassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                    (
                         textBox.Text.Where(ch => (ch >= 'A' && ch <= 'Z') || (ch >= 'a' && ch <= 'z') || (ch >= '0' && ch <= '9')).ToArray()
                    );
            }
        }

        private void btnCLAdd_Click(object sender, RoutedEventArgs e)
        {
            {
                if (string.IsNullOrWhiteSpace(tbCLFName.Text))
                {
                    MessageBox.Show("Заполните поле имя!", "Ошибка!", MessageBoxButton.OK);
                    return;
                }
                if (string.IsNullOrWhiteSpace(tbEmail.Text))
                {
                    MessageBox.Show("Заполните поле электронной почты!", "Ошибка!", MessageBoxButton.OK);
                    return;
                }
                if (string.IsNullOrWhiteSpace(tbCLPhone.Text))
                {
                    MessageBox.Show("Заполните поле телефон!", "Ошибка!", MessageBoxButton.OK);
                    return;
                }
                if (string.IsNullOrWhiteSpace(tbLCLogin.Text))
                {
                    MessageBox.Show("Заполните поле логин!", "Ошибка!", MessageBoxButton.OK);
                    return;
                }
                if (string.IsNullOrWhiteSpace(tbCLPassword1.Text))
                {
                    MessageBox.Show("Заполните поле пароль!", "Ошибка!", MessageBoxButton.OK);
                    return;
                }
                if (tbCLRePassword.Text != tbCLPassword1.Text)
                {
                    MessageBox.Show("Пароли не совпадают!", "Ошибка!", MessageBoxButton.OK);
                    return;
                }

                try
                {
                    var resClick = MessageBox.Show("Добавить пользователя?", "Подтверждение.", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (resClick == MessageBoxResult.Yes)
                    {
                        EF.Client addClient = new EF.Client();
                        addClient.FName = tbCLFName.Text;
                        addClient.FName = tbEmail.Text;
                        addClient.NumPhone = tbCLPhone.Text;
                        addClient.Login = tbLCLogin.Text;
                        addClient.Password = tbCLPassword1.Text;

                        ClassHelper.Class1.context.Client.Add(addClient);
                        ClassHelper.Class1.context.SaveChanges();

                        MessageBox.Show("Пользователь успешно добавлен.", "Выполнено!", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.Hide();
                        PersonalWindow personalWindow = new PersonalWindow();
                        personalWindow.ShowDialog();
                        this.Close();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                    throw;
                }
            }
        }

        private void btnCLBack_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Clients clients = new Clients();
            clients.ShowDialog();
            this.Close();
        }
    }
}
