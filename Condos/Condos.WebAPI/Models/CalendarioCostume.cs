using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Condos.WebAPI.Models
{
    public class CalendarioCostume
    {
        public Int64 ZonaPublicaID { get; set; }

        public int InmuebleID { get; set; }

        public DateTime Fecha { get; set; }

       
        public DateTime HoraInicio { get; set; }

       
        public DateTime HoraFinal { get; set; }

        public string Comentarios { get; set; }

        public int Estado { get; set; }

        public int UsuarioID { get; set; }
    }
}