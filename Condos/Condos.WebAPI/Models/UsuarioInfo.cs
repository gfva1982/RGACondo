using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Condos.WebAPI.Models
{
    public class UsuarioInfo
    {

        public int UsuarioID { get; set; }

        public int InmuebleID { get; set; }

        public string NombreUsuario { get; set; }

        public string PrimerApellido { get; set; }

        public string SegundoApellido { get; set; }

        public string NombreCompleto { get; set; }

        public string TelefonoEmergencia { get; set; }

        public string Identificacion { get; set; }

        public string DetalleInmueble { get; set; }
        public int IdCondo { get; internal set; }
        public string DescripcionCondo { get; internal set; }

        public List<InvitadosFrecuentesInfo> ListaInvitadosFrecuentes { get; set; }
    }
}