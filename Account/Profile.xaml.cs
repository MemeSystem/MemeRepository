using System.Windows;
using System.Windows.Controls;

namespace MemeSystem.Account
{
    /// <summary>
    /// Логика взаимодействия для Profile.xaml
    /// </summary>
    public partial class Profile : Page
    {

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
        void NameLabel()
        {
            LoginUser.Content = (string)App.Current.Properties["LoginUser"];
        }
    }
}
