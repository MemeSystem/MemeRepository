using MemeSystem.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MemeSystem.Account
{
    public partial class Entrance : Window
    {
        public Entrance() =>
            InitializeComponent();

        private void Label_MouseDoubleClick(object sender, MouseButtonEventArgs e) =>
            DialogResult = false;

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) =>
            DragMove();

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
            List<User> users = ReadUsers();
            string userName = LoginName.Text,
                password = PasswordName.Text;
            foreach (User user in users)
            {
                if ((user.UserName == userName) && (user.Password != password))
                {
                    MessageBox.Show("Неверный пароль");
                    break;
                }
                else if ((user.UserName == userName) && (user.Password == password))
                {
                    Application.Current.Properties["CurrentUser"] = user;
                    DialogResult = true;
                }
            }
        }

        //public string GetLogin() => //для передачи другим методам
        //    login;

        static List<User> ReadUsers() //считывает аккаунты
        {
            List<User> users = new();
            using (StreamReader sr = new(Properties.Resources.UsersPath))
            {
                while (sr?.EndOfStream != null)
                {
                    string? line = sr.ReadLine();
                    if (line != null)
                    {
                        string[] array = line.Split(';');
                        users.Add(new User
                        {
                            Email = array[0],
                            UserName = array[1],
                            Password = array[2],
                            FullName = array[3],
                            Description = array[4],
                            Photo = array[5]
                        });
                    }
                    else break;
                }
            }
            return users;
        }
    }
}