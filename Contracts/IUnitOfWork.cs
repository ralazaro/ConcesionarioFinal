using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IUnitOfWork
    {
        IClienteRepository RClientes { get; }
        IVehiculoRepository RVehiculos { get; }
        IPresupuestoRepository RPresupuestos { get; }

        void Comenzar();
        void Terminar();
        void SaveChanges();
        void RollBack();
    }
}
