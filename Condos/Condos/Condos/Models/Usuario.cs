using System;
namespace Condos.Models
{
    public class Usuario
    {
        public int UsuarioID { get; set; }

        public int InmuebleID { get; set; }

        public string NombreUsuario { get; set; }

        public string PrimerApellido { get; set; }

        public string SegundoApellido { get; set; }

        public string NombreCompleto { get; set; }

        public string TelefonoEmergencia { get; set; }

        public string Identificacion { get; set; } 
    }
}
