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

        //public ConcesionarioEntities() : base("Data Source=GAJOVA\\SQLEXPRESS; Integrated security=SSPI; Initial Catalog=Concesionario;") {}
        public ConcesionarioEntities() : base("Data Source=RulesMan;Initial Catalog=Concesionario;Integrated Security=True") { }


        static ConcesionarioEntities()
        {
            // ROLA - This is a hack to ensure that Entity Framework SQL Provider is copied across to the output folder.
            // As it is installed in the GAC, Copy Local does not work. It is required for probing.
            // Fixed "Provider not loaded" error
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuild)
        {
            modelBuild.Entity<Presupuesto>().ToTable("Presupuestos");
            modelBuild.Entity<Vehiculo>().ToTable("Vehiculos");
            modelBuild.Entity<Cliente>().ToTable("Clientes");
            Database.SetInitializer<ConcesionarioEntities>(null);
        }
    }
}