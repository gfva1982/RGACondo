﻿

using System.Data.Entity;

namespace Condos.Entities
{
    public class DataContext: DbContext
    {

        public DbSet<Condominio> Condominios { get; set; }

        public DbSet<Inmueble> Inmuebles { get; set; }

        public DataContext() :base("DefaultConnection")
        {

        }
    }
}