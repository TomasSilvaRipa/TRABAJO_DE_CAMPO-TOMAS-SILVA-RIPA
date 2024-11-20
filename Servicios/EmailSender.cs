using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class EmailSender
    {
        internal static string Emisor = "RentHub.Notifier@gmail.com";

        public static async Task<bool> EnviarMail(string Tema, string Descripcion, string Receptor)
        {
            try
            {
                using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com"))
                {
                    smtpClient.Port = 587; // El puerto SMTP (587 o 465 generalmente)
                    smtpClient.Credentials = new NetworkCredential(Emisor, "vhcq mrvv beqi yqwy");
                    smtpClient.EnableSsl = true; // Activar SSL si es necesario

                    // Crear el correo
                    MailMessage mail = new MailMessage
                    {
                        From = new MailAddress(Emisor),
                        Subject = Tema,
                        Body = Descripcion,
                        IsBodyHtml = true // Si quieres que el cuerpo sea en HTML
                    };

                    // Destinatarios
                    mail.To.Add(Receptor);

                    // Enviar el correo
                    await smtpClient.SendMailAsync(mail);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
