using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace SGMI.Models
{
    public class ContextoDb : DbContext
    {
        public ContextoDb() : base("Contexto") { }

        public DbSet<MembrosModels> Membros { get; set; }

        public DbSet<CidadeModels> Cidade { get; set; }

        public DbSet<EstadoModels> Estado { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();            

            base.OnModelCreating(modelBuilder);
        }

    }
}