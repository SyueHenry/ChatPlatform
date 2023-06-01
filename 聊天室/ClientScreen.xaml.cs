using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
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
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class ClientScreen : Window
    {
        public static int IndexRecord { get; set; }
        public static string ID { get; set; }
        public static string[] ChatRecord = new string[256];
        public List<string> FriendCheckString { get; set; }
        public static List<string> FriendString { get; set; }
        public List<Label> FriendCheckLabel = new List<Label>();
        public List<Button> FriendCheckYes = new List<Button>();
        public List<Button> FriendCheckNo = new List<Button>();
        readonly private static LoginRegisterDB LRDB = new LoginRegisterDB();
        ClientServer clientServer = new ClientServer();
        public static string isYoursNews;
        Thread t;

        public ClientScreen()
        {
            InitializeComponent();
            ID = LRDB.FoundIAP("ID", "Account", LoginScreen.accountBag);
            UpdateStackPanel();
            t = new Thread(LoadingChatLog);
            t.Start();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            if (LRDB.FriendStateCheck(ID_TB.Text, ID))
            {
                ID_Label.Visibility = Visibility.Visible;
                Add.Visibility = Visibility.Visible;
                Cancel.Visibility = Visibility.Visible;

                ID_Label.Content = ID_TB.Text;
                Add.IsEnabled = false;
                Cancel.IsEnabled = false;
            }
            else if (LRDB.CompareIAP(ID_TB.Text, "ID", "IAP") && ID != ID_TB.Text)
            {
                ID_Label.Visibility = Visibility.Visible;
                Add.Visibility = Visibility.Visible;
                Cancel.Visibility = Visibility.Visible;

                ID_Label.Content = ID_TB.Text;
                if (LRDB.CompareIAP(ID, "Friend_Check", ID_TB.Text))
                {
                    Add.IsEnabled = false;
                    Cancel.IsEnabled = true;
                }
                else
                {
                    Add.IsEnabled = true;
                    Cancel.IsEnabled = false;
                }
            }
            else
                MessageBox.Show("查無此ID", "Not Found", MessageBoxButton.OK, MessageBoxImage.Error);
            ClearData();
            UpdateStackPanel();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if(LRDB.FriendStateCheck(ID_Label.Content.ToString(), ID))
            {
                MessageBox.Show("對方已經是你好友或者等待確認中");
                Add.IsEnabled = false;
                Cancel.IsEnabled = false;
            }
            else
            {
                LRDB.InsertFriend(ID, ID_Label.Content.ToString(), "Friend_Check");
                MessageBox.Show("成功送出邀請", "Successful", MessageBoxButton.OK, MessageBoxImage.Information);
                Add.IsEnabled = false;
                Cancel.IsEnabled = true;
            }
            ClearData();
            UpdateStackPanel();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            if (LRDB.FriendStateCheck(ID_Label.Content.ToString(), ID))
            {
                MessageBox.Show("對方已經是你好友");
                Add.IsEnabled = false;
                Cancel.IsEnabled = false;
            }
            else
            {
                LRDB.DeleteFriend(ID, ID_Label.Content.ToString(), "Friend_Check");
                MessageBox.Show("成功取消邀請或者對方已取消邀請", "Successful", MessageBoxButton.OK, MessageBoxImage.Information);
                Add.IsEnabled = true;
                Cancel.IsEnabled = false;
            }
            ClearData();
            UpdateStackPanel();
        }

        private void UpdateFriendListBox()
        {
            FriendString = LRDB.SelectFriendCheck(ID, "Friend");
            for (int i = 0; i < FriendString.Count; i++)
            {
                if (FriendString[i] == "1a2b3c4d5e")
                    continue;
                Friend_ListBox.Items.Add(FriendString[i]);
            }
        }

        private void UpdateStackPanel()
        {
            ClearData();
            FriendCheckString = LRDB.SelectFriendCheck(ID, "Friend_Check");
            for(int i = 0; i < FriendCheckString.Count; i++)
            {
                if (FriendCheckString[i] == "1a2b3c4d5e")
                    continue;
                FriendCheckLabel.Add(new Label() { Content = FriendCheckString[i], FontSize = 14, Name = "Label" + (i - 1).ToString(), FontWeight = FontWeights.UltraBold,
                                                   HorizontalAlignment = HorizontalAlignment.Center,
                                                   VerticalAlignment = VerticalAlignment.Center });
                Friend_Check.Children.Add(FriendCheckLabel[i - 1]);

                FriendCheckYes.Add(new Button() { Content = "接受", FontSize = 19, Name = "Yes" + (i - 1) });
                Yes.Children.Add(FriendCheckYes[i - 1]);
                FriendCheckNo.Add(new Button() { Content = "拒絕", FontSize = 19, Name = "No" + (i - 1) });
                No.Children.Add(FriendCheckNo[i - 1]);

                FriendCheckYes[i - 1].Click += new RoutedEventHandler(Yes_Click);
                FriendCheckNo[i - 1].Click += new RoutedEventHandler(No_Click);
            }
            UpdateFriendListBox();
        }

        private void ClearData()
        {
            FriendCheckLabel.Clear();
            FriendCheckYes.Clear();
            FriendCheckNo.Clear();
            Friend_Check.Children.Clear();
            Yes.Children.Clear();
            No.Children.Clear();
            Friend_ListBox.Items.Clear();
        }

        private void Yes_Click(object sender, RoutedEventArgs e)
        {
            for(int i = 0; i < FriendCheckLabel.Count; i++)
            {
                if (!LRDB.FriendStateCheck(FriendCheckLabel[i].Content.ToString(), ID))
                {
                    MessageBox.Show("對方已經是你好友或者對方已取消邀請");
                    Add.IsEnabled = true;
                    Cancel.IsEnabled = false;
                }
                else
                {
                    string buttonName = ((Button)(sender)).Name;
                    string indexStr = "";

                    for (int j = 0; j < buttonName.Length; j++)
                    {
                        if (buttonName[j] >= 48 && buttonName[j] <= 57)
                            indexStr += buttonName[j];
                    }

                    int indexInt = Convert.ToInt32(indexStr);
                    LRDB.InsertFriend(FriendCheckLabel[indexInt].Content.ToString(), ID, "Friend");
                    LRDB.InsertFriend(ID, FriendCheckLabel[indexInt].Content.ToString(), "Friend");
                    LRDB.DeleteFriend(FriendCheckLabel[indexInt].Content.ToString(), ID, "Friend_Check");
                    LRDB.CreateChatLog(FriendCheckLabel[indexInt].Content.ToString() + ID);
                }
            }
            ClearData();
            UpdateStackPanel();
        }

        private void No_Click(object sender, RoutedEventArgs e)
        {
            for(int i = 0; i < FriendCheckLabel.Count; i++)
            {
                if (!LRDB.FriendStateCheck(FriendCheckLabel[i].Content.ToString(), ID))
                {
                    MessageBox.Show("對方已取消邀請");
                    Add.IsEnabled = true;
                    Cancel.IsEnabled = false;
                }
                else
                {
                    string buttonName = ((Button)(sender)).Name;
                    string indexStr = "";

                    for (int j = 0; j < buttonName.Length; j++)
                    {
                        if (buttonName[j] >= 48 && buttonName[j] <= 57)
                            indexStr += buttonName[j];
                    }

                    int indexInt = Convert.ToInt32(indexStr);
                    LRDB.DeleteFriend(FriendCheckLabel[indexInt].Content.ToString(), ID, "Friend_Check");
                }
            }
            ClearData();
            UpdateStackPanel();
        }

        private void ClientTabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = Friend_ListBox.SelectedIndex;
            
            if (index != -1)
            {
                FriendName.Content = Friend_ListBox.Items[index].ToString();
                IndexRecord = ++index;
                LRDB.SelectChatLog(ID + FriendName.Content);
                LRDB.SelectChatLog(FriendName.Content + ID);
                ChatLog.Text = ChatRecord[IndexRecord];
                ChatRecord[IndexRecord] = "";
                ChatLog.ScrollToEnd();
            }

            if (LRDB.FriendStateCheck(ID_TB.Text, ID))
            {
                ID_Label.Visibility = Visibility.Visible;
                Add.Visibility = Visibility.Visible;
                Cancel.Visibility = Visibility.Visible;

                ID_Label.Content = ID_TB.Text;
                Add.IsEnabled = false;
                Cancel.IsEnabled = false;
            }
            else if (LRDB.CompareIAP(ID_TB.Text, "ID", "IAP") && ID != ID_TB.Text)
            {
                ID_Label.Visibility = Visibility.Visible;
                Add.Visibility = Visibility.Visible;
                Cancel.Visibility = Visibility.Visible;

                ID_Label.Content = ID_TB.Text;
                if (LRDB.CompareIAP(ID, "Friend_Check", ID_TB.Text))
                {
                    Add.IsEnabled = false;
                    Cancel.IsEnabled = true;
                }
                else
                {
                    Add.IsEnabled = true;
                    Cancel.IsEnabled = false;
                }
            }
            ClearData();
            UpdateStackPanel();
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Key == Key.Enter || e.Key == Key.Return) && IndexRecord != 0 && Chat_TB.Text.Trim() != "")
            {
                Chat_TB.Text = Chat_TB.Text.TrimEnd();
                Chat_TB.Text = ID + ":" + Chat_TB.Text;
                clientServer.SendMessage(Chat_TB.Text + "~@!#" + FriendName.Content + "!#~@" + ID);
                Chat_TB.Text = "";
                ChatLog.ScrollToEnd();
            }
        }

        public void LoadingChatLog()
        {
            while (true)
            {
                clientServer.ReceiveMessage();
                bool exist = false;
                if (isYoursNews.Contains(ID))
                {
                    for (int i = 1; i < FriendString.Count; i++)
                    {
                        if (isYoursNews.Contains(FriendString[i]))
                            exist = true;
                    }

                    if (exist)
                    {
                        string a;
                        a = isYoursNews.Substring(isYoursNews.IndexOf("~!@#"));
                        a = a.Remove(0, 4);
                        isYoursNews = isYoursNews.Remove(isYoursNews.IndexOf("~!@#"));
                        LRDB.SelectChatLog(a + isYoursNews);
                        LRDB.SelectChatLog(isYoursNews + a);
                        
                    }
                    
                }

                Action methodDelegate = delegate ()
                {
                    
                    ChatLog.Text = ChatRecord[IndexRecord];
                    ChatRecord[IndexRecord] = "";
                    ChatLog.ScrollToEnd();
                };
                this.Dispatcher.BeginInvoke(methodDelegate);
            }
        }
    }
}
