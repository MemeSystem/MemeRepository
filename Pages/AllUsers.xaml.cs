using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для AllUsers.xaml
    /// </summary>
    public partial class AllUsers : Page
    {
        public AllUsers()
        {
            InitializeComponent();

            List<User> Users = new();
            using (StreamReader sr = new(Properties.Resources.UsersPath, Encoding.UTF8))
            {
                while (sr.EndOfStream != true)
                {
                    string[] array = sr.ReadLine().Split(';');
                    Users.Add(new User
                    {
                        UserName = array[1] + "\n" + array[3] + "\n\n" + "----------------------" + array[4],
                    });
                }
            }
            List.ItemsSource = Users;
        }
    }
}
