using Condos.Entities;

namespace Condos.WebAdmin.Models
{
    public class DataContextLocal : DataContext
    {
        public System.Data.Entity.DbSet<Condos.Entities.Usuario> Usuarios { get; set; }
    }
}