namespace MemeSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //MainFrame.Navigate(new MainPage());
            //if (true)
            //    MessageBox.Show("пиздишь!", "сообщение о пиздеже");
        }

        private void First_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new TmpPage());
        }

        private void Main_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new MainPage());
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            foreach (MenuItem item in Menu.Items)
            {
                item.Width = ActualWidth / Menu.Items.Count - 20;
            }
        }

        private void Enter(object sender, RoutedEventArgs e)
        {

        }

        private void Registr_Click(object sender, RoutedEventArgs e)
        {
            if (new Registration().ShowDialog() == true)
            {
                MainFrame.Navigate(new TmpPage());
            }
        }

        private void Ent_Click(object sender, RoutedEventArgs e)
        {
            if (new Entrance().ShowDialog() == true)
            {
                MainFrame.Navigate(new TmpPage());
            }
        }

        private void Profile_click(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((User?)Application.Current.Properties["CurrentUser"] is not null)
                {
                    Ent.Visibility = Visibility.Collapsed;
                    Registr.Visibility = Visibility.Collapsed;
                    Me.Visibility = Visibility.Visible;
                    MainFrame.Navigate(new Profile());
                }
                else
                {
                    Ent.Visibility = Visibility.Visible;
                    Registr.Visibility = Visibility.Visible;
                    Me.Visibility = Visibility.Collapsed;
                }
            }
            catch { }
        }

        private void Story_click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Story());
        }
    }
}
