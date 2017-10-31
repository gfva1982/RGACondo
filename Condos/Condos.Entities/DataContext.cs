

using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Condos.Entities
{
    public class DataContext: DbContext
    {

      

        

        public DataContext() :base("DefaultConnection")
        {

        }


        public DbSet<Condominio> Condominios { get; set; }

        public DbSet<Inmueble> Inmuebles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public DbSet<RegistroDeAcceso> RegistroDeAccesoes { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<InvitadosFrecuentes> InvitadosFrecuentes { get; set; }

        public System.Data.Entity.DbSet<Condos.Entities.CalendarioZonasPublicas> CalendarioZonasPublicas { get; set; }
    }
}
