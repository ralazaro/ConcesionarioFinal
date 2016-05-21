using DomainModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ConcesionarioEntities : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Presupuesto> Presupuestos { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }

        public ConcesionarioEntities() : base("Data Source=RulesMan;Initial Catalog=Concesionario;Integrated Security=True") { }

        static ConcesionarioEntities()
        {
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuild)
        {
            modelBuild.Entity<Cliente>().ToTable("Clientes");
            modelBuild.Entity<Vehiculo>().ToTable("Vehiculos");
            modelBuild.Entity<Presupuesto>().ToTable("Presupuestos");

            Database.SetInitializer<ConcesionarioEntities>(null);
        }
    }
}