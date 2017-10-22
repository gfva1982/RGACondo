using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Condos.Entities
{
    public class Condominio
    {
        [Key]
        public int CondoID { get; set; }

        [Required(ErrorMessage = "El campo {0} is required.")]
        [MaxLength(500,ErrorMessage ="Excedió el tamaña máximo permitido")]
        [Index("Condominio_Descripcion_Index",IsUnique =true)]
        [Display(Name ="Descripción")]
        public string Descripcion { get; set; }

        public bool Estado { get; set; }

        [Required(ErrorMessage = "Ingresar una descripción")]
        [MaxLength(500, ErrorMessage = "Excedió el tamaña máximo permitido")]
        [Display(Name ="Ubicación")]
        public string Ubicacion { get; set; }

        [JsonIgnore]
        public virtual ICollection<Inmueble> Inmuebles { get; set; }

    }
}
