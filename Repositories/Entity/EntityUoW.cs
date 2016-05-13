using Contracts;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class EntityUoW : IUnitOfWork
    {
        ConcesionarioEntities Context;

        IClienteRepository rClientes;
        public IClienteRepository RClientes { get; set; }
        IVehiculoRepository rVehiculos;
        public IVehiculoRepository RVehiculos { get; set; }
        IPresupuestoRepository rPresupuestos;
        public IPresupuestoRepository RPresupuestos { get; set; }

        public EntityUoW()
        {
            Context = new ConcesionarioEntities();
            Context.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public void Comenzar()
        {
            try
            {
                this.RClientes = new EFClienteRepository(Context);
                this.rClientes = this.RClientes;
                this.RVehiculos = new EFVehiculoRepository(Context);
                this.rVehiculos = this.RVehiculos;
                this.RPresupuestos = new EFPresupuestoRepository(Context);
                this.rPresupuestos = this.RPresupuestos;
            }
            catch (Exception e)
            {
            }
        }

        public void RollBack()
        {
            try
            {
                if (Context.Database != null)
                    Context.Database.CurrentTransaction.Rollback();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }

        public void Terminar()
        {
            //Context.Dispose();
        }

    }
}
