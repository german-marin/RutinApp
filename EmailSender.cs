using System;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace RutinApp
{
    public class EmailSender
    {
        public void EnviarEmail(string emailCliente, string asunto, string cuerpo, string archivoAdjunto = null)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.office365.com");

                // Configura los detalles del correo
                mail.From = new MailAddress("rutinapp@outlook.com");
                mail.To.Add(emailCliente);
                mail.Subject = asunto;
                mail.Body = cuerpo;

                // Si hay un archivo adjunto, añádelo al correo
                if (!string.IsNullOrEmpty(archivoAdjunto))
                {
                    Attachment attachment = new Attachment(archivoAdjunto);
                    mail.Attachments.Add(attachment);
                }

                // Configura los detalles del servidor SMTP
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new NetworkCredential("rutinapp@outlook.com", "passw0rdmol0n");
                SmtpServer.EnableSsl = true;

                // Envía el correo
                SmtpServer.Send(mail);
                MessageBox.Show("Correo enviado");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al enviar correo: {ex.Message}");
            }
        }
    }
}
