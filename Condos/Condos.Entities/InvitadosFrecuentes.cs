using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Condos.Entities
{
    public class InvitadosFrecuentes
    {

        [Key]
        public int InvitadoFrecuenteID { get; set; }

        public int UsuarioID { get; set; }

        [Required(ErrorMessage = "El campo {0} is required.")]
        [Display(Name = "Nombre Invitado")]
        public string NombreInvitado { get; set; }

        [Required(ErrorMessage = "El campo {0} is required.")]
        [Display(Name = "Identificación")]
        public string Identificacion { get; set; }

        [Display(Name = "Placa del Vehículo")]
        public string PlacaVehiculo { get; set; }

        [JsonIgnore]
        public virtual Usuario Usuario { get; set; }
    }
}
