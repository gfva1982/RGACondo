using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Condos.WebAPI.Models
{
    public class InvitadosFrecuentesInfo
    {
        public int InvitadoFrecuenteID { get; set; }

        public int UsuarioID { get; set; }

       
        public string NombreInvitado { get; set; }

        
        public string Identificacion { get; set; }

       
        public string PlacaVehiculo { get; set; }

    }
}