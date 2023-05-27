using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MemeSystem.Account
{
    public partial class Entrance : Window
    {
        private string mail;
        private string login;
        private string password;
        private static string path_logins = "../../../Files/Logins.csv";

        public Entrance() => InitializeComponent();

        public override string ToString()
        {
            return $"{mail};{login};{password};0;0";
        }

        private void Label_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void LoginChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void PasswordChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EnterClick(object sender, RoutedEventArgs e)
        {
            List<Entrance> logins = ReadUsers();
            string his_login, his_password;
            bool exist = false, wrong_password =false;
            his_login = Convert.ToString(LoginName.Text);
            his_password = Convert.ToString(PasswordName.Text);
            foreach (Entrance user in logins)
            {
                if ((user.login == his_login) && (user.password != his_password))
                {
                    MessageBox.Show("Неверный пароль");
                    wrong_password = true;
                    //if (Console.ReadLine() == "1") Restore(his_login); НУЖНО ОКНО С ИЗМЕНЕНИЕМ ПАРОЛЯ
                    break;
                }
                else if ((user.login == his_login) && (user.password == his_password))
                {
                    exist = true;
                    break;
                }
            }
            App.Current.Properties["EnterUser"] = exist;
            if (exist) this.Close();
            else if (!wrong_password)
            {
                MessageBox.Show("Аккаунт не найден. Возможно, вы ошиблись в вводе логина и пароля. Повторите ввод.");
            }//переход в основное меню выбора действий для пользователя, что-то типа главного меню
            login = his_login;
            App.Current.Properties["LoginUser"] = his_login;
        }
        public string GetLogin() //для передачи другим методам
        {
            return login;
        }
        static List<Entrance> ReadUsers() //считывает аккаунты
        {
            List<Entrance> logins = new List<Entrance>();
            using (StreamReader sr = new StreamReader(path_logins))
            {
                while (sr.EndOfStream != true)
                {
                    string[] array = sr.ReadLine().Split(';');
                    logins.Add(new Entrance
                    {
                        mail = array[0],
                        login = array[1],
                        password = array[2],
                    });
                }
                return logins;
            }
        }
    }
}