using Condos.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace Condos.WebAdmin.Models
{ 
    [NotMapped]
    public class InmuebleView :Inmueble
    {

        [Display(Name = "Imagen")]
        public HttpPostedFileBase ImagenFile { get; set; }
    }
}