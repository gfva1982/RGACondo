using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Condos.Entities
{
  
    public class Usuario
    {
        [Key]
        public int UsuarioID { get; set; }

        public int InmuebleID { get; set; }

        [Required(ErrorMessage = "El campo {0} is required.")]
        [MaxLength(100, ErrorMessage = "Excedió el tamaña máximo permitido")]
        [Index("Usuario_NombreUsuario_Index", IsUnique = true)]
        public string NombreUsuario { get; set; }

        public string PrimerApellido { get; set; }

        public string SegundoApellido { get; set; }

        public string NombreCompleto { get; set; }

        public string TelefonoEmergencia { get; set; }

        public string Identificacion { get; set; }
        
        [JsonIgnore]
        public virtual Inmueble Inmueble { get; set; }


        [JsonIgnore]
        public virtual ICollection<InvitadosFrecuentes> InvitadosFrecuentes { get; set; }

    }
}
