using System;
using System.Net.Mail;

namespace BlackBall.Models
{
    public class Mailer
    {
        public void SendMail(string sendersName, string sendersEmailAddress, string recipientsName, string recipientsEmailAddress, string subject, string body, bool isBodyHtml = false)
        {
            var msg = new MailMessage();
            msg.From = new MailAddress(sendersEmailAddress, sendersName);
            msg.To.Add(new MailAddress(recipientsEmailAddress, recipientsName));
            msg.Subject = subject;
            msg.Body = body;
            msg.IsBodyHtml = isBodyHtml;

            using (SmtpClient client = new SmtpClient())
            {
                client.Send(msg);
            }
        }
    }
}
