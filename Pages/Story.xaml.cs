using MemeSystem.Account;
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
                        Text = array[1]+ "\n#" + array[2],
                    });
                }
            }

            List.ItemsSource = historis;
        }

        private void Popular_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ByTag_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RandomStory_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
