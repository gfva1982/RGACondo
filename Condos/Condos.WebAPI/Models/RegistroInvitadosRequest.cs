using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Condos.WebAPI.Models
{
    public class RegistroInvitadosRequest
    {
        public string Nombre { get; set; }

        public string Cedula { get; set; }

        public string Placa { get; set; }

        public DateTime Fecha { get; set; }

        public bool Recordar { get; set; }

        public string NombreUsuario { get; set; }

        
    }
}