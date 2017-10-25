using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

namespace Condos.Entities
{
    public class RegistroDeAcceso
    {
        [Key]
        public int RegistroID { get; set; }

        public int CondoID { get; set; }


        [Required(ErrorMessage = "El campo {0} is required.")]
        [Display(Name = "Nombre Invitado")]
        public string NombreInvitado { get; set; }

        [Required(ErrorMessage = "El campo {0} is required.")]
        [Display(Name = "Identificación")]
        public string Identificacion { get; set; }

        [Display(Name = "Placa del Vehículo")]
        public string PlacaVehiculo { get; set; }

        [Required(ErrorMessage = "El campo {0} is required.")]
        [Display(Name = "Fecha del Acceso")]
        public DateTime FechaAcceso { get; set; }


        [Display(Name = "Destino")]
        public string DescripcionInmueble { get; set; }

        public Nullable <DateTime> FechaIngreso { get; set; }

        [Required(ErrorMessage = "El campo {0} is required.")]
        public string NombreAutoriza { get; set; }

        [Display(Name = "Autoriza")]
        public string UsuarioValidaAcceso { get; set; }

        public string Comentarios { get; set; }

       
        public Nullable< DateTime> FechaSalida { get; set; }


        [JsonIgnore]
        public virtual Condominio Condominio { get; set; }

    }
}
