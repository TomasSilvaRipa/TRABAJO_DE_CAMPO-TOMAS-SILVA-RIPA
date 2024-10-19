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

        public static bool EnviarMail(string Tema, string Descripcion, string Receptor)
        {
            try
            {
                // Configuración del cliente SMTP
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587, // El puerto SMTP (587 o 465 generalmente)
                    Credentials = new NetworkCredential(Emisor, "vhcq mrvv beqi yqwy"),
                    EnableSsl = true, // Activar SSL si es necesario
                };

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
                smtpClient.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
