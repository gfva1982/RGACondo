

using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Condos.Entities
{
    public class DataContext: DbContext
    {

        public DbSet<Condominio> Condominios { get; set; }

        public DbSet<Inmueble> Inmuebles { get; set; }

        public DataContext() :base("DefaultConnection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public DbSet<RegistroDeAcceso> RegistroDeAccesoes { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<InvitadosFrecuentes> InvitadosFrecuentes { get; set; }

    }
}
