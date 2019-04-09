using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Guardllet_Desarrollo.Backend.Emails
{
    public class EnviarCorreo
    {
        public static bool Registro(string para) 
        {
            try
            {
                System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();

                msg.To.Add(para);
                msg.Subject = "BIENVENIDO";
                msg.SubjectEncoding = System.Text.Encoding.UTF8;

                msg.Body = "Registro Exitoso";
                msg.BodyEncoding = System.Text.Encoding.UTF8;
                msg.IsBodyHtml = true;

                msg.From = new System.Net.Mail.MailAddress("guardllet@gmail.com");

                System.Net.Mail.SmtpClient clt = new System.Net.Mail.SmtpClient();
                clt.Credentials = new System.Net.NetworkCredential("guardllet@gmail.com", "asdfg312");
                clt.Port = 587;
                clt.EnableSsl = true;
                clt.Host = "smtp.gmail.com";

                clt.Send(msg);

                return true;
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
                return false;
            }
        }
    }
}