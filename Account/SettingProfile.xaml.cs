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
            List<SettingProfile> logins = new List<SettingProfile>();
            using (StreamWriter sw = new StreamWriter(path_logins))
            using (StreamReader sr = new StreamReader(path_logins))
            {
                while (sr.EndOfStream != true)
                {
                    string[] array = sr.ReadLine().Split(';');
                    
                    if (array[1] == (string)App.Current.Properties["DescriptionLoginUser"])
                    {
                        logins.Add(new SettingProfile
                        {
                            mail = array[0],
                            login = LoginUser.Text,
                            password = array[2],
                            nickname = NickNameUser.Text,
                            description = DescroptionUser.Text,
                        });
                        foreach (SettingProfile user in logins)
                        {
                            sw.WriteLine($"{user.mail};{user.login};{user.password};{user.nickname};{user.description}");
                        }
                    }
                }
            }
            NavigationService.Navigate(new Profile());
        }
    }
}
