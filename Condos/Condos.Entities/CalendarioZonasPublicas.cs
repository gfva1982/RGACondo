using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace Condos.Entities
{
    public class CalendarioZonasPublicas
    {
        [Key]
        public Int64 ZonaPublicaID { get; set; }

        public int InmuebleID { get; set; }

        public DateTime Fecha { get; set; }

        [Display(Name ="Hora Inicio")]
        public DateTime HoraInicio { get; set; }

        [Display(Name = "Hora Final")]
        public DateTime HoraFinal { get; set; }

        public string Comentarios { get; set; }

        public int Estado { get; set; }

        public int UsuarioID { get; set; }

        [JsonIgnore]
        public virtual Inmueble Inmueble { get; set; }
    }
}
