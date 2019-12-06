using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender
{
    public static class MailSenderProperties
    {
        public static List<string> mailAdress = new List<string>()
        {
            "BezdelMA@mail.ru", "Mavi08@rambler.ru"
        };
        public static string host = "smtp.mail.ru";
        public static int port = 25;

    }
}
