using System;
using System.Net.Mail;
using System.Net;
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

namespace MailSender
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        EmailSendServiceClass email = new EmailSendServiceClass();
        Account account = new Account();
        MessageWindow messageWindow;

        public MainWindow()
        {
            InitializeComponent();
            Account.LAccount.Add(new Account("TestCSHarp3@mail.ru", "p1c1TB4i"));
            cbMail.ItemsSource = account.ListName;
            pbPassword.GotFocus += PbPassword_GotFocus;
            pbPassword.LostFocus += PbPassword_LostFocus;
        }

        private void PbPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            if (pbPassword.Password == "")
                pbPassword.Password = "Введите пароль";
        }

        private void PbPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            if (pbPassword.Password == "Введите пароль")
                pbPassword.Clear();
        }

        private void btnSendMail_Click(object sender, RoutedEventArgs e)
        {
            if (account.CheckAccount(cbMail.SelectedIndex, pbPassword.Password))
                email.SendMail(cbMail.SelectedItem.ToString(), pbPassword.Password, tbSubject.Text, tbBody.Text);
            else
            {
                messageWindow = new MessageWindow("Введены не верные данные");
                messageWindow.ShowDialog();
            }
        }

        private void btnAddNewAccount_Click(object sender, RoutedEventArgs e)
        {
            AddNewAccount addNewAccount = new AddNewAccount();
            addNewAccount.Owner = this;
            addNewAccount.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            if (addNewAccount.ShowDialog() == true)
                cbMail.ItemsSource = account.ListName;
        }
    }
}
