using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Condos.WebAPI.Models
{
    public class RegistroInvitado
    {

      

        public int CondoID { get; set; }
  
        public string NombreInvitado { get; set; }

       
        public string Identificacion { get; set; }

      
        public string PlacaVehiculo { get; set; }

      
        public DateTime FechaAcceso { get; set; }

       
        public string NombreAutoriza { get; set; }


        public string Destino { get; set; }

        public bool Registra { get; set; }



    }
}