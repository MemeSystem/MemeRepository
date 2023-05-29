namespace MemeSystem.Account;

public partial class Profile : Page
{
    public Profile() =>
        InitializeComponent();

    private void Page_Loaded(object sender, RoutedEventArgs e)
    {
        User? currentUser = (User?)Application.Current.Properties["CurrentUser"];
        if (currentUser != null)
        {
            LoginUser.Content = currentUser.UserName;
            NickNameUser.Content = currentUser.FullName;
            DescriptionUser.Text = currentUser.Description;
            try
            {
                byte[] bytes = Convert.FromBase64String(currentUser.Photo);
                BitmapImage image = new();
                image.BeginInit();
                image.StreamSource = new MemoryStream(bytes);
                image.EndInit();
                Photo.Fill = new ImageBrush { ImageSource = image };
            }
            catch { }
        }
    }

    private void Settings_Click(object sender, RoutedEventArgs e) =>
        NavigationService.Navigate(new SettingProfile());
}