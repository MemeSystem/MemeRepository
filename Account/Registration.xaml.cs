using System.Text.RegularExpressions;
using System.Windows.Input;

namespace MemeSystem.Account
{
    public partial class Registration : Window
    {
        private BitmapImage? Image { get; set; } = null;
        private byte[]? Bytes { get; set; } = null;
        private string? String { get; set; } = null;
        public Registration() => InitializeComponent();

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {

        }

        private void Label_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void LoginSC(object sender, TextChangedEventArgs e)
        {

        }

        private void PasswordSC(object sender, TextChangedEventArgs e)
        {

        }

        private void EmailSC(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Registration_click(object sender, RoutedEventArgs e)
        {
            Bytes = File.ReadAllBytes(Properties.Resources.NounameUserPhoto);
            Image = new();
            Image.BeginInit();
            Image.StreamSource = new MemoryStream(Bytes);
            Image.EndInit();
            ImageBrush photos = new ImageBrush { ImageSource = Image };
            String = Convert.ToBase64String(Bytes);

            List<User> logins = ReadUsers();

            Regex reg_login = new Regex("[0-9][A-z]{6,}$");
            string his_login = null;
            if (!reg_login.IsMatch(Login.Text)) his_login = Convert.ToString(Login.Text);
            else
                MessageBox.Show("Введен неверный логин", "Ошибка ввода логина");

            Regex reg_password = new Regex("[0-9][A-z]{6,}");
            string his_password = null;
            if (!reg_password.IsMatch(passwordI.Text)) his_password = Convert.ToString(passwordI.Text);
            else
                MessageBox.Show("Введен неверный пароль", "Ошибка ввода пароля");

            Regex reg_mail = new Regex("\\W{4,}@\\W\\.\\W");
            string his_mail = null;
            if (!reg_mail.IsMatch(Email.Text)) his_mail = Convert.ToString(Email.Text);
            else
                MessageBox.Show("Введена неверная почта", "Ошибка ввода почты");

            bool used_smth = false;
            foreach (User login in logins)
            {
                if (his_login == login.UserName)
                {
                    MessageBox.Show("Аккаунт с таким логином уже существует");
                    used_smth = true;
                }
                if (his_mail == login.Email)
                {
                    MessageBox.Show("На данную почту уже зарегистрирован аккаунт");
                    used_smth = true;
                }
            }
            if (!used_smth)
            {
                List<User> new_logins = ReadUsers();
                if (his_mail != null && his_password != null && his_login != null)
                {
                    new_logins.Add(new User
                    {
                        Email = his_mail,
                        UserName = his_login,
                        Password = his_password,
                        FullName = "User" + logins.Count,
                        Description = "Я новый пользователь Meme System!",
                        Photo = String //Миша, помоги
                    });
                    WriteUserAccount(new_logins);
                    App.Current.Properties["EnterUser"] = false;
                    this.Close();
                }
            }
            if ((his_login is null) || (his_password is null)||(his_mail is null))
            {
                MessageBox.Show("Необходимо ввести все данные!", "Пустое поле");
            }

            static void WriteUserAccount(List<User> logins)
            {
                using (StreamWriter streamWriter = new StreamWriter(Properties.Resources.UsersPath, false, Encoding.UTF8))
                {
                    foreach (User user in logins)
                    {
                        streamWriter.WriteLine(user.ToString());
                    }
                }
            }
            static List<User> ReadUsers() //считывает аккаунты
            {
                List<User> logins = new List<User>();
                using (StreamReader sr = new StreamReader(Properties.Resources.UsersPath))
                {
                    while (sr.EndOfStream != true)
                    {
                        string[] array = sr.ReadLine().Split(';');
                        if (array != null)
                        {
                            logins.Add(new User()
                            {
                                Email = array[0],
                                UserName = array[1],
                                Password = array[2],
                                FullName = array[3],
                                Description = array[4],
                                Photo = array[5]
                            });
                        }

                    }
                    return logins;
                }
            }
        }
    }
}
