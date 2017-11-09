using System;
using System.IO;
using System.Web;

using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using Condos.WebAPI.Models;
using System.Net;

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



               

            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        public static  bool EnviarComentarios(ComentarioRequest pComentario, Stream pImagen)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("geovega1982@gmail.com");
            mail.To.Add("gvega@agt.cr");
            mail.Subject = string.Format("Comentario Enviado desde el app por : {0}",pComentario.Inquilino);



            string text = "Hola, necesito hablar ccon vos " +
               "mañana paso por tu casa. Saludos";


            var plainView =
                             AlternateView.CreateAlternateViewFromString(text,
                             Encoding.UTF8,
                             MediaTypeNames.Text.Plain);


            var html = "<h2>Comentario enviado desde la aplicación móvil</h2>" +
                       string.Format("<h5>Comentario: {0} </h5>",pComentario.Detalle) +
              "<img src='cid:imagen' />";

            var htmlView =
                AlternateView.CreateAlternateViewFromString(html,
                                        Encoding.UTF8,
                                        MediaTypeNames.Text.Html);



            var img = new LinkedResource(pImagen);


                        //new LinkedResource(pComentario.FullPath,
                        //MediaTypeNames.Image.Jpeg);
                        img.ContentId = "imagen";

            htmlView.LinkedResources.Add(img);


            mail.AlternateViews.Add(plainView);
            mail.AlternateViews.Add(htmlView);
            mail.IsBodyHtml = true;


            // Y lo enviamos a través del servidor SMTP...

            var smtp = new SmtpClient("smtp.live.com");
            smtp.Port = 25;
            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential("gfva1982@outlook.com", "Heredia2015");

            

            smtp.Send(mail);

            return true;

        }
    }
}
