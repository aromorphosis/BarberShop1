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
    /// Логика взаимодействия для Adding.xaml
    /// </summary>
    public partial class Adding : Window
    {
        public Adding()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            {
                if (string.IsNullOrWhiteSpace(tbFName.Text))
                {
                    MessageBox.Show("Заполните поле имя!", "Ошибка!", MessageBoxButton.OK);
                    return;
                }
                if (string.IsNullOrWhiteSpace(tbLName.Text))
                {
                    MessageBox.Show("Заполните поле фамилия!", "Ошибка!", MessageBoxButton.OK);
                    return;
                }
                if (string.IsNullOrWhiteSpace(tbPhone.Text))
                {
                    MessageBox.Show("Заполните поле телефон!", "Ошибка!", MessageBoxButton.OK);
                    return;
                }
                if (string.IsNullOrWhiteSpace(tbLogin.Text))
                {
                    MessageBox.Show("Заполните поле логин!", "Ошибка!", MessageBoxButton.OK);
                    return;
                }
                if (string.IsNullOrWhiteSpace(tbPassword1.Text))
                {
                    MessageBox.Show("Заполните поле пароль!", "Ошибка!", MessageBoxButton.OK);
                    return;
                }
                if (tbRePassword.Text != tbPassword1.Text)
                {
                    MessageBox.Show("Пароли не совпадают!", "Ошибка!", MessageBoxButton.OK);
                    return;
                }

                try
                {
                    var resClick = MessageBox.Show("Добавить пользователя?", "Подтверждение.", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (resClick == MessageBoxResult.Yes)
                    {
                        EF.Worker addWorker = new EF.Worker();
                        addWorker.FName = tbFName.Text;
                        addWorker.LName = tbLName.Text;
                        addWorker.Phone = tbPhone.Text;
                        addWorker.Login = tbLogin.Text;
                        addWorker.Password = tbPassword1.Text;

                        ClassHelper.Class1.context.Worker.Add(addWorker);
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

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            PersonalWindow personalWindow = new PersonalWindow();
            personalWindow.ShowDialog();
            this.Close();
        }

        private void tbFName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                    (
                         textBox.Text.Where(ch => (ch >= 'а' && ch <= 'я') || (ch >= 'А' && ch <= 'Я') || ch == 'ё' ||  ch == 'Ё' || (ch >= 'A' && ch <= 'Z') || (ch >= 'a' && ch <= 'z')).ToArray()
                    );
            }
        }

        private void tbLName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                    (
                         textBox.Text.Where(ch => (ch >= 'а' && ch <= 'я')||(ch >= 'А' && ch <= 'Я') ||  ch == 'ё' || ch == 'Ё' || (ch >= 'A' && ch <= 'Z')||(ch >= 'a' && ch <= 'z')).ToArray()
                    );
            }
        }

        private void tbPhone_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                    (
                         textBox.Text.Where(ch => ch == '+' || (ch >= '0' && ch <= '9') || ch == '(' || ch == ')').ToArray()
                    );
            }
        }

        private void tbLogin_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                    (
                         textBox.Text.Where(ch => (ch >= 'A' && ch <= 'Z') || (ch >= 'a' && ch <= 'z') || (ch >= '0' && ch <= '9')).ToArray()
                    );
            }
        }

        private void tbPassword1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                    (
                         textBox.Text.Where(ch => (ch >= 'A' && ch <= 'Z') || (ch >= 'a' && ch <= 'z') || (ch >= '0' && ch <= '9')).ToArray()
                    );
            }
        }

        private void tbRePassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                    (
                         textBox.Text.Where(ch => (ch >= 'A' && ch <= 'Z') || (ch >= 'a' && ch <= 'z') || (ch >= '0' && ch <= '9')).ToArray()
                    );
            }
        }
    }
}
