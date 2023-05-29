using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace MemeSystem.Pages
{
    /// <summary>
    /// Логика взаимодействия для Story.xaml
    /// </summary>

    public partial class Story : Page
    {
        public string path_history = "../../../Files/History.csv";
        class History
        {
            public string Text { get; set; } = null!;
            public int id;
            public int likes;
            FJFJFJJFJFJF
        }

        public Story()
        {
            InitializeComponent();

            List<History> historis = new();
            using (StreamReader sr = new(path_history, Encoding.UTF8))
            {
                while (sr.EndOfStream != true)
                {
                    string[] array = sr.ReadLine().Split(';');
                    historis.Add(new History
                    {
                        Text = array[1] + "\n#" + array[2] + "\n\n" + array[3] + "\n\nПонравилось " + array[4] + " людям",
                    });
                }
            }

            List.ItemsSource = historis;
        }

        private void Popular_Click(object sender, RoutedEventArgs e)
        {
            List<History> historis = new();
            historis.Add(new History
            {
                Text = "Топ 3 самых популярных историй"
            });
            using (StreamReader sr = new(path_history, Encoding.UTF8))
            {
                while (sr.EndOfStream != true)
                {
                    string[] array = sr.ReadLine().Split(';');
                    historis.Add(new History
                    {
                        Text = "Автор: " + array[0] + "\nНазвание: " + array[1] + "\n#" + array[2] + "\n\n" + array[3] + "\n\nПонравилось " + array[4] + " людям",
                        likes = Convert.ToInt32(array[4])
                    });
                }
            }
            List<History> popular = new();
            int s, flag = 0;
            s = historis.Max(x => x.likes);
            foreach (History history in historis)
            {
                if (s == history.likes)
                {
                    popular.Add(history);
                }
            }
            var h1 = historis.Except(popular).ToList();
            s = h1.Max(x => x.likes);
            foreach (History history in h1)
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
            foreach (History history in h2)
            {
                if (s == history.likes)
                {
                    popular.Add(history);
                }
            }

            List.ItemsSource = popular;
        }

        private void ByTag_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RandomStory_Click(object sender, RoutedEventArgs e)
        {
            List<History> historis = new();
            int i = 0;
            using (StreamReader sr = new(path_history, Encoding.UTF8))
            {
                while (sr.EndOfStream != true)
                {
                    string[] array = sr.ReadLine().Split(';');
                    i++;
                }
            }
            Random rnd = new Random();
            int random_story = rnd.Next(0, i);
            i = 0;
            using (StreamReader sr = new(path_history, Encoding.UTF8))
            {
                while (sr.EndOfStream != true)
                {
                    string[] array = sr.ReadLine().Split(';');
                    if (i == random_story)
                    {
                        historis.Add(new History
                        {
                            Text = "Автор: " + array[0] + "\nНазвание: " + array[1] + "\n#" + array[2] + "\n\n" + array[3],
                            id = i
                        });
                    }
                    i++;
                }
            }
            List.ItemsSource = historis;
        }
    }
}