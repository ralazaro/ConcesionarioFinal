using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IVehiculoService : IService<Vehiculo>
    {
        void AñadirPresupuesto(Vehiculo v, Presupuesto p);
        ICollection<Presupuesto> PresupuestosPorVehiculo(Vehiculo v);
    }
}
