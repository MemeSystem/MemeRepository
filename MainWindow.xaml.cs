using MemeSystem.Account;
using MemeSystem.Pages;
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
            foreach(MenuItem item in Menu.Items)
            {
                item.Width = ActualWidth / Menu.Items.Count - 20;
            }
        }

        private void Enter(object sender, RoutedEventArgs e)
        {

        }

        private void Registr_Click(object sender, RoutedEventArgs e)
        {
            if(new Registration().ShowDialog() == true)
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
            bool Enters = (bool)App.Current.Properties["EnterUser"];
            if (Enters == true)
            {
                Ent.Visibility = Visibility.Hidden;
                Registr.Visibility = Visibility.Hidden;
                MainFrame.Navigate(new Profile());
            }
        }

        private void Story_click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Story());
        }
    }
}
