using System.Net;
using System.Net.Mail;

namespace ProgramacaoDoZero.Common
{
    public class EmailSender
    {
        private string emailDestino;

        public void Enviar(string assunto, string corpo, string emailDestino)
        {

        }
        //dispara email
        public void EnviarEmail(string toEmail, string assunto, string corpo)
        {
            var fromEmail = "contato@renatogava.com.br";
            var fromPassword = "5yoJ8x21JAw%";
            var fromHost = "smtp.zoho.com";
            var fromPort = 587;

            MailMessage mail = new MailMessage();

            mail.From = new MailAddress(fromEmail);

            mail.To.Add(new MailAddress(emailDestino));

            mail.Subject = assunto;

            mail.Body = corpo;

            using (SmtpClient smtp = new SmtpClient(fromHost, fromPort))
            {
                smtp.UseDefaultCredentials = false;

                smtp.Credentials = new NetworkCredential(fromEmail, fromPassword);

                smtp.EnableSsl = true;

                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                smtp.Send(mail);

            }
        }
    }
}
