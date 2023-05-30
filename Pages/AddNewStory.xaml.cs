using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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
    /// Логика взаимодействия для AddNewStory.xaml
    /// </summary>
    public partial class AddNewStory : Page
    {
        public AddNewStory()
        {
            InitializeComponent();
        }

        void Method()
        {
            User? currentUser = (User?)Application.Current.Properties["CurrentUser"];
            List<Histories> histories = new();
            int id = 1;
            using (StreamReader sr = new StreamReader(Properties.Resources.HistoryPath))
            {
                while(!sr.EndOfStream)
                {
                    string[] array = sr.ReadLine().Split(';');
                    histories.Add(new Histories
                    {
                        id = Convert.ToInt32(array[0]), //надеюсь, тут не будет ебли со кодом символов
                        Author = array[1],
                        Name = array[2],
                        tag = array[3],
                        Text = array[4],
                        likes = Convert.ToInt32(array[5]),
                    });
                    id++;
                }
            }
            histories.Add(new Histories
            {
                id = id,
                Author = currentUser.FullName,
                Name = StoryName.Text, //тут поставить то, что в ксаэмельхуйне пропишет
                tag = StoryTag.Text,
                Text = StoryText.Text,
                likes = 0
            });
            using (StreamWriter sw = new StreamWriter(Properties.Resources.HistoryPath))
            {
                foreach (Histories hist in histories)
                {
                    sw.WriteLine(hist.ToString());
                }
            }
        }
    }
}
