using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MemeSystem.Account
{
    public partial class SettingProfile : Page
    {
        private BitmapImage? Image { get; set; } = null;
        private byte[]? Bytes { get; set; } = null;
        private string? String { get; set; } = null;

        public SettingProfile()
        {
            InitializeComponent();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {

        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            User? currentUser = (User?)Application.Current.Properties["CurrentUser"];
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
            foreach (User user in users)
            {
                if (user.UserName == currentUser?.UserName)
                {
                    user.UserName = LoginUser.Text;
                    user.FullName = NickNameUser.Text;
                    user.Description = DescriptionUser.Text;
                    user.Password = PasswordUser.Password;
                    if (String != null)
                        user.Photo = String;
                    currentUser.UserName = LoginUser.Text;
                    currentUser.FullName = NickNameUser.Text;
                    currentUser.Description = DescriptionUser.Text;
                    currentUser.Password = PasswordUser.Password;
                    if (String != null)
                        currentUser.Photo = String;
                }
            }
            File.Create(Properties.Resources.UsersPath).Close();
            using (StreamWriter streamWriter = new(Properties.Resources.UsersPath))
            {
                foreach (User user in users)
                {
                    streamWriter.WriteLine(user.ToString());
                }
            }
            NavigationService.Navigate(new Profile());
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Profile());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new();
            bool? result = dialog.ShowDialog();
            if (result == true)
            {
                Bytes = File.ReadAllBytes(dialog.FileName);
                Image = new();
                Image.BeginInit();
                Image.StreamSource = new MemoryStream(Bytes);
                Image.EndInit();
                Photo.Fill = new ImageBrush { ImageSource = Image };
                String = Convert.ToBase64String(Bytes);
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            User? currentUser = (User?)Application.Current.Properties["CurrentUser"];
            if (currentUser != null)
            {
                LoginUser.Text = currentUser.UserName;
                NickNameUser.Text = currentUser.FullName;
                DescriptionUser.Text = currentUser.Description;
                PasswordUser.Password = currentUser.Password;
                try
                {
                    Bytes = Convert.FromBase64String(currentUser.Photo);
                    Image = new();
                    Image.BeginInit();
                    Image.StreamSource = new MemoryStream(Bytes);
                    Image.EndInit();
                    Photo.Fill = new ImageBrush { ImageSource = Image };
                    String = Convert.ToBase64String(Bytes);
                }
                catch { }
            }
        }

        private void PasswordUser_PasswordChanged(object sender, RoutedEventArgs e)
        {
            //if (IsMouseOver) PasswordUser.PasswordChar = '0';
        }
    }
}