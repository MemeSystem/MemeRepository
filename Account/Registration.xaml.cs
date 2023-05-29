using System;
using System.Windows.Navigation;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MemeSystem.Account
{
    /// <summary>
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        private string mail;
        private string login;
        private string password;
        private static string path_logins = "../../../Files/Logins.csv";
        public override string ToString()
        {
            return $"{mail};{login};{password};0;0";
        }
        public Registration() => InitializeComponent();

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {

        }

        private void Label_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void LoginSC(object sender, TextChangedEventArgs e)
        {
            
        }

        private void PasswordSC(object sender, TextChangedEventArgs e)
        {
            
        }

        private void EmailSC(object sender, TextChangedEventArgs e)
        {
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Registration_click(object sender, RoutedEventArgs e)
        {
            //List<object> list = vernul();
            //if (vernul() != null)
            //    Console.WriteLine();
            //else
            //    MessageBox.Show("nihuya ne vernul");
            List<Registration> logins = ReadUsers();

            Regex reg_login = new Regex("[0-9][A-z]{6,}$");
            string his_login = null;
            if (!reg_login.IsMatch(Login.Text)) his_login = Convert.ToString(Login.Text);
            else 
                MessageBox.Show("Введен неверный логин", "Ошибка ввода логина");

            Regex reg_password = new Regex("[0-9][A-z]{6,}");
            string his_password = null;
            if (!reg_password.IsMatch(passwordI.Text)) his_password = Convert.ToString(passwordI.Text);
            else 
                MessageBox.Show("Введен неверный пароль", "Ошибка ввода пароля");

            Regex reg_mail = new Regex("\\W{4,}@\\W\\.\\W");
            string his_mail = null;
            if (!reg_mail.IsMatch(Email.Text)) his_mail = Convert.ToString(Email.Text);
            else
                MessageBox.Show("Введена неверная почта", "Ошибка ввода почты");

            bool used_smth = false;
            foreach (Registration login in logins)
            {
                if (his_login == login.login)
                {
                    MessageBox.Show("Аккаунт с таким логином уже существует");
                    used_smth = true;
                }
                if (his_mail == login.mail)
                {
                    MessageBox.Show("На данную почту уже зарегистрирован аккаунт");
                    used_smth = true;
                }
            }
            if (!used_smth)
            {
                List<Registration> new_logins = ReadUsers();
                if (his_mail != null && his_password != null && his_login != null)
                {
                    new_logins.Add(new Registration
                    {
                        mail = his_mail,
                        login = his_login,
                        password = his_password
                    });
                    WriteUserAccount(new_logins);
                    App.Current.Properties["EnterUser"] = false;
                    this.Close();
                }
            }
            
            static void WriteUserAccount(List<Registration> logins)
            {
                using (StreamWriter streamWriter = new StreamWriter(path_logins, false, Encoding.UTF8))
                {
                    foreach (Registration user in logins)
                    {
                        streamWriter.WriteLine($"{user.mail};{user.login};{user.password}");
                    }
                }
            }
            static List<Registration> ReadUsers() //считывает аккаунты
            {
                List<Registration> logins = new List<Registration>();
                using (StreamReader sr = new StreamReader(path_logins))
                {
                    while (sr.EndOfStream != true)
                    {
                        string[] array = sr.ReadLine().Split(';');
                        logins.Add(new Registration()
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
}
