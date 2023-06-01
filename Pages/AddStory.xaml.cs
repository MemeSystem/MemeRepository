namespace MemeSystem.Pages
{
    /// <summary>
    /// Interaction logic for AddStory.xaml
    /// </summary>
    public partial class AddStory : Page
    {
        public AddStory()
        {
            InitializeComponent();
        }

        private void AddHistory_Click(object sender, RoutedEventArgs e)
        {
            int count = 0;
            User? currentUser = (User?)Application.Current.Properties["CurrentUser"];
            using (StreamReader sw = new StreamReader(Properties.Resources.HistoryPath))
            {
                while (!sw.EndOfStream)
                {
                    sw.ReadLine();
                    count++;
                }
            }
            using (StreamWriter sw = new StreamWriter(Properties.Resources.HistoryPath, true, Encoding.UTF8))
            {
                sw.WriteLine($"{count+1};{currentUser.UserName};{NameHistory.Text};{TagHistory.Text};{TextHistory.Text};{0}");
            }
            MessageBox.Show("Ваша история опубликована.", "Действие выполнено");
            NameHistory.Text = null;
            TagHistory.Text = null;
            TextHistory.Text = null;
        }
    }
}
