using System;
namespace Condos.Models
{
    public class Calendario
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
