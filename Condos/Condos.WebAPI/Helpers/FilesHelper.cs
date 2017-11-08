using System;
using System.IO;
using System.Web;

using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using Condos.WebAPI.Models;

namespace Condos.WebAPI.Helpers
{
    public class FilesHelper
    {
       public static bool UploadPhoto(MemoryStream pStream, string pFolder, string pName)
        {
            try
            {
                pStream.Position = 0;

                var path = Path.Combine(HttpContext.Current.Server.MapPath(pFolder), pName);
                File.WriteAllBytes(path,pStream.ToArray());



                File.Delete();

            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        public static  bool EnviarComentarios(ComentarioRequest pComentario)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("geovega1982@gmail.com");
            mail.To.Add("gvega@agt.cr");
            mail.Subject = "Mensaje con imagen";



            string text = "Hola, necesito hablar ccon vos " +
               "mañana paso por tu casa. Saludos";


            var plainView =
                             AlternateView.CreateAlternateViewFromString(text,
                             Encoding.UTF8,
                             MediaTypeNames.Text.Plain);


            var html = "<h2>Hola, te perdiste de la fiesta de anoche, mira la foto:</h2>" +
              "<img src='cid:imagen' />";

            var htmlView =
                AlternateView.CreateAlternateViewFromString(html,
                                        Encoding.UTF8,
                                        MediaTypeNames.Text.Html);



            var img =
                        new LinkedResource(@"C:\fiesta.jpg",
                        MediaTypeNames.Image.Jpeg);
                        img.ContentId = "imagen";

            htmlView.LinkedResources.Add(img);


            mail.AlternateViews.Add(plainView);
            mail.AlternateViews.Add(htmlView);

            // Y lo enviamos a través del servidor SMTP...

            var smtp = new SmtpClient("smtp.nuestroservidor.com");
            smtp.Send(mail);

            return true;

        }
    }
}
