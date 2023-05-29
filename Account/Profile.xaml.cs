using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace MemeSystem.Account
{
    /// <summary>
    /// Логика взаимодействия для Profile.xaml
    /// </summary>
    public partial class Profile : Page
    {
        private string mail;
        private string login;
        private string password;
        private string nickname;
        private string description;
        private static string path_logins = "../../../Files/Logins.csv";
        public Profile()
        {
            InitializeComponent();
            NameLabel();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //EllipseUserPhoto.Height = EllipseUserPhoto.Height * 10;
            //EllipseUserPhoto.Width = EllipseUserPhoto.Width * 5;
            //BannerImage.Height = BannerImage.ActualHeight * 100;
        }
        private void NameLabel()
        {
            List<Profile> logins = new List<Profile>();
            using (StreamReader sr = new StreamReader(path_logins))
            {
                while (sr.EndOfStream != true)
                {
                    string[] array = sr.ReadLine().Split(';');
                    //logins.Add(new Profile
                    //{
                    //    mail = array[0],
                    //    login = array[1],
                    //    password = array[2],
                    //    nickname = array[3],
                    //    description = array[4]
                    //});
                    if((string)App.Current.Properties["LoginUser"] == array[1])
                    {
                        LoginUser.Content = array[1];
                        NickNameUser.Content = array[3];
                        DescriptionUser.Content = array[4];
                        App.Current.Properties["DescriptionLoginUser"] = array[1];
                        App.Current.Properties["DescriptionNicknameUser"] = array[3];
                        App.Current.Properties["DescriptionDescriptionUser"] = array[4];
                    }
                }
            }
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SettingProfile());
        }
    }
}
