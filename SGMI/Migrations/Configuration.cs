namespace SGMI.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SGMI.Models.ContextoDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SGMI.Models.ContextoDb context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Estado.AddOrUpdate(
                p => p.Id,
                new EstadoModels { Nome = "Acre", Sigla = "AC" },
                new EstadoModels { Nome = "Parana", Sigla = "PR" },
                new EstadoModels { Nome = "Santa Catarina", Sigla = "SC" },
                new EstadoModels { Nome = "Sao Paulo", Sigla = "SP" }
            );

            context.Cidade.AddOrUpdate(
                  p => p.Id,
                  new CidadeModels { Nome = "Maringa", EstadoId = 1},
                  new CidadeModels { Nome = "Cianorte", EstadoId = 1 },
                  new CidadeModels { Nome = "Cidade Gaucha", EstadoId = 1 },
                  new CidadeModels { Nome = "Curitiba", EstadoId = 1 },
                  new CidadeModels { Nome = "São Paulo", EstadoId = 1 }
                );
        }
    }
}
