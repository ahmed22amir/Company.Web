using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Company.Services.Helper
{
    public class EmailSettings
    {
        public static void SendEmail(Email email)
        {
            var Client = new SmtpClient("smtp.gmail.com",587);
            Client.EnableSsl = true;
            Client.Credentials = new NetworkCredential("ahmed12amir91@gmail.com", "lcomxrxdkatrbvaf");
            Client.Send("ahmed12amir91@gmail.com",email.to,email.Subject,email.Body);
        }
    }
}
