using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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

namespace sfia13
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        sfia13Entities context;
        public MainWindow()
        {

            InitializeComponent();
            context = new censorshipEntities();
        }

        private void TextBox_ColorChanged(object sender, RoutedPropertyChangedEventArgs<Color> e)
        {

        }



        private void Button_Click_Reg(object sender, RoutedEventArgs e)
        {
            string login = loginBox.Text.Trim();//без последнего символа типо пробела
            string password = passwordBox.Password.Trim();




            if (login.Contains("!") || login.Contains("?") || login.Contains("%") || login.Contains("#") || login.Contains(","))
            {
                loginBox.ToolTip = "логин введен некорректно!";
                loginBox.Background = Brushes.Red;
            }
            else if (password.Length < 6)
            {
                passwordBox.ToolTip = "пароль введен некорректно! длина не меньше 6 символов!";
                passwordBox.Background = Brushes.Red;
            }
            else
            {
                loginBox.ToolTip = "";//пустая строка чтобы не выскакивало сообщение
                loginBox.Background = Brushes.Transparent;//прозрачный фон
                passwordBox.ToolTip = "";
                passwordBox.Background = Brushes.Transparent;

                Users user = new Users()
                {
                    login = Convert.ToString(loginBox),
                    password = Convert.ToString(passwordBox)

                };

                MessageBox.Show("Регистрация прошла успешно!");
            }
        }