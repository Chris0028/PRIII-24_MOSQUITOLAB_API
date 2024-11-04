using System.Net;
using System.Net.Mail;

namespace MosquitoLaboratorio.Utils
{
    public class CustomSMTPClient
    {
        public void SendEmail(string fromEmail, string toEmail, string content)
        {
            try
            {
                using var smtpClient = new SmtpClient();
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.EnableSsl = true;
                smtpClient.Host = "smtp.gmail.com";
                smtpClient.Port = 587;
                smtpClient.Credentials = new NetworkCredential(fromEmail, "ofzb qroc edyo gdsj");
                smtpClient.Send(fromEmail, toEmail, "SEDES", content);
            }
            catch(SmtpException e)
            {
                Console.WriteLine(e.Message.ToString());
            }
        }
    }
}
