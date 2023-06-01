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
    /// RegisterScreen.xaml 的互動邏輯
    /// </summary>
    public partial class RegisterScreen : Window
    {
        readonly LoginRegisterDB LDRB = new LoginRegisterDB();

        public RegisterScreen()
        {
            InitializeComponent();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            if(ID.Text == "" || Account.Text == "" || Password.Password == "")
                MessageBox.Show("註冊失敗，請確實輸入各項資料", "Faild", MessageBoxButton.OK, MessageBoxImage.Error);
            else
                switch (LDRB.InsertData(ID.Text, Account.Text, Password.Password))
                {
                    case 1:
                        MessageBox.Show("註冊成功", "Successful", MessageBoxButton.OK, MessageBoxImage.Information);
                        break;
                    case 2:
                        MessageBox.Show("註冊失敗，ID與帳號已有重複", "Faild", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                    case 3:
                        MessageBox.Show("註冊失敗，ID已有重複", "Faild", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                    case 4:
                        MessageBox.Show("註冊失敗，帳號已有重複", "Faild", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                    default:
                        MessageBox.Show("註冊失敗，未知錯誤", "Faild", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            LoginScreen loginScreen = new LoginScreen();
            loginScreen.Show();
            this.Close();
        }
    }
}
