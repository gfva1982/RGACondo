using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public string PrimerApellido { get; set; }

        public string SegundoApellido { get; set; }

        public string NombreCompleto { get; set; }

        public string TelefonoEmergencia { get; set; }

        public string Identificacion { get; set; }

        public string ClaveValidacion { get; set; }

        public string MyProperty { get; set; }

        [JsonIgnore]
        public virtual Inmueble Inmueble { get; set; }


    }
}
