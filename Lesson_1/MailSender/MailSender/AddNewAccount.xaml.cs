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

namespace MailSender
{
    /// <summary>
    /// Логика взаимодействия для AddNewAccount.xaml
    /// </summary>
    public partial class AddNewAccount : Window
    {
        public AddNewAccount()
        {
            InitializeComponent();
        }

        private void btnAddNewAccount_Click(object sender, RoutedEventArgs e)
        {
            Account account = new Account();
            if (account.CheckNewPassword(tbNewPassword.Text, tbCheckNewPassword.Text))
            {
                account.Name = tbNewMail.Text;
                account.Password = tbNewPassword.Text;
                account.ListAdd(account);
                DialogResult = true;
                this.Close();
            }
        }
    }
}
