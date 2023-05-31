namespace MemeSystem.Account;

public partial class Profile : Page
{
    public Profile()
    {
        InitializeComponent();

        User? user = (User?)Application.Current.Properties["CurrentUser"];
        List<Histories> historis = new();
        using (StreamReader sr = new(Properties.Resources.HistoryPath, Encoding.UTF8))
        {
            while (sr.EndOfStream != true)
            {
                string[] array = sr.ReadLine().Split(';');
                if (array[1] == user.UserName)
                historis.Add(new Histories
                {
                    Text = array[2] + "\n#" + array[3] + "\n\n" + array[4] + "\n\nПонравилось " + array[5] + " людям",
                });
            }
        }
        List.ItemsSource = historis;
    }


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