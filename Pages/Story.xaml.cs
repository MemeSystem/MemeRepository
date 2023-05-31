using System.Collections.Immutable;

namespace MemeSystem.Pages
{
    /// <summary>
    /// Логика взаимодействия для Story.xaml
    /// </summary>

    public partial class Story : Page
    {
        public Story()
        {
            InitializeComponent();

            List<Histories> historis = new();
            using (StreamReader sr = new(Properties.Resources.HistoryPath, Encoding.UTF8))
            {
                while (sr.EndOfStream != true)
                {
                    string[] array = sr.ReadLine().Split(';');
                    historis.Add(new Histories
                    {
                        Text = array[2] + "\n#" + array[3] + "\n\n" + array[4] + "\n\nПонравилось " + array[5] + " людям",
                    });
                }
            }
            List.ItemsSource = historis;
        }

        private void Popular_Click(object sender, RoutedEventArgs e)
        {
            List<Histories> historis = new();
            historis.Add(new Histories
            {
                Text = "Топ 3 самых популярных историй"
            });
            using (StreamReader sr = new(Properties.Resources.HistoryPath, Encoding.UTF8))
            {
                while (sr.EndOfStream != true)
                {
                    string[] array = sr.ReadLine().Split(';');
                    historis.Add(new Histories
                    {
                        Text = "Автор: " + array[1] + "\nНазвание: " + array[2] + "\n#" + array[3] + "\n\n" + array[4] + "\n\nПонравилось " + array[5] + " людям",
                        likes = Convert.ToInt32(array[5])
                    });
                }
            }
            List<Histories> popular = new();
            int s, flag = 0;
            s = historis.Max(x => x.likes);
            foreach (Histories history in historis)
            {
                if (s == history.likes)
                {
                    popular.Add(history);
                }
            }
            var h1 = historis.Except(popular).ToList();
            s = h1.Max(x => x.likes);
            foreach (Histories history in h1)
            {
                if (s == history.likes)
                {
                    if (s == history.likes)
                    {
                        popular.Add(history);
                    }
                }
            }
            var h2 = historis.Except(popular).ToList();
            s = h2.Max(x => x.likes);
            foreach (Histories history in h2)
            {
                if (s == history.likes)
                {
                    popular.Add(history);
                }
            }

            List.ItemsSource = popular;
        }


        private void RandomStory_Click(object sender, RoutedEventArgs e)
        {
            List<Histories> historis = new();
            Random rnd = new Random();
            int count = 0;
            using (StreamReader sr = new(Properties.Resources.HistoryPath, Encoding.UTF8))
            {
                while (!sr.EndOfStream)
                {
                    sr.ReadLine();
                    count++;
                }
            }
            int random_story = rnd.Next(1, count+1);
            using (StreamReader sr = new(Properties.Resources.HistoryPath, Encoding.UTF8))
            {
                while (sr.EndOfStream != true)
                {
                    string[] array = sr.ReadLine().Split(';');
                        historis.Add(new Histories
                        {
                            Text = "Автор: " + array[1] + "\nНазвание: " + array[2] + "\n#" + array[3] + "\n\n" + array[4],
                            id = Convert.ToInt32(array[0])
                        });
                }
            }
            List<Histories> historis2 = new();
            foreach (Histories history in historis)
            {
                if (history.id == random_story)
                {
                    historis2.Add(new Histories { Text = history.Text });
                }
            }
            List.ItemsSource = historis2;
        }

        private void Search_Tag_TextChanged(object sender, TextChangedEventArgs e)
        {
            List<Histories> stories = new();
            using (StreamReader sr = new(Properties.Resources.HistoryPath, Encoding.UTF8))
            {
                while (sr.EndOfStream != true)
                {
                    string[] array = sr.ReadLine().Split(';');
                    stories.Add(new Histories
                    {
                        Text = array[2] + "\n#" + array[3] + "\n\n" + array[4] + "\n\nПонравилось " + array[5] + " людям",
                        tag = array[3]
                    });
                }
            }
            List<Histories> stories_by_tag = new();
            foreach (Histories history in stories)
            {
                if (history.tag.ToLower().Contains(Search_Tag.Text.ToLower()))
                {
                    stories_by_tag.Add(new Histories
                    {
                        Text = history.Text,
                    });
                }
            }
            List.ItemsSource = stories_by_tag;
        }
    }
}