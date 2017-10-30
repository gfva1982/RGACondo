using System;
namespace Condos.Models
{
    public class Inmueble
    {
        #region Properties

        public int InmuebleID { get; set; }

        public int CondoID { get; set; }

        public string Descripcion { get; set; }

        public string Image { get; set; }

        public bool EsPublico { get; set; }

        public bool Estado { get; set; }

        public string Comentario { get; set; }

        public string ImageFullPath
        {
            get
            {
                return string.Format("http://condoscrwebadmin.azurewebsites.net/{0}", Image.Substring(1));
            }

        }

        #endregion
    }
}
