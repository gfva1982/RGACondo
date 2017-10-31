using Condos.Entities;

namespace Condos.WebAdmin.Models
{
    public class DataContextLocal : DataContext
    {
        public System.Data.Entity.DbSet<Condos.Entities.CalendarioZonasPublicas> CalendarioZonasPublicas { get; set; }
    }
}