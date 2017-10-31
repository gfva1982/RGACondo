using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Condos.Entities
{
    public class Inmueble
    {
        [Key]
        public int InmuebleID { get; set; }

        public int CondoID { get; set; }

        [Required(ErrorMessage = "El campo {0} is required.")]
        [MaxLength(500, ErrorMessage = "Excedió el tamaña máximo permitido")]
        [Index("Inmueble_Descripcion_Index", IsUnique = true)]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        public string Image { get; set; }

        [Required(ErrorMessage = "El campo {0} is required.")]
        [Display(Name = "Es Público")]
        public bool EsPublico { get; set; }

        [Required(ErrorMessage = "El campo {0} is required.")]
        [Display(Name = "Habilitado")]
        public bool Estado { get; set; }


        [MaxLength(500, ErrorMessage = "Excedió el tamaña máximo permitido")]
        [DataType(DataType.MultilineText)]
        public string Comentario { get; set; }

        [JsonIgnore]
        public virtual Condominio Condominio { get; set; }

        [JsonIgnore]
        public virtual ICollection<Usuario> Usuarios { get; set; }

        [JsonIgnore]
        public virtual ICollection<CalendarioZonasPublicas> Calendario {get;set;}


    }
}
