using System.Collections.Generic;

namespace Condos.WebAPI.Models
{
    public class InmuebleCostume
    {

        public int InmuebleID { get; set; }

        public int CondoID { get; set; }
        
        public string Descripcion { get; set; }

        public string Image { get; set; }

        public bool EsPublico { get; set; }

        public bool Estado { get; set; }


        public string Comentario { get; set; }

        public List<CalendarioCostume> Calendario { get; set; }


    }
}