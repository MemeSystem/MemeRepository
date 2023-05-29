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
    /// <summary>
    /// Логика взаимодействия для SettingProfile.xaml
    /// </summary>
    public partial class SettingProfile : Page
    {
        private BitmapImage? Image { get; set; } = null;
        private byte[]? Bytes { get; set; } = null;
        private string? String { get; set; } = null;

        private string mail;
        private string login;
        private string password;
        private string nickname;
        private string description;
        private static string path_logins = "../../../Files/Logins.csv";
        public SettingProfile()
        {
            InitializeComponent();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {

        }

        private void Label_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
        //    try
        //    {
        //        if (Bytes != null)
        //        {
        //            Image = new();
        //            Image.BeginInit();
        //            Image.StreamSource = new MemoryStream(Bytes);
        //            Image.EndInit();
        //            PhotoUserEllips.ImageSource = new ImageSource()
        //            {
        //                Fill = new ImageBrush { ImageSource = Image }
        //            };
        //            String = Convert.ToBase64String(Bytes);
        //        }
        //    }
        //    catch { }
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Profile());
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            List<SettingProfile> data = ReadUsers();
            List<SettingProfile> new_data = new();
            string new_login = Convert.ToString(LoginUser.Text);
            bool ABSOLUTELY_new_login = true;
            foreach(SettingProfile profile in data)
            {
                if ((profile.login == new_login) && ((string)App.Current.Properties["DescriptionLoginUser"] != new_login))
                {
                    ABSOLUTELY_new_login = false;
                    MessageBox.Show("Логин уже существует");
                }
                else if (profile.login == (string)App.Current.Properties["DescriptionLoginUser"])
                {
                    new_data.Add(new SettingProfile
                    {
                        mail = profile.mail,
                        login = profile.login,
                        password = profile.password,
                        nickname = NickNameUser.Text,
                        description = DescroptionUser.Text,
                    });
                }
                else
                {
                    new_data.Add(new SettingProfile
                    {
                        mail = profile.mail,
                        login = profile.login,
                        password = profile.password,
                        nickname = profile.nickname,
                        description = profile.description,
                    });
                }
            }
            if (ABSOLUTELY_new_login)
            {
                using (StreamWriter sw = new StreamWriter(new_login, false, Encoding.UTF8))
                {
                    foreach (SettingProfile profile in new_data)
                    {
                        sw.WriteLine($"{profile.mail};{profile.login};{profile.password};{profile.nickname};{profile.description}");
                    }
                }
            }
            NavigationService.Navigate(new Profile());
        }
        static List<SettingProfile> ReadUsers() //считывает аккаунты
        {
            List<SettingProfile> data = new();
            using (StreamReader sr = new StreamReader(path_logins))
            {
                while (sr.EndOfStream != true)
                {
                    string[] array = sr.ReadLine().Split(';');
                    data.Add(new SettingProfile
                    {
                        mail = array[0],
                        login = array[1],
                        password = array[2],
                        nickname = array[3],
                        description = array[4]
                    });
                }
            }
            return data;
        }
    }
}
