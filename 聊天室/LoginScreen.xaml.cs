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
using System.Windows.Shapes;

namespace 聊天室
{
    /// <summary>
    /// LoginScreen.xaml 的互動邏輯
    /// </summary>
    public partial class LoginScreen : Window
    {
        public static string accountBag;
        readonly LoginRegisterDB LRDB = new LoginRegisterDB();

        public LoginScreen()
        {
            InitializeComponent();
            ClientServer clientServer = new ClientServer();
            clientServer.ConnectToServer();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if (LRDB.CompareLogin(Account.Text, Password.Password, "Account", "Password"))
            {
                accountBag = Account.Text;
                ClientScreen clientWindow = new ClientScreen();
                clientWindow.Show();
                this.Close();
            }
            else
                MessageBox.Show("帳號或密碼錯誤", "Login error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            RegisterScreen registerScreen = new RegisterScreen();
            registerScreen.Show();
            this.Close();
        }

        private void Forgot_Click(object sender, RoutedEventArgs e)
        {
            ForgotScreen forgotScreen = new ForgotScreen();
            forgotScreen.Show();
            this.Close();
        }
    }
}
