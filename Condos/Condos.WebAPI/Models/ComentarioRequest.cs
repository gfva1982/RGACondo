using System;
namespace Condos.WebAPI.Models
{
    public class ComentarioRequest
    {
        public string Detalle
        {
            get;
            set;
      
        }

        public byte[] ImageArray
        {
            get;
            set;
        }

        public string Inquilino
        {
            get;
            set;
        
        }

        public string CorreoElectronico
        {
            get;
            set;
        }

        public string FullPath;
        {
            get;
            set;
        }


    }
}
