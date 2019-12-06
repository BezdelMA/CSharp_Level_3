using System;
using System.Net;
using System.Net.Mail;
using System.Windows;

namespace MailSender
{
    public class EmailSendServiceClass
    {
        public EmailSendServiceClass()
        {

        }

        public void SendMail(string mailFrom, string password, string subject, string body)
        {
            MessageWindow messageWindow;
            int mailCounter = 0;
            try
            {
                foreach (string mail in MailSenderProperties.mailAdress)
                {
                    using (MailMessage message = new MailMessage(mailFrom, mail, subject, body))
                    {
                        message.IsBodyHtml = false;
                        using (SmtpClient client = new SmtpClient(MailSenderProperties.host, 25))
                        {
                            client.Credentials = new NetworkCredential(mailFrom, password);
                            client.EnableSsl = true;
                            try
                            {
                                client.Send(message);
                                mailCounter++;
                            }
                            catch (Exception ex)
                            {
                                messageWindow = new MessageWindow(ex.Message);
                                messageWindow.ShowDialog();
                            }
                        }
                    }
                }
                messageWindow = new MessageWindow(string.Format("Количество успешно направленных писем: {0}", mailCounter.ToString()));
                messageWindow.ShowDialog();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
