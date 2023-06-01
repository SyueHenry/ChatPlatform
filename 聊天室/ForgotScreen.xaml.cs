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
    /// ForgotScreen.xaml 的互動邏輯
    /// </summary>
    public partial class ForgotScreen : Window
    {
        readonly LoginRegisterDB LRDB = new LoginRegisterDB();

        public ForgotScreen()
        {
            InitializeComponent();
        }

        private void ForgotAccount_Checked(object sender, RoutedEventArgs e)
        {
            UserData_Label1.Content = "ID";
            UserData_Label2.Content = "Password";
            UserData_Label2.Visibility = Visibility.Visible;

            UserData_TB1.Text = "";
            UserData_TB1.MaxLength = 10;
            UserData_TB2.Password = "";
            UserData_TB2.Visibility = Visibility.Visible;
        }

        private void ForgotPassword_Checked(object sender, RoutedEventArgs e)
        {
            UserData_Label1.Content = "Account";
            UserData_Label2.Visibility = Visibility.Hidden;

            UserData_TB1.Text = "";
            UserData_TB1.MaxLength = 16;
            UserData_TB2.Visibility = Visibility.Hidden;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            LoginScreen loginScreen = new LoginScreen();
            loginScreen.Show();
            this.Close();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            if(ForgotPassword.IsChecked == true)
            {
                if(LRDB.CompareIAP(UserData_TB1.Text, "Account", "IAP"))
                    MessageBox.Show("您的密碼為：" + LRDB.FoundIAP("Password", "Account", UserData_TB1.Text), "Found", MessageBoxButton.OK, MessageBoxImage.Information);
                else
                    MessageBox.Show("查無此帳號", "Not Found", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if(LRDB.CompareLogin(UserData_TB1.Text, UserData_TB2.Password, "ID", "Password"))
                {
                    MessageBox.Show("您的帳號為：" + LRDB.FoundIAP("Account", "ID", UserData_TB1.Text), "Found", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    MessageBox.Show("查無此ID或密碼", "Not Found", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
